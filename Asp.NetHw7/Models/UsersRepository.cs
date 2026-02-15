namespace Asp.NetHw7.Models
{
    public class UsersRepository
    {
        private readonly Dictionary<int, User> _users = new Dictionary<int, User>();

        public UsersRepository()
        {

        }

        public IEnumerable<User> SearchByName(string name)
        {
            return _users.Values.Where((User user) => user.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<User> SearchByPosition(string position)
        {
            return _users.Values.Where((User user) => user.Position.Equals(position, StringComparison.OrdinalIgnoreCase));
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
