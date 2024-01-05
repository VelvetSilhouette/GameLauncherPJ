using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for EditMenu.xaml
    /// </summary>
    public partial class EditMenu : Window,INotifyPropertyChanged
    {
        MainMenu MainMenu1 { get; set; }

        public GameInfo EditedGame { get; set; }
        private GameInfo selectedEdit;
        //create a public instance of Selected game so it can bring it properties to editMenu
        public GameInfo SelectedEdit { get { return selectedEdit; } set { selectedEdit = value; OnPropertyChanged("SelectedEdit"); } }
        public EditMenu(MainMenu mainMenu,GameInfo SelectedGame)
        {
            
            InitializeComponent();
            MainMenu1 = new MainMenu();
            SelectedEdit = SelectedGame;
            this.DataContext = this;
            //create new instance of MainMenu to run a method CloseEdit
            //Export SelectedGame Info object to Edit
        }
        private void Close_btn3_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //Close window
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            if (GameName_TxtBox.Text != "" && GameExeLink_TxtBox.Text !="")
            {
                EditedGame = new GameInfo(GameName_TxtBox.Text, GameDesc_TxtBox.Text, GameExeLink_TxtBox.Text, GameImg_TxtBox.Text);
                MainMenu1.FinishEdit(EditedGame);
                this.Close();
                //Import Edited object back to selected Item using FinishEdit Method in MainMenu
            }  
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if ((PropertyChanged != null))
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void ExeLinkButton_Click(object sender, RoutedEventArgs e)
        {
            //Open a DialogMenu to get Link of Exe File from user
            var OpenDialog = new OpenFileDialog()
            {
            Filter = "Executable Files (*.exe)|*.exe",
            Title = "Select Executable File in game folder",
            };
            bool?success=OpenDialog.ShowDialog();
            if(success==true)
            {
                GameExeLink_TxtBox.Text = (string)OpenDialog.FileName;
                //get the exe link to replace the current one
            }
            else
            {
                //nothing happen
            }

        }

        private void PictureLinkButton_Click(object sender, RoutedEventArgs e)
        {
            //Open a DialogMenu to get Link of picture File from user
            var OpenDialog = new OpenFileDialog()
            {
                Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG",
            Title = "Select a picture for game banner",
            };
            bool? success = OpenDialog.ShowDialog();
            if (success == true)
            {
                GameExeLink_TxtBox.Text = (string)OpenDialog.FileName;
                //get the the new image link to replace the current one
            }
            else
            {
                //nothing happen
            }
        }
    }
}
