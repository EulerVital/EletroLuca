function modalDeletar(urlPost, valor, urlCallback, nomeTitulo) {

    document.getElementById("nomeDelete").innerText = nomeTitulo;

    $.ajax({
        url: urlPost,
        type: 'post',
        data: { id: valor },
        async: true,
        beforeSend: function () {
            $("#alertDelete").css('display', 'block');
            $("#alertaDeleteEnviando").css('display', 'block');
        }
    }).done(function (msg) {
        $("#alertaDeleteEnviando").css('display', 'none');
        $("#alertaDeleteSucesso").css('display', 'block');
        sleep(2000);
        $("#alertDelete").css('display', 'none');
        window.location.href = urlCallback;

    }).fail(function (jqXHR, textStatus, msg) {
        $("#alertaDeleteEnviando").css('display', 'none');
        $("#alertaDeleteFalha").css('display', 'block');
    });
}

function sleep(milliseconds) {
    var start = new Date().getTime();
    for (var i = 0; i < 1e7; i++) {
        if ((new Date().getTime() - start) > milliseconds) {
            break;
        }
    }
}