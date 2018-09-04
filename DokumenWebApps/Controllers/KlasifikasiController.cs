using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DokumenWebApps.DAL;
using DokumenWebApps.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DokumenWebApps.Controllers
{
    public class KlasifikasiController : Controller
    {
        private IKlasifikasi _tblKlasifikasi;
        public KlasifikasiController(IKlasifikasi tblKlasifikasi)
        {
            _tblKlasifikasi = tblKlasifikasi;
        }

        // GET: Klasifikasi
        public ActionResult Index()
        {
            if (TempData["Keterangan"] != null)
                ViewBag.Keterangan = TempData["Keterangan"];
            else
                ViewBag.Keterangan = string.Empty;

            var models = _tblKlasifikasi.GetAll();
            return View(models);
        }

        // GET: Klasifikasi/Details/5
        public ActionResult Details(string id)
        {
            var result = _tblKlasifikasi.GetById(id);
            return View(result);
        }

        // GET: Klasifikasi/Create
        [Authorize()]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Klasifikasi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Klasifikasi klasifikasi)
        {
            try
            {
                _tblKlasifikasi.Create(klasifikasi);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error =
                    $"<span class='alert alert-danger'>Kesalahan {ex.Message}</span>";
                return View();
            }
        }

        // GET: Klasifikasi/Edit/5
        public ActionResult Edit(string id)
        {
            try
            {
                var result = _tblKlasifikasi.GetById(id);
                return View(result);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Klasifikasi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Klasifikasi klasifikasi)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _tblKlasifikasi.Update(klasifikasi);
                    //mengirimkan nilai ke action method yang lain
                    TempData["Keterangan"] =
                        $"<span class='alert alert-success'>Data klasifikasi {klasifikasi.NamaKlasifikasi} sudah berhasil diupdate !</span>";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch(Exception ex)
            {
                ViewBag.Error =
                   $"<span class='alert alert-danger'>Kesalahan {ex.Message}</span>";
                return View();
            }
        }

        // GET: Klasifikasi/Delete/5
        public ActionResult Delete(string id)
        {
            var model = _tblKlasifikasi.GetById(id);
            return View(model);
        }

        //
        // POST: Klasifikasi/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(string id)
        {
            try
            {
                _tblKlasifikasi.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error : " + ex.Message;
                return View();
            }
        }
    }
}