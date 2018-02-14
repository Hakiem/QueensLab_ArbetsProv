var defaultLatGlobal;
var defaultLngGlobal;

function initMap() {
    // Check for geolocation support
    if (navigator.geolocation) {
        // Use method getCurrentPosition to get coordinates
        navigator.geolocation.getCurrentPosition(function (position) {
            // Access them accordingly

            var defaultLatGlobal = position.coords.latitude;
            var defaultLngGlobal = position.coords.longitude;

            var myLatlng = new google.maps.LatLng(defaultLatGlobal, defaultLngGlobal);
            var myOptions = {
                zoom: 9,
                center: myLatlng,
                mapTypeId: google.maps.MapTypeId.ROADMAP,
                mapTypeControl: true,
                mapTypeControlOptions:
                {
                    style: google.maps.MapTypeControlStyle.DROPDOWN_MENU,
                    poistion: google.maps.ControlPosition.TOP_RIGHT,
                    mapTypeIds: [google.maps.MapTypeId.ROADMAP,
                    google.maps.MapTypeId.TERRAIN,
                    google.maps.MapTypeId.HYBRID,
                    google.maps.MapTypeId.SATELLITE]
                },
                navigationControl: true,
                navigationControlOptions:
                {
                    style: google.maps.NavigationControlStyle.ZOOM_PAN
                },
                scaleControl: true,
                disableDoubleClickZoom: true,
                draggable: true,
                streetViewControl: true,
                draggableCursor: 'move'
            };
            map = new google.maps.Map(document.getElementById("gmap"), myOptions);
        
            // marker refers to a global variable
            marker = new google.maps.Marker({
                position: myLatlng,
                map: map
            });

            function placeMarker(location) {
                var clickedLocation = new google.maps.LatLng(location);
                marker.setPosition(location);
            }
        });
    }
}

$(document).ready(function () {

    $('#btnRead').click(function (e) {
        e.preventDefault();
        $(this).attr("disabled", "disabled");

        $.ajax({
            url: '/Location/GetRandomCity',
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                navigator.geolocation.getCurrentPosition(function (position) {

                    var currentLat = position.coords.latitude;
                    var currentLng = position.coords.longitude;

                    $('#divMap').empty();
                    $('#rightPanel').empty();

                    var directionsService = new google.maps.DirectionsService;
                    var directionsDisplay = new google.maps.DirectionsRenderer;

                    var map = new google.maps.Map(document.getElementById('gmap'), {
                        zoom: 9,
                        center: { lat: currentLat, lng: currentLng }
                    });

                    directionsDisplay.setMap(map);

                    var start = new google.maps.LatLng(currentLat, currentLng);
                    var end   = new google.maps.LatLng(data['latitude'], data['longitude']);

                    var request = {
                        origin: start,
                        destination: end,
                        travelMode: google.maps.DirectionsTravelMode.DRIVING
                    };

                    directionsDisplay = new google.maps.DirectionsRenderer({
                        suppressMarkers: false,
                        suppressInfoWindows: true
                    });

                    directionsDisplay.setMap(map);
                    directionsDisplay.setPanel(document.getElementById('rightPanel'));

                    directionsService.route({
                        origin: start,
                        destination: end,
                        travelMode: 'DRIVING'
                    }, function (response, status) {
                            // Route the directions and pass the response to a function to create
                            // markers for each step.
                            if (status === 'OK') {
                                directionsDisplay.setDirections(response);

                                $("#rightPanelText").empty();
                                $("#rightPanelText").append('<p>This distance covers <br><kbd>'
                                    + response.routes[0].legs[0].distance.text + '</kbd> in <kbd>' + response.routes[0].legs[0].duration.text + '</kbd> by Car');

                                response.routes[0].legs[0].distance
                                console.log(response);
                            } else {
                                console.log('Directions request failed due to ' + status);
                            }
                        });
                });
            },
            accepts: {
                json: "application/json, text/javascript"
            }
        });
        setTimeout('$("#btnRead").removeAttr("disabled")', 1500);
    });

    $('#btnClear').click(function (k) {
        k.preventDefault();
  
        var noData = 'No Data Available';
        $('#rightPanel').empty().append(noData);
        $('#rightPanelText').empty().append(noData);

        initMap();
    });
});