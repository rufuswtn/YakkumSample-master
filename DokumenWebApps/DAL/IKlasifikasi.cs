
using DokumenWebApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DokumenWebApps.DAL
{
    public interface IKlasifikasi : ICrud<Klasifikasi>
    {
        IEnumerable<Klasifikasi> GetAllByNama(string nama);
        IEnumerable<Klasifikasi> GetAllAktifStatus();
        IEnumerable<Klasifikasi> GetAllWithDapper();
        void UbahStatusAktif(string id);
    }
}
