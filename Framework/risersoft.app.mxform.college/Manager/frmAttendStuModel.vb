Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization

<DataContract>
Public Class frmAttendStuModel
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
        Dim rPayP As DataRow, objPayPeriod As New clsPayPeriodStu(myContext)
        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acEditM Then

            Dim Sql As String = "select * from clglistStudentView where StudentID = " & prepIDX
            Me.InitData(sql, "PayPeriodId", oView, prepMode, prepIDX, strXML)
            If Not (myUtils.NullNot(Me.vBag("PayPeriodID"))) AndAlso prepIDX > 0 Then
                rPayP = myCollegeFuncs.rPayPeriodID(myContext, myUtils.cValTN(Me.vBag("PayPeriodID")))
                If Not IsNothing(rPayP) Then
                    objPayPeriod.CalculateAbsentDays(myUtils.cValTN(rPayP("PayPeriodID")), prepIDX)

                    Sql = "Select attendid,TotWorkHours, numpunch,latepenalty,Present, Absent, Leave, ExtraDay,LateinMin,earlyoutmin, IsHoliday, payperiodid,attendidsh, StudentID, InAbsentPeriod, Dated, Shiftid, attendidfh, InTime, OutTime, Comment, IsManual from attendance where  payperiodid = " & myUtils.cValTN(rPayP("payperiodid")) & " AND StudentID = " & myUtils.cValTN(prepIDX) & " order by dated"
                    myView.MainGrid.QuickConf(Sql, True, "1.5-1.5-1-1-1-1-1", True, "Attendance")
                    Dim str As String = "<BAND INDEX=""0"" TABLE=""Attendance"" IDFIELD=""Attendid"" ><COL KEY=""Date"" FIELD=""DATED"" NOEDIT=""TRUE""/><COL KEY=""shiftid"" LOOKUPSQL=""select shiftid,shift from shift"" CAPTION=""Shift""/><COL KEY=""attendidfh"" CAPTION=""Status"" LOOKUPSQL=""select attendtagid,attendtag from attendtagmaster order by tagtype,attendtag""/><COL KEY=""attendidsh"" CAPTION=""II Half"" LOOKUPSQL=""select attendtagid,attendtag from attendtagmaster  order by tagtype,attendtag""/><COL KEY=""StudentID,Comment,payperiodid,ismanual,Present, Absent, Leave, ExtraDay, IsHoliday,InAbsentPeriod,totworkhours,numpunch,latepenalty,LateinMin,earlyoutmin""/><COL KEY=""Intime,outtime"" STYLE=""TIME""/></BAND> "
                    myView.MainGrid.PrepEdit(str, EnumEditType.acCommandAndEdit)

                    Me.FormPrepared = True
                End If
            End If
        End If

        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        Dim objProc As clsProcOutput
        VSave = False
        If Me.Validate Then
            objProc = myCollegeFuncs.TrySaveAttendance(myContext, Me.vBag("PayperiodID"), myRow.Row, myView.MainGrid.myDS.Tables(0))
            If objProc.Success Then
                VSave = True
            Else
                Me.AddError("", objProc.Message)
            End If
        End If
        Return VSave
    End Function

    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim oRet As New clsProcOutput
        Select Case dataKey.Trim.ToLower
            Case "punch"
                Dim StudentID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@StudentID", Params))
                Dim payperiodid As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@PayPeriodId", Params))

                Dim rPP As DataRow = myCollegeFuncs.rPayPeriodID(myContext, payperiodid)
                Dim Dated As DateTime = rPP("SDate")
                Dim strFilter As String = "StudentID=" & StudentID
                Dim oProc As New CLSProcessPunch(myContext)
                While Dated <= rPP("EDate")
                    oRet = oRet + oProc.processPunch(Dated, strFilter)
                    Dated = Dated.AddDays(1)
                End While

        End Select
        Return oRet
    End Function
End Class