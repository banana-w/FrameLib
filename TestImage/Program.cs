using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System;
using System.Drawing;
using System.Reflection.Metadata;
using TestImage.Drive;
using TestImage.Frame;
using TestImage.Render;
using TestImage.Utils;

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
        var list = new List<ImageInFrame>();
        //FrameType frameType = new()
        //{
        //    Width = 1200,
        //    Height = 1800,
        //    Colum = 2,
        //    Row = 2,
        //    Code = "1a",
        //    BackgroundImage = Image.FromFile("C:/Users/Admin/Desktop/PNG/PNG/2x6 01.png"),
        //    ImageInFrames = list,
        //    Theme = FrameTheme.FALL
        //};
        ImageInFrame image = new()
        {
            Width = 534,
            Height = 532,
            TopLeft = new PointF(33, 39),
            Image = Image.FromFile("C:/Users/Admin/Downloads/anh1.png"),
            MarginTop = 40,
            MarginBottom = 40,
            MarginLeft = 34,
            MarginRight = 34
        };
        ImageInFrame image2 = new()
        {
            Width = 534,
            Height = 532,
            TopLeft = new PointF(634, 39),
            Image = Image.FromFile("C:/Users/Admin/Pictures/Screenshots/Screenshot 2024-01-25 164559.png"),
            MarginTop = 40,
            MarginBottom = 40,
            MarginLeft = 34,
            MarginRight = 34


        };
        ImageInFrame image3 = new()
        {
            Width = 534,
            Height = 532,
            TopLeft = new PointF(33, 604),
            Image = Image.FromFile("C:/Users/Admin/Pictures/Screenshots/Screenshot 2024-02-08 011733.png"),
            MarginTop = 40,
            MarginBottom = 40,
            MarginLeft = 34,
            MarginRight = 34


        };
        ImageInFrame image4 = new()
        {
            Width = 534,
            Height = 532,
            TopLeft = new PointF(634, 604),
            Image = Image.FromFile("C:/Users/Admin/Pictures/Screenshots/Screenshot 2023-11-27 020536.png"),
            MarginTop = 40,
            MarginBottom = 40,
            MarginLeft = 34,
            MarginRight = 34


        };
        ImageInFrame image5 = new()
        {
            Width = 534,
            Height = 532,
            TopLeft = new PointF(33, 604),
            Image = Image.FromFile("C:/Users/Admin/Pictures/Screenshots/Screenshot 2023-10-04 224717.png"),
            MarginTop = 37,
            MarginBottom = 37,
            MarginLeft = 27,
            MarginRight = 27


        };
        ImageInFrame image6 = new()
        {
            Width = 534,
            Height = 532,
            TopLeft = new PointF(634, 604),
            Image = Image.FromFile("C:/Users/Admin/Pictures/Screenshots/Screenshot 2023-10-04 224703.png"),
            MarginTop = 37,
            MarginBottom = 37,
            MarginLeft = 27,
            MarginRight = 27


        };
        list.Add(image);
        list.Add(image4);
        list.Add(image3);
        list.Add(image2);
        //list.Add(image5);

        Frames.Instance.LoadListType();
        Frames.Instance.LoadTypeImage("C:/Users/Admin/Desktop/PNG/TYPE1", "1a");
        Frames.Instance.LoadTypeImage("C:/Users/Admin/Desktop/PNG", "2a");
        //RenderManager.Render(Frames.Instance.GetType("1a"), "FALL_abc.png", list);
        //Bitmap result = RenderManager.CombineImage(Frames.Instance.GetType("1a"), list);

        //RenderManager.FrameImage(Frames.Instance.GetType("1a"), result, "FALL_abc.png");
        RenderManager.Render(Frames.Instance.GetType("1a"), "FALL_abc.png", list);

        var savePath = "D:/testmagik";
        var fileName = "TYPE1.zip";
        var zipPath = savePath + "/" + fileName;
        var outputFolder = savePath + "/TYPE1";
        ////DriveDownload.DriveDownloadFile(@"C:\Users\Admin\Downloads\credentials.json", savePath, fileName);

        Util.ExtractZipContent(zipPath, "", outputFolder);

    }
}
