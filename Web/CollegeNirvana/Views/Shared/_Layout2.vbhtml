@imports risersoft.shared.web.Extensions
@imports risersoft.shared.web
@imports risersoft.shared.web.common
@imports risersoft.shared.portable
@code
    Dim _user As RSUser = OwinHelper.GetRSUser(Me.User)
    Dim ctx = CType(ViewContext.Controller, IWebController)
    Dim baseUrl As String = Request.Url.Scheme & "://" & Request.Url.Authority & Request.ApplicationPath.TrimEnd("/")
    Dim logo As String = baseUrl & "/account/logo"

End Code
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title</title>
    <script>
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','https://www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-30484106-2', 'auto');
  ga('send', 'pageview');

    </script>
</head>
<body ng-app="rsApp">
   
    <div Class="container" style="padding-left:6px;">
        @If Not _user Is Nothing Then

            Else

            @<div style="padding:10px;">
                <a Class="btn btn-primary btn-sm pull-right blue-btn margin-left5" href="/account/SignIn">Sign in</a>
            </div>
        End If


    </div>


   
    <div class="logo-border">
        <div class="container">
            <div class="logo-header">
                <div class="pull-left mobo-widthtab"><a href="/index"><img src="@logo"></a></div>
                <div class="pull-right tagline mobo-widthtab">
                    <h2>Powering B2B SaaS</h2>
                </div>
            </div>
        </div>
    </div>
    <div Class="container body-content">
        @RenderBody()

        <div id="dialog-confirm" title="Confirm">
            <p><span class="glyphicon glyphicon-question-sign" style="float:left; margin:12px 12px 20px 0;"></span><span id="confirmationMessage"> confirmationMessage</span></p>
        </div>
    </div>
    @Html.Partial("~/Views/Shared/_footer.vbhtml")



    <!-- CSS FILES -->
    <link href="/content/bootstrap.css" rel="stylesheet" />
    <link href="/css/style.css" rel="stylesheet">
    @Styles.Render("~/Content/css")
    <link href="/css/font-awesome.css" rel="stylesheet">
    <link href="/css/slider.css" rel="stylesheet" type="text/css">
    <link href="/css/slider-main.css" rel="stylesheet" type="text/css">
    <link href="/css/slider-responsive.css" rel="stylesheet" type="text/css">
    <link href="/css/slider-style.css" rel="stylesheet" type="text/css" />
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    <script src="~/Scripts/moment.js"></script>
    <link href="~/Scripts/jquery-ui/jquery-ui.css" rel="stylesheet" />
    @Scripts.Render("~/bundles/jqueryui")


    <link href="~/Content/font-awesome.css" rel="stylesheet" />


    @*<script type="text/javascript">
            var loggedInUser = @Html.Raw(userJson);
        </script>*@
    @Scripts.Render("~/bundles/angular")




    <link href="~/Scripts/Intl-Tel-Input/css/intlTelInput.css" rel="stylesheet" />
    <script src="~/Scripts/Intl-Tel-Input/js/intlTelInput.js"></script>
    <script src="~/Scripts/Intl-Tel-Input/js/utils.js"></script>


    @RenderSection("scripts", required:=False)
</body>
</html>