using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HostSwitch.Models;


namespace HostSwitch.Interfaces {

    /// <summary>
    /// Host文件接口
    /// </summary>
    public interface IHost {

        /// <summary>
        /// 获取文件列表
        /// </summary>
        IList<HostInfo> GetList();

        /// <summary>
        /// 删除host
        /// </summary>
        void Delete(HostInfo host);

        /// <summary>
        /// 创建host
        /// </summary>
        /// <param name="host"></param>
        void Create(HostInfo host);

        /// <summary>
        /// 编辑host
        /// </summary>
        /// <param name="host"></param>
        void Edit(HostInfo host);
    }
}
