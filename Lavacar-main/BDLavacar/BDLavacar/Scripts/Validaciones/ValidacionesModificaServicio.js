$(function () {

    validacion();

});

function validacion() {
    $("#frmModificaServicio").validate({

        rules: {
            //Etique name para validar
            Codigo_S: {
                required: true,
                minlength: 3
            },
            Descripcion_S: {
                required: true,
                minlength: 4,
                maxlength: 50
            },
            Precio_S: {
                required: true,
                number: true
            },
            Tipo_S: {
                required: true,
                minlength: 2,
                maxlength: 50
            }

        }

    });
}