namespace UniFelice.Models
{
    public interface IEsame
    {
        public string Codice { get; }
        public string? Descrizione { get; }
        public IProfessore Titolare { get; }
        public List<string> Assistenti { get; }
        public List<IAppello> Appelli { get; }
    }
}
