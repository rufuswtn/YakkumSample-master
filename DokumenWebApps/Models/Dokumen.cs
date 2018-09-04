using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DokumenWebApps.Models
{
    public class Dokumen
    {
        [Key,MaxLength(20)]
        [Display(Name ="ID")]
        public string DokumenID { get; set; }
        public string KodeKlasifikasi { get; set; }
        [Display(Name ="Dokumen")]
        public string NamaDokumen { get; set; }
        [Display(Name ="Tgl Buat")]
        public DateTime TanggalDibuat { get; set; }
        [Display(Name ="Tgl Terima")]
        public DateTime TanggalDiterima { get; set; }
        public string Sumber { get; set; }
        public string Keterangan { get; set; }
        public Klasifikasi Klasifikasi { get; set; }
    }
}
