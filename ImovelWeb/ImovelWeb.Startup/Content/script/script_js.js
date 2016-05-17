CadastrarUsuario = function () {
    var dados = $("#FormCadastrar").serialize();

    $.ajax({
        url: 'LoginUsuario',
        type: 'post',
        datatype: 'json',
        cache: false,
        method: 'post',
        data: dados,
        success: function (data, txtstatus) {
            $("#resposta").text(data);
            document.getElementById("Login").value = "";
            document.getElementById("Senha").value = "";
            document.getElementById("Email").value = "";
            document.getElementById("Cidade").value = "";
            document.getElementById("Telefone").value = "";
            document.getElementById("Endereco").value = "";
            document.getElementById("Senha").value = "";
            $('#Estado').find('option:first').attr('selected', 'selected');
            $('#sexo').find('option:first').attr('selected', 'selected');

        }, error: function (data, txtstatus) {
            $("#resposta").text(data);
        }
    });
};

var AuthenticarUsuario = function () {
    var dados = $("#FormLogar").serialize();

    $.ajax({
        url: 'VerificarLogin',
        type: 'post',
        datatype: 'json',
        cache: false,
        method: 'post',
        data: dados,
        success: function (data, txtstatus) {
            if (data.indexOf("erro") == 0) {
                $("#mensagem").text("Usuário ou Senha incorreto");
                
            } else {
                document.getElementById("Login").value = "";
                document.getElementById("Senha").value = "";
                window.location.href = "/Home";
            }
        }, error: function (data, txtstatus) {
            //$("#resposta").text(data);
        }
    });

};

var GravarPedidoCompra = function () {
    var dados = $("#FormComprar").serialize();

    $.ajax({
        url: 'Comprarmoveis',
        type: 'post',
        datatype: 'json',
        cache: false,
        method: 'post',
        data: dados,
        success: function (data, txtstatus) {
            alert(data)
            window.location.href = "/Home/Index";
        }, error: function (data, txtstatus) {
            alert('Erro na Gravação de dados');
        }
    });
};