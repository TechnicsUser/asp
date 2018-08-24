var BingMapKey = "ENTER_YOUR_KEY_HERE";

var renderRequestsMap = function (divIdForMap, requestData) {
    if (requestData) {
        var bingMap = createBingMap(divIdForMap);
        addRequestPins(bingMap, requestData);
    }
}

function createBingMap(divIdForMap) {
    return new Microsoft.Maps.Map(
        document.getElementById(divIdForMap), {
            credentials: BingMapKey
        });
}

function addRequestPins(bingMap, requestData) {
    var locations = [];
    $.each(requestData, function (index, data) {
        var location = new Microsoft.Maps.Location(data.lat, data.long);
        locations.push(location);
        var order = index + 1;
        var pin = new Microsoft.Maps.Pushpin(location, { title: data.name, color: data.color, text: order.toString() });
        bingMap.entities.push(pin);
    });
    var rect = Microsoft.Maps.LocationRect.fromLocations(locations);
    bingMap.setView({ bounds: rect, padding: 80 });
}