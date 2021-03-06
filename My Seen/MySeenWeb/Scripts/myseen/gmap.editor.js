//http://gmap3.net/en/pages/19-demo/
//var lat=$map.gmap3('getLatlng').lat();
//var lon = $map.gmap3('getLatlng').lon();

var current; // current click event
var coordinates = 0;

function initialGmapEditor() {
    var menu = new Gmap3Menu($("#my_map"));
    menu.add(GmapMenuName,
        "itemA",
        function() {
            menu.close();
            addMarkerInEditor();
        });

    $("#my_map")
        .gmap3({
            map: {
                options: {
                    zoom: 2,
                    mapTypeId: window.google.maps.MapTypeId.ROADMAP
                },
                events: {
                    rightclick: function(map, event) {
                        current = event;
                        menu.open(current);
                    },
                    click: function() {
                        menu.close();
                    },
                    dragstart: function() {
                        menu.close();
                    },
                    zoom_changed: function() {
                        menu.close();
                    }
                }
            }
        });
};

function updateMarker(marker, event, context) {
    //������ ��� ������ ��������� � ���������� ���������� � ����� ����, ����� �� ���� ����
    //console.log("new position=" + marker.position);
    var $div = $(".track-id-" + context.data);
    //var id = $div.attr("id");
    //console.log("old position="+id);
    $div.attr("id", marker.position);
    //id = $div.attr("id");
    //console.log("updated position=" + id);
    calculateRoute();
};

// add marker and manage which one it is (A, B)
function addMarkerInEditor(skipCalculateRoad) {

    var info = "" + (coordinates + 1);
    var tag = "marker-" + (coordinates + 1);
    var latlng = current.latLng;
    //console.log("addMarker tag=" + tag, " latlng=" + latlng);
    // add marker and store it
    $("#my_map")
        .gmap3({
            marker: {
                latLng: latlng,
                data: info,
                options: {
                    draggable: true, //���� ������ �������
                    icon: getMarkerIcon("next")
                },
                tag: tag,
                events: {
                    mouseover: function(marker, event, context) {
                        var map = $(this).gmap3("get"),
                            infowindow = $(this).gmap3({ get: { name: "infowindow" } });
                        if (infowindow) {
                            infowindow.open(map, marker);
                            infowindow.setContent(context.data);
                        } else {
                            $(this)
                                .gmap3({
                                    infowindow: {
                                        anchor: marker,
                                        options: { content: context.data }
                                    }
                                });
                        }
                    },
                    mouseout: function() {
                        var infowindow = $(this).gmap3({ get: { name: "infowindow" } });
                        if (infowindow) {
                            infowindow.close();
                        }
                    },
                    dragend: function(marker, event, context) {
                        updateMarker(marker, event, context);
                    }
                }
            }
        });
    AddCoordinate(latlng);
    if (!skipCalculateRoad) calculateRoute();
};


function removeMarker(id) {
    //console.log("removeMarker="+id);
    jQuery("#my_map")
        .gmap3({
            clear: {
                tag: ["marker-" + id]
            }
        });
    calculateRoute();
};

function AddCoordinate(latlng) {
    coordinates++;
    //console.log("AddCoordinate");
    var $panel = $("#panelCoordinates");
    $panel.append("<div class=\"list-group-item track-id-" +
        coordinates +
        "\" \" id=\"" +
        latlng +
        "\"> <h6 class=\"list-group-item-text align-left\"><span class=\"align-center\">" +
        coordinates +
        "</span><span class=\"pull-right alert-info small\"><button class=\"btn btn-xs btn-danger\" id=\"" +
        coordinates +
        "\"><small><span class=\"glyphicon glyphicon-trash\"></span></small></button></span></h6></div>");
};

function calculateRoute() {
    //console.log("calculateRoute");
    //��������� ������� ��������� �� ����� �� ������
    var $panel = $("#panelCoordinates");
    var $rows = $panel.find("div");

    var trackCoordsLatLng = [];

    $rows.each(function(index, element) {
        var $row = $(element);
        //console.log("row=", $row);
        var id = $row.attr("id");
        //console.log("id=", id);
        id = id.replace("(", "");
        id = id.replace(")", "");
        trackCoordsLatLng.push(new window.google.maps.LatLng(id.split(",")[0], id.split(",")[1]));
    });

    clearPolylines();

    var $mapStatisticPoints = $("#mapStatisticPoints");
    var $mapStatisticDistance = $("#mapStatisticDistance");
    $mapStatisticPoints.text(trackCoordsLatLng.length);
    $mapStatisticDistance.text("0");

    if (trackCoordsLatLng.length === 0) {
        coordinates = 0;
    }
    if (trackCoordsLatLng.length > 1) {
        addPolyline(trackCoordsLatLng, "red");

        var polyline = new window.google.maps.Polyline({
            path: trackCoordsLatLng
        });
        var distance = ((window.google.maps.geometry.spherical.computeLength(polyline.getPath()) / 1000) /
        (GLanguage === "en" ? 1.66 : 1)).toString();
        if ((distance.split(".").length || distance.split(",").length) && distance.length > 5) {
            distance = distance.slice(0, 5);
        }
        $mapStatisticDistance.text(distance);
    }
};