using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Classes
{
    public class SatisHareket
    {
        [Key]
        public int SatisId { get; set; }
        //ne satıldı ürün
        //kime satıldı cari
        //kim sattı personel 
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }
        public int UrunId { get; set; }
        public int CariId { get; set; }
        public int PersonelId { get; set; }

        public virtual Urun Urunlers { get; set; }
        public virtual Cari Caris { get; set; }
        public virtual Personel Personels { get; set; }

    }
}