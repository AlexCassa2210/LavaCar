$(function () {
    obtenerRegistrosPersonas();
});


/// funcion que obtiene los registros
// del metodo del controlador
// RetornaPersonasLista()
function obtenerRegistrosPersonas() {
    /////construir la dirección del método del servidor
    var urlMetodo = '/Reportes/ServiciosclienteLista'
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
        columns: [{
            field: 'Nombre_Completo',
            title: 'Nombre del Cliente'
        },
        {
            field: 'Cedula',
            title: 'Cedula'
        },
        {
            field: 'Tipo_S',
            title: 'Tipo'
        },
        {
            field: 'Cantidad_FVS',
            title: 'Cantidad'
        },
        {
            field: 'Monto_FVS',
            title: 'Monto'
        },
        ],
        filterable: true,
        toolbar: ["excel", "pdf"],
        excel: {
            fileName: "Reporte_Servicio_Cliente.xlsx",
            filterable: true,
            allPages: true
        },
        pdf: {
            fileName: "Reporte_Servicio_Cliente.pdf",
            author: "José David Fonseca Araya",
            creator: "José David Fonseca Araya",
            date: new Date(),

        }
    });
}