using CoreWebCrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebCrud.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly CompanyDBContext _context;

        public DepartmentController(CompanyDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await _context.Departments.ToListAsync();
            return View(departments);
        }

        //AddOrEdit Get Method
        public async Task<IActionResult> AddOrEdit(int? depid)
        {
            ViewBag.PageName = depid == null ? "Create Department" : "Edit Department";
            ViewBag.IsEdit = depid == null ? false : true;
            if (depid == null)
            {
                return View();
            }
            else
            {
                var department = await _context.Departments.FindAsync(depid);

                if (department == null)
                {
                    return NotFound();
                }
                return View(department);
            }
        }

        //AddOrEdit Post Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int deptid, [Bind("DepId,DepartmentName,CreatedDate")]
        Department departmentData)
        {
            bool IsDepartmentExist = false;

            Department department = await _context.Departments.FindAsync(deptid);

            if (department != null)
            {
                IsDepartmentExist = true;
            }
            else
            {
                department = new Department();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    department.DepartmentName = departmentData.DepartmentName;
                    department.CreatedDate = departmentData.CreatedDate;                   

                    if (IsDepartmentExist)
                    {
                        _context.Update(department);
                    }
                    else
                    {
                        _context.Add(department);
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // Employee Details
        public async Task<IActionResult> Details(int? deptid)
        {
            if (deptid == null)
            {
                return NotFound();
            }
            var department = await _context.Departments.FirstOrDefaultAsync(m => m.DepId == deptid);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // GET: Employees/Delete/1
        public async Task<IActionResult> Delete(int? deptid)
        {
            if (deptid == null)
            {
                return NotFound();
            }
            var department = await _context.Departments.FirstOrDefaultAsync(m => m.DepId == deptid);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Employees/Delete/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int deptid)
        {
            var department = await _context.Departments.FindAsync(deptid);
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
