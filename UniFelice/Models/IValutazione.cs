namespace UniFelice.Models
{
    public interface IValutazione
    {
        public IAppello Appello { get; }
        public int Voto { get; }
    }
}
