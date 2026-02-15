namespace Asp.NetHw7.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public string Position { get; set; }

        public User(int id, string name, int age, decimal salary, string position)
        {
            Id = id;
            Name = name;
            Age = age;
            Salary = salary;
            Position = position;
        }
    }
}
