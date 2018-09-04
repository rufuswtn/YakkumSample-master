using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DokumenWebApps.Data;
using DokumenWebApps.Models;
using Microsoft.EntityFrameworkCore;

namespace DokumenWebApps.DAL
{
    public class DokumenDAL : IDokumen
    {
        private ApplicationDbContext _db;
        public DokumenDAL(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Create(Dokumen obj)
        {
            try
            {
                _db.Dokumen.Add(obj);
                _db.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dokumen> GetAll()
        {
            var results = from d in _db.Dokumen.Include("Klasifikasi")
                          orderby d.KodeKlasifikasi ascending
                          select d;
            return results;
        }

        public Dokumen GetById(string id)
        {
            var result = (from d in _db.Dokumen
                          where d.DokumenID == id
                          select d).SingleOrDefault();
            return result;
        }

        public void Update(Dokumen obj)
        {
            try
            {
                var result = GetById(obj.DokumenID);
                result.KodeKlasifikasi = obj.KodeKlasifikasi;
                result.NamaDokumen = obj.NamaDokumen;
                result.Sumber = obj.Sumber;
                result.Keterangan = obj.Keterangan;
                result.TanggalDibuat = obj.TanggalDibuat;
                result.TanggalDiterima = obj.TanggalDiterima;
                _db.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
        }

        public IEnumerable<Dokumen> Search(string search,string pilih, DateTime tglbuatawal, DateTime tglbuatakhir)
        {
            IQueryable<Dokumen> results;
            if(pilih == "NamaKlasifikasi")
            {
                results = from d in _db.Dokumen.Include("Klasifikasi")
                          where d.Klasifikasi.NamaKlasifikasi.ToLower().Contains(search.ToLower()) &&
                            (d.TanggalDibuat>=tglbuatawal && d.TanggalDibuat<=tglbuatakhir)
                          orderby d.NamaDokumen ascending
                          select d;
            }
            else
            {
                results = from d in _db.Dokumen.Include("Klasifikasi")
                          where d.NamaDokumen.ToLower().Contains(search.ToLower()) && (d.TanggalDibuat >= tglbuatawal && d.TanggalDibuat <= tglbuatakhir)
                          orderby d.NamaDokumen ascending
                          select d;
            }

            return results;
        }

        public IEnumerable<DokumenKlasifikasiView> GetAllWithKlasifikasi()
        {
            throw new NotImplementedException();
        }
    }
}
