using HBSIS.Domain.Entities;
using System.Collections.Generic;

namespace HBSIS.Service.Interface
{
    public interface ILivroService
    {
        List<Livro> ListarLivros();
        Livro BuscarLivro(int id);
        void InserirLivro(Livro livro);
        void AtualizarLivro(Livro livro);
        void ExcluirLivro(int id);

    }
}
