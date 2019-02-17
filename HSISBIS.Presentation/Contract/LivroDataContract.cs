using HBSIS.Domain.Entities;
using System.Collections.Generic;

namespace HBSIS.Presentation.Contract
{
    public class LivroDataContract
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public object ProcessingTime { get; set; }
        public IEnumerable<Livro> Object { get; set; }
    }
}