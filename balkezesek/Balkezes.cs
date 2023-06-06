using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace balkezesek
{
    internal class Balkezes
    {
        string nev;
        DateTime elso;
        DateTime utolso;
        int suly;
        int magassag;

        public Balkezes(string nev, DateTime elso, DateTime utolso, int suly, int magassag)
        {
            this.nev = nev;
            this.elso = elso;
            this.utolso = utolso;
            this.suly = suly;
            this.magassag = magassag;
        }

        public string Nev { get => nev; }
        public DateTime Elso { get => elso; }
        public DateTime Utolso { get => utolso; }
        public int Suly { get => suly; }
        public int Magassag { get => magassag; }
    }
}
