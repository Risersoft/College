Imports risersoft.app.mxengg
Imports risersoft.app.mxform.college
Imports risersoft.shared
Imports System.Runtime.Serialization

<DataContract>
Public Class frmActivityModel
    Inherits clsFormDataModel
    Dim Sql As String

    Protected Overrides Sub InitViews()
        myView = Me.GetViewModel("Media")
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()

        Sql = myFuncs.CodeWordSQL("Activity", "Nature", "")
        Me.AddLookupField("Nature", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql), "Nature").TableName)

        Sql = "Select finyearid, Descrip from FinYears order by FinYearID"
        Me.AddLookupField("finyearid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql), "FinYear").TableName)

        Dim vlist2 As New clsValueList
        vlist2.Add("Image", "Image")
        vlist2.Add("Video", "Video")
        Me.ValueLists.Add("UploadType", vlist2)
        Me.AddLookupField("UploadType", "UploadType")

    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim str1 As String, dic As New clsCollecString(Of String)

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acAddM Then prepIDX = 0
        Sql = "select * from Activity where ActivityID = " & prepIDX
        Me.InitData(Sql, "Companyid", oView, prepMode, prepIDX, strXML)


        Dim str2 As String = myUtils.CombineWhere(True, myContext.AppModel.strFilterDBAppUser(myContext, Me.fRow, "CompanyID"))

        Sql = "Select deptid, deptname from department " & str2 & " order by deptname"
        Me.AddLookupField("deptid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql), "dept").TableName)

        Sql = "Select Companyid, CompName from Company " & str2 & " Order by CompName"
        Me.AddLookupField("Companyid", myUtils.AddTable(Me.dsCombo, myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, Sql), "Company").TableName)

        Sql = "Select MediaDetailID,ActivityID,UploadType,Url from MediaDetail where ActivityID = " & frmIDX & ""
        myView.MainGrid.MainConf("FORMATXML") = "<COL KEY=""UploadType"" CAPTION=""MediaType""/><COL KEY=""Url"" CAPTION=""File Name""/>"
        myView.MainGrid.QuickConf(Sql, True, "1-1", True)
        str1 = "<BAND INDEX=""0"" TABLE=""MediaDetail"" IDFIELD=""MediaDetailID""><COL KEY=""ActivityID,UploadType,Url""/></BAND>"
        myView.MainGrid.PrepEdit(str1, EnumEditType.acCommandOnly)


        Me.FormPrepared = True
        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        If myUtils.cStrTN(myRow("Name")).Trim.Length = 0 Then Me.AddError("Name", "Please Enter Activity Name")
        If myUtils.cStrTN(myRow("Nature")).Trim.Length = 0 Then Me.AddError("Nature", "Please Select Activity Nature")
        If myUtils.cStrTN(myRow("Dated")).Trim.Length = 0 Then Me.AddError("Dated", "Please Enter Proposed Week/Month")

        Return Me.CanSave
    End Function


    Public Overrides Function VSave() As Boolean
        VSave = False
        If Me.Validate Then
            Dim r1 As DataRow = myContext.CommonData.FinRow(myRow("Dated"))
            If Not myUtils.NullNot(r1) Then
                myRow("FinYearID") = r1("FinYearID")
            End If

            Dim ActivityDescrip As String = myUtils.cStrTN(myRow("Name"))

            myRow("DescriptionHTML") = myFuncs.DecodeNormalizeHTML(myUtils.cStrTN(myRow("DescriptionHTML")))
            myRow("DescriptionText") = BucketUtility.TryBase64Decode(myUtils.cStrTN(myRow("DescriptionText")))

            myRow("PurposeHTML") = myFuncs.DecodeNormalizeHTML(myUtils.cStrTN(myRow("PurposeHTML")))
            myRow("PurposeText") = BucketUtility.TryBase64Decode(myUtils.cStrTN(myRow("PurposeText")))

            Try
                myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "ActivityID", frmIDX)
                myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, Me.sqlForm)
                frmIDX = myRow("ActivityID")

                frmMode = EnumfrmMode.acEditM
                myView.MainGrid.SaveChanges(, "ActivityID=" & frmIDX)
                myContext.Provider.dbConn.CommitTransaction(ActivityDescrip, frmIDX)
                VSave = True
            Catch ex As Exception
                myContext.Provider.dbConn.RollBackTransaction(ActivityDescrip, ex.Message)
                Me.AddError("", ex.Message)
            End Try
        End If
        Return VSave
    End Function

    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim oRet As New clsProcOutput
        oRet = myCollegeFuncs.GenerateCommonOutput(myContext, dataKey, Params, "activityId")
        Return oRet
    End Function

    Public Overrides Function DeleteEntity(EntityKey As String, ID As Integer, AcceptWarning As Boolean) As clsProcOutput
        Dim oRet As New clsProcOutput
        Try
            If AcceptWarning Then
                Select Case EntityKey.Trim.ToLower
                    Case "activity"
                        Dim sql As String = "Select * from Activity Where ActivityID =" & ID
                        Dim dt As DataTable = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)

                        If dt.Rows.Count > 0 Then
                            Dim sql1 As String = "delete from Activity where ActivityID =" & ID
                            myContext.Provider.objSQLHelper.ExecuteNonQuery(CommandType.Text, sql1)
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
