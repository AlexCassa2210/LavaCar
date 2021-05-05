$(function () {
    obtenerRegistrosFactura();
});


/// funcion que obtiene los registros
// del metodo del controlador
// RetornaPersonasLista()
function obtenerRegistrosFactura() {
    /////construir la dirección del método del servidor
    var urlMetodo = '/Factura/KendoFacturaLista'
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
                field: 'Nombre_Completo' ,
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
                field: 'Total_F',
                title: 'Total de la factura'
            },
            {
                field: 'Fecha_F',
                title: 'Fecha de creación'
            },
            {
              
                template: function (dataItem) {
                    return "<a href='/Factura/MuestraServicios?Id_Factura_F=" + dataItem.Id_Factura_F + "'>Ver_Factura</a>"
                }
            }
        ],
        filterable: true


    });
}