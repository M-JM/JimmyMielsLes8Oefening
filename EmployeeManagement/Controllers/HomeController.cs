using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EmployeeManagement.DataAccessLayer.Models;
using EmployeeManagement.DataAccessLayer.Repositories;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace EmployeeManagement.Controllers
{
    //[Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IEmployeeRepository employeeRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _employeeRepository = employeeRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        //[Route("~/Home")]
        //[Route("~/")]
        public IActionResult Index()
        {
            var employeeList = _employeeRepository.GetAll();
            return View(employeeList);
        }

        //[Route("{id?}")]
        public IActionResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetById(id ?? 1),
                PageTitle = "Employee Details"
            };

            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                List<string> uniqueFilenames = new List<string>();
                if (model.Photos != null && model.Photos.Count> 0)
                {
                    foreach(IFormFile photo in model.Photos) { 
                    var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    uniqueFileName = $"{Guid.NewGuid().ToString()}_{photo.FileName}";
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    photo.CopyTo(new FileStream(filePath, FileMode.Create));
                        uniqueFilenames.Add(uniqueFileName);
                }
                }

                var newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    BankAccountNumber = model.BankAccountNumber,
                    PhotoPath = uniqueFilenames.First(),
                    SecondPhotoPath = uniqueFilenames.Last(),

                };

                var response = _employeeRepository.Add(newEmployee);

                if (response != null && response.Id != 0)
                {
                    return RedirectToAction("Details", new { id = response.Id });
                }
            }

            return View();
        }
    }
}
