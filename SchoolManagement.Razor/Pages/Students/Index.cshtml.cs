using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Razor.Data;
using SchoolManagement.Razor.Models;

namespace SchoolManagement.Razor.Pages.Students;

public class IndexModel(SchoolContext db) : PageModel
{
    public List<Student> Students { get; private set; } = new();
    public async Task OnGetAsync() => Students = await db.Students.OrderBy(s => s.FullName).ToListAsync();
}
