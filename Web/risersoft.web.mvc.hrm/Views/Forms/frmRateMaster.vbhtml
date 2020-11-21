
@imports risersoft.shared.cloud.common
@imports risersoft.app.mxform.hrm
@imports Newtonsoft.Json
@imports risersoft.shared.web.Extensions
@ModelType frmRateMasterModel
@Code
    ViewData("Title") = "Rate Master"
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
                <div class="col-md-8"><label class="control-label lbln">Rate Master</label></div>
            </div>


            <div class="row">
                <div class="col-md-1"></div>

                <div class="col-md-3">
                    <Label Class="control-label labeltext">Company</Label>
                    <input type="text" ng-model="PartyInfo.CompanyIDSelected.compname" readonly Class="form-control" />
                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Date</Label>
                    <input type="text" ng-model="PartyInfo.Dated" Class="form-control my-datepicker" />


                </div>





            </div>


            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">VDA</label></div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>






                <div class="col-md-3">
                    <Label Class="control-label labeltext">VDA Calculation</Label>
                    <select ng-model="PartyInfo.VDAOnActualBasicSelected" ng-options="itemn.DisplayText for itemn in ValueLists.VDAOnActualBasic.ValueListItems track by itemn.DataValue" Class="form-control"></select>

                </div>




                <div Class="col-md-3">
                    <Label Class="control-label labeltext">VDA Skill</Label>


                    <input type="text" ng-model="PartyInfo.VDASkill" Class="form-control" />


                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">VDA Semi</Label>
                    <input type="text" ng-model="PartyInfo.VDASemi" Class="form-control" />


                </div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>






                <div class="col-md-3">
                    <Label Class="control-label labeltext">VDAUnSkill</Label>
                    <input type="text" ng-model="PartyInfo.VDAUnSkill" Class="form-control" />
                </div>




                <div Class="col-md-3">
                    <Label Class="control-label labeltext">VDABaseIndex</Label>

                    <input type="text" ng-model="PartyInfo.VDABaseIndex" Class="form-control" />

                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">VDACurrentIndex</Label>
                    <input type="text" ng-model="PartyInfo.VDACurrentIndex" Class="form-control" />
                </div>
            </div>







            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Week</label></div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>






                <div class="col-md-3">
                    <Label Class="control-label labeltext">Week Start</Label>
                    <select ng-model="PartyInfo.WeekStartSelected" ng-options="itemn.descriptot for itemn in dsCombo.CalWeek track by itemn.codeword" Class="form-control"></select>

                </div>




                <div Class="col-md-3">
                    <Label Class="control-label labeltext">WeeklyOff1</Label>
                    <select ng-model="PartyInfo.WeeklyOff1Selected" ng-options="itemn.descriptot for itemn in dsCombo.CalWeek track by itemn.codeword" Class="form-control"></select>




                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext">WeeklyOff2</Label>
                    <select ng-model="PartyInfo.WeeklyOff2Selected" ng-options="itemn.descriptot for itemn in dsCombo.CalWeek track by itemn.codeword" Class="form-control"></select>


                </div>



            </div>
            <div class="row">
                <div class="col-md-1"></div>






                <div class="col-md-3">
                    <Label Class="control-label labeltext">WeeklyOFF 2 Type</Label>
                    <select ng-model="PartyInfo.WeeklyOff2TypeSelected" ng-options="itemn.descriptot for itemn in dsCombo.WeekOffType track by itemn.codeword" Class="form-control"></select>

                </div>






            </div>
            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Salary</label></div>
            </div>

            <div class="row">
                <div class="col-md-1"></div>






                <div class="col-md-3">
                    <Label Class="control-label labeltext">Maximum Early Minutes Allow</Label>
                    <input type="text" ng-model="PartyInfo.MaxEarlyMin" Class="form-control" />
                </div>











                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Allow Tolerance</Label>

                    <input type="text" ng-model="PartyInfo.AllowTol" Class="form-control" />


                </div>






                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Weekly Late Allow</Label>
                    <input type="text" ng-model="PartyInfo.WeeklyLateAllow" Class="form-control" />


                </div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>






                <div class="col-md-3">
                    <Label Class="control-label labeltext">Include Holiday With Absents</Label>
                    <select ng-model="PartyInfo.AdvCoordEmpIDSelected" ng-options="itemn.DisplayText for itemn in ValueLists.InclHDaysForAbDays.ValueListItems track by itemn.DataValue" Class="form-control"></select>

                </div>




                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Month Work Days</Label>
                    <input type="text" ng-model="PartyInfo.MonthWorkDays" Class="form-control" />




                </div>
                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Min Work Days</Label>
                    <input type="text" ng-model="PartyInfo.MinWorkDays" Class="form-control" />
                </div>
            </div>











            <div class="row">
                <div class="col-md-1"></div>




                <div class="col-md-3">
                    <Label Class="control-label labeltext">TDS Cess</Label>
                    <input type="text" ng-model="PartyInfo.TDSCess1Per" Class="form-control" />
                </div>






            </div>










            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Contractor</label></div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>






                <div class="col-md-3">
                    <Label Class="control-label labeltext">Contractor Margin %</Label>
                    <input type="text" ng-model="PartyInfo.ContractorMargin" Class="form-control" />
                </div>





                <div Class="col-md-3">
                    <Label Class="control-label labeltext">Contractor TDS %</Label>
                    <input type="text" ng-model="PartyInfo.ContractorTDS" Class="form-control" />


                </div>
            </div>






            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln"></label></div>
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

