async function success(pos) {
    var crd = pos.coords;
    const weatherData = await WeatherHelper.dotNetObject.invokeMethodAsync(`GetWeatherData`, crd.latitude, crd.longitude);
    console.log(`Longitude ${crd.longitude}, latitude ${crd.latitude}`);
    document.getElementById(`weatherInfo`).innerText = weatherData;
}

function error(err) {
    document.getElementById(`weatherInfo`).innerText = `Couldn't get current location, no weather to show.`;
    console.warn(`ERROR(${err.code}): ${err.message}`);
}

class WeatherHelper {
    static dotNetObject;

    static getCurrentCoordinates(dotNetObjectRef) {
        WeatherHelper.dotNetObject = dotNetObjectRef;
        var options = {
            enableHighAccuracy: true,
            timeout: 10000,
            maximumAge: 0
        };
        navigator.geolocation.getCurrentPosition(success, error, options);
    }
}

window.WeatherHelper = WeatherHelper;