﻿<div id="dialog-confirm"></div>




<div Class="row marb">


    <a ng-show="ShowAddMore" ng-click="nform()" style="margin-bottom: 16px;" class="btn btn-default btnm">Add New</a><button type="button" ng-show="model.frmMode==1 && visdel" id="btndele" ng-click="btndel()" Class="btn btne">Delete</button><button type="button" ng-disabled="(status=='posted')" id="btnsave" Class="btn btn-primary btnf" ng-click="btnsave()">Save</button>
    <div id="loading" class="row marb" ng-show="(status=='posted')">
        <div class="col-md-12" id="loading-text"><img src="~/Content/images/imgechange.gif" ng-show="(status=='posted')" width="80" height="80" /></div>
    </div>

   

    <button type="button" id="btnback" onclick="window.history.back()" style="margin-bottom: 16px;" Class="btn btn-primary btnf">Back</button>


</div>
<i class="fa fa-2x fa-check" id="status" style="margin-top:-58px;margin-left: 135px;" ng-show="(result=='success')">Success</i>
<i class="fa fa-2x fa-remove" id="failure" style="margin-top:-58px;margin-left: 135px;" ng-show="(result=='failure')">Failure</i>
<div class="row" style="color: red;
    
    margin-left: 40px;">{{message}}</div>
