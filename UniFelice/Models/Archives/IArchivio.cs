﻿namespace UniFelice.Models
{
    public interface IArchivio
    {
        public List<IStudente> Studenti { get; }

        void Add(string matricola, string nomeCognome, string corso);
    }
}
