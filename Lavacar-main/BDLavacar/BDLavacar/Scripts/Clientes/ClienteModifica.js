$(function () {
    ///llamamos a la función que se encargará de crear los eventos
    //que nos permitirán controlar cuando se haga una selección en las respectivas listas
    estableceEventosChange();
    ///Carga inicialmente la lista der provincias, ya que es 
    //la lista con la que iniciaremos.
    cargaDropdownListProvincias();
});

//función que registrará los eventos necesarios para "monitorear"
//cuando se ejecute el método change de las respectivas listas
function estableceEventosChange() {
    $("#provincia").change(function () {
        var provincia = $("#provincia").val();
        cargaDropdownListCantones(provincia);
    });
    $("#canton").change(function () {
        var canton = $("#canton").val();
        cargarDropdownListDistritos(canton);
    });
}


///carga los registros de las provincias
function cargaDropdownListProvincias() {
    ///dirección a donde se enviarán los datos
    var url = '/Clientes/RetornaProvincias';
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
            procesarResultadoProvincias(data);
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
function procesarResultadoProvincias(data) {
    var ddlProvincia = $("#provincia");
    var ddlProvinciaID = $("#hddProvinciaID").val();
    ddlProvincia.empty();
    var nuevaOpcion = "<option value=''>Seleccione una provincia</option>";
    ddlProvincia.append(nuevaOpcion);
    ///Recorre los registros
    $(data).each(function () {
        var provinciaActual = this;
        nuevaOpcion = "<option value='" + provinciaActual.id_Provincia + "'>" + provinciaActual.nombre + "</option>";
        ddlProvincia.append(nuevaOpcion);
    });
    ddlProvincia.val(ddlProvinciaID);
}

///carga los registros de los cantones
function cargaDropdownListCantones(pIdProvincia) {

    ///dirección a donde se enviarán los datos
    var url = '/Clientes/RetornaCantones';
    ///parámetros del método, es CASE-SENSITIVE
    var parametros = {
        id_Provincia: pIdProvincia
    };
    ///invocar el método
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            procesarResultadoCantones(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        },
    });
}


function procesarResultadoCantones(data) {
    var ddlCantones = $("#canton");
    var ddlCantonID = $("#hddCantonID").val();
    ddlCantones.empty();
    nuevaOpcion = "<option value=''>Seleccione un Cantón</option>";
    ddlCantones.append(nuevaOpcion);
    $(data).each(function () {
        var cantonActual = this;
        nuevaOpcion = "<option value='" + cantonActual.id_Canton + "'>" + cantonActual.nombre + "</option>";
        ddlCantones.append(nuevaOpcion);
    });
    ddlCantones.val(ddlCantonID);
}

function cargarDropdownListDistritos(pId_Canton) {
    ///dirección a donde se enviarán los datos
    var url = '/Clientes/RetornaDistritos';
    ///parámetros del método, es CASE-SENSITIVE
    var parametros = {
        id_Canton: pId_Canton
    };
    ///invocar el método
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            procesarResultadoDistritos(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        },
    });
}
function procesarResultadoDistritos(data) {
    var ddlDistritos = $("#distrito");
    var ddlDistritoID = $("#hddDistritoID").val();
    ddlDistritos.empty();
    nuevaOpcion = "<option value=''>Seleccione un Distrito</option>";
    ddlDistritos.append(nuevaOpcion);
    $(data).each(function () {
        var DistritoActual = this;
        nuevaOpcion = "<option value='" + DistritoActual.id_Distrito + "'>" + DistritoActual.nombre + "</option>";
        ddlDistritos.append(nuevaOpcion);
    });
    ddlDistritos.val(ddlDistritoID);
}
