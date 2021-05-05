$(function () {
    creaValidaciones();
    creaEventos();
});

///crea las validaciones para el formulario
function creaValidaciones() {
    $("#frmEjemploPost").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {
            correo: {
                required: true,
                required: $.validator.format("Valor Requerido"),
                email: true,
                email: "Favor ingrese una dirección de correo electrónico válida"
            },
            contra: {
                required: true
            },
        }
    });
}

function creaEventos() {
    $("#btnAceptar").on("click", function () {
        var formulario = $('#frmEjemploPost');
        formulario.validate();

        if (formulario.valid()) {
            invocarMetodoPost();
        }
    });
}
///se encarga de llamar al método del controlador y procesar el resultado
function invocarMetodoPost() {
    var url = '/Login/Validar';

    var parametros = {
        correo: $("#correo").val(),
        contra: $("#contra").val(),
    };
    Ajax(url, parametros);
}

function Ajax(url, parametros) {
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            procesarResultadoMetodo(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

function procesarResultadoMetodo(data) {
    var resultadoFuncion = data;
    if (resultadoFuncion.validado == true) {
        window.location.href = resultadoFuncion.url;
    } else {
        alert('Usuario Incorrecto');
        window.location.href = resultadoFuncion.url;
    }
}