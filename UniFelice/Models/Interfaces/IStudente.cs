namespace UniFelice.Models
{
    public interface IStudente : IPersona
    {
        public string Matricola { get; }
        public string CorsoIscritto { get; }
        public ILibretto Libretto { get; }
    }
}
