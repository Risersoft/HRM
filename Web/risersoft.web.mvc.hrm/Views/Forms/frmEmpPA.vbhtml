
@imports risersoft.shared.cloud.common
@imports risersoft.app.mxform.hrm
@imports Newtonsoft.Json
@imports risersoft.shared.web.Extensions
@ModelType frmEmpPAModel
@Code
    ViewData("Title") = "EmployeePA"
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
                <div class="col-md-8"><label class="control-label lbln">Employee Garding</label></div>
            </div>
            <div class="row marb" style="padding:15px;">







                <div class="col-md-1"></div>
                <div class="col-md-13">

                    <div class="tab-content">





                        <div class="row">
                            <div class="col-md-1"></div>
                            <div Class="col-md-3">
                                <Label Class="control-label labeltext">Name: </Label>     {{EmpRow.FullName}}

                            </div>
                            <div class="col-md-3">
                                <Label Class="control-label labeltext">Dep: </Label>    {{EmpRow.Depname}}

                            </div>
                            <div Class="col-md-3">
                                <Label Class="control-label labeltext">Code :</Label>    {{EmpRow.EmpCode}}

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-1"></div>





                            <div class="col-md-3">
                                <Label Class="control-label labeltext">Grade</Label>
                                <select ng-model="PartyInfo.gradeSelected" ng-options="camp.DisplayText for camp in ValueLists.Grade.ValueListItems  track by camp.DataValue" Class="form-control"></select>
                            </div>
                            <div Class="col-md-3">
                                <Label Class="control-label labeltext">Remark</Label>
                                <input type="text" ng-model="PartyInfo.remark" Class="form-control" />
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
                $scope.PartyInfo = $scope.model.dsForm.DT[0];
                $scope.EmpRow = $scope.model.DatasetCollection.EmpRow.EmpRow[0];
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