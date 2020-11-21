
@imports risersoft.shared.cloud.common
@imports risersoft.app.mxform.hrm
@imports Newtonsoft.Json
@imports risersoft.shared.web.Extensions
@ModelType frmEmpSalaryModel
@Code
    ViewData("Title") = "Employee Salary"
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
                <div class="col-md-8"><label class="control-label lbln">Employee Salary</label></div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">

                    <label class="control-label labeltext">Name</label>
                    <input type="text" ng-model="EmpInfo.FullName" readonly class="form-control" />
                </div>







                <div class="col-md-3">
                    <label class="control-label labeltext">Code</label><input type="text" ng-model="EmpInfo.EmpCode" readonly class="form-control" />
                </div>






                <div class="col-md-3">
                    <label class="control-label labeltext">Department</label>
                    <input type="text" ng-model="EmpInfo.Depname" readonly class="form-control" />
                </div>

            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">

                    <label class="control-label labeltext">Salary Structure</label>
                    <select ng-model="PartyInfo.SalStructureIDSelected" ng-options="itemo.StructureName for itemo in dsCombo.SalStructure track by itemo.SalStructureID" Class="form-control"></select>
                </div>







                <div class="col-md-3">
                    <label class="control-label labeltext">Date</label><input type="text" ng-model="PartyInfo.Dated" class="form-control my-datepicker" />
                </div>





                <div class="col-md-3">

                    <label class="control-label labeltext"></label>
                    <Button type="button" id="items" Class="btn btn-primary btnf" ng-click="item()" style="float:left;padding-left: 47px;padding-right: 47px; margin-top:34px">Generate</Button>
                </div>


            </div>









            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Salary Definition</label></div>
            </div>



            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">

                    <label class="control-label labeltext">TDS Norm %<span class="red">*</span></label>
                    <input type="text" ng-model="PartyInfo.perTDSNorm" class="form-control" />
                </div>







                <div class="col-md-3">
                    <label class="control-label labeltext">Prof Tax Norm</label><input type="text" ng-model="PartyInfo.ProfTaxNorm" class="form-control" />
                </div>






                <div class="col-md-3">
                    <label class="control-label labeltext">Other</label>
                    <input type="text" ng-model="PartyInfo.Other" class="form-control" />
                </div>

            </div>



            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">

                    <label class="control-label labeltext">OT Hour Rate</label>
                    <input type="text" ng-model="PartyInfo.OTHourRate" class="form-control" />
                </div>







                <div class="col-md-3">
                    <label class="control-label labeltext">OT Sal Mult</label>  <input type="text" ng-model="PartyInfo.OTSalMult" class="form-control" />
                </div>






                <div class="col-md-3">
                    <label class="control-label labeltext">Skill</label>
                    <select ng-model="PartyInfo.SkillTextSelected" ng-options="itemt.descriptot for itemt in dsCombo.SkillText track by itemt.codeword" Class="form-control"></select>
                </div>

            </div>

            <div class="row" style="margin-top:17px; margin-bottom:15px;">
                <div class="col-md-1"></div>
                <div Class="col-md-6"><label class="control-label" style="text-decoration:underline;">Basic Calculation</label></div>

            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">

                    <label class="control-label labeltext">Proposed CTC</label>
                    <input type="text" ng-model="PartyInfo.MenDaysTotal" class="form-control" />
                </div>







                <div class="col-md-3">
                    <label class="control-label labeltext">Basic Percentage</label>  <input type="text" ng-model="PartyInfo.MenDaysWorked" class="form-control" />
                </div>






                <div class="col-md-3" style="margin-top: 40px;">
                    <Label Class="control-label">Ignore Previous Salary Value</Label>
                    <input type="checkbox" ng-model="PartyInfo.IsForController" />

                </div>

            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">

                    <label class="control-label labeltext"></label>
                    <Button type="button" id="items" Class="btn btn-primary btnf" ng-click="item()" style="float:left;padding-left: 47px;padding-right: 47px; margin-top:34px">Go !</Button>
                </div>




            </div>









            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln"></label></div>
            </div>
            <div class="container marb" ng-repeat="row in EmpSalComp" style="padding-top:5px;">
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">

                        <label class="control-label labeltext">Component<span class="red">*</span></label>
                        <input type="text" ng-model="row.SalComponentID" class="form-control" />
                    </div>







                    <div class="col-md-3">
                        <label class="control-label labeltext">Amount</label><input type="text" ng-model="row.Amount" class="form-control" />
                    </div>








                </div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">


                    <div class="table-responsive">
                        <table class="table table-bordered table-striped space10">
                            <tr class="tbld">
                                <td>Date</td>
                                <td>Basic</td>
                                <td>Allowance</td>
                                <td>TotalPay</td>
                                <td>TakeHome</td>
                                <td>Bonus</td>
                                <td>LeaveNCash</td>

                                <td>Gratuity</td>
                                <td>CTC</td>



                            </tr>
                            <tr ng-repeat="row in Exp">
                                <td><label>{{row.Dated}}</label></td>
                                <td><label>{{row.TotalBasic}}</label></td>
                                <td><label>{{row.TotalAllow}}</label></td>
                                <td><label>{{row.TotalPay}}</label></td>
                                <td><label>{{row.TakeHome}}</label></td>
                                <td><label>{{row.Bonus}}</label></td>
                                <td><label>{{row.LeaveNCash}}</label></td>
                                <td><label>{{row.Gratuity}}</label></td>
                                <td><label>{{row.CTC}}</label></td>





                            </tr>


                        </table>
                    </div>
                </div>

            </div>
            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Calculation</label></div>
            </div>




            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">


                    <div class="table-responsive">
                        <table class="table table-bordered table-striped space10">
                            <tr class="tbld">
                                <td>Date</td>
                                <td>Basic</td>
                                <td>Allowance</td>
                                <td>TotalPay</td>
                                <td>TakeHome</td>
                                <td>Bonus</td>
                                <td>LeaveNCash</td>

                                <td>Gratuity</td>
                                <td>CTC</td>



                            </tr>
                            <tr ng-repeat="row in LastCalculated">
                                <td><label>{{row.Dated}}</label></td>
                                <td><label>{{row.TotalBasic}}</label></td>
                                <td><label>{{row.TotalAllow}}</label></td>
                                <td><label>{{row.TotalPay}}</label></td>
                                <td><label>{{row.TakeHome}}</label></td>
                                <td><label>{{row.Bonus}}</label></td>
                                <td><label>{{row.LeaveNCash}}</label></td>
                                <td><label>{{row.Gratuity}}</label></td>
                                <td><label>{{row.CTC}}</label></td>





                            </tr>


                        </table>
                    </div>
                </div>

            </div>






            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln"></label></div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">


                    <div class="table-responsive">
                        <table class="table table-bordered table-striped space10">
                            <tr class="tbld">
                                <td>Component</td>
                                <td>Benefit</td>
                                <td>Amount</td>
                                <td>BaseAmount</td>
                                <td>Employee Share</td>


                                <td>Employer Share</td>




                            </tr>
                            <tr ng-repeat="row in SalRCComp">
                                <td><label>{{row.ComponentName}}</label></td>
                                <td><label>{{row.Benefit}}</label></td>
                                <td><label>{{row.Amount}}</label></td>
                                <td><label>{{row.BaseAmount}}</label></td>




                                <td><label>{{row.EmployeeShare}}</label></td>
                                <td><label>{{row.EmployerShare}}</label></td>


                            </tr>


                        </table>
                    </div>
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



                $scope.dsCombo = $scope.model.dsCombo;
                $scope.EmpInfo = $scope.model.DatasetCollection.Emp.EmployeeID[0];
                $scope.ValueLists = $scope.model.ValueLists;
                $scope.Exp = $scope.model.GridViews.SalRateCalc.MainGrid.myDS.dt;
                $scope.LastCalculated = $scope.model.GridViews.LastCalculated.MainGrid.myDS.dt;



                $scope.EmpSalComp = $scope.model.GridViews.EmpSalComp.MainGrid.myDS.dt;




                $scope.SalRCComp = $scope.model.DatasetCollection.SalRCComp.SalRCComp;

                @Html.RenderLookup("PartyInfo", Model, Model.dsForm.Tables(0))
                $.each($scope.Holiday, function (index, row) {
                    row.CampusSelected = $.grep($scope.Campus, function (item, index) { return item.CampusID === row.CampusID })[0];
                    row.HolidayTypeSelected = $.grep($scope.ValueLists.Tnvlp.ValueListItems, function (item, index) { return item.DataValue === row.Isworking })[0];
                });

                $scope.item = function () {
                    $scope.Holiday.push({});
                };
                $scope.delete = function (index) {
                    $scope.Holiday.splice(index, 1);
                };



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

