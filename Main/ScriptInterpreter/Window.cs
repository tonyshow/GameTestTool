using System.Threading;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTestTool
{
    class WindowScriptInterpreter
    {
        private Data date;
        private Dm.dmsoft dm;
        char[] splitChar = new char[] { '(', ')', '[', ']', ',' };
        string[] splitCommand;

         //执行命令
        public bool ExeCommand(string command, Logic logic) {
            date = logic.Data;
            dm = logic.DmPlug;

            if (command.IndexOf("窗口后台绑定") == 0) {
                splitCommand = command.Split(splitChar);
                if (splitCommand.Length < 6) {
                    return false;
                }

                date.winProp.hwnd = dm.FindWindow("", splitCommand[1]);
                if (date.winProp.hwnd < 1) {
                    MessageBox.Show("没找到窗口，请确定游戏是否开启和游戏窗口标题是否正确：" + dm.GetLastError().ToString());
                    return false;
                }

                if (dm.BindWindow(date.winProp.hwnd, splitCommand[2], splitCommand[3], splitCommand[4], int.Parse(splitCommand[5])) != 1) {
                    if (dm.CheckUAC() == 1) {
                        if (!date.set.closeUAC) {
                            MessageBox.Show("如果不主动关闭系统UAC,请以管理员模式运行此\"测试工具\"和需要后台绑定的\"目标程序\"");
                        } else {
                            if (dm.SetUAC(0) == 0) {
                                MessageBox.Show("关闭系统UAC失败！请以\"管理员\"方式运行此程序！");
                                logic.ScriptRunState = false;
                                return false;
                            } else if (dm.SetUAC(0) == 1) {
                                MessageBox.Show("关闭系统UAC,如果部分脚本运行失败请重启系统生效！");
                            }
                        }
                    }
                    logic.ScriptRunState = false;
                    MessageBox.Show("后台绑定出错！代码：" + dm.GetLastError().ToString());
                    return false;
                }
                
                dm.SetWindowState(date.winProp.hwnd, 1);
                dm.SetPath("\\Pic");
                dm.Capture(0, 0, 2000, 2000, "testScreen.bmp");
            }

            else if (command.IndexOf("如果") == 0) {
                splitCommand = command.Split(splitChar, StringSplitOptions.RemoveEmptyEntries);
                if (splitCommand.Length < 6) {
                    return false;
                }
                if (splitCommand[1] == "窗口大小") {
                    object x, y;
                    dm.GetClientSize(date.winProp.hwnd, out x, out y);
                    if (int.Parse(splitCommand[2]) == (int)x && int.Parse(splitCommand[3]) == (int)y) {
                        return true;
                    } 
                }
                return false;
            }

            return true;
        }
    }
}
