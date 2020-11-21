
@imports risersoft.shared.cloud.common
@imports risersoft.app.mxform.hrm
@imports risersoft.app.mxform
@imports Newtonsoft.Json
@imports risersoft.shared.web.Extensions
@ModelType frmShiftModel
@Code
    ViewData("Title") = "Department"
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
                <div class="col-md-8"><label class="control-label lbln">Shift</label></div>
            </div>


            <div class="row">
                <div class="col-md-1"></div>

                <div class="col-md-3">
                    <Label Class="control-label labeltext">Shift</Label>
                    <input type="text" ng-model="AdvanceInfo.Shift" Class="form-control my-datepicker" />
                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Start Time</Label>
                    <input type="text" ng-model="AdvanceInfo.STime" Class="form-control" />


                </div>




                <div Class="col-md-3">
                    <Label Class="control-label labeltext">End Time</Label>


                    <input type="text" ng-model="AdvanceInfo.ETime" Class="form-control" />
                </div>
            </div>



            <div class="row">
                <div class="col-md-1"></div>






                <div class="col-md-3">
                    <Label Class="control-label labeltext">Lunch Out</Label>
                    <input type="text" ng-model="AdvanceInfo.LunchOut" Class="form-control" />
                </div>




                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Lunch In</Label>

                    <input type="text" ng-model="AdvanceInfo.LunchIn" Class="form-control" />



                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Work Hours</Label>
                    <input type="text" ng-model="AdvanceInfo.WHours" readonly Class="form-control" />


                </div>
            </div>




            <div class="row">
                <div class="col-md-1"></div>

                <div class="col-md-3">
                    <Label Class="control-label labeltext">Monitor Absent</Label>
                    <select ng-model="AdvanceInfo.MonitorAbsentSelected" ng-options="itemn.DisplayText for itemn in ValueLists.MonitorAbsent.ValueListItems track by itemn.DataValue" Class="form-control"></select>
                </div>
                <div class="col-md-3">
                    <Label Class="control-label labeltext">Break Hours</Label>
                    <input type="text" ng-model="AdvanceInfo.BHours" readonly Class="form-control" />
                </div>
                <div class="col-md-3">
                    <Label Class="control-label labeltext">For Machine</Label>
                    <select ng-model="AdvanceInfo.ForMachineSelected" ng-options="iten.DisplayText for iten in ValueLists.ForMachine.ValueListItems track by iten.DataValue" Class="form-control"></select>
                </div>




            </div>
            <div class="row">
                <div class="col-md-1"></div>

                <div class="col-md-3">
                    <Label Class="control-label labeltext">ETime Act</Label>
                    <input type="text" ng-model="AdvanceInfo.ETimeAct" Class="form-control" />
                </div>
                <div class="col-md-3">
                    <Label Class="control-label labeltext">For Persons</Label>
                    <select ng-model="AdvanceInfo.ForPersonsSelected" ng-options="item.DisplayText for item in ValueLists.ForPersons.ValueListItems track by item.DataValue" Class="form-control"></select>
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
                $scope.AdvanceInfo = $scope.model.dsForm.DT[0];
                $scope.Party = $scope.model.dsForm.party;
                $scope.dsCombo = $scope.model.dsCombo;

                $scope.ValueLists = $scope.model.ValueLists;

               @Html.RenderLookup("AdvanceInfo", Model, Model.dsForm.Tables(0));

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

