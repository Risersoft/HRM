
@imports risersoft.shared.cloud.common
@imports risersoft.app.mxform.hrm
@imports Newtonsoft.Json
@imports risersoft.shared.web.Extensions
@ModelType frmCompanyHRModel
@Code
    ViewData("Title") = "Company HR"
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
                <div class="col-md-8"><label class="control-label lbln">Company HR</label></div>
            </div>
            <div Class="row" style="margin-top:40px;margin-bottom:40px">
                <div Class="col-md-1"></div>
                <div Class="col-md-10">
                    <Label Class="control-label labeltext">Name</Label>
                    <input type="text" ng-model="CompanyInfo.CompName" style="max-width: 796px;" class="form-control" />
                </div>

            </div>

            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Details</label></div>
            </div>



            <div Class="row">
                <div Class="col-md-1"></div>
                <div Class="col-md-5">
                    <Label Class="control-label labeltext">HR Start Date</Label>
                    <input type="text" ng-model="CompanyInfo.HRStartDate" style="max-width: 340px;" Class="form-control my-datepicker" />
                </div>
                <div Class="col-md-5">
                    <Label Class="control-label labeltext">Main Shift<span class="red">*</span></Label>
                    <input type="text" name="InvoiceNum" ng-model="CompanyInfo.PANNum" style="max-width: 340px;" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.InvoiceNum.$invalid]" />
                </div>

            </div>
            <div Class="row">
                <div Class="col-md-1"></div>
                <div Class="col-md-5">
                    <Label Class="control-label labeltext">Leave Start Month</Label>
                    <input type="text" ng-model="CompanyInfo.LeaveStartMonth" style="max-width: 340px;" Class="form-control" />
                </div>
                <div Class="col-md-5">
                    <Label Class="control-label labeltext">Leave Encash Days/Year<span class="red">*</span></Label>
                    <input type="text" name="InvoiceNum" ng-model="CompanyInfo.LeaveCashDaysYear" style="max-width: 340px;" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.InvoiceNum.$invalid]" />
                </div>

            </div>
            <div Class="row">
                <div Class="col-md-1"></div>
                <div Class="col-md-5">
                    <Label Class="control-label labeltext">Bonus Start Month</Label>
                    <input type="text" ng-model="CompanyInfo.BonusStartMonth" style="max-width: 340px;" Class="form-control" />
                </div>
                <div Class="col-md-5">
                    <Label Class="control-label labeltext">Gratuity Days/Year<span class="red">*</span></Label>
                    <input type="text" name="InvoiceNum" ng-model="CompanyInfo.GratuityDaysPerYear" style="max-width: 340px;" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.InvoiceNum.$invalid]" />
                </div>

            </div>
            <div Class="row">
                <div Class="col-md-1"></div>
                <div Class="col-md-5">
                    <Label Class="control-label labeltext">Minimum Att Average for</Label>
                    <input type="text" ng-model="CompanyInfo.AdvAttAvgMin" style="max-width: 340px;" Class="form-control" />
                </div>
                <div Class="col-md-5">
                    <Label Class="control-label labeltext">Gratuity Min Months<span class="red">*</span></Label>
                    <input type="text" name="InvoiceNum" ng-model="CompanyInfo.GratuityMinMonths" style="max-width: 340px;" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.InvoiceNum.$invalid]" />
                </div>

            </div>
            <div Class="row">
                <div Class="col-md-1"></div>
                <div Class="col-md-5">
                    <Label Class="control-label labeltext">Advance Day</Label>
                    <input type="text" ng-model="CompanyInfo.AdvanceDay" style="max-width: 340px;" Class="form-control" />
                </div>
                <div Class="col-md-5">
                    <Label Class="control-label labeltext">Policy Num Group Gratuity<span class="red">*</span></Label>
                    <input type="text" name="InvoiceNum" ng-model="CompanyInfo.PolicyNumGG" style="max-width: 340px;" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.InvoiceNum.$invalid]" />
                </div>

            </div>
            <div Class="row">
                <div Class="col-md-1"></div>
                <div Class="col-md-5">
                    <Label Class="control-label labeltext">Advance Request Days</Label>
                    <input type="text" ng-model="CompanyInfo.AdvanceRequestDays" style="max-width: 340px;" Class="form-control" />
                </div>
                <div Class="col-md-5">
                    <Label Class="control-label labeltext">Policy Num EDLIP<span class="red">*</span></Label>
                    <input type="text" name="InvoiceNum" ng-model="CompanyInfo.PolicyNumEDLIP" style="max-width: 340px;" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.InvoiceNum.$invalid]" />
                </div>

            </div>
            <div Class="row">
                <div Class="col-md-1"></div>
                <div Class="col-md-5">
                    <Label Class="control-label labeltext">Advance Limit %</Label>
                    <input type="text" ng-model="CompanyInfo.AdvLimitPercent" style="max-width: 340px;" Class="form-control" />
                </div>


            </div>
            <div Class="row" style="margin-top:40px">
                <div Class="col-md-1"></div>
                <div Class="col-md-10">
                    <Label Class="control-label labeltext">ESI Reasons <span class="red">*</span></Label>
                    <input type="text" ng-model="CompanyInfo.ESIReasons" style="max-width: 796px;" class="form-control" />
                </div>


            </div>

            <div Class="row" style="margin-top:40px">
                <div Class="col-md-1"></div>
                <div Class="col-md-10">
                    <Label Class="control-label labeltext">Employment Office <span class="red">*</span></Label>
                    <input type="text" ng-model="CompanyInfo.EmploymentOffice" style="max-width: 796px;" class="form-control" />
                </div>

            </div>


            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Rates</label></div>
            </div>




            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">


                    <div class="table-responsive">
                        <table class="table table-bordered table-striped space10">
                            <tr class="tbld">
                                <td>Date</td>
                                <td>Week Start From</td>
                                <td>First Week Off</td>
                                <td>Second Week Off</td>
                                <td>Second Week Off Type</td>
                                <td>Skill</td>
                                <td>SemiSkill</td>
                                <td>UnSkill</td>
                                <td>BaseIndex</td>
                                <td>CurrentIndex</td>
                                <td></td>


                            </tr>








                            <tr ng-repeat="row in Rate">
                                <td><label>{{row.Dated}}</label></td>
                                <td><label>{{row.WeekStart}}</label></td>
                                <td><label>{{row.Weeklyoff1}}</label></td>
                                <td><label>{{row.Weeklyoff2}}</label></td>
                                <td><label>{{row.Weeklyoff2Type}}</label></td>
                                <td><label>{{row.VDASkill}}</label></td>
                                <td><label>{{row.VDASemi}}</label></td>
                                <td><label>{{row.VDAUnSkill}}</label></td>
                                <td><label>{{row.VDABaseIndex}}</label></td>
                                <td><label>{{row.VDACurrentIndex}}</label></td>
                                <td><a href="" ng-click="efnc(row,'frmRateMaster',row.RateMasterID)">Edit</a></td>





                            </tr>


                        </table>
                    </div>
                </div>

            </div>









            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Bonus</label></div>
            </div>







            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">


                    <div class="table-responsive">
                        <table class="table table-bordered table-striped space10">
                            <tr class="tbld">
                                <td>Bonus Period</td>
                                <td>Start Date</td>
                                <td>End Date</td>
                                <td>Calculated On</td>
                                <td>Paid On</td>
                                <td>Cut Off</td>
                                <td>Percentage</td>
                                <td>BonusPerCas</td>
                                <td>Minimum Days</td>
                                <td>Limit</td>
                                <td></td>


                            </tr>








                            <tr ng-repeat="row in Bonus">
                                <td><label>{{row.Descrip}}</label></td>
                                <td><label>{{row.sDate}}</label></td>
                                <td><label>{{row.eDate}}</label></td>
                                <td><label>{{row.BonusCalcOn}}</label></td>
                                <td><label>{{row.BonusPaidOn}}</label></td>
                                <td><label>{{row.BonusCutOff}}</label></td>
                                <td><label>{{row.BonusPer}}</label></td>
                                <td><label>{{row.BonusPerCas}}</label></td>
                                <td><label>{{row.BonusMinDays}}</label></td>
                                <td><label>{{row.BonusLimit}}</label></td>
                                <td><a href="" ng-click="efnc(row,'frmBonusMaster',row.BonusMasterID)">Edit</a></td>





                            </tr>


                        </table>
                    </div>
                </div>

            </div>





            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Leave</label></div>
            </div>

            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">


                    <div class="table-responsive">
                        <table class="table table-bordered table-striped space10">
                            <tr class="tbld">
                                <td>Leaved Period</td>
                                <td>Stard Date</td>
                                <td>End Date</td>
                                <td>Leave Calculated On</td>

                                <td></td>


                            </tr>








                            <tr ng-repeat="row in Leave">
                                <td><label>{{row.Descrip}}</label></td>
                                <td><label>{{row.sDate}}</label></td>
                                <td><label>{{row.eDate}}</label></td>
                                <td><label>{{row.LeaveCalcOn}}</label></td>

                                <td><a href="" ng-click="efnc(row,'frmLeaveMaster',row.LeaveMasterID)">Edit</a></td>





                            </tr>


                        </table>
                    </div>
                </div>

            </div>





            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Benefits</label></div>
            </div>


            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">


                    <div class="table-responsive">
                        <table class="table table-bordered table-striped space10">
                            <tr class="tbld">
                                <td>Code</td>
                                <td>Name</td>
                                <td>Company Code</td>
                                <td>Start Date</td>
                                <td>End Date</td>
                                <td>ReturnMonths</td>

                                <td></td>


                            </tr>








                            <tr ng-repeat="row in Ben">
                                <td><label>{{row.BenefitCode}}</label></td>
                                <td><label>{{row.BenefitName}}</label></td>
                                <td><label>{{row.CompCode}}</label></td>
                                <td><label>{{row.StartDate}}</label></td>
                                <td><label>{{row.EndDate}}</label></td>
                                <td><label>{{row.ReturnMonths}}</label></td>

                                <td><a href="" ng-click="efnc(row,'frmSalBenefitMaster',row.BenefitMasterID)">Edit</a></td>





                            </tr>


                        </table>
                    </div>
                </div>

            </div>

            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Loan Rules</label></div>
            </div>


            <div Class="row">
                <div Class="col-md-1"></div>
                <div Class="col-md-10">
                    <Label Class="control-label labeltext">Loan Rules</Label>
                    <textarea ng-model="Leave.Descrip" style="max-width: 856px;" cols="8" rows="8" Class="form-control"></textarea>
                </div>


            </div>









            <div class="row"><hr /></div>











        </div>
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
                $scope.CompanyInfo = $scope.model.dsForm.DT[0];
                $scope.Party = $scope.model.dsForm.party;
                $scope.dsCombo = $scope.model.dsCombo;
                $scope.ValueLists = $scope.model.ValueLists;




                $scope.Rate = $scope.model.GridViews.Rate.MainGrid.myDS.Table;
                $scope.Ben = $scope.model.GridViews.Ben.MainGrid.myDS.Table;
                $scope.Leave = $scope.model.GridViews.Leave.MainGrid.myDS.Table;

                $scope.Bonus = $scope.model.GridViews.Bonus.MainGrid.myDS.Table;







                $scope.changestate = function (id) {

                    $scope.State = [];
                    if (id) {

                        $.each($scope.dsCombo.SU, function (item, index) {

                            if (index.countrycode === id.countrycode) {

                                $scope.State.push(index);

                            }
                        });
                    }

                };





                $scope.Rate.WeekStartSelected = $.grep($scope.ValueLists.Envb.ValueListItems, function (item, index) { return item.DataValue === $scope.Rate.WeekStart })[0];
                $scope.Rate.WeekEndSelected = $.grep($scope.ValueLists.Envw.ValueListItems, function (item, index) { return item.DataValue === $scope.Rate.Weeklyoff1 })[0];
                $scope.Rate.WeekEndOffSelected = $.grep($scope.ValueLists.Envo.ValueListItems, function (item, index) { return item.DataValue == $scope.Rate.Weeklyoff2 })[0];

                $scope.Rate.WeekStartnSelected = $.grep($scope.ValueLists.Envwo.ValueListItems, function (item, index) { return item.DataValue === $scope.Rate.Weeklyoff2Type })[0];




                $scope.changestate($scope.CompanyInfo.CountrySelected);
                $scope.efnc = function (row,key,id) {

                    var base = '/App/Link' + location.search;
                    var payload = { fKey: key, fMode: 'acEditM', IDX: id, rowData: JSON.stringify(row) };
                    $.post(base, payload, function (result) {
                        $scope.status = 'loaded';

                        window.location = result;
                        if (result.success) {
                            var data = JSON.parse(result.data);
                            loadmodel(data);
                            $scope.result = 'success';
                            $scope.message = '';
                        }
                        else {
                            if (result.message === '') { result.message = 'Unknown Error!' };


                            $scope.result = 'failure';
                            $scope.message = result.message;
                        }
                        $scope.$apply();
                        return;
                    });
                }
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

