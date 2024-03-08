using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestImage.Constant;
using TestImage.Render;
using TestImage.Utils;
using static TestImage.Constant.PhotoParemeters;

namespace TestImage.Frame
{
    public class Frames
    {
        public List<FrameType>? FrameTypes { get; }
        private static readonly Frames instance = new();
        public static Frames Instance = instance;
        private Frames()
        {
            FrameTypes = new();
        }

        readonly FrameType type1 = new()
        {   
            Name = "Frame 4 hinh",
            Width = (int)Type1.Width,
            Height = (int)Type1.Height,
            Colum = (int)Type1.Col,
            Row = (int)Type1.Row,
            Code = "1a",
            ImageInFrames = new List<ImageInFrame>()
            {
                new()
                {
                    Width = (int)Type1.ImageWidth,
                    Height = (int)Type1.ImageHeight,
                },
            },
            Theme = FrameTheme.FALL
        };
        readonly FrameType type2 = new()
        {
            Width = (int)Type2.Width,
            Height = (int)Type2.Height,
            Colum = (int)Type2.Col,
            Row = (int)Type2.Row,
            Code = "2a",
            ImageInFrames = new List<ImageInFrame>()
            {
                new()
                {
                    Width = (int) Type2.ImageWidth,
                    Height = (int) Type2.ImageHeight,

                },
            },
            Theme = FrameTheme.FALL
        };
        public void LoadListType()
        {
            FrameTypes.Add(type1);
            FrameTypes.Add(type2);
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
