'use strict';

var campus = campus || {};


campus.App = {
	init: function() {
	    campus.Map.init();
	    campus.Map.initplaces();

		campus.Map.showDrawing();

		this.route();

		//
		$("#testIsPointInCampus").on('click', $.proxy(this.testIsPointInCampus, this));
		$("#loadEmployees").on('click', $.proxy(this.loadEmployees, this));
	},

	route: function() {
        if (window.location.pathname.indexOf('/frmCampusArea/Create') >= 0) {
			this.initSubmit();
		}

		if (window.location.pathname.indexOf('/frmCampusArea/Edit/') >= 0) {
			this.initEdit();
			this.initSubmit();
		}
	},

	initEdit: function() {
		if (typeof areasJSON === "object") {
			campus.Map.showAreas(areasJSON);
		}
	},

	initSubmit: function() {
		$("#campusForm").on('submit', function(e) {
			var areas = campus.Map.getAreas();
			$("#areas").val(JSON.stringify(areas));
		});
	},

	testIsPointInCampus: function() {
		$("#testIsPointInCampus").addClass('active');
		campus.Map.testIsPointInCampus(function(pos) {
			console.log(pos.lat(), pos.lng());

			$("#testIsPointInCampus").removeClass('active');

			var url = '/IsPointInCampus/' + campusName + '/' + pos.lat() + '/' + pos.lng() + '/';

			$.get(url)
				.done(function(res) {
					if (res === 'True') {
						alert('Inside');
					} else {
						alert('Outside');
					}
				});

		});
	},

	loadEmployees: function() {
		$.get('/employees/')
			.done(function(res){
				campus.Map.showEmployees(res);
			});
	}

};



$(function() {
	campus.App.init();
})