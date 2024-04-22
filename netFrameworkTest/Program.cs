using FrameLib.Drive;
using FrameLib.Frame;
using FrameLib.Render;
using FrameLib.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace netFrameworkTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Image>();


            Image image = Image.FromFile("C:/Users/Admin/Downloads/anh1.png");
            Image image2 = Image.FromFile("C:/Users/Admin/Downloads/anh1.png");
            Image image3 = Image.FromFile("C:/Users/Admin/Downloads/anh1.png");
            Image image4 = Image.FromFile("C:/Users/Admin/Downloads/anh1.png");
            Image image5 = Image.FromFile("C:/Users/Admin/Downloads/anh1.png");
            Image image6 = Image.FromFile("C:/Users/Admin/Downloads/anh1.png");
            list.Add(image);
            list.Add(image2);
            list.Add(image3);
            list.Add(image4);
            list.Add(image5);
            list.Add(image6);


            //Frames.Instance.LoadListType();
            //Frames.Instance.LoadTypeImage("C:/Users/Admin/Desktop/PNG/TYPE1", "4a");
            //Frames.Instance.LoadTypeImage("C:/Users/Admin/Desktop/PNG", "2a");
            //RenderManager.Render(Frames.Instance.GetType("1a"), "FALL_abc.png", list);

            //Bitmap r2 = RenderManager.FrameImage(Frames.Instance.GetType("1a"), result, "CUOI_abc.png");

            //RenderManager.FrameImage(Frames.Instance.GetType("1a"), result, "FALL_abc.png");
            //RenderManager.Render(Frames.Instance.GetType("1a"), "5x5 01.png", list);

            var list1 = ReadAndParseJsonFileWithSystemTextJson.UseFileOpenReadTextWithSystemTextJson("D:\\HOC\\Intern\\Workspace\\TestImage\\TestImage\\FrameType.json");
            var b = Frames.Instance(list1);
            b.LoadTypeImage("C:/Users/Admin/Desktop/PNG/TYPE1", "6a");
            b.LoadTypeImage("C:/Users/Admin/Desktop/PNG/TYPE1", "4a");
            //result = RenderManager.GhepBackground(b.GetType("6a"), result, "2x6 02.png");
            

            Console.ReadLine();
            var authPath = "C:/Users/Admin/Downloads/credentials.json";
            
            var filePath = "D:\\testmagik\\result.jpg";
            //DriveDownload.DriveDownloadFile(authPath, savePath, "TYPE1.zip");
            //var a = GoogleDrive.DriveUploadToFolder(authPath, filePath, "16sNxIo9knl4LSaONOcTmbsCk-MUOBwiz");
            //Console.ReadLine();
        }

    }
}
