using System.Data.Entity;

namespace TestAvicom
{
    public class MyDBContext : DbContext
    {
        /// <summary>
        /// Конструктор по-умолчанию
        /// </summary>
        public MyDBContext() : base("TestAvicom")
        {

        }

        /// <summary>
        /// Получение данных для обоих наборов
        /// </summary>
        public void LoadAll()
        {
            User.Load();
            Company.Load();
        }

        /// <summary>
        /// Набор данных Пользователей
        /// </summary>
        public DbSet<User> User { get; set; }

        /// <summary>
        /// Набор данных Компаний
        /// </summary>
        public DbSet<Company> Company { get; set; }

    }
}
