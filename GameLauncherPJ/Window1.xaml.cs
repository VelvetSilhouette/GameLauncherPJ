using MySql.Data.MySqlClient;
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

namespace GameLauncherPJ
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public string UserName { get; set; }

        public Window1()
        {
            InitializeComponent();
            UserName = GetUserName();
            DataContext = this;
        }

        private string GetUserName()
        {
            string userName = "";
            string cmdText = "select username from users where username = 'admin'";

            using var conn = new MySqlConnection("SERVER=localhost;PORT=3306;DATABASE=gamelauncheruser;USER=root;PASSWORD=26091997");
            conn.Open();
            var cmd = new MySqlCommand(cmdText, conn);
            userName = cmd.ExecuteScalar().ToString();

            return userName ?? "";
        }
    }
}
