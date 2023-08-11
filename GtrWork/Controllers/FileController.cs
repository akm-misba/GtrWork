using GtrWork.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GtrWork.Controllers
{
    public class FileController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        public FileController(IWebHostEnvironment hostEnvironmen)
        {
            _hostEnvironment = hostEnvironmen;
            
        }
        public IActionResult Index()
        {
            List<ObjFile> ObjFiles = new List<ObjFile>();
            foreach (string strfile in Directory.GetFiles(this._hostEnvironment.WebRootPath, "Files/"))
            {
                FileInfo fi = new FileInfo(strfile);
                ObjFile obj = new ObjFile();
                obj.File = fi.Name;
                obj.Size = fi.Length;
                obj.Type = GetFileTypeByExtension(fi.Extension);
                ObjFiles.Add(obj);
            }

            return View(ObjFiles);
        }

        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(this._hostEnvironment.WebRootPath, "Files/", fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);



            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        private string GetFileTypeByExtension(string fileExtension)
        {
            switch (fileExtension.ToLower())
            {
                case ".docx":
                case ".doc":
                    return "Microsoft Word Document";
                case ".xlsx":
                case ".xls":
                    return "Microsoft Excel Document";
                case ".txt":
                    return "Text Document";
                case ".jpg":
                case ".png":
                    return "Image";
                default:
                    return "Unknown";
            }
        }
        [HttpPost]
        public IActionResult Index(ObjFile doc)
        {
            foreach (var file in doc.files)
            {

                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(this._hostEnvironment.WebRootPath, "Files/", fileName);
                    UploadFile(file, filePath);
                    

                }
            }
            TempData["Message"] = "files uploaded successfully";
            return RedirectToAction(nameof(Index));
        }
        public void UploadFile(IFormFile file, string path)
        {

            FileStream stream = new FileStream(path, FileMode.Create);

            file.CopyTo(stream);


        }
    }
}
