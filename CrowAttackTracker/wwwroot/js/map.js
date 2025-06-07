console.log("map.js loaded");

let dotNetRef = null;
let map, heat;

window.initMap = (ref) => {
    dotNetRef = ref;

    map = L.map('map').setView([59.91, 10.75], 12);
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; OpenStreetMap contributors'
    }).addTo(map);

    heat = L.heatLayer([], { radius: 25 }).addTo(map);

    map.on('click', function (e) {
        const latlng = e.latlng;
        L.marker(latlng).addTo(map);
        heat.addLatLng([latlng.lat, latlng.lng]);
        if (dotNetRef) {
            dotNetRef.invokeMethodAsync("OnMapClick", latlng.lat, latlng.lng);
        }
    });
};

window.getUserLocation = () => {
    if (!navigator.geolocation) {
        alert("Geolocation not supported.");
        return;
    }
    navigator.geolocation.getCurrentPosition(position => {
        const lat = position.coords.latitude;
        const lng = position.coords.longitude;

        L.marker([lat, lng]).addTo(map);
        heat.addLatLng([lat, lng]);

        dotNetRef?.invokeMethodAsync("OnMapClick", lat, lng);
    }, err => {
        alert("Location error: " + err.message);
    });
};

window.panToLocation = (lat, lng) => {
    if (map) {
        map.setView([lat, lng], 14); // Zoom in a bit more
        L.marker([lat, lng]).addTo(map);
        heat.addLatLng([lat, lng]);
    }
};