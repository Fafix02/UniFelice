namespace UniFelice.Models
{
    public interface ILibretto
    {
        public IStudente Titolare { get; }
        public List<IValutazione> Voti { get; }
    }
}
