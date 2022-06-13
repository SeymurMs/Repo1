using _10IyunTask.DAL;
using _10IyunTask.Models;
using _10IyunTask.utilize;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _10IyunTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        public AppDbContext _context { get; }
        public IWebHostEnvironment _env { get; }
        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _env = env;
            _context = context;
        }
        public ActionResult Index()
        {
            List<Slider> slider = _context.Sliders.ToList();
            return View(slider);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Slider slider)
        {
            if (!ModelState.IsValid) return BadRequest();
            Slider dbSlider = _context.Sliders.FirstOrDefault(s => s.Title.ToLower().Trim().Contains(slider.Title.ToLower().Trim()));
            string filName = Guid.NewGuid().ToString() + slider.Photo.FileName;
            if (slider.Photo !=null)
            {
                slider.ImageUrl = slider.Photo.SaveImg(_env.WebRootPath, "img", filName);
                slider.ImageUrl = filName;
            }

            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: SliderController/Edit/5
        public ActionResult Edit(int id)
        {
            Slider slider = _context.Sliders.Find(id);
            return View(slider);
        }

        // POST: SliderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Slider slider)
        {
            if (slider == null) return BadRequest();

            Slider DbSlider = _context.Sliders.Find(id);
            if (slider.Photo == null)
            {
                DbSlider.Title = slider.Title;
                DbSlider.Descripiton = slider.Descripiton;
                DbSlider.Job = slider.Job;
            }
            else
            {
                string filName = Guid.NewGuid().ToString() + slider.Photo.FileName;
                slider.ImageUrl = slider.Photo.SaveImg(_env.WebRootPath, "img", filName);
                slider.ImageUrl = filName;

                FileManager.DeleteFile(_env.WebRootPath, "img", DbSlider.ImageUrl);

                DbSlider.Title = slider.Title;
                DbSlider.Descripiton = slider.Descripiton;
                DbSlider.Job = slider.Job;
                DbSlider.ImageUrl = filName;
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
            
        }

        // GET: SliderController/Delete/5
        public ActionResult Delete(int id)
        {
            Slider DbSlider = _context.Sliders.Find(id);
            if (DbSlider == null)
            {
                return BadRequest();
            }
            _context.Sliders.Remove(DbSlider);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

     
    }
}
