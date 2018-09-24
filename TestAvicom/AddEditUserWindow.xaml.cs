using System.Linq;
using System.Windows;


namespace TestAvicom
{
    /// <summary>
    /// Логика взаимодействия для AddEditUserWindow.xaml
    /// </summary>
    public partial class AddEditUserWindow : Window
    {
        /// <summary>
        /// Главная форма
        /// </summary>
        private Window callWindow;
        /// <summary>
        /// Изменяемый/добавляемый объект БД
        /// </summary>
        private User element;

        /// <summary>
        /// Основной конструктор
        /// </summary>
        /// <param name="callWindow">Ссылка на главную форму</param>
        /// <param name="element">Изменяемый/добавляемый объект БД</param>
        public AddEditUserWindow(Window callWindow, User element)
        {
            InitializeComponent();
            this.callWindow = callWindow;
            this.element = element;
            this.CompanyCB.ItemsSource = ((MainWindow)callWindow).db.Company.Local.Select(x => x.Name.TrimEnd(' '));
            if (element != null) // при редактировании объекта - перенести значения полей и избавиться от пробелов из БД
            {
                this.NameTB.Text = element.Name.TrimEnd(' ');
                this.LoginTB.Text = element.Login.TrimEnd(' ');
                this.PasswordTB.Text = element.Password.TrimEnd(' ');
                this.CompanyCB.Text = ((MainWindow)callWindow).db.Company.First(x => x.ID == element.Company_ID).Name.TrimEnd(' ');
            }
        }

        /// <summary>
        /// Обработчик события при закрытии окна
        /// </summary>
        /// <param name="sender">Вызывающий</param>
        /// <param name="e">Аргументы</param>
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Обработчик события при создании/редактировании объекта
        /// </summary>
        /// <param name="sender">Вызывающий</param>
        /// <param name="e">Аргументы</param>
        private void AcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            int company_id = ((MainWindow)callWindow).db.Company.First(x => x.Name.Substring(0, this.CompanyCB.Text.Length) == this.CompanyCB.Text).ID; // Запретил использовать Trim и его вариации?..
            try
            {
                if (((MainWindow)callWindow).db.User.Local.First(x => x.Login.TrimEnd(' ').Equals(this.NameTB.Text)) == null)
                { 
                    if (element == null)
                    {
                        ((MainWindow)callWindow).db.User.Add(new User(this.NameTB.Text, this.LoginTB.Text, this.PasswordTB.Text, company_id));
                    }
                    else
                    {
                        element.Name = this.NameTB.Text;
                        element.Login = this.LoginTB.Text;
                        element.Password = this.PasswordTB.Text;
                        element.Company_ID = company_id;
                    }
                    ((MainWindow)callWindow).db.SaveChanges();
                    ((MainWindow)callWindow).NonItemsStateCheck();
                    ((MainWindow)callWindow).SelectFirstItem();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Пользователь с таким логином уже существует в базе данных", "Повторное добавление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException alert)
            {
                MessageBox.Show("Пользователь с таким логином уже существует в базе данных", "Повторное добавление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// Обработчик события при закрытии окна
        /// </summary>
        /// <param name="sender">Вызывающий</param>
        /// <param name="e">Аргументы</param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            callWindow.Show();
        }
    }
}
