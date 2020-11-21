
@imports risersoft.shared.cloud.common
@imports risersoft.app.mxform.hrm
@imports Newtonsoft.Json
@imports risersoft.shared.web.Extensions
@ModelType frmLeaveNCashModel
@Code
    ViewData("Title") = "Leave And Cash"
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
                <div class="col-md-8"><label class="control-label lbln">LeaveNCash</label></div>
            </div>


            <div class="row">
                <div class="col-md-1"></div>

                <div class="col-md-3">
                    <Label Class="control-label labeltext">Emp Code : </Label>   {{ContextRow.EmpCode}}

                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Name : </Label>   {{ContextRow.FullName}}



                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Leave Master : </Label>    {{ContextRow.EmpCode}}



                </div>
            </div>
            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">LeaveEncashment</label></div>
            </div>


            <div class="row">
                <div class="col-md-1"></div>

                <div class="col-md-3">
                    <Label Class="control-label labeltext">Dated</Label>
                    <input type="text" ng-model="PartyInfo.CardNum" Class="form-control my-datepicker" />
                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Leaves Encashed</Label>
                    <input type="text" ng-model="PartyInfo.CardNum" Class="form-control" />


                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Leave Type</Label>
                    <select ng-model="PartyInfo.ShiftIDSelected" ng-options="itemn.shift for itemn in dsCombo.shift track by itemn.shiftid" Class="form-control"></select>


                </div>
            </div>



            <div class="row">
                <div class="col-md-1"></div>

                <div class="col-md-3">
                    <Label Class="control-label labeltext">Amount Prev</Label>
                    <input type="text" ng-model="PartyInfo.CardNum" readonly Class="form-control" />
                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Amount New</Label>
                    <input type="text" ng-model="PartyInfo.CardNum" readonly Class="form-control" />


                </div>

            </div>

            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">LeaveLedger</label></div>
            </div>

            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">


                    <div class="table-responsive">
                        <table class="table table-bordered table-striped space10">
                            <tr class="tbld">
                                <td>TagType</td>
                                <td>FullTag</td>
                                <td>MaxAccure</td>


                                <td>Accure Type</td>
                                <td>LvePeriodType</td>
                                <td>LvePeriodNum</td>
                                <td>LveDue</td>
                                <td>CountOnlyWork</td>
                                <td>CarryForwardLimit</td>
                                <td>AllowEncashLM</td>


                                <td>AllowEncashFF</td>
                                <td>LeaveGroup</td>

                                <td>UserLeaveGroup</td>
                                <td></td>
                            </tr>








                            <tr ng-repeat="row in AttTagMstr">
                                <td><label>{{row.TagType}}</label></td>
                                <td><label>{{row.FullTag}}</label></td>
                                <td><label>{{row.MaxAccrue}}</label></td>
                                <td><label>{{row.AccrueType}}</label></td>
                                <td><label>{{row.LvePeriodType}}</label></td>
                                <td><label>{{row.LvePeriodNum}}</label></td>
                                <td><label>{{row.LveDue}}</label></td>
                                <td><label>{{row.CountOnlyWork}}</label></td>
                                <td><label>{{row.CarryForwardLimit}}</label></td>
                                <td><label>{{row.AllowEncashLM}}</label></td>
                                <td><label>{{row.AllowEncashFF}}</label></td>
                                <td><label>{{row.LeaveGroup}}</label></td>
                                <td><label>{{row.UseLeaveGroup}}</label></td>
                                <td><a href="">Edit</a></td>





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
                $scope.ContextRow = $scope.model.pViewState.ContextRow.valuebag;
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

