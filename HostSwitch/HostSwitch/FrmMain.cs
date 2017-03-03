using HostSwitch.Core;
using HostSwitch.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostSwitch {
    public partial class FrmMain : Form {

        HostService hostService;
        Operation currentOperation;
        HostInfo currentHost;
        Regex regImport = new Regex(@"#@import ([^\r\n\s]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        Regex regUri = new Regex(@"http:\/\/.+", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public FrmMain() {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e) {
            currentOperation = Operation.CREATE;
            hostService = new HostService();
            refreshHostList();
        }

        private void refreshHostList() {
            var hostList = hostService.GetList();
            gvList.DataSource = hostList;
            gvList.Update();
            exchargeList.DropDownItems.Clear();

            foreach (var host in hostList) {
                exchargeList.DropDownItems.Add(host.FileName, null, delegate {
                    handleUse(host, true);
                });
            }
        }

        private void gvList_CellContentClick(object sender, DataGridViewCellEventArgs e) {

            var operation = gvList.Columns[gvList.CurrentCell.ColumnIndex].Name;

            // 如果点击的是文件名称则不处理
            if (operation == "FileName") {
                return;
            }

            var operationEnum = (Operation)Enum.Parse(typeof(Operation), operation);
            var host = new HostInfo(gvList.CurrentRow.Cells["FileName"].Value.ToString(),
                                    gvList.CurrentRow.Cells["FilePath"].Value.ToString());


            switch (operationEnum) {

                // 删除host
                case Operation.DELETE:
                    hostService.Delete(host);
                    refreshHostList();
                    break;

                case Operation.USE:
                    handleUse(host);
                    break;

                case Operation.EDIT:
                    currentOperation = Operation.EDIT;
                    currentHost = host;
                    handleHostEdit(host);
                    break;

                default:
                    break;
            }
        }

        private void handleUse(HostInfo host, bool isSilence = false) {
            var syst = Environment.GetEnvironmentVariable("windir");
            var hostPath = Path.Combine(syst, "system32\\drivers\\etc\\hosts");
            var hostContent = File.ReadAllText(host.FilePath);
            IList<string> noExistModules = new List<string>();
            IList<string> importModules = new List<string>();
            string msg = "操作成功！";

            while(regImport.IsMatch(hostContent)) {
                var matchList = regImport.Matches(hostContent);

                foreach (Match m in matchList) {
                    var fileName = m.Result("$1");

                    // 已经加载的则不再加载一遍
                    if (importModules.Contains(fileName)) {
                        hostContent = hostContent.Replace(m.Value, "");
                        continue;
                    }

                    // 如果import的模块是个uri则使用http抓取
                    if (regUri.IsMatch(fileName)) {
                        try {
                            var content = HttpHelper.Get(fileName);
                            hostContent = hostContent.Replace(m.Value, content);
                        }
                        catch (Exception ex) {
                            noExistModules.Add(string.Format("{1}({0})", fileName, ex.Message));
                        }
                    }
                    else {
                        var filePath = hostService.BuildFilePath(fileName);

                        if (File.Exists(filePath)) {
                            hostContent = hostContent.Replace(m.Value, File.ReadAllText(filePath));
                        }
                        else {
                            noExistModules.Add(fileName);
                        }
                    }

                    importModules.Add(fileName);
                }
            }

            try {
                File.SetAttributes(hostPath, FileAttributes.Normal);
                File.WriteAllText(hostPath, hostContent);
                File.SetAttributes(hostPath, FileAttributes.ReadOnly);
            }
            catch (Exception ex) {
                MessageBox.Show("无法写入hosts文件，请去除hosts文件的只读属性！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var name in noExistModules) {
                msg += string.Format("\n未找到模块：{0}", name);
            }

            if (isSilence != true) {
                MessageBox.Show(msg, "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void handleHostEdit(HostInfo host) {
            tbeName.Text = host.FileName;
            tbContent.Text = File.ReadAllText(host.FilePath);
            labStatus.Text = string.Format("操作 > 编辑“{0}”", host.FileName, host.FilePath);
        }

        private void button1_Click(object sender, EventArgs e) {
            var host = new HostInfo();
            host.FileName = tbeName.Text.Trim();
            host.FilePath = hostService.BuildFilePath(host.FileName);
            host.FileContent = tbContent.Text.Trim();

            if (string.IsNullOrWhiteSpace(host.FileName)) {
                MessageBox.Show("请填写文件名称！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(host.FileContent)) {
                MessageBox.Show("请填写文件内容！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentOperation == Operation.EDIT) {
                hostService.Delete(currentHost);
            }

            hostService.Create(host);
            refreshHostList();
            btnCreate_Click(null, null);
        }

        /// <summary>
        /// 创建host文件
        /// </summary>
        private void btnCreate_Click(object sender, EventArgs e) {
            currentOperation = Operation.CREATE;
            tbeName.Text = "";
            tbContent.Text = "";
            labStatus.Text = "操作 > 新增";
        }

        private void FrmMain_SizeChanged(object sender, EventArgs e) {
            if (WindowState == FormWindowState.Minimized) {
                this.Visible = false;
                trayIcon.Visible = true;
            }
        }

        private void ShowWindow(object sender, EventArgs e) {
            trayIcon.Visible = false;
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void tsmtOut_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
