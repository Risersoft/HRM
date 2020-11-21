
@imports risersoft.shared.cloud.common
@imports risersoft.app.mxform.hrm
@imports Newtonsoft.Json
@imports risersoft.shared.web.Extensions
@ModelType frmPayslipWOTModel
@Code
    ViewData("Title") = "PaySlipWOT"
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
                <div class="col-md-8"><label class="control-label lbln">PaySlipWOT</label></div>
            </div>


            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-10">


                    <div class="table-responsive">
                        <table class="table table-bordered table-striped space10">
                            <tr class="tbld">
                                <td>EmpCode</td>
                                <td>FullName</td>


                                <td>DepName</td>
                                <td>EWDay</td>
                                <td>Payment Thru</td>
                                <td>PersonalExpense</td>
                            </tr>








                            <tr ng-repeat="row in AttTagMstr">
                                <td><label>{{row.EmpCode}}</label></td>
                                <td><label>{{row.FullName}}</label></td>
                                <td><label>{{row.DepName}}</label></td>
                                <td><label>{{row.EWDay}}</label></td>
                                <td><label>{{row.PaymentThru}}</label></td>
                                <td><label>{{row.PersonalExpense}}</label></td>






                            </tr>


                        </table>
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-md-1"></div>

                <div class="col-md-3">
                    <Label Class="control-label labeltext">Rate Rs.Per Day</Label>
                    <input type="text" ng-model="AdvanceInfo.Rate" Class="form-control" />
                </div>



                <div Class="col-md-3">
                    <Label Class="control-label labeltext"></Label>
                    <input type="button" value="Update" style="margin-top:31px" Class="btn btn-primary" />


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
                $scope.AttTagMstr = $scope.model.GridViews.PayslipWOT.MainGrid.myDS.dt;
               @Html.RenderLookup("AdvanceInfo", Model, Model.dsForm.Tables(0));

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

