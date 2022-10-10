function myMap() {
    var latLong = new google.maps.LatLng(17.74042985036737, 83.23392384426505);
    var mapProp= {
        center:latLong,
        zoom:16,
    };
    var map = new google.maps.Map(document.getElementById("googleMap"),mapProp);
    new google.maps.Marker({
        position: latLong,
        map,
        title: "Hello World!",
        icon: 'https://developers.google.com/maps/documentation/javascript/examples/full/images/beachflag.png'
    });
    
    new google.maps.Marker({
        position: new google.maps.LatLng(17.74342985036740, 83.23592384426510),
        map,
        title: "Hello World!",
        icon: 'https://developers.google.com/maps/documentation/javascript/examples/full/images/beachflag.png'
    });
}