using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DokumenWebApps.Data;
using DokumenWebApps.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace DokumenWebApps.DAL
{
    public class KlasifikasiDAL : IKlasifikasi
    {
        private ApplicationDbContext _db;
        private IConfiguration _config;

        public KlasifikasiDAL(ApplicationDbContext db,IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        public void Create(Klasifikasi obj)
        {
            try
            {
                _db.Add(obj);
                _db.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                var sqlError = (System.Data.SqlClient.SqlException)dbEx.InnerException;
                if (sqlError.Number == 2627)
                {
                    throw new Exception("Kode Klasifikasi sudah ada, masukan kode yang lain.");
                }
                else
                {
                    throw new Exception("Error: " + sqlError.Message);
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public void Delete(string id)
        {
            try
            {
                var result = GetById(id);
                _db.Remove(result);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Klasifikasi> GetAll()
        {
            var results = _db.Klasifikasi.OrderBy(k => k.KodeKlasifikasi);
            //var results = from k in _db.Klasifikasi
            //              orderby k.NamaKlasifikasi ascending
            //              select k;
            return results;
        }

        public IEnumerable<Klasifikasi> GetAllAktifStatus()
        {
            var results = from k in _db.Klasifikasi
                          where k.StatusAktif == true
                          orderby k.KodeKlasifikasi ascending
                          select k;

            //var results = _db.Klasifikasi.FromSql("select * from Klasifikasi where StatusAktif=1 order by KodeKlasifikasi");
            return results;
        }

        public IEnumerable<Klasifikasi> GetAllByNama(string nama)
        {
            //var results = from k in _db.Klasifikasi
            //              where k.NamaKlasifikasi.Contains(nama)
            //              orderby k.NamaKlasifikasi ascending
            //              select k;

            var results = _db.Klasifikasi
                .Where(k => k.NamaKlasifikasi.Contains(nama))
                .OrderBy(k => k.NamaKlasifikasi);

            return results;
        }

        public IEnumerable<Klasifikasi> GetAllWithDapper()
        {
            string strConn = _config.GetConnectionString("DefaultConnection");
            using(SqlConnection conn = new SqlConnection(strConn))
            {
                string strSql = @"select * from Klasifikasi order by NamaKlasifikasi asc";
                var results = conn.Query<Klasifikasi>(strSql);
                return results;
            }
        }

        public Klasifikasi GetById(string id)
        {
            var results = (from k in _db.Klasifikasi
                           where k.KodeKlasifikasi == id
                           select k).SingleOrDefault();

            if (results != null)
                return results;
            else
                throw new Exception("Data tidak ditemukan !");
        }

        public void UbahStatusAktif(string id)
        {
            var result = GetById(id);
            if (result != null)
            {
                result.StatusAktif = false;
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("Error: Data klasifikasi tidak ditemukan !");
            }
        }

        public void Update(Klasifikasi obj)
        {
            try
            {
                var result = GetById(obj.KodeKlasifikasi);
                result.Induk = obj.Induk;
                result.Level = obj.Level;
                result.NamaKlasifikasi = obj.NamaKlasifikasi;
                result.RetensiAktif = obj.RetensiAktif;
                result.RetensiInaktif = obj.RetensiInaktif;
                result.Uraian = obj.Uraian;
                result.StatusAktif = obj.StatusAktif;
                
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
