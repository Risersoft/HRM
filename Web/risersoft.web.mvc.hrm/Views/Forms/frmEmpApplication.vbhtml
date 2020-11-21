
@imports risersoft.shared.cloud.common
@imports risersoft.app.mxform.hrm
@imports Newtonsoft.Json
@imports risersoft.shared.web.Extensions
@ModelType frmEmpApplicationModel
@Code
    ViewData("Title") = "Employee Application"
    Layout = "~/Views/Shared/_FrameworkLayout.vbhtml"

    Dim modelJson = JsonConvert.SerializeObject(Model, Formatting.Indented,
            New JsonSerializerSettings With {.StringEscapeHandling = StringEscapeHandling.EscapeHtml, .NullValueHandling = NullValueHandling.Ignore})


End Code

<div class="container cbackground">
    <form action="" method="post" name="userform" ng-controller="CompanyController">
        @Html.AntiForgeryToken()



        <input type="hidden" id="model_json" value='@Html.Raw(modelJson)' />
        <div Class="form-horizontal">
            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Employee Application</label></div>
            </div>


            <div class="row">
                <div class="col-md-1"></div>

                <div class="col-md-3">
                    <Label Class="control-label labeltext">Emp Code : </Label>   {{ContextRow.EmpCode}}

                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Name : </Label>   {{ContextRow.FullName}}



                </div>

            </div>

            <div class="row">
                <div class="col-md-1"></div>

                <div class="col-md-3">
                    <Label Class="control-label labeltext">Application Type</Label>
                    <select ng-model="PartyInfo.ApplicationTypeSelected" ng-options="itemn.descriptot for itemn in dsCombo.ApplicationType track by itemn.codeword" Class="form-control"></select>

                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Application Date</Label>
                    <input type="text" ng-model="PartyInfo.ApplicationDate" Class="form-control my-datepicker" />


                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Approve Date</Label>
                    <input type="text" ng-model="PartyInfo.ApproveDate" Class="form-control my-datepicker" />


                </div>

            </div>



            <div class="row">
                <div class="col-md-1"></div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Dated</Label>
                    <input type="text" ng-model="PartyInfo.Dated" Class="form-control my-datepicker" />


                </div>
                <div class="col-md-3">
                    <Label Class="control-label labeltext">Reason</Label>
                    <input type="text" ng-model="PartyInfo.Reason" Class="form-control" />
                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext">No. Of Leave Require</Label>
                    <input type="text" ng-model="PartyInfo.CardNum" Class="form-control" />


                </div>

            </div>






        </div>
        <div class="row"><hr /></div>







        @Html.Partial("_SavePanel")

    </form>


</div>


@Section botscripts
    <script type="text/javascript">

        $(document).ready(function () {
            setInterval(function () {
                $(".my-datepicker").removeClass("my-datepicker").each(function () {
                    $(this).datepicker({ dateFormat: 'yy-mm-dd' });
                });
            }, 10);
        });
        rsApp.controller('CompanyController', function ($scope,$http) {
            $scope.model = JSON.parse($("#model_json").val());
            $scope.data = "This is data come from json";



            var loadmodel = function (result) {
                $scope.model = result;
                $scope.PartyInfo = $scope.model.dsForm.DT[0];
                $scope.Party = $scope.model.dsForm.party;
                $scope.dsCombo = $scope.model.dsCombo;
                $scope.ContextRow = $scope.model.pViewState.ContextRow.valuebag;
                $scope.ValueLists = $scope.model.ValueLists;

               @Html.RenderLookup("PartyInfo", Model, Model.dsForm.Tables(0));









            }



            loadmodel($scope.model);
            $scope.calculateAll = function () {

            };
        $scope.calculateAll();
        $scope.cleanupmodel = function (datamodel) {
            //empty function
        };
        $scope.calculatemodel = function () {
            $scope.calculateAll();
        };
        $scope.visdel = false; $scope.visdelete = false;
        @Html.RenderFile("~/scripts/rsforms.js")
            });

    </script>
End Section

