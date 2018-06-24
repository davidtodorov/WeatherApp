$(document).ready(function () {

    $('.search-city-btn').on('click', function (event) {
        var cityName = $('#city-input').val();

        $.get("/weather/search",
            { Name: cityName },
            function (data) {
                if (data.result) {
                    var stringData = data.result; // todo: add .result
                    stringData = '{ "cities": ' + stringData + ' }';
                    var jsonResult = JSON.parse(stringData);

                    $('ul#cities-list').empty();

                    jsonResult.cities.forEach(appendCity);
                } else {
                    alert('No more requests allowed!');
                }
            });
        event.preventDefault();
    });
});

function appendCity(city) {
    $('ul#cities-list').append(
        $('<li>City: ' + city.LocalizedName + ' Country: ' + city.Country.LocalizedName + '</li>')
            .attr({ "data-key": city.Key })
            .click(function () {
                $('ul#cities-list').empty();
                weatherDetails(city);
            })
    );
}

function weatherDetails(city) {
    $.get("/weather/city",
        { Id: city.Key },
        function (data) {
            var stringData = data.result;
            var weather = '{ "data": ' + stringData + ' }';
            var weatherResult = JSON.parse(weather);
            $('#weatherTable tbody').append(
                $('<tr>' +
                    '<td>' +
                    weatherResult.data[0].WeatherText +
                    '</td>' +
                    '<td>' +
                    weatherResult.data[0].Temperature.Metric.Value +
                    '</td>' +
                    '<td>' +
                    weatherResult.data[0].Temperature.RelativeHumidity +
                    '</td>' +
                    '</tr>'
                )
            );
        });
}