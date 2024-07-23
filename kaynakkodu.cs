using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Log;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Terminal
{
    /* 26.05.2024 09:40 Update Note : New Text Methods */
    /* 1.06.2024 22:03 Update Note : New Methods (about some texts)*/
    /* 14.06.2024 Biggest Text Methods fixed */
    public static class Code
    {
        public static void If(Func<bool> condition, Action<int> action, Action<int> incrementAction)
        {
            for (int i = 0; condition(); incrementAction(i))
            {
                action(i);
            }
        }
    }
    public static class Finder
    {
        public static void FindIt(int startx, int endx, int starty, int endy)
        {
            Cursor.SetCursorPositionXY(startx, starty);
            Text.WriteFore("255,0,0", "*");

            Cursor.SetCursorPositionXY(endx, starty);
            Text.WriteFore("255,0,0", "*");

            Cursor.SetCursorPositionXY(startx, endy);
            Text.WriteFore("255,0,0", "*");

            Cursor.SetCursorPositionXY(endx, endy);
            Text.WriteFore("255,0,0", "*");
        }
    }
    public static class Office
    {
        public static void Google(string url)
        {

            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(url);

            var links = document.DocumentNode.SelectNodes("//a[@href]");

            if (links != null)
            {
                foreach (var link in links)
                {

                    string href = link.GetAttributeValue("href", string.Empty);
                    Console.WriteLine(href);
                }
            }
            else
            {
                Console.WriteLine("No links found!");
            }
        }
    }
    public static class Keyboard
    {
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);
        public static bool KeyPress(string key)
        {
            int vKey = 0;
            switch (Text.UpperCase(key))
            {
                case "CTRL":
                    vKey = 0x11;
                    break;
                case "SHIFT":
                    vKey = 0x10;
                    break;
                case "ALT":
                    vKey = 0x12;
                    break;
                case "ALT GR":
                    vKey = 0xA5;
                    break;
                case "TAB":
                    vKey = 0x09;
                    break;
                case "CAPSLOCK":
                    vKey = 0x14;
                    break;
                case "ENTER":
                    vKey = 0x0D;
                    break;
                case "DELETE":
                    vKey = 0x2E;
                    break;
                case "F1":
                    vKey = 0x70;
                    break;
                case "F2":
                    vKey = 0x71;
                    break;
                case "F3":
                    vKey = 0x72;
                    break;
                case "F4":
                    vKey = 0x73;
                    break;
                case "F5":
                    vKey = 0x74;
                    break;
                case "F6":
                    vKey = 0x75;
                    break;
                case "F7":
                    vKey = 0x76;
                    break;
                case "F8":
                    vKey = 0x77;
                    break;
                case "F9":
                    vKey = 0x78;
                    break;
                case "F10":
                    vKey = 0x79;
                    break;
                case "F11":
                    vKey = 0x7A;
                    break;
                case "F12":
                    vKey = 0x7B;
                    break;
                default:
                    throw new ArgumentException("Geçersiz tuş adı.");
            }
            short keyState = GetAsyncKeyState(vKey);
            return (keyState & 0x8000) != 0;
        }
    }
    public static class Transactions
    {
        public static int Addition(int a, int b)
        {
            return a + b;
        }
        public static int Subtraction(int a, int b)
        {
            return a - b;
        }
        public static int Division(int a, int b)
        {
            return a / b;
        }
        public static int Multiplication(int a, int b)
        {
            return a * b;
        }
    }
    public static class Menu
    {
        public static void InfoBox(int x, int y, string info)
        {
            Frame(x, y, info.Length + 2, 1, " ");
            Cursor.SetCursorPositionXY(x + 1, y + 1);
            Console.Write(info);
        }
        public static void Frame(int x, int y, int width, int heigth, string title)
        {
            for (int i = 0; i < width; i++)
            {
                Cursor.SetCursorPositionXY(x + i, y);
                if (i == 0) Console.Write("╭"); else if (i + 1 == width) { Console.Write("╮"); } else { Console.Write("─"); }
                Cursor.SetCursorPositionXY(x + i, y + heigth + 1);
                Console.Write("─");
                for (int j = 0; j < heigth; j++)
                {
                    Cursor.SetCursorPositionXY(x, y + j + 1);
                    Console.Write("│");
                    Cursor.SetCursorPositionXY(x + width - 1, y + j + 1);
                    Console.Write("│");
                    if (j + 1 == heigth) { Cursor.SetCursorPositionXY(x, y + j + 2); Console.Write("╰"); Cursor.SetCursorPositionXY(x + width - 1, y + j + 2); Console.Write("╯"); }
                }
            }
            Cursor.SetCursorPositionXY(x + (title.Length % 2 == 0 ? title.Length / 2 : title.Length / 2 + 1), y + heigth + 2);
            Console.Write(title);
        }
        public static void Loading(string text, int x, int y, string rgb, string rgbload, bool bg, string rgbbg)
        {

            if (bg == false)
            {
                Cursor.CursorVisibility(false);
                Cursor.SetCursorPositionXY(x, y);
                Text.WriteFore(rgbload, "|");
                Cursor.SetCursorPositionXY(x + 2, y);
                Text.WriteFore(rgb, text);
                Time.Wait(250);
                Cursor.SetCursorPositionXY(x + 2, y);
                Text.WriteFore(rgb, text + ".");
                Cursor.SetCursorPositionXY(x, y);
                Text.WriteFore(rgbload, "/");
                Time.Wait(250);
                Cursor.SetCursorPositionXY(x + 2, y);
                Text.WriteFore(rgb, text + "..");
                Cursor.SetCursorPositionXY(x, y);
                Text.WriteFore(rgbload, "-");
                Time.Wait(250);
                Cursor.SetCursorPositionXY(x + 2, y);
                Text.WriteFore(rgb, text + "...");
                Cursor.SetCursorPositionXY(x, y);
                Text.WriteFore(rgbload, "|");
                Time.Wait(250);

                Cursor.SetCursorPositionXY(x, y);
                Text.WriteFore(rgbload, @"/");
                Time.Wait(250);
                Cursor.SetCursorPositionXY(x, y);
                Text.WriteFore(rgbload, "-");
                Time.Wait(250);
                Text.RemoveText(x + 2, x + 5 + text.Length, y, y);
            }
            else
            {
                Cursor.CursorVisibility(false);
                Cursor.SetCursorPositionXY(x, y);
                Text.WriteWithRGB(rgbload, rgbbg, "|");
                Text.SetWriteWithRGB(x + 1, y, "255,255,255", "255,255,255", " ");
                Cursor.SetCursorPositionXY(x + 2, y);
                Text.WriteWithRGB(rgb, rgbbg, text);
                Time.Wait(250);
                Cursor.SetCursorPositionXY(x + 2, y);
                Text.WriteWithRGB(rgb, rgbbg, text + ".");
                Cursor.SetCursorPositionXY(x, y);
                Text.WriteWithRGB(rgbload, rgbbg, "/");
                Time.Wait(250);
                Cursor.SetCursorPositionXY(x + 2, y);
                Text.WriteWithRGB(rgb, rgbbg, text + "..");
                Cursor.SetCursorPositionXY(x, y);
                Text.WriteWithRGB(rgbload, rgbbg, "-");
                Time.Wait(250);
                Cursor.SetCursorPositionXY(x + 2, y);
                Text.WriteWithRGB(rgb, rgbbg, text + "...");
                Cursor.SetCursorPositionXY(x, y);
                Text.WriteWithRGB(rgbload, rgbbg, "|");
                Time.Wait(250);
                Cursor.SetCursorPositionXY(x, y);
                Text.WriteWithRGB(rgbload, rgbbg, @"/");
                Time.Wait(250);
                Cursor.SetCursorPositionXY(x, y);
                Text.WriteWithRGB(rgbload, rgbbg, "-");
                Time.Wait(250);
                Text.RemoveText(x + 2, x + 5 + text.Length, y, y);
                Text.SetWriteWithRGB(x + 2 + text.Length, y, "255,255,255", "255,255,255", "   ");
            }

        }
        public static void List(int x, int y, string title, string[] content, string rgb, bool bg_rgb = false, string bgrgb = "0,0,0")
        {
            if (bg_rgb == false)
            {
                Cursor.SetCursorPositionXY(x - 2, y - 1);
                Text.WriteFore(rgb, title);
                Cursor.SetCursorPositionXY(x - 2, y);
                Text.WriteFore("108,108,108", new string('-', title.Length));
                for (int i = 0; i < content.Length; i++)
                {
                    Cursor.SetCursorPositionXY(x - 2, y + 1 + i);
                    Text.WriteFore("108,108,108", "⬤");
                    Cursor.SetCursorPositionXY(x, y + 1 + i);
                    Text.WriteFore($"{108 + i * 7},{100 + i * 2},{50 + i * 3}", content[i]);
                }
            }
            else
            {
                Cursor.SetCursorPositionXY(x - 2, y - 1);
                Text.WriteWithRGB(rgb, bgrgb, title);
                Cursor.SetCursorPositionXY(x - 2, y);
                Text.WriteWithRGB("108,108,108", bgrgb, new string('-', title.Length));
                for (int i = 0; i < content.Length; i++)
                {
                    Cursor.SetCursorPositionXY(x - 2, y + 1 + i);
                    Text.WriteWithRGB("108,108,108", bgrgb, "⬤");
                    Cursor.SetCursorPositionXY(x, y + 1 + i);
                    Text.WriteWithRGB($"{108 + i * 7},{100 + i * 2},{50 + i * 3}", bgrgb, content[i]);
                }
            }
        }
    }
    public static class Graph
    {
        [DllImport("User32.dll")]
        private static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("User32.dll")]
        private static extern void ReleaseDC(IntPtr hwnd, IntPtr dc);
        private static IntPtr desktopPtr = GetDC(IntPtr.Zero);
        public static class DImage
        {
            public static void DrawImage(string path, int x, int y, int width, int heigth)
            {
                using (Graphics g = Graphics.FromHdc(desktopPtr))
                {
                    Image resim = Image.FromFile(path);
                    Rectangle hedef = new Rectangle(x, y, width, heigth);
                    g.DrawImage(resim, hedef);
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
        public static class Text
        {
            public static void DrawString(string text, string font, int fontsize, FontStyle style, Brush color, int x, int y)
            {
                Graphics g = Graphics.FromHdc(desktopPtr);
                Font fontt = new Font(text, fontsize, style);
                g.DrawString(text, fontt, color, new PointF(x, y));
            }
        }
        public static class Box
        {
            public static void DrawBox(int x, int y, int width, int height, Color color, bool argb = false, int alpha = 10, string forergb = "0,0,0")
            {
                Graphics g = Graphics.FromHdc(desktopPtr);
                if (argb)
                {
                    SolidBrush b = new SolidBrush(System.Drawing.Color.FromArgb(alpha, TerminalColor.RGB.SolveRGB(forergb, 'r'), TerminalColor.RGB.SolveRGB(forergb, 'g'), TerminalColor.RGB.SolveRGB(forergb, 'b'))); g.FillRectangle(b, new Rectangle(x, y, width, height));
                }
                else { SolidBrush b = new SolidBrush((color)); g.FillRectangle(b, new Rectangle(x, y, width, height)); }

            }
        }
    }
    public static class TerminalColor
    {
        public static class RGB
        {
            public static string GetRGB(int x, int y, bool argb = false)
            {
                IntPtr hdc = GetDC(IntPtr.Zero);
                uint pixel = GetPixel(hdc, x, y);
                Color color = Color.FromArgb((int)(pixel & 0x000000FF),
                                              (int)(pixel & 0x0000FF00) >> 8,
                                              (int)(pixel & 0x00FF0000) >> 16);
                if (argb) return $"{color.A},{color.R},{color.G},{color.B}";
                else return $"{color.R},{color.G},{color.B}";

            }
            public static int SolveRGB(string rgb, char color)
            {
                string bb = rgb.Trim();
                string[] components = bb.Split(',');
                if (components.Length != 3)
                {
                    throw new ArgumentException("Invalid RGB format");
                }
                if (color == 'r')
                {
                    return int.Parse(components[0]);
                }
                else if (color == 'g')
                {
                    return int.Parse(components[1]);
                }
                else if (color == 'b')
                {
                    return int.Parse(components[2]);
                }

                throw new ArgumentException("Invalid color");
            }
        }
        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("gdi32.dll")]
        private static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);
        public static byte RedPixel(int x, int y)
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            uint color = GetPixel(hdc, x, y);
            ReleaseDC(IntPtr.Zero, hdc);

            byte r = (byte)(color);
            return r;
        }
        public static void SetFullBGC(string rgb)
        {
            Text.WriteArea(" ", 0, Console.WindowWidth - 1, 0, Console.WindowHeight - 1, rgb, rgb);
        }
        public static byte GreenPixel(int x, int y)
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            uint color = GetPixel(hdc, x, y);
            ReleaseDC(IntPtr.Zero, hdc);

            byte g = (byte)(color >> 8);
            return g;
        }
        public static byte BluePixel(int x, int y)
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            uint color = GetPixel(hdc, x, y);
            ReleaseDC(IntPtr.Zero, hdc);

            byte b = (byte)(color >> 16);
            return b;
        }

        private static ConsoleColor GetForeColor()
        {
            return Console.ForegroundColor;
        }
        private static ConsoleColor GetBGColor()
        {
            return Console.BackgroundColor;
        }
        public static ConsoleColor BackColor(ConsoleColor color, bool setColor)
        {
            if (setColor)
            {
                Console.BackgroundColor = color;
                return color;
            }
            else { return GetBGColor(); }
        }
        public static ConsoleColor ForeColor(ConsoleColor color, bool setColor)
        {
            if (setColor)
            {
                Console.ForegroundColor = color;
                return color;
            }
            else { return GetForeColor(); }
        }
    }
    public static class Settings
    {

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOZORDER = 0x0004;
        public static void SetWindowXY(int x, int y)
        {
            IntPtr consoleWindowHandle = GetConsoleWindow();
            SetWindowPos(consoleWindowHandle, IntPtr.Zero, x, y, 0, 0, SWP_NOSIZE | SWP_NOZORDER);
        }
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowText(IntPtr hWnd, string lpString);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetClassLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        private const int MF_BYCOMMAND = 0x00000000;
        private const int SC_CLOSE = 0xF060;
        private const int SC_MINIMIZE = 0xF020;
        private const int SC_MAXIMIZE = 0xF030;
        private const int SC_SIZE = 0xF000;

        const int WM_SETICON = 0x0080;
        const int ICON_SMALL = 0;
        const int ICON_BIG = 1;

        [DllImport("user32.dll")]
        private static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        public static void SetIcon(bool taskbaricon, string path)
        {
            IntPtr consoleHandle = GetConsoleWindow();

            if (consoleHandle != IntPtr.Zero)
            {
                IntPtr hIcon = LoadIcon(path);
                if (hIcon != IntPtr.Zero && taskbaricon)
                {
                    SendMessage(consoleHandle, WM_SETICON, (IntPtr)ICON_SMALL, hIcon);
                    SendMessage(consoleHandle, WM_SETICON, (IntPtr)ICON_BIG, hIcon);
                }
                else if (hIcon != IntPtr.Zero && taskbaricon == false)
                {
                    SendMessage(consoleHandle, WM_SETICON, (IntPtr)ICON_SMALL, hIcon);
                }
            }
        }
        public static void Clear()
        {
            Console.Clear();
        }
        private static IntPtr LoadIcon(string iconPath)
        {
            try
            {
                return new System.Drawing.Icon(iconPath).Handle;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Simge yüklenirken bir hata oluştu: " + ex.Message);
                return IntPtr.Zero;
            }
        }
        private static string _title;
        public static string Title
        {
            get => _title;
            set
            {
                _title = value;
                Console.Title = _title;
            }
        }
        public static void DisableButton(bool close, bool minimize, bool maximize, bool resize)
        {
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);
            if (handle != IntPtr.Zero)
            {
                if (close) DeleteMenu(sysMenu, SC_CLOSE, MF_BYCOMMAND);

                if (minimize) DeleteMenu(sysMenu, SC_MINIMIZE, MF_BYCOMMAND);

                if (maximize) DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);

                if (resize) DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
            }
        }
        public static class Sound
        {
            const int MAXVOL = 65535;

            [DllImport("winmm.dll")]
            private static extern int waveOutSetVolume(IntPtr uDeviceID, uint dwVolume);
            public static void SetSound(int level)
            {
                if (level < 0 || level > 100)
                {
                    return;
                }
                uint volumeLevel = (uint)((double)level / 100 * MAXVOL);
                waveOutSetVolume(IntPtr.Zero, volumeLevel);
            }
        }

        public static void WindowSize(int width, int height)
        {
            WindowWidth(width);
            WindowHeight(height);
        }
        public static void WindowWidth(int width)
        {
            Console.WindowWidth = width;
        }
        public static void WindowHeight(int height)
        {
            Console.WindowHeight = height;
        }
        public static int GetWindowWidth()
        {
            return Console.WindowWidth;
        }
        public static int GetWindowHeight()
        {
            return Console.WindowHeight;
        }
    }
    public static class App
    {
        public static void Start(string path)
        {
            Process.Start(path);
        }
    }
    public static class Recommend
    {
        private static int tutarimX;
        private static int tutarimY;
        public static string Box(int x, int y, string word, string[] recom, string text, int lengt)
        {
            Terminal.Cursor.SetCursorPositionXY(x, y);
            Terminal.Cursor.CursorVisibility(true);
            bool secim = false;
            bool main = true;
            bool yazim = true;
            string input = "";
            while (main)
            {
                int ileri = 0;
                while (yazim)
                {
                    string enUzun = recom.OrderByDescending(s => s.Length).FirstOrDefault();
                    ConsoleKeyInfo keys = Console.ReadKey(intercept: true);
                    char key = keys.KeyChar;

                    if (keys.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine();
                        yazim = false;
                        main = false;
                    }
                    else if (key == '\b')
                    {
                        if (input.Length > 0)
                        {
                            Terminal.Cursor.CursorVisibility(false);
                            Terminal.Text.RemoveChar(Terminal.Cursor.GetCursorPositionX(), y - 1);
                            Terminal.Text.RemoveChar(Terminal.Cursor.GetCursorPositionX(), y + 1);
                            Terminal.Cursor.CursorVisibility(true);
                            Console.Write("\b \b");
                            input = input.Substring(0, input.Length - 1);

                        }
                        if (input.Contains(word))
                        {
                            int xx = Terminal.Cursor.GetCursorPositionX();
                            int yy = Terminal.Cursor.GetCursorPositionY();
                            for (int i = 0; i < recom.Length; i++)
                            {
                                Terminal.Cursor.SetCursorPositionXY(x, y + 2 + i);
                                Console.WriteLine(recom[i]);
                            }
                            Terminal.Cursor.SetCursorPositionXY(x, y - 2);
                            Console.Write(text);
                            if (enUzun.Length > input.Length)
                            {
                                for (int i = 0; i < enUzun.Length; i++)
                                {
                                    Terminal.Cursor.SetCursorPositionXY(x + i, y + 1);
                                    Console.Write("-");
                                }
                            }
                            else
                            {
                                for (int i = 0; i < input.Length; i++)
                                {
                                    Terminal.Cursor.SetCursorPositionXY(x + i, y + 1);
                                    Console.Write("-");
                                }
                            }
                            if (text.Length > input.Length)
                            {
                                for (int i = 0; i < text.Length; i++)
                                {
                                    Terminal.Cursor.SetCursorPositionXY(x + i, y - 1);
                                    Console.Write("-");
                                }
                            }
                            else
                            {
                                for (int i = 0; i < input.Length; i++)
                                {
                                    Terminal.Cursor.SetCursorPositionXY(x + i, y - 1);
                                    Console.Write("-");
                                }
                            }
                            Terminal.Cursor.SetCursorPositionXY(xx, yy);
                        }
                        else
                        {
                            Terminal.Text.RemoveText(x, x + enUzun.Length, y + 2, y + 2 + recom.Length);
                            Terminal.Text.RemoveText(x, x + text.Length, y - 2, y - 2);
                            Terminal.Text.RemoveText(x, input.Length > enUzun.Length ? input.Length : enUzun.Length, y + 1, y + 1);
                            Terminal.Text.RemoveText(x, x + text.Length, y - 1, y - 1);
                        }

                    }
                    else if (input.Length < lengt && (char.IsLetterOrDigit(key) || char.IsPunctuation(key) || char.IsSymbol(key) || char.IsWhiteSpace(key)))
                    {
                        input += key;
                        Console.Write(key);
                        if (input.Contains(word))
                        {
                            int xx = Terminal.Cursor.GetCursorPositionX();
                            int yy = Terminal.Cursor.GetCursorPositionY();
                            for (int i = 0; i < recom.Length; i++)
                            {
                                Terminal.Cursor.SetCursorPositionXY(x, y + 2 + i);
                                Console.WriteLine(recom[i]);
                            }
                            Terminal.Cursor.SetCursorPositionXY(x, y - 2);
                            Console.Write(text);
                            if (enUzun.Length > input.Length)
                            {
                                for (int i = 0; i < enUzun.Length; i++)
                                {
                                    Terminal.Cursor.SetCursorPositionXY(x + i, y + 1);
                                    Console.Write("-");
                                }
                            }
                            else
                            {
                                for (int i = 0; i < input.Length; i++)
                                {
                                    Terminal.Cursor.SetCursorPositionXY(x + i, y + 1);
                                    Console.Write("-");
                                }
                            }
                            if (text.Length > input.Length)
                            {
                                for (int i = 0; i < text.Length; i++)
                                {
                                    Terminal.Cursor.SetCursorPositionXY(x + i, y - 1);
                                    Console.Write("-");
                                }
                            }
                            else
                            {
                                for (int i = 0; i < input.Length; i++)
                                {
                                    Terminal.Cursor.SetCursorPositionXY(x + i, y - 1);
                                    Console.Write("-");
                                }
                            }
                            Terminal.Cursor.SetCursorPositionXY(xx, yy);
                        }
                        else
                        {
                            Terminal.Text.RemoveText(x, x + enUzun.Length, y + 2, y + 2 + recom.Length);
                            Terminal.Text.RemoveText(x, x + text.Length, y - 2, y - 2);
                            Terminal.Text.RemoveText(x, input.Length > enUzun.Length ? input.Length : enUzun.Length, y + 1, y + 1);
                            Terminal.Text.RemoveText(x, x + text.Length, y - 1, y - 1);
                        }
                    }
                    else if (input.Contains(word) && keys.Key == ConsoleKey.DownArrow)
                    {
                        tutarimX = Terminal.Cursor.GetCursorPositionX();
                        tutarimY = Terminal.Cursor.GetCursorPositionY();
                        if (Terminal.Cursor.GetCursorPositionY() == y)
                        {
                            Terminal.Text.RemoveText(x, recom[ileri].Length + x, y + 2, y + 2);
                            Terminal.Cursor.SetCursorPositionXY(x, y + 2);
                            Terminal.Text.WriteWithRGB("0,0,0", "255,255,255", recom[ileri]);
                        }
                        yazim = false;
                        secim = true;
                    }
                    Console.Title = ileri.ToString();
                }
                while (secim)
                {
                    ConsoleKeyInfo keys = Console.ReadKey(intercept: true);
                    char key = keys.KeyChar;
                    if (input.Contains(word) && keys.Key == ConsoleKey.DownArrow)
                    {
                        if (ileri + 1 != recom.Length)
                        {
                            ileri++;
                            Terminal.Text.RemoveText(x, recom[ileri].Length + x, Terminal.Cursor.GetCursorPositionY() + 1, Terminal.Cursor.GetCursorPositionY() + 1);
                            Terminal.Cursor.SetCursorPositionXY(x, Terminal.Cursor.GetCursorPositionY() + 1);
                            Terminal.Text.WriteWithRGB("0,0,0", "255,255,255", recom[ileri]);

                            if (ileri > 0)
                            {
                                Terminal.Text.RemoveText(x, recom[ileri - 1].Length + x, Terminal.Cursor.GetCursorPositionY() - 1, Terminal.Cursor.GetCursorPositionY() - 1);
                                Terminal.Cursor.SetCursorPositionXY(x, Terminal.Cursor.GetCursorPositionY() - 1);
                                Terminal.Text.WriteWithRGB("255, 255, 255", "0, 0, 0", recom[ileri - 1]);
                                Terminal.Cursor.SetCursorPositionXY(recom[ileri].Length + x, Terminal.Cursor.GetCursorPositionY() + 1);
                            }

                        }

                    }
                    else if (input.Contains(word) && keys.Key == ConsoleKey.UpArrow)
                    {
                        if (Terminal.Cursor.GetCursorPositionY() - 1 != y && ileri - 1 >= 0)
                        {
                            ileri--;
                            Terminal.Cursor.SetCursorPositionXY(recom[ileri].Length + x, Terminal.Cursor.GetCursorPositionY() - 1);
                            Terminal.Text.RemoveText(x, recom[ileri + 1].Length + x, Terminal.Cursor.GetCursorPositionY() + 1, Terminal.Cursor.GetCursorPositionY() + 1);
                            Terminal.Cursor.SetCursorPositionXY(x, Terminal.Cursor.GetCursorPositionY() + 1);
                            Terminal.Text.WriteWithRGB("255, 255, 255", "0, 0, 0", recom[ileri + 1]);
                            Terminal.Cursor.SetCursorPositionXY(recom[ileri].Length + x, Terminal.Cursor.GetCursorPositionY() - 1);
                            Terminal.Text.RemoveText(x, recom[ileri].Length + x, Terminal.Cursor.GetCursorPositionY(), Terminal.Cursor.GetCursorPositionY());
                            Terminal.Cursor.SetCursorPositionXY(x, Terminal.Cursor.GetCursorPositionY());
                            Terminal.Text.WriteWithRGB("0,0,0", "255,255,255", recom[ileri]);
                        }

                    }
                    else if (keys.Key == ConsoleKey.Enter)
                    {
                        for (int i = 0; i < recom.Length; i++)
                        {
                            Terminal.Cursor.SetCursorPositionXY(x, y + 2 + i);
                            Console.WriteLine(recom[i]);
                        }
                        if (input.Length < lengt)
                        {
                            if (!(recom[ileri].Length + input.Length > lengt))
                            {
                                Terminal.Cursor.SetCursorPositionXY(tutarimX, tutarimY);
                                input += " " + recom[ileri];
                                Console.Write(" " + recom[ileri]);
                            }
                        }
                        Terminal.Cursor.SetCursorPositionXY(x + input.Length, y);

                        yazim = true;
                        secim = false;
                    }
                }
            }
            return input;
        }
    }
    public static class Table
    {
        public static void CreateTable(string title, string[] items, int x, int y)
        {
            string[] tutabisi = items;
            Terminal.Cursor.SetCursorPositionXY(x, y);
            Console.WriteLine(title);
            string tut = "";
            for (int i = 0; i < items.Length; i++)
            {
                string a = i + ". ";

                items[i] = a + items[i].ToString();
            }
            string enUzun = items.OrderByDescending(s => s.Length).FirstOrDefault();
            if (title.Length > enUzun.Length)
            {
                for (int i = 0; i < title.Length; i++)
                {
                    tut += "-";
                }
            }
            else
            {
                for (int i = 0; i < enUzun.Length; i++)
                {
                    tut += "-";
                }
            }
            Terminal.Cursor.SetCursorPositionXY(x, y + 1);
            Console.Write(tut);
            Console.WriteLine();
            for (int i = 0; i < items.Length; i++)
            {
                Terminal.Cursor.SetCursorPositionXY(x, y + i + 2);
                Console.WriteLine(items[i]);
            }
            items = tutabisi;
        }
    }
    public static class Time
    {
        public static int GetHour()
        {
            return DateTime.Now.Hour;
        }
        public static int GetMinute()
        {
            return DateTime.Now.Minute;
        }
        public static int GetMillisecond()
        {
            return DateTime.Now.Millisecond;
        }
        public static int GetSecond()
        {
            return DateTime.Now.Second;
        }
        public static int GetMonth()
        {
            return DateTime.Now.Month;
        }
        public static int GetYear()
        {
            return DateTime.Now.Year;
        }
        public static DayOfWeek GetDayOfWeek()
        {
            return DateTime.Now.DayOfWeek;
        }
        public static int GetDayOfYear()
        {
            return DateTime.Now.DayOfYear;
        }
        public static int GetDay()
        {
            return DateTime.Now.Day;
        }
        public static void Wait(int delay)
        {
            Thread.Sleep(delay);
        }
    }
    public static class Text
    {
        public static int CountWord(string text)
        {
            int a = 0;
            string r_text = text.TrimEnd().TrimStart();
            for (int i = 0; i < r_text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    a++;
                }
            }
            return a + 1;
        }
        public static string SplitWord(string text, char item)
        {
            string a = "";
            for (int i = 0; i < text.Length; i++)
            {

                if (text[i] == ' ')
                {
                    a += item;
                }
                else
                {
                    a += text[i];
                }
            }
            return a;
        }
        public static string MakeReverse(string text)
        {
            char[] chars = text.ToCharArray();
            string reversed = "";
            for (int i = chars.Length - 1; i >= 0; i--)
            {
                reversed += chars[i];
            }
            text = reversed;
            return text;
        }

        public static class Arrays
        {
            public static int TheLongest(string[] arr)
            {
                int a = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].Length > a)
                    {
                        a = arr[i].Length;
                    }
                }
                return a - 1;
            }
            public static int IndexOf(string[] arr, string value)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == value)
                    {
                        return i;
                    }
                }
                return 0;
            }
            public static int IndexOfTheLongest(string[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].Length == TheLongest(arr) + 1)
                    {
                        return i;
                    }
                }
                return 0;
            }

            public static void MakeReverse(string[] arr)
            {
                string[] reversed = new string[arr.Length];
                int s = 0;
                for (int i = arr.Length - 1; i >= 0; i--, s++)
                {
                    reversed[s] = arr[i];
                }
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = reversed[i];
                }

            }

        }
        public static string BLOCK { get { return "█"; } private set { value = "█"; } }
        public static string Input()
        {
            return Console.ReadLine();
        }
        public static string Input<t>(t text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }
        public static string Input<t>(t text, string rgb)
        {
            Text.WriteFore(rgb, text.ToString());
            return Console.ReadLine();
        }
        public static string Input(bool writekeys = false)
        {
            string s = "";
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(writekeys);
                if (key.Key == ConsoleKey.Enter)
                {
                    return s;
                }
                else if (char.IsLetter(key.KeyChar) || char.IsDigit(key.KeyChar) || char.IsSymbol(key.KeyChar))
                {
                    s += key.KeyChar.ToString();
                }
            }
        }
        public static string Input(string text, bool writekeys = false)
        {
            Console.Write(text);
            string s = "";
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(writekeys);
                if (key.Key == ConsoleKey.Enter)
                {
                    return s;
                }
                else if (char.IsLetter(key.KeyChar) || char.IsDigit(key.KeyChar) || char.IsSymbol(key.KeyChar))
                {
                    s += key.KeyChar.ToString();
                }
            }
        }
        public static string Take(string text, int start, int end)
        {
            return text.Substring(start, end - start);
        }
        public static string Add(int size, string content, string text, char startOrEnd)
        {
            if (startOrEnd == 's')
            {
                string a = "";
                for (int i = 0; i < size; i++)
                {
                    a += content;
                }
                return a + text;
            }
            else if (startOrEnd == 'e')
            {
                string a = "";
                for (int i = 0; i < size; i++)
                {
                    a += content;
                }
                return text + a;
            }
            return string.Empty;

        }
        public static string Space(int size)
        {
            string spacer = string.Empty;
            for (int i = 0; i < size; ++i)
            {
                spacer += " ";
            }
            return spacer;
        }
        public static string FillSpace(string text, char fill)
        {
            string a = "";
            char[] chars = text.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == ' ') chars[i] = fill;
                a += chars[i];
            }
            return a;
        }
        private const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 4;
        [DllImport("kernel32.dll")]
        private static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);
        public static void UseDecaration() { var handle = GetStdHandle(STD_OUTPUT_HANDLE); uint mode; GetConsoleMode(handle, out mode); mode |= ENABLE_VIRTUAL_TERMINAL_PROCESSING; SetConsoleMode(handle, mode); }
        public static string UNDERLINE { get { return "\x1b[4m"; } private set { UNDERLINE = value; } }
        public static string RESET { get { return "\x1b[0m"; } private set { RESET = value; } }
        //public static void TurnIntoLink(int x, int y, string text, string link)
        //{
        //    if (Mouse.ConsoleMouse.MouseHover(x, x + text.Length, y, y))
        //    {
        //        if (Mouse.ConsoleMouse.Click('l'))
        //        {
        //            App.Start(link);
        //        }
        //    }
        //}
        //public static void Link(int x, int y, string link, string text, string rgb = "0,0,255", string oldrgb = "255,255,255")
        //{
        //    if (Mouse.ConsoleMouse.MouseHover(x, x + link.Length, y, y))
        //    {
        //        Cursor.SetCursorPositionXY(x, y);
        //        Text.WriteFore(rgb, UNDERLINE + text + RESET);
        //        Cursor.CursorVisibility(false);
        //        if (Mouse.ConsoleMouse.Click('l'))
        //        {
        //            App.Start(link);
        //        }
        //    }
        //    else
        //    {
        //        Cursor.SetCursorPositionXY(x, y);
        //        Text.WriteFore(oldrgb, text);
        //    }
        //}
        public static int IndexOf(string text, string val, int index) { return text.IndexOf(val, index); }
        public static bool Contains<t>(string text, t val) { if (text.Contains(val.ToString())) return true; else return false; }
        public static string MakeString<t>(t obj) { return obj.ToString(); }
        public static string LowerCase(string text) { return text.ToLower(); }
        public static string UpperCase(string text) { return text.ToUpper(); }
        public static string Replace(string Text, string oldVal, string newVal) { return Text.Replace(oldVal, newVal); }
        public static void OutputEncoding(Encoding encoder) { Console.OutputEncoding = encoder; }
        public static void InputEncoding(Encoding encoder) { Console.InputEncoding = encoder; }
        public static int LengthOf(string text) { return text.Length; }
        [StructLayout(LayoutKind.Sequential)]
        private struct COORD
        {
            public short X;
            public short Y;
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadConsoleOutputCharacter(IntPtr hConsoleOutput, [Out] char[] lpCharacter, uint nLength, COORD dwReadCoord, out uint lpNumberOfCharsRead);

        private const int STD_OUTPUT_HANDLE = -11;
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool GetConsoleMode(IntPtr handle, out int mode);
        private const int STD_INPUT_HANDLE = -10;
        private const uint ENABLE_MOUSE_INPUT = 0x0010;
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);
        public static void WriteIndex(string text, string rgb, string indexed, string other_rgb)
        {
            if (text.Contains(indexed))
            {
                string[] a = text.Split(' ');
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] == indexed)
                    {
                        Text.WriteFore(rgb, a[i]);
                    }
                    else
                    {
                        if (i + 1 != a.Length)
                        {
                            Text.WriteFore(other_rgb, a[i] + " ");
                        }
                    }
                }
            }
        }

        public static void DDGH()
        {
            var handle = GetStdHandle(-11);
            int mode;
            GetConsoleMode(handle, out mode);
            SetConsoleMode(handle, mode | 0x4);
        }
        public static void WriteFore(string forergb, string text)
        {
            DDGH();
            Console.Write($"\x1b[38;2;{TerminalColor.RGB.SolveRGB(forergb, 'r')};{TerminalColor.RGB.SolveRGB(forergb, 'g')};{TerminalColor.RGB.SolveRGB(forergb, 'b')}m{text}\x1b[0m");
        }
        public static void SetWriteFore(string forergb, string text, int x, int y)
        {
            DDGH();
            Cursor.SetCursorPositionXY(x, y);
            Console.Write($"\x1b[38;2;{TerminalColor.RGB.SolveRGB(forergb, 'r')};{TerminalColor.RGB.SolveRGB(forergb, 'g')};{TerminalColor.RGB.SolveRGB(forergb, 'b')}m{text}\x1b[0m");
        }
        public static void WriteLine<t>(t text)
        {
            Console.WriteLine(text);
        }
        public static void SetWrite<t>(t text, int x, int y)
        {
            Cursor.SetCursorPositionXY(x, y);
            Console.Write(text);
        }
        public static void SetWriteLine<t>(t text, int x, int y)
        {
            Cursor.SetCursorPositionXY(x, y);
            Console.WriteLine(text);
        }
        public static void NewLine()
        {
            Console.WriteLine();
        }
        public static void NewLine(int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine();
            }
        }
        public static char GetChar(int x, int y)
        {
            IntPtr hConsoleOutput = GetStdHandle(STD_OUTPUT_HANDLE);
            COORD readCoord = new COORD { X = (short)x, Y = (short)y };
            char[] lpCharacter = new char[1];
            uint lpNumberOfCharsRead;
            ReadConsoleOutputCharacter(hConsoleOutput, lpCharacter, 1, readCoord, out lpNumberOfCharsRead);
            return lpCharacter[0];
        }
        public static string GetTextLine(int x, int endx, int y)
        {
            string text = "";
            for (int i = x; i < endx; i++)
            {
                text += GetChar(i, y);
            }
            return text;
        }
        public static string AddSpace(string text, char s_or_e, int unit)
        {
            string a = "";
            for (int i = 0; i < unit; i++)
            {
                a += " ";
            }
            if (s_or_e == 's')
            {
                return a + text;
            }
            else if (s_or_e == 'e')
            {
                return text + a;
            }
            else return null;
        }
        public static string GetText(int start_x, int end_x, int start_y, int end_y)
        {
            string text = "";
            for (int i = start_y; i < end_y; i++)
            {
                if (i + 1 == end_y)
                {
                    text += '\n';
                    text = AddSpace(text, 's', start_x);
                }
                for (int j = start_x; j < end_x; j++)
                {
                    text += GetChar(j, i);
                }
            }
            return text;

        }
        public static void WriteArea<t>(t chr, int start_x, int end_x, int start_y, int end_y, string forergb = "0,0,0", string bgrgb = "255,255,255")
        {
            for (int i = start_x; i < end_x + 1; i++)
            {
                for (int j = start_y; j < end_y + 1; j++)
                {
                    Text.SetWriteWithRGB(i, j, forergb, bgrgb, chr.ToString());
                }
            }
        }
        public static void WriteWithRGB(string forergb = "0,0,0", string bgrgb = "255,255,255", string text = "")
        {
            DDGH();
            Console.Write($"\x1b[48;2;{TerminalColor.RGB.SolveRGB(bgrgb, 'r')};{TerminalColor.RGB.SolveRGB(bgrgb, 'g')};{TerminalColor.RGB.SolveRGB(bgrgb, 'b')};38;2;{TerminalColor.RGB.SolveRGB(forergb, 'r')};{TerminalColor.RGB.SolveRGB(forergb, 'g')};{TerminalColor.RGB.SolveRGB(forergb, 'b')}m{text}\x1b[0m");
        }
        public static void WriteLineWithRGB(string forergb = "0,0,0", string bgrgb = "255,255,255", string text = "")
        {
            DDGH();
            Console.WriteLine($"\x1b[48;2;{TerminalColor.RGB.SolveRGB(bgrgb, 'r')};{TerminalColor.RGB.SolveRGB(bgrgb, 'g')};{TerminalColor.RGB.SolveRGB(bgrgb, 'b')};38;2;{TerminalColor.RGB.SolveRGB(forergb, 'r')};{TerminalColor.RGB.SolveRGB(forergb, 'g')};{TerminalColor.RGB.SolveRGB(forergb, 'b')}m{text}\x1b[0m");
        }
        public static void SetWriteWithRGB(int x, int y, string forergb = "0,0,0", string bgrgb = "255,255,255", string text = "")
        {
            DDGH();
            Terminal.Cursor.SetCursorPositionXY(x, y);
            Console.Write($"\x1b[48;2;{TerminalColor.RGB.SolveRGB(bgrgb, 'r')};{TerminalColor.RGB.SolveRGB(bgrgb, 'g')};{TerminalColor.RGB.SolveRGB(bgrgb, 'b')};38;2;{TerminalColor.RGB.SolveRGB(forergb, 'r')};{TerminalColor.RGB.SolveRGB(forergb, 'g')};{TerminalColor.RGB.SolveRGB(forergb, 'b')}m{text}\x1b[0m");
        }
        public static void SetWriteLineWithRGB(int x, int y, string forergb = "0,0,0", string bgrgb = "255,255,255", string text = "")
        {
            DDGH(); Terminal.Cursor.SetCursorPositionXY(x, y);
            Console.WriteLine($"\x1b[48;2;{TerminalColor.RGB.SolveRGB(bgrgb, 'r')};{TerminalColor.RGB.SolveRGB(bgrgb, 'g')};{TerminalColor.RGB.SolveRGB(bgrgb, 'b')};38;2;{TerminalColor.RGB.SolveRGB(forergb, 'r')};{TerminalColor.RGB.SolveRGB(forergb, 'g')};{TerminalColor.RGB.SolveRGB(forergb, 'b')}m{text}\x1b[0m");
        }
        public static void Capsule(int x, int y, string text, string forergb = "0,0,0", string bgrgb = "255,255,255")
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (i == 0)
                {
                    Terminal.Cursor.SetCursorPositionXY(x - 1, y);
                    Terminal.Text.WriteWithRGB(forergb, bgrgb, "╭");
                    Terminal.Cursor.SetCursorPositionXY(x, y);
                    Terminal.Text.WriteWithRGB(forergb, bgrgb, "─");
                    Terminal.Cursor.SetCursorPositionXY(x + 1, y);
                    Terminal.Text.WriteWithRGB(forergb, bgrgb, "╮");
                }
                Terminal.Cursor.SetCursorPositionXY(x, y + i + 1);
                if (i < text.Length)
                {
                    Console.Write(text[i]);
                }
                Terminal.Cursor.SetCursorPositionXY(x - 1, y + i + 1);
                Terminal.Text.WriteWithRGB(forergb, bgrgb, "│");
                Terminal.Cursor.SetCursorPositionXY(x + 1, y + i + 1);
                Terminal.Text.WriteWithRGB(forergb, bgrgb, "│");
                if (i + 1 == text.Length)
                {
                    Terminal.Cursor.SetCursorPositionXY(x - 1, y + i + 2);
                    Terminal.Text.WriteWithRGB(forergb, bgrgb, "╰");
                    Terminal.Cursor.SetCursorPositionXY(x, y + i + 2);
                    Terminal.Text.WriteWithRGB(forergb, bgrgb, "─");
                    Terminal.Cursor.SetCursorPositionXY(x + 1, y + 2 + i);
                    Terminal.Text.WriteWithRGB(forergb, bgrgb, "╯");
                }
            }
        }
        public static void RemoveChar(int x, int y)
        {
            int xx = Terminal.Cursor.GetCursorPositionX();
            int yy = Terminal.Cursor.GetCursorPositionY();
            Terminal.Cursor.SetCursorPositionXY(x, y);
            Console.Write("\b \b");
            Terminal.Cursor.SetCursorPositionXY(xx, yy);
        }
        public static void RemoveText(int start_x, int end_x, int start_y, int end_y)
        {
            int xx = Terminal.Cursor.GetCursorPositionX();
            int yy = Terminal.Cursor.GetCursorPositionY();
            for (int i = start_y; i < end_y + 1; i++)
            {
                for (int j = start_x; j < end_x + 1; j++)
                {
                    RemoveChar(j, i);
                }
            }
            Terminal.Cursor.SetCursorPositionXY(xx, yy);
        }
    }
    public static class FileIO
    {
        public static string FileContent(string path)
        {
            return File.ReadAllText(path);
        }
        public static int LineCount(string path)
        {
            return File.ReadAllLines(path).Length;
        }
        public static string GetLine(string path, int row)
        {
            string[] line = File.ReadAllLines(path);
            return line[row];
        }

        public static string ReadFileLine(string path, int line)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string lines;
                int currentLine = 0;
                while ((lines = reader.ReadLine()) != null)
                {
                    currentLine++;
                    if (currentLine == line)
                    {
                        return lines;
                    }
                }
            }
            return string.Empty;
        }
        public static string MakePath(string path)
        {
            string rps = "";
            string[] rp = path.Split('\\');
            for (int i = 0; i < rp.Length; i++)
            {
                rps += rp[i];
                if (i + 1 != rp.Length) rps += "\\";
            }
            return rps;
        }
        public static void CreateFile(string path, string filename)
        {
            string[] rp = path.Split('\\');
            string rps = "";
            for (int i = 0; i < rp.Length; i++)
            {
                rps += rp[i];
                if (i + 1 != rp.Length) rps += "\\";
            }
            using (FileStream fs = File.Create(path + "\\" + filename))
            {
            }
        }
        public static void WriteFile(string path, string text)
        {
            using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                writer.WriteLine(text);
            }
        }
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern IntPtr CreateFile(string lpFileName, FileAccess dwDesiredAccess, FileShare dwShareMode, IntPtr lpSecurityAttributes, FileMode dwCreationDisposition, FileAttributes dwFlagsAndAttributes, IntPtr hTemplateFile);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool GetFileSizeEx(IntPtr hFile, out long lpFileSize);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr hObject);

        public static void SetRowFromFile(string filepath, int row, string newtext)
        {
            if (!File.Exists(filepath) || row <= 0)
            {
                return;
            }
            string[] satirlar = File.ReadAllLines(filepath);

            if (row > satirlar.Length)
            {
                return;
            }
            satirlar[row - 1] = newtext;
            File.WriteAllLines(filepath, satirlar);
        }
        public static void AddTextoToRowFromFile(string filepath, int row, int index, string text)
        {

            if (!File.Exists(filepath) || row <= 0)
            {
                return;
            }
            string[] satirlar = File.ReadAllLines(filepath);
            if (row > satirlar.Length)
            {

                return;
            }
            string satirMetni = satirlar[row - 1];
            if (index < 0 || index > satirMetni.Length)
            {

                satirMetni = satirMetni.PadRight(index + text.Length);
            }
            satirMetni = satirMetni.Insert(index, text);
            satirlar[row - 1] = satirMetni;
            File.WriteAllLines(filepath, satirlar);
        }

        public static string GetRowFromFile(string filepath, int row)
        {
            if (!File.Exists(filepath) || row <= 0)
            {
                return "b";
            }
            string[] satirlar = File.ReadAllLines(filepath);

            if (row > satirlar.Length)
            {
                return "ds0";
            }
            return satirlar[row - 1];
        }
    }
    public static class Cursor
    {
        public static void CursorVisibility(bool visibility) { Console.CursorVisible = visibility; }
        public static void SetCursorPositionXY(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
        public static void SetCursorPositionY(int y) { Console.CursorTop = y; }
        public static void SetCursorPositionX(int x) { Console.CursorLeft = x; }

        public static string GetCursorPositionXY()
        {
            int x = GetCursorPositionX();
            int y = GetCursorPositionY();
            return "X {" + x + "} Y {" + y + "}";
        }
        public static int GetCursorPositionY() { return Console.CursorTop; }
        public static int GetCursorPositionX() { return Console.CursorLeft; }
    }
    //public static class Mouse
    //{
    //    public static class GlobalMouse
    //    {
    //        [DllImport("user32.dll")]
    //        private static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);
    //        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    //        private static extern void mouse_event(uint dwFlags, int dx, int dy, uint cButtons, uint dwExtraInfo);
    //        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
    //        private const int MOUSEEVENTF_RIGHTUP = 0x10;
    //        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
    //        private const int MOUSEEVENTF_LEFTUP = 0x04;

    //        [DllImport("user32.dll")]
    //        private static extern short GetAsyncKeyState(int vKey);

    //        [DllImport("user32.dll")]
    //        private static extern bool GetCursorPos(out POINT lpPoint);

    //        const int VK_LBUTTON = 0x01;
    //        const int VK_RBUTTON = 0x02;

    //        static bool previousLeftState = false;
    //        static bool previousRightState = false;

    //        private struct POINT
    //        {
    //            public int X;
    //            public int Y;
    //        }
    //        [DllImport("user32.dll")]
    //        private static extern bool SetCursorPos(int X, int Y);
    //        public static int GetMouseX() { POINT point; GetCursorPos(out point); return point.X; }
    //        public static int GetMouseY() { POINT point; GetCursorPos(out point); return point.Y; }
    //        public static string GetMouseXY() { POINT point; GetCursorPos(out point); int x = Terminal.Mouse.GlobalMouse.GetMouseX(); int y = Terminal.Mouse.GlobalMouse.GetMouseY(); return "X {" + x + "} Y {" + y + "}"; }
    //        public static void SetMouseXY(int x, int y)
    //        {
    //            SetCursorPos(x, y);
    //        }
    //        public static void SendRightClick(int x, int y, int delayToMouseUp = 0)
    //        {
    //            mouse_event(MOUSEEVENTF_RIGHTDOWN, x, y, 0, 0);
    //            Terminal.Time.Wait(delayToMouseUp);
    //            mouse_event(MOUSEEVENTF_RIGHTUP, x, y, 0, 0);
    //        }
    //        public static void SendLeftClick(int x, int y, int delayToMouseUp = 0)
    //        {
    //            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
    //            Thread.Sleep(delayToMouseUp);
    //            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
    //        }
    //        public static bool LeftClick(bool MouseUp = false)
    //        {
    //            bool currentLeftState = (GetAsyncKeyState(VK_LBUTTON) & 0x8000) != 0;
    //            if (!previousLeftState && currentLeftState && MouseUp == false)
    //            {
    //                return true;
    //            }
    //            else if (previousLeftState && !currentLeftState && MouseUp == true)
    //            {
    //                return true;
    //            }
    //            else { return false; }
    //        }
    //        public static bool RigthClick(bool MouseUp = false)
    //        {
    //            bool currentRightState = (GetAsyncKeyState(VK_RBUTTON) & 0x8000) != 0;
    //            if (!previousRightState && currentRightState && MouseUp == false)
    //            {
    //                return true;
    //            }
    //            else if (previousRightState && !currentRightState && MouseUp == true)
    //            {
    //                return true;
    //            }
    //            else { return false; }
    //        }
    //        public static bool MouseHover(int start_x, int end_x, int start_y, int end_y)
    //        {
    //            int xx = Mouse.GlobalMouse.GetMouseX();
    //            int yy = Mouse.GlobalMouse.GetMouseY();
    //            if (xx >= end_x && xx <= end_x && yy >= end_y && yy <= end_y)
    //            {
    //                return true;
    //            }
    //            else return false;
    //        }
    //    }
        //public static class ConsoleMouse
        //{
        //    [DllImport("kernel32.dll", SetLastError = true)]
        //    private static extern IntPtr GetStdHandle(int handle);

        //    [DllImport("kernel32.dll", SetLastError = true)]
        //    private static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

        //    [DllImport("kernel32.dll", SetLastError = true)]
        //    private static extern bool ReadConsoleInput(IntPtr hConsoleInput, [Out] INPUT_RECORD[] lpBuffer, uint nLength, out uint lpNumberOfEvents);

        //    private const int STD_INPUT_HANDLE = -10;
        //    private const uint ENABLE_EXTENDED_FLAGS = 0x0080;
        //    private const uint ENABLE_MOUSE_INPUT = 0x0010;

        //    [StructLayout(LayoutKind.Explicit)]
        //    private struct INPUT_RECORD
        //    {
        //        [FieldOffset(0)]
        //        public ushort EventType;
        //        [FieldOffset(4)]
        //        public MOUSE_EVENT_RECORD MouseEvent;
        //    }

        //    [StructLayout(LayoutKind.Sequential)]
        //    private struct MOUSE_EVENT_RECORD
        //    {
        //        public COORD dwMousePosition;
        //        public uint dwButtonState;
        //        public uint dwControlKeyState;
        //        public uint dwEventFlags;
        //    }

        //    [StructLayout(LayoutKind.Sequential)]
        //    private struct COORD
        //    {
        //        public short X;
        //        public short Y;
        //    }

        //    private static IntPtr hConsoleHandle = GetStdHandle(STD_INPUT_HANDLE);
        //    private static bool _running = false;

        //    static ConsoleMouse()
        //    {
        //        SetConsoleMode(hConsoleHandle, ENABLE_MOUSE_INPUT | ENABLE_EXTENDED_FLAGS);
        //    }
        //    public static void StopListening()
        //    {
        //        _running = false;
        //    }

        //    public static int GetMouseX()
        //    {
        //        var mouseEvent = GetMouseEvent();
        //        return mouseEvent.dwMousePosition.X;
        //    }

        //    public static int GetMouseY()
        //    {
        //        var mouseEvent = GetMouseEvent();
        //        return mouseEvent.dwMousePosition.Y;
        //    }

        //    public static bool IsLeftClick()
        //    {
        //        var mouseEvent = GetMouseEvent();
        //        return (mouseEvent.dwButtonState & 0x01) != 0;
        //    }

        //    public static bool IsRightClick()
        //    {
        //        var mouseEvent = GetMouseEvent();
        //        return (mouseEvent.dwButtonState & 0x02) != 0;
        //    }

        //    private static MOUSE_EVENT_RECORD GetMouseEvent()
        //    {
        //        INPUT_RECORD[] records = new INPUT_RECORD[1];
        //        uint numberOfEvents;
        //        ReadConsoleInput(hConsoleHandle, records, 1, out numberOfEvents);

        //        if (numberOfEvents > 0 && records[0].EventType == 0x0002)
        //        {
        //            return records[0].MouseEvent;
        //        }

        //        return new MOUSE_EVENT_RECORD();
        //    }

        //    private static void OnLeftClick(int x, int y)
        //    {
        //        Console.WriteLine($"Left click at X: {x}, Y: {y}");
        //        // Implement your logic for left click handling here
        //    }

        //    private static void OnRightClick(int x, int y)
        //    {
        //        Console.WriteLine($"Right click at X: {x}, Y: {y}");
        //        // Implement your logic for right click handling here
        //    }
        //}
        //}
}
