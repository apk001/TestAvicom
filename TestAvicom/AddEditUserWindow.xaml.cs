using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TestAvicom
{
    /// <summary>
    /// Логика взаимодействия для AddEditUserWindow.xaml
    /// </summary>
    public partial class AddEditUserWindow : Window
    {
        private Window callWindow;
        private User element;

        public AddEditUserWindow(Window callWindow, User element)
        {
            InitializeComponent();
            this.callWindow = callWindow;
            this.element = element;
            this.CompanyCB.ItemsSource = ((MainWindow)callWindow).db.Company.Local.Select(x => x.Name.TrimEnd(' '));
            if (element != null)
            {
                this.NameTB.Text = element.Name.TrimEnd(' ');
                this.LoginTB.Text = element.Login.TrimEnd(' ');
                this.PasswordTB.Text = element.Password.TrimEnd(' ');
                this.CompanyCB.Text = ((MainWindow)callWindow).db.Company.First(x => x.ID == element.Company_ID).Name.TrimEnd(' ');
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            int company_id = ((MainWindow)callWindow).db.Company.First(x => x.Name.Substring(0, this.CompanyCB.Text.Length) == this.CompanyCB.Text).ID;
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
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            callWindow.Show();
        }
    }
}
