using Dapper.FluentMap.Dommel.Mapping;
using HBSIS.Domain.Entities;

namespace HBSIS.Data.Mappers
{
    public class LivroMap : DommelEntityMap<Livro>
    {
        public LivroMap()
        {
            ToTable("Livro");
            Map(x => x.Id).ToColumn("id").IsKey();
            Map(x => x.ISBN).ToColumn("isbn");
            Map(x => x.Titulo).ToColumn("titulo");
            Map(x => x.Descricao).ToColumn("descricao");
            Map(x => x.Autor).ToColumn("autor");
        }
    }
}
