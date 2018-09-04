using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

using SendGrid;
using SendGrid.Helpers.Mail;


namespace DokumenWebApps.Controllers
{
    public class UploadDokumenController : Controller
    {
        private CloudStorageAccount storageAccount;
        private CloudBlobClient blobClient;
        private CloudBlobContainer container;
        //private UploadFileToBlob objUpload;

        //upload to blob azure
        public UploadDokumenController()
        {
            storageAccount = new CloudStorageAccount(
               new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
                   "yakkumstorage", "WUalxetFcSxEc8VxyHPcLxHlFpomwqt3Bk9Ukm2iv9YHSKW+JQpazgMD7+86jPU43Duu2Z5W7cMyPWOipK4PUg=="), true);

            blobClient = storageAccount.CreateCloudBlobClient();
            container = blobClient.GetContainerReference("dokumen");
        }

        public async Task KirimNotifikasi(string namafile)
        {
            var apiKey = "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"; //EmailHelpers.SendridAPI;
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress("admin@yakkum.or.id", "Admin Yakkum");
            List<EmailAddress> tos = new List<EmailAddress>() {
                new EmailAddress{ Email="erick.kurniawan@gmail.com"},
                new EmailAddress{Email="rufuswtn@gmail.com"},
                new EmailAddress{Email="hiskia.ponco@gmail.com"}
            };


            var subject = "Notifikasi Dokumen Sudah Terupload";
            var htmlContent = $"<p>File dengan nama {namafile} berhasil diupload </p>";
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, "", htmlContent, false);
            var response = await client.SendEmailAsync(msg);
        }


        public IActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFile(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
            await container.CreateIfNotExistsAsync();
            string namaBaru = string.Empty;
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    namaBaru = Guid.NewGuid() + "-" + DateTime.Now.Year.ToString() +
                DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + "-" + formFile.FileName;
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(namaBaru);
                    await blockBlob.UploadFromStreamAsync(formFile.OpenReadStream());
                }
            }
            await KirimNotifikasi(namaBaru);
            return Content("File " + namaBaru + " berhasil diupload !");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}