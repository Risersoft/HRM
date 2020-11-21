
@imports risersoft.shared.cloud.common
@imports risersoft.app.mxform.hrm
@imports Newtonsoft.Json
@imports risersoft.shared.web.Extensions
@ModelType frmFullNFinalModel
@Code
    ViewData("Title") = "Full And Final"
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
                <div class="col-md-8"><label class="control-label lbln">FullNFinal</label></div>
            </div>


            <div class="row">
                <div class="col-md-1"></div>

                <div class="col-md-3">
                    <Label Class="control-label labeltext">Emp Code : </Label>   {{ContextRow.EmpCode}}

                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Name : </Label>   {{ContextRow.FullName}}



                </div>



                <div class="col-md-3">
                    <Label Class="control-label labeltext">Department : </Label>   {{ContextRow.Depname}}

                </div>

            </div>





            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Details</label></div>
            </div>














            <div class="row">
                <div class="col-md-1"></div>

                <div class="col-md-3">
                    <Label Class="control-label labeltext">Reason</Label>
                    <select ng-model="PartyInfo.ReasonSelected" ng-options="itemn.descriptot for itemn in dsCombo.emp track by itemn.codeword" Class="form-control"></select>

                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Notice Period Type</Label>
                    <select ng-model="PartyInfo.NoticePeriodTypeSelected" ng-options="itemn.descriptot for itemn in dsCombo.emp1 track by itemn.codeword" Class="form-control"></select>


                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Date</Label>
                    <input type="text" ng-model="PartyInfo.Date" Class="form-control my-datepicker" />


                </div>

            </div>



            <div class="row">
                <div class="col-md-1"></div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Notice Period Month</Label>
                    <input type="text" ng-model="PartyInfo.NoticePeriodMnth" Class="form-control " />


                </div>
                <div class="col-md-3">
                    <Label Class="control-label labeltext">Accept Date</Label>
                    <input type="text" ng-model="PartyInfo.AcceptDate" Class="form-control my-datepicker" />
                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Left Gratuity</Label>
                    <input type="text" ng-model="PartyInfo.LeftGratAmount" readonly Class="form-control" />


                </div>

            </div>

            <div class="row">
                <div class="col-md-1"></div>

                <div class="col-md-3">
                    <Label Class="control-label labeltext">Leave Date</Label>
                    <input type="text" ng-model="PartyInfo.LeaveDate" Class="form-control my-datepicker" />

                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Bonus</Label>
                    <input type="text" ng-model="PartyInfo.FFBonusPer" readonly Class="form-control" />


                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Service Gratuity</Label>
                    <input type="text" ng-model="PartyInfo.ServiceGratAmount" readonly Class="form-control" />


                </div>

            </div>






            <div class="row">
                <div class="col-md-1"></div>

                <div class="col-md-3">
                    <Label Class="control-label labeltext">Leave Encashment</Label>
                    <input type="text" ng-model="PartyInfo.ApplicationTypeSelected" readonly Class="form-control"></input>

                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext">PayPeriod</Label>




                    <select ng-model="PartyInfo.PayPeriodSelected" ng-options="itemn.DisplayText for itemn in ValueLists.FFIncludeLastPP.ValueListItems track by itemn.DataValue" Class="form-control"></select>
                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Loan Payable</Label>
                    <input type="text" ng-model="PartyInfo.ApproveDate" readonly Class="form-control" />


                </div>

            </div>



            <div class="row">
                <div class="col-md-1"></div>


                <div class="col-md-3">
                    <Label Class="control-label labeltext">Last Bonus</Label>
                    <select ng-model="PartyInfo.LastBonusSelected" ng-options="itemn.DisplayText for itemn in ValueLists.FFIncludeLastBonus.ValueListItems track by itemn.DataValue" Class="form-control"></select>

                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Ex Gratia</Label>
                    <input type="text" ng-model="PartyInfo.ApplicationDate" Class="form-control" />


                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">% Bonus</Label>


                    <input type="text" ng-model="PartyInfo.ApproveDate" Class="form-control" />


                </div>

            </div>
            <div class="row">
                <div class="col-md-1"></div>

                <div class="col-md-3">
                    <Label Class="control-label labeltext">Salary For The Month Of</Label>
                    <input type="text" ng-model="PartyInfo.ApplicationDate" readonly Class="form-control" />


                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext">TDS</Label>
                    <input type="text" ng-model="PartyInfo.ApplicationDate" Class="form-control" />


                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Net Payable</Label>
                    <input type="text" ng-model="PartyInfo.ApproveDate" readonly Class="form-control" />


                </div>

            </div>
            <div class="row">
                <div class="col-md-1"></div>

                <div class="col-md-3">
                    <Label Class="control-label labeltext">TDS Cess</Label>
                    <input type="text" ng-model="PartyInfo.ApplicationDate" Class="form-control" />


                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Professional Tax</Label>
                    <input type="text" ng-model="PartyInfo.ApplicationDate" Class="form-control" />


                </div>


            </div>






















            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Loans</label></div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">


                    <div class="table-responsive">
                        <table class="table table-bordered table-striped space10">
                            <tr class="tbld">
                                <td>Date</td>
                                <td>Amount</td>




                            </tr>
                            <tr ng-repeat="row in LoanPayBack">
                                <td><label>{{row.Dated}}</label></td>
                                <td><label>{{row.Amount}}</label></td>







                            </tr>


                        </table>
                    </div>
                </div>

            </div>
            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Leaves</label></div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">


                    <div class="table-responsive">
                        <table class="table table-bordered table-striped space10">
                            <tr class="tbld">
                                <td>Leave Type</td>


                                <td>Amount New</td>
                                <td>Amount Prev</td>



                            </tr>
                            <tr ng-repeat="row in lveledger">
                                <td><label>{{row.LeaveNum}}</label></td>
                                <td><label>{{row.AmountNew}}</label></td>
                                <td><label>{{row.AmountPrev}}</label></td>






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
                                <td>Descrip</td>
                                <td>Net Paid</td>




                            </tr>
                            <tr ng-repeat="row in Bonus">
                                <td><label>{{row.Descrip}}</label></td>
                                <td><label>{{row.NetPaid}}</label></td>







                            </tr>


                        </table>
                    </div>
                </div>

            </div>
            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Salary</label></div>
            </div>


            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">


                    <div class="table-responsive">
                        <table class="table table-bordered table-striped space10">
                            <tr class="tbld">
                                <td>PayPeriod</td>
                                <td>Campus</td>
                                <td>Dep Name</td>

                                <td>Designation</td>
                                <td>Acc. Number</td>
                                <td>TW Day</td>
                                <td>EW Day</td>
                                <td>Absent</td>
                                <td>Leave Allow</td>
                                <td>Arrear</td>
                                <td>Arrear Man</td>

                                <td>Advance</td>
                                <td>TDS</td>
                                <td>Bonus AmmoutFF</td>
                                <td>Bonus GratFF</td>
                                <td>Total BasicPS</td>
                                <td>Total Allow</td>



                                <td>Net Ammount</td>
                            </tr>
                            <tr ng-repeat="row in Sal">
                                <td><label>{{row.PayPeriodID}}</label></td>
                                <td><label>{{row.CampusID}}</label></td>
                                <td><label>{{row.DepName}}</label></td>
                                <td><label>{{row.Designation}}</label></td>
                                <td><label>{{row.BankAccNum}}</label></td>
                                <td><label>{{row.TWDay}}</label></td>
                                <td><label>{{row.EWDay}}</label></td>
                                <td><label>{{row.Absent}}</label></td>
                                <td><label>{{row.LeaveAllow}}</label></td>
                                <td><label>{{row.Arrear}}</label></td>
                                <td><label>{{row.ArrearMan}}</label></td>
                                <td><label>{{row.Advance}}</label></td>
                                <td><label>{{row.TDS}}</label></td>
                                <td><label>{{row.BonusAmountFF}}</label></td>
                                <td><label>{{row.BonusGratFF}}</label></td>
                                <td><label>{{row.TotalBasicPS}}</label></td>
                                <td><label>{{row.TotalAllow}}</label></td>
                                <td><label>{{row.NetPaid}}</label></td>








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
                $scope.Party = $scope.model.dsForm.party;
                $scope.dsCombo = $scope.model.dsCombo;
                $scope.ContextRow = $scope.model.pViewState.ContextRow.valuebag;
                $scope.ValueLists = $scope.model.ValueLists;
                $scope.LoanPayBack = $scope.model.GridViews.LoanPayBack.MainGrid.myDS.dt;
                $scope.lveledger = $scope.model.GridViews.lveledger.MainGrid.myDS.dt;
                $scope.Sal = $scope.model.GridViews.Sal.MainGrid.myDS.dt;
                $scope.Bonus = $scope.model.GridViews.Bonus.MainGrid.myDS.dt;
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

