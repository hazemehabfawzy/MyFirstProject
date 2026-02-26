using FirstProject.Models;

namespace FirstProject.Interfaces;

public interface IUserService
{
    IEnumerable<User> GetAll();
    User? GetById(int id);
    void Add(User user);
}