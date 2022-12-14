using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWebCore.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
            var values = experienceManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
           
            if (experience.StartingDate is null)
            {

                ModelState.AddModelError("", "Lütfen girilen değerleri kontrol ediniz.");
                return View(experience);
            }
            if (experience.StartingDate >= DateTime.Now)
            {
                ModelState.AddModelError("", "Lütfen girilen değerleri kontrol ediniz.");
                return View(experience);
            }
            if (experience.EndDate <= experience.StartingDate)
            {
                ModelState.AddModelError("", "Lütfen girilen değerleri kontrol ediniz.");
                return View(experience);
            }
            if (experience.EndDate >= DateTime.Now)
            {
                ModelState.AddModelError("", "Lütfen girilen değerleri kontrol ediniz.");
                return View(experience);
            }


            try
            {
                ExperienceValidator validation = new ExperienceValidator();
                ValidationResult results = validation.Validate(experience);
                if (results.IsValid)
                {
                    experienceManager.TAdd(experience);
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
                return View(experience);

           

        }
        public IActionResult DeleteExperience(int id)
        {
            var values = experienceManager.TGetByID(id);
            experienceManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditExperience(int id)
        {
            var values = experienceManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {
            //experienceManager.TUpdate(experience);
            //return RedirectToAction("Index");

            if (ModelState.IsValid)
            {
                ExperienceValidator validations = new ExperienceValidator();
                ValidationResult results = validations.Validate(experience);
                if (results.IsValid)
                {
                    if (experience.StartingDate is null)
                    {

                        ModelState.AddModelError("", "Lütfen girilen değerleri kontrol ediniz.");
                        return View(experience);
                    }
                    if (experience.StartingDate >= experience.EndDate)
                    {
                        ModelState.AddModelError("", "Lütfen girilen değerleri kontrol ediniz.");
                        return View(experience);
                    }
                    if (experience.EndDate >= DateTime.Now)
                    {
                        ModelState.AddModelError("", "Lütfen girilen değerleri kontrol ediniz.");
                        return View(experience);
                    }
                    if (experience.EndDate <= experience.StartingDate)
                    {
                        ModelState.AddModelError("", "Lütfen girilen değerleri kontrol ediniz.");
                        return View(experience);
                    }
                    experienceManager.TUpdate(experience);
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
                ModelState.AddModelError("", "Lütfen girilen değerleri kontrol ediniz.");
                //return View(experience);
            }

            return View(experience);
        }
    }
}

