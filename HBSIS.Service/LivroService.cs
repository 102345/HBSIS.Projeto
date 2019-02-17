using HBSIS.Service.Interface;
using HBSIS.Data.Repositories;
using HBSIS.Domain.Entities;
using System.Linq;
using System.Collections.Generic;

namespace HBSIS.Service
{
    public class LivroService : ILivroService
    {
        private readonly LivroRepository _livroRepository;

        public LivroService()
        {
            _livroRepository = new LivroRepository();
        }

        public void AtualizarLivro(Livro livro)
        {
            _livroRepository.Update(livro);
        }

        public Livro BuscarLivro(int id)
        {
            return _livroRepository.GetById(id);
        }

        public void ExcluirLivro(int id)
        {
            _livroRepository.Delete(id);
        }

        public void InserirLivro(Livro livro)
        {
            _livroRepository.Insert(livro);

        }

        public List<Livro> ListarLivros()
        {
            return _livroRepository.GetAll().OrderByDescending(x => x.Titulo).ToList();
        }
    }
}
