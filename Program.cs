using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;

namespace Clifford
{
    class Program
    {
        static void Main()
        {
            Bitmap buffer;
            Color q;
            buffer = new Bitmap(1920, 1080);
            q = Color.FromArgb(255, 235, 235, 235);
            double x, y, x_pre, y_pre, a, b, c, d;
            x = 0;
            y = 0;
            a = 1.2;
            b = -1.2;
            c = 0.1;
            d = 1.5;
            for (int j = 0; j < 1000; ++j)
            {
                c = 0.1 + 0.002 * j;
                buffer.Dispose();
                buffer = new Bitmap(1920, 1080);
                for (int i = 0; i < 4000000; ++i)
                {
                    x_pre = x;
                    y_pre = y;
                    x = Math.Sin(y_pre * a) + c * Math.Cos(x_pre * a);
                    y = Math.Sin(x_pre * b) + d * Math.Cos(y_pre * b);
                    buffer.SetPixel((int)(1920 * (x + 1 + c) / (2 * c + 2)), (int)(1080 * (y + 1 + d) / (2 * d + 2)), q);
                }
                buffer.Save("D:\\imgs\\img" + (j + 0).ToString("D3") + ".bmp");
            }
        }
    }
}