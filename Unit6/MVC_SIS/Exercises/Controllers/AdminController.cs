﻿using Exercises.Models.Data;
using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Majors()
        {
            IEnumerable<Major> model = MajorRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddMajor()
        {
            return View(new Major());
        }

        [HttpPost]
        public ActionResult AddMajor(Major major)
        {
            MajorRepository.Add(major.MajorName);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult EditMajor(int id)
        {
            Major major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult EditMajor(Major major)
        {
            MajorRepository.Edit(major);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult DeleteMajor(int id)
        {
            Major major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult DeleteMajor(Major major)
        {
            MajorRepository.Delete(major.MajorId);
            return RedirectToAction("Majors");
        }




        [HttpGet]
        public ActionResult GetStates()
        {
        IEnumerable<State> states = StateRepository.GetAll();
        return View(states);
        }

        [HttpGet]
        public ActionResult AddState()
        {
            return View(new State());
        }

        [HttpPost]
        public ActionResult AddState(State state)
        {
            StateRepository.Add(state);
            return RedirectToAction("GetStates");
        }

        [HttpGet]
        public ActionResult EditState(string abbreviation)
        {
            State selectedState = StateRepository.Get(abbreviation);
            return View(selectedState);
        }

        [HttpPost]
        public ActionResult EditState(State state)
        {
            StateRepository.Edit(state);
            return RedirectToAction("GetStates");
        }

        [HttpGet]
        public ActionResult DeleteState(string abbreviation)
        {
            State state = StateRepository.Get(abbreviation);
            return View(state);
        }

        [HttpPost]
        public ActionResult DeleteState(State state)
        {
            StateRepository.Delete(state.StateAbbreviation);
            return RedirectToAction("GetStates");
        }






        [HttpGet]
        public ActionResult GetCourses() {
            IEnumerable<Course> model = CourseRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            return View(new Course());
        }

        [HttpPost]
        public ActionResult AddCourse(string courseName)
        {
            CourseRepository.Add(courseName);
            return RedirectToAction("GetCourses");
        }

        [HttpGet]
        public ActionResult EditCourse(int CourseId)
        {
            Course course = CourseRepository.Get(CourseId);
            return View(course);
        }

        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            CourseRepository.Edit(course);
            return RedirectToAction("GetCourses");
        }

        [HttpGet]
        public ActionResult DeleteCourse(int CourseId)
        {
            Course course = CourseRepository.Get(CourseId);
            return View(course);
        }

        [HttpPost]
        public ActionResult DeleteCourse(Course course)
        {
            CourseRepository.Delete(course.CourseId);
            return RedirectToAction("GetCourses");
        }

    }
}