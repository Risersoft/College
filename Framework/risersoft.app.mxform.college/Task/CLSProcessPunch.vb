Imports risersoft.app.mxent
Imports risersoft.app.mxform.college
Imports risersoft.shared
Public Class CLSProcessPunch
    Inherits clsProcessPunchBase

    Dim dtPunch As DataTable, objOutput As clsPunchOutput, WeekLateSum As Decimal
    Public Overrides Property IDField As String = "StudentID"

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
    End Sub
    Public Function processPunchEmp(ByVal dated As DateTime, ByVal StudentID As Integer) As clsProcOutput
        Return Me.processPunch(dated, "StudentID = " & StudentID)
    End Function
    Public Function processPunchDay(ByVal dated As DateTime) As clsProcOutput
        Return Me.processPunch(dated, " AdmissionDate< ='" & Format(dated, "yyyy-MMM-dd") & "' and (leavedate is null or leavedate>='" & Format(dated, "yyyy-MMM-dd") & "')")
    End Function

    Public Overrides Function processPunch(ByVal dated As DateTime, strFilter As String) As clsProcOutput
        Dim oRet As New clsProcOutput

        Try
            Dim sql As String, rRate As DataRow = Nothing

            Dim dtShifts = Me.ShiftsTable(dated)
            Dim str1 As String = myUtils.CombineWhere(False, strFilter, "isnull(PunchEnabled,0)=1 and AdmissionDate is not Null")

            sql = "Select StudentID, ShiftId, CampusId, CompanyID from clglistStudentView where " & str1
            Dim dtStu = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)

            Dim str2 As String = "StudentID in (select StudentID from Student where " & str1 & ")"

            Me.LoadAttendanceData(dated, str2)

            For Each rStu As DataRow In dtStu.Select
                'Dim rPP As DataRow = oMasterData.rPayPeriod(rStu("CompanyID"), dated)
                'If (Not rPP Is Nothing) AndAlso myUtils.NullNot(rPP("SalCalcOn")) Then
                'rRate = Me.oMasterData.rRateMaster(myContext.CommonData.GetCompanyIDFromCampus(rStu("CampusId")), dated)

                rRate = myCollegeFuncs.rRateMaster(myContext, myUtils.cValTN(rStu("CompanyID")), dated)
                Dim rAttend As DataRow = Me.AttendanceRow(rStu, dated, False)
                Dim rAttend2 As DataRow = Me.AttendanceRowExisting(dtAttendance, rStu("StudentID"), dated.AddDays(1))
                If (Not rAttend Is Nothing) Then
                    If myUtils.cBoolTN(rAttend("IsManual")) Then
                        'manual row: do nothing
                    Else
                        Me.InitAttendanceRow(rAttend)
                        Dim rShift As DataRow = Me.ShiftRow(dtShifts, rAttend("ShiftId"))
                        Dim rShift2 As DataRow = Me.ShiftRow(dtShifts, If(rAttend2 Is Nothing, rStu("ShiftId"), rAttend2("ShiftId")))

                        dtPunch = Me.PunchTableFromDateShift(rStu, rRate, rShift, rShift2)
                        If dtPunch.Rows.Count > 0 Then
                            Me.PreProcessTable(rAttend, dtPunch)
                            objOutput = Me.ProcessRate(rStu, rAttend, dtPunch, rShift, rRate)
                            SetAttendanceSugg(rAttend, rShift, rRate)

                            myContext.Provider.objSQLHelper.SaveResults(dtPunch, "select * from punchdata")

                        Else
                            Dim AttendID As Integer = Me.AttendIDAbsent
                            rAttend("attendIdFHS") = AttendID
                            rAttend("attendIdSHS") = AttendID
                        End If
                        SetAttendanceStats(rAttend, myUtils.cValTN(rAttend("AttendIDFHS")), myUtils.cValTN(rAttend("AttendIDSHS")))
                    End If
                End If
                'End If
            Next
            If Not IsNothing(dtAttendance) AndAlso dtAttendance.Rows.Count > 0 Then myContext.Provider.objSQLHelper.SaveResults(dtAttendance, "select * from attendance")

        Catch ex As Exception
            oRet.AddException(ex)
        End Try
        Return oRet
    End Function

    Public Function SetAttendanceSugg(rAttend As DataRow, rShift As DataRow, rRate As DataRow)
        Dim Sql As String = "Select Top 1 OnePunchPresent from SystemOptions"
        Dim rSystemOpt As DataRow = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql).Tables(0).Rows(0)

        If (Not rSystemOpt Is Nothing) Then
            If myUtils.cBoolTN(rSystemOpt("OnePunchPresent")) Then
                If (Not IsDBNull(rAttend("intime"))) Then
                    If rAttend("intime") < DateAdd(DateInterval.Minute, 30, rShift("edtime")) Then
                        rAttend("attendIdFHS") = 1
                        rAttend("attendIdSHS") = 1
                    End If
                ElseIf (Not IsDBNull(rAttend("outtime"))) Then
                    If rAttend("outtime") < DateAdd(DateInterval.Minute, 30, rShift("edtime")) Then
                        rAttend("attendIdFHS") = 1
                        rAttend("attendIdSHS") = 1
                    End If
                End If
            Else
                SetLateEarlyMin(rAttend, rShift)
                WeekLateSum = objOutput.PrevLateSumWeekAfterPenalty
                rAttend("LatePenalty") = 0
                WeekLateSum = WeekLateSum + myUtils.cValTN(rAttend("lateinMin"))

                If myUtils.cBoolTN(rAttend("isholiday")) Then
                    If myUtils.cValTN(rAttend("totworkhours")) <= rShift("whours") / 2 Then
                        rAttend("attendIdFHS") = 1
                        rAttend("attendIdSHS") = 2
                        If myUtils.cValTN(rAttend("totworkhours")) < rShift("whours") / 2 Then rAttend("attconflict") = True
                    ElseIf myUtils.cValTN(rAttend("totworkhours")) > rShift("whours") / 2 Then
                        rAttend("attendIdFHS") = 1
                        rAttend("attendIdSHS") = 1
                        If myUtils.cValTN(rAttend("totworkhours")) < rShift("whours") Then rAttend("attconflict") = True
                    End If
                Else
                    'working day
                    If IsDBNull(rAttend("outtime")) Then rAttend("EarlyOutMin") = 0
                    If IsDBNull(rAttend("intime")) Then rAttend("LateInMin") = 0
                    If (Not IsDBNull(rAttend("outtime"))) AndAlso (Not IsDBNull(rAttend("intime"))) Then
                        If myUtils.cValTN(rAttend("totworkhours")) >= rShift("whours") Then
                            rAttend("attendIdFHS") = 1
                            rAttend("attendIdSHS") = 1
                            Me.CheckWeekLateSum(rAttend, myUtils.cValTN(rRate("WeeklyLateAllow")), "FHS")
                        ElseIf myUtils.cValTN(rAttend("totworkhours")) >= rShift("whours") / 2 Then
                            If rAttend("intime") > rShift("botime") Then
                                rAttend("attendIdFHS") = 2
                                rAttend("attendIdSHS") = 1
                                Me.CheckWeekLateSum(rAttend, myUtils.cValTN(rRate("WeeklyLateAllow")), "SHS")
                            ElseIf rAttend("intime") > rShift("sdtime") AndAlso rAttend("intime") < rShift("botime") Then
                                rAttend("attendIdFHS") = 2
                                rAttend("attendIdSHS") = 1
                                rAttend("latepenalty") = 1
                            Else
                                rAttend("attendIdFHS") = 1
                                rAttend("attendIdSHS") = 2
                            End If
                            WeekLateSum = WeekLateSum + myUtils.cValTN(rAttend("earlyoutmin"))

                            If rAttend("outtime") < rShift("edtime") AndAlso rAttend("outtime") <= rShift("MaxTimeSH") Then
                                rAttend("attendIdSHS") = 2

                            ElseIf rAttend("outtime") < rShift("edtime") AndAlso rAttend("outtime") > rShift("MaxTimeSH") Then
                                Me.CheckWeekLateSum(rAttend, myUtils.cValTN(rRate("WeeklyLateAllow")), "SHS")
                            End If
                            'This else require where InTime and OutTime is not null but working hours < whrs/2
                        Else
                            'Both absent, No LatePenalty and Hence no LateinMin/EarlyOutMin
                            rAttend("LateInMin") = 0
                            rAttend("EarlyOutMin") = 0

                        End If

                        If myUtils.cValTN(rAttend("lateinMin")) = 0 AndAlso myUtils.cValTN(rAttend("earlyoutMin")) = 0 AndAlso myUtils.cValTN(rAttend("totworkhours")) < rShift("whours") AndAlso rAttend("intime") < rShift("MaxTimeFH") AndAlso rAttend("outtime") > rShift("MaxTimeSH") Then
                            rAttend("attconflict") = True
                        End If
                        'This else require where InTime or  OutTime is null. In the case of single punch
                    End If
                End If

            End If
        End If

        If dtPunch.Rows.Count Mod 2 = 1 Then rAttend("attconflict") = True
        Return True
    End Function

    Private Function CheckWeekLateSum(rAttend As DataRow, WeekLateSumAllow As Decimal, HalfString As String) As Integer
        If WeekLateSum > WeekLateSumAllow Then
            rAttend("attendId" & HalfString) = 2
            rAttend("LatePenalty") = rAttend("LatePenalty") + 1
        End If
        Return True
    End Function

    ' New Added Function
    Public Overrides Sub LoadAttendanceData(Dated As DateTime, strFilter As String)
        Dim str1, str2 As String, dic As New clsCollecString(Of String)

        str1 = myUtils.CombineWhere(False, "Dated>='" & Format(Dated.AddDays(-6), "dd-MMM-yyyy") & "'", "Dated<='" & Format(Dated.AddDays(1), "dd-MMM-yyyy") & "'")
        If strFilter.Trim.Length > 0 Then str2 = strFilter Else str2 = " StudentID in (select StudentID from Student where isnull(PunchEnabled,0)=1)"
        dic.Add("att", "select * from Attendance " & myUtils.CombineWhere(True, str1, str2))

        Dim AttendIDCSV As String = Me.AttendIDPresentCSV()
        str1 = myUtils.CombineWhere(False, "Dated<'" & Format(Dated, "dd-MMM-yyyy") & "'", myUtils.CombineWhereOR(False, "attendidfh in (" & AttendIDCSV & ")", "attendidsh in (" & AttendIDCSV & ")"))
        dic.Add("last", "select  StudentID, MAX(Dated) as LastPresentDate from attendance " & myUtils.CombineWhere(True, str1, str2) & " group by StudentID")

        Dim ds As DataSet = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)
        dtAttendance = ds.Tables("att")
        dtLastPresent = ds.Tables("last")
    End Sub

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

    Protected Overrides Function dicSQLStructure(dicWhere As clsCollecString(Of String)) As clsCollecString(Of String)
        Dim dic As New clsCollecString(Of String)
        dic.Add("comp", "select * from Company")
        dic.Add("campus", "select * from campus")
        dic.Add("holiday", "select * from holiday")
        Return dic
    End Function

    Public Overrides Function IsHoliday(ByVal Dated As DateTime, CampusID As Integer) As Boolean
        Dim rMaster As DataRow = myCollegeFuncs.rRateMaster(myContext, myCollegeFuncs.GetInstitutionIDFromCampus(myContext, CampusID), Dated)
        Return Me.IsHoliday(Dated, rMaster, CampusID)
    End Function
End Class