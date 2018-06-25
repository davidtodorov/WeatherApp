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
        if (localStorage.getItem("cityKey")) {
            $('table#weatherTable').css("display", "table");
        } else {
            $('table#weatherTable').css("display", "none");
        }
        
        $.get("/weather/search",
            { Name: cityName },
            function (data) {
                if (data) { 
                    if (data.length === 0) {
                        alert("No cities found!");
                    }
                    $('ul#cities-list').empty();
                    data.forEach(appendCity);
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
        $('<li>' + city.localizedName + ',' + city.country.localizedName + '</li>')
            .attr({ "data-key": city.key })
            .click(function () {
                $('ul#cities-list').empty();
                
                localStorage.setItem("cityKey", city.key);
                localStorage.setItem("cityName", city.localizedName);
                localStorage.setItem("country", city.country.localizedName);
                weatherDetails(city.key);
            })
    );
}

function weatherDetails(cityKey) {
    $('#weatherTable tbody').empty();

    $.get("/weather/city",
        { cityId: cityKey },
        function (data) {
            $('table#weatherTable').css("display", "table");
            $('th#weatherForCity').text("Weather - " + localStorage.getItem("cityName") +", "+localStorage.getItem("country"));
            $('#weatherTable tbody').append(
                $('<tr>' +
                    '<td><img src="https://developer.accuweather.com/sites/default/files/01-s.png"/>' +
                    '<p style="display: inline-block;">' +
                    data[0].weatherText +
                    '</p></td>' +
                    '<td>' +
                    data[0].temperature.metric.value + " " + data[0].temperature.metric.unit +
                    '</td>' +
                    '<td>' +
                    data[0].relativeHumidity +
                    '%</td>' +
                    '</tr>'
                )
            );

            $('#weatherTable td th').addClass("col-md-4");
        });
}