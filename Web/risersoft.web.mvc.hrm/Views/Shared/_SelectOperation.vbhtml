﻿<label class="control-label">Scope</label>
<select name="scope" ng-model="model.OperationSelected" ng-options="rchrg.DisplayText for rchrg in ValueLists.Operation.ValueListItems track by rchrg.DataValue " Class="form-control"></select>

<label class="control-label">Period</label>


<select name="prchrg" ng-model="model.PeriodSelected" ng-options="prchrg.DisplayText for prchrg in ValueLists.Period.ValueListItems track by prchrg.DataValue " Class="form-control" ng-change="cdata(model.PeriodSelected)"></select>
<br />
<label class="control-label" ng-show="dispd">From</label>
<select ng-show="dispd" ng-model="model.fromperiodidSelected" ng-options="itemt.ret_pd for itemt in dsCombo.PostPeriod track by itemt.PostPeriodID" Class="form-control"></select>


<label class="control-label" ng-show="dispd">To</label>
<select ng-show="dispd" ng-model="model.toperiodidSelected" ng-options="item.ret_pd for item in dsCombo.PostPeriod track by item.PostPeriodID" Class="form-control"></select>