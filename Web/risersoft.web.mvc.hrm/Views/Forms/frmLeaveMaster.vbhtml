
@imports risersoft.shared.cloud.common
@imports risersoft.app.mxform.hrm
@imports Newtonsoft.Json
@imports risersoft.shared.web.Extensions
@ModelType frmLeaveMasterModel
@Code
    ViewData("Title") = "Leave Master"
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
                <div class="col-md-8"><label class="control-label lbln">Leave Master</label></div>
            </div>
            <div Class="row" style="margin-top:40px;">
                <div Class="col-md-1"></div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Company</Label>
                    <select ng-model="PartyInfo.CompanyIDSelected" ng-options="itemn.compname for itemn in dsCombo.company track by itemn.companyid" Class="form-control"></select>

                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Start Date</Label>
                    <input type="text" ng-model="PartyInfo.sDate" readonly class="form-control" />
                </div>


                <div Class="col-md-3">
                    <Label Class="control-label labeltext">End Date</Label>
                    <input type="text" ng-model="PartyInfo.eDate" readonly class="form-control" />
                </div>

            </div>
            <div Class="row" style="margin-bottom:40px">
                <div Class="col-md-1"></div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">El Min Months</Label>
                    <input type="text" ng-model="PartyInfo.ELMinMonths" class="form-control" />
                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext"></Label>
                    <Button type="button" id="items" Class="btn btn-primary btnf" ng-click="postc('generateleavebal','')" style="float:left;padding-left: 47px;padding-right: 47px; margin-top:34px">Calculate Balance</Button>
                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext"></Label>
                    <Button type="button" id="items" Class="btn btn-primary btnf" ng-click="postc('generatefy','')" style="float:left;padding-left: 47px;padding-right: 47px; margin-top:34px">Calculate FY</Button>
                </div>

            </div>
            <div class="row">
                <div style="margin-top:10px;margin-left: 65px;">
                    <div id="msgSyncContainer">
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="form-group">
                        <div class="col-md-10">
                            <i class="fa fa-2x fa-check" id="status" ng-show="(result=='success')" style="margin-right:8px;margin-left: 0px;float: left;"></i>
                            <div ng-show="(result=='success')" style="color:green;margin-left:8px;float: left;width: 500px;">{{message}}</div>

                            <i class="fa fa-2x fa-remove" id="failure" ng-show="(result=='failure')" style="margin-right:8px;margin-left: 0px;"></i>
                            <div ng-show="(result=='failure')" style="color:red;margin-left:8px;width: 500px;">{{message}}</div>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Balance</label></div>
            </div>





            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">


                    <div class="table-responsive">
                        <table class="table table-bordered table-striped space10">
                            <tr class="tbld">
                                <td>Emp Code</td>
                                <td>Full Name</td>
                                <td>Qty</td>

                                

                            </tr>
                            <tr ng-repeat="row in LveBal">
                                <td><label>{{row.EmpCode}}</label></td>
                                <td><label>{{row.FullName}}</label></td>
                                <td><label>{{row.Qty}}</label></td>





                               
                            </tr>


                        </table>
                    </div>
                </div>

            </div>


            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Encashment Previous</label></div>
            </div>



            <div class="row marb" style="margin-top:17px;">

                <div class="">
                    <ul class="nav nav-tabs">
                        <li class="active labeltext"><a href="#tabc" class="labeltext nav-link active" data-toggle="tab">Yearly</a></li>
                        <li class="labeltext"><a href="#taby" class="labeltext nav-link" data-toggle="tab">Voucher</a></li>


                    </ul>
                    <div class="tab-content">
                        <div class="tab-pane active" id="tabc">
                            <div class="row">
                                <div class="col-md-1"></div>
                                <div class="col-md-10">


                                    <div class="table-responsive">
                                        <table class="table table-bordered table-striped space10">
                                            <tr class="tbld">
                                                <td>Emp Code</td>
                                                <td>Full Name</td>
                                                <td>Qty</td>
                                                <td>Amount New</td>
                                                <td>Amount Prev</td>
                                                <td>Payment Thru</td>
                                                <td></td>

                                            </tr>
                                            <tr ng-repeat="row in Yr">
                                                <td><label>{{row.EmpCode}}</label></td>
                                                <td><label>{{row.FullName}}</label></td>
                                                <td><label>{{row.Qty}}</label></td>
                                                <td><label>{{row.AmountNew}}</label></td>
                                                <td><label>{{row.AmountPrev}}</label></td>
                                                <td><label>{{row.PaymentThru}}</label></td>



                                                <td><a href="" ng-click="efnc(row)">Edit</a></td>
                                            </tr>


                                        </table>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="tab-pane" id="taby">
                            <div class="row">
                                <div class="col-md-1"></div>
                                <div class="col-md-10">


                                    <div class="table-responsive">
                                        <table class="table table-bordered table-striped space10">
                                            <tr class="tbld">
                                                <td>Payee</td>
                                                <td>Payment Due</td>
                                                <td>Total Amount</td>

                                                <td></td>

                                            </tr>
                                            <tr ng-repeat="row in PayHRVouch">
                                                <td><label>{{row.Payee}}</label></td>
                                                <td><label>{{row.PaymentDue}}</label></td>
                                                <td><label>{{row.TotalAmount}}</label></td>





                                                <td><a href="" ng-click="efnc(row)">Edit</a></td>
                                            </tr>


                                        </table>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Encashment Current</label></div>
            </div>

            <div class="row marb" style="margin-top:17px;">

                <div class="">
                    <ul class="nav nav-tabs">
                        <li class="active labeltext"><a href="#tabn" class="labeltext nav-link active" data-toggle="tab">FF</a></li>
                        <li class="labeltext"><a href="#tabw" class="labeltext nav-link" data-toggle="tab">As When</a></li>


                    </ul>
                    <div class="tab-content">
                        <div class="tab-pane active" id="tabn">
                            <div class="row">
                                <div class="col-md-1"></div>
                                <div class="col-md-10">


                                    <div class="table-responsive">
                                        <table class="table table-bordered table-striped space10">
                                            <tr class="tbld">
                                                <td>Emp Code</td>
                                                <td>Full Name</td>
                                                <td>Descrip</td>
                                                <td>Amount New</td>
                                                <td>Amount Prev</td>
                                                <td>Payment Thru</td>
                                                <td></td>

                                            </tr>
                                            <tr ng-repeat="row in FF">
                                                <td><label>{{row.EmpCode}}</label></td>
                                                <td><label>{{row.FullName}}</label></td>
                                                <td><label>{{row.Descrip}}</label></td>
                                                <td><label>{{row.AmountNew}}</label></td>
                                                <td><label>{{row.AmountPrev}}</label></td>
                                                <td><label>{{row.PaymentThru}}</label></td>



                                                <td><a href="" ng-click="efnc(row)">Edit</a></td>
                                            </tr>


                                        </table>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="tab-pane" id="tabw">
                            <div class="row">
                                <div class="col-md-1"></div>
                                <div class="col-md-10">


                                    <div class="table-responsive">
                                        <table class="table table-bordered table-striped space10">
                                            <tr class="tbld">
                                                <td>Emp Code</td>
                                                <td>Full Name</td>
                                                <td>Descrip</td>
                                                <td>Amount New</td>
                                                <td>Amount Prev</td>
                                                <td>Payment Thru</td>
                                                <td></td>

                                            </tr>
                                            <tr ng-repeat="row in LL">
                                                <td><label>{{row.EmpCode}}</label></td>
                                                <td><label>{{row.FullName}}</label></td>
                                                <td><label>{{row.Descrip}}</label></td>
                                                <td><label>{{row.AmountNew}}</label></td>
                                                <td><label>{{row.AmountPrev}}</label></td>
                                                <td><label>{{row.PaymentThru}}</label></td>



                                                <td><a href="" ng-click="efnc(row)">Edit</a></td>
                                            </tr>


                                        </table>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>





            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">FY End</label></div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">


                    <div class="table-responsive">
                        <table class="table table-bordered table-striped space10">
                            <tr class="tbld">
                                <td>Emp Code</td>
                                <td>Full Name</td>
                                <td>DepName</td>
                                <td>Qty</td>
                                <td>Amount New</td>
                                <td>Amount Prev</td>



                            </tr>
                            <tr ng-repeat="row in FY">
                                <td><label>{{row.EmpCode}}</label></td>
                                <td><label>{{row.FullName}}</label></td>
                                <td><label>{{row.DepName}}</label></td>
                                <td><label>{{row.Qty}}</label></td>
                                <td><label>{{row.AmountNew}}</label></td>
                                <td><label>{{row.AmountPrev}}</label></td>





                            </tr>


                        </table>
                    </div>
                </div>

            </div>


            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Task Status</label></div>
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


                $scope.Party = $scope.model.dsForm.party;
                $scope.dsCombo = $scope.model.dsCombo;



                $scope.modelUrl = 'frmLeaveMaster';


                $scope.LveBal = $scope.model.GridViews.LveBal.MainGrid.myDS.dt;
                $scope.FF = $scope.model.GridViews.FF.MainGrid.myDS.dt;
                $scope.LL = $scope.model.GridViews.LL.MainGrid.myDS.dt;
                $scope.FY = $scope.model.GridViews.FY.MainGrid.myDS.dt;
                $scope.PayHRVouch = $scope.model.GridViews.PayHRVouch.MainGrid.myDS.dt;
                $scope.Yr = $scope.model.GridViews.Yr.MainGrid.myDS.dt;
                @Html.RenderLookup("PartyInfo", Model, Model.dsForm.Tables(0));

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

                var msgHTML = '<div></div><div class="form-group" id="syncPanel"><div>';
                msgHTML += '<div class="form-group" style="font-size: 10px;background-color: #efefef;width: 815px;" id="syncMessagePanel">';
                msgHTML += '<div><a href="#" class="delete" id="removeSyncDiv"><span class="fa fa-remove" style="color: #d83e3b;margin-right: 8px;"></span></a>';
                msgHTML += '<div class="row" style="padding-top:5px;margin-left: 15px;">';
                msgHTML += '<div id="syncExecutedMsg" style="padding:5px;"></div>';
                msgHTML += '<i class="fa fa-2x fa-link" style="color:green; display:none; padding: 5px;" id="syncDownloadLink"></i>';
                msgHTML += '</div></div></div></div></div>';



                $scope.postc = function (key, UploadType) {
                    //debugger;
                    $scope.IsInitializing = true;
                    $scope.result = ''; $scope.status = 'postedc';

                    var token = $('input[name="__RequestVerificationToken"]').val();
                    var url = '/' + $scope.modelUrl + '/ParamsOutput' + location.search;
                    var payload = { LeaveMasterID: $scope.PartyInfo.LeaveMasterID };
                    payload = JSON.stringify(payload);
                    var payloaddata = { key: key, Params: payload, __RequestVerificationToken: token };



                    $.post(url, payloaddata, function (result) {
                        $scope.itemdis = false;
                        if (result.Data.Description != "" && result.message != "") {
                            $scope.status = '';
                            $scope.result = '';

                            var msg = $('#msgSyncContainer').find("[data-syncTaskid='" + result.Data.Description + "']");
                            if (msg.length <= 0) {
                                msg = $(msgHTML);
                                $(msg.get(1)).attr("data-syncTaskid", result.Data.Description);
                                $('#msgSyncContainer').prepend(msg);
                            }
                            msg.find("div#syncExecutedMsg").html('<i class="fa fa-2x fa-check" style="color:green"> ' + result.message + '</i>');
                        }
                        else {
                            $scope.status = '';
                            $scope.result = result.message == "" ? '' : 'success';
                            $scope.message = result.message;
                        }

                        //debugger;
                        if (result.success) {
                            if (result.Data) {
                                if (key == 'dbsumm') {
                                    $scope.model.dsForm.detail = result.Data.Data.detail;
                                    $scope.model.dsForm.counter = result.Data.Data.counter;
                                    $scope.AppItem = result.Data.Data.gstreg;
                                    $scope.return = result.Data.Data.return[0];
                                    $scope.itmval = false;
                                }

                                if (typeof (result.Data) === "string") {
                                    result.Data = JSON.parse(result.Data);
                                }

                                if (result.Data.CalcList && result.Data.CalcList.trans && result.Data.CalcList.trans.length > 0 && result.Data.CalcList.trans[0].ResponsePayload) {
                                    var responsePayload = JSON.parse(result.Data.CalcList.trans[0].ResponsePayload);
                                    $scope.Datacn_RetPeriod = responsePayload.ret_period;
                                    //$scope.setDatacn(responsePayload.sec_sum);

                                    if (result.Data.Result == undefined) { }
                                    else {
                                        //$scope.setDatacn(result.Data.Result.sec_sum);
                                    }
                                } else {
                                    //$scope.setDatacn([]);
                                    //$scope.setDatacn(result.Data.sec_sum);
                                }

                                if ($scope.IsInitializing && result.Data.Description) {
                                    $scope.taskID = result.Data.Description;
                                    $scope.checkStatusInterval($scope.taskID, msg);
                                }

                                if (key == 'infojson') {
                                    $scope.InfoJsonData = JSON.parse(result.Data.Description);
                                }
                            };
                        }
                        else {
                            if (result.message === '') {
                                msg.find("div#syncExecutedMsg").html('<i class="fa fa-2x fa-remove" style="color:red"> Unknown Error!</i>');
                                //result.message = 'Unknown Error!'
                            };
                            $scope.message = result.message;
                            $scope.status = '';
                            $scope.result = 'failure';
                        }


                        $scope.$apply();
                        return;
                    });
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
            $(document).on("click", "#removeSyncDiv", function (e) {
                e.preventDefault();
                $(this).closest('div#syncMessagePanel').hide();
                return;
            });
        @Html.RenderFile("~/scripts/rsforms.js")
            });

    </script>
End Section

