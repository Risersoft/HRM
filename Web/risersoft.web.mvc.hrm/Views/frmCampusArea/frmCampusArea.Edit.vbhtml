@imports Infragistics.Web.Mvc
@imports System.Data
@imports risersoft.shared
@imports risersoft.shared.cloud
@imports risersoft.shared.web
@imports risersoft.shared.web.Extensions
@imports risersoft.app.mxform.eto
@imports risersoft.shared.portable.models.config
@imports risersoft.shared.agent

@ModelType CampusInfo
@Code
    Dim ctx = CType(ViewContext.Controller, IHostedController).myWebController
    ViewData("Title") = ctx.Vars("appname") & " - Edit Campus"
    Layout = "~/Views/Shared/_LayoutArea.vbhtml"
End Code
<div class="container" id="page-container-wide">
    <div class="header clearfix">
        <nav>
            <ul class="nav nav-pills pull-right">
                <li role="presentation"><a href="/">Home</a></li>
                <li role="presentation"
                    @If (Not ViewBag.isEdit) Then @<Text> Class="active" </text> End If><a href="/addCampus">Add campus</a></li>
            </ul>
        </nav>
        <h3> Edit Campus </h3>
    </div>
    <div id="page">
        <div id="sidebar">
            @Using (Html.BeginForm("Edit", "frmCampusArea", FormMethod.Post, New With {.id = "campusForm"}))
                @<div class="form-horizontal">
                    <Table Class="details-table">
                        <tr> <td> Name</td> <td> @Html.TextBoxFor(Function(x) x.CampusName, New With {.required = True}) </td> </tr>
                        <tr> <td> Starting address</td> <td> @Html.TextBoxFor(Function(x) x.StartingAddress) </td> </tr>
                    </Table>
                    <input type="hidden" name="areas" id="areas" />
                    <input type="submit" Class="btn btn-primary" value="Save campus">
                    <a href="@Url.Action("Index", "App")" Class="btn btn-default">Return To list</a>
                    @If (ViewBag.isEdit) Then
                        @<text><br><br><a href="@Url.Action("Clear")/@Model.CampusId" onclick="return confirm('Do you really want to clear the campus?');">Clear campus</a></text>
                    End If
                    @If (ViewBag.isEdit) Then
                        @<Div><hr />Test function IsPointInCampus <br><br></Div>
                    End If
                    <button class="btn btn-default" type="button" id="testIsPointInCampus">Choose map point</button>
                    <hr> <button class="btn btn-default" type="button" id="loadEmployees">Load employees</button>
                </div>

            End Using
        </div>
        <div id="map"></div>

    </div>
</div>

@section scripts
    <script type="text/javascript" src="@Url.Content("/Scripts/App/CampusMap.js")"></script>
    <script type="text/javascript" src="@Url.Content("/Scripts/App/CampusApp.js")"></script>
    <!--<script type="text/javascript" src="@Url.Content("/Scripts/App/CampusAppMin.js")"></script>-->
    <script type="text/javascript">
        var campusName = '@Model.CampusName';
        @If (String.IsNullOrEmpty(ViewBag.AreasJson)) Then
            @<text>var areasJSON ;</text>
        Else
            @<text>var areasJSON = @Html.Raw(ViewBag.areasJSON);</text>
        End If

    </script>
end section

