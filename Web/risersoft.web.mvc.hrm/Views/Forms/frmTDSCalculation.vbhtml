
@imports risersoft.shared.cloud.common
@imports risersoft.app.mxform.hrm
@imports Newtonsoft.Json
@imports risersoft.shared.web.Extensions
@ModelType frmTDSCalculationModel
@Code
    ViewData("Title") = "TDSCalculation"
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
                <div class="col-md-8"><label class="control-label lbln">TDS Calculation</label></div>
            </div>


            <div class="row">
                <div class="col-md-1"></div>

                <div class="col-md-3">
                    <Label Class="control-label labeltext">Emp Code</Label>
                    <input type="text" ng-model="EmpInfo.Empcode" Class="form-control" />
                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Name</Label>
                    <input type="text" ng-model="EmpInfo.fullname" Class="form-control" />


                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Dated</Label>
                    <input type="text" ng-model="AdvanceInfo.Dated" Class="form-control my-datepicker" />


                </div>

            </div>



            <div class="row">
                <div class="col-md-1"></div>






                <div class="col-md-3">
                    <Label Class="control-label labeltext">Nearest Form 12BB</Label>
                    <select ng-model="AdvanceInfo.Form12BBIDSelected" ng-options="itemn.Dated for itemn in dsCombo.Form12BB track by itemn.Form12BBID" disabled Class="form-control"></select>
                
                </div>




                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Number of Months Zero</Label>

                    <input type="text" ng-model="AdvanceInfo.NumMonthsZero" Class="form-control" />



                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Rental Place</Label>
                    <select ng-model="AdvanceInfo.placeSelected" ng-options="iten.DisplayText for iten in ValueLists.Place.ValueListItems track by iten.DataValue" Class="form-control"></select>



                </div>
            </div>



            <div class="row">
                <div class="col-md-1"></div>

                <div class="col-md-3">
                    <Label Class="control-label labeltext">Number of Months Earn</Label>
                    <input type="text" ng-model="AdvanceInfo.NumMonthsEarn" readonly Class="form-control" />
                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext">TDS Paid Totla</Label>
                    <input type="text" ng-model="AdvanceInfo.TDSPaidTotal" readonly Class="form-control" />


                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Total Income</Label>
                    <input type="text" ng-model="AdvanceInfo.TotalIncome" readonly Class="form-control" />


                </div>

            </div>


            <div class="row">
                <div class="col-md-1"></div>

                <div class="col-md-3">
                    <Label Class="control-label labeltext">Number of Months Rate</Label>
                    <input type="text" ng-model="AdvanceInfo.NumMonthsRate" readonly Class="form-control" />
                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext">TDS Paid Rate</Label>
                    <input type="text" ng-model="AdvanceInfo.TDSPayRate" readonly Class="form-control" />


                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Total Liablility</Label>
                    <input type="text" ng-model="AdvanceInfo.TotalLiab" readonly Class="form-control" />


                </div>

            </div>
            







            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">


                    <div class="table-responsive">
                        <table class="table table-bordered table-striped space10">
                            <tr class="tbld">
                                <td>Code</td>
                                <td>Description</td>


                                <td>Input</td>
                                <td>Calc</td>
                                <td>Limit</td>
                                <td>Taken</td>
                            </tr>








                            <tr ng-repeat="row in AttTagMstr">
                                <td><label>{{row.Code}}</label></td>
                                <td><label>{{row.Description}}</label></td>
                                <td><label>{{row.Input}}</label></td>
                                <td><label>{{row.Calc}}</label></td>
                                <td><label>{{row.Limit}}</label></td>
                                <td><label>{{row.Taken}}</label></td>






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
                $scope.AdvanceInfo = $scope.model.dsForm.DT[0];
                $scope.Party = $scope.model.dsForm.party;
                $scope.dsCombo = $scope.model.dsCombo;



                $scope.ValueLists = $scope.model.ValueLists;
                $scope.EmpInfo = $scope.model.DatasetCollection.Set.Emp[0];
                $scope.AttTagMstr = $scope.model.GridViews.Item.MainGrid.myDS.dt;
               @Html.RenderLookup("AdvanceInfo", Model, Model.dsForm.Tables(0));
                $scope.AdvanceInfo.placeSelected = $.grep($scope.ValueLists.Place.ValueListItems, function (item, index) { return item.DataValue === $scope.AdvanceInfo.RentPlace })[0];

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

