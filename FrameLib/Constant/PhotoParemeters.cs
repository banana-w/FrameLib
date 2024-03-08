using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestImage.Constant;

public class PhotoParemeters
{
    public enum AspectRatioEnum
    {
        R4x3,//Rate 4 multi 3
        R3x2,

    }
    public enum FrameTheme
    {
        FALL, CHRISTMAS
    }
    public enum Type1
    {
        Width = 1200, Height = 1800, Row = 2, Col = 2,
        ImageWidth = 534, ImageHeight = 532,
    }
    public enum Type2
    {
        Width = 1200, Height = 1800, Row = 3, Col = 2,
        ImageWidth = 546, ImageHeight = 364,
    }

}
