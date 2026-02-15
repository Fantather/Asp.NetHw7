using Asp.NetHw7.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetHw7.Controllers
{
    public class UsersRepositoryController : Controller
    {
        private readonly UsersRepository _usersRepository;
        public UsersRepositoryController(UsersRepository usersRepsitory)
        {
            _usersRepository = usersRepsitory;
        }

        public IActionResult Index(string name, string position)
        {
            IEnumerable<User> users = _usersRepository.GetAll();

            if (!string.IsNullOrWhiteSpace(name))
            {
                users.
            }

            return View(users);
        }
    }
}
