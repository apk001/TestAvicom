using System.ComponentModel;

namespace TestAvicom
{
    public class User : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private string login;
        private string password;
        private int company_ID;

        public event PropertyChangedEventHandler PropertyChanged;

        public User()
        {

        }

        public User(string name, string login, string password, int company_ID)
        {
            this.name = name;
            this.login = login;
            this.password = password;
            this.company_ID = company_ID;
        }

        public int ID
        {
            get { return id; }
            set
            {
                if (id == 0)
                    id = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                this.name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Login
        {
            get { return login; }
            set
            {
                this.login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                this.password = value;
                OnPropertyChanged("Password");
            }
        }

        public int Company_ID
        {
            get { return company_ID; }
            set
            {
                this.company_ID = value;
                OnPropertyChanged("Company_ID");
            }
        }

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
