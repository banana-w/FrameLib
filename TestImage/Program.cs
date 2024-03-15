using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using TestImage.Frame;
using TestImage.Render;


class Program
{
    private static UserCredential Login(string GClientId, string GClientSecret)
    {
        ClientSecrets secrets = new()
        {
            ClientId = GClientId,
            ClientSecret = GClientSecret
        };
        return GoogleWebAuthorizationBroker.AuthorizeAsync(secrets, new[] { "https://www.googleapis.com/auth/drive.readonly" }, "user", CancellationToken.None).Result;
    }
    static void Main()
    {
        var list = new List<Image>();


        Image image = Image.FromFile("C:/Users/Admin/Downloads/anh1.png");
        list.Add(image);



        Frames.Instance.LoadListType();
        Frames.Instance.LoadTypeImage("C:/Users/Admin/Desktop/PNG/TYPE1", "1a");
        Frames.Instance.LoadTypeImage("C:/Users/Admin/Desktop/PNG", "2a");
        //RenderManager.Render(Frames.Instance.GetType("1a"), "FALL_abc.png", list);
        Bitmap result = RenderManager.CombineImage(Frames.Instance.GetType("1a"), list);
        result.Save("cc.png");
        //RenderManager.FrameImage(Frames.Instance.GetType("1a"), result, "FALL_abc.png");
        //RenderManager.Render(Frames.Instance.GetType("1a"), "5x5 01.png", list);

        //var savePath = "D:/testmagik";
        //var fileName = "TYPE1.zip";
        //var zipPath = savePath + "/" + fileName;
        //var outputFolder = savePath + "/TYPE1";
        //////DriveDownload.DriveDownloadFile(@"C:\Users\Admin\Downloads\credentials.json", savePath, fileName);

        //Util.ExtractZipContent(zipPath, "", outputFolder);

    }



    static void Maiccn()
    {
        // Load ảnh gốc
        Bitmap originalImage = new Bitmap("C:/Users/Admin/Pictures/Screenshots/Screenshot 2024-01-25 164559.png");

        // Kích thước mới của ảnh
        int newWidth = 546;
        int newHeight = 364;

        // Tạo Bitmap mới cho ảnh thay đổi kích thước
        Bitmap resizedImage = new Bitmap(newWidth, newHeight);

        // Sử dụng Graphics để vẽ ảnh mới
        using (Graphics g = Graphics.FromImage(resizedImage))
        {
            // Thiết lập chất lượng vẽ
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Vẽ ảnh mới từ ảnh gốc
            g.DrawImage(originalImage, new Rectangle(0, 0, newWidth, newHeight));
        }

        // Lưu ảnh mới
        resizedImage.Save("resized.jpg");

        // Giải phóng bộ nhớ
        originalImage.Dispose();
        resizedImage.Dispose();
    }
}


