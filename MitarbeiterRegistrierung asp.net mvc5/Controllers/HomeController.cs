using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using nankamApp.Models;
namespace nankamApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }


        [HttpPost]
    public ActionResult Index(HttpPostedFileBase file)
    {
      if (file != null)
      {
        //get the bytes from the uploaded file
        byte[] data = GetBytesFromFile(file);

        using (Context db = new Context())
        {
          db.FileTable.Add(new FileTable() { UploadedFile = data });
          db.SaveChanges();
        }
      }

      return View();
    }

    //Method to convert file into byte array
    private byte[] GetBytesFromFile(HttpPostedFileBase file)
    {
      using (Stream inputStream = file.InputStream)
      {
        MemoryStream memoryStream = inputStream as MemoryStream;
        if (memoryStream == null)
        {
          memoryStream = new MemoryStream();
          inputStream.CopyTo(memoryStream);
        }
        return memoryStream.ToArray();
      }
    }
    }
}
