using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostSwitch.Models {

    /// <summary>
    /// Host文件信息
    /// </summary>
    public class HostInfo {

        public HostInfo() {

        }

        public HostInfo(string fileName, string filePath) {
            this.FileName = fileName;
            this.FilePath = filePath;
        }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 文件内容 
        /// </summary>
        public string FileContent { get; set; }
    }
}
