using System.Collections.Generic;

namespace AracKiraSistemi.Entities.Model
{
    public class Araba
    {
        public int ArabaId { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Branch { get; set; }
        public int Year { get; set; }
        public int Km { get; set; }
        public int LeaseTypeId { get; set; }

        public virtual KiraTuru KiraTuru { get; set; }

        public virtual ICollection<Sepet> Sepets { get; set; }
    }
}
