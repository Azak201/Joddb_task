/*using Microsoft.AspNetCore.Mvc;
using JODDB_task.DAL;
using JODDB_task.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JODDB_task.Controllers;

public class UsersController(UserContext context) : Controller
{
    private readonly UserContext _context = context;
    // معالجة نموذج إضافة المستخدم
    [HttpPost]
    public async Task<IActionResult> AddUser(Users user)
    {
        if (ModelState.IsValid)
        {
            _context.Users.Add(user);  // إضافة المستخدم إلى قاعدة البيانات
            await _context.SaveChangesAsync();
            return RedirectToAction("Login","Home");
        }
        return RedirectToAction("AddUser","Home");
    }

    // معالجة بيانات تسجيل الدخول
    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

        if (user != null)
        {
            // نجاح تسجيل الدخول
            return RedirectToAction("Index", "Home");
        }

        ViewBag.ErrorMessage = "Invalid email or password.";
        return View();
    }
}*/