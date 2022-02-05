function ConsultarNumero() {
    var par = 0;
    var impar = 0;
    var numero = $("#number").val();
    if (numero % 2) {
        par++;
    } else {
        impar++;
    }

    $('#pares').val(par);
    $('#impares').val(impar);
}