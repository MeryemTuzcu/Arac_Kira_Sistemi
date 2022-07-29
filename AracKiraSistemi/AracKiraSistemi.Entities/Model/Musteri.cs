using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiraSistemi.Entities.Model
{
    public class Musteri
    {
        public int MusteriId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BornDate { get; set; }
        public string Gender { get; set; }
        public string MusteriEmail { get; set; }
        public string MusteriKAdi { get; set; }
        public string MusteriParola { get; set; }
        public virtual ICollection<Sepet> Sepets { get; set; }
    }
}
