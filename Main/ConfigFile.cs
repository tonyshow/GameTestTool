using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GameTestTool
{
    //配置文件类
    class ConfigFile
    {
        static string configFileName = "config.txt";

        public static string _saveScriptName;
        public static string SaveScriptName {
            get {
                if (_saveScriptName == null) {
                    _saveScriptName = GetSaveScriptName(configFileName);
                }
                return _saveScriptName;
            }
            set {
                SetSaveScriptName(value);
                _saveScriptName = value;
            }
        }

        static string GetSaveScriptName(string fileName) {
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(fs, Encoding.Default);
            string str, saveName = "";
            while (!reader.EndOfStream) {
                str = reader.ReadLine();
                if (str.IndexOf("saveScriptName=") == 0) {
                    string[] split = str.Split(new char[]{'='});
                    if (split.Length > 1)
                    {
                        saveName = split[1];
                    }
                }
            }
            reader.Close();//关闭流
            fs.Close();
            return saveName;
        }

        static void SetSaveScriptName(string saveName) {
            FileStream fs = new FileStream(configFileName, FileMode.OpenOrCreate);

            StreamReader reader = new StreamReader(fs, Encoding.Default);
            string wholeContent = reader.ReadToEnd();   //整个读出来
            string[] lineContent = wholeContent.Split('\n');        //分割成每一行
            reader.Close();
            fs.Close();

            bool saveScriptNameExist = false;
            FileStream fsWrite = new FileStream(configFileName, FileMode.Create);
            StreamWriter write = new StreamWriter(fsWrite, Encoding.Default);
            foreach (string strTemp in lineContent) {
                if (strTemp.IndexOf("saveScriptName=") == 0) {
                    saveScriptNameExist = true;
                    write.WriteLine("saveScriptName=" + saveName);
                } else {
                    write.WriteLine(strTemp);
                }
            }
            if (!saveScriptNameExist) {
                write.WriteLine("saveScriptName=" + saveName);
            }
            write.Close();
            fsWrite.Close();
        }
    }
}
