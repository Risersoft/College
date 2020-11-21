Imports System.Data.Common
Imports System.Data.SqlClient
Imports Microsoft.Extensions.Logging
Imports risersoft.app.mxent
Imports risersoft.shared
Imports risersoft.shared.dal

Public Class UP_PunchFileTaskProvider
    Inherits clsTaskProviderBase
    'Upload Punch
    Dim conn As DbConnection, objExec As clsOLEDBExecutor
    Public Overrides ReadOnly Property IsApiTask As Boolean = False

    Public Sub New(controller As clsAppController)
        MyBase.New(controller)
    End Sub

    Public Overrides Function ExecutePostLocal(rTask As DataRow, input As clsProcOutput) As clsProcOutput
        'TODO: Delete punches more than 1 month old
        Dim oRet As New clsProcOutput
        Return oRet
    End Function

    Public Overrides Function ExecutePreLocal(rTask As DataRow) As Task(Of clsProcOutput)
        Dim dbconn As New clsDBConnector(New clsOLEDBExecutor())
        Dim PunchDate As Date, oRet As New clsProcOutput

        Dim strConn As String = myUtils.cStrTN(rTask("dbconnstring"))
        conn = dbconn.OpenConnFromString(strConn, "task")


        Dim Sql As String = "Select Top 1 PunchDate from PunchData Order by PunchDate Desc"
        Dim dt2 As DataTable = myContext.DataProvider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql).Tables(0)
        If (Not IsNothing(dt2)) AndAlso dt2.Rows.Count > 0 Then
            PunchDate = dt2(0)("PunchDate")
        Else
            Sql = "Select Top 1 HRStartDate from Company"
            Dim r2 As DataRow = myContext.DataProvider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql).Tables(0).Rows(0)
            PunchDate = r2("HRStartDate")
        End If


        If Not IsNothing(PunchDate) Then
            Dim Dated As Date = PunchDate
            Dim CodeList As New List(Of String)
            Do While (Dated <= Now.Date)
                CodeList.Add("_" & Dated.Month & "_" & Dated.Year & "")
                Dated = Dated.AddMonths(1)
            Loop

            Dim ds As New DataSet, ds1 As New DataSet
            Dim dtSchema = conn.GetSchema("Tables")
            For Each Value In CodeList
                Dim rr() As DataRow = dtSchema.Select("Table_Name = 'DeviceLogs" & Value & "'")
                If rr.Length > 0 Then
                    Sql = "Select * from DeviceLogs" & Value & " where LogDate >=(#" & Format(PunchDate.AddDays(-2), "yyyy-MM-dd HH:mm:ss") & "#)"
                    Dim dt As DataTable = dbconn.Executor.ExecuteDataset(conn, Nothing, CommandType.Text, Sql).Tables(0)
                    myUtils.AddTable(ds, dt, Value)
                    If ds1.Tables.Count = 0 Then ds1.Tables.Add(dt.Clone)
                End If
            Next

            For Each table As DataTable In ds.Tables
                myUtils.CopyRows(table.Select, ds1.Tables(0))
            Next


            Sql = "select * from Employees"
            Dim ds2 As DataSet = dbconn.Executor.ExecuteDataset(conn, Nothing, CommandType.Text, Sql)


            myUtils.AddTable(oRet.Data, ds1, "Punch")
            myUtils.AddTable(oRet.Data, ds2, "Stu")
        End If
        Return Task.FromResult(oRet)
    End Function

    Public Overrides Function ExecuteServer(rTask As DataRow, input As clsProcOutput) As Task(Of clsProcOutput)
        Dim oRet As New clsProcOutput
        Dim ds = input.Data
        Dim dic As New clsCollecString(Of String)
        dic.Add("punch", "Select * from punchdata where 0=1")
        dic.Add("stu", "Select StudentID, SUBSTRING(SerialNo, PATINDEX('%[^0]%', SerialNo+'.'), LEN(SerialNo)) as SerialNo, CardNum From Student where onrolls=1")
        dic.Add("campus", "select * from campus")
        Dim ds2 As DataSet = myContext.DataProvider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)
        Dim dsTarget As DataSet = ds2.Clone
        ds.Tables("punch").Columns.Add("Upload", GetType(String))
        For Each r1 As DataRow In ds.Tables(0).Select("", "UserID,LogDate")
            For Each rFileStu As DataRow In ds.Tables("stu").Select("NumericCode=" & r1("UserID"))
                'myContext.Logger.Information("SerialNo. - " & myUtils.cStrTN(rFileStu("NumericCode")) & " - " & r1("LogDate") & " Saved Success.")


                Dim nr As DataRow
                Try
                    Dim rrStu() As DataRow = ds2.Tables("stu").Select(String.Format("SerialNo='{0}'", myUtils.cStrTN(rFileStu("NumericCode"))))
                    If rrStu.Length > 0 Then
                        Dim rrCampus() As DataRow = ds2.Tables("campus").Select()
                        If rrCampus.Length > 0 Then
                            nr = myUtils.CopyOneRow(r1, dsTarget.Tables(0))
                            nr("StudentID") = myUtils.cValTN(rrStu(0)("StudentID"))
                            nr("CampusId") = myUtils.cValTN(rrCampus(0)("CampusId"))
                            nr("PunchDate") = CDate(r1("LogDate")).Date
                            nr("PunchTime") = Format(r1("LogDate"), "HH:mm")
                            myContext.DataProvider.objSQLHelper.SaveResults(dsTarget.Tables(0), "SELECT StudentID,PUNCHDATE,PUNCHTIME,INOUT,CampusId FROM PunchData")
                            r1("upload") = "Y"
                        End If
                    End If
                Catch ex As SqlException
                    If ex.Number = 2601 OrElse ex.Number = 2627 Then
                        r1("upload") = "Y"
                    Else
                        Dim str1 = ex.Message & vbCrLf & myUtils.RowValuesText(r1)
                        'Trace.WriteLine(str1)

                        myContext.Logger.LogInformation(str1)
                        oRet.AddError(str1)
                    End If
                    If Not nr Is Nothing Then nr.Delete()
                Catch ex2 As Exception
                    If Not nr Is Nothing Then nr.Delete()
                    Dim str1 = ex2.Message & vbCrLf & myUtils.RowValuesText(r1)
                    'Trace.WriteLine(str1)
                    myContext.Logger.LogInformation(str1)
                    oRet.AddError(str1)
                End Try
            Next
        Next

        Dim objPayPeriod As New clsPayPeriodStu(myContext)
        Dim NewPayPeriodID, OldPayPeriodID As Integer
        For Each rStu As DataRow In ds2.Tables("stu").Select()
            NewPayPeriodID = 0
            OldPayPeriodID = 0
            For Each rPunch As DataRow In dsTarget.Tables(0).Select("StudentID = " & myUtils.cValTN(rStu("StudentID")) & "", "punchdate")
                Dim CompanyID As Integer = myCollegeFuncs.GetInstitutionIDFromCampus(myContext, myUtils.cValTN(rPunch("CampusID")))
                Dim rPP As DataRow = myCollegeFuncs.PPRow(myContext, CompanyID, rPunch("PunchDate"))
                NewPayPeriodID = myUtils.cValTN(rPP("PayPeriodID"))
                If NewPayPeriodID <> OldPayPeriodID Then
                    objPayPeriod.CalculateAbsentDays(NewPayPeriodID, rStu("StudentID"))
                End If
                OldPayPeriodID = NewPayPeriodID
            Next
        Next

        Dim oProc As New CLSProcessPunch(myContext)
        For Each r1 As DataRow In myContext.Data.SelectDistinct(dsTarget.Tables(0), "PunchDate").Select
            Dim StudentIDCSV As String = myUtils.MakeCSV(dsTarget.Tables(0).Select("PunchDate='" & Format(r1("PunchDate"), "dd-MMM-yyyy") & "'"), "StudentID")
            Dim strf1 As String = "StudentID in (" & StudentIDCSV & ")"
            oProc.processPunch(r1("PunchDate"), strf1)
            oProc.processPunch(DateAdd(DateInterval.Day, -1, r1("PunchDate")), strf1)
        Next
        oRet.Data = ds
        Return Task.FromResult(oRet)
    End Function
End Class