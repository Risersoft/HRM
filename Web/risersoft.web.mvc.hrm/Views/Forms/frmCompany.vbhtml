﻿
@imports risersoft.shared.cloud.common
@imports risersoft.app.mxform
@imports Newtonsoft.Json
@imports risersoft.shared.web.Extensions
@ModelType frmCompanyModel
@Code
    ViewData("Title") = "Company"
    Layout = "~/Views/Shared/_FrameworkLayout.vbhtml"

    'Dim modelJson = JsonConvert.SerializeObject(Model, Formatting.Indented,
    '                New JsonSerializerSettings With {.StringEscapeHandling = StringEscapeHandling.EscapeHtml, .NullValueHandling = NullValueHandling.Ignore})

    Dim modeljson = Model.SerializeJson.Replace("{{", "\u007B\u007B").Replace("}}", "\u007D\u007D")
End Code

@*<link href="~/Scripts/jquery-ui/jquery-ui.css" rel="stylesheet" />
<script src="~/Scripts/jquery-ui-1.11.4.min.js"></script>
<link href="~/Content/bootstrap-datepicker.min.css" rel="stylesheet" />
<link href="~/Content/font-awesome.css" rel="stylesheet" />
<script src="~/Scripts/bootstrap-datepicker.min.js"></script>*@
<div class="container cbackground">
    <form action="" method="post" name="userform" ng-controller="FormController">
        @Html.AntiForgeryToken()

        <input type="hidden" id="model_json" value='@Html.Raw(modelJson)' />
        <div Class="form-horizontal">
            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Company</label></div>
            </div>
            <div class="row"></div>
            <div Class="row" style="margin-top: 40px;">


                <div Class="col-md-1"></div>
                <div Class="col-md-6">
                    <Label Class="control-label labeltext">Name <span class="red">*</span></Label>
                    <input name="disname" type="text" ng-model="CompanyInfo.CompName" style="max-width: 540px;" class="form-control" required ng-class="{true: 'error'}[submitted() && userform.disname.$invalid]" />
                </div>
                <div Class="col-md-4">

                </div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-6">
                    <Label Class="control-label labeltext">PAN No. <span class="red">*</span></Label>
                    <input name="panno" type="text" ng-model="CompanyInfo.PANNum" style="max-width: 540px;" class="form-control" required ng-class="{true: 'error'}[submitted() && userform.panno.$invalid]" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-6">
                    <Label Class="control-label labeltext">Brand</Label>
                    <input name="panno" type="text" ng-model="CompanyInfo.BrandName" style="max-width: 540px;" class="form-control" required ng-class="{true: 'error'}[submitted() && userform.panno.$invalid]" />
                </div>
            </div>

            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">
                    <a href="" class="btn btn-primary" style="z-index:35;position:relative;margin-top:26px;" ng-click="item()">Add Registration</a>
                </div>

            </div><div ng-repeat="row in GstNo">
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">

                        <label class="control-label labeltext">GSTIN <span class="red">*</span></label>
                        <input type="text" name="gstc{{$index}}" ng-model="row.GSTIN" ng-change="changef(row)" class="form-control" required ng-class="{true: 'error'}[submitted() && userform.gstc{{$index}}.$invalid]" />
                    </div>


                    <div class="col-md-2">
                        <label class="control-label labeltext">RegDate <span class="red">*</span></label><input type="text" name="datec{{$index}}" ng-model="row.RegDate" class="form-control my-datepicker" required ng-class="{true: 'error'}[submitted() && userform.datec{{$index}}.$invalid]" />
                    </div>






                    <div class="col-md-2">
                        <label class="control-label labeltext">GSTRegType <span class="red">*</span></label>
                        <select name="categoryc{{$index}}" ng-model="row.GSTRegTypeSelected" ng-options="itemtx.descriptot for itemtx in Table1 track by itemtx.codeword" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.categoryc{{$index}}.$invalid]"></select>
                    </div>

                    <div class="col-md-2">
                        <label class="control-label labeltext">SearchResult</label><input type="text" ng-model="row.SearchResult" class="form-control" />
                    </div>








                </div>



                <div class="row">
                    <div class="col-md-1"></div>


                    <div class="col-md-3">
                        <label class="control-label labeltext">Tax Area <span class="red">*</span></label>
                        <select name="category{{$index}}" ng-model="row.TaxAreaIDSelected" ng-options="itemtx.Descrip for itemtx in GstTx track by itemtx.TaxAreaID" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.category{{$index}}.$invalid]"></select>

                    </div>
                    <div class="col-md-2">
                        <label class="control-label labeltext">Application Num</label><input type="text" ng-model="row.ApplicationNum" class="form-control" />
                    </div>
                    <div class="col-md-2">
                        <label class="control-label labeltext">GSTN UserId <span class="red">*</span></label>
                        <input type="text" name="cate{{$index}}" ng-model="row.GSTNUserId" class="form-control" required ng-class="{true: 'error'}[submitted() && userform.cate{{$index}}.$invalid]" />
                    </div>
                    <div class="col-md-2"><label class="control-label labeltext">Credit <span class="red">*</span></label><select name="ctwn{{$index}}" ng-model="row.PartialCreditSelected" ng-options="txdn.DisplayText for txdn in ValueLists.PartialCredit.ValueListItems track by txdn.DataValue" class="form-control" required ng-class="{true: 'error'}[submitted() && userform.ctwn{{$index}}.$invalid]"></select></div>
                </div>








                <div class="row">
                    <div class="col-md-1"></div>






                    <div class="col-md-3">
                        <label class="control-label labeltext">AuthPAN</label><input type="text" ng-model="row.AuthPAN" class="form-control" />
                    </div>



                    <div class="col-md-2">
                        <label class="control-label labeltext">EWB UserName</label>
                        <input type="text" ng-model="row.EWBUserName" class="form-control" />
                    </div>
                    <div class="col-md-2">
                        <label class="control-label labeltext">EWB Password</label>
                        <input type="text" ng-model="row.EWBPassword" class="form-control" />
                    </div>


                    <div class="col-md-2">
                        <label class="control-label labeltext">Turn Over <span class="red">*</span></label>
                        <input type="text" name="cateo{{$index}}" ng-model="row.TurnOver" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.cateo{{$index}}.$invalid]" />

                    </div>






                </div>





                <div class="row">
                    <div class="col-md-1"></div>


                    <div class="col-md-3">
                        <label class="control-label labeltext">Is HeadOffice </label><select name="country" ng-model="row.IsHeadOfficeSelected" ng-options="itemhc.DisplayText for itemhc in ValueLists.IsHeadOffice.ValueListItems track by itemhc.DataValue" Class="form-control"></select>
                    </div>












                    <div class="col-md-1">
                        <a href="" class="delete" style="z-index:35;position:relative;margin-top:38px;float:right" ng-click="delete($index)"><span class="fa fa-trash" style="color: #d83e3b;"></span></a>
                    </div>


                </div>


                <div class="row"><hr /></div>
            </div>
            <div class="row" style="margin-top:17px; margin-bottom:15px;">
                <div class="col-md-1"></div>
                <div Class="col-md-6"><label class="control-label" style="text-decoration:underline;">Head Office </label></div>

            </div>










            <div class="row marb" style="padding:15px;">



                <div class="">



                    <div class="col-md-1"></div>
                    <div class="col-md-8">
                        <ul class="nav nav-tabs">
                            <li class="labeltext"><a href="#tab{{$index}}_1" class="nav-link active labeltext" data-toggle="tab">Address</a></li>
                            <li class="labeltext"><a href="#tab{{$index}}_2" class="nav-link labeltext" data-toggle="tab">Config</a></li>
                            <li class="labeltext" ng-show="CompanyInfo.TCLogo"><a href="#tab{{$index}}_3" class="nav-link labeltext" data-toggle="tab">Logo</a></li>

                        </ul>
                        <div class="tab-content">
                            <div class="tab-pane active" id="tab{{$index}}_1">
                                <div Class="row">


                                    <div Class="col-md-1"></div>
                                    <div Class="col-md-10">
                                        <Label Class="control-label">Address <span class="red">*</span></Label>
                                        <input name="cadd" type="text" ng-model="CompanyInfo.Address" Class="form-control" style="max-width: 517px;" required ng-class="{true: 'error'}[submitted() && userform.cadd.$invalid]" />

                                    </div>




                                </div>
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div Class="col-md-4">
                                        <Label Class="control-label">City <span class="red">*</span></Label>
                                        <input name="city" type="text" ng-model="CompanyInfo.City" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.city.$invalid]" />
                                    </div>
                                    <div class="col-md-6">
                                        <Label Class="control-label">PinCode <span class="red">*</span></Label>
                                        <input name="pcode" type="text" ng-model="CompanyInfo.Pincode" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.pcode.$invalid]" />
                                    </div>
                                </div>





                                <div Class="row">


                                    <div Class="col-md-1"></div>
                                    <div Class="col-md-4">
                                        <Label Class="control-label">Country <span class="red">*</span></Label>
                                        <select name="country" ng-model="CompanyInfo.CountrySelected" ng-options="itemcoun.country for itemcoun in dsCombo.CO track by itemcoun.country" ng-change="changestate(CompanyInfo.CountrySelected)" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.country.$invalid]"></select>


                                    </div>
                                    <div Class="col-md-6">
                                        <Label Class="control-label">State <span class="red">*</span></Label>
                                        <select name="state" ng-model="CompanyInfo.StateSelected" ng-options="itemsu.SubDivisionName for itemsu in State track by itemsu.SubDivisionName" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.state.$invalid]"></select>

                                    </div>

                                    <div Class="col-md-3">
                                        <Label Class="control-label labeltext"></Label>
                                        @*<select name="Receivergstin" ng-model="InvoiceInfo.CompanyIDSelected"
                                    ng-options="itemze.CompName for itemze in dsCombo.Company track by itemze.CompanyID" Class="form-control"></select>*@
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-2">
                                        <label class="control-label">Ph No.</label>
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
                                        <label class="control-label">Fax No.</label>
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
                                        <label class="control-label">Email</label>
                                        <input type="text" ng-model="CompanyInfo.Email" class="form-control" />
                                    </div>
                                    <div class="col-md-6">
                                        <label class="control-label">Web</label>
                                        <input type="text" ng-model="CompanyInfo.Web" class="form-control" />
                                    </div>
                                </div>



                            </div>




                            <div class="tab-pane" id="tab{{$index}}_2">

                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-5">

                                        <Label Class="control-label">Fin Start Date <span class="red">*</span></Label>
                                        <input type="text" id="companydate" name="companydate" datetime="yyyy-mm-dd" ng-model="CompanyInfo.FinStartDate" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.companydate.$invalid]" />


                                    </div>
                                    <div class="col-md-5">

                                    </div>

                                </div>
                                <div class="row" ng-show="HO!=''">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-5">
                                        <Label Class="control-label">HO Campus</Label>
                                        <select ng-model="CompanyInfo.HOCampusIDSelected" ng-options="camp.DispName for camp in dt track by camp.CampusID" Class="form-control"></select>

                                    </div>
                                    <div class="col-md-5">

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-5">
                                        <label class="control-label">Purchase Employee</label>
                                        <input type="text" class="form-control" />
                                    </div>
                                    <div class="col-md-5">

                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-5">
                                        <label class="control-label">Sales Employee</label>
                                        <input type="text" class="form-control" />
                                    </div>
                                    <div class="col-md-5">

                                    </div>

                                </div>



                            </div>
                            <div class="tab-pane" id="tab{{$index}}_3">
                                <div class="row" style="margin-top:25px">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-5">
                                        <img src="" data-ng-src="data:image/png;base64,{{CompanyInfo.TCLogo}}" />
                                    </div>
                                    <div class="col-md-5">

                                        <label class="control-label">Upload Logo</label><br />
                                        <input type="file" id="filename" name="filename" Class="form-control" autocomplete="off" />

                                    </div>
                                    <div class="col-md-5">

                                    </div>
                                </div>

                            </div>

                        </div>
                    </div>


                </div>






                @Html.Partial("_SavePanel")
            </div>
</form>
</div>


@section botscripts





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
            $scope.status = 'loaded';
            var loadmodel = function (result) {


                $scope.model = result;
                $scope.CompanyInfo = $scope.model.dsForm.DT[0]; $scope.ValueLists = $scope.model.ValueLists;



                $scope.GstTx = $scope.model.GridViews.GstReg.MainGrid.dsLookup.Table0;
                $scope.Table1 = $scope.model.GridViews.GstReg.MainGrid.dsLookup.Table1;


                $scope.GstNo = $scope.model.GridViews.GstReg.MainGrid.myDS.dt;
                $('#companydate').datepicker({ dateFormat: 'yy-mm-dd' });
                $scope.dsCombo = $scope.model.dsCombo;
                $scope.dt = $scope.model.GridViews.Campus.MainGrid.myDS.dt; $scope.HO = $scope.dt;


                $scope.item = function () {

                    $scope.GstNo.push({});
                };


                $scope.delete = function (index) {


                    $scope.GstNo.splice(index, 1);
                };
                $scope.dsCombo = $scope.model.dsCombo;


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

                $scope.changestate($scope.CompanyInfo.CountrySelected);
                $scope.CompanyInfo.HOCampusIDSelected = $.grep($scope.dt, function (item, index) { return item.CampusID === $scope.CompanyInfo.HOCampusID })[0];
                $.each($scope.GstNo, function (index, row) {
                    row.TaxAreaIDSelected = $.grep($scope.GstTx, function (item, index) { return item.TaxAreaID === row.TaxAreaID })[0];
                    row.GSTRegTypeSelected = $.grep($scope.Table1, function (item, index) { return item.codeword === row.GSTRegType })[0];
                    row.PartialCreditSelected = $.grep($scope.ValueLists.PartialCredit.ValueListItems, function (item, index) { return item.DataValue == row.PartialCredit })[0];
                    row.IsProductionSelected = $.grep($scope.ValueLists.Envc.ValueListItems, function (item, index) { return item.DataValue == row.IsProduction })[0];
                    row.IsHeadOfficeSelected = $.grep($scope.ValueLists.IsHeadOffice.ValueListItems, function (item, index) { return item.DataValue == row.IsHeadOffice })[0];
                });


                $scope.partyfn = function (code) {

                    $scope.SelectedParty = $.grep($scope.dsCombo.Customer, function (item, index) { return item.CustomerID === code.CustomerID })[0];
                    $scope.CompanyInfo.CTIN = $scope.SelectedParty.GSTIN;
                };

                $scope.changef = function (row) {


                    var gstin = row.GSTIN.split('');
                    if (gstin[0] != undefined && gstin[1] != undefined) {
                        var gstinc = gstin[0] + gstin[1];
                        row.TaxAreaIDSelected = $.grep($scope.GstTx, function (item, index) { return item.TINCode === gstinc })[0];

                  }
                };
                $scope.itemf = function (gstindata) {

                    if (gstindata != undefined) {
                        var url = '/frmGstCompany/ParamsOutput' + location.search;

                        var payload = { gstin: gstindata };


                        payload = JSON.stringify(payload);

                        var token = $('input[name="__RequestVerificationToken"]').val();
                        var payloaddata = { key: 'search', Params: payload, __RequestVerificationToken: token };


                        $.post(url, payloaddata, function (result) {




                            if (result.success) {







                                $scope.Datac = result.Data;
                                    $("#dialog-manual").dialog({
                                        autoOpen: false,
                                        modal: true,
                                        width: 1100,


                                        title: "GSTIN",
                                        hide: {
                                            effect: "fade",
                                            duration: 1000
                                        }

                                }); $scope.$apply();
                                    $("#dialog-manual").dialog("open");

                            }
                            else {
                                alert(result.message);
                            }
                        });
                    }

                };

            };





            loadmodel($scope.model);
            $scope.cleanupmodel = function (datamodel) {
                datamodel.GridViews.GstReg.MainGrid.dsLookup = null;
            };
            $scope.calculatemodel = function () {
                //empty function
            };




            $scope.visdel = false;@Html.RenderFile("~/scripts/rsforms.js")


        }

        )
    </script>
    <link href="~/Scripts/jquery-ui/jquery-ui.css" rel="stylesheet" />
    @Scripts.Render("~/bundles/jqueryui")
end section

