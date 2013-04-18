using System.IO;
//-------------------------------tony-------------------------------
namespace GameTestTool
{
    //窗口属性
    public struct WinProp
    {
        public int hwnd;
        public string className;
        public string title;
        public int sizeWidth;
        public int sizeHeight;
    }

    //鼠标属性
    public struct CursorProp
    {
        public int x;
        public int y;
        public int xBack;           //后台X坐标
        public int yBack;           //后台Y坐标
    }

    //数据类
    internal class Data
    {
        public string[] lineCommand;        //命令的每一行

        public WinProp winProp = new WinProp();

        public CursorProp cursorProp = new CursorProp();

        public Set set = new Set();

        //public WinAttribute WinAttribute {
        //    get { return _winAttribute; }
        //    set { _winAttribute = value; }
        //}
    }

    public struct Set
    {
        public bool closeUAC;
    }
}