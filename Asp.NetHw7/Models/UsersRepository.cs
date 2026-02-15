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


        // Чем я занимаюсь :/
        // Применяет разные сортировки одновременно
        public IEnumerable<User> GetFilteredAndSortedUsers(string name, string position, string[] sortBy)
        {
            IEnumerable<User> query = _users.Values;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(u => u.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(position))
            {
                query = query.Where(u => u.Position.Contains(position, StringComparison.OrdinalIgnoreCase));
            }


            // Применяю множественную сортировку, если массив не пуст
            if (sortBy != null && sortBy.Length > 0)
            {
                IOrderedEnumerable<User> orderedQuery = null;

                foreach (string sortParam in sortBy)
                {
                    if (sortParam == "Age")
                    {
                        // Если это первая сортировка — использую OrderBy, если вторичная — ThenBy
                        orderedQuery = orderedQuery == null
                            ? query.OrderBy(u => u.Age)
                            : orderedQuery.ThenBy(u => u.Age);
                    }
                    else if (sortParam == "Salary")
                    {
                        orderedQuery = orderedQuery == null
                            ? query.OrderBy(u => u.Salary)
                            : orderedQuery.ThenBy(u => u.Salary);
                    }
                }

                // Если сортировка была применена, перезаписываю основной запрос
                if (orderedQuery != null)
                {
                    query = orderedQuery;
                }
            }

            return query;
        }
    }
}
