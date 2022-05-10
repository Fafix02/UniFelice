namespace UniFelice.Models
{
    public interface ILibretto
    {
        public enum Tipo
        {
            CARTACEO,
            DIGITALE,
            SCONOSCIUTO
        }
        public Tipo Type { get; }
        public List<IValutazione> Voti { get; }
    }
}
