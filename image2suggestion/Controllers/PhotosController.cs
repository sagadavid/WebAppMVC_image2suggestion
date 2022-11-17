using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using image2suggestion.Data;
using image2suggestion.Models;
using Microsoft.AspNetCore.Http;

namespace image2suggestion.Controllers
{
    public class PhotosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PhotosController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Image
        public async Task<IActionResult> Index()
        {
            return View(await _context
                .Photo.ToListAsync());
        }

        // GET: Image/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Photo == null)
            {
                return NotFound();
            }

            var imageModel = await _context.Photo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imageModel == null)
            {
                return NotFound();
            }

            return View(imageModel);
        }

        // GET: Image/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Image/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,File")] Photo photo)
        {
            if (ModelState.IsValid)
            {
                //save image to wwwroot/image
                string wwwRootPath = _hostEnvironment.WebRootPath;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                string fileName = Path.GetFileNameWithoutExtension(photo.File.FileName);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                string fileExtension = Path.GetExtension(photo.File.FileName);
                photo.Title = fileName = fileName + DateTime.Now.ToString("yymmssffff") + fileExtension;
                string path = Path.Combine(wwwRootPath + "/Image/" + fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await photo.File.CopyToAsync(fileStream);
                }

                using (var memoryStream = new MemoryStream())
                {
                    await photo.File.CopyToAsync(memoryStream);
                }
                    //insert record
                    //await AddPicture(photo);
                    _context.Add(photo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(photo);
        }

        // GET: Image/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Photo == null)
            {
                return NotFound();
            }

            var photo = await _context.Photo.FindAsync(id);
            if (photo == null)
            {
                return NotFound();
            }
            return View(photo);
        }

        // POST: Image/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,File")] Photo photo)
        {
            if (id != photo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(photo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageModelExists(photo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(photo);
        }

        // GET: Image/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Photo == null)
            {
                return NotFound();
            }

            var imageModel = await _context.Photo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imageModel == null)
            {
                return NotFound();
            }

            return View(imageModel);
        }

        // POST: Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Photo == null)
            {
                return Problem("Entity set 'PhotoDBContext.Photo'  is null.");
            }
            var photo = await _context.Photo.FindAsync(id);

            if (photo != null)
            {
                _context.Photo.Remove(photo);
            }

            //delete image from wwwroot/image folder
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", photo.Title);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
            //delete the record
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImageModelExists(int id)
        {
            return _context.Photo.Any(e => e.Id == id);
        }

        //private async Task AddPicture(Photo photo)
        //{
        //    if (photo.File.Length > 0)
        //    {
        //        using (var memoryStream = new MemoryStream())
        //        {
        //            await photo.File.CopyToAsync(memoryStream);
                   

        //           // Upload the file if less than 2 MB
        //            if (memoryStream.Length < 2097152)
        //            {
        //                //based on the upload file to create Photo instance.
        //                //You can also check the database, whether the image exists in the database.
        //                var newphoto = new Photo()
        //                {
        //                    Bytes = memoryStream.ToArray(),
        //                };
        //                //add the photo instance to the list.
        //                _context.Add(photo);
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("File", "The file is too large.");
        //            }
        //        }
        //    }
        //}
    }
}
