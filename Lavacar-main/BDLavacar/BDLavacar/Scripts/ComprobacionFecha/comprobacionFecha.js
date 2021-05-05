$(function () {
    mostrar();
});

function mostrar() {
    var x = $("#fecha").val();
    var estado = $("#Estado_FVS");
    var today = new Date();
    var date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();

    var txt = $("#txt");
    var mensaje = 'No se puede anular, ya pasaron 15 días.'

    var lblEstado = document.getElementById("lblEstado");

    var day1 = new Date(x);
    var day2 = new Date(date);
    var difference = Math.abs(day2 - day1);

    days = difference / (1000 * 3600 * 24)


    if (days >= 15) {
        $(estado).css("display", "none");
        $(lblEstado).css("display", "none");
        $(txt).innerHTML = mensaje
        
    } else {
        $(estado).css("border", "1px solid green");
    }
}

