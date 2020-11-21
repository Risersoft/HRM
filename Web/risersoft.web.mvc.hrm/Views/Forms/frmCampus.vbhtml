
@imports risersoft.shared.portable
@imports risersoft.app.mxform
@imports risersoft.shared.portable.Proxies
@imports risersoft.shared.web.Extensions
@imports Newtonsoft.Json
@ModelType frmCampusModel

@Code
    ViewData("Title") = "Campus"
    Layout = "~/Views/Shared/_FrameworkLayout.vbhtml"
    Dim modelJson = JsonConvert.SerializeObject(Model, Formatting.Indented,
                           New JsonSerializerSettings With {.StringEscapeHandling = StringEscapeHandling.EscapeHtml})
End Code

<div class="container cbackground">
    <form action="" method="post" name="userform" ng-controller="FormController">
        @Html.AntiForgeryToken()

        <input type="hidden" id="model_json" value='@Html.Raw(modelJson)' />
        <div Class="form-horizontal">

            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Campus</label></div>
            </div>

            <div Class="row">
                <div Class="col-md-1"></div>
                <div Class="col-md-6">
                    <Label Class="control-label labeltext">Display Name <span class="red">*</span></Label>
                    <input type="text" name="disname" ng-model="Campus.DispName" style="max-width: 540px;" class="form-control" required ng-class="{true: 'error'}[submitted() && userform.disname.$invalid]" />
                </div>
            </div>

            <div Class="row">
                <div Class="col-md-1"></div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">GST Registration <span class="red">*</span></Label>
                    <select name="gret" ng-model="Campus.GSTRegIDSelected" ng-options="itgstc.GSTIN for itgstc in dsCombo.GstReg track by itgstc.GSTRegID" ng-change="changestate(Campus.SelCountrySelected)" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.gret.$invalid]"></select>
                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">City <span class="red">*</span></Label>
                    <input type="text" ng-model="Campus.SelCity" Class="form-control" />
                </div>

                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Print Name</Label>
                    <input type="text" ng-model="Campus.TCName" Class="form-control" />
                </div>
            </div>
            <div Class="row">
                <div Class="col-md-1"></div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Campus Code</Label>
                    <input type="text" ng-model="Campus.CampusCode" Class="form-control" readonly />
                </div>
                <div class="col-md-3">
                    <label class="control-label labeltext">Type <span class="red">*</span></label>
                    <select name="grcamp" ng-model="Campus.CampusTypeSelected" ng-options="itgscamp.descriptot for itgscamp in dsCombo.CampusType track by itgscamp.codeword" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.grcamp.$invalid]"></select>
                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Branch</Label>
                    <input type="text" ng-model="Campus.Division" Class="form-control" />
                </div>
            </div>
            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Address</label></div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">
                    <label class="control-label labeltext">Address <span class="red">*</span></label>
                    <input name="cadd" type="text" ng-model="Campus.SelAddress" class="form-control" style="max-width:647px" required ng-class="{true: 'error'}[submitted() && userform.cadd.$invalid]" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-2">
                    <label class="control-label labeltext">PinCode <span class="red">*</span></label>
                    <input type="text" numbers-only ng-model="Campus.SelPinCode" class="form-control" />
                </div>
                <div class="col-md-2">
                    <Label Class="control-label labeltext">Country <span class="red">*</span></Label>
                    <select name="country" ng-model="Campus.SelCountrySelected" ng-options="itemcoun.country for itemcoun in dsCombo.CO track by itemcoun.country" ng-change="changestate(Campus.SelCountrySelected)" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.country.$invalid]"></select>
                </div>
                <div class="col-md-6">
                    <Label Class="control-label labeltext">State <span class="red">*</span></Label>
                    <select name="state" ng-model="Campus.SelStateSelected" ng-options="itemsu.SubDivisionName for itemsu in State track by itemsu.SubDivisionName" Class="form-control" required ng-class="{true: 'error'}[submitted() && userform.state.$invalid]"></select>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-4">
                    <label class="control-label labeltext">Email</label>
                    <input type="text" ng-model="Campus.EmailGen" style="max-width: 647px;" class="form-control" />
                </div>
                <div class="col-md-6">
                    <label class="control-label labeltext">Web</label>
                    <input type="text" ng-model="Campus.SelWeb" class="form-control" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-2">
                    <label class="control-label labeltext">Ph No.</label>
                    <input type="text" ng-model="Campus.SelPhCountry" class="form-control" />
                </div>
                <div class="col-md-2">
                    <label class="control-label labeltext">&nbsp;</label>
                    <input type="text" ng-model="Campus.SelPhArea" class="form-control" />
                </div>
                <div class="col-md-6">
                    <label class="control-label labeltext">&nbsp;</label>
                    <input type="text" ng-model="Campus.SelPhNum" class="form-control" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-2">
                    <label class="control-label labeltext">Fax No.</label>
                    <input type="text" ng-model="Campus.SelFaxCountry" class="form-control" />
                </div>
                <div class="col-md-2">
                    <label class="control-label labeltext">&nbsp;</label>
                    <input type="text" ng-model="Campus.SelFaxArea" class="form-control" />
                </div>
                <div class="col-md-6">
                    <label class="control-label labeltext">&nbsp;</label>
                    <input type="text" ng-model="Campus.SelFaxNum" class="form-control" />
                </div>
            </div>
            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Statutory</label></div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">
                    <label class="control-label labeltext">PAN NO.</label>
                    <input type="text" ng-model="Campus.PANNum" class="form-control" />
                </div>
                <div class="col-md-3">
                    <Label Class="control-label labeltext">TIN NO.</Label>
                    <input type="text" ng-model="Campus.TINNum" class="form-control" />
                </div>
                <div class="col-md-3">
                    <Label Class="control-label labeltext">Tax Area Code</Label>
                    <input type="text" ng-model="Campus.SelStateSelected.SubDivisionName" readonly class="form-control" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">
                    <label class="control-label labeltext">Factory License No.</label>
                    <input type="text" ng-model="Campus.FactoryLicenseNumber" class="form-control" />
                </div>
            </div>
            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Config</label></div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">
                    <label class="control-label labeltext">Division Code List</label>
                    <input type="text" ng-model="Campus.DivisionCodeList" class="form-control" />
                </div>
                <div class="col-md-3">
                    <Label Class="control-label labeltext">Email Sales </Label>
                    <input type="text" ng-model="Campus.EmailSls" class="form-control" />
                </div>
                <div class="col-md-3">
                    <Label Class="control-label labeltext">Email Purchase </Label>
                    <input type="text" ng-model="Campus.EmailPur" class="form-control" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">
                    <label class="control-label labeltext">Po Notes </label>
                    <input type="text" ng-model="Campus.PONote" class="form-control" />
                </div>
                <div class="col-md-3">
                    <Label Class="control-label labeltext">Invoice Notes </Label>
                    <input type="text" ng-model="Campus.InvoiceNote" Class="form-control"></>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div style="margin-top: 15px;" class="col-md-3">
                    <Label Class="control-label"> </Label>
                    Accepts Sales Order<input type="checkbox" ng-model="Campus.AcceptsOrder" /><br />
                    Accepts Sales Enquiry<input type="checkbox" ng-model="Campus.AcceptsEnq" /><br />
                </div>
            </div>
            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-10"><label class="control-label lbln">Material Depts</label> <Button type="button" id="items" Class="btn btn-primary btnf" ng-click="efnc()" style="margin-top:5px;margin-bottom:5px; float:right">ADD</Button></div>

            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">


                    <div class="table-responsive">
                        <table class="table table-bordered table-striped space10">
                            <tr class="tbld">
                                <td>DepCode</td>
                                <td>DepName</td>
                                <td>IsStore</td>
                                <td>IsShop</td>
                                
                                <td></td>


                            </tr>








                            <tr ng-repeat="row in Deps">
                                <td><label>{{row.DepCode}}</label></td>
                                <td><label>{{row.DepName}}</label></td>
                                <td><label>{{row.IsStore}}</label></td>
                                <td><label>{{row.IsShop}}</label></td>
                               


                                <td><a href="" ng-click="efnc(row,'frmMatDep',row.MatDepId)">Edit</a></td>





                            </tr>


                        </table>
                    </div>
                </div>

            </div>
            
            
            
            
            @Html.Partial("_SavePanel")
        </div>
    </form>

</div>





@section botscripts
    <script type="text/javascript">

        rsApp.controller('FormController', function ($scope, $http) {
            $scope.model = JSON.parse($("#model_json").val());
            $scope.status = 'loaded';
            $scope.ShowAddMore = ($scope.model.frmMode == 2);
            var loadmodel = function (result) {

                $scope.model = result;
                $scope.Campus = $scope.model.dsForm.DT[0];
                $scope.dsCombo = $scope.model.dsCombo;
                $scope.Division = $scope.model.dsCombo.Division;
                $scope.ValueLists = $scope.model.ValueLists;
                $scope.Deps = $scope.model.GridViews.Deps.MainGrid.myDS.Table;
                @Html.RenderLookup("Campus", Model, Model.dsForm.Tables(0))

                $scope.changestate = function (id) {
                    $scope.State = [];
                    if (id) {
                        $.each($scope.dsCombo.SU, function (item, index) {
                            if (index.countrycode === id.countrycode) {
                                $scope.State.push(index);
                            }
                        });
                    }

                }; $scope.copycontent = function (row) {
                    row.SelAddress = $scope.Campus.Address;
                    row.SelCity = $scope.Campus.City;
                    row.SelPinCode = $scope.Campus.Pincode;
                    row.CountrySelected = $scope.Campus.CountrySelected;
                    row.State = [];
                    $.each($scope.dsCombo.SU, function (item, indext) {
                        if (indext.countrycode === row.CountrySelected.countrycode) {
                            row.State.push(indext);
                        }
                    });
                    row.StateSelected = $scope.Campus.StateSelected;
                    row.SelPhCountry = $scope.Campus.PhCountry;
                    row.SelPhArea = $scope.Campus.PhArea;
                    row.SelPhNum = $scope.Campus.Phnum;
                    row.SelFaxCountry = $scope.Campus.FaxCountry;
                    row.SelFaxArea = $scope.Campus.FaxArea;
                    row.SelFaxNum = $scope.Campus.Faxnum;
                    return false;
                };

                $scope.changestate($scope.Campus.SelCountrySelected);

                $scope.pitem = function () {
                    $('#dialogFilterfile').dialog({
                        autoOpen: false,
                        resizable: false,
                        height: "auto",
                        width: 400,
                        modal: true,
                        buttons: [
                            {
                                text: "Save",
                                click: function () {
                                    var string = '';
                                    $.each($scope.Division, function (index, row) {
                                        if (row.DivisionCode == true) {
                                            string = string + row.DivisionName + ',';
                                        };

                                        $scope.Campus.DivisionCodeList = string;
                                    });

                                    $scope.$apply();
                                    $(this).dialog("close");
                                }
                                //showText: false
                            },
                            {
                                text: "Cancel",
                                click: function () {
                                    $(this).dialog("close");
                                }
                            }
                        ]
                    }).dialog("open");
                }



                $scope.efnc = function (row, key, id) {

                    var base = '/App/Link' + location.search;
                    var product = $scope.Campus;
                    product.CampusID = product.CampusID;
                    if (row == 0) {




                        var payload = { fKey: 'frmMatDep', fMode: 'acAddM', IDX: 0, rowData: JSON.stringify(product) };
                    }
                    else {
                        var payload = { fKey: key, fMode: 'acEditM', IDX: id, rowData: JSON.stringify(row) };
                    }
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
            };

            loadmodel($scope.model);

            $scope.cleanupmodel = function (datamodel) {
            };

            $scope.calculatemodel = function () {
            };

            $scope.visdel = false;@Html.RenderFile("~/scripts/rsforms.js")

            $scope.nform = function () {
                window.location = window.location.href;
            }
        });

    </script>
    <link href="~/Scripts/jquery-ui/jquery-ui.css" rel="stylesheet" />
    @Scripts.Render("~/bundles/jqueryui")
end section

