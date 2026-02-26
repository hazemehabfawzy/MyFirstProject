using FirstProject.Models;

namespace FirstProject.Interfaces;

public interface IGameService
{
    IEnumerable<Game> GetAll();
    Game? GetById(int id);
    void Add(Game game);
}