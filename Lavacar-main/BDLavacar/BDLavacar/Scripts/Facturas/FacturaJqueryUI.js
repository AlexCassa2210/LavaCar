$(function () {
    creaElementosJqueryUI();

});
///Función que crea los elementos de jqueryUI
function creaElementosJqueryUI() {

    ///cargar las provincias y posteriormente asignarlas al autocomplete
    cargarPersona();
    cargarVehiculo();
}


function cargarPersona() {
    ///dirección a donde se enviarán los datos
    var url = '/Factura/RetornaPersona';
    ///parámetros del método, es CASE-SENSITIVE
    var parametros = {
    };
    ///invocar el método
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            crearAutoComplete(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        },
    });
}

function cargarVehiculo() {
    ///dirección a donde se enviarán los datos
    var url = '/Factura/RetornaVehiculo';
    ///parámetros del método, es CASE-SENSITIVE
    var parametros = {
    };
    ///invocar el método
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            crearAutoCompleteCar(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        },
    });
}
/*
 * toma el resultado del método RetornaProvincias
 * y lo procesa, recorriendo cada posición
 */
function crearAutoComplete(data) {
    var datosAutocomplete = $.map(data, function (item) {
        return {
            label: item.Nombre_P,
            id_Persona: item.Id_Cliente_P
        }
    });
    $("#txtPersona").autocomplete({
        source: datosAutocomplete,
        select: function (event, ui) {
            $("#txtId_Persona").val(ui.item.id_Persona);
        }
    });
}

/*
 * toma el resultado del método Vehiculo
 * y lo procesa, recorriendo cada posición
 */
function crearAutoCompleteCar(data) {
    var datosAutocompleteCar = $.map(data, function (item) {
        return {
            label: item.Placa_V,
            id_Vehiculo: item.Id_Vehiculo_V
        }
    });
    $("#txtVehiculo").autocomplete({
        source: datosAutocompleteCar,
        select: function (event, ui) {
            $("#txtId_Vehiculo").val(ui.item.id_Vehiculo);
        }
    });
}