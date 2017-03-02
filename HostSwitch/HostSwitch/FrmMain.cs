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
        Regex regImport = new Regex("#@import (\\w+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);

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

            foreach (var host in hostList) {
                exchargeList.DropDownItems.Add(host.FileName, null, delegate {
                    handleUse(host, true);
                });
            }
        }

        private void gvList_CellContentClick(object sender, DataGridViewCellEventArgs e) {

            var operation = gvList.Columns[gvList.CurrentCell.ColumnIndex].Name;
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
            string msg = "操作成功！";

            if (regImport.IsMatch(hostContent)) {
                var matchList = regImport.Matches(hostContent);

                foreach (Match m in matchList) {
                    var fileName = m.Result("$1");
                    var filePath = hostService.BuildFilePath(fileName);

                    if (File.Exists(filePath)) {
                        hostContent = hostContent.Replace(m.Value, File.ReadAllText(filePath));
                    }
                    else {
                        noExistModules.Add(fileName);
                    }
                }
            }

            File.WriteAllText(hostPath, hostContent);

            if (noExistModules.Count > 0) {
                msg += string.Join("未找到\n", noExistModules.ToArray());
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
            if(WindowState == FormWindowState.Minimized) {
                this.Hide();
                trayIcon.Visible = true;
            }
        }

        private void tsmtShow_Click(object sender, EventArgs e) {
            trayIcon.Visible = false;
            this.Show();
            this.Activate();  
        }
    }
}
