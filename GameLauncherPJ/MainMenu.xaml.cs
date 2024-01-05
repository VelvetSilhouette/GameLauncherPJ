using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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

        // TODO: nam ngu
        public MainMenu()
        {
            InitializeComponent();
            gameList = new ObservableCollection<GameInfo>();
            //Test Game
            GameList.Add(new GameInfo("A", "A", "steam://rungameid/108710", "C:\\Users\\thanh\\OneDrive\\Pictures\\f55.png"));
            GameList.Add(new GameInfo("A", "A", "A", "Resources\\Game_Launcher_Icon_Large.png"));
            this.DataContext = this;
        }
        public void Close_Btn2_Click(object sender, RoutedEventArgs e)
        {
            //literally just a close button for the application because Windows Border is ugly af
            this.Close();
        }
        private void ScreenMode_btn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState == WindowState.Normal? WindowState = WindowState.Maximized : WindowState=WindowState.Normal;
            this.ResizeMode = WindowState == WindowState.Normal? ResizeMode.CanResize : ResizeMode.NoResize;
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
            //Create an object to get exe link to run the app
            GameInfo gametoprocess = game_list.SelectedItem as GameInfo;
            //Process start, checck exe link to see if it a steam link or normal exe link to process correctly
            if(gametoprocess.ExeLink.Contains("steam://"))
            {
                Process.Start(@"C:\Program Files (x86)\Steam\Steam.exe", gametoprocess.ExeLink);
            }
            else
            {
                Process.Start(gametoprocess.ExeLink);
            }    
            
        }
        //IPropertychanged to handle Adding new Game to ObservableCollection GameList
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if((PropertyChanged != null))
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }           
        }

        private void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(game_list.SelectedItem != null)
            {
                GameInfo SelectedGame = game_list.SelectedItem as GameInfo;
                EditMenu edit1 = new EditMenu(this,SelectedGame);
                edit1.ShowDialog();
                //Open Edit menu of selected game 
            }
        }
        public void FinishEdit(GameInfo EditedGame)
        {
            //Change Selected Game info to Edited one
            game_list.SelectedItem = EditedGame;
        }

        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
