using System.ComponentModel;

namespace TestAvicom
{
    /// <summary>
    /// Модель Пользователя
    /// </summary>
    public class User : INotifyPropertyChanged
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        private int id;

        /// <summary>
        /// Имя пользователя
        /// </summary>
        private string name;

        /// <summary>
        /// Логин пользователя
        /// </summary>
        private string login;

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        private string password;

        /// <summary>
        /// Идентификатор Компании-владельца
        /// </summary>
        private int company_ID;

        /// <summary>
        /// Событие при обновлении значений свойств
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Конструктор по-умолчанию
        /// </summary>
        public User()
        {

        }

        /// <summary>
        /// Конструктор для создания новых объектов
        /// </summary>
        /// <param name="name">Имя пользователя</param>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <param name="company_ID">Идентификатор Компании-владельца</param>
        public User(string name, string login, string password, int company_ID)
        {
            this.name = name;
            this.login = login;
            this.password = password;
            this.company_ID = company_ID;
        }

        /// <summary>
        /// Задает или возвращает значение идентификатора Пользователя
        /// </summary>
        public int ID
        {
            get { return id; }
            set
            {
                if (id == 0)
                    id = value;
            }
        }

        /// <summary>
        /// Задает или возвращает имя Пользователя
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                this.name = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Задает или возвращает логин Пользователя
        /// </summary>
        public string Login
        {
            get { return login; }
            set
            {
                this.login = value;
                OnPropertyChanged("Login");
            }
        }

        /// <summary>
        /// Задает или возвращает пароль Пользователя
        /// </summary>
        public string Password
        {
            get { return password; }
            set
            {
                this.password = value;
                OnPropertyChanged("Password");
            }
        }

        /// <summary>
        /// Задает или возвращает идентификатор Компании-владельца
        /// </summary>
        public int Company_ID
        {
            get { return company_ID; }
            set
            {
                this.company_ID = value;
                OnPropertyChanged("Company_ID");
            }
        }

        /// <summary>
        /// Вызов события
        /// </summary>
        /// <param name="property">Имя свойства</param>
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
