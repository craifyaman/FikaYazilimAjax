namespace Fika.Model
{
    public class SatisHareket
    {
        public int SatisHareketID { get; set; }

        public int StokID { get; set; }
        public Stok Stok { get; set; }

        public int MusteriID { get; set; }
        public Musteri Musteri { get; set; }

        public int PersonelID { get; set; }
        public Personel Personel { get; set; }

        public System.DateTime SatisZamani { get; set; }
    }
}
