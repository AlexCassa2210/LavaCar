$(function () {

    validacion();

});

function validacion() {
    $("#frmVehiculoModifica").validate({

        rules: {
            //Etique name para validar
            Placa_V: {
                required: true,
                minlength: 4,
                maxlength: 6
            },
            Id_Marca_MV: {
                required: true
            },
            Id_Tipo_TV: {
                required: true
            },
            Numero_Puertas_V: {
                required: true,
                number: true,
                maxlength: 1,
                minlength: 1
            },
            Numero_Ruedas_V: {
                required: true,
                number: true,
                maxlength: 1,
                minlength: 1
            }

        }

    });
}