'use strict';

var campus = campus || {};


campus.App = {
    init: function () {
        campus.Map.init();
        campus.Map.showDrawing();

        this.loadEmployees();
    },


    loadEmployees: function () {
        if (typeof empJSON === "object") {
            //campus.Map.showEmployees2(empJSON);
            campus.Map.showEmployees(empJSON);
        }
    }

};



$(function () {
    campus.App.init();
})