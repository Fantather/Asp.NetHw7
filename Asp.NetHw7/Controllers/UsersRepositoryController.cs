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

        public IActionResult Index()
        {
            return View(_usersRepository.Users);
        }

        public IActionResult SearchByName(string name)
        {
            return View("Index", _usersRepository.SearchByName(name));
        }

        public IActionResult SearchByPosition(string position)
        {
            return View("Index", _usersRepository.SearchByPosition(position));
        }

        public IActionResult SortByAge()
        {
            return View("Index", _usersRepository.SortByAge());
        }

        public IActionResult SortBySalary()
        {
            return View("Index", _usersRepository.SortBySalary());
        }
    }
}
