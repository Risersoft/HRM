@imports risersoft.shared.cloud.common
@Code
    ViewData("Title") = "Home Page"
    Dim baseUrl As String = Request.Url.Scheme & "://" & Request.Url.Authority & Request.ApplicationPath.TrimEnd("/")
    Dim banner As String = risersoft.shared.GlobalCore.GetConfigSetting("banner")
    If String.IsNullOrEmpty(banner) Then banner = "/Content/images/HRM-banner.jpg" Else banner = baseUrl & banner

End Code
<div class="row">
    <div class="col-md-8">
        <img src="@banner" style="width:650px;" class="img-responsive banner-img">
    </div>
    <div class="col-md-3 gst-banner-text" style="margin-top:0px;">
        <h1 class="gst-banner-text-title">HRMNirvana</h1>
        <p class="lead gst-banner-text-para">Manage your organization’s human capital management needs from hire to retire.</p>
        <p><a href="/app" class="btn btn-primary btn-lg">Start Now &raquo;</a></p>

        <div class="col-md-12" style="margin-top: 50px;margin-bottom: 10px;">
            <p style="font-weight:bold">Admin</p>
            <a href="https://play.google.com/store/apps/details?id=com.risersoft.HRMNirvana" target="_blank"><img class="play" src="~/Content/images/playstore-button.png" style="width:100px;"></a>&nbsp;
            <a href="#appstore" target="_blank"><img class="app" src="~/Content/images/appstore-button.png" style="width:100px;"></a>
        </div>

        <div class="col-md-12">
            <p style="font-weight:bold">ESS </p>
            <a href="https://play.google.com/store/apps/details?id=com.risersoft.ess" target="_blank"><img class="play" src="~/Content/images/playstore-button.png" style="width:100px;"></a>&nbsp;
            <a href="#appstore" target="_blank"><img class="app" src="~/Content/images/appstore-button.png" style="width:100px;"></a>
        </div>
    </div>
</div>
<div><br /><br /></div>
<div class="row clsimgb">
    <div class="col-md-3 footer-nav footer-text">
        <div class="clsfoot">
            <h2>Employee Records</h2>
            <p>
                Capture numerous pieces of information about the employee through pre-built functions.

            </p>
        </div>
    </div>
    <div class="col-md-3 footer-nav footer-text">
        <div class="clsfoot">
            <h2>Time & Attendance</h2>
            <p>
                Track time and attendance of the employees on campus, in remote offices and field visits.

            </p>
        </div>
    </div>
    <div class="col-md-3 footer-nav footer-text">
        <div class="clsfoot">
            <h2>Payroll</h2>
            <p>Handle payroll processing comprehensively, and yet simplistically.</p>
        </div>
    </div>
    <div class="col-md-3 footer-text">
        <div class="clsfoot">
            <h2>Multi Platform</h2>
            <p>Securely access your cloud hosted data from desktop, web & mobile.</p>
        </div>
    </div>
</div>
</div>