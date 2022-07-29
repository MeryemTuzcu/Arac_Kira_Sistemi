using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiraSistemi.Entities.Model
{
    public class KiraTuru
    {
        public int KiraTuruId { get; set; }
        public int DailyPrice { get; set; }
        public int WeeklyPrice { get; set; }
        public int MonthlyPrice { get; set; }

        public virtual ICollection<Araba> Arabas { get; set; }

    }
}
