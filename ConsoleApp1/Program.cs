using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Đường dẫn tới các tấm hình
        string portraitImagePath = "portrait.jpg";
        string frameImagePath = "frame.jpg";

        // Tải tấm hình chân dung và frame
        Bitmap portrait = new Bitmap(portraitImagePath);
        Bitmap frame = new Bitmap(frameImagePath);

        // Tạo một bitmap mới với kích thước bằng với frame
        Bitmap result = new Bitmap(frame.Width, frame.Height);

        // Tạo graphics object để vẽ lên bitmap result
        using (Graphics g = Graphics.FromImage(result))
        {
            // Vẽ tấm hình chân dung lên bitmap result
            g.DrawImage(portrait, 0, 0, frame.Width, frame.Height);

            // Vẽ tấm hình frame lên bitmap result
            g.DrawImage(frame, 0, 0, frame.Width, frame.Height);
        }

        // Lưu bitmap result vào một tệp mới
        result.Save("result.jpg");

        // Giải phóng bộ nhớ
        portrait.Dispose();
        frame.Dispose();
        result.Dispose();
    }
}

