namespace GameTestTool
{
    class Logic
    {
        private readonly static Logic _instance = new Logic();

        public static Logic Instance { get { return _instance; }}

        public Dm.dmsoft DmPlug { get { return dm; } }

        public Data Data { get { return data; } }

        public Interpreter Interpreter { get { return interpreter; } }

        //大漠插件类
        private Dm.dmsoft dm = new Dm.dmsoft();         
        //数据类
        private Data data = new Data();
        //脚本解析类
        private Interpreter interpreter = new Interpreter();

        public bool ScriptRunState { get; set; }

        public void StopScriptRun() {
            dm.UnBindWindow();
        }

        public int ScriptRunStoreIndex { get; set; }

        //脚本列表执行的行数
        public int ScriptRunIndex { get; set; }

        public bool ExeCommand(string command) {
            return interpreter.ExeCommand(command);
        }
    }
}