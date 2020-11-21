
@imports risersoft.shared.cloud.common
@imports risersoft.app.mxform.hrm
@imports Newtonsoft.Json
@imports risersoft.shared.web.Extensions
@ModelType frmForm12BBModel
@Code
    ViewData("Title") = "Form12BB"
    Layout = "~/Views/Shared/_FrameworkLayout.vbhtml"

    Dim modelJson = JsonConvert.SerializeObject(Model, Formatting.Indented,
            New JsonSerializerSettings With {.StringEscapeHandling = StringEscapeHandling.EscapeHtml, .NullValueHandling = NullValueHandling.Ignore})

    'Dim modeljson = Model.SerializeJson.Replace("{{", "\u007B\u007B").Replace("}}", "\u007D\u007D")
End Code

<div class="container cbackground">
    <form action="" method="post" name="userform" ng-controller="FormController">
        @Html.AntiForgeryToken()



        <input type="hidden" id="model_json" value='@Html.Raw(modelJson)' />
        <div Class="form-horizontal">
            <div class="row cbackgroun">
                <div class="col-md-1"></div>
                <div class="col-md-8"><label class="control-label lbln">Form12BB</label></div>
            </div>


            <div class="row">
                <div class="col-md-1"></div>

                <div class="col-md-5">
                    <Label Class="control-label labeltext">FullName</Label>
                    <input type="text" ng-model="Emp.fullname" readonly Class="form-control" style="max-width: 500px;" />
                </div>



                <div Class="col-md-5">
                    <Label Class="control-label labeltext">EmpCode</Label>
                    <input type="text" ng-model="Emp.Empcode" readonly Class="form-control" style="max-width: 500px;" />


                </div>




            </div>



            <div class="row">
                <div class="col-md-1"></div>










                <div class="col-md-5">
                    <Label Class="control-label labeltext">Date</Label>
                    <input type="text" ng-model="AdvanceInfo.Dated" Class="form-control my-datepicker" style="max-width: 500px;" />
                </div>

                <div Class="col-md-5">
                    <Label Class="control-label labeltext">FinYear</Label>

                    <select ng-model="AdvanceInfo.FinyearIDSelected" ng-options="itemn.descrip for itemn in dsCombo.finyears track by itemn.finyearid" Class="form-control" style="max-width: 500px;"></select>



                </div>

            </div>







            <div class="row">
                <div class="col-md-1"></div>

                <div class="col-md-5">
                    <Label Class="control-label labeltext">LastUpdated</Label>
                    <input type="text" ng-model="AdvanceInfo.LastUpdated" readonly Class="form-control" style="max-width: 500px;" />
                </div>



                




            </div>
            <div class="row">
                <div class="col-md-1"></div>




                <div class="col-md-10">
                    <div class="table-responsive">
                        <table class="table table-bordered table-striped space10">
                            <tr class="tbld">




                                <td>TableNum</td>
                                <td>SectionNum</td>
                                <td>Nature Of Claim</td>
                                <td>Amount</td>
                                <td>Evidence/Particulars</td>
                            </tr>








                            <tr ng-repeat="row in AttTagMstr">
                                <td><label>{{row.TableNum}}</label></td>
                                <td><label>{{row.SectionNum}}</label></td>





                                <td><label>{{row.Description}}</label></td>
                                <td><input type="text" ng-hide="row.IsParent==1 || row.IsText==true" ng-model="row.Amount" class="form-control numeric" /></td>
                                <td><input type="text" ng-hide="row.IsParent==1" ng-model="row.Evidence" class="form-control" /></td>






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
        rsApp.controller('FormController', function ($scope,$http) {
            $scope.model = JSON.parse($("#model_json").val());
            $scope.data = "This is data come from json";



            var loadmodel = function (result) {
                $scope.model = result;

                $scope.AdvanceInfo = $scope.model.dsForm.DT[0];
                $scope.AttTagMstr = $scope.model.dsForm.item;
                $scope.dsCombo = $scope.model.dsCombo;

                $scope.Emp = $scope.model.DatasetCollection.Set.Emp[0];
              
               @Html.RenderLookup("AdvanceInfo", Model, Model.dsForm.Tables(0));
               
            }



            loadmodel($scope.model);
            $scope.GenerateDelPayload = function () {
                var payload = { EntityKey: 'Form12BB', ID: $scope.model.dsForm.DT[0].Form12BBID, AcceptWarning: false };
                return payload;
            };
            $scope.calculateAll = function () {
              
            };
        $scope.calculateAll();
        $scope.cleanupmodel = function (datamodel) {
            //empty function
        };
        $scope.calculatemodel = function () {
            $scope.calculateAll();
        };
        $scope.visdel = true; $scope.visdelete = false;
        @Html.RenderFile("~/scripts/rsforms.js")
            });

    </script>
End Section

