
@imports risersoft.shared.cloud.common
@imports risersoft.app.mxform.hrm
@imports Newtonsoft.Json
@imports risersoft.shared.web.Extensions
@ModelType frmPayProjectionModel
@Code
    ViewData("Title") = "Pay Projection"
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
                <div class="col-md-8"><label class="control-label lbln">Pay Projection</label></div>
            </div>
            <div class="row marb" style="padding:15px;">







                <div class="col-md-1"></div>
                <div class="col-md-13">

                    <div class="tab-content">





                        <div class="row">
                            <div class="col-md-1"></div>
                            <div Class="col-md-3">
                                <Label Class="control-label">Company</Label>
                                <select ng-model="PayProjInfo.CompanyIDSelected" ng-options="itemn.CompName for itemn in dsCombo.Company track by itemn.CompanyID" Class="form-control"></select>
                            </div>
                            <div class="col-md-3">
                                <Label Class="control-label">Increment Frequency</Label>
                                <input type="text" ng-model="PayProjInfo.IncFreq" Class="form-control" />
                            </div>
                            <div Class="col-md-3">
                                <Label Class="control-label">Target Date</Label>
                                <input type="text" ng-model="PayProjInfo.TargetDate" Class="form-control my-datepicker" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-1"></div>

                            <div class="col-md-3">
                                <Label Class="control-label">Start Date</Label>
                                <input type="text" ng-model="PayProjInfo.StartDate" Class="form-control my-datepicker" />
                            </div>


                        </div>








                        <div class="row cbackgroun">
                            <div class="col-md-1"></div>
                            <div class="col-md-8"><label class="control-label lbln">Employees</label></div>
                        </div>



                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="col-md-10">


                                <div class="table-responsive">
                                    <table class="table table-bordered table-striped space10">
                                        <tr class="tbld">
                                            <td>EmpCode</td>
                                            <td>FullName</td>
                                            <td>TargetSal</td>



                                        </tr>








                                        <tr ng-repeat="row in ListEmp">
                                            <td><label>{{row.EmpCode}}</label></td>
                                            <td><label>{{row.FullName}}</label></td>
                                            <td><label>{{row.TargetSal}}</label></td>






                                        </tr>


                                    </table>
                                </div>
                            </div>

                        </div>















                        <div class="row cbackgroun">
                            <div class="col-md-1"></div>
                            <div class="col-md-10"><label class="control-label lbln">Proposal</label> <Button type="button" id="items" Class="btn btn-primary btnf" ng-click="postc()" style="margin-top:5px;margin-bottom:5px;float:right">ADD</Button></div>
                        </div>





                        <div Class="row">


                            <div Class="col-md-1"></div>
                            <div Class="col-md-3">
                                <Label Class="control-label">Company</Label>
                                <select ng-model="PayProjInfo.ContractorIDSelected" ng-options="itemn.partyName for itemn in dsCombo.party track by itemn.vendorid" Class="form-control"></select>

                            </div>

                            <div class="col-md-3">
                                <label class="control-label">Date</label>
                                <input type="text" ng-model="PayProjInfo.CareOf" class="form-control" />
                            </div>
                            <div class="col-md-3">
                                <label class="control-label">Type</label>
                                <select ng-model="PayProjInfo.RelationShipSelected" ng-options="camp.DisplayText for camp in ValueLists.Relationship.ValueListItems track by camp.DataValue" Class="form-control"></select>
                            </div>

                        </div>
                        <div Class="row">


                            <div Class="col-md-1"></div>
                            <div Class="col-md-3">
                                <Label Class="control-label">Enforce On</Label>
                                <select ng-model="PayProjInfo.ContractorIDSelected" ng-options="itemn.partyName for itemn in dsCombo.party track by itemn.vendorid" Class="form-control"></select>

                            </div>

                            <div class="col-md-3">
                                <label class="control-label">Refrence PayPeroid</label>
                                <input type="text" ng-model="PayProjInfo.CareOf" class="form-control" />
                            </div>
                            <div class="col-md-3">
                                <label class="control-label">Last PayPeriod</label>
                                <select ng-model="PayProjInfo.RelationShipSelected" ng-options="camp.DisplayText for camp in ValueLists.Relationship.ValueListItems track by camp.DataValue" Class="form-control"></select>
                            </div>

                        </div>
                        <div Class="row">


                            <div Class="col-md-1"></div>
                            <div Class="col-md-3">
                                <Label Class="control-label">Proposed RateMaster</Label>
                                <select ng-model="PayProjInfo.ContractorIDSelected" ng-options="itemn.partyName for itemn in dsCombo.party track by itemn.vendorid" Class="form-control"></select>

                            </div>




                        </div>





                    </div>
                </div>






            </div>


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
                $scope.PayProjInfo = $scope.model.dsForm.DT[0];

                $scope.dsCombo = $scope.model.dsCombo;




                $scope.ListEmp = $scope.model.GridViews.ListEmp.MainGrid.myDS.dt;
                $scope.PayProp = $scope.model.GridViews.PayProp.MainGrid.myDS.dt;







                $scope.ValueLists = $scope.model.ValueLists;

               @Html.RenderLookup("PayProjInfo", Model, Model.dsForm.Tables(0));




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