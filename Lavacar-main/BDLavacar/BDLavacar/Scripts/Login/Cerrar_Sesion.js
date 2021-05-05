function creaEventos() {
    $("#Cerrar").on("click", function () {
     
            invocarMetodoPost();
    });
}
function invocarMetodoPost() {
    var url = '/Login/CerrarSesion';

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
    } 
}