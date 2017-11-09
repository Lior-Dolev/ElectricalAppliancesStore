jQuery(function ($) {
    // Asynchronously Load the map API 
    var script = document.createElement('script');
    script.src = "//maps.googleapis.com/maps/api/js?sensor=false&callback=initialize&key=AIzaSyBu1J5q1yWhhs-49hv7GmpGQaklHmxaYWk";
    document.body.appendChild(script);
});

function initialize() {
    $.ajax({
        url: "/Manager/GetBranches", success: function (result) {
            initialize2(result);
        }
    });
}

function initialize2(Branches) {
    console.log(Branches);
    var map;
    var bounds = new google.maps.LatLngBounds();
    var mapOptions = {
        mapTypeId: 'roadmap'
    };

    // Display a map on the page
    map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);
    map.setTilt(45);

    // Info Window Content
    var infoWindowContent = [];
    for (i = 0; i < Branches.length; i++) {
        var branch = Branches[i]

        var html = ['<div class="info_content">' +
            '<h3>' + branch.Name + '</h3>' +
            '<p>' + branch.LocationDescription + '</p>' + '</div>']

        infoWindowContent.push(html);
    }

    // Display multiple markers on a map
    var infoWindow = new google.maps.InfoWindow(), marker, i;

    // Loop through our array of markers & place each one on the map  
    for (i = 0; i < Branches.length; i++) {
        var position = new google.maps.LatLng(Branches[i].LocationCoordinates[0], Branches[i].LocationCoordinates[1]);
        bounds.extend(position);
        marker = new google.maps.Marker({
            position: position,
            map: map,
            title: Branches[i].LocationDescription
        });

        // Allow each marker to have an info window    
        google.maps.event.addListener(marker, 'click', (function (marker, i) {
            return function () {
                infoWindow.setContent(infoWindowContent[i][0]);
                infoWindow.open(map, marker);
            }
        })(marker, i));

        // Automatically center the map fitting all markers on the screen
        map.fitBounds(bounds);
    }

    // Override our map zoom level once our fitBounds function runs (Make sure it only runs once)
    var boundsListener = google.maps.event.addListener((map), 'bounds_changed', function (event) {
        this.setZoom(14);
        google.maps.event.removeListener(boundsListener);
    });

}