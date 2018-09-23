using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.Entity;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestAvicom
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MyDBContext db;

        public MainWindow()
        {
            InitializeComponent();
            DBInitialization();

            companyGrid.SelectedIndex = 0;
        }

        public void DBInitialization ()
        {
            db = new MyDBContext();
            db.Company.Load();
            db.User.Load();
            companyGrid.ItemsSource = db.Company.Local.ToBindingList();
            userGrid.ItemsSource = db.User.Local.ToBindingList();
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.tabPnl.SelectedIndex == 0)
            {
                this.Hide();
                new AddEditCompanyWindow(this, null).Show();
            }
            else if (this.tabPnl.SelectedIndex == 1)
            {

            }
            else throw new Exception("Созданы новые вкладки, необработанные в коде");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.tabPnl.SelectedIndex == 0)
            {
                this.Hide();
                new AddEditCompanyWindow(this, (Company)this.companyGrid.Items.CurrentItem).Show();
            }
            else if (this.tabPnl.SelectedIndex == 1)
            {

            }
            else throw new Exception("Созданы новые вкладки, необработанные в коде");
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.tabPnl.SelectedIndex == 0)
            {
                Company selectedCompany = (Company)this.companyGrid.SelectedItem;
                this.db.Company.Remove(selectedCompany);
            }
            else if (this.tabPnl.SelectedIndex == 1)
            {

            }
            else throw new Exception("Созданы новые вкладки, необработанные в коде");
            db.SaveChanges();
        }
    }
}
