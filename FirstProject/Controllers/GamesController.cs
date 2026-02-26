using Microsoft.AspNetCore.Mvc;
using FirstProject.Models;
using FirstProject.Interfaces;

public class GamesController : Controller
{
    private readonly IGameService _gameService;

    // Constructor Injection
    public GamesController(IGameService gameService) => _gameService = gameService;

    // 1. GET: /Games (List all)
    public IActionResult Index() => View(_gameService.GetAll());

    // 2. GET: /Games/Details/5
    public IActionResult Details(int id) => View(_gameService.GetById(id));

    // 3. POST: /Games/Create
    [HttpPost]
    public IActionResult Create(Game game)
    {
        _gameService.Add(game);
        return RedirectToAction(nameof(Index));
    }
}