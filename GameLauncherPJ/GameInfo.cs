using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncherPJ
{
    public class GameInfo
    {
        public string GameName { get; set; }
        public string GameDesc { get; set; }
        public string ExeLink { get; set; }
        public string PictureLink {  get; set; }
        public GameInfo(string gameName,string gameDesc,string exeLink,string pictureLink)  
        {
            this.GameName = gameName;
            this.GameDesc = gameDesc;
            this.ExeLink = exeLink;
            this.PictureLink = pictureLink;
        }
        public GameInfo(string gameName, string exeLink) 
        {
            //user only need to have exeLink and game Name to add a new game
            this.GameName = gameName;
            this.ExeLink = exeLink;
        }

        public GameInfo(string gameName,string gameDesc,string exeLink)
        {
            this.GameName = gameName;
            this.GameDesc = gameDesc;
            this.ExeLink = exeLink;
        }
    }
}
