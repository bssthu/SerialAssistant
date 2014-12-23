using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace BloodPressureViewer
{
    /// <summary>
    /// 热键管理
    /// </summary>
    public class HotKey
    {
        /// <summary>
        /// 注册快捷键
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="id">定义的ID</param>
        /// <param name="fsModifiers">按下的功能键</param>
        /// <param name="vk">按下的键</param>
        /// <returns>成功返回非0</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);

        /// <summary>
        /// 取消注册快捷键
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="id">定义的ID</param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [Flags()]
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            WindowsKey = 8
        }
    }
}
