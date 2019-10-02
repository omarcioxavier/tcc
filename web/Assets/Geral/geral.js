
$(document).ready(function () {
    try {
        SetLabels();
    } catch (err) { }
    try {
        SetTextEditors();
    } catch (err) { }
    try {
        SetMask();
    } catch (err) { }
});

var SetTextEditors = () => {
    SetDisableTextField();
}

var SetLabels = () => {
    SetStatusLabel();
}

var SetStatusLabel = () => {
    const cb = document.getElementById("SwitchStatus");
    if (cb.checked) {
        document.getElementById("lblStatus").innerHTML = "Ativo";
    }
    else {
        document.getElementById("lblStatus").innerHTML = "Inativo";
    }
}

var SetDisableTextField = () => {
    const txtBox = document.getElementsByClassName("disabled");
    for (var i = 0; i < txtBox.length; i++) {
        txtBox[i].disabled = true;
    }
}

var ConfirmDialog = (texto) => {
    bootbox.confirm("" + texto + "", function (result) {
        return;
    });
}

var SetMask = () => {
    $(".cpf").inputmask("mask", { "mask": "999.999.999-99" });
    $(".cnpj").inputmask("mask", { "mask": "99.999.999/9999-99" });
    $(".data").inputmask("mask", { "mask": "99/99/9999" });
    $(".telefone").inputmask("mask", { "mask": "(99) 9999 9999" });
    $(".celular").inputmask("mask", { "mask": "(99) 9 9999 9999" });
    $(".float").mask('#.##0,00', { reverse: true });
}