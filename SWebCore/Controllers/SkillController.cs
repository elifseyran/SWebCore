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
    public class SkillController : Controller
    {
        SkillManager skillManager= new SkillManager(new EfSkillDal());

        public IActionResult Index()
        {
            var values = skillManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            //skillManager.TAdd(skill);
            //return RedirectToAction("Index"); 
            SkillValidator validation=new SkillValidator();
            ValidationResult results=validation.Validate(skill);
            if (results.IsValid)
            {
                skillManager.TAdd(skill);
                return RedirectToAction("Index");
            }
            else 
            { 
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }  
        public IActionResult DeleteSkill(int id)
        {
            var values = skillManager.TGetByID(id);
            skillManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditSkill(int id)
        {
            var values = skillManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditSkill(Skill skill)
        {
            //skillManager.TUpdate(skill);
            //return RedirectToAction("Index");
            SkillValidator validations = new SkillValidator();
            ValidationResult results=validations.Validate(skill);
            if(results.IsValid)
            {
                skillManager.TUpdate(skill);
                return RedirectToAction("Index");
            }
            else 
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
