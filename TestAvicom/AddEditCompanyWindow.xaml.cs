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
    /// Логика взаимодействия для AddEditCompanyWindow.xaml
    /// </summary>
    public partial class AddEditCompanyWindow : Window
    {
        private Window callWindow;
        private Company element;

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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            callWindow.Show();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AcceptBtn_Click(object sender, RoutedEventArgs e)
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
            this.Close();
        }
    }
}
