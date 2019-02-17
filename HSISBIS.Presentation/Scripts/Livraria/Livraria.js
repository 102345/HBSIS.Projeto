$(".incluirLivro").click(function () {
    $("#modIncluirLivro").load("/Livraria/ExibirJanelaIncluiLivro", function () {
        $("#modIncluirLivro").modal();
    })
});


$(".editarLivro").click(function () {
    var id = $(this).attr("data-id");
    $("#modAtualizarLivro").load("/Livraria/ExibirJanelaEditaLivro/" + id, function () {
        $("#modAtualizarLivro").modal();
    })
});


$(".excluirLivro").click(function () {
    var id = $(this).attr("data-id");
    $("#modExcluirLivro").load("/Livraria/ExibirJanelaExcluiLivro/" + id, function () {
        $("#modExcluirLivro").modal();
    })
});