using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JODDB_task.Models;
using JODDB_task.DAL;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
namespace JODDB_task.Controllers;

public class HomeController : Controller
{    
      private readonly UserContext _userContext;

    public HomeController(UserContext userContext)
    {
        _userContext = userContext;
    }

    public IActionResult Index()
    {
        return View();
    }
     public IActionResult ImportData()
    {
        return View();
    }
    public IActionResult Login()
    {
        return View();
    }
    public IActionResult AddUser()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
       
    // معالجة نموذج إضافة المستخدم
    [HttpPost]
    public async Task<IActionResult> AddUser(Users user)
    {
        if (ModelState.IsValid)
        {
            _userContext.Users.Add(user);  // إضافة المستخدم إلى قاعدة البيانات
            await _userContext.SaveChangesAsync();
            return RedirectToAction("Login","Home");
        }
        return RedirectToAction("AddUser","Home");
    }

    // معالجة بيانات تسجيل الدخول
    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = await _userContext.Users
            .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

        if (user != null)
        {
            // نجاح تسجيل الدخول
            return RedirectToAction("Index", "Home");
        }

        ViewBag.ErrorMessage = "Invalid email or password.";
        return View();
    }
    [HttpPost]
public async Task<IActionResult> ImportExcel(IFormFile file)
{
    if (file != null && file.Length > 0)
    {
        using (var stream = file.OpenReadStream())
        {
            using (var package = new ExcelPackage(stream))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assuming the data is in the first sheet

                var products = new List<Excel>();
                for (int i = 2; i <= worksheet.Dimension.Rows; i++) // Assuming header row is in the first row
                {
                    var product = new Excel
                    {
                        UserId = (int)worksheet.Cells[i, 1].Value,
                        UserName = (string)worksheet.Cells[i, 2].Value,
                        UserEmail = (string)worksheet.Cells[i, 3].Value,
                        UserNumber = (decimal)worksheet.Cells[i, 4].Value,
                        UserPassword = (string)worksheet.Cells[i, 5].Value
                    };
                    products.Add(product);
                }

                // Insert products into your database
                _userContext.Users.AddRange((IEnumerable<Users>)products);
                await _userContext.SaveChangesAsync();

                return RedirectToAction("Index"); // Redirect to a success page or another appropriate action
            }
        }
    }

    return View("Index"); // Or return an error view
}
}

