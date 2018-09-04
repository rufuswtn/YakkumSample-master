using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DokumenWebApps.DAL;
using DokumenWebApps.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DokumenWebApps.Controllers
{
    public class DokumenController : Controller
    {
        private IDokumen _dokumen;
        private IKlasifikasi _klasifikasi;
        public DokumenController(IDokumen dokumen,IKlasifikasi klasifikasi)
        {
            _dokumen = dokumen;
            _klasifikasi = klasifikasi;
        }
        // GET: Dokumen
        public ActionResult Index()
        {
            //var results = _dokumen.GetAll();
            var results = _dokumen.GetAllWithKlasifikasi();
            return View(results);
        }

        [HttpPost]
        public ActionResult Search(string search,string pilih, 
            DateTime tglbuatawal,DateTime tglbuatakhir)
        {
            var results = _dokumen.Search(search,pilih,tglbuatawal,tglbuatakhir);
            return View("Index", results);
        }

        // GET: Dokumen/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dokumen/Create
        public ActionResult Create()
        {
            ViewBag.ListKlasifikasi = _klasifikasi.GetAll().ToList();
            return View();
        }

        // POST: Dokumen/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dokumen dokumen)
        {
            try
            {
                _dokumen.Create(dokumen);
                TempData["Keterangan"] =
                        $"<span class='alert alert-success'>Data klasifikasi {dokumen.NamaDokumen} sudah berhasil ditambah !</span>";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error =
                  $"<span class='alert alert-danger'>Kesalahan {ex.Message}</span>";
                return View();
            }
        }

        // GET: Dokumen/Edit/5
        public ActionResult Edit(string id)
        {
            ViewBag.ListKlasifikasi = _klasifikasi.GetAll().ToList();
            var result = _dokumen.GetById(id);
            return View(result);
        }

        // POST: Dokumen/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Dokumen dokumen)
        {
            try
            {
                _dokumen.Update(dokumen);
                TempData["Keterangan"] =
                        $"<span class='alert alert-success'>Data klasifikasi {dokumen.NamaDokumen} sudah berhasil diedit !</span>";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error =
                 $"<span class='alert alert-danger'>Kesalahan {ex.Message}</span>";
                return View();
            }
        }

        // GET: Dokumen/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dokumen/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}