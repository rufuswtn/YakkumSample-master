using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DokumenWebApps.Models;

using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DokumenWebApps.DAL
{
    public class DokumenDALDapper : IDokumen
    {
        //
        private string connStr;
        public DokumenDALDapper(IConfiguration config)
        {
            connStr = config.GetConnectionString("DefaultConnection");
        }

        public void Create(Dokumen obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dokumen> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DokumenKlasifikasiView> GetAllWithKlasifikasi()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
//                SELECT dbo.Dokumen.DokumenID, dbo.Dokumen.KodeKlasifikasi, dbo.Dokumen.NamaDokumen, dbo.Dokumen.TanggalDibuat, dbo.Dokumen.TanggalDiterima, dbo.Dokumen.Sumber, dbo.Dokumen.Keterangan, dbo.Klasifikasi.Induk, 
//                         dbo.Klasifikasi.[Level], dbo.Klasifikasi.NamaKlasifikasi, dbo.Klasifikasi.RetensiAktif, dbo.Klasifikasi.RetensiInaktif, dbo.Klasifikasi.StatusAktif, dbo.Klasifikasi.Uraian
//FROM            dbo.Dokumen INNER JOIN
//                         dbo.Klasifikasi ON dbo.Dokumen.KodeKlasifikasi = dbo.Klasifikasi.KodeKlasifikasi

                string strSql = @"select * from DokumenKlasifikasiView order by DokumenID asc";
                var results = conn.Query<DokumenKlasifikasiView>(strSql);
                return results;
            }
        }

        public Dokumen GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dokumen> Search(string search, string pilih, DateTime tglbuatawal, DateTime tglbuatakhir)
        {
            throw new NotImplementedException();
        }

        public void Update(Dokumen obj)
        {
            throw new NotImplementedException();
        }
    }
}
