namespace HBSIS.Domain.Entities
{   
   
    public class Livro : BaseEntity
    {
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Autor { get; set; }
    }
}
