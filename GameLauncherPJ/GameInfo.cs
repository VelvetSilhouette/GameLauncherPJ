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
        public GameInfo(string gameName, string gameDesc, string exeLink) 
        {
            this.GameName = gameName;
            this.GameDesc = gameDesc;
            this.ExeLink = exeLink;
        }
    }
}
