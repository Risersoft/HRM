
@imports risersoft.shared.cloud.common
@imports risersoft.app.mxform
@imports Newtonsoft.Json
@imports risersoft.shared.web.Extensions
@ModelType frmMatDepModel
@Code
    ViewData("Title") = "Master HR"
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
                <div class="col-md-8"><label class="control-label lbln">Materail Dept</label></div>
            </div>


            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">
                    <label class="control-label labeltext">Code</label>
                    <input type="text" ng-model="Campus.DepCode" class="form-control" />
                </div>
                <div class="col-md-3">
                    <Label Class="control-label labeltext">Name</Label>
                    <input type="text" ng-model="Campus.DepName" class="form-control" />
                </div>
                <div class="col-md-3">
                    <Label Class="control-label labeltext">Number</Label>
                    <input type="text" ng-model="Campus.UnitNum" class="form-control" />
                </div>
            </div>



            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">
                    <label class="control-label labeltext">HR Dept</label>
                    <select name="grcamp" ng-model="Campus.DepIDSelected" ng-options="itgscamp.DepName for itgscamp in dsCombo.Dep track by itgscamp.DepId" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.grcamp.$invalid]"></select>

                </div>
                <div style="margin-top:32px" class="col-md-3">
                    <Label Class="control-label"></Label>
                    Shop         <input type="checkbox" ng-model="Campus.IsShop" /><br />
                </div>
                <div class="col-md-3">
                    <Label Class="control-label labeltext">Incentive Group</Label>
                    <input type="text" ng-model="Campus.IncGroup" class="form-control" />
                </div>
            </div>




            <div class="row">
                <div class="col-md-1"></div>
                <div style="margin-top: 15px;" class="col-md-3">
                    <Label Class="control-label"> </Label>
                    Has Non-Confirmities       <input type="checkbox" ng-model="Campus.HasNC" /><br />
                    Accepts Work Orders        <input type="checkbox" ng-model="Campus.AcceptsWO" /><br />
                    Accepts Mfg Orders         <input type="checkbox" ng-model="Campus.AcceptsMO" /><br />

                </div>
                <div style="margin-top: 15px;" class="col-md-3">
                    <Label Class="control-label"> </Label>
                    Accepts Documents        <input type="checkbox" ng-model="Campus.AcceptsDoc" /><br />
                    Store                    <input type="checkbox" ng-model="Campus.IsStore" /><br />
                    Gives Requisition        <input type="checkbox" ng-model="Campus.GivesReq" /><br />

                </div>

                <div style="margin-top: 15px;" class="col-md-3">
                    <Label Class="control-label"> </Label>
                    Incentive               <input type="checkbox" ng-model="Campus.HasIncentive" /><br />
                    Has TestLab             <input type="checkbox" ng-model="Campus.HasLab" /><br />
                </div>
            </div>



            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">
                    <label class="control-label labeltext">Lab Name</label>
                    <input type="text" ng-model="Campus.LabName" class="form-control" />
                </div>
                <div class="col-md-3">
                    <Label Class="control-label labeltext">Test Group</Label>
                    <input type="text" ng-model="Campus.TestGroup" class="form-control" />
                </div>
                <div style="margin-top:32px" class="col-md-3">
                    <Label Class="control-label"></Label>
                    Old        <input type="checkbox" ng-model="Campus.OldShop" /><br />
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
               
                $scope.Campus = $scope.model.dsForm.DT[0];
                $scope.dsCombo = $scope.model.dsCombo;



               





               


             
               @Html.RenderLookup("Campus", Model, Model.dsForm.Tables(0));








               
              







               


                
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

