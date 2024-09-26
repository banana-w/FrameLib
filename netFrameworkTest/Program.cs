using FrameLib.Drive;
using FrameLib.Frame;
using FrameLib.Render;
using FrameLib.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace netFrameworkTest
{
    internal class Program
    {
        public static string HashPassword(string rawPassword)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawPassword));
                return Convert.ToBase64String(bytes);
            }
        }
        static void Main(string[] args)
        {
            var list = new List<Image>();


            Image image = Image.FromFile(@"C:\Users\Admin\Desktop\Testing\abc.png");
            Image image2 = Image.FromFile(@"C:\Users\Admin\Desktop\Testing\abc.png");
            Image image3 = Image.FromFile(@"C:\Users\Admin\Desktop\Testing\abc.png");
            Image image4 = Image.FromFile(@"C:\Users\Admin\Desktop\Testing\abc.png");
            Image image5 = Image.FromFile(@"C:\Users\Admin\Desktop\Testing\abc.png");
            Image image6 = Image.FromFile(@"C:\Users\Admin\Desktop\Testing\abc.png");
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

            var list1 = ReadAndParseJsonFileWithSystemTextJson.UseFileOpenReadTextWithSystemTextJson("D:\\HOC IN UNI\\Intern\\Workspace\\TestImage\\TestImage\\FrameType.json");
            var b = Frames.Instance(list1);
            b.LoadTypeImage(@"C:\Users\Admin\Desktop\Testing", "4a");



            var ghephinh = RenderManager.GhepHinh(b.GetType("4a"), list);
            ghephinh.Save(@"C:\Users\Admin\Desktop\Testing\ghep.jpg");

            var result = RenderManager.GhepBackground(b.GetType("4a"), ghephinh, "bg.jpg");
            result.Save(@"C:\Users\Admin\Desktop\Testing\result5.jpg");
            RenderManager.Dispose();


            //result = rendermanager.ghepbackground(b.gettype("6a"), result, "2x6 02.png");

            var a = HashPassword("khoa");
            Console.WriteLine(a);
            Console.ReadLine();
            var authPath = "C:/Users/Admin/Downloads/credentials.json";
            
            var filePath = "D:\\testmagik\\result.jpg";
            //DriveDownload.DriveDownloadFile(authPath, savePath, "TYPE1.zip");
            //var a = GoogleDrive.DriveUploadToFolder(authPath, filePath, "16sNxIo9knl4LSaONOcTmbsCk-MUOBwiz");
            //Console.ReadLine();
        }

    }
}
