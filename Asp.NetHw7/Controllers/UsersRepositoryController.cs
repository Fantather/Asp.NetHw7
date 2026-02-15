using Asp.NetHw7.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Asp.NetHw7.Controllers
{
    public class UsersRepositoryController : Controller
    {
        private readonly UsersRepository _usersRepository;
        public UsersRepositoryController(UsersRepository usersRepsitory)
        {
            _usersRepository = usersRepsitory;
        }

        public IActionResult Index(string name, string position, string[] sortBy)
        {
            var users = _usersRepository.GetFilteredAndSortedUsers(name, position, sortBy);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_UsersTable", users);
            }

            return View("Index", users);
        }
    }
}
