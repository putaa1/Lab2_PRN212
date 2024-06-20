using BusinessObjects.Models;
using Services;
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
using WPFApp;

namespace ProductManagement
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IAccountService iaccountService;
        public LoginWindow()
        {
            InitializeComponent();
            iaccountService = new AccountService();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            AccountMember acc = iaccountService.GetAccountById(txtUser.Text);
            if (acc != null && acc.MemberPassword.Equals(txtPass.Password) && acc.MemberRole == 1)
            {
                this.Hide();
                MainWindow main = new MainWindow();
                main.Show();
            }
            else
            {
                MessageBox.Show("You are not permission !");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
