using FirstProject.Interfaces;
using FirstProject.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Add MVC Services
builder.Services.AddControllersWithViews();

// 2. Register your Services (Singleton keeps data alive while the app runs)
builder.Services.AddSingleton<IGameService, MockGameService>();
builder.Services.AddSingleton<IUserService, MockUserService>();

var app = builder.Build();

// 3. Configure HTTP pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// 4. Set Default Route (This tells the app what to show at 'localhost')
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Games}/{action=Index}/{id?}");

app.Run();

// --- MOCK DATA IMPLEMENTATIONS ---

public class MockGameService : IGameService {
    private List<Game> _games = new() { 
        new Game { Id = 1, Title = "Elden Ring", Genre = "RPG" },
        new Game { Id = 2, Title = "Cyberpunk 2077", Genre = "Action" }
    };
    public IEnumerable<Game> GetAll() => _games;
    public Game? GetById(int id) => _games.FirstOrDefault(g => g.Id == id);
    public void Add(Game game) { game.Id = _games.Max(g => g.Id) + 1; _games.Add(game); }
}

public class MockUserService : IUserService {
    private List<User> _users = new() { 
        new User { Id = 1, Username = "Alice", Email = "alice@example.com" },
        new User { Id = 2, Username = "Bob", Email = "bob@example.com" }
    };
    public IEnumerable<User> GetAll() => _users;
    public User? GetById(int id) => _users.FirstOrDefault(u => u.Id == id);
    public void Add(User user) { user.Id = _users.Max(u => u.Id) + 1; _users.Add(user); }
}