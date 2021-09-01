using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjeMvc5Eticaret.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelAdi { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersaonelSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string PersonelGorsel { get; set; }

        public int DepartmanID { get; set; }
        public ICollection<SatisHareket> SatisHarekts { get; set; }
        public virtual Departman Departman { get; set; }
    }
}