using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GameTestTool
{
    internal class Tool
    {
        private static readonly Tool _instance = new Tool();

        public static Tool Instance {
            get { return _instance; }
        }

        public Data Data {
            get { return data; }
        }

        Data data = new Data();
        Dm.dmsoft dm = Logic.Instance.DmPlug;

        //通过鼠标获取窗口句柄
        public int GetWindowsHwnd() {
            int hwnd = dm.GetMousePointWindow();
            return dm.GetWindow(hwnd, 7);
        }

        //通过鼠标获取窗口属性, 返回Hwnd
        public int GetWindowsAttribute() {
            int hwnd = GetWindowsHwnd();
            return GetWindowsAttribute(hwnd);
        }

        //通过窗口句柄获取顶层窗口属性, 返回Hwnd
        public int GetWindowsAttribute(int hwnd) {
            hwnd = dm.GetWindow(hwnd, 7);
            if (hwnd > 0) {
                data.winProp.hwnd = hwnd;
                data.winProp.title = dm.GetWindowTitle(hwnd);
                data.winProp.className = dm.GetWindowClass(hwnd);
                object x, y;
                dm.GetClientSize(hwnd, out x, out y);
                data.winProp.sizeWidth = (int)x;
                data.winProp.sizeHeight = (int)y;
            }
            return hwnd;
        }

        //通过窗口句柄获取顶层窗口属性, 返回Hwnd
        public int GetWindowsAttribute(string className, string title) {
            int hwnd = dm.FindWindow(className, title);
            if (hwnd > 0) {
                data.winProp.hwnd = hwnd;
                data.winProp.title = dm.GetWindowTitle(hwnd);
                data.winProp.className = dm.GetWindowClass(hwnd);
            }
            return hwnd;
        }

        //通过鼠标获取鼠标的后台坐标
        public bool GetCursorAttribute() {
            dm.UnBindWindow();
            object x, y;
            if (dm.GetCursorPos(out x, out y) == 0) {
                return false;
            }
            data.cursorProp.x = (int)x;
            data.cursorProp.y = (int)y;

            if (dm.ScreenToClient(GetWindowsHwnd(), ref x, ref y) == 0) {
                return false;
            }
            data.cursorProp.xBack = (int)x;
            data.cursorProp.yBack = (int)y;
            return true;
        }
    }

    public delegate void HotkeyEventHandler(int HotKeyID);
    public class Hotkey : System.Windows.Forms.IMessageFilter
    {
        private System.Collections.Hashtable keyIDs = new System.Collections.Hashtable();
        private IntPtr hWnd;

        public event HotkeyEventHandler OnHotkey;

        public enum KeyFlags
        {
            MOD_NON = 0x0,
            MOD_ALT = 0x1,
            MOD_CONTROL = 0x2,
            MOD_SHIFT = 0x4,
            MOD_WIN = 0x8
        }

        [DllImport("user32.dll")]
        public static extern UInt32 RegisterHotKey(IntPtr hWnd, UInt32 id, UInt32 fsModifiers, UInt32 vk);

        [DllImport("user32.dll")]
        public static extern UInt32 UnregisterHotKey(IntPtr hWnd, UInt32 id);

        [DllImport("kernel32.dll")]
        public static extern UInt32 GlobalAddAtom(String lpString);

        [DllImport("kernel32.dll")]
        public static extern UInt32 GlobalDeleteAtom(UInt32 nAtom);

        public Hotkey(IntPtr hWnd) {
            this.hWnd = hWnd;
            System.Windows.Forms.Application.AddMessageFilter(this);
        }

        public int RegisterHotkey(System.Windows.Forms.Keys Key, KeyFlags keyflags) {
            UInt32 hotkeyid = GlobalAddAtom(System.Guid.NewGuid().ToString());
            RegisterHotKey((IntPtr)hWnd, hotkeyid, (UInt32)keyflags, (UInt32)Key);
            keyIDs.Add(hotkeyid, hotkeyid);
            return (int)hotkeyid;
        }

        public void UnregisterHotkeys() {
            System.Windows.Forms.Application.RemoveMessageFilter(this);
            foreach (UInt32 key in keyIDs.Values) {
                UnregisterHotKey(hWnd, key);
                GlobalDeleteAtom(key);
            }
        }

        public bool PreFilterMessage(ref System.Windows.Forms.Message m) {
            if (m.Msg == 0x312) {
                if (OnHotkey != null) {
                    foreach (UInt32 key in keyIDs.Values) {
                        if ((UInt32)m.WParam == key) {
                            OnHotkey((int)m.WParam);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}