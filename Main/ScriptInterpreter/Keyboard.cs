using System.Threading;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTestTool
{
    class KeyboardScriptInterpreter
    {
        private Data date;
        private Dm.dmsoft dm;
        char[] splitChar = new char[] { '(', ')', '[', ']', ',' };
        string[] splitCommand;

         //执行命令
        public bool ExeCommand(string command, Logic logic) {
            date = logic.Data;
            dm = logic.DmPlug;

            if (command.IndexOf("鼠标左键单击") == 0) {
                splitCommand = command.Split(splitChar);
                if (splitCommand.Length < 4 ) {
                    return false;
                }
                int x = int.Parse(splitCommand[1]);
                int y = int.Parse(splitCommand[2]);
                if (x < 1 || y < 1) {
                    return false;
                }
                dm.MoveTo(x, y);
                dm.LeftDoubleClick();
            }

            return true;
        }
    }
}
