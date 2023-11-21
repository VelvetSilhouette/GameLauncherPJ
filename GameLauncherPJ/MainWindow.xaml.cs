﻿using System;
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
        string testaccountpassword = "admin";

        public void Close_Btn_Click(object sender, RoutedEventArgs e)
        {
            //literally just a close button for the application because Windows Border is ugly af
            this.Close();
        }

        private void Minimize_Btn_Click(Object sender, RoutedEventArgs e)
        {
            // Minimized button
            this.WindowState = WindowState.Minimized;
        }
        private void Usernametxtbox_GotFocus(object sender, RoutedEventArgs e)
        {
            usernamelbl.Visibility = Visibility.Hidden;
        }
        private void Usernametxtbox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Usernametxtbox.Text == "")
            {
                usernamelbl.Visibility = Visibility.Visible;
            }
        }

        //making a show password button
        private void Passwordtxtbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ShowPassword_btn.Visibility = Passwordtxtbox.Password.Length > 0 || Passwordshowtxtbox.Text.Length > 0 ? Visibility.Visible : Visibility.Hidden;
        }
        //show/hide password when clicking
        private void ShowPassword_btn_Click(object sender, RoutedEventArgs e)
        {
            //Show password button
            Passwordshowtxtbox.Visibility = Passwordshowtxtbox.Visibility = Passwordtxtbox.Visibility == Visibility.Visible ? Visibility.Visible : Visibility.Hidden;
            Passwordtxtbox.Visibility = Passwordtxtbox.Visibility = Passwordshowtxtbox.Visibility == Visibility.Visible ? Visibility.Visible : Visibility.Hidden;

          /*  if (Passwordshowtxtbox.Visibility == Visibility.Visible)
            {
                Passwordshowtxtbox.Visibility = Visibility.Hidden;
                Passwordtxtbox.Visibility = Visibility.Visible;
                Passwordtxtbox.Password = Passwordshowtxtbox.Text;
            }
            else
            {
                Passwordtxtbox.Visibility = Visibility.Hidden;
                Passwordshowtxtbox.Visibility = Visibility.Visible;
                Passwordshowtxtbox.Text = Passwordtxtbox.Password.ToString();
            }*/
        }
        //limit password length to 16 characters
        private void Passwordtxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Passwordtxtbox.Password.Length >= 16)
            { e.Handled = true; }
        }

        private void Passwordtxtbox_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordlbl.Visibility = Visibility.Hidden;
        }

        private void Passwordtxtbox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Passwordtxtbox.Password.ToString() == "" && Passwordshowtxtbox.Text == "")
            {
                passwordlbl.Visibility = Visibility.Visible;
            }
        } 


        private void Passwordshowtxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Passwordshowtxtbox.Text.Length >= 16)
            { e.Handled = true;}    
        }
        //Login button, for now use a test account to test login to MainMenu
        //id: admin | password:admin
        private void Login_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Usernametxtbox.Text == testaccountid)
            {
                if(Passwordtxtbox.Password.ToString() == testaccountpassword || Passwordshowtxtbox.Text == testaccountpassword)
                { 
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please Enter the right account information","Wrong account or password");
                }
            }
            else
            { MessageBox.Show("Please Enter the right account information","Wrong account or password"); }

        }
        private void Passwordshowtxtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Passwordshowtxtbox.Text.Length == 0 && Passwordshowtxtbox.Visibility == Visibility.Visible)
            {
                Passwordshowtxtbox.Visibility = Visibility.Hidden;
                Passwordtxtbox.Visibility = Visibility.Visible;
                Passwordtxtbox.Password = "";
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
