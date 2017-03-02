using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostSwitch.Core {

    /// <summary>
    /// 操作类型
    /// </summary>
    public enum Operation {

        /// <summary>
        /// 创建
        /// </summary>
        CREATE = 0,

        /// <summary>
        /// 使用
        /// </summary>
        USE = 1,

        /// <summary>
        /// 编辑 
        /// </summary>
        EDIT = 2,

        /// <summary>
        /// 删除
        /// </summary>
        DELETE = 3
    }
}
