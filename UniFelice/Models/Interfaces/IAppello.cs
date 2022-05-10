namespace UniFelice.Models
{
    public interface IAppello
    {
        public enum Tipo
        {
            SCRITTO,
            ORALE,
            MISTO
        }
        public DateTime Data { get; }
        public Tipo TipoAppello { get; }
        public string CodEsame { get; }
        public string Codice { get; }
    }
}
