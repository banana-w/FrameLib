using TestImage.Utils;
using static TestImage.Constant.PhotoParemeters;

namespace TestImage.Frame
{
    public class Frames
    {
        private Frames()
        {
            FrameTypes = new();
        }
        public List<FrameType>? FrameTypes { get; }
        private static Frames instance = null;
        public static Frames Instance
        {
            get
            {
                instance ??= new();
                return instance;
            }
        }
        

        readonly FrameType type1 = new()
        {
            Name = "Frame 4 hinh",
            Width = (int)Type1.Width,
            Height = (int)Type1.Height,
            Colum = (int)Type1.Col,
            Row = (int)Type1.Row,
            Code = "4a",
            ImageInFrame = new()
                {
                    Width = (int)Type1.ImageWidth,
                    Height = (int)Type1.ImageHeight,
                    MarginBottom = (int)Type1.MarginBottom,
                    MarginLeft = (int)Type1.MarginLeft,
                    MarginRight = (int)Type1.MarginRight,
                    MarginTop = (int)Type1.MarginTop
                },


        };
        readonly FrameType type2 = new()
        {
            Name = "Frame 1 hinh",
            Width = (int)Type2.Width,
            Height = (int)Type2.Height,
            Colum = (int)Type2.Col,
            Row = (int)Type2.Row,
            Code = "1a",
            ImageInFrame = new()
                {
                    Width = (int) Type2.ImageWidth,
                    Height = (int) Type2.ImageHeight,
                    MarginBottom = (int)Type2.MarginBottom,
                    MarginLeft = (int)Type2.MarginLeft,
                    MarginRight = (int)Type2.MarginRight,
                    MarginTop = (int)Type2.MarginTop
                },


        };
        readonly FrameType type3 = new()
        {
            Name = "Frame 6 hinh",
            Width = (int)Type3.Width,
            Height = (int)Type3.Height,
            Colum = (int)Type3.Col,
            Row = (int)Type3.Row,
            Code = "6a",
            ImageInFrame = new()
                {
                    Width = (int) Type3.ImageWidth,
                    Height = (int) Type3.ImageHeight,
                    MarginBottom = (int)Type3.MarginBottom,
                    MarginLeft = (int)Type3.MarginLeft,
                    MarginRight = (int)Type3.MarginRight,
                    MarginTop = (int)Type3.MarginTop
                },


        };
        public void LoadListType()
        {
            FrameTypes.Add(type1);
            FrameTypes.Add(type2);
            FrameTypes.Add(type3);
        }
        public bool LoadTypeImage(string folderPath, string id)
        {
            FrameType type = FrameTypes.Where(x => x.Code.Equals(id)).FirstOrDefault();
            if (type != null)
            {
                type.BackgroundImages = Util.LoadImagesFromFolder(folderPath);
                return true;
            }
            else
            {
                return false;
            }
        }
        public FrameType GetType(string id)
        {
            return FrameTypes.Where(x => x.Code.Equals(id)).FirstOrDefault();
        }


    }
}
