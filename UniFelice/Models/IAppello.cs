namespace UniFelice.Models
{
    public interface IAppello
    {
        public enum Tipo
        {
            SCRITTO,
            ORALE
        }
        public DateTime Data { get; }
        public Tipo TipoAppello { get; }
        public IEsame Esame { get; }
    }
}
