Imports risersoft.shared
Imports risersoft.app.mxent
Imports System.Runtime.Serialization
<DataContract>
Public Class frmAttendDayModel
    Inherits clsFormDataModel
    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("Att")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql, str1, strWhere As String

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acEditM Then
            Me.InitData("", "Dated,PayPeriodID", oView, prepMode, prepIDX, strXML)
            Dim date1 As Date = Me.vBag("dated")

            Me.ModelParams.Add(New clsSQLParam("@Dated", Me.vBag("dated"), GetType(Date), False))
            strWhere = myUtils.CombineWhere(True, "PayPeriodID = " & prepIDX & "", "Dated = '" & Format(date1, "dd-MMM-yyyy") & "'", myCollegeFuncs.WValue(pView, "id2casual,dep,isworker,contractorid"))
            sql = "select attendid, Present, Absent, Leave, ExtraDay, IsHoliday,InAbsentPeriod,LateInMin, payperiodid, ClassID, StudentID,AttendIDsh, Dated,ShiftID, SerialNo, FullName, ClassName,  AttendIDfh, InTime, OutTime, Comment, IsManual   from clglistAttendanceView  " & strWhere & " "
            myView.MainGrid.MainConf("FORMATXML") = "<COL KEY=""Dated"" CAPTION=""Punching Date""/><COL KEY=""SerialNo"" CAPTION=""Serial No""/><COL KEY=""FullName"" CAPTION=""Name""/><COL KEY=""ClassName"" CAPTION=""Class Name""/>"
            myView.MainGrid.QuickConf(sql, True, "1-2-2-1-1-1-4-1", True)
            str1 = "<BAND INDEX=""0"" TABLE=""Attendance"" IDFIELD=""Attendid"" ><COL KEY=""Dated"" FIELD=""DATED""/><COL KEY=""shiftid"" LOOKUPSQL=""select shiftid,shift from shift"" CAPTION=""Shift""/><COL KEY=""attendidfh"" CAPTION=""Status"" LOOKUPSQL=""select attendtagid,attendtag from attendtagmaster""/><COL KEY=""attendidsh"" CAPTION=""II Half"" LOOKUPSQL=""select attendtagid,attendtag from attendtagmaster""/><COL KEY=""StudentID,Comment,payperiodid,IsManual, Present, Absent, Leave, ExtraDay, IsHoliday,InAbsentPeriod""/><COL KEY=""Intime,outtime"" STYLE=""TIME""/></BAND> "
            myView.MainGrid.PrepEdit(str1, EnumEditType.acCommandAndEdit)
            Me.FormPrepared = True
        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        Dim objAttend As New clsAttendanceCalc(myContext)
        VSave = False
        For Each r1 As DataRow In myView.MainGrid.myDS.Tables(0).Select
            r1("attendidsh") = r1("attendidfh")
            objAttend.SetAttendanceStats(r1)
        Next
        If Me.Validate Then
            Dim AttendanceDescrip As String = "Attendance for : " & Me.vBag("Dated")
            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "PayPeriodID", frmIDX)
                Me.myView.MainGrid.SaveChanges()
                myContext.Provider.dbConn.CommitTransaction(AttendanceDescrip, frmIDX)
                VSave = True
            Catch e As Exception
                myContext.Provider.dbConn.RollBackTransaction(AttendanceDescrip, e.Message)
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
                Dim oProc As New CLSProcessPunch(myContext)
                oRet = oProc.processPunchDay(dated)
        End Select
        Return oRet
    End Function
End Class