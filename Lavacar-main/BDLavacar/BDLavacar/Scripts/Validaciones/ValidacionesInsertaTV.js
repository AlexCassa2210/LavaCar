$(function () {

    validacion();

});

function validacion() {
    $("#frmTipoVehiculoNuevo").validate({

        rules: {
            //Etique name para validar
            codigo_TV: {
                required: true,
                minlength: 4
            },
            Tipo_TV: {
                required: true,
                minlength: 2
            }

        }

    });
}