using System;
using System.Threading;
using System.Windows.Forms;

namespace GameTestTool
{
    //文本脚本解释器类
    internal class Interpreter
    {
        MouseScriptInterpreter mouseInterpreter = new MouseScriptInterpreter();
        KeyboardScriptInterpreter keyboardInterpreter = new KeyboardScriptInterpreter();
        PictureScriptInterpreter pictureInterpreter = new PictureScriptInterpreter();
        CommonScriptInterpreter commonInterpreter = new CommonScriptInterpreter();
        WindowScriptInterpreter windowInterpreter = new WindowScriptInterpreter();

        Data date;
        Dm.dmsoft dm;
        char[] splitChar = new char[]{ '(', ')', '[', ']', ',' };
        string[] splitCommand;

        //执行命令
        public bool ExeCommand(string command) {
            date = Logic.Instance.Data;
            dm = Logic.Instance.DmPlug;
            command = command.Trim().Replace(" ", "");
            if (command.Length < 4 || command.IndexOf("//", 0, 3) == 0 || command.IndexOf("--", 0, 3) == 0 || command.IndexOf("/*", 0, 3) == 0) {
                return true;
            }

            if (command.IndexOf("提示框") == 0) {
                splitCommand = command.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                if (splitCommand.Length < 3) {
                    return false;
                }
                MessageBox.Show(splitCommand[1]);
                return true;
            }

            if (command.IndexOf("如果") == 0) {
                splitCommand = command.Split(splitChar, StringSplitOptions.RemoveEmptyEntries);
                if (splitCommand.Length < 6) {
                    return false;
                }

                if (splitCommand[1] == "找图")
                {
                    if (pictureInterpreter.ExeCommand(command, Logic.Instance)) {
                        splitCommand = command.Split(new string[]{"那么"}, StringSplitOptions.RemoveEmptyEntries);
                        ExeCommand(splitCommand[1]);
                    }
                }
                else if (splitCommand[1] == "窗口大小") {
                    if (windowInterpreter.ExeCommand(command, Logic.Instance)) {
                        splitCommand = command.Split(new string[] { "那么" }, StringSplitOptions.RemoveEmptyEntries);
                        ExeCommand(splitCommand[1]);
                    }
                }
                return true;
            }

            if (command.IndexOf("储存并标记") == 0) {
                splitCommand = command.Split(new char[] { '[', ']' });
                if (splitCommand.Length < 3) {
                    return false;
                }
                return true;
            } 
            
            if (command.IndexOf("返回父调用") == 0) {
                Logic.Instance.ScriptRunIndex = Logic.Instance.ScriptRunStoreIndex;
                return true;
            }

            if (command.IndexOf("跳到标记") == 0 || command.IndexOf("跳到子标记") == 0) {
                commonInterpreter.ExeCommand(command, Logic.Instance);
                return true;
            }

            if (command.IndexOf("窗口") == 0) {
                return windowInterpreter.ExeCommand(command, Logic.Instance);
            }  
            
            if (command.IndexOf("鼠标") == 0) {
                return mouseInterpreter.ExeCommand(command, Logic.Instance);
            }

            if (command.IndexOf("等待时间") == 0) {
                splitCommand = command.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                int delayTime = int.Parse(splitCommand[1]);
                Thread.Sleep(delayTime);
            }
            return true;
        }
    }
}