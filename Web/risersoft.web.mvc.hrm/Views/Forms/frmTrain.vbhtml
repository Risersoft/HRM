
@imports risersoft.shared.cloud.common
@imports risersoft.app.mxform.hrm
@imports Newtonsoft.Json
@imports risersoft.shared.web.Extensions
@ModelType frmTrainModel
@Code
    ViewData("Title") = "Training"
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
                <div class="col-md-8"><label class="control-label lbln">Training</label></div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">

                    <label class="control-label labeltext">Date</label>
                    <input type="text" ng-model="PartyInfo.Dated" class="form-control my-datepicker" />
                </div>







                <div class="col-md-3">
                    <label class="control-label labeltext">Duration</label><input type="text" ng-model="PartyInfo.Durations" class="form-control" />
                </div>






                <div class="col-md-3">
                    <label class="control-label labeltext">Faculty</label>
                    <input type="text" ng-model="PartyInfo.Faculty" class="form-control" />
                </div>

            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-3">

                    <label class="control-label labeltext">Topic</label>
                    <input type="text" ng-model="PartyInfo.Topic" class="form-control" />
                </div>







                <div class="col-md-3">
                    <label class="control-label labeltext">Place</label><input type="text" ng-model="PartyInfo.Place" class="form-control" />
                </div>






                <div class="col-md-3">
                    <label class="control-label labeltext">Description<span class="red">*</span></label>
                    <input type="text" ng-model="PartyInfo.Descrip" class="form-control" />
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

