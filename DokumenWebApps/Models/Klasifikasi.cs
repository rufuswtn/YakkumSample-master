using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DokumenWebApps.Models
{
    public class Klasifikasi
    {
        public Klasifikasi()
        {
            StatusAktif = true;
            RetensiAktif = 0;
            RetensiInaktif = 0;
        }

        [Key, MaxLength(20)]
        [Display(Name ="Kode")]
        [Required(ErrorMessage ="Data Kode Klasifikasi Harus Diisi")]
        public string KodeKlasifikasi { get; set; }

        [MaxLength(20)]
        public string Induk { get; set; }

        public int Level { get; set; }

        [Display(Name ="Klasifikasi")]
        [Required(ErrorMessage ="Nama Klasifikasi Harus Diisi")]
        public string NamaKlasifikasi { get; set; }

        public string Uraian { get; set; }

        [Display(Name ="Retensi Aktif")]
        public int RetensiAktif { get; set; }

        [Display(Name ="Retensi Inaktif")]
        public int RetensiInaktif { get; set; }

        [Display(Name ="Status Aktif")]
        public bool StatusAktif { get; set; }
    }
}
