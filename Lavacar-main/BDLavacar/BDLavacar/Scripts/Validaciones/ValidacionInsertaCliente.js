$(function () {

    validacion();

});

function validacion() {
    $("#frmNuevoUsuario").validate({

        rules: {
            //Etique name para validar
            Cedula_P: {
                required: true,
                minlength: 9,
                maxlength: 9
            },
            Fecha_Nacimiento_P: {
                required:true
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
            Id_Provincia_P: {
                required: true
            },
            Id_Canton_P: {
                required: true
            },
            Id_Distrito_P: {
                required: true
            },
            Id_Tipo_P: {
                required: true
            }
        }

    });
}