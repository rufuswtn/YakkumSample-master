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
    public class KlasifikasiDALDapper : IKlasifikasi
    {
        private string connStr;
        public KlasifikasiDALDapper(IConfiguration config)
        {
            connStr = config.GetConnectionString("DefaultConnection");
        }

        public void Create(Klasifikasi obj)
        {
            using(SqlConnection conn = new SqlConnection(connStr))
            {
                string strSql = @"insert into Klasifikasi(KodeKlasifikasi,Induk,Level,NamaKlasifikasi,RetensiAktif,RetensiInaktif,StatusAktif,Uraian) 
                values(@KodeKlasifikasi,@Induk,@Level,@NamaKlasifikasi,@RetensiAktif,@RetensiInaktif,@StatusAktif,@Uraian)";
                try
                {
                    conn.Execute(strSql,obj);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"Kesalahan: {sqlEx.Message}");
                }
            }
        }

        public void Delete(string id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string strSql = @"delete from Klasifikasi where KodeKlasifikasi=@KodeKlasifikasi";
                try
                {
                    var param = new { KodeKlasifikasi = id };
                    conn.Execute(strSql,param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
            }
        }

        public IEnumerable<Klasifikasi> GetAll()
        {
            IEnumerable<Klasifikasi> listKlasifikasi;
            using(SqlConnection conn = new SqlConnection(connStr))
            {
                //string strSql = @"select * from Klasifikasi order by NamaKlasifikasi";
                //listKlasifikasi = conn.Query<Klasifikasi>(strSql);

                //memanggil store procedure
                listKlasifikasi = conn.Query<Klasifikasi>("sp_GetAllKlasifikasi", commandType: System.Data.CommandType.StoredProcedure);
                return listKlasifikasi;
            }
        }

        public IEnumerable<Klasifikasi> GetAllAktifStatus()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Klasifikasi> GetAllByNama(string nama)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Klasifikasi> GetAllWithDapper()
        {
            throw new NotImplementedException();
        }

        public Klasifikasi GetById(string id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string strSql = @"select * from Klasifikasi where KodeKlasifikasi=@KodeKlasifikasi";
                var param = new { KodeKlasifikasi = id };
                var result = conn.QuerySingle<Klasifikasi>(strSql,param);
                return result;
            }
        }

        public void UbahStatusAktif(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(Klasifikasi obj)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string strSql = @"update Klasifikasi set Induk=@Induk,Level=@Level,
                NamaKlasifikasi=@NamaKlasifikasi,RetensiAktif=@RetensiAktif,RetensiInaktif=@RetensiInaktif,StatusAktif=@StatusAktif,Uraian=@Uraian 
                where KodeKlasifikasi=@KodeKlasifikasi";
                try
                {
                    conn.Execute(strSql, obj);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception("Error: "+sqlEx.Message);
                }
            }
        }
    }
}
