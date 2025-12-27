using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace BasicChat // Nhớ đổi namespace theo project của bạn
{
    public static class AvatarGenerator
    {
        // Danh sách màu pastel đẹp mắt để làm nền
        private static readonly List<string> _colors = new List<string>
        {
            "#1abc9c", "#2ecc71", "#3498db", "#9b59b6", "#34495e",
            "#16a085", "#27ae60", "#2980b9", "#8e44ad", "#2c3e50",
            "#f1c40f", "#e67e22", "#e74c3c", "#ecf0f1", "#95a5a6",
            "#f39c12", "#d35400", "#c0392b", "#bdc3c7", "#7f8c8d"
        };

        public static Image Generate(string text, int width = 100, int height = 100)
        {
            if (string.IsNullOrEmpty(text)) text = "?";

            // Lấy chữ cái đầu và chuyển thành in hoa
            string letter = text.Substring(0, 1).ToUpper();

            // Chọn màu dựa trên tên (để tên giống nhau thì màu giống nhau)
            int colorIndex = Math.Abs(text.GetHashCode()) % _colors.Count;
            Color bgColor = ColorTranslator.FromHtml(_colors[colorIndex]);

            Bitmap bmp = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Cấu hình nét vẽ mượt mà (AntiAlias)
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                // 1. Vẽ hình tròn nền
                using (Brush b = new SolidBrush(bgColor))
                {
                    g.FillEllipse(b, 0, 0, width, height);
                }

                // 2. Vẽ chữ cái ở giữa
                using (Font f = new Font("Segoe UI", width / 2.5f, FontStyle.Bold))
                {
                    // Canh giữa chữ
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    g.DrawString(letter, f, Brushes.White, new RectangleF(0, 0, width, height), sf);
                }
            }

            return bmp;
        }
    }
}