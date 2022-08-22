using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fika.Model
{
    public class Musteri
    {
        public int MusteriID { get; set; }
        public string Unvan { get; set; }

        public int GrupID { get; set; }
        public Grup Grup { get; set; }

        [Column("SatisID")]
        public Personel SatisID { get; set; }

        [Column("OperasyonID")]
        public Personel OperasyonID { get; set; }

    }
}
