
@imports risersoft.shared.cloud.common
@imports risersoft.app.mxform.hrm
@imports Newtonsoft.Json
@imports risersoft.shared.web.Extensions
@ModelType frmAttendTagMasterModel
@Code
    ViewData("Title") = "Attend TagMaster"
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
                <div class="col-md-8"><label class="control-label lbln">Leave Description</label></div>
            </div>
            <div Class="row" style="margin-top:40px;">
                <div Class="col-md-1"></div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Attend Tag</Label>
                    <input type="text" ng-model="AdvanceInfo.AttendTag" style="max-width: 340px;" class="form-control" />
                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Tag Type</Label>
                    <select ng-model="AdvanceInfo.TagTypeSelected" ng-options="itemo.descriptot for itemo in dsCombo.TagType track by itemo.codeword" Class="form-control"></select>
                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Full Tag</Label>
                    <input type="text" ng-model="AdvanceInfo.FullTag" style="max-width: 340px;" class="form-control" />
                </div>

            </div>
            <div Class="row">
                <div Class="col-md-1"></div>

                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Accure Type</Label>
                    <select ng-model="AdvanceInfo.AccrueTypeSelected" ng-options="itemo.descriptot for itemo in dsCombo.AccrueType track by itemo.codeword" Class="form-control"></select>
                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">MaxAccure</Label>
                    <input type="text" ng-model="AdvanceInfo.MaxAccrue" style="max-width: 340px;" class="form-control" />
                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Leave Period Type</Label>
                    <select ng-model="AdvanceInfo.LvePeriodTypeSelected" ng-options="itemo.descriptot for itemo in dsCombo.LvePeriodType track by itemo.codeword" Class="form-control"></select>
                </div>

            </div>
            <div Class="row">
                <div Class="col-md-1"></div>

                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Leave Period</Label>
                    <input type="text" ng-model="AdvanceInfo.LvePeriodNum" style="max-width: 340px;" class="form-control" />
                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Leave Due</Label>
                    <input type="text" ng-model="AdvanceInfo.LveDue" style="max-width: 340px;" class="form-control" />
                </div>






                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Count Only Work</Label>

                    <select ng-model="AdvanceInfo.CountOnlyWorkSelected" ng-options="itemt.DisplayText for itemt in ValueLists.CountOnlyWork.ValueListItems track by itemt.DataValue" Class="form-control"></select>
                </div>

            </div>

            <div Class="row">
                <div Class="col-md-1"></div>

                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Carry Forward Limit</Label>
                    <input type="text" ng-model="AdvanceInfo.CarryForwardLimit" style="max-width: 340px;" class="form-control" />
                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Allow Encash LM</Label>
                    <select ng-model="AdvanceInfo.AllowEncashLMSelected" ng-options="itemt.DisplayText for itemt in ValueLists.AllowEncash.ValueListItems track by itemt.DataValue" Class="form-control"></select>
                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Allow Encash FF</Label>
                    <select ng-model="AdvanceInfo.AllowEncashFFSelected" ng-options="itemt.DisplayText for itemt in ValueLists.AllowEncash.ValueListItems track by itemt.DataValue" Class="form-control"></select>
                </div>

            </div>
            <div Class="row">
                <div Class="col-md-1"></div>

                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Leave Group</Label>
                    <input type="text" ng-model="AdvanceInfo.LeaveGroup" style="max-width: 340px;" class="form-control" />
                </div>


            </div>

            @Html.Partial("_SavePanel")
            <div class="row"><hr /></div>





        </div>



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
                $scope.AdvanceInfo = $scope.model.dsForm.DT[0];

                $scope.dsCombo = $scope.model.dsCombo;

                $scope.ValueLists = $scope.model.ValueLists;

               @Html.RenderLookup("AdvanceInfo", Model, Model.dsForm.Tables(0));



                $scope.AdvanceInfo.TagTypeSelected = $.grep($scope.dsCombo.TagType, function (item, index) { return item.codeword == $scope.AdvanceInfo.TagType })[0];

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

