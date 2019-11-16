$(document).ready(function () { });

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
function validarEndereco() {
    var endereco = montarEndereco();

    var urlGMapsApi = "https://maps.googleapis.com/maps/api/geocode/json?address=" + endereco + "&key=AIzaSyDoOBBqHuu3tiGZ4v46MGMN4c5J10xbntk";

    $.get(urlGMapsApi, function (data, status) {
        const latitude = Number(data.results[0].geometry.location.lat);
        const longitude = Number(data.results[0].geometry.location.lng);

        $("#hddLatitude").val(latitude);
        $("#hddLongitude").val(longitude);
        loadGMaps();
        Swal.fire({
            title: "Informação",
            text:"Confirme o endereço marcado no mapa.",
            showClass: {
                popup: 'animated fadeInDown faster'
            },
            hideClass: {
                popup: 'animated fadeOutUp faster'
            }
        });
        $("#btnSalvar").prop("disabled", false);
    });
}


// Monta o endereço com base no que foi preenchido
function montarEndereco() {
    var endereco = "";

    const logradouro = $("#txtLogradouro").val().trim();
    const numero = $("#txtNumero").val().trim();
    const bairro = $("#txtBairro").val().trim();
    const complemento = $("#txtComplemento").val().trim();
    const cep = $("#txtCep").val().trim();
    const cidade = $("#ddlCidades option:selected").text();
    const estado = $("#ddlEstados option:selected").text();

    if (logradouro != "" && logradouro != "-") {
        endereco += endereco != "" ? ", " : "";
        endereco += logradouro;
    }

    if (numero != "" && numero != "-") {
        endereco += endereco != "" ? ", " : "";
        endereco += numero;
    }

    if (bairro != "" && bairro != "-") {
        endereco += endereco != "" ? ", " : "";
        endereco += bairro;
    }

    if (complemento != "" && complemento != "-") {
        endereco += endereco != "" ? ", " : "";
        endereco += complemento;
    }

    if (cep != "" && cep != "-") {
        endereco += endereco != "" ? ", " : "";
        endereco += cep;
    }

    endereco += endereco != "" ? ", " : "";
    endereco += cidade;

    endereco += endereco != "" ? ", " : "";
    endereco += estado;

    return endereco;
}