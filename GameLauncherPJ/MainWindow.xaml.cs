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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameLauncherPJ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();    
        }

        string testaccountid = "admin";
        string testaccountpassword = "123456";

        private void Close_Btn_Click(object sender, RoutedEventArgs e)
        {
            //literally just a close button for the application because Windows Border is ugly af
            this.Close();
        }
        
        //making a show password button with some trick since wpf passwordbox don't support it
        private void Passwordtxtbox_GotFocus(object sender, RoutedEventArgs e)
        {
            ShowPassword_btn.Visibility = Visibility.Visible;
        }

        private void Passwordtxtbox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Passwordtxtbox.Password.ToString() == "") 
            {
                ShowPassword_btn.Visibility = Visibility.Hidden;
            }         
        }
        //show/hide password when clicking
        private void ShowPassword_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Passwordshowtxtbox.Visibility == Visibility.Hidden) 
            {
                 Passwordshowtxtbox.Text = Passwordtxtbox.Password.ToString();
                Passwordtxtbox.Visibility = Visibility.Hidden;
                Passwordshowtxtbox.Visibility = Visibility.Visible;
            }
            else
            {
                Passwordtxtbox.Password = Passwordshowtxtbox.Text;
                Passwordtxtbox.Visibility = Visibility.Visible;
                Passwordshowtxtbox.Visibility = Visibility.Hidden;
            }
           
        }
        //limit password length to 16 characters
        private void Passwordtxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Passwordtxtbox.Password.Length >= 16)
            {e.Handled = true;}
        }

        private void Passwordshowtxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Passwordshowtxtbox.Text.Length >= 16)
            { e.Handled = true;}    
        }
        //Login button, for now use a test account to test login to MainMenu
        private void Login_btn_Click(object sender, RoutedEventArgs e)
        {
            if(Usernametxtbox.Text == testaccountid)
            {
                if(Passwordtxtbox.Password.ToString() == testaccountpassword || Passwordshowtxtbox.Text == testaccountpassword)
                {
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Show();
                    this.Close();
                }
            }

        }
    }
}
