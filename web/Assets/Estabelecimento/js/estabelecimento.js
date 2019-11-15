$(document).ready(function () {});

// Obtém as cidades de acordo com o estado selecionado
$("#ddlEstados").on("change", function () {
    const estadoID = $('#ddlEstados').val();
    $.ajax({
        type: "GET",
        data: { id: estadoID },
        url: "../cidade/getByEstadoId",
        success: function (result) {
            var c = '';
            for (var i = 0; i < result.length; i++) {
                c += '<option value ="' + result[i].cidadeID + '">' + result[i].nome + '</option>';
            }
            $('#ddlCidades').html(c);
        }
    });
});

// Carrega o endereço no maps de acordo com as coordenadas
function loadGMaps() {
    const latitude = Number($("#hddLatitude").val().replace(",", "."));
    const longitude = Number($("#hddLongitude").val().replace(",", "."));

    var mapProp = {
        center: new google.maps.LatLng(latitude, longitude),
        zoom: 15,
    };

    var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
    var marker = new google.maps.Marker({ position: mapProp.center });
    marker.setMap(map);
}

// Valida o endereço com o google maps
function VerificarEndereco() {
    var endereco = "";

    var urlGMapsApi = "https://maps.googleapis.com/maps/api/geocode/json?address=" + endereco + "&key=AIzaSyDoOBBqHuu3tiGZ4v46MGMN4c5J10xbntk";

    $.get(urlGMapsApi, function (data, status) {
        console.log(status);
        console.log(data);
    });
}