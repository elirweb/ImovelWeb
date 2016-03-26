var ValidateLogar = function () {
        if ($("#Login").val() == "") {
            Mensagem("Favor informar o Login");
            document.getElementById("Login").focus();
            return false;
        } else if ($("#Senha").val() == "") {
            Mensagem("Favor informar a Senha");
            document.getElementById("Senha").focus();
            return false;
        }
        else {

            $("#mensagem").css('display', 'none');
            $("#mensagem").html();
            document.getElementById("FormLogar").submit();
        }
   
};
var Mensagem = function (mensagem) {
        $("#mensagem").css('display', 'block');
        $("#mensagem").html(mensagem);
     
};



var AbrirFormCorretorCadastro = function () {
    $("#MsgGeral").css('display', 'block').animate({ opacity: 0.10 }).slideUp;
    $("#CadCorretor").css('display', 'block').fadeIn(500);
};

var Closed = function () {
    $("#MsgGeral").css('display', 'none');
    $("#CadCorretor").css('display', 'none');
    $("#EmailCadastro").css('display', 'none');

};

var AbrirEmailCadastro = function () {
    $("#MsgGeral").css('display', 'block').animate({ opacity: 0.10 }).slideUp;
    $("#EmailCadastro").css('display', 'block').fadeIn(500);
    document.getElementById("esqueciemail").value = "";
};

function Formata(campo, tammax, teclapres, decimal) {
    var tecla = teclapres.keyCode;
    vr = Limpar(campo.value, "0123456789");
    tam = vr.length;
    dec = decimal

    if (tam < tammax && tecla != 8) { tam = vr.length + 1; }

    if (tecla == 8)
    { tam = tam - 1; }

    if (tecla == 8 || tecla >= 48 && tecla <= 57 || tecla >= 96 && tecla <= 105) {

        if (tam <= dec)
        { campo.value = vr; }

        if ((tam > dec) && (tam <= 5)) {
            campo.value = vr.substr(0, tam - 2) + "," + vr.substr(tam - dec, tam);
        }
        if ((tam >= 6) && (tam <= 8)) {
            campo.value = vr.substr(0, tam - 5) + "." + vr.substr(tam - 5, 3) + "," + vr.substr(tam - dec, tam);
        }
        if ((tam >= 9) && (tam <= 11)) {
            campo.value = vr.substr(0, tam - 8) + "." + vr.substr(tam - 8, 3) + "." + vr.substr(tam - 5, 3) + "," + vr.substr(tam - dec, tam);
        }
        if ((tam >= 12) && (tam <= 14)) {
            campo.value = vr.substr(0, tam - 11) + "." + vr.substr(tam - 11, 3) + "." + vr.substr(tam - 8, 3) + "." + vr.substr(tam - 5, 3) + "," + vr.substr(tam - dec, tam);
        }
        if ((tam >= 15) && (tam <= 17)) {
            campo.value = vr.substr(0, tam - 14) + "." + vr.substr(tam - 14, 3) + "." + vr.substr(tam - 11, 3) + "." + vr.substr(tam - 8, 3) + "." + vr.substr(tam - 5, 3) + "," + vr.substr(tam - 2, tam);
        }
    }

}

function Limpar(valor, validos) {
    // retira caracteres invalidos da string
    var result = "";
    var aux;
    for (var i = 0; i < valor.length; i++) {
        aux = validos.indexOf(valor.substring(i, i + 1));
        if (aux >= 0) {
            result += aux;
        }
    }
    return result;
}

function SomenteNumero(e) {
    var tecla = (window.event) ? event.keyCode : e.which;
    if ((tecla > 47 && tecla < 58)) return true;
    else {
        if (tecla == 8 || tecla == 0) return true;
        else return false;
    }
}

var SalvarCorretor = function () {
    var dados = $("#FormCorretor").serialize();
    $.ajax({
        url: '/Admin/Cadcorretor',
        type: 'post',
        datatype: 'json',
        cache: false,
        method: 'post',
        data: dados,
        success: function (data, textSaudacoes) {
            if (data.indexOf("Erro!") == 0) {
                $("#resposta").text(data);
             } else {
                $("#resposta").text(data);
                document.getElementById("Matricula").value = "";
                document.getElementById("NomeCorretor").value = "";
                document.getElementById("Login").value = "";
                document.getElementById("senhacorretor").value = "";
                document.getElementById("Endereco").value = "";
                document.getElementById("Email").value = "";
                document.getElementById("Cidade").value = "";
                document.getElementById("Telefone").value = "";
                document.getElementById("logincorretor").value = "";
                document.getElementById("Cidade").value = "";
                document.getElementById("Telefone").value = "";
                document.getElementById("resenha").value = "";
                $('#sexo').find('option:first').attr('selected', 'selected');
                $('#Estado').find('option:first').attr('selected', 'selected');

            }
        },
        error: function (data, textSaudacoes) {
            $("#resposta").text(data);
        }
    });
};

var EsqueceuEmailCorretor = function () {
    
    if (document.getElementById("esqueciemail").value != "") {
        var enviaremail = false;
        var dados = $("#FormEmail").serialize();
        $.ajax({
            url: 'http://localhost:51744/api/corretor/?valor=' + document.getElementById("esqueciemail").value,
            type: 'get',
            datatype: 'json',
            cache: false,
            method: 'post',
            befoseSend: function () {
                alert('Aguarde');
            },
            success: function (data, textSaudacoes) {
                $.each(data, function (i, obj) {
                    if (obj.email == document.getElementById("esqueciemail").value) {
                        senhacor = obj.senha;
                        enviaremail = true;
                    }
                });
                if (enviaremail) // criar um controller para enviar e-mail esqueci a senha 
                    EnviarEmailEsqueci(document.getElementById("esqueciemail").value, senhacor);
                   
                else
                    alert("Usuário não authenticado no sistema");

            },
            error: function (data, textSaudacoes) {
                $("#resposta").text(data);
            }
        });

    }
};


var ValidarSenha = function (valor) {
    if (valor != "") {
        if (valor != document.getElementById("senhacorretor").value)
            document.getElementById("resenha").style.border = '1px solid #FF0000';
        else
            document.getElementById("resenha").style.border = '1px solid #000000';
    }else 
        document.getElementById("resenha").style.border = '1px solid #000000';

};

var EnviarEmailEsqueci = function (email,senha) {
    
    $.ajax({
        url: 'Admin/EsqueceuEmail/?email='+email + '&senha='+senha,
        type: 'post',
        datatype: 'json',
        cache: false,
        method: 'get',
        success: function (data, textSaudacoes) {
            alert("email enviado com sucesso");
        }
    });
};

var ValidadorEmail = function (email) {
    var enviaremail = false;
    if (email != "") {

        if (email.indexOf("@") == -1) {
            document.getElementById("Email").style.border = '1px solid #FF0000';
        } else {
            document.getElementById("Email").style.border = '1px solid #000000';

            $.ajax({
                url: 'http://localhost:51744/api/corretor/?valor=' + document.getElementById("Email").value,
                type: 'get',
                datatype: 'json',
                success: function (data, textSaudacoes) {

                    $.each(data, function (i, obj) {
                        if (obj.email == document.getElementById("Email").value) {
                            enviaremail = true;
                        }
                    });
                    if (enviaremail) {// criar um controller para enviar e-mail esqueci a senha 
                        alert("Cadastrado no Banco de daods");
                        document.getElementById("Email").value = "";
                        document.getElementById("Email").focus();
                    }
                    

                }
            });
        }

    }
    else {
        document.getElementById("Email").style.border = '1px solid #000000';
    }
};

var CadEmpreendimento = function () {

    var dados = $("#FormEmpreendimento").serialize();
    $.ajax({
        url: 'Empreendimento',
        type: 'post',
        datatype: 'json',
        cache: false,
        method: 'post',
        data: dados,
        success: function (data, textSaudacoes) {
            $("#resposta").text(data);
            $("#Nome").val() = "";
            $("#Endereco").val() = "";
            $("#Numero").val() = "";
            $("#Estado").val() = "";
            $("#Cidade").val() = "";
            
        },
        error: function (data, textSaudacoes) {
            $("#resposta").text(data);
        }
    });

};


var SalvarImovel = function () {

    var dados = $("#FormImovel").serialize();
    $.ajax({
        url: 'Imovel',
        type: 'post',
        datatype: 'json',
        cache: false,
        method: 'post',
        data: dados,
        success: function (data, textSaudacoes) {
            if (data.indexOf("Erro!") == 0) {
                $("#resposta").text(data);
            } else {
                $("#resposta").text(data);
                document.getElementById("NomeImovel").value = "";
                document.getElementById("Descricao").value = "";
                document.getElementById("Endereco").value = "";
                document.getElementById("Numero").value = "";
                document.getElementById("Estado").value = "";
                document.getElementById("Cidade").value = "";
                document.getElementById("IdPorcetagem_ID").value = "";
                document.getElementById("Preco").value = "";

            }
        },
        error: function (data, textSaudacoes) {
            $("#resposta").text(data);
        }
    });

};

var CadPorcentagem = function () {
    var dados = $("#FormPorcentagem").serialize();

    $.ajax({
        url: 'Porcentagem',
        type: 'post',
        datatype: 'json',
        cache: false,
        method: 'post',
        data: dados,
        success: function (data, txtstatus) {
            $("#Desconto").val() = "";
            $("#resposta").text(data);
        }, error: function (data, txtstatus) {
            $("#resposta").text(data);
        }
    });
};

$(function () {
    var selecao = "";
    
        $("#EmpreendimentoID").change(function () {
            $.ajax({
                url: 'http://localhost:51744/api/imovel/?valor=' + $("#EmpreendimentoID").val(),
                type: 'get',
                datatype: 'json',
                cache: false,
                method: 'get',
                success: function (data, txtstatus) {
                    selecao = "<select name='ImovelID' id='ImovelID'>";
                    $.each(data, function (i, obj) {
                        selecao += "<option value= " + obj.imovelID + ">" + obj.nomeImovel + "</option>";
                    });
                    selecao += "</select>";
                    document.getElementById("txtimovel").innerHTML = selecao;

                }, error: function (data, txtstatus) {

                }
            });
        });
     

});
