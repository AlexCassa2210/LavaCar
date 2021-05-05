$(function () {

    validacion();

});

function validacion() {
    $("#frmPaisFabricacionModifica").validate({

        rules: {
            //Etique name para validar
            Pais_PF: {
                required: true,
                minlength: 2
            },
            Codigo_PF: {
                required: true,
                minlength: 4
            }

        }

    });
}