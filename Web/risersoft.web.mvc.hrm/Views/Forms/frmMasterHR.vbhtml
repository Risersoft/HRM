
@imports risersoft.shared.cloud.common
@imports risersoft.app.mxform.hrm
@imports Newtonsoft.Json
@imports risersoft.shared.web.Extensions
@ModelType frmMasterHRModel
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
                <div class="col-md-8"><label class="control-label lbln">Salary Structure</label></div>
            </div>


            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">


                    <div class="table-responsive">
                        <table class="table table-bordered table-striped space10">
                            <tr class="tbld">
                                <td>StructureName</td>
                                <td>ComponentCode</td>
                                <td>ComponentName</td>
                                <td>Behave</td>
                                <td>CompType</td>
                                <td>AllowType</td>

                                <td></td>


                            </tr>








                            <tr ng-repeat="row in SalComp">
                                <td><label>{{row.StructureName}}</label></td>
                                <td><label>{{row.ComponentCode}}</label></td>
                                <td><label>{{row.ComponentName}}</label></td>
                                <td><label>{{row.Behave}}</label></td>
                                <td><label>{{row.CompType}}</label></td>
                                <td><label>{{row.AllowType}}</label></td>

                                <td><a href="">Edit</a></td>





                            </tr>


                        </table>
                    </div>
                </div>

            </div>
            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Salary Benefits</label></div>
            </div>


            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">


                    <div class="table-responsive">
                        <table class="table table-bordered table-striped space10">
                            <tr class="tbld">
                                <td>Benefit Code</td>
                                <td>Benefit Name</td>
                                <td>Behave</td>
                                <td>Apply Comp Type</td>
                                <td>Admin Amount1 Name</td>
                                <td>Admin Amount2 Name</td>

                                <td></td>


                            </tr>








                            <tr ng-repeat="row in SalBen">
                                <td><label>{{row.BenefitCode}}</label></td>
                                <td><label>{{row.BenefitName}}</label></td>
                                <td><label>{{row.Behave}}</label></td>
                                <td><label>{{row.ApplyCompType}}</label></td>
                                <td><label>{{row.AdminAmount1Name}}</label></td>
                                <td><label>{{row.AdminAmount2Name}}</label></td>

                                <td><a href="">Edit</a></td>





                            </tr>


                        </table>
                    </div>
                </div>

            </div>





            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Attendance Type</label></div>
            </div>

            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">


                    <div class="table-responsive">
                        <table class="table table-bordered table-striped space10">
                            <tr class="tbld">
                                <td>TagType</td>
                                <td>FullTag</td>
                                <td>MaxAccure</td>


                                <td>Accure Type</td>
                                <td>LvePeriodType</td>
                                <td>LvePeriodNum</td>
                                <td>LveDue</td>
                                <td>CountOnlyWork</td>
                                <td>CarryForwardLimit</td>
                                <td>AllowEncashLM</td>


                                <td>AllowEncashFF</td>
                                <td>LeaveGroup</td>

                                <td>UserLeaveGroup</td>
                                <td></td>
                            </tr>








                            <tr ng-repeat="row in AttTagMstr">
                                <td><label>{{row.TagType}}</label></td>
                                <td><label>{{row.FullTag}}</label></td>
                                <td><label>{{row.MaxAccrue}}</label></td>
                                <td><label>{{row.AccrueType}}</label></td>
                                <td><label>{{row.LvePeriodType}}</label></td>
                                <td><label>{{row.LvePeriodNum}}</label></td>
                                <td><label>{{row.LveDue}}</label></td>
                                <td><label>{{row.CountOnlyWork}}</label></td>
                                <td><label>{{row.CarryForwardLimit}}</label></td>
                                <td><label>{{row.AllowEncashLM}}</label></td>
                                <td><label>{{row.AllowEncashFF}}</label></td>
                                <td><label>{{row.LeaveGroup}}</label></td>
                                <td><label>{{row.UseLeaveGroup}}</label></td>
                                <td><a href="">Edit</a></td>





                            </tr>


                        </table>
                    </div>
                </div>

            </div>







            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Shift</label></div>
            </div>







            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">


                    <div class="table-responsive">
                        <table class="table table-bordered table-striped space10">
                            <tr class="tbld">
                                <td>Shift</td>
                                <td>STime</td>
                                <td>ETime</td>
                                <td>WHours</td>
                                <td>BHours</td>
                                <td>LunchOut</td>
                                <td>LunchIn</td>
                                <td>ETimeAct</td>
                                <td>ForMachine</td>
                                <td>ForPersons</td>

                                <td>Monitor</td>

                                <td></td>


                            </tr>








                            <tr ng-repeat="row in Shiftinfo">
                                <td><label>{{row.Shift}}</label></td>
                                <td><label>{{row.STime}}</label></td>
                                <td><label>{{row.ETime}}</label></td>
                                <td><label>{{row.WHours}}</label></td>
                                <td><label>{{row.BHours}}</label></td>
                                <td><label>{{row.LunchOut}}</label></td>
                                <td><label>{{row.LunchIn}}</label></td>
                                <td><label>{{row.ETimeAct}}</label></td>
                                <td><label>{{row.ForMachine}}</label></td>
                                <td><label>{{row.ForPersons}}</label></td>
                                <td><label>{{row.MonitorAbsent}}</label></td>
                                <td><a href="">Edit</a></td>





                            </tr>


                        </table>
                    </div>
                </div>

            </div>















        </div>
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
                //$scope.PartyInfo = $scope.model.dsForm.DT[0];
                //$scope.Party = $scope.model.dsForm.party;
                //$scope.dsCombo = $scope.model.dsCombo;
                //$scope.ValueLists = $scope.model.ValueLists;
                $scope.SalComp = $scope.model.GridViews.SalComp.MainGrid.myDS.Table;



                $scope.Shiftinfo = $scope.model.GridViews.Shift.MainGrid.myDS.Table;


                $scope.SalBen = $scope.model.GridViews.SalBen.MainGrid.myDS.Table;
                $scope.AttTagMstr = $scope.model.GridViews.AttTagMstr.MainGrid.myDS.Table;
                $scope.ValueLists = $scope.model.ValueLists;
                $scope.GstNot = []; $scope.GstNotc = []; $scope.GstNotu = [];
                $scope.item = function () {
                    $scope.SalComp.push({});
                };
                $scope.delete = function (index) {
                    $scope.SalComp.splice(index, 1);
                };
                $scope.itemn = function () {
                    $scope.SalBen.push({});
                };
                $scope.deleten = function (index) {
                    $scope.SalBen.splice(index, 1);
                };





                $scope.itemcn = function () {
                    $scope.AttTagMstr.push({});
                };
                $scope.deletecn = function (index) {
                    $scope.AttTagMstr.splice(index, 1);
                };
                $scope.itemun = function () {
                    $scope.Shiftinfo.push({});
                };


                $scope.deleteun = function (index) {
                    $scope.Shiftinfo.splice(index, 1);
                };
               @*@Html.RenderLookup("PartyInfo", Model, Model.dsForm.Tables(0));*@








                $.each($scope.SalComp, function (index, row) {
                    row.BehaveSelected = $.grep($scope.ValueLists.Envb.ValueListItems, function (item, index) { return item.DataValue === row.Behave })[0];
                    row.CompTypeSelected = $.grep($scope.ValueLists.Envc.ValueListItems, function (item, index) { return item.DataValue === row.CompType })[0];
                    row.AllowTypeSelected = $.grep($scope.ValueLists.Envp.ValueListItems, function (item, index) { return item.DataValue == row.AllowType })[0];


                });

                $.each($scope.Shiftinfo, function (index, row) {
                    row.MonitorSelected = $.grep($scope.ValueLists.Mnvh.ValueListItems, function (item, index) { return item.DataValue === row.MonitorAbsent })[0];
                    row.MachineSelected = $.grep($scope.ValueLists.Mnvp.ValueListItems, function (item, index) { return item.DataValue === row.ForMachine })[0];
                    row.PersonSelected = $.grep($scope.ValueLists.Pnvc.ValueListItems, function (item, index) { return item.DataValue === row.ForPersons })[0];
                });







                $.each($scope.SalBen, function (index, row) {
                    row.BehaveSelected = $.grep($scope.ValueLists.Bnvc.ValueListItems, function (item, index) { return item.DataValue === row.Behave })[0];
                    row.ApplyCompTypeSelected = $.grep($scope.ValueLists.Envc.ValueListItems, function (item, index) { return item.DataValue === row.ApplyCompType })[0];



                });


                $.each($scope.AttTagMstr, function (index, row) {
                    row.TagTypeSelected = $.grep($scope.ValueLists.Tnvc.ValueListItems, function (item, index) { return item.DataValue === row.TagType })[0];
                    row.AccureTypeSelected = $.grep($scope.ValueLists.Tnvcp.ValueListItems, function (item, index) { return item.DataValue === row.AccrueType })[0];
                    row.LeavePeriodTypeSelected = $.grep($scope.ValueLists.Tnvlp.ValueListItems, function (item, index) { return item.DataValue == row.LvePeriodType })[0];

                    row.CoutOSelected = $.grep($scope.ValueLists.LMnvo.ValueListItems, function (item, index) { return item.DataValue === row.CountOnlyWork })[0];
                    row.EnLMSelected = $.grep($scope.ValueLists.LMnvp.ValueListItems, function (item, index) { return item.DataValue === row.AllowEncashLM })[0];
                    row.EnFFSelected = $.grep($scope.ValueLists.FFnvp.ValueListItems, function (item, index) { return item.DataValue === row.AllowEncashFF })[0];


                });
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

