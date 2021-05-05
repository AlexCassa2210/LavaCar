$(function () {

    validacion();

});

function validacion() {
    $("#frmModificaUsuario").validate({

        rules: {
            //Etique name para validar
            Cedula_P: {
                required: true,
                minlength: 9,
                maxlength: 9
            },
            Genero_P: {
                required: true
            },
            Fecha_Nacimiento_P: {
                required: true
            },
            Nombre_P: {
                required: true,
                minlength: 2

            },
            PApellido: {
                required: true,
                minlength: 2
            },
            SApellido: {
                required: true,
                minlength: 2
            },
            Correo_P: {
                required: true,
                email: true

            },
            id_Provincia: {
                required: true
            },
            id_Canton: {
                required: true
            },
            id_Distrito: {
                required: true
            },
            Id_TipoPersona_TP: {
                required: true
            }
        }

    });
}