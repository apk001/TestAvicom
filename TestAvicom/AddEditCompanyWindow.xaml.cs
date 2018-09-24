using System.Windows;
using System.Linq;

namespace TestAvicom
{
    /// <summary>
    /// Логика взаимодействия для AddEditCompanyWindow.xaml
    /// </summary>
    public partial class AddEditCompanyWindow : Window
    {
        /// <summary>
        /// Главная форма
        /// </summary>
        private Window callWindow;
        
        /// <summary>
        /// Изменяемый/добавляемый элемент
        /// </summary>
        private Company element;

        /// <summary>
        /// Основной конструктор
        /// </summary>
        /// <param name="callWindow">Ссылка на главную форму</param>
        /// <param name="element">Обрабатываемый элемент</param>
        public AddEditCompanyWindow(Window callWindow, Company element)
        {
            InitializeComponent();
            this.callWindow = callWindow;
            this.element = element;
            if (element != null)
            {
                this.NameTB.Text = element.Name.TrimEnd(' ');
                this.StateCB.Text = element.ContractStatus.TrimEnd(' ');
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

        /// <summary>
        /// Закрытие формы
        /// </summary>
        /// <param name="sender">Вызывающий</param>
        /// <param name="e">Аргументы</param>
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Обработчик события подтверждения создания/изменения объекта БД
        /// </summary>
        /// <param name="sender">Вызывающий</param>
        /// <param name="e">Агрументы</param>
        private void AcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (((MainWindow)callWindow).db.Company.Local.First(x => x.Name.TrimEnd(' ').Equals(this.NameTB.Text)) == null)
                {
                    if (element == null)
                    {
                        ((MainWindow)callWindow).db.Company.Add(new Company(this.NameTB.Text, this.StateCB.Text));
                    }
                    else
                    {
                        element.Name = this.NameTB.Text;
                        element.ContractStatus = this.StateCB.Text;
                    }
                    ((MainWindow)callWindow).db.SaveChanges();
                    ((MainWindow)callWindow).NonItemsStateCheck();
                    ((MainWindow)callWindow).SelectFirstItem();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Компания с таким названием уже существует в базе данных", "Повторное добавление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException alert)
            {
                MessageBox.Show("Компания с таким названием уже существует в базе данных", "Повторное добавление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
