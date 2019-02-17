using HBSIS.Domain.Entities;

namespace HBSIS.Presentation.Contract
{
    public class LivroUnitarioDataContract
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public object ProcessingTime { get; set; }
        public Livro Object { get; set; }
    }
}