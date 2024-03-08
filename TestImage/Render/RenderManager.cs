using System.Drawing;
using TestImage.Frame;

namespace TestImage.Render;

public class RenderManager
{
    public static Bitmap Render(FrameType frameType,string fileName, List<ImageInFrame> imageInFrames)
    {
        var itemHeight = frameType.ImageInFrames[0].Height;
        var itemWidth = frameType.ImageInFrames[0].Width;
        var totalWidth = frameType.Width;
        var totalHeight = frameType.Height;

        Bitmap result0 = new Bitmap(totalWidth, totalHeight);
        
        Bitmap[] items = new Bitmap[imageInFrames.Count];
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = new Bitmap(imageInFrames[i].Image);
        }

        using (Graphics g = Graphics.FromImage(result0))
        {
            int index = 0;
            int marginLeft = imageInFrames[0].MarginLeft;
            int marginTop = imageInFrames[0].MarginTop;
            int marginRight = imageInFrames[0].MarginRight;
            int marginBottom = imageInFrames[0].MarginBottom;

            // Tính tổng lề của các cạnh
            int totalHorizontalMargin = marginLeft + marginRight;
            int totalVerticalMargin = marginTop + marginBottom;

            // Tính tổng chiều rộng và chiều cao của mỗi item kèm theo lề
            int itemWidthWithMargin = itemWidth + totalHorizontalMargin;
            int itemHeightWithMargin = itemHeight + totalVerticalMargin;

            // Vẽ từng item lên bitmap result với lề
            for (int row = 0; row < frameType.Row; row++) // 3 hàng
            {
                for (int col = 0; col < frameType.Colum; col++) // 2 item mỗi hàng
                {
                    int x = marginLeft + col * itemWidthWithMargin;
                    int y = marginTop + row * itemHeightWithMargin;
                    if (index >= 2)
                    {
                        y -= marginTop;
                    }
                    g.DrawImage(items[index], x, y, itemWidth, itemHeight);
                    index++;
                }
            }
        }

        Bitmap portrait = result0;
        var twoItems = frameType.BackgroundImages.Where(x => x.Item2.Equals(fileName)).FirstOrDefault();
        var image = twoItems.Item1;
        if (image == null) return null;

        Bitmap frame = new Bitmap(image); 
        
        Bitmap result = new Bitmap(frame.Width, frame.Height);

        // Tạo graphics object để vẽ lên bitmap result
        using (Graphics g = Graphics.FromImage(result))
        {
            // Vẽ tấm hình chân dung lên bitmap result
            g.DrawImage(portrait, 0, 0, frame.Width, frame.Height);

            // Vẽ tấm hình frame lên bitmap result
            g.DrawImage(frame, 0, 0, frame.Width, frame.Height);
        }

        return result;
    }
    public static Bitmap CombineImage(FrameType frameType, List<ImageInFrame> imageInFrames)
    {
        var itemHeight = imageInFrames[0].Height;
        var itemWidth = imageInFrames[0].Width;
        var totalWidth = frameType.Width;
        var totalHeight = frameType.Height;

        Bitmap result0 = new Bitmap(totalWidth, totalHeight);

        Bitmap[] items = new Bitmap[imageInFrames.Count];
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = new Bitmap(imageInFrames[i].Image);
        }

        using (Graphics g = Graphics.FromImage(result0))
        {
            int index = 0;
            int marginLeft = imageInFrames[0].MarginLeft;
            int marginTop = imageInFrames[0].MarginTop;
            int marginRight = imageInFrames[0].MarginRight;
            int marginBottom = imageInFrames[0].MarginBottom;

            // Tính tổng lề của các cạnh
            int totalHorizontalMargin = marginLeft + marginRight;
            int totalVerticalMargin = marginTop + marginBottom;

            // Tính tổng chiều rộng và chiều cao của mỗi item kèm theo lề
            int itemWidthWithMargin = itemWidth + totalHorizontalMargin;
            int itemHeightWithMargin = itemHeight + totalVerticalMargin;

            // Vẽ từng item lên bitmap result với lề
            for (int row = 0; row < frameType.Row; row++) // 3 hàng
            {
                for (int col = 0; col < frameType.Colum; col++) // 2 item mỗi hàng
                {
                    int x = marginLeft + col * itemWidthWithMargin;
                    int y = marginTop + row * itemHeightWithMargin;
                    if (index >= 2)
                    {
                        y -= marginTop;
                    }
                    g.DrawImage(items[index], x, y, itemWidth, itemHeight);
                    index++;
                }
            }
        }
        return result0;
    }
    public static Bitmap FrameImage(FrameType frameType, Bitmap result0, string fileName)
    {
        Bitmap portrait = result0;
        var twoItems = frameType.BackgroundImages.Where(x => x.Item2.Equals(fileName)).FirstOrDefault();
        var image = twoItems.Item1;

        if (image == null) return null;

        Bitmap frame = new Bitmap(image);

        Bitmap result = new Bitmap(frame.Width, frame.Height);

        // Tạo graphics object để vẽ lên bitmap result
        using (Graphics g = Graphics.FromImage(result))
        {
            // Vẽ tấm hình chân dung lên bitmap result
            g.DrawImage(portrait, 0, 0, frame.Width, frame.Height);

            // Vẽ tấm hình frame lên bitmap result
            g.DrawImage(frame, 0, 0, frame.Width, frame.Height);
        }

        return result;
        // Giải phóng bộ nhớ
        //portrait.Dispose();
        //frame.Dispose();
        //result0.Dispose();
        //result.Dispose();
    }
}
