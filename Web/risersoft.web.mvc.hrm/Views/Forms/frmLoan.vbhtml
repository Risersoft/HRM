
@imports risersoft.shared.cloud.common
@imports risersoft.app.mxform.hrm
@imports Newtonsoft.Json
@imports risersoft.shared.web.Extensions
@ModelType frmLoanModel
@Code
    ViewData("Title") = "Loan"
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
                <div class="col-md-8"><label class="control-label lbln">Loan</label></div>
            </div>


            <div class="row">
                <div class="col-md-1"></div>

                <div class="col-md-3">
                    <Label Class="control-label labeltext">Emp Code : </Label>   {{Employee.EmpCode}}

                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Name : </Label>   {{Employee.FullName}}



                </div>


            </div>

            <div class="row">
                <div class="col-md-1"></div>

                <div class="col-md-3">
                    <Label Class="control-label labeltext">Date</Label>
                    <input type="text" ng-model="LoanInfo.Dated" class="form-control my-datepicker" />

                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Completed On</Label>
                    <input type="text" ng-model="LoanInfo.CompletedOn" readonly Class="form-control " />


                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Amount</Label>
                    <input type="text" ng-model="LoanInfo.Amount" Class="form-control" />


                </div>

            </div>



            <div class="row">
                <div class="col-md-1"></div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Detuct Amount Per Month</Label>
                    <input type="text" ng-model="LoanInfo.DeductAmountPM" Class="form-control" />


                </div>
                <div class="col-md-3">
                    <Label Class="control-label labeltext">Detuct From Per Month</Label>
                    <select ng-model="LoanInfo.DeductFromPMSelected" ng-options="itemn.descriptot for itemn in dsCombo.DeductFromPM track by itemn.codeword" Class="form-control"></select>

                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Detuct Starting From</Label>
                    <input type="text" ng-model="LoanInfo.DeductStartFrom" Class="form-control my-datepicker" />


                </div>

            </div>


            <div class="row">
                <div class="col-md-1"></div>

                <div class="col-md-10">
                    <Label Class="control-label labeltext">Remark</Label>
                    <input type="text" ng-model="LoanInfo.Remark" style="max-width:794px" class="form-control" />

                </div>












            </div>
            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-10"><label class="control-label lbln">Pay Period</label> <Button type="button" id="items" Class="btn btn-primary btnf" ng-click="item()" style="margin-top:5px;margin-bottom:5px;float:right">ADD</Button></div>
            </div>

            <div ng-repeat="row in LoanPayBack">
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">

                        <label class="control-label labeltext">PayPeriodName</label>
                        <input type="text" ng-model="row.PayPeriodName" class="form-control" />
                    </div>


                    <div class="col-md-3">
                        <label class="control-label labeltext">Amount </label><input type="text" ng-model="row.Amount" class="form-control" />
                    </div>






                    <div class="col-md-3">
                        <label class="control-label labeltext">Remark</label>
                        <input type="text" ng-model="row.Remark" class="form-control" />
                    </div>








                </div>

                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">

                        <label class="control-label labeltext">DeductFromPP</label>
                        <select ng-model="row.DeductFromPPSelected" ng-options="itemt.descriptot for itemt in DeductFromPP track by itemt.codeword" Class="form-control"></select>

                    </div>













                    <div class="col-md-1">
                        <a href="" class="delete" style="z-index:35;position:relative;margin-top:38px;float:right" ng-click="delete($index)"><span class="fa fa-trash" style="color: #d83e3b;"></span></a>
                    </div>




                </div>



                <div class="row"><hr /></div>
            </div>













            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-10"><label class="control-label lbln">Incentive</label> <Button type="button" id="items" Class="btn btn-primary btnf" ng-click="itemn()" style="margin-top:5px;margin-bottom:5px;float:right">ADD</Button></div>
            </div>
            <div ng-repeat="row in LoanPayBackIncen">
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">

                        <label class="control-label labeltext">PayPeriodName</label>
                        <input type="text" ng-model="row.PayPeriodName" class="form-control" />
                    </div>


                    <div class="col-md-3">
                        <label class="control-label labeltext">Amount </label><input type="text" ng-model="row.Amount" class="form-control" />
                    </div>






                    <div class="col-md-3">
                        <label class="control-label labeltext">Remark</label>
                        <input type="text" ng-model="row.Remark" class="form-control" />
                    </div>




                    <div class="col-md-1">
                        <a href="" class="delete" style="z-index:35;position:relative;margin-top:38px;float:right" ng-click="deleten($index)"><span class="fa fa-trash" style="color: #d83e3b;"></span></a>
                    </div>



                </div>





                <div class="row"><hr /></div>
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
                                <td>Designation</td>
                                <td>JoinDate</td>
                                <td>LeaveDate</td>
                                <td>Status</td>
                                <td></td>

                            </tr>
                            <tr ng-repeat="row in Bonus">
                                <td><label>{{row.Designation}}</label></td>
                                <td><label>{{row.JoinDate}}</label></td>
                                <td><label>{{row.LeaveDate}}</label></td>
                                <td><label>{{row.Status}}</label></td>




                                <td><a href="" ng-click="efnc(row)">Edit</a></td>
                            </tr>


                        </table>
                    </div>
                </div>

            </div>

            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-10"><label class="control-label lbln">AdHoc  </label> <Button type="button" id="items" Class="btn btn-primary btnf" ng-click="itemcn()" style="margin-top:5px;margin-bottom:5px;float:right">ADD</Button></div>
            </div>


            <div ng-repeat="rowc in AdHoc">
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">

                        <label class="control-label labeltext">AdHocPayDate </label>
                        <input type="text" ng-model="rowc.AdHocPayDate" class="form-control" />
                    </div>


                    <div class="col-md-3">
                        <label class="control-label labeltext">Amount </label><input type="text" ng-model="rowc.Amount" class="form-control" />
                    </div>






                    <div class="col-md-3">
                        <label class="control-label labeltext">Remark</label>
                        <input type="text" ng-model="rowc.Remark" class="form-control" />
                    </div>





                    <div class="col-md-1">
                        <a href="" class="delete" style="z-index:35;position:relative;margin-top:38px;float:right" ng-click="deletecn($index)"><span class="fa fa-trash" style="color: #d83e3b;"></span></a>
                    </div>




                </div>





                <div class="row"><hr /></div>
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
                $scope.LoanInfo = $scope.model.dsForm.DT[0];
                $scope.Party = $scope.model.dsForm.party;
                $scope.dsCombo = $scope.model.dsCombo;

                $scope.ValueLists = $scope.model.ValueLists;





                $scope.LoanPayBack = $scope.model.GridViews.LoanPayBack.MainGrid.myDS.dt;
                $scope.DeductFromPP = $scope.model.GridViews.LoanPayBack.MainGrid.dsLookup.Table0;
                $scope.LoanPayBackIncen = $scope.model.GridViews.LoanPayBackIncen.MainGrid.myDS.dt;
                $scope.Bonus = $scope.model.GridViews.Bonus.MainGrid.myDS.dt;


                $scope.AdHoc = $scope.model.GridViews.AdHoc.MainGrid.myDS.dt;





                $scope.Employee = $scope.model.DatasetCollection.Emp.EmployeeID[0];
                $scope.item = function () {
                    $scope.LoanPayBack.push({});
                };
                $scope.delete = function (index) {
                    $scope.LoanPayBack.splice(index, 1);
                };



                $scope.itemn = function () {
                    $scope.LoanPayBackIncen.push({});
                };
                $scope.deleten = function (index) {
                    $scope.LoanPayBackIncen.splice(index, 1);
                };
                $scope.itemcn = function () {
                    $scope.AdHoc.push({});
                };




                $scope.deletecn = function (index) {
                    $scope.AdHoc.splice(index, 1);
                };
                $.each($scope.LoanPayBack, function (index, row) {
                    row.DeductFromPPSelected = $.grep($scope.DeductFromPP, function (item, index) { return item.codeword === row.DeductFromPP })[0];

                });
               @Html.RenderLookup("LoanInfo", Model, Model.dsForm.Tables(0));









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

