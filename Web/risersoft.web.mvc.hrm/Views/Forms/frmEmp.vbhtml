
@imports risersoft.shared.cloud.common
@imports risersoft.app.mxform.hrm
@imports Newtonsoft.Json
@imports risersoft.shared.web.Extensions
@ModelType frmEmpModel
@Code
    ViewData("Title") = "Employee"
    Layout = "~/Views/Shared/_FrameworkLayout.vbhtml"

    Dim modelJson = JsonConvert.SerializeObject(Model, Formatting.Indented,
            New JsonSerializerSettings With {.StringEscapeHandling = StringEscapeHandling.EscapeHtml, .NullValueHandling = NullValueHandling.Ignore})


End Code




<div class="container cbackground">
    <form action="" method="post" name="userform" ng-controller="FormController">
        @Html.AntiForgeryToken()
        <input type="hidden" id="model_json" value='@Html.Raw(modelJson)' />
        <div Class="form-horizontal">
            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Employee</label></div>
            </div>
            <div class="row marb" style="padding:15px;">







                <div class="col-md-1"></div>
                <div class="col-md-13">
                   
                    <div class="tab-content">





                        <div class="row">
                            <div class="col-md-1"></div>
                            <div Class="col-md-3">
                                <Label Class="control-label">Code</Label>
                                <input type="text" ng-model="PartyInfo.EmpCode" Class="form-control" />
                            </div>
                            <div class="col-md-3">
                                <Label Class="control-label">UIDNum</Label>
                                <input type="text" ng-model="PartyInfo.UIDNum" Class="form-control" />
                            </div>
                            <div Class="col-md-3">
                                <Label Class="control-label">JoinDate</Label>
                                <input type="text" ng-model="PartyInfo.JoinDate"  Class="form-control my-datepicker" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-1"></div>

                            <div class="col-md-3">
                                <Label Class="control-label">PANNum</Label>
                                <input type="text" ng-model="PartyInfo.PANNum" Class="form-control" />
                            </div>
                            <div Class="col-md-3">
                                <Label Class="control-label">Designation</Label>
                                <input type="text" ng-model="PartyInfo.Designation" Class="form-control" />
                            </div>
                            <div class="col-md-3">
                                <Label Class="control-label">Function</Label>
                                <input type="text" ng-model="PartyInfo.JobFunc" Class="form-control" />
                            </div>
                        </div>

                        <div Class="row">
                            <div Class="col-md-1"></div>
                            <div Class="col-md-3">
                                <Label Class="control-label">Department</Label>
                                <select ng-model="PartyInfo.DepIDSelected" ng-options="itemn.depname for itemn in dsCombo.dep track by itemn.depid" Class="form-control"></select>
                            </div>




                            <div class="col-md-3">
                                <Label Class="control-label">Nature</Label>
                                <select ng-model="PartyInfo.iscasualSelected" ng-options="itemt.DisplayText for itemt in ValueLists.IsCasual.ValueListItems track by itemt.DataValue" Class="form-control"></select>
                                
                            </div>
                            <div Class="col-md-3">
                                <Label Class="control-label">Campus</Label>
                                <select ng-model="PartyInfo.CampusIDSelected" ng-options="itemn.dispname for itemn in dsCombo.campus track by itemn.campusid" Class="form-control"></select>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-1"></div>

                            <div class="col-md-3">
                                <Label Class="control-label">Card Number</Label>
                                <input type="text" ng-model="PartyInfo.CardNum" Class="form-control" />
                            </div>
                            <div Class="col-md-3">
                                <Label Class="control-label">Shift</Label>
                                <select ng-model="PartyInfo.ShiftIDSelected" ng-options="itemn.shift for itemn in dsCombo.shift track by itemn.shiftid" Class="form-control"></select>
                            </div>
                            <div Class="col-md-3">
                                <Label Class="control-label">Bank Account Number</Label>
                                <select Class="form-control"></select>

                            </div>
                        </div>





                        <div Class="row">


                            <div Class="col-md-1"></div>


                            <div Class="col-md-3">
                                <Label Class="control-label">Salary Category <span class="red">*</span></Label>

                                <select ng-model="PartyInfo.HasWageSelected" name="catgn" ng-options="itemc.DisplayText for itemc in ValueLists.haswage.ValueListItems track by itemc.DataValue" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.catgn.$invalid]"></select>
                            </div>
                            <div class="col-md-3">
                                <Label Class="control-label">Division <span class="red">*</span></Label>
                                <select ng-model="PartyInfo.DivisionIDSelected" name="cdivo" ng-options="itemn.DivisionName for itemn in dsCombo.Division track by itemn.Divisionid" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.cdivo.$invalid]"></select>
                            </div>
                            <div Class="col-md-3">
                                <Label Class="control-label">Work Force Category <span class="red">*</span></Label>
                                <select ng-model="PartyInfo.IsWorkerSelected" name="cwfto" ng-options="itemt.DisplayText for itemt in ValueLists.isworker.ValueListItems track by itemt.DataValue" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.cwfto.$invalid]"></select>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-1"></div>

                            <div class="col-md-3">
                                <Label Class="control-label">Bearer Name</Label>
                                <input type="text" ng-model="PartyInfo.BankAccBearerName" Class="form-control" />
                            </div>




                            <div Class="col-md-3">
                                <Label Class="control-label">Reports To</Label>
                                <select ng-model="PartyInfo.ReportsToIDSelected" ng-options="itemn.EmployeeName for itemn in dsCombo.rep track by itemn.employeeid" Class="form-control"></select>
                            </div>
                            <div class="col-md-3">
                                <Label Class="control-label">Payment Through <span class="red">*</span></Label>
                                <select ng-model="PartyInfo.PaymentThruCodeSelected" name="cpaytw" ng-options="itemn.descriptot for itemn in dsCombo.emp1 track by itemn.codeword" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.cpaytw.$invalid]"></select>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-1"></div>


                            <div Class="col-md-3">
                                <Label Class="control-label">Leave Date</Label>
                                <input type="text" ng-model="PartyInfo.LeaveDate" readonly Class="form-control" />
                            </div>
                            <div Class="col-md-3">
                                <Label Class="control-label">Reason For Leaving</Label>
                                <input type="text" ng-model="PartyInfo.DispName" readonly Class="form-control" />
                            </div>
                            <div class="col-md-3">
                                <Label Class="control-label">Status <span class="red">*</span></Label>





                                <select ng-model="PartyInfo.StatusNumSelected" name="csaty" ng-options="itemt.statusText for itemt in dsCombo.status track by itemt.statusnum" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.csaty.$invalid]"></select>
                            </div>
                        </div>



                        












                        <div class="row cbackgroun">
                            <div class="col-md-1"></div>
                            <div class="col-md-8"><label class="control-label lbln">Details</label></div>
                        </div>



                        <div Class="row">


                            <div Class="col-md-1"></div>
                            <div Class="col-md-3">
                                <Label Class="control-label">Contractor</Label>
                                <select ng-model="PartyInfo.ContractorIDSelected" ng-options="itemn.partyname for itemn in dsCombo.party track by itemn.vendorid" Class="form-control"></select>

                            </div>

                         <div class="col-md-3">
                                <label class="control-label">Care Of</label>
                                <input type="text" ng-model="PartyInfo.CareOf" class="form-control" />
                            </div>
                            <div class="col-md-3">
                                <label class="control-label">Relationship</label>
                                <select ng-model="PartyInfo.RelationShipSelected" ng-options="camp.DisplayText for camp in ValueLists.Relationship.ValueListItems track by camp.DataValue" Class="form-control"></select>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="col-md-3">

                                <Label Class="control-label">Rent Paid</Label>
                                <input type="text" ng-model="PartyInfo.RentPaid" Class="form-control" />


                            </div>

                            <div class="col-md-3">
                                <Label Class="control-label">LIC Number</Label>
                                <input type="text" ng-model="PartyInfo.LICNum" Class="form-control" />

                            </div>
                            <div class="col-md-3">
                                <label class="control-label">User</label>
                                <select ng-model="PartyInfo.UserIdSelected" ng-options="camp.username for camp in dsCombo.user track by camp.userid" Class="form-control"></select>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="col-md-3">
                                <Label Class="control-label">Cat Emp Number</Label>
                                <input type="text" ng-model="PartyInfo.CatEmpNum" Class="form-control" />

                            </div>
                            <div class="col-md-3">
                                <label class="control-label">LeaveAuthority1</label>
                                <select ng-model="PartyInfo.LeaveAuth1IDSelected" ng-options="camp.EmployeeName for camp in dsCombo.leave1 track by camp.employeeid" Class="form-control"></select>
                            </div>
                            <div class="col-md-3" style="margin-top: 40px;">
                                <Label Class="control-label">Is For Controller</Label>
                                <input type="checkbox" ng-model="PartyInfo.IsForController" />

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-1"></div>

                            <div class="col-md-3">
                                <label class="control-label">LeaveAuthority2</label>
                                <select ng-model="PartyInfo.LeaveAuth2IDSelected" ng-options="camp.EmployeeName for camp in dsCombo.leave2 track by camp.employeeid" Class="form-control"></select>
                            </div>
                            <div class="col-md-3">
                                <Label Class="control-label">Company Email</Label>
                                <input type="text" ng-model="PartyInfo.CompanyEmail" class="form-control" />

                            </div>







                            <div class="col-md-3">
                                <label class="control-label">Punch</label>
                                <select ng-model="PartyInfo.PunchEnabledSelected" ng-options="camp.DisplayText for camp in ValueLists.EnableList.ValueListItems  track by camp.DataValue" Class="form-control"></select>
                            </div>
                        </div>

                        <div Class="row">


                            <div Class="col-md-1"></div>
                            <div Class="col-md-3">
                                <Label Class="control-label">Dispensary</Label>
                                <input type="text" ng-model="PartyInfo.Dispensary" Class="form-control" style="max-width: 725px;" />

                            </div>



                            <div class="col-md-3">
                                <Label Class="control-label">Vendor Code</Label>

                                <input type="text" ng-model="PartyInfo.VendorCode" readonly class="form-control" />
                            </div>
                            <div class="col-md-3">
                                <label class="control-label">Imprest</label>
                                <select ng-model="PartyInfo.ImprestEnabledSelected" ng-options="camp.DisplayText for camp in ValueLists.EnableList.ValueListItems  track by camp.DataValue" Class="form-control"></select>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="col-md-3">
                                <Label Class="control-label">Current Working Day</Label>
                                <input type="text" ng-model="PartyInfo.OpenEwdCurrLM" class="form-control" />

                            </div>
                            <div class="col-md-3">
                                <label class="control-label">Last Working Day</label>
                                <input type="text" ng-model="PartyInfo.OpenEwdLastLM" class="form-control" />
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
                                            <td>Date</td>
                                            <td>perTDSNorm</td>
                                            <td>Other</td>
                                            <td>OTHourRate</td>
                                            <td>OTSalMultiple</td>
                                            <td>Skill</td>

                                            <td></td>


                                        </tr>








                                        <tr ng-repeat="row in EmpSal">
                                            <td><label>{{row.Dated}}</label></td>
                                            <td><label>{{row.perTDSNorm}}</label></td>
                                            <td><label>{{row.Other}}</label></td>
                                            <td><label>{{row.OTHourRate}}</label></td>
                                            <td><label>{{row.OTSalMult}}</label></td>
                                            <td><label>{{row.SkillText}}</label></td>

                                            <td><a href="" ng-click="efnc(row)">Edit</a></td>





                                        </tr>


                                    </table>
                                </div>
                            </div>

                        </div>







                        <div class="row cbackgroun">
                            <div class="col-md-1"></div>
                            <div class="col-md-10"><label class="control-label lbln">Benefits</label> <Button type="button" id="items" Class="btn btn-primary btnf" ng-click="commonDialog(PartyInfo.EmployeeID,'dialogc', 'Select Benefit','salbenefit')" style="margin-top:5px;margin-bottom:5px;float:right">ADD</Button></div>
                        </div>
                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="col-md-10">


                                <div class="table-responsive">
                                    <table class="table table-bordered table-striped space10">
                                        <tr class="tbld">
                                            <td>Benefit</td>
                                            <td>Benefit Number</td>
                                            <td>EEDate</td>
                                            <td>Remark</td>






                                        </tr>








                                        <tr ng-repeat="row in EmpSalBen">
                                            <td><select ng-model="row.SalBenefitIDSelected" disabled ng-options="campt.BenefitName for campt in EmpSalBenc  track by campt.SalBenefitID" Class="form-control"></select></td>
                                            <td><input type="text" ng-model="row.BenefitMemNum" class="form-control" /></td>
                                            <td><input type="text" ng-model="row.EEDate" class="form-control my-datepicker" /></td>
                                            <td><input type="text" ng-model="row.Remark" class="form-control" /></td>


                                        </tr>


                                    </table>
                                </div>
                            </div>

                        </div>

                    </div>
                </div>






            </div>

            <div id="dialogc"></div>
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
        rsApp.controller('FormController', function ($scope, $http) {
            $scope.model = JSON.parse($("#model_json").val());
            $scope.data = "This is data come from json";



            var loadmodel = function (result) {
                $scope.model = result;
                $scope.PartyInfo = $scope.model.dsForm.DT[0];
                $scope.Party = $scope.model.dsForm.party;
                $scope.dsCombo = $scope.model.dsCombo;
                //$scope.ValueLists = $scope.model.ValueLists;
                $scope.EmpSal = $scope.model.GridViews.EmpSal.MainGrid.myDS.Table;
                $scope.EmpSalBen = $scope.model.GridViews.EmpSalBen.MainGrid.myDS.dt;


                $scope.EmpSalBenc = $scope.model.GridViews.EmpSalBen.MainGrid.dsLookup.Table0;
                //$scope.Shiftinfo = $scope.model.GridViews.Shift.MainGrid.myDS.Table;


                //$scope.SalBen = $scope.model.GridViews.SalBen.MainGrid.myDS.Table;
                //$scope.AttTagMstr = $scope.model.GridViews.AttTagMstr.MainGrid.myDS.Table;
                $scope.ValueLists = $scope.model.ValueLists;
                $scope.GstNot = []; $scope.GstNotc = []; $scope.GstNotu = [];
                $scope.item = function () {
                    $scope.SalComp.push({});
                };
                $scope.delete = function (index) {
                    $scope.SalComp.splice(index, 1);
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
               @Html.RenderLookup("PartyInfo", Model, Model.dsForm.Tables(0));




                $scope.efnc = function (row) {

                    var base = '/App/Link' + location.search;
                    var payload = { fKey: 'frmEmpSalary', fMode: 'acEditM', IDX: row.employeeid, rowData: JSON.stringify(row) };
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
                $scope.cancel = function () {
                    $rootScope.modalInstance.dismiss('cancel');
                };

















                $scope.PartyInfo.PaymentThruCodeSelected = $.grep($scope.dsCombo.emp1, function (item, index) { return item.codeword == $scope.PartyInfo.PaymentThruCode })[0];;




                $scope.commonDialog = function (val, dialogName, dialogTitle, keyValue) {
                    
                    $scope.IsInitializing = true;
                    $scope.result = '';


                    var payload = { empid: $scope.PartyInfo.EmployeeID };


                    var url = '/frmEmp/ParamsModel' + location.search;
                    payload = JSON.stringify(payload);
                    var token = $('input[name="__RequestVerificationToken"]').val();
                    var payloaddata = { key: keyValue, Params: payload, __RequestVerificationToken: token };
                    igGridDataPostData(url, payloaddata, dialogName, dialogTitle, keyValue);
                };












                $scope.gridfxn = function (rowData, allData, keyValue) {
                    for (var i = 0; i < rowData.length; i++) {
                        var dataid;
                        dataid = $.grep(allData, function (item, index) { return item.ig_pk == rowData[i].id })[0];
                        var dataSalBen = { SalBenefitID: dataid.SalBenefitID}
                        $scope.EmpSalBen.push(dataSalBen);
                        $.each($scope.EmpSalBen, function (index, row) {
                            row.SalBenefitIDSelected = $.grep($scope.EmpSalBenc, function (item, index) { return item.SalBenefitID == row.SalBenefitID })[0];
                        });

                    }

                }




                $.each($scope.EmpSalBen, function (index, row) {
                    row.SalBenefitIDSelected = $.grep($scope.EmpSalBenc, function (item, index) { return item.SalBenefitID == row.SalBenefitID })[0];
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