$(document).ready(function () {
    var refresh;
    var defaultInterval = $('#selectRefreshTime').val();
    getCityKey();
    
    refreshData(defaultInterval);

    $('#selectRefreshTime').on('change', function () {
        if (refresh) {
            clearInterval(refresh);
        }
        var timeInterval = $('#selectRefreshTime').val();
        if (timeInterval) {
            refreshData(timeInterval);
        }
    });

    $('.search-city-btn').on('click', function (event) {
        var cityName = $('#city-input').val();
        $('table#weatherTable').css("display", "none");
        $.get("/weather/search",
            { Name: cityName },
            function (data) {
                if (data) {
                    var stringData = data; 
                    stringData = '{ "cities": ' + stringData + ' }';
                    var jsonResult = JSON.parse(stringData);
                    if (jsonResult.length === 0) {
                        alert("No cities found!");
                    }
                    $('ul#cities-list').empty();
                    jsonResult.cities.forEach(appendCity);
                } else {
                    alert('No more requests allowed!');
                }
            });
        event.preventDefault();
    });
    function refreshData(timeInterval) {
        
        refresh = setInterval(getCityKey, timeInterval);
    }
});

function getCityKey() {
    var cityKey = localStorage.getItem("cityKey");
    if (cityKey) {
        weatherDetails(cityKey);
    }
}

function appendCity(city) {
    $('ul#cities-list').append(
        $('<li>City: ' + city.LocalizedName + ' Country: ' + city.Country.LocalizedName + '</li>')
            .attr({ "data-key": city.Key })
            .click(function () {
                $('ul#cities-list').empty();
                
                localStorage.setItem("cityKey", city.Key);
                weatherDetails(city.Key);
            })
    );
}

function weatherDetails(cityKey) {
    $('#weatherTable tbody').empty();

    $.get("/weather/city",
        { cityId: cityKey },
        function (data) {
            var stringData = data;
            var weather = '{ "data": ' + stringData + ' }';
            var weatherResult = JSON.parse(weather);

            $('table#weatherTable').css("display", "table");
            $('#weatherTable tbody').append(
                $('<tr>' +
                    '<td><img src="https://developer.accuweather.com/sites/default/files/01-s.png"/>' +
                    '<p style="display: inline-block;">' +
                    weatherResult.data[0].WeatherText +
                    '</p></td>' +
                    '<td>' +
                    weatherResult.data[0].Temperature.Metric.Value +
                    '</td>' +
                    '<td>' +
                    weatherResult.data[0].RelativeHumidity +
                    '%</td>' +
                    '</tr>'
                )
            );

            $('#weatherTable td th').addClass("col-md-4");
        });
}