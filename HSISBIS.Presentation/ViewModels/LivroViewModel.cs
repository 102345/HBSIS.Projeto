using HBSIS.Domain.Entities;
using System.Collections.Generic;

namespace HBSIS.Presentation.ViewModels
{
    public class LivroViewModel
    {
        //public LivroViewModel()
        //{
        //    ColecaoLivros = new List<Livro>();
        //}

        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Autor { get; set; }
        public IEnumerable<Livro> ColecaoLivros { get; set; }
    }
}