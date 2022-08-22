using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fika.Model
{
    public class Personel
    {
        public int PersonelID { get; set; }

        [InverseProperty("SatisID")]
        public virtual ICollection<Musteri> Satis { get; set; }

        [InverseProperty("OperasyonID")]
        public virtual ICollection<Musteri> Operasyon { get; set; }

        public string Isim { get; set; }


    }
}
