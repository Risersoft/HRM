@imports risersoft.shared.cloud.common
@imports risersoft.app.mxform
@imports Newtonsoft.Json
@imports risersoft.shared.web.Extensions
@ModelType frmDepModel
@Code
    ViewData("Title") = "Department"
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
                <div class="col-md-8"><label class="control-label lbln">Department</label></div>
            </div>


            <div class="row">
                <div class="col-md-1"></div>

                <div class="col-md-3">
                    <Label Class="control-label labeltext">Code</Label>
                    <input type="text" ng-model="PartyInfo.DepCode" Class="form-control " />
                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Department Name</Label>
                    <input type="text" ng-model="PartyInfo.DepName" Class="form-control " />


                </div>




                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Attendance CoOrdinator</Label>


                    <select ng-model="PartyInfo.AttCoordEmpIDSelected" ng-options="camp.descrip for camp in dsCombo.empatt  track by camp.employeeid" Class="form-control"></select>
                </div>
            </div>



            <div class="row">
                <div class="col-md-1"></div>






                <div class="col-md-3">
                    <Label Class="control-label labeltext">Email</Label>
                    <input type="text" ng-model="PartyInfo.AttCoordEmpIDSelected.companyemail" readonly Class="form-control" />
                </div>




                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Advance CoOrdinator</Label>

                    <select ng-model="PartyInfo.AdvCoordEmpIDSelected" ng-options="itemn.descrip for itemn in dsCombo.empadv track by itemn.employeeid" Class="form-control"></select>



                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">User Name</Label>
                    <input type="text" ng-model="PartyInfo.AdvCoordEmpIDSelected.username" readonly Class="form-control" />


                </div>
            </div>




            <div class="row">
                <div class="col-md-1"></div>

                <div class="col-md-3">
                    <Label Class="control-label labeltext">OU</Label>
                    <select ng-model="PartyInfo.OUSelected" ng-options="itemn.DisplayText for itemn in ValueLists.OU.ValueListItems track by itemn.DataValue" Class="form-control"></select>
                </div>





            </div>


            <div class="row">
                <div class="col-md-1"></div>


                <div class="col-md-5">

                    In Quality List <input type="checkbox" ng-model="PartyInfo.InQualityList" /><br />
                    In Sales List <input type="checkbox" ng-model="PartyInfo.InSalesList" /><br />
                    Do Not Track Attendance <input type="checkbox" ng-model="PartyInfo.DoNotTrackAtt" /><br />
                    Not Shown in Employee Department Selection <input type="checkbox" ng-model="PartyInfo.NotInList" /><br />
                    In Purch List <input type="checkbox" ng-model="PartyInfo.InPurchList" /><br />




                    In Design List <input type="checkbox" ng-model="PartyInfo.InDesignList" /><br />
                    Bank Non Prod <input type="checkbox" ng-model="PartyInfo.BankNonProd" /><br />
                </div>









            </div>


            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Shop/Stores</label></div>
            </div>

            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">


                    <div class="table-responsive">
                        <table class="table table-bordered table-striped space10">
                            <tr class="tbld">
                                <td>Sys</td>
                                <td>Dep Code</td>


                                <td>DepName</td>
                            </tr>








                            <tr ng-repeat="row in AttTagMstr">
                                <td><label>{{row.TagType}}</label></td>
                                <td><label>{{row.FullTag}}</label></td>
                                <td><label>{{row.MaxAccrue}}</label></td>






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
                $scope.PartyInfo = $scope.model.dsForm.DT[0];
                $scope.Party = $scope.model.dsForm.party;
                $scope.dsCombo = $scope.model.dsCombo;

                $scope.ValueLists = $scope.model.ValueLists;

               @Html.RenderLookup("PartyInfo", Model, Model.dsForm.Tables(0));

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

