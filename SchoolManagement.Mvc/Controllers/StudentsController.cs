using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Mvc.Data;

namespace SchoolManagement.Mvc.Controllers;

public class StudentsController(SchoolContext db) : Controller
{
    public async Task<IActionResult> Index() => View(await db.Students.OrderBy(s => s.FullName).ToListAsync());
}
