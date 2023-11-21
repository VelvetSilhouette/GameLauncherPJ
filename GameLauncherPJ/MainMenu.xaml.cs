using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window ,INotifyPropertyChanged
    {
        private ObservableCollection<GameInfo> gameList;
        public ObservableCollection<GameInfo> GameList { get { return gameList; } set { gameList = value; OnPropertyChanged("GameList"); } }
        public MainMenu()
        {
            InitializeComponent();
            gameList = new ObservableCollection<GameInfo>();
            gameList.Add(new GameInfo("A", "Long Loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong man", "A", "Resources\\Game_Launcher_Icon_Large.png"));
            gameList.Add(new GameInfo("A", "A", "A", "Resources\\Game_Launcher_Icon_Large.png"));
            this.DataContext = this;
        }

        public void Close_Btn_Click(object sender, RoutedEventArgs e)
        {
            //literally just a close button for the application because Windows Border is ugly af
            this.Close();
        }

        private void ScreenMode_btn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState == WindowState.Normal? WindowState=WindowState.Maximized : WindowState=WindowState.Normal ;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && WindowState == WindowState.Normal) 
            {
                this.DragMove();  
            }
        }
        private void Minimize_Btn_Click(Object sender, RoutedEventArgs e)
        {
            // Minimized button
            this.WindowState = WindowState.Minimized;
        }

        private void Play_Btn_Click(object sender, RoutedEventArgs e)
        {
            //Test Adding more data to list to see if the listview update using the play button
            gameList.Add(new GameInfo("A", "A", "A", "Resources\\Game_Launcher_Icon_Large.png"));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if((PropertyChanged != null))
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }           
        }

    }
}
