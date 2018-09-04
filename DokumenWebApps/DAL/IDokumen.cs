using DokumenWebApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DokumenWebApps.DAL
{
    public interface IDokumen : ICrud<Dokumen>
    {
        IEnumerable<Dokumen> Search(string search, string pilih, DateTime tglbuatawal, DateTime tglbuatakhir);
        IEnumerable<DokumenKlasifikasiView> GetAllWithKlasifikasi();
    }
}
