Imports risersoft.app.mxent
Imports risersoft.app.mxform.college
Imports risersoft.shared

Public Class clsPayPeriodStu
    Inherits clsPayPeriodBase

    Public Overrides Property IDField As String = "StudentID"
    Public Overrides Property TableName As String = "Student"

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
    End Sub

    Public Overrides Sub CalculateAbsentDays(PayPeriodID As Integer, StudentID As Integer)
        'to be called from attendance form
        Dim ds As DataSet = Me.LoadAttendanceData(PayPeriodID, StudentID)
        Dim rPP As DataRow = Me.rPayPeriod(PayPeriodID, ds.Tables("pp"))
        Dim rEmp As DataRow = Me.rStudent(StudentID, ds.Tables("stu"))
        Me.CalculateAbsentDays(rPP, rEmp, rEmp("campusid"), ds)
        myContext.Provider.objSQLHelper.SaveResults(ds.Tables("att"), "select * from attendance where 0=1")
    End Sub

    Protected Overrides Sub CalculateAbsentDays(rPP As DataRow, rEmp As DataRow, CampusID As Integer, dsp As DataSet)
        Dim dated2 As DateTime = rPP("eDate")
        If Not myUtils.NullNot(rEmp("LeaveDate")) AndAlso rEmp("leavedate") < rPP("eDate") Then dated2 = rEmp("LeaveDate")
        Dim rRate As DataRow = myCollegeFuncs.rRateMasterID(myContext, myUtils.cValTN(rPP("RateMasterId")))

        'Delete extra attendance rows if employee has joined at the end of payperiod
        Dim dated As DateTime = rPP("sDate")
        While dated < rEmp("AdmissionDate")
            Dim rAtt As DataRow = Me.AttendanceRowExisting(dsp.Tables("att"), rEmp("StudentID"), dated)
            If Not (rAtt Is Nothing) Then
                rAtt.Delete()
            End If
            dated = DateAdd(DateInterval.Day, +1, dated)
            If dated > dated2 Then Exit While
        End While



        While dated <= dated2
            Dim ishol As Boolean = Me.IsHoliday(dated, CampusID)
            Dim rAtt As DataRow = Me.AttendanceRowExisting(dsp.Tables("att"), rEmp("StudentID"), dated)
            Dim inabsentperiod As Boolean = False

            If (rAtt Is Nothing) Then
                rAtt = Me.AttendanceRowAdd(dsp.Tables("att"), rEmp("StudentID"), rEmp("shiftid"), CampusID, dated)
            Else
                rAtt("isHoliday") = ishol
                If ishol Then inabsentperiod = Me.InAbsentPeriod(dated, rEmp("StudentID"), CampusID, rAtt, rRate, dsp)
                rAtt("inAbsentPeriod") = inabsentperiod
                Me.SetAttendanceStats(rAtt)
            End If


            If (Not rAtt Is Nothing) Then
                rAtt("inAbsentPeriod") = inabsentperiod
                Me.SetAttendanceStats(rAtt)
            End If
            dated = DateAdd(DateInterval.Day, +1, dated)
        End While



        'Delete extra attendance rows if employee has left in middle of payperiod
        dated = DateAdd(DateInterval.Day, +1, dated2)
        While dated <= rPP("eDate")
            Dim rAtt As DataRow = Me.AttendanceRowExisting(dsp.Tables("att"), rEmp("StudentID"), dated)
            If Not (rAtt Is Nothing) Then
                rAtt.Delete()
            End If
            dated = DateAdd(DateInterval.Day, +1, dated)
        End While
    End Sub

    Public Overrides Function InAbsentPeriod(Dated As DateTime, EmployeeID As Integer, CampusID As Integer, rAtt As DataRow, rRate As DataRow, dsp As DataSet) As Boolean
        Return False
    End Function


    Protected Overrides Function dicWherePayslipID(PayPeriodID As Integer, StudentID As Integer) As clsCollecString(Of String)
        Dim dic As New clsCollecString(Of String)

        Dim rPP As DataRow = myCollegeFuncs.rPayPeriodID(myContext, PayPeriodID)
        Dim str1 As String = dic.Add("PayPeriodId", "PayPeriodId=" & PayPeriodID)
        Dim str2 As String = dic.Add("StudentID", "StudentID=" & StudentID)
        Return dic
    End Function

    Protected Overrides Function dicSQLAttendance(dicWhere As clsCollecString(Of String)) As clsCollecString(Of String)
        Dim dic As New clsCollecString(Of String)
        Dim AttendIDCSV As String = Me.AttendIDPresentCSV()
        dic.Add("pp", "select * from PayPeriod where " & dicWhere("PayPeriodId"))
        dic.Add("stu", "select * from clglistStudentView where " & dicWhere("StudentID"))
        dic.Add("att", "select * from attendance where " & dicWhere("payperiodid"))
        Return dic
    End Function

    Public Function rStudent(StudentID As Integer, dtStu As DataTable) As DataRow
        Dim rr() As DataRow = dtStu.Select("StudentID=" & StudentID)
        If rr.Length > 0 Then Return rr(0) Else Return Nothing
    End Function

    Public Overrides Function IsHoliday(ByVal Dated As DateTime, CampusID As Integer) As Boolean
        Dim rMaster As DataRow = myCollegeFuncs.rRateMaster(myContext, myCollegeFuncs.GetInstitutionIDFromCampus(myContext, CampusID), Dated)
        Return Me.IsHoliday(Dated, rMaster, CampusID)
    End Function

    Protected Overrides Function dicSQLStructure(dicWhere As clsCollecString(Of String)) As clsCollecString(Of String)
        Dim dic As New clsCollecString(Of String)
        dic.Add("holiday", "select * from holiday")
        Return dic
    End Function

    Public Overrides Function AttendanceRowExisting(dtAttend As DataTable, StudentID As Integer, Dated As DateTime) As DataRow
        Dim rr() As DataRow = dtAttend.Select("StudentID=" & StudentID & " and dated ='" & Format(Dated, "dd-MMM-yyyy") & "'")
        If rr.Length > 0 Then Return rr(0) Else Return Nothing
    End Function

    Public Overrides Function AttendanceRowAdd(dtAttend As DataTable, StudentID As Integer, ShiftID As Integer, CampusID As Integer, Dated As DateTime) As DataRow
        Dim nr, rRate, rPP As DataRow

        Dim CompanyID As Integer = myUtils.cValTN(myCollegeFuncs.GetInstitutionIDFromCampus(myContext, CampusID))
        rPP = myCollegeFuncs.PPRow(myContext, CompanyID, Dated)
        rRate = myCollegeFuncs.rRateMaster(myContext, CompanyID, Dated)
        If Not rPP Is Nothing Then
            nr = myContext.Tables.AddNewRow(dtAttend)
            nr("dated") = Dated
            nr("studentid") = StudentID
            nr("payperiodid") = rPP("payperiodid")
            nr("shiftid") = ShiftID
            nr("ismanual") = False

            nr("isholiday") = Me.IsHoliday(Dated, rRate, CampusID)

            Me.InitAttendanceRow(nr)
            myContext.Provider.objSQLHelper.SaveResults(dtAttend, "select * from attendance where attendid=0")
        End If
        Return nr
    End Function
End Class