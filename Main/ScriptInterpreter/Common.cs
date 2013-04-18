using System.Threading;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTestTool
{
    class CommonScriptInterpreter
    {
        private Data date;
        private Dm.dmsoft dm;
        char[] splitChar = new char[] { '(', ')', '[', ']', ',' };
        string[] splitCommand;

         //执行命令
        public bool ExeCommand(string command, Logic logic) {
            date = logic.Data;
            dm = logic.DmPlug;

            if (command.IndexOf("跳到标记") == 0 || command.IndexOf("跳到子标记") == 0) {
                splitCommand = command.Split(new char[] { '[', ']' });
                if (splitCommand.Length < 3) {
                    return false;
                }

                string commandTemp;
                string[] splitCommandTemp;
                for (int i = 0; i < date.lineCommand.Length; ++i) {
                    commandTemp = date.lineCommand[i].Trim().Replace(" ", "");
                    if (commandTemp.Length < 4 || commandTemp.IndexOf("//", 0, 3) == 0 || commandTemp.IndexOf("--", 0, 3) == 0 || commandTemp.IndexOf("/*", 0, 3) == 0) {
                        continue;
                    }
                    if (commandTemp.IndexOf("标记") == 0) {
                        splitCommandTemp = commandTemp.Split(new char[] { '[', ']' });
                        if (splitCommandTemp.Length < 3) {
                            return false;
                        }
                        if (splitCommandTemp[1] == splitCommand[1]) {
                            if (command.IndexOf("跳到子标记") == 0) {
                                logic.ScriptRunStoreIndex = logic.ScriptRunIndex;
                            }
                            logic.ScriptRunIndex = i - 1;
                            return true;
                        }
                    }
                }
            }



            return true;
        }
    }
}
