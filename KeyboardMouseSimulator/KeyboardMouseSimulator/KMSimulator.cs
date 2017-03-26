using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace KeyboardMouseSimulator
{
    public class KMSimulator
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        const int MOUSEEVENTF_MOVE = 0x0001;//      移动鼠标 
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;// 模拟鼠标左键按下 
        const int MOUSEEVENTF_LEFTUP = 0x0004;// 模拟鼠标左键抬起 
        const int MOUSEEVENTF_RIGHTDOWN = 0x0008;// 模拟鼠标右键按下 
        const int MOUSEEVENTF_RIGHTUP = 0x0010;// 模拟鼠标右键抬起 
        const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;// 模拟鼠标中键按下 
        const int MOUSEEVENTF_MIDDLEUP = 0x0040;// 模拟鼠标中键抬起 
        const int MOUSEEVENTF_ABSOLUTE = 0x8000;// 标示是否采用绝对坐标

        private uint ScreenX;
        private uint ScreenY;

        public KMSimulator()
        {
            int height = Screen.PrimaryScreen.Bounds.Height;
            int witght = Screen.PrimaryScreen.Bounds.Width;
            this.ScreenX = (uint)witght;
            this.ScreenY = (uint)height;
        }

        public void Input(string input)
        {
            SendKeys.SendWait(input);
        }

        public void LeftClick()
        {

            //Call the imported function with the cursor's current position

            uint X = (uint)Cursor.Position.X;

            uint Y = (uint)Cursor.Position.Y;

            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X * 65536 / this.ScreenX, Y * 65536 / this.ScreenY, 0, 0);

        }
        public void RightClick()
        {
            //Call the imported function with the cursor's current position

            uint X = (uint)Cursor.Position.X;

            uint Y = (uint)Cursor.Position.Y;

            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, X * 65536 / this.ScreenX, Y * 65536 / this.ScreenY, 0, 0);
        }

        public void LeftClick(int x, int y)
        {
            this.Move(x, y);
            this.LeftClick();
        }

        public void DoubleLeftClick(int x, int y)
        {
            this.Move(x, y);
            this.LeftClick();
            this.LeftClick();
        }

        public void RightClick(int x, int y)
        {
            this.Move(x, y);
            this.RightClick();
        }

        public void Move(int x, int y)
        {
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, (uint)x * 65536 / this.ScreenX, (uint)y * 65536 / this.ScreenY, 0, 0);
        }

        public void Drag(int x, int y, int x2, int y2)
        {
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, (uint)x * 65536 / this.ScreenX, (uint)y * 65536 / this.ScreenY, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)x * 65536 / this.ScreenX, (uint)y * 65536 / this.ScreenY, 0, 0);
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, (uint)x2 * 65536 / this.ScreenX, (uint)y2 * 65536 / this.ScreenY, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, (uint)x2 * 65536 / this.ScreenX, (uint)y2 * 65536 / this.ScreenY, 0, 0);
        }
    }
}
