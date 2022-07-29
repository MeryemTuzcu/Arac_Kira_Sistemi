using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiraSistemi.Entities.Model
{
    public class Sepet
    {
        public int SepetId { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual Musteri Musteri { get; set; }
        public virtual Araba Araba { get; set; }
    }
}
