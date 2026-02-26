using Microsoft.AspNetCore.Mvc;
using FirstProject.Models;
using FirstProject.Interfaces;

namespace FirstProject.Controllers;

public class UsersController : Controller
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    // 1. GET: /Users (List all users)
    public IActionResult Index()
    {
        var users = _userService.GetAll();
        return View(users);
    }

    // 2. GET: /Users/Details/1
    public IActionResult Details(int id)
    {
        var user = _userService.GetById(id);
        if (user == null) return NotFound();
        return View(user);
    }

    // 3. POST: /Users/Create
    [HttpPost]
    public IActionResult Create(User user)
    {
        if (ModelState.IsValid)
        {
            _userService.Add(user);
            return RedirectToAction(nameof(Index));
        }
        return View(user);
    }
}