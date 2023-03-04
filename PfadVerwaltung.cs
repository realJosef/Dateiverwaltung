using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dateiverwaltung
{
    public class publicPfadEintrag
    {

        public string Name { get; set; }
        public string Dateipfad { get; set; }
        public string Abteilung { get; set; }
        public string Passwort { get; set; }
    }

    public class privatPfadEintrag
    {

        public string Name { get; set; }
        public string Dateipfad { get; set; }
        public string Abteilung { get; set; }
        public string Passwort { get; set; }
    }

    public class config
    {
        public string Abteilung { get; set; }
        public string privatDBPath { get; set; }
    }
}
