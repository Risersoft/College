Imports risersoft.shared
Imports risersoft.app.mxent
Imports System.Runtime.Serialization

<DataContract>
Public Class frmPayPeriodModel
    Inherits clsFormDataModel
    Dim rInstitute As DataRow

    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("Holiday")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        Dim sql As String = "Select RateMasterId,  'Rate Master Dt. ' + convert(varchar,dated,106) as Descrip , Dated from RateMaster inner join Company on RateMaster.CompanyID = Company.CompanyID"
        Me.AddLookupField("RateMasterId", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "rm").TableName)
    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql1 As String
        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        Dim sql As String = "Select * from PayPeriod where PayPeriodID = " & prepIDX
        Me.InitData(sql, "CompanyID", oView, prepMode, prepIDX, strXML)

        AssignMasters()

        sql = "select HoliDayId, PayPeriodID, CampusID, Dated, Holiday, Isworking from Holiday where CampusID In (Select CampusID  from Campus where CompanyID In (Select CompanyID from RateMaster where RateMasterID= " & myUtils.cValTN(myRow("RateMasterID")) & ")) And Dated > = '" & Format(myRow("SDate"), "yyyy-MMM-dd") & "' and Dated < = '" & Format(myRow("EDate"), "yyyy-MMM-dd") & "' and PayPeriodID = " & frmIDX & ""
        myView.MainGrid.QuickConf(sql, True, "1-1-1-1")
        sql1 = " Select CampusID, DispName  from Campus where CompanyID In (Select CompanyID from RateMaster where RateMasterID = " & myUtils.cValTN(myRow("RateMasterID")) & ") "
        myView.MainGrid.PrepEdit("<BAND INDEX=""0"" TABLE=""HOLIDAY"" IDFIELD=""HOLIDAYID""><COL KEY=""Dated,Holiday,PayPeriodID""/><COL KEY=""Isworking"" CAPTION=""Working Type"" VLIST=""False;Holiday|True;Working""/><COL KEY=""CampusID"" CAPTION=""Campus"" WFACTOR=""2"" LOOKUPSQL = """ & sql1 & """/></BAND>", EnumEditType.acCommandAndEdit)

        If (Not ((frmMode = EnumfrmMode.acEditM) AndAlso (myUtils.cBoolTN(myRow("isfinal"))))) Then Me.FormPrepared = True

        Return Me.FormPrepared
    End Function

    Private Sub AssignMasters()
        Dim dt As DataTable, sql As String
        rInstitute = myCollegeFuncs.rInstitute(myContext, Me.vBag("CompanyID"))
        myRow("CompanyID") = rInstitute("CompanyID")

        If Me.frmMode = EnumfrmMode.acAddM Then
            Dim str1 As String = "RateMasterId In (Select RateMasterId from RateMaster where CompanyID=" & myUtils.cValTN(myRow("CompanyID")) & ")"
            If myUtils.cStrTN(Me.vBag("TYPE")).Trim.ToLower = "old" Then
                sql = "Select top 1 (SDate) As st from PayPeriod where " & str1 & "  order by SDate asc"
            Else
                sql = "Select top 1 (EDate) As ed from PayPeriod where " & str1 & " order by EDate desc"
            End If
            dt = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
            If dt.Rows.Count > 0 Then
                If myUtils.cStrTN(Me.vBag("TYPE")).Trim.ToLower = "old" Then
                    myRow("sdate") = DateAdd("m", -1, dt.Rows(0)(0))
                Else
                    myRow("sdate") = DateAdd("d", 1, dt.Rows(0)(0))
                End If
            Else
                myRow("sdate") = rInstitute("HRStartDate")

            End If
            myRow("edate") = DateAdd("d", -1, DateAdd("m", 1, myRow("sdate")))
        End If

        myCollegeFuncs.AssignMasters(myContext, myRow.Row)

        sql = "Select PostPeriodID, Descrip from PostPeriod inner join FinYears On PostPeriod.FinYearID = FinYears.FinYearID And PostPeriod.TenantID = FinYears.TenantID"
        Me.AddLookupField("PostPeriod", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "PostPeriod").TableName)

        If myRow("SDate") < rInstitute("hrStartDate") Then myRow("isFinal") = True
    End Sub

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        If myUtils.NullNot(myRow("SDate")) Then Me.AddError("SDate", "Select a starting Date")
        If myUtils.NullNot(myRow("eDate")) Then Me.AddError("eDate", "Select an ending Date")
        If Me.SelectedRow("RateMasterID") Is Nothing Then Me.AddError("RateMasterID", "Select a Rate Master")
        If myUtils.cStrTN(myRow("PayPeriodName")).Trim.Length = 0 Then Me.AddError("PayPeriodName", "Enter a Description")
        If myUtils.NullNot(myRow("Ratemasterid")) Then Me.AddError("PayPeriodName", "Date Out Of Range")

        myView.MainGrid.CheckValid("Dated,isworking,holiday,CampusID", , , "<CHECK COND=""Dated&gt;='" & Format(myRow("sdate"), "yyyy-MMM-dd") & "' AND Dated&lt;='" & Format(myRow("edate"), "yyyy-MMM-dd") & "'"" MSG=""Select Date within limits""/>")
        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False

        If Me.Validate Then
            Dim PayperiodDescrip As String = myUtils.cStrTN(myRow("PayPeriodName"))
            Try
                If frmMode = EnumfrmMode.acAddM Then
                    myRow("isfinal") = False
                    myRow("isfinalwot") = False
                    myRow("haswot") = True
                    myRow("forcesingleot") = True
                End If
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "PayPeriodID", frmIDX)
                myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                frmIDX = myRow.Row("PayPeriodID")

                Me.myView.MainGrid.SaveChanges(, "PayPeriodID = " & frmIDX)

                frmMode = EnumfrmMode.acEditM
                myContext.Provider.dbConn.CommitTransaction(PayperiodDescrip, frmIDX)
                VSave = True
            Catch e As Exception
                myContext.Provider.dbConn.RollBackTransaction(PayperiodDescrip, e.Message)
                Me.AddException("", e)
            End Try
        End If

        Return VSave
    End Function

    Public Overrides Function GenerateIDOutput(dataKey As String, ID As Integer) As clsProcOutput
        Dim oRet As New clsProcOutput
        Select Case dataKey.Trim.ToLower
            Case "finalize"
                oRet = Me.FinalizePPField(ID, "isfinal", "saldirtyon", "Payperiod already finalized")
        End Select
        Return oRet
    End Function

    Protected Friend Function FinalizePPField(PayPeriodID As Integer, FinalFieldName As String, DirtyFieldName As String, ErrorMessage As String) As clsProcOutput
        Dim oRet As New clsProcOutput, sql As String
        If String.IsNullOrEmpty(DirtyFieldName) Then
            sql = String.Format("select payperiodid,{0} from payperiod where payperiodid={1}", FinalFieldName, PayPeriodID)
        Else
            sql = String.Format("select payperiodid,{0},{1} from payperiod where payperiodid={2}", FinalFieldName, DirtyFieldName, PayPeriodID)
        End If
        Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
        If dt.Rows.Count > 0 Then
            If myUtils.cBoolTN(dt.Rows(0)(FinalFieldName)) Then
                oRet.AddError(ErrorMessage)
            ElseIf (Not String.IsNullOrEmpty(DirtyFieldName)) AndAlso (Not myUtils.NullNot(dt.Rows(0)(DirtyFieldName))) Then
                oRet.AddError("Payperiod calculation dirty .. Pl recalculate")
            Else
                dt.Rows(0)(FinalFieldName) = True
                myContext.Provider.objSQLHelper.SaveResults(dt, sql)
            End If
        End If
        Return oRet
    End Function

    Public Overrides Function DeleteEntity(EntityKey As String, ID As Integer, AcceptWarning As Boolean) As clsProcOutput
        Dim oRet As New clsProcOutput
        Try
            If AcceptWarning Then
                Select Case EntityKey.Trim.ToLower
                    Case "payperiod"
                        Dim sql As String = "Select * from PayPeriod Where PayPeriodID =" & ID
                        Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)

                        If dt.Rows.Count > 0 Then
                            Dim sql_atten As String = "select * from Attendance where PayPeriodID=" & ID
                            Dim dtAtten As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql_atten).Tables(0)

                            If dtAtten.Rows.Count > 0 Then
                                Dim sql1 As String = "delete from Attendance where PayPeriodID =" & ID
                                myContext.Provider.objSQLHelper.ExecuteNonQuery(CommandType.Text, sql1)
                            End If

                            Dim sql2 As String = "delete from PayPeriod where PayPeriodID =" & ID
                            myContext.Provider.objSQLHelper.ExecuteNonQuery(CommandType.Text, sql2)
                        End If

                End Select
            ElseIf oRet.WarningCount = 0 Then
                oRet.AddWarning("Are you sure ?")
            End If
        Catch ex As Exception
            oRet.AddException(ex)
        End Try
        Return oRet
    End Function

End Class