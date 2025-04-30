using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View(); // Yönetici paneli sayfası
    }

    public IActionResult UserList()
    {
        // Tüm kullanıcıları listeleyebilirsiniz.
        return View();
    }

    // Diğer yönetici işlemleri burada yapılabilir
}
