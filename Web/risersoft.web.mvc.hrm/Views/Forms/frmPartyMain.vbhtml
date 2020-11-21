
@imports risersoft.shared.cloud.common
@imports risersoft.app.mxform
@imports Newtonsoft.Json
@imports risersoft.shared.web.Extensions
@ModelType frmPartyMainModel
@Code
    ViewData("Title") = "Party Main"
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
                <div class="col-md-8"><label class="control-label lbln">Party</label></div>
            </div>


            <div class="row" style="margin-top:17px; margin-bottom:15px;">
                <div class="col-md-1"></div>
                <div Class="col-md-6"><label class="control-label" style="text-decoration:underline;">Head Office </label></div>

            </div>
            <div Class="row">


                <div Class="col-md-1"></div>
                <div Class="col-md-10">
                    <Label Class="control-label labeltext">Address <span class="red">*</span></Label>
                    <input name="cadd" type="text" ng-model="CompanyInfo.Address" Class="form-control" style="max-width: 647px;" required ng-class="{true: 'error'}[submitted() && userform.cadd.$invalid]" />

                </div>




            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div Class="col-md-4">
                    <Label Class="control-label labeltext">City <span class="red">*</span></Label>
                    <input name="city" type="text" ng-model="CompanyInfo.City" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.city.$invalid]" />
                </div>
                <div class="col-md-6">
                    <Label Class="control-label labeltext">PinCode <span class="red">*</span></Label>
                    <input name="pcode" type="text" ng-model="CompanyInfo.Pincode" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.pcode.$invalid]" />
                </div>
            </div>
            <div Class="row">


                <div Class="col-md-1"></div>
                <div Class="col-md-4">
                    <Label Class="control-label labeltext">Country <span class="red">*</span></Label>
                    <select name="country" ng-model="CompanyInfo.CountrySelected" ng-options="itemcoun.country for itemcoun in dsCombo.CO track by itemcoun.country" ng-change="changestate(CompanyInfo.CountrySelected)" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.country.$invalid]"></select>


                </div>
                <div Class="col-md-6">
                    <Label Class="control-label labeltext">State <span class="red">*</span></Label>
                    <select name="state" ng-model="CompanyInfo.StateSelected" ng-options="itemsu.SubDivisionName for itemsu in State track by itemsu.SubDivisionName" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.state.$invalid]"></select>

                </div>

                <div Class="col-md-3">
                    <Label Class="control-label labeltext"></Label>

                </div>
            </div>









            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-2">
                    <label class="control-label labeltext">Ph No.</label>
                    <input type="text" ng-model="CompanyInfo.PhCountry" class="form-control" />
                </div>
                <div class="col-md-2">
                    <label class="control-label">&nbsp;</label>
                    <input type="text" ng-model="CompanyInfo.PhArea" class="form-control" />
                </div>
                <div class="col-md-6">
                    <label class="control-label">&nbsp;</label>
                    <input type="text" ng-model="CompanyInfo.Phnum" class="form-control" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-2">
                    <label class="control-label labeltext">Fax No.</label>
                    <input type="text" ng-model="CompanyInfo.FaxCountry" class="form-control" />
                </div>
                <div class="col-md-2">
                    <label class="control-label">&nbsp;</label>
                    <input type="text" ng-model="CompanyInfo.FaxArea" class="form-control" />
                </div>
                <div class="col-md-6">
                    <label class="control-label">&nbsp;</label>
                    <input type="text" ng-model="CompanyInfo.Faxnum" class="form-control" />
                </div>
            </div>





            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-4">
                    <label class="control-label labeltext">Email</label>
                    <input type="text" ng-model="CompanyInfo.Email" style="max-width: 647px;" class="form-control" />
                </div>
                <div class="col-md-6">
                    <label class="control-label labeltext">Web</label>
                    <input type="text" ng-model="CompanyInfo.Web" class="form-control" />
                </div>
            </div>





            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Info</label></div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">

                    <label class="control-label labeltext">Name<span class="red">*</span></label>
                    <input type="text" ng-model="CompanyInfo.MPName" class="form-control" />
                </div>







                <div class="col-md-3">
                    <label class="control-label labeltext">Nick</label><input type="text" ng-model="CompanyInfo.MPNick" readonly class="form-control my-datepicker" />
                </div>






                <div class="col-md-3">
                    <label class="control-label labeltext">Turnover</label>
                    <input type="text" ng-model="CompanyInfo.Turnover" class="form-control" />
                </div>

            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">

                    <label class="control-label labeltext">No. of employees</label>
                    <input type="text" ng-model="CompanyInfo.NumEmp" class="form-control" />
                </div>







                <div class="col-md-3">
                    <label class="control-label labeltext">Area</label>  <input type="text" ng-model="CompanyInfo.Area" class="form-control" />
                </div>






                <div class="col-md-3">
                    <label class="control-label labeltext">Description</label>
                    <input type="text" ng-model="CompanyInfo.Description" class="form-control" />
                </div>

            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">

                    <label class="control-label labeltext">Ownership</label>






                    <select ng-model="row.CampusSelected" ng-options="itemt.DispName for itemt in Campus track by itemt.CampusID" Class="form-control"></select>
                </div>







                <div class="col-md-3">
                    <label class="control-label labeltext">Predefined </label>  <input type="text" ng-model="CompanyInfo.MenDaysWorked" class="form-control" />
                </div>






                <div class="col-md-3">
                    <label class="control-label labeltext">Other</label>
                    <input type="text" ng-model="CompanyInfo.SegmentOther" class="form-control" />
                </div>

            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">

                    <label class="control-label labeltext">Remark</label>
                    <input type="text" ng-model="CompanyInfo.Remark" class="form-control" />
                </div>
                <div class="col-md-3">
                    <label class="control-label labeltext">Type</label>
                    <input type="text" ng-model="CompanyInfo.PartyType" readonly class="form-control" />
                </div>
                <div class="col-md-3">
                    <label class="control-label labeltext">Sub Type</label>
                    <input type="text" ng-model="CompanyInfo.PartySubType" readonly class="form-control" />
                </div>















            </div>




            <div class="row">
                <div class="col-md-1"></div>


                <div style="margin-top: 15px;" class="col-md-3">
                    <Label Class="control-label"> </Label>
                    Dealer          <input type="checkbox" ng-model="CompanyInfo.IsDealer" /><br />
                    EPC        <input type="checkbox" ng-model="CompanyInfo.IsEPC" /><br />
                    End User         <input type="checkbox" ng-model="CompanyInfo.IsEndUser" /><br />

                </div>
                <div style="margin-top: 15px;" class="col-md-3">
                    <Label Class="control-label"> </Label>
                    Consultant        <input type="checkbox" ng-model="CompanyInfo.IsConsultant" /><br />
                    Contractor                    <input type="checkbox" ng-model="CompanyInfo.IsContractor" /><br />
                    Inspection Agency        <input type="checkbox" ng-model="CompanyInfo.IsInspAgency" /><br />

                </div>
                <div style="margin-top: 15px;" class="col-md-3">
                    <Label Class="control-label"> </Label>
                    Trader               <input type="checkbox" ng-model="CompanyInfo.IsTrader" /><br />
                    Competitor             <input type="checkbox" ng-model="CompanyInfo.IsCompetitor" /><br />


                </div>
            </div>

            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-10"><label class="control-label lbln">Selectable Parties</label>  <Button type="button" id="items" Class="btn btn-primary btnf" ng-click="item()" style="margin-top:5px;margin-bottom:5px; float:right">ADD</Button></div>
            </div>










            <div Class="form-horizontal" ng-repeat="row in party">

                <div class="row"></div>
                <div Class="row" style="margin-top: 40px;">


                    <div Class="col-md-1"></div>
                    <div Class="col-md-3">
                        <Label Class="control-label labeltext">Code </Label>
                        <input type="text" ng-model="row.PartyCode" style="max-width: 540px;" readonly class="form-control" />
                    </div>

                    <div class="col-md-3">
                        <Label Class="control-label labeltext">GSTReg Type</Label>


                        <select ng-model="row.GSTRegTypeSelected" ng-options="itemc.descriptot for itemc in dsCombo.GSTRegType track by itemc.codeword" style="max-width: 634px" Class="form-control"></select>
                    </div>
                    <div Class="col-md-3">
                        <Label Class="control-label labeltext">GST No. </Label>
                        <input name="disname" type="text" ng-model="row.GSTIN" style="max-width: 540px;" class="form-control" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <Label Class="control-label labeltext">Valuation Class</Label>
                        <input name="panno" type="text" ng-model="row.PANNum" style="max-width: 540px;" class="form-control" />
                    </div>
                    <div class="col-md-3">
                        <Label Class="control-label labeltext">Branch</Label>
                        <input name="panno" type="text" ng-model="row.Division" style="max-width: 540px;" class="form-control" />
                    </div>
                    <div class="col-md-3">
                        <Label Class="control-label labeltext">City</Label>
                        <input name="panno" type="text" ng-model="row.SelCity" style="max-width: 540px;" class="form-control" />
                    </div>
                </div>

















                <div class="" style="padding:15px;">



                    <div>



                        <div class="col-md-1"></div>
                        <div class="" style="margin-top:15px">
                            <ul class="nav nav-tabs">
                                <li class="labeltext"><a href="#tabc" class="nav-link active labeltext" data-toggle="tab">Address</a></li>
                                <li class="labeltext"><a href="#tabw" class="nav-link labeltext" data-toggle="tab">Statutory</a></li>
                                <li class="labeltext"><a href="#tabn" class="nav-link labeltext" data-toggle="tab">Commerical</a></li>
                                <li class="labeltext"><a href="#taby" class="nav-link  labeltext" data-toggle="tab">Vendor</a></li>
                            </ul>
                            <div class="tab-content">
                                <div class="tab-pane active" id="tabc">
                                    <div Class="row">


                                        <div Class="col-md-1"></div>
                                        <div Class="col-md-4">
                                            <Label Class="control-label">Address</Label>
                                            <input type="text" ng-model="row.SelAddress" Class="form-control" style="max-width: 634px" />

                                        </div>
                                        <div class="col-md-6">
                                            <Label Class="control-label">PinCode</Label>
                                            <input type="text" ng-model="row.SelPinCode" Class="form-control" />
                                        </div>



                                    </div>






                                    <div Class="row">


                                        <div Class="col-md-1"></div>
                                        <div Class="col-md-4">
                                            <Label Class="control-label">Country</Label>
                                            <select ng-model="row.CountrySelected" ng-options="itemcoun.country for itemcoun in dsCombo.CO track by itemcoun.country" ng-change="changestate(row.CountrySelected)" style="max-width: 634px" Class="form-control"></select>


                                        </div>
                                        <div Class="col-md-6">
                                            <Label Class="control-label">State</Label>
                                            <select ng-model="row.StateSelected" ng-options="itemsu.SubDivisionName for itemsu in State track by itemsu.SubDivisionName" Class="form-control"></select>

                                        </div>


                                    </div>
                                    <div class="row">
                                        <div class="col-md-1"></div>
                                        <div class="col-md-2">
                                            <label class="control-label">Ph No.</label>
                                            <input type="text" ng-model="row.SelPhCountry" class="form-control" />
                                        </div>
                                        <div class="col-md-2">
                                            <label class="control-label">&nbsp;</label>
                                            <input type="text" ng-model="row.SelPhArea" class="form-control" />
                                        </div>
                                        <div class="col-md-6">
                                            <label class="control-label">&nbsp;</label>
                                            <input type="text" ng-model="row.SelPhNum" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-1"></div>
                                        <div class="col-md-2">
                                            <label class="control-label">Fax No.</label>
                                            <input type="text" ng-model="row.SelFaxCountry" class="form-control" />
                                        </div>
                                        <div class="col-md-2">
                                            <label class="control-label">&nbsp;</label>
                                            <input type="text" ng-model="row.SelFaxArea" class="form-control" />
                                        </div>
                                        <div class="col-md-6">
                                            <label class="control-label">&nbsp;</label>
                                            <input type="text" ng-model="row.SelFaxNum" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-1"></div>
                                        <div class="col-md-4">
                                            <label class="control-label">Email</label>
                                            <input type="text" ng-model="row.SelEmail" class="form-control" />
                                        </div>
                                        <div class="col-md-6">
                                            <label class="control-label">Web</label>
                                            <input type="text" ng-model="row.SelWeb" class="form-control" />
                                        </div>
                                    </div>



                                </div>




                                <div class="tab-pane" id="tabw">
                                    <div class="row">
                                        <div class="col-md-1"></div>
                                        <div class="col-md-3">
                                            <label class="control-label">PAN No.</label>
                                            <input type="text" ng-model="row.PANNum" class="form-control" />
                                        </div>
                                        <div class="col-md-3">
                                            <label class="control-label">Tax Area Code</label>
                                            <select ng-model="row.TaxAreaIDSelected" ng-options="itemt.Descrip for itemt in dsCombo.TaxAreaCode track by itemt.TaxAreaID" Class="form-control"></select>
                                        </div>
                                        <div class="col-md-3">
                                            <label class="control-label">TIN No.</label>
                                            <input type="text" ng-model="row.TINNum" class="form-control" />
                                        </div>


                                    </div>
                                    <div class="row">
                                        <div class="col-md-1"></div>
                                        <div class="col-md-3">

                                            <Label Class="control-label">Sales Tax No.</Label>
                                            <input type="text" ng-model="row.stnum" Class="form-control" />


                                        </div>
                                        <div class="col-md-3">

                                            <Label Class="control-label">CST No.</Label>
                                            <input type="text" ng-model="row.cstnum" Class="form-control" />


                                        </div>
                                        <div class="col-md-3">

                                            <Label Class="control-label">Excise No.</Label>
                                            <input type="text" ng-model="row.ECCNum" Class="form-control" />


                                        </div>


                                    </div>
                                    <div class="row">
                                        <div class="col-md-1"></div>
                                        <div class="col-md-3">
                                            <label class="control-label">ECC Range</label>
                                            <input type="text" ng-model="row.ECCRange" class="form-control" />
                                        </div>
                                        <div class="col-md-3">
                                            <label class="control-label">ECC Division</label>
                                            <input type="text" ng-model="row.ECCDiv" class="form-control" />
                                        </div>
                                        <div class="col-md-3">
                                            <label class="control-label">MSME Status</label>
                                            <select ng-model="row.MSMEStatusSelected" ng-options="itemc.descriptot for itemc in dsCombo.MSME track by itemc.codeword" Class="form-control"></select>
                                        </div>


                                    </div>




                                </div>
                                <div class="tab-pane" id="tabn">
                                    <div class="row">
                                        <div class="col-md-1"></div>
                                        <div class="col-md-3">
                                            <label class="control-label">Shipment</label>
                                            <input type="text" ng-model="row.Shipterms" class="form-control" />
                                        </div>
                                        <div class="col-md-3">
                                            <label class="control-label">Terms Of Payment</label>
                                            <input type="text" ng-model="row.Payterms" class="form-control" />
                                        </div>
                                        <div class="col-md-3">
                                            <label class="control-label">Mode Of Transport</label>
                                            <input type="text" ng-model="row.Transmode" class="form-control" />
                                        </div>


                                    </div>
                                    <div class="row">
                                        <div class="col-md-1"></div>
                                        <div class="col-md-3">
                                            <label class="control-label">Insurance</label>
                                            <input type="text" ng-model="row.Insurance" class="form-control" />
                                        </div>
                                        <div class="col-md-3">
                                            <label class="control-label">Discount</label>
                                            <input type="text" ng-model="row.Discount" class="form-control" />
                                        </div>
                                        <div class="col-md-3">
                                            <label class="control-label">Freight</label>
                                            <input type="text" ng-model="row.Freight" class="form-control" />
                                        </div>


                                    </div>
                                    <div class="row">
                                        <div class="col-md-1"></div>
                                        <div class="col-md-3">
                                            <label class="control-label">Excise</label>
                                            <input type="text" ng-model="row.Excise" class="form-control" />
                                        </div>
                                        <div class="col-md-3">
                                            <label class="control-label">Sales Tax</label>
                                            <input type="text" ng-model="row.SalesTax" class="form-control" />
                                        </div>



                                    </div>
                                </div>
                                <div class="tab-pane" id="taby">

                                    <div class="row">
                                        <div class="col-md-1"></div>
                                        <div Class="col-md-3">
                                            <Label Class="control-label">Contract Started From</Label>
                                            <input type="text" ng-model="row.HRContractStart" Class="form-control my-datepicker" />
                                        </div>
                                        <div class="col-md-3">
                                            <Label Class="control-label">Contract Ended On</Label>
                                            <input type="text" ng-model="row.HRContractEnd" Class="form-control my-datepicker" />
                                        </div>
                                        <div Class="col-md-3">
                                            <Label Class="control-label">Nature of Work</Label>
                                            <input type="text" ng-model="row.WorkNature" Class="form-control" />
                                        </div>
                                    </div>





                                    <div Class="row">


                                        <div Class="col-md-1"></div>
                                        <div Class="col-md-3">
                                            <Label Class="control-label">% Service Charges</Label>
                                            <input type="text" ng-model="row.HRContractSvcChgPer" Class="form-control" />


                                        </div>



                                    </div>






                                </div>
                            </div>
                        </div>


                    </div>







                </div>












                <hr>
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



                $scope.CompanyInfo = $scope.model.dsForm.DT[0];


                $scope.party = $scope.model.dsForm.party;



                $scope.dsCombo = $scope.model.dsCombo;
                $scope.ValueLists = $scope.model.ValueLists;



                 @Html.RenderLookup("CompanyInfo", Model, Model.dsForm.Tables(0))






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


                $scope.item = function () {
                    $scope.party.push({});
                };
                $scope.delete = function (index) {
                    $scope.party.splice(index, 1);
                };


                $scope.changestate($scope.CompanyInfo.CountrySelected);















                $.each($scope.party, function (index, row) {
                    row.GSTRegTypeSelected = $.grep($scope.dsCombo.GSTRegType, function (item, index) { return item.Code === row.GSTRegType })[0];
                    row.CountrySelected = $.grep($scope.dsCombo.CO, function (item, index) { return item.countrycode === row.SelCountryCode })[0];
                    row.MSMEStatusSelected = $.grep($scope.dsCombo.MSME, function (item, index) { return item.codeword === row.MSMEStatus })[0];
                    row.TaxAreaIDSelected = $.grep($scope.dsCombo.TaxAreaCode, function (item, index) { return item.TaxAreaID === row.TaxAreaID })[0];

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

