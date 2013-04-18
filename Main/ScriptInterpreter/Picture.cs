using System.Threading;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTestTool
{
    class PictureScriptInterpreter
    {
        private Data date;
        private Dm.dmsoft dm;
        char[] splitChar = new char[] {'(', ')', '[', ']', ',' , '='};
        string[] splitCommand;

         //执行命令
        public bool ExeCommand(string command, Logic logic) {
            date = logic.Data;
            dm = logic.DmPlug;

            if (command.IndexOf("如果") == 0) {
                splitCommand = command.Split(splitChar, StringSplitOptions.RemoveEmptyEntries);
                if (splitCommand.Length < 3 ) {
                    return false;
                }
                if (splitCommand[1] == "找图")
                {
                    object posX, posY;
                    dm.FindPic(0, 0, 1024, 768, splitCommand[2]+".bmp", "000000", 0.8, 0, out posX, out posY);
                    if ((int)posX > 0){
                        return true;
                    }
                    
                }
                return false;
            }
            return true;
        }
    }
}
