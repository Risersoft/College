Imports System.Data.Common
Imports System.Data.SqlClient
Imports risersoft.app.mxent
Imports risersoft.shared
Imports risersoft.shared.dal

Public Class UP_StuTaskProvider
    Inherits clsTaskProviderBase
    'Upload Studenr
    Dim conn As DbConnection, objExec As clsOLEDBExecutor
    Public Overrides ReadOnly Property IsApiTask As Boolean = False

    Public Sub New(controller As clsAppController)
        MyBase.New(controller)
    End Sub

    Public Overrides Function ExecutePostLocal(rTask As DataRow, input As clsProcOutput) As clsProcOutput
        Dim oRet As New clsProcOutput
        Return oRet
    End Function

    Public Overrides Function ExecutePreLocal(rTask As DataRow) As Task(Of clsProcOutput)
        Dim dbconn As New clsDBConnector(New clsOLEDBExecutor())
        Dim oRet As New clsProcOutput

        Dim strConn As String = myUtils.cStrTN(rTask("dbconnstring"))
        conn = dbconn.OpenConnFromString(strConn, "task")


        Dim Sql As String = "select EmployeeName,Gender,DOB,NumericCode,Employees.DepartmentID,DOJ,PANNo,DepartmentSName,DepartmentFName from Employees inner join Departments on Employees.DepartmentID = Departments.DepartmentID where Employees.RecordStatus = 1"
        Dim dsAcc As DataSet = dbconn.Executor.ExecuteDataset(conn, Nothing, CommandType.Text, Sql)

        myUtils.AddTable(oRet.Data, dsAcc, "Access")
        Return Task.FromResult(oRet)
    End Function

    Public Overrides Function ExecuteServer(rTask As DataRow, input As clsProcOutput) As Task(Of clsProcOutput)
        Dim oRet As New clsProcOutput
        Dim dsAcc = input.Data

        Dim dic As New clsCollecString(Of String)
        dic.Add("stu", "Select * from Student")
        dic.Add("person", "Select * from Persons")
        Dim dsSql As DataSet = myContext.DataProvider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)
        myContext.Tables.SetAuto(dsSql.Tables("person"), dsSql.Tables("stu"), "PersonID", "_stu")
        Dim dsTarget As DataSet = dsSql.Clone

        For Each r1 As DataRow In dsAcc.Tables(0).Select()
            Dim rPer, rStu As DataRow

            Dim rr() As DataRow = dsSql.Tables("stu").Select("SerialNo = '" & myUtils.cStrTN(r1("NumericCode")) & "'")
            If rr.Length = 0 Then
                Dim ClassID As Integer = myCollegeFuncs.GenerateClass(myContext, r1)

                rPer = myUtils.CopyOneRow(r1, dsTarget.Tables("person"))
                rPer("FirstName") = myUtils.cStrTN(r1("EmployeeName"))
                rPer("FullName") = myUtils.cStrTN(r1("EmployeeName"))
                rPer("IsFemale") = myUtils.IsInList(myUtils.cStrTN(r1("Gender")), "Female")
                rPer("Birthday") = myUtils.cDateTN(r1("DOB"), DateTime.MinValue)


                rStu = myUtils.CopyOneRow(r1, dsTarget.Tables("stu"))
                rStu("SerialNo") = myUtils.cStrTN(r1("NumericCode"))
                rStu("PersonID") = myUtils.cValTN(rPer("PersonID"))
                rStu("ClassID") = ClassID
                rStu("AdmissionDate") = myUtils.cDateTN(r1("DOJ"), DateTime.MinValue)
                rStu("CampusId") = 1
                rStu("ShiftID") = 1
                rStu("OnRolls") = 1
                rStu("PunchEnabled") = 1
                rStu("RollNum") = myUtils.cStrTN(r1("PANNo"))
                rStu("SortIndex") = myUtils.cValTN(r1("PANNo"))
            End If
        Next


        Dim Descrip As String = "Student Import"
        Try
            myContext.DataProvider.dbConn.BeginTransaction(myContext, "", EnumfrmMode.acEditM, "", "")

            myContext.DataProvider.objSQLHelper.SaveResults(dsTarget.Tables("person"), "SELECT PersonID, FirstName, FullName, IsFemale, Birthday  FROM Persons")
            myContext.DataProvider.objSQLHelper.SaveResults(dsTarget.Tables("stu"), "SELECT StudentID, PersonID, ClassID, SerialNo, AdmissionDate, CampusID, ShiftID, OnRolls, RollNum,SortIndex,PunchEnabled FROM Student")

            myContext.DataProvider.dbConn.CommitTransaction(Descrip, "")
            oRet.AddMessage("Saved Successfully.")
        Catch ex As Exception
            myContext.DataProvider.dbConn.RollBackTransaction(Descrip, ex.Message)
            oRet.AddError(ex.Message)
        End Try

        Return Task.FromResult(oRet)
    End Function
End Class