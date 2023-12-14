
    var openstreetmapUrl = 'http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png',
        openstreetmap = L.tileLayer(openstreetmapUrl, { maxZoom: 18 }),
        map = new L.Map('map', { center: new L.LatLng(40.18869647290294, 29.054207783048007), zoom: 10 }),
        drawnItems = L.featureGroup().addTo(map);

    openstreetmap.addTo(map);

    var drawControl = new L.Control.Draw({
        draw: {
            polygon: true,
            polyline: true,
            rectangle: true,
            circle: true,
            marker: true
        },
        edit: {
            featureGroup: drawnItems,
            remove: true
        }
    });

    map.addControl(drawControl);

    L.control.layers({
        'OpenStreetMap': openstreetmap,
        'Google': L.tileLayer('http://www.google.cn/maps/vt?lyrs=s@189&gl=cn&x={x}&y={y}&z={z}', {
            attribution: 'Google'
        })
    }, { 'Draw Layer': drawnItems }, { position: 'topleft', collapsed: false }).addTo(map);

    map.on('draw:created', function (e) {
        var layer = e.layer;
        drawnItems.addLayer(layer);

        var geoJSON = layer.toGeoJSON();
        var shapeType = geoJSON.geometry.type;
        var coordinates = JSON.stringify(geoJSON.geometry.coordinates);

        document.getElementById('coordinatesInput').value = coordinates;
        document.getElementById('typeInput').value = shapeType;
        document.getElementById('geometryInput').value = geoJSON.geometry;
    });
