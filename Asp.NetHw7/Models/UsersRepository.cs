namespace Asp.NetHw7.Models
{
    public class UsersRepository
    {
        private readonly Dictionary<int, User> _users = new Dictionary<int, User>();

        public UsersRepository()
        {
            _users.Add(1, new User(1, "Алексей", 24, 3500m, "Junior Backend Developer"));
            _users.Add(2, new User(2, "Мария", 29, 4200m, "Middle Frontend Developer"));
            _users.Add(3, new User(3, "Иван", 35, 6000m, "Senior Fullstack Developer"));
            _users.Add(4, new User(4, "Елена", 27, 3000m, "QA Engineer"));
            _users.Add(5, new User(5, "Дмитрий", 32, 7000m, "Team Lead"));
        }

        public IEnumerable<User> GetAll() => _users.Values;

        public IEnumerable<User> SearchByName(string name)
        {
            return _users.Values.Where((User user) => user.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<User> SearchByPosition(string position)
        {
            return _users.Values.Where((User user) => user.Position.Contains(position, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<User> SortByAge()
        {
            return _users.Values.OrderBy(user => user.Age);
        }

        public IEnumerable<User> SortBySalary()
        {
            return _users.Values.OrderBy(user => user.Salary);
        }
    }
}
