'use strict';


var campus = campus || {};
var map;
var bounds2;
function makeCallback(addressName) {
    var geocodeCallBack = function (results, status) {
        if (status === google.maps.GeocoderStatus.OK) {
            var marker = new google.maps.Marker({
                map: map,
                position: results[0].geometry.location,
                title: addressName,
                optimized: false
            });
            bounds2.extend(marker.position);
            map.fitBounds(bounds2);
        } else {
            console.log(addressName + ' Geocode was not successful for the following reason: ' + status);
        }

    }
    return geocodeCallBack;
}
campus.Map = {
    areas: {},
    iterator: 1,
    pathOptions: {
        strokeColor: "#FF7D4B",
        strokeWeight: 2,
        fillColor: "#FFD800",
        fillOpacity: 0.3,
        editable: true
    },
    infoWindow: new google.maps.InfoWindow(),
    init: function () {
        var self = this;
        this.map = new google.maps.Map(document.getElementById('map'), {
            center: {
                lat: 28.99,
                lng: 77.7
            },
            zoom: 12
        });
        this.drawingManager = new google.maps.drawing.DrawingManager({
            drawingControl: true,
            drawingControlOptions: {
                position: google.maps.ControlPosition.LEFT_TOP,
                drawingModes: [
					google.maps.drawing.OverlayType.POLYGON
                ]
            },
            polygonOptions: this.pathOptions
        });

        google.maps.event.addListener(this.drawingManager, 'polygoncomplete', $.proxy(this.polygonAdded, this));
        google.maps.event.addListener(this.map, 'tilesloaded', this.alignControl);
        google.maps.event.addListener(this.map, 'click', function () {
            self.infoWindow.close();
        });

        $("#map").on('change', 'input', function () {
            var value = $(this).val();
            var id = self.infoWindow.relatedPolygon.id;
            self.areas[id].areaName = value;
        });

       

        this.geocoder = new google.maps.Geocoder();
    },


    initplaces: function (){
        //places
        var elem = document.getElementById('StartingAddress');
        this.searchBox = new google.maps.places.SearchBox(elem);
        this.searchBox.addListener('places_changed', function (e) {
            debugger;
            var places = campus.Map.searchBox.getPlaces();
            if (places.length) {
                campus.Map.map.fitBounds(places[0].geometry.viewport);
            }
        });
        this.placesService = new google.maps.places.PlacesService(this.map);

    },

    alignControl: function () {
        $(".gmnoprint").each(function () {
            var margin = $(this).css('margin-left');
            if (margin === "5px")
                $(this).css('margin-left', '10px');
        })
    },

    showDrawing: function () {
        this.drawingManager.setMap(this.map);
        setTimeout(this.alignControl, 1);
    },

    polygonAdded: function (polygon) {
        polygon.id = this.iterator++;
        polygon.areaName = "Area #" + polygon.id;
        this.areas[polygon.id] = polygon;

        this.polygonAddHandlers(polygon);

        var path = polygon.getPath();
        var bounds = new google.maps.LatLngBounds();

        for (var i = 0; i < path.getLength() ; i++) {
            bounds.extend(path.getAt(i));
        }

        new google.maps.event.trigger(polygon, 'click', {
            latLng: bounds.getCenter()
        });
    },

    polygonAddHandlers: function (polygon) {
        var self = this;

        google.maps.event.addListener(polygon, 'dblclick', function (e) {
            e.stop();
            self.infoWindow.close();

            if (typeof e.vertex !== "undefined") {
                if (this.getPath().getLength() > 3) {
                    this.getPath().removeAt(e.vertex);
                } else {
                    this.setMap(null);
                    delete self.areas[this.id];
                }
            }
        });

        google.maps.event.addListener(polygon, 'click', function (e) {
            if (typeof e.vertex !== "undefined") {
                return;
            }

            self.infoWindow.relatedPolygon = this;
            self.infoWindow.setContent('Area name: <input type="text" class="areaName" value="' + this.areaName + '"/>');
            self.infoWindow.setPosition(e.latLng);
            self.infoWindow.open(self.map, polygon);
        });
    },

    getAreas: function () {
        var areas = [];
        for (var n in this.areas) {
            var area = {
                Boundary: this.mvcArrayToObject(this.areas[n].getPath()),
                AreaName: this.areas[n].areaName
            }

            areas.push(area);
        }

        return areas;
    },

    showAreas: function (areas) {
        var bounds = new google.maps.LatLngBounds();

        for (var i = 0; i < areas.length; i++) {
            var options = {
                path: areas[i].Boundary,
                areaName: areas[i].AreaName,
                id: i,
                map: this.map
            };

            options = $.extend(options, this.pathOptions);
            var polygon = new google.maps.Polygon(options);
            this.polygonAddHandlers(polygon);

            this.areas[polygon.id] = polygon;

            for (var j = 0; j < areas[i].Boundary.length; j++) {
                bounds.extend(areas[i].Boundary[j]);
            }
        }

        if (areas.length)
            this.map.fitBounds(bounds);
    },

    testIsPointInCampus: function (callback) {
        var self = this;

        var eventHandler = function (e) {
            var pos = e.latLng;

            for (var n in self.areas) {
                google.maps.event.clearInstanceListeners(self.areas[n]);
                self.polygonAddHandlers(self.areas[n]);
            }
            google.maps.event.removeListener(listener);

            callback(pos);
        }

        for (var n in this.areas) {
            google.maps.event.clearInstanceListeners(this.areas[n]);
            this.areas[n].addListener('click', eventHandler);
        }

        var listener = google.maps.event.addListenerOnce(this.map, 'click', eventHandler);
    },

    showEmployees: function (employees) {
        var bounds = new google.maps.LatLngBounds();
        for (var i = 0; i < employees.length; i++) {
            var marker = new google.maps.Marker({
                position: employees[i].Place,
                title: 'Name: ' + employees[i].FullName + ', Code: ' + employees[i].EmpCode,
                map: this.map
            });
            bounds.extend(marker.position);
        }
        this.map.fitBounds(bounds);
    },
    showEmployees2: function (employees) {
        map = this.map;
        bounds2 = new google.maps.LatLngBounds();
        for (var i = 0; i < employees.length; i++) {
            var address = employees[i].Address;
            var addressName = 'Name: ' + employees[i].FullName + ', Code: ' + employees[i].EmpCode;
            this.geocoder.geocode({ 'address': address }, makeCallback(addressName));
        }
    },
    // utils
    mvcArrayToObject: function (mvcArray) {
        var result = [];
        var arr = mvcArray.getArray();
        for (var i = 0; i < arr.length; i++) {
            var item = {
                lat: arr[i].lat(),
                lng: arr[i].lng(),
            };
            result.push(item);
        }

        return result;
    }
};