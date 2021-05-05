$(function () {

    validacion();

});

function validacion() {
    $("#frmMarcaVehiculoModifica").validate({

        rules: {
            //Etique name para validar
            Tipo_MV: {
                required: true,
                minlength: 2
            },
            Codigo_MV: {
                required: true,
                minlength: 4
            },
            Id_PaisFabricacion_PF: {
                required: true
            }

        }

    });
}