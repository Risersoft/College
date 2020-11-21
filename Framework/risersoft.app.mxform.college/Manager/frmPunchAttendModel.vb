Imports risersoft.shared
Imports risersoft.app.mxent
Imports System.Runtime.Serialization

<DataContract>
Public Class frmPunchAttendModel
    Inherits clsFormDataModel
    Dim sql As String
    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("PunchData")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
        sql = "select shiftid,shift from shift"
        Me.AddLookupField("shiftid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "shift").TableName)

        sql = "select attendtagid,attendtag from attendtagmaster where (TagType = 1 or TagType = 2)"
        Me.AddLookupField("attendidfh", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql), "att").TableName)

        Me.AddLookupField("attendidsh", "att")
        Me.AddLookupField("attendidfhs", "att")
        Me.AddLookupField("attendidshs", "att")
    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim rPP As DataRow
        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acEditM Then
            sql = "select * from Attendance where AttendId = " & prepIDX
            Me.InitData(sql, "", oView, prepMode, prepIDX, strXML)

            Dim oMasterData As New clsMasterDataHRP(myContext)
            rPP = oMasterData.rPayPeriodID(myUtils.cValTN(myRow("PayPeriodId")))
            If myUtils.cBoolTN(rPP("isfinal")) Then Me.AddError("Dated", "This PayPeriod has been Finalized")

            sql = "select punchid, PunchIndex, PunchDate, PunchTime, Geopoint, Location, DispName as Campus, Distance, DeviceId from PunchData
                   left join campus on PunchData.campusid = campus.CampusID where attendid = " & frmIDX & " order by Punchindex"
            myView.MainGrid.MainConf("FORMATXML") = "<COL KEY=""Distance"" CAPTION=""Distance(meters)""/>"
            myView.MainGrid.QuickConf(sql, True, "0.5-1-1-2-2-2-1-1", True, "Punches")

            Dim dic As New clsCollecString(Of String)
            dic.Add("Stu", "Select * from clglistStudentView where StudentID =" & myUtils.cStrTN(myRow("StudentID")))
            dic.Add("Punch", "Select * from punchdata where 0=1")
            Me.AddDataSet("StuList", dic)

            Me.FormPrepared = (Me.ErrorList.Count = 0)
            If Me.ErrorList.Count = 0 Then Me.FormPrepared = True
        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()

        If myUtils.NullNot(myRow("Dated")) Then Me.AddError("Dated", "Enter the date")
        If Me.SelectedRow("attendidfh") Is Nothing Then Me.AddError("attendidfh", "Enter Attendance")
        If Me.SelectedRow("attendidsh") Is Nothing Then Me.AddError("attendidsh", "Enter Attendance")
        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        Dim objAttend As New clsProcessPunchBase(myContext)
        VSave = False
        If Me.Validate Then
            Dim ds As DataSet = DatasetCollection("StuList")
            Dim PunchDescrip As String = " Code: " & myUtils.cStrTN(ds.Tables("Stu").Rows(0)("SerialNo")) & ", Name: " & myUtils.cStrTN(ds.Tables("Stu").Rows(0)("FullName")) & ", Dt: " & Format(myRow("Dated"), "dd-MMM-yyyy")
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "attendid", frmIDX)

                objAttend.SetAttendanceStats(myRow.Row)
                objAttend.ProcessManual(myRow.Row, ds.Tables("Stu").Rows(0), ds.Tables("punch"))
                myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)

                frmMode = EnumfrmMode.acEditM
                myContext.Provider.dbConn.CommitTransaction(PunchDescrip, frmIDX)
                VSave = True
            Catch e As Exception
                myContext.Provider.dbConn.RollBackTransaction(PunchDescrip, e.Message)
                Me.AddException("", e)
            End Try
        End If

        Return VSave
    End Function

    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim oRet As New clsProcOutput
        Select Case dataKey.Trim.ToLower
            Case "punch"
                Dim dated As DateTime = myContext.SQL.ParamValue("@dated", Params)
                Dim StudentID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@StudentID", Params))
                Dim oProc As New CLSProcessPunch(myContext)
                oRet = oProc.processPunchEmp(dated, StudentID)
        End Select
        Return oRet
    End Function
End Class