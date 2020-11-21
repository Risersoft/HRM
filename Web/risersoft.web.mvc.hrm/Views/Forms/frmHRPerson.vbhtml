
@imports risersoft.shared.cloud.common
@imports risersoft.app.mxform.hrm
@imports Newtonsoft.Json
@imports risersoft.shared.web.Extensions
@ModelType frmHRPersonModel
@Code
    ViewData("Title") = "HR Person"
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
                <div class="col-md-8"><label class="control-label lbln">Person</label></div>
            </div>


            <div Class="row" style="margin-top:40px;">
                <div Class="col-md-1"></div>
                <div Class="col-md-5">
                    <Label Class="control-label labeltext">FirstName <span class="red">*</span></Label>
                    <input type="text" name="cfirst" ng-model="PartyInfo.FirstName" style="max-width: 340px;" class="form-control" required ng-class="{true: 'error'}[submitted() && userform.cfirst.$invalid]" />
                </div>
                <div Class="col-md-5">
                    <Label Class="control-label labeltext">MidName</Label>
                    <input type="text" ng-model="PartyInfo.MidName" style="max-width: 340px;" class="form-control" />
                </div>

            </div>
            <div Class="row" style="margin-bottom:40px">
                <div Class="col-md-1"></div>
                <div Class="col-md-5">
                    <Label Class="control-label labeltext">LastName</Label>
                    <input type="text" ng-model="PartyInfo.LastName" style="max-width: 340px;" class="form-control" />
                </div>
                <div Class="col-md-5">
                    <Label Class="control-label labeltext">Sal</Label>
                    <input type="text" ng-model="PartyInfo.Salutation" style="max-width: 340px;" class="form-control" />
                </div>

            </div>
            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Basic</label></div>
            </div>




            <div ng-show="frmMode==2">
                <div Class="row">
                    <div Class="col-md-1"></div>
                    <div Class="col-md-3">
                        <Label Class="control-label labeltext">Code <span class="red">*</span></Label>
                        <input type="text" name="matn" ng-model="ListEmprow.EmpCode" style="max-width: 340px;" class="form-control" required ng-class="{true: 'error'}[submitted() && userform.matn.$invalid]" />
                    </div>
                    <div Class="col-md-3">
                        <Label Class="control-label labeltext">Join Date <span class="red">*</span></Label>
                        <input type="text" name="datco" ng-model="ListEmprow.JoinDate" style="max-width: 340px;" class="form-control my-datepicker" required ng-class="{true: 'error'}[submitted() && userform.datco.$invalid]"/>
                    </div>




                    <div Class="col-md-3">
                        <Label Class="control-label labeltext">Department <span class="red">*</span></Label>
                        <select name="deptco" ng-model="ListEmprow.depidSelected" ng-options="itemco.depname for itemco in dsCombo.dep track by itemco.depid" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.deptco.$invalid]"></select>
                    </div>
                </div>
                <div Class="row">
                    <div Class="col-md-1"></div>
                    <div Class="col-md-3">
                        <Label Class="control-label labeltext">Campus <span class="red">*</span></Label>
                        <select name="ctwyn" ng-model="ListEmprow.campusidSelected" ng-options="itemyc.dispname for itemyc in dsCombo.campus track by itemyc.campusid" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.ctwyn.$invalid]"></select>
                    </div>
                    <div Class="col-md-3">
                        <Label Class="control-label labeltext">Shift <span class="red">*</span></Label>
                        <select name="cftyn" ng-model="ListEmprow.shiftidSelected" ng-options="itemc.shift for itemc in dsCombo.shift track by itemc.shiftid" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.cftyn.$invalid]"></select>
                    </div>
                    <div Class="col-md-3">
                        <Label Class="control-label labeltext">Nature</Label>
                        <select name="country" ng-model="ListEmprow.NatureSelected" ng-options="itemcw.DisplayText for itemcw in ValueLists.Tnvc.ValueListItems track by itemcw.DataValue" Class="form-control"></select>
                    </div>
                </div>
            </div>
            <div ng-show="frmMode==1">
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
                                <tr ng-repeat="row in ListEmp">
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
            </div>


            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Address</label></div>
            </div>











            <div Class="row">
                <div Class="col-md-1"></div>
                <div Class="col-md-1">
                    <Label Class="control-label labeltext">OfficePhone</Label>
                    <input type="text" ng-model="PartyInfo.OfficeCountry" Class="form-control" />
                </div>
                <div Class="col-md-1">
                    <Label Class="control-label labeltext"> </Label>
                    <input type="text" ng-model="PartyInfo.OfficeArea" style="margin-top: 7px;" Class="form-control" />
                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext"> </Label>
                    <input type="text" ng-model="PartyInfo.OfficePhone" style="max-width: 340px;margin-top: 7px;" Class="form-control" />
                </div>


                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Mobile</Label>
                    <input type="text" ng-model="PartyInfo.CellNum" Class="form-control" />
                </div>
            </div>
            <div Class="row">
                <div Class="col-md-1"></div>

                <div Class="col-md-5">
                    <Label Class="control-label labeltext">Email </Label>
                    <input type="text" ng-model="PartyInfo.Email" style="max-width:430px;" Class="form-control" />
                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Home Page</Label>
                    <input type="text" ng-model="PartyInfo.Web" Class="form-control" />
                </div>



            </div>


            <div class="row" style="margin-top:17px; margin-bottom:15px;">
                <div class="col-md-1"></div>
                <div Class="col-md-6"><label class="control-label" style="text-decoration:underline;">Present Address</label></div>

            </div>
            <div Class="row">
                <div Class="col-md-1"></div>
                <div Class="col-md-10">
                    <Label Class="control-label labeltext">Address </Label>
                    <input type="text" ng-model="PartyInfo.PrAddress" style="max-width: 796px;" class="form-control" />
                </div>

            </div>
            <div Class="row">
                <div Class="col-md-1"></div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Country </Label>




                    <select name="country" ng-model="PartyInfo.PrCountrySelected" ng-options="itemcoun.country for itemcoun in dsCombo.CO track by itemcoun.country" ng-change="changestate(PartyInfo.PrCountrySelected)" Class="form-control"></select>
                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">State</Label>
                    <select ng-model="PartyInfo.PrStateSelected" ng-options="itemsu.SubDivisionName for itemsu in State track by itemsu.SubDivisionCode" Class="form-control"></select>
                </div>






                <div Class="col-md-3">
                    <Label Class="control-label labeltext">City</Label>
                    <input type="text" ng-model="PartyInfo.PrCity" Class="form-control" />
                </div>


            </div>
            <div Class="row">
                <div Class="col-md-1"></div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Pincode </Label>
                    <input type="text" ng-model="PartyInfo.PrPinCode" Class="form-control" />
                </div>

                <div Class="col-md-1">
                    <Label Class="control-label labeltext">Ph No. </Label>
                    <input type="text" ng-model="PartyInfo.PrPhCountry" Class="form-control" />
                </div>
                <div Class="col-md-1">
                    <Label Class="control-label labeltext"> </Label>
                    <input type="text" ng-model="PartyInfo.PrPhArea" style="margin-top: 7px;" Class="form-control" />
                </div>
                <div Class="col-md-4">
                    <Label Class="control-label labeltext"> </Label>
                    <input type="text" ng-model="PartyInfo.PrPhone" style="max-width: 340px;margin-top: 7px;" Class="form-control" />
                </div>
            </div>
            <div Class="row">
                <div Class="col-md-1"></div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Geo Point </Label>
                    <input type="text" ng-model="PartyInfo.PrGeoPoint" Class="form-control" />
                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext"> </Label>
                    <input type="button" style="margin-top: 34px;" Class="btn btn-primary" value="Lookup" />
                </div>
            </div>




            <div class="row" style="margin-top:17px; margin-bottom:15px;">
                <div class="col-md-1"></div>
                <div Class="col-md-6"><label class="control-label" style="text-decoration:underline;">Permanent Address</label></div>

            </div>
            <div Class="row">
                <div Class="col-md-1"></div>
                <div Class="col-md-10">
                    <Label Class="control-label labeltext">Address </Label>
                    <input type="text" ng-model="PartyInfo.PmAddress" style="max-width: 796px;" class="form-control" />
                </div>

            </div>
            <div Class="row">
                <div Class="col-md-1"></div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Country </Label>




                    <select name="country" ng-model="PartyInfo.PmCountrySelected" ng-options="itemcoun.country for itemcoun in dsCombo.CO track by itemcoun.country" ng-change="changestate(PartyInfo.PmCountrySelected)" Class="form-control"></select>
                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">State</Label>
                    <select ng-model="PartyInfo.PmStateSelected" ng-options="itemo.SubDivisionName for itemo in State track by itemo.SubDivisionCode" Class="form-control"></select>
                </div>






                <div Class="col-md-3">
                    <Label Class="control-label labeltext">City</Label>
                    <input type="text" ng-model="PartyInfo.PmCity" Class="form-control" />
                </div>
            </div>


            <div Class="row">
                <div Class="col-md-1"></div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Pincode </Label>
                    <input type="text" ng-model="PartyInfo.PmPinCode" Class="form-control" />
                </div>

                <div Class="col-md-1">
                    <Label Class="control-label labeltext">Ph No. </Label>
                    <input type="text" ng-model="PartyInfo.PmPhCountry" Class="form-control" />
                </div>
                <div Class="col-md-1">
                    <Label Class="control-label labeltext"> </Label>
                    <input type="text" ng-model="PartyInfo.PmPhArea" style="margin-top: 7px;" Class="form-control" />
                </div>
                <div Class="col-md-4">
                    <Label Class="control-label labeltext"> </Label>
                    <input type="text" ng-model="PartyInfo.PmPhone" style="max-width: 340px;margin-top: 7px;" Class="form-control" />
                </div>
            </div>







            <div Class="row">
                <div Class="col-md-1"></div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Geo Point </Label>
                    <input type="text" ng-model="PartyInfo.PmGeoPoint" Class="form-control" />
                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext"> </Label>
                    <input type="button" style="margin-top: 34px;" Class="btn btn-primary" value="Lookup" />
                </div>
            </div>

            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Info</label></div>
            </div>










            <div Class="row">
                <div Class="col-md-1"></div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Gender <span class="red">*</span></Label>
                    <select ng-model="PartyInfo.IsFemaleSelected" name="categoryc" ng-options="itemt.DisplayText for itemt in ValueLists.IsFemale.ValueListItems track by itemt.DataValue" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.categoryc.$invalid]"></select>




                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Marital Status</Label>
                    <select ng-model="PartyInfo.MarStatusSelected" ng-options="itemt.DisplayText for itemt in ValueLists.MarStatus.ValueListItems track by itemt.DataValue" Class="form-control"></select>
                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Top Qualification</Label>
                    <select ng-model="PartyInfo.TopQualSelected" ng-options="itemt.DisplayText for itemt in ValueLists.TopQual.ValueListItems track by itemt.DataValue" Class="form-control"></select>
                </div>

            </div>
            <div Class="row">
                <div Class="col-md-1"></div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Display Name </Label>
                    <input type="text" ng-model="PartyInfo.NickName" class="form-control" />
                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Birthday</Label>
                    <input type="text" ng-model="PartyInfo.Birthday" class="form-control my-datepicker" />
                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Anniversery</Label>





                    <input type="text" ng-model="PartyInfo.Anniversary" class="form-control my-datepicker" />
                </div>



            </div>
            <div Class="row">
                <div Class="col-md-1"></div>
                <div Class="col-md-10">
                    <Label Class="control-label labeltext">Education </Label>
                    <input type="text" ng-model="PartyInfo.Education" style="max-width: 796px;" class="form-control" />
                </div>

            </div>
            <div Class="row">
                <div Class="col-md-1"></div>
                <div Class="col-md-10">
                    <Label Class="control-label labeltext">Profile </Label>
                    <input type="text" ng-model="PartyInfo.Profile" style="max-width: 796px;" class="form-control" />
                </div>

            </div>
            <div Class="row">
                <div Class="col-md-1"></div>
                <div Class="col-md-10">
                    <Label Class="control-label labeltext">Remark </Label>
                    <input type="text" ng-model="PartyInfo.Remark" style="max-width: 796px;" class="form-control" />
                </div>

            </div>



            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-10"><label class="control-label lbln">Education</label> <Button type="button" id="items" Class="btn btn-primary btnf" ng-click="item()" style="margin-top:5px;margin-bottom:5px; float:right">ADD</Button></div>
            </div>










            <div ng-repeat="row in Edu">
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">

                        <label class="control-label labeltext">Qualification</label>
                        <input type="text" ng-model="row.Qualification" class="form-control" />
                    </div>


                    <div class="col-md-3">
                        <label class="control-label labeltext">Institution </label>
                        <input type="text" ng-model="row.Institution" class="form-control" />
                    </div>






                    <div class="col-md-3">
                        <label class="control-label labeltext">YearQual</label>
                        <input type="text" ng-model="row.YearQual" class="form-control" />
                    </div>










                </div>



                <div class="row">
                    <div class="col-md-1"></div>






                    <div class="col-md-3"><label class="control-label labeltext">Marks </label> <input type="text" ng-model="row.Marks" class="form-control" /></div>
                    <div class="col-md-1">
                        <a href="" class="delete" style="z-index:35;position:relative;margin-top:38px;float:right" ng-click="delete($index)"><span class="fa fa-trash" style="color: #d83e3b;"></span></a>
                    </div>
                </div>

                <div class="row"><hr /></div>
            </div>


            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-10"><label class="control-label lbln">Family</label>  <Button type="button" id="items" Class="btn btn-primary btnf" ng-click="itemn()" style="margin-top:5px;margin-bottom:5px;float:right">ADD</Button></div>


            </div>




            <div ng-repeat="rown in Fam">
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">

                        <label class="control-label labeltext">MemberName </label>
                        <input type="text" ng-model="rown.MemberName" class="form-control" />
                    </div>


                    <div class="col-md-3">
                        <label class="control-label labeltext">Relation </label><input type="text" ng-model="rown.Relation" class="form-control" />
                    </div>






                    <div class="col-md-3">
                        <label class="control-label labeltext">BDate </label>
                        <input type="text" ng-model="rown.BDate" class="form-control my-datepicker" />
                    </div>










                </div>



                <div class="row">
                    <div class="col-md-1"></div>






                    <div class="col-md-3"><label class="control-label labeltext">Profession </label> <input type="text" ng-model="rown.Profession" class="form-control" /></div>
                    <div class="col-md-3"><label class="control-label labeltext">Other </label> <input type="text" ng-model="rown.Other" class="form-control" /></div>
                    <div class="col-md-1">
                        <a href="" class="delete" style="z-index:35;position:relative;margin-top:38px;float:right" ng-click="deleten($index)"><span class="fa fa-trash" style="color: #d83e3b;"></span></a>
                    </div>
                </div>

                <div class="row"><hr /></div>
            </div>
            <div class="row cbackgroun" style="margin-bottom:40px">
                <div class="col-md-1"></div>
                <div class="col-md-10"><label class="control-label lbln">Experience</label>   <Button type="button" id="items" Class="btn btn-primary btnf" ng-click="itemcn()" style="margin-top:5px;margin-bottom:5px;float:right">ADD</Button></div>
            </div>





            <div ng-repeat="rowc in Exp">
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">

                        <label class="control-label labeltext">EstabName </label>
                        <input type="text" ng-model="rowc.EstabName" class="form-control" />
                    </div>


                    <div class="col-md-3">
                        <label class="control-label labeltext">Designation </label><input type="text" ng-model="rowc.Designation" class="form-control" />
                    </div>






                    <div class="col-md-3">
                        <label class="control-label labeltext">PeriodService </label>
                        <input type="text" ng-model="rowc.PeriodService" class="form-control" />
                    </div>










                </div>



                <div class="row">
                    <div class="col-md-1"></div>






                    <div class="col-md-3"><label class="control-label labeltext">ExpInMonths </label> <input type="text" ng-model="rowc.ExpInMonths" class="form-control" /></div>
                    <div class="col-md-3"><label class="control-label labeltext">MonthlyPay </label> <input type="text" ng-model="rowc.MonthlyPay" class="form-control" /></div>
                    <div class="col-md-3"><label class="control-label labeltext">ReasonLeft </label> <input type="text" ng-model="rowc.ReasonLeft" class="form-control" /></div>
                    <div class="col-md-1">
                        <a href="" class="delete" style="z-index:35;position:relative;margin-top:38px;float:right" ng-click="deletecn($index)"><span class="fa fa-trash" style="color: #d83e3b;"></span></a>
                    </div>
                </div>

                <div class="row"><hr /></div>
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
                $scope.PartyInfo = $scope.model.dsForm.DT[0];
                $scope.frmMode = $scope.model.frmMode;


                $scope.Party = $scope.model.dsForm.party;
                $scope.dsCombo = $scope.model.dsCombo;
                $scope.ValueLists = $scope.model.ValueLists;





                $scope.Edu = $scope.model.GridViews.Edu.MainGrid.myDS.dt;
                $scope.Fam = $scope.model.GridViews.Fam.MainGrid.myDS.dt;
                $scope.ListEmprow = {}


                $scope.Exp = $scope.model.GridViews.Exp.MainGrid.myDS.dt;
                //$scope.valuebag = $scope.model.pViewState.ContextRow.valuebag;
                $scope.ListEmp = $scope.model.GridViews.ListEmp.MainGrid.myDS.Table;
                $scope.ListEmpdata = $scope.model.GridViews.ListEmp.MainGrid.myDS.Table[0];
                @Html.RenderLookup("PartyInfo", Model, Model.dsForm.Tables(0));
                $scope.PartyInfo.PrCountrySelected = $.grep($scope.dsCombo.CO, function (item, index) { return item.countrycode === $scope.PartyInfo.PrCountryCode })[0];
                $scope.PartyInfo.PmCountrySelected = $.grep($scope.dsCombo.CO, function (item, index) { return item.countrycode === $scope.PartyInfo.PmCountryCode })[0];
                $scope.PartyInfo.PrStateSelected = $.grep($scope.dsCombo.SU, function (item, index) { return item.SubDivisionCode === $scope.PartyInfo.PrStateCode })[0];
                $scope.PartyInfo.PmStateSelected = $.grep($scope.dsCombo.SU, function (item, index) { return item.SubDivisionCode === $scope.PartyInfo.PmStateCode })[0];;
                if ($scope.frmMode == 1) {
                    $scope.ListEmprow.depidSelected = $.grep($scope.dsCombo.dep, function (item, index) { return item.depid === $scope.ListEmpdata.DepId })[0];
                    $scope.ListEmprow.campusidSelected = $.grep($scope.dsCombo.campus, function (item, index) { return item.campusid === $scope.ListEmpdata.Campusid })[0];
                    $scope.ListEmprow.shiftidSelected = $.grep($scope.dsCombo.shift, function (item, index) { return item.shiftid === $scope.ListEmpdata.ShiftId })[0];



                    $scope.ListEmprow.NatureSelected = $.grep($scope.ValueLists.Tnvc.ValueListItems, function (item, index) { return item.DataValue === $scope.ListEmpdata.Nature })[0];

                }


                    $scope.item = function () {
                    $scope.Edu.push({});
                };
                $scope.delete = function (index) {
                    $scope.Edu.splice(index, 1);
                };

                $scope.itemn = function () {
                    $scope.Fam.push({});
                };



                $scope.deleten = function (index) {
                    $scope.Fam.splice(index, 1);
                };
                $scope.itemcn = function () {
                    $scope.Exp.push({});
                };

                $scope.deletecn = function (index) {
                    $scope.Exp.splice(index, 1);
                };



                $scope.PartyInfo.TopQualSelected = $.grep($scope.ValueLists.TopQual.ValueListItems, function (item, index) { return item.DataValue === $scope.PartyInfo.TopQual })[0];


                $scope.PartyInfo.IsFemaleSelected = $.grep($scope.ValueLists.IsFemale.ValueListItems, function (item, index) { return item.DataValue === $scope.PartyInfo.IsFemale })[0];
                $scope.PartyInfo.MarStatusSelected = $.grep($scope.ValueLists.MarStatus.ValueListItems, function (item, index) { return item.DataValue === $scope.PartyInfo.MarStatus })[0];




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




                $scope.efnc = function (row) {

                    var base = '/App/Link' + location.search;
                    var payload = { fKey: 'frmEmp', fMode: 'acEditM', IDX: row.employeeid, rowData: JSON.stringify(row) };
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
                $scope.changestate($scope.PartyInfo.PrCountrySelected);
                $scope.changestate($scope.PartyInfo.PmCountrySelected);
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
            if ($scope.frmMode == 2) {
                $scope.model.GridViews.ListEmp.MainGrid.myDS.Table.push($scope.ListEmprow);


            }
            };



        $scope.visdel = false; $scope.visdelete = false;
        @Html.RenderFile("~/scripts/rsforms.js")
            });

    </script>
End Section

