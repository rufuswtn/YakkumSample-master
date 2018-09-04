using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DokumenWebApps.Models
{
    public class DokumenKlasifikasiView
    {
        public string DokumenID { get; set; }
        public string KodeKlasifikasi { get; set; }
        public string NamaDokumen { get; set; }
        public DateTime TanggalDibuat { get; set; }
        public DateTime TanggalDiterima { get; set; }
        public string Sumber { get; set; }
        public string Keterangan { get; set; }
        public string Induk { get; set; }
        public int Level { get; set; }
        public string NamaKlasifikasi { get; set; }
        public int RetensiAktif { get; set; }
        public int RetensiInaktif { get; set; }
        public bool StatusAktif { get; set; }
        public string Uraian { get; set; }
    }
}
