
@imports risersoft.shared.cloud.common
@imports risersoft.app.mxform.hrm
@imports Newtonsoft.Json
@imports risersoft.shared.web.Extensions
@ModelType frmPayPeriodModel
@Code
    ViewData("Title") = "Pay Period"
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
                <div class="col-md-8"><label class="control-label lbln">Pay Period</label></div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">

                    <label class="control-label labeltext">Description </label>
                    <input type="text" ng-model="PaydInfo.PayPeriodName" class="form-control" />
                </div>







                <div class="col-md-3">
                    <label class="control-label labeltext">Start Date </label><input type="text" ng-model="PaydInfo.SDate" readonly class="form-control" />
                </div>






                <div class="col-md-3">
                    <label class="control-label labeltext">End Date </label>
                    <input type="text" ng-model="PaydInfo.EDate" readonly class="form-control" />
                </div>

            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">

                    <label class="control-label labeltext">Rate Master </label>
                    <input type="text" ng-model="dsCombo.rm[0].Descrip" readonly class="form-control" />
                </div>







                <div class="col-md-3">
                    <label class="control-label labeltext">Bonus Master </label><input type="text" ng-model="dsCombo.bonus[0].descrip" readonly class="form-control" />
                </div>






                <div class="col-md-3">
                    <label class="control-label labeltext">Leaver Master <span class="red">*</span></label>
                    <input type="text" ng-model="dsCombo.lve[0].descrip" readonly class="form-control" />
                </div>

            </div>



            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">

                    <label class="control-label labeltext">Financial Year </label>
                    <input type="text" ng-model="dsCombo.finyear[0].descrip" readonly class="form-control" />
                </div>


            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">

                    <label class="control-label labeltext"></label>
                    <Button type="button" id="items" Class="btn btn-primary btnf" ng-click="postid('advance','')" style="margin-top:13px;float:left;padding-left: 47px;padding-right: 47px;margin-bottom: 15px">Generate Advance</Button>
                </div>







                <div class="col-md-3">
                    <label class="control-label labeltext"></label> <Button type="button" id="items" Class="btn btn-primary btnf" ng-click="postid('advancedep','')" style="margin-top:13px;float:left;">Create DepartmentalAdvance</Button>
                </div>













                <div class="col-md-3">
                    <label class="control-label labeltext"></label>
                    <Button type="button" id="items" Class="btn btn-primary btnf" ng-click="postc('calcppsal','')" style="margin-top:13px;float:left;padding-left: 57px;padding-right: 54px;">Calculate Salary</Button>
                </div>

            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">

                    <label class="control-label labeltext"></label>
                    <Button type="button" id="items" Class="btn btn-primary btnf" ng-click="postc('uncalcppsal','')" style="float:left;padding-left: 47px;padding-right: 47px;margin-bottom: 15px">UnCalculate Salary</Button>
                </div>







                <div class="col-md-3">
                    <label class="control-label labeltext"></label> <Button type="button" id="items" Class="btn btn-primary btnf" ng-click="postc('calcppsumm','')" style="float:left;padding-left: 47px;padding-right: 47px;">Calculate Summary</Button>
                </div>










                <div class="col-md-3">
                    <label class="control-label labeltext"></label>
                    <Button type="button" id="items" Class="btn btn-primary btnf" ng-click="postc('calcppinc','')" style="float:left;padding-left: 47px;padding-right: 47px;">Calculate Incentive</Button>
                </div>

            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">

                    <label class="control-label labeltext"></label>
                    <Button type="button" id="items" Class="btn btn-primary btnf" ng-click="postc('calcincsumm','')" style="margin-bottom:13px;float:left;">Calculate Incentive Summary</Button>
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
                <div class="col-md-8"><label class="control-label lbln">Details</label></div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">

                    <label class="control-label labeltext">Salary Calculated On <span class="red">*</span></label>
                    <input type="text" ng-model="PaydInfo.SalCalcOn" class="form-control" />
                </div>







                <div class="col-md-3">
                    <label class="control-label labeltext">Advanced Paid On</label><input type="text" ng-model="PaydInfo.AdvanceOn" readonly class="form-control my-datepicker" />
                </div>






                <div class="col-md-3">
                    <label class="control-label labeltext">Salary Dirtied On</label>
                    <input type="text" ng-model="PaydInfo.SalDirtyOn" class="form-control" />
                </div>

            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">

                    <label class="control-label labeltext">Salary Paid On </label>
                    <input type="text" ng-model="PaydInfo.SalPaidOn" class="form-control" />
                </div>







                <div class="col-md-3">
                    <label class="control-label labeltext">Total Basic </label>  <input type="text" ng-model="PaydInfo.TotalBasic" class="form-control" />
                </div>






                <div class="col-md-3">
                    <label class="control-label labeltext">Total Allowance </label>
                    <input type="text" ng-model="PaydInfo.TotalAllow" class="form-control" />
                </div>

            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">

                    <label class="control-label labeltext">Men Days Total </label>
                    <input type="text" ng-model="PaydInfo.MenDaysTotal" class="form-control" />
                </div>







                <div class="col-md-3">
                    <label class="control-label labeltext">Men Days Worked </label>  <input type="text" ng-model="PaydInfo.MenDaysWorked" class="form-control" />
                </div>






                <div class="col-md-3">
                    <label class="control-label labeltext">Total Benefit of Employees </label>
                    <input type="text" ng-model="PaydInfo.TotalBenefitEE" class="form-control" />
                </div>

            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">

                    <label class="control-label labeltext">Total Benefit of Employer </label>
                    <input type="text" ng-model="PaydInfo.TotalBenefitER" class="form-control" />
                </div>







                <div class="col-md-3">
                    <label class="control-label labeltext">Accounting Voucher Date </label>  <input type="text" ng-model="PaydInfo.AccVouchDate" class="form-control" />
                </div>








            </div>



            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-10"><label class="control-label lbln">Mandatory Holidays</label>  <Button type="button" id="items" Class="btn btn-primary btnf" ng-click="item()" style="margin-top:5px;margin-bottom:5px; float:right">ADD</Button></div>
            </div>


            <div ng-repeat="row in Holiday">
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">

                        <label class="control-label labeltext">Campus</label>
                        <select ng-model="row.CampusSelected" ng-options="itemt.DispName for itemt in Campus track by itemt.CampusID" Class="form-control"></select>
                    </div>


                    <div class="col-md-3">
                        <label class="control-label labeltext">Dated</label><input type="text" ng-model="row.Dated" class="form-control my-datepicker" />
                    </div>






                    <div class="col-md-3">
                        <label class="control-label labeltext">Holiday</label>
                        <input type="text" ng-model="row.Holiday" class="form-control" />
                    </div>










                </div>
                <div class="row">
                    <div class="col-md-1"></div>






                    <div class="col-md-3">
                        <label class="control-label labeltext">Type </label>  <select ng-model="row.HolidayTypeSelected" ng-options="itemt.DisplayText for itemt in ValueLists.Tnvlp.ValueListItems track by itemt.DataValue" Class="form-control"></select>
                    </div>
                    <div class="col-md-1">
                        <a href="" class="delete" style="z-index:35;position:relative;margin-top:38px;float:right" ng-click="delete($index)"><span class="fa fa-trash" style="color: #d83e3b;"></span></a>
                    </div>
                </div>

                <div class="row"><hr /></div>
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
                                <td>Name</td>
                                <td>PayPeriod</td>
                                <td>Challan</td>
                                <td>Limit</td>
                                <td>Employee</td>
                                <td>Employee1</td>
                                <td>Employee2</td>

                                <td>Amount1</td>
                                <td>Amount2</td>
                                <td>Amount3</td>
                                <td>Employee</td>
                                <td>Employee1</td>
                                <td>Employee2</td>
                                <td>Amount1</td>
                                <td>Amount2</td>


                            </tr>
                            <tr ng-repeat="row in Exp">
                                <td><label>{{row.BenefitName}}</label></td>
                                <td><label>{{row.PayPeriodid}}</label></td>
                                <td><label>{{row.ChallanDate}}</label></td>
                                <td><label>{{row.Limit}}</label></td>
                                <td><label>{{row.perEE}}</label></td>
                                <td><label>{{row.perER1}}</label></td>
                                <td><label>{{row.perER2}}</label></td>
                                <td><label>{{row.perAdminAmount1}}</label></td>
                                <td><label>{{row.perAdminAmount2}}</label></td>
                                <td><label>{{row.perAdminAmount3}}</label></td>
                                <td><label>{{row.AmountEE}}</label></td>
                                <td><label>{{row.AmountER1}}</label></td>
                                <td><label>{{row.AmountER2}}</label></td>
                                <td><label>{{row.AdminAmount1}}</label></td>

                                <td><label>{{row.AdminAmount2}}</label></td>




                            </tr>


                        </table>
                    </div>
                </div>

            </div>
            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Vouchers</label></div>
            </div>



            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">


                    <div class="table-responsive">
                        <table class="table table-bordered table-striped space10">
                            <tr class="tbld">
                                <td>VoucherType</td>
                                <td>PayDue Type</td>
                                <td>Payee</td>
                                <td>TotalAmount</td>
                                <td>Payment Mode</td>



                            </tr>
                            <tr ng-repeat="row in GstNo">
                                <td><label>{{row.EstabName}}</label></td>
                                <td><label>{{row.Designation}}</label></td>
                                <td><label>{{row.PeriodService}}</label></td>
                                <td><label>{{row.ExpInMonths}}</label></td>
                                <td><label>{{row.MonthlyPay}}</label></td>






                            </tr>


                        </table>
                    </div>
                </div>

            </div>







            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Campus</label></div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">


                    <div class="table-responsive">
                        <table class="table table-bordered table-striped space10">
                            <tr class="tbld">
                                <td>PayPeriodName</td>
                                <td>Campus</td>
                                <td>Half Month Working Days</td>
                                <td>Month Working Days</td>




                            </tr>
                            <tr ng-repeat="row in GstNot">
                                <td><label>{{row. PayPeriodName}}</label></td>
                                <td><label>{{row.DispName}}</label></td>
                                <td><label>{{row.HWDay}}</label></td>
                                <td><label>{{row.TWDay}}</label></td>







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
        rsApp.controller('CompanyController', function ($scope,$rootScope, $http, $interval) {
            $scope.modelUrl = 'frmPayPeriod';
            $scope.model = JSON.parse($("#model_json").val());
            $scope.data = "This is data come from json";



            var loadmodel = function (result) {
                $scope.model = result;



                $scope.PaydInfo = $scope.model.dsForm.DT[0];


                $scope.dsCombo = $scope.model.dsCombo;
                $scope.ValueLists = $scope.model.ValueLists;
                $scope.Holiday = $scope.model.GridViews.Holiday.MainGrid.myDS.dt;



                $scope.Campus = $scope.model.GridViews.Holiday.MainGrid.dsLookup.Table0;





                var msgHTML = '<div></div><div class="form-group" id="syncPanel"><div>';
                msgHTML += '<div class="form-group" style="font-size: 10px;background-color: #efefef;width: 815px;" id="syncMessagePanel">';
                msgHTML += '<div><a href="#" class="delete" id="removeSyncDiv"><span class="fa fa-remove" style="color: #d83e3b;margin-right: 8px;"></span></a>';
                msgHTML += '<div class="row" style="padding-top:5px;margin-left: 15px;">';
                msgHTML += '<div id="syncExecutedMsg" style="padding:5px;"></div>';
                msgHTML += '<i class="fa fa-2x fa-link" style="color:green; display:none; padding: 5px;" id="syncDownloadLink"></i>';
                msgHTML += '</div></div></div></div></div>';

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
                $scope.postid = function (key, UploadType) {
                    //debugger;
                    $scope.IsInitializing = true;
                    $scope.result = ''; $scope.status = 'postedc';

                    var token = $('input[name="__RequestVerificationToken"]').val();
                    var url = '/' + $scope.modelUrl+'/IDOutput' + location.search;



                   var payloaddata = { Key: key, ID: $scope.PaydInfo.PayPeriodID, __RequestVerificationToken: token };


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

                $scope.postc = function (key, UploadType) {
                    //debugger;
                    $scope.IsInitializing = true;
                    $scope.result = ''; $scope.status = 'postedc';

                    var token = $('input[name="__RequestVerificationToken"]').val();
                    var url = '/' + $scope.modelUrl+'/ParamsOutput' + location.search;
                    var payload = { PayPeriodID: $scope.PaydInfo.PayPeriodID };
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

            $scope.checkStatusInterval = function (apiTaskID, msg) {
                var stop = $interval(function () {
                    var url = '/' + $scope.modelUrl + '/ParamsOutput' + location.search;
                    var datainfo = { ApiTaskID: apiTaskID };
                    datainfo = JSON.stringify(datainfo);
                    var payloadDataInfo = { key: 'payloadStatus', Params: datainfo, __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val() };

                    $http({
                        method: 'POST',
                        url: url,
                        data: payloadDataInfo
                    }).then(function successCallback(result) {
                        if (result.data.Success) {
                            if (result.data.DownloadUrl) {
                                msg.find("div#syncExecutedMsg").html('<i class="fa fa-2x fa-check" style="color:green"> ' + result.data.Message + '</i> <br>  <a href=' + result.data.DownloadUrl + ' style="font-size:15px"> Download File</a>');


                                $scope.stopFight(stop);
                                //$scope.downloadURL = result.DownloadUrl;
                                //$scope.showdownloadlink = 'downloadlink';
                            } else {
                                msg.find("div#syncExecutedMsg").html('<i class="fa fa-2x fa-check" style="color:green"> ' + result.data.Message + '</i>');
                                $scope.stopFight(stop);
                                //$scope.message = result.Message;
                                //$scope.result = 'success';
                            }
                        }
                        else {
                            msg.find("div#syncExecutedMsg").html('<i class="fa fa-2x fa-check" style="color:green"> ' + result.data.Message + '</i>');
                            //$scope.result = 'success';
                            //$scope.message = result.Message;
                        }
                    })
                }, 20000);
                return;
            }
            $(document).on("click", "#removeSyncDiv", function (e) {
                e.preventDefault();
                $(this).closest('div#syncMessagePanel').hide();
                return;
            });
        @Html.RenderFile("~/scripts/rsforms.js")
            });

    </script>




    <link href="~/Scripts/jquery-ui/jquery-ui.css" rel="stylesheet" />
    @Scripts.Render("~/bundles/jqueryui")
End Section

