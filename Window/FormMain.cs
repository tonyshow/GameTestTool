using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace GameTestTool
{
    public partial class FormMain : Form
    {
        Data date = Logic.Instance.Data;
        Dm.dmsoft dm = Logic.Instance.DmPlug;

        string bindType = "gdi";

        Stopwatch stopwatch = new Stopwatch();

        List<FileInfo> scriptFiles = new List<FileInfo>();

        private BackgroundWorker backgroundWorker1 = new System.ComponentModel.BackgroundWorker();

        Hotkey hotKey;
        int keyIDGetCursor, keyIDScritpStart, keyIDScriptStop;
        public FormMain()
        {
            InitializeComponent();
            ListScriptFiles(new DirectoryInfo(@".\Script\"));
            string saveScriptName = ConfigFile.SaveScriptName;
            foreach (FileInfo info in scriptFiles) {
                if (info.Name == saveScriptName)
                {
                    cboScript.Text = info.FullName;
                    FileStream fs = new FileStream(info.FullName, FileMode.Open);
                    StreamReader read = new StreamReader(fs, Encoding.Default);
                    while (!read.EndOfStream) {
                        lstScriptInfo.Items.Add(read.ReadLine());
                    }
                    read.BaseStream.Seek(0, SeekOrigin.Begin);
                    date.lineCommand = read.ReadToEnd().Split('\n');
                    fs.Close();
                }
            }

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += new DoWorkEventHandler(ProcessScript);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(UpdateProgress);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CompletedWork);

            hotKey = new Hotkey(this.Handle);
            keyIDGetCursor = hotKey.RegisterHotkey(Keys.D1, Hotkey.KeyFlags.MOD_ALT);
            keyIDScritpStart = hotKey.RegisterHotkey(Keys.Home, Hotkey.KeyFlags.MOD_NON);
            keyIDScriptStop = hotKey.RegisterHotkey(Keys.End, Hotkey.KeyFlags.MOD_NON);
            hotKey.OnHotkey += new HotkeyEventHandler(OnHotkey);
        }

        //脚本运行
        private void BtnScriptStartClick(object sender, EventArgs e) {
            Logic.Instance.ScriptRunIndex = 0;
            Logic.Instance.ScriptRunState = true;
            btnScriptStart.Enabled = false;
            backgroundWorker1.RunWorkerAsync(this); 
        }

        //脚本停止
        private void BtnScriptStopClick(object sender, EventArgs e) {
            Logic.Instance.ScriptRunState = false;
            btnScriptStart.Enabled = true;
            backgroundWorker1.CancelAsync(); 
        }

        //脚本选择
        private void CobScriptSelectedIndexChanged(object sender, EventArgs e) {
            if (cboScript.Items != null && cboScript.Items.Count > 0)
            {
                lstScriptInfo.Items.Clear();
                FileStream fs = new FileStream(scriptFiles[cboScript.SelectedIndex].FullName, FileMode.Open);
                ConfigFile.SaveScriptName = scriptFiles[cboScript.SelectedIndex].Name;
                StreamReader read = new StreamReader(fs, Encoding.Default);
                while (!read.EndOfStream) {
                    lstScriptInfo.Items.Add(read.ReadLine());
                }
                read.BaseStream.Seek(0, SeekOrigin.Begin);
                date.lineCommand = read.ReadToEnd().Split('\n');
                fs.Close();
            }
        }

        //脚本列表读取 按钮
        private void CobScriptLoadClick(object sender, EventArgs e) {
            ListScriptFiles(new DirectoryInfo(@".\Script\"));
            cboScript.Items.Clear();
            foreach (FileInfo info in scriptFiles)
            {
                cboScript.Items.Add(info.FullName);
            }
        }

        //脚本列表读取
        private void ListScriptFiles(FileSystemInfo info) {
            if (!info.Exists) {
                MessageBox.Show("\"Script\"脚本目录不存在！请检查");
                return;
            }

            DirectoryInfo dir = info as DirectoryInfo;
            //不是目录 
            if (dir == null) return;

            scriptFiles.Clear();
            FileSystemInfo[] files = dir.GetFileSystemInfos();
            for (int i = 0; i < files.Length; i++) {
                scriptFiles.Add(files[i] as FileInfo);
                //对于子目录，进行递归调用 
                if (scriptFiles[i] == null) {
                    ListScriptFiles(files[i]);
                }
            }
        }

        //脚本处理
        public void ProcessScript(object sender, DoWorkEventArgs e) {
            BackgroundWorker bw = sender as BackgroundWorker;
            while (Logic.Instance.ScriptRunIndex < date.lineCommand.Length) {
                if (!Logic.Instance.ScriptRunState) { //脚本停止运行
                    Logic.Instance.StopScriptRun();
                    return;
                }
                bw.ReportProgress(1, Logic.Instance.ScriptRunIndex);
                Thread.Sleep(10);
                Logic.Instance.ExeCommand(date.lineCommand[Logic.Instance.ScriptRunIndex]);
                ++Logic.Instance.ScriptRunIndex;
            }
        }

        void UpdateProgress(object sender, ProgressChangedEventArgs e) {
            //int progress = e.ProgressPercentage;

            //if (e.ProgressPercentage == 1)
            //{
            //    txtHandle.Text = date.winProp.hwnd.ToString();
            //    Tool.Instance.GetWindowsAttribute(date.WinProp.Hwnd);
            //    txtWinName.Text = date.WinProp.Title.ToString();
            //}
            lstScriptInfo.SetSelected((int)e.UserState, true);
        }

        void CompletedWork(object sender, RunWorkerCompletedEventArgs e) {
            //if (e.Error != null) {
            //    MessageBox.Show("Error");
            //} else if (e.Cancelled) {
            //    MessageBox.Show("Canceled");
            //} else {
            //    MessageBox.Show("Completed");
            //}
            BtnScriptStopClick(sender, e);
        }

        public void OnHotkey(int hotkeyID) {
            //获取鼠标后台位置
            if (hotkeyID == keyIDGetCursor) {
                Tool.Instance.GetWindowsAttribute();
                Tool.Instance.GetCursorAttribute();
                txtHandle.Text = Tool.Instance.Data.winProp.hwnd.ToString();
                txtWinName.Text = Tool.Instance.Data.winProp.title;
                txtCursorPos.Text = Tool.Instance.Data.cursorProp.xBack.ToString() + ", " + Tool.Instance.Data.cursorProp.yBack.ToString();
            } else if (hotkeyID == keyIDScritpStart)
            {
                BtnScriptStartClick(this, null);    //运行脚本;
            } else if (hotkeyID == keyIDScriptStop)
            {
                BtnScriptStopClick(this, null);    //停止脚本;
            }
        }

        
        private void LstScriptInfoClick(object sender, EventArgs e) {
            Logic.Instance.ScriptRunIndex = lstScriptInfo.SelectedIndex;
            Logic.Instance.ScriptRunState = true;
            btnScriptStart.Enabled = false;
            backgroundWorker1.RunWorkerAsync(this); 
        }

        private void CobBindTypeChangedClick(object sender, EventArgs e) {
            bindType = this.bindTypeCbo.SelectedItem.ToString();
        }

        private void CheCloseUACChangedClick(object sender, EventArgs e) {
            date.set.closeUAC = closeUACChe.Checked;
        }

        private void BtnOpenScriptFolder(object sender, MouseEventArgs e) {
            System.Diagnostics.Process.Start(@".\Script\");
        }

        private void BtnScriptRefreshClick(object sender, EventArgs e) {
            ListScriptFiles(new DirectoryInfo(@".\Script\"));
            string saveScriptName = ConfigFile.SaveScriptName;
            lstScriptInfo.Items.Clear();
            foreach (FileInfo info in scriptFiles) {
                if (info.Name == saveScriptName) {
                    cboScript.Text = info.FullName;
                    FileStream fs = new FileStream(info.FullName, FileMode.Open);
                    StreamReader read = new StreamReader(fs, Encoding.Default);
                    while (!read.EndOfStream) {
                        lstScriptInfo.Items.Add(read.ReadLine());
                    }
                    read.BaseStream.Seek(0, SeekOrigin.Begin);
                    date.lineCommand = read.ReadToEnd().Split('\n');
                    fs.Close();
                }
            }

        }
    }
}