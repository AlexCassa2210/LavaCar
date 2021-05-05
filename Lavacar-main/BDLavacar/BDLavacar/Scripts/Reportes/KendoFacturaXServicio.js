$(function () {
    obtenerRegistrosFactura();
});


/// funcion que obtiene los registros
// del metodo del controlador
// RetornaPersonasLista()
function obtenerRegistrosFactura() {
    /////construir la dirección del método del servidor
    var urlMetodo = '/Factura/MuestraServiciosLista'
    var parametros = {};
    var funcion = creaGridKendo;
    ///ejecuta la función $.ajax utilizando un método genérico
    //para no declarar toda la instrucción siempre
    ejecutaAjax(urlMetodo, parametros, funcion);
}
///encargada de crear el grid de kendo y mostrar
//los datos obtenidos al llamar al método
// RetornaListaClientes
function creaGridKendo(data) {


    $("#divKendoGrid").kendoGrid({
        dataSource: {
            data: data.resultado,
            pageSize: 10
        },
        pageable: true,
        columns: [
            {
                field: 'Id_Factura_F',
                title: '#_Factura'
            }, {
                field: 'Nombre_Completo',
                title: 'Nombre del Cliente'
            },
            {
                field: 'Cedula_P',
                title: 'Cedula'
            },
            {
                field: 'Tipo_MV',
                title: 'Marca'
            },
            {
                field: 'Placa_V',
                title: 'Placa'
            },
            {
                field: 'Tipo_S',
                title: 'Servicio'
            },
            {
                field: 'Cantidad_FVS',
                title: 'Cantidad'
            },
            {
                field: 'Estado_FVS',
                title: 'Estado'
            },
            {
                field: 'Monto_FVS',
                title: 'Monto'
            },
            {

                template: function (dataItem) {
                    return "<a href='/Factura/ModificaServicioFactura?Id_Servicio_S=" + dataItem.Id_Servicio_S + "' class='btn btn-info'>Modificar</a>"
                }
            },
                {
                template: function (dataItem) {
                        return "<a href='/Factura/EliminaServicioFactura?Id_Servicio_S=" + dataItem.Id_Servicio_S + "' class='btn btn-danger'>Eliminar</a>"
                }
            }
        ],
        filterable: true


    });
}