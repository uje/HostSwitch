using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HostSwitch.Interfaces;
using HostSwitch.Models;
using System.Globalization;
using System.Text.RegularExpressions;

namespace HostSwitch.Core {

    /// <summary>
    /// Host文件接口实现 
    /// </summary>
    public class HostService : IHost {

        public void Create(HostInfo host) {
            File.WriteAllText(host.FilePath, host.FileContent);
        }

        public void Delete(HostInfo host) {
            File.Delete(host.FilePath);
        }

        public void Edit(HostInfo host) {
            Create(host);
        }

        /// <summary>
        /// 生成文件路径
        /// </summary>
        public string BuildFilePath(string name) {
            return Path.Combine(Environment.CurrentDirectory, ENV.FILE_FOLDER, name + ENV.FILE_EXT);
        }

        public IList<HostInfo> GetList() {
            var folder = Path.Combine(Environment.CurrentDirectory, ENV.FILE_FOLDER);

            if (!Directory.Exists(folder)) {
                Directory.CreateDirectory(folder);
            }

            return _GetList(folder);
        }

        private IList<HostInfo> _GetList(string dir) {
            List<HostInfo> hosts = new List<HostInfo>();
            var dirList = Directory.GetDirectories(dir);
            var fileList = Directory.GetFiles(dir);

            // 找到当前目录的所有匹配文件 
            foreach(var file in fileList) {
                if(file.EndsWith(ENV.FILE_EXT, true, CultureInfo.CurrentCulture)) {
                    hosts.Add(new HostInfo(Path.GetFileNameWithoutExtension(file), file));
                }
            }

            // 一层一层向下查看子目录
            if(dirList.Length > 0) {
                foreach(var d in dirList) {
                    hosts.AddRange(_GetList(d));
                } 
            }

            return hosts;
        }
    }
}
