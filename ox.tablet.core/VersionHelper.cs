using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OX.Tablet
{
    public static class VersionHelper
    {
        /// <summary>
        /// 第一位：主版本号，重大更新时更改
        /// 第二位：次版本号，功能性更新时更改
        /// 第三位：修订号，修复bug时更改
        /// 第四位：编译号，编译时更改
        /// </summary>
        public const string Version = "1.0.0.8";
        public static string GetDataVersion()
        {
            var vs = Version.Split('.');
            if (vs.Length >= 3)
                return $"{vs[0]}.{vs[1]}.{vs[2]}";
            return Version;
        }
    }
}
