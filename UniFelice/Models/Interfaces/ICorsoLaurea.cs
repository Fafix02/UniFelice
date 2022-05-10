namespace UniFelice.Models
{
    public interface ICorsoLaurea
    {
        public string Codice { get; }
        public string Descrizione { get; }
        public List<IEsame> Esami { get; }
    }
}
