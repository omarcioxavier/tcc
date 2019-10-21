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