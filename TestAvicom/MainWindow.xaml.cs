using System;
using System.Windows;
using System.Data.Entity;
using System.Windows.Controls;

namespace TestAvicom
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// Контекст БД
        /// </summary>
        public MyDBContext db;

        /// <summary>
        /// Конструктор по-умолчанию
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DBInitialization();
            SelectFirstItem();
        }

        /// <summary>
        /// Подключение к БД
        /// </summary>
        public void DBInitialization()
        {
            db = new MyDBContext();
            db.LoadAll();
            companyGrid.ItemsSource = db.Company.Local.ToBindingList();
            userGrid.ItemsSource = db.User.Local.ToBindingList();
        }

        /// <summary>
        /// Обработчик события для "универсального" добавления объекта
        /// </summary>
        /// <param name="sender">Вызывающий</param>
        /// <param name="e">Аргументы</param>
        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.tabPnl.SelectedIndex == 0)
            {
                this.Hide();
                new AddEditCompanyWindow(this, null).Show();
            }
            else if (this.tabPnl.SelectedIndex == 1)
            {
                this.Hide();
                new AddEditUserWindow(this, null).Show();
            }
            else throw new Exception("Созданы новые вкладки, необработанные в коде");
        }

        /// <summary>
        /// Обработчик события для удаления объекта контекста БД
        /// </summary>
        /// <param name="sender">Вызывающий</param>
        /// <param name="e">Аргументы</param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        /// <summary>
        /// Обработчик события для "универсального" редактирования объектов БД
        /// </summary>
        /// <param name="sender">Вызывающий</param>
        /// <param name="e">Аргументы</param>
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.tabPnl.SelectedIndex == 0)
            {
                this.Hide();
                new AddEditCompanyWindow(this, (Company)this.companyGrid.SelectedItem).Show();
            }
            else if (this.tabPnl.SelectedIndex == 1)
            {
                this.Hide();
                new AddEditUserWindow(this, (User)this.userGrid.SelectedItem).Show();
            }
            else throw new Exception("Созданы новые вкладки, необработанные в коде");
        }

        /// <summary>
        /// Обработчик события для "универсального" удаления объектов БД
        /// </summary>
        /// <param name="sender">Вызывающий</param>
        /// <param name="e">Аргументы</param>
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            /// Возможна потеря фокуса элементами окна
            try
            {
                if (this.tabPnl.SelectedIndex == 0)
                {
                    Company selectedCompany = (Company)this.companyGrid.SelectedItem;
                    this.db.Company.Remove(selectedCompany);
                }
                else if (this.tabPnl.SelectedIndex == 1)
                {
                    User selectedUser = (User)this.userGrid.SelectedItem;
                    this.db.User.Remove(selectedUser);
                }
                else throw new Exception("Созданы новые вкладки, необработанные в коде");

                db.SaveChanges();
                db.Dispose(); // Не может выполнить каскадное удаление и обновление данных в двух представлениях - почему?..
                DBInitialization();
            }
            catch (ArgumentNullException alert)
            {
                MessageBox.Show("Выберите строку для удаления", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Управление доступностью управляющих кнопок
        /// </summary>
        public void NonItemsStateCheck()
        {
            if (tabPnl.SelectedIndex == 0)
            {
                CreateBtn.IsEnabled = true;
                EditBtn.IsEnabled = companyGrid.HasItems;
                DeleteBtn.IsEnabled = companyGrid.HasItems;
            }
            else if (tabPnl.SelectedIndex == 1)
            {
                CreateBtn.IsEnabled = companyGrid.HasItems;
                EditBtn.IsEnabled = userGrid.HasItems;
                DeleteBtn.IsEnabled = userGrid.HasItems;
            }
        }

        /// <summary>
        /// Обновление "фокуса" в таблицах
        /// </summary>
        public void SelectFirstItem()
        {
            companyGrid.SelectedIndex = 0;
            userGrid.SelectedIndex = 0;
        }

        /// <summary>
        /// Обработчик события при открытии новой вкладки
        /// </summary>
        /// <param name="sender">Вызывающий</param>
        /// <param name="e">Аргументы</param>
        private void tabPnl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NonItemsStateCheck();
            SelectFirstItem();
        }
    }
}
