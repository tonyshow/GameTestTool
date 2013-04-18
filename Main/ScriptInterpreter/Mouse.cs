using System.Threading;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTestTool
{
    class MouseScriptInterpreter
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
                dm.LeftClick();
                int delayTime = 0;
                if (splitCommand.Length > 4 && (delayTime = int.Parse(splitCommand[3])) > 0) {
                    Thread.Sleep(delayTime);
                }
            }

            if (command.IndexOf("鼠标点击延迟") == 0) {
                splitCommand = command.Split(splitChar);
                if (splitCommand.Length < 3) {
                    return false;
                }
                dm.SetMouseDelay(splitCommand[1], int.Parse(splitCommand[2]));
            }

            return true;
        }
    }
}
