﻿using System.Drawing;
using FrameLib.Frame;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System;
using System.Linq;
using System.Drawing.Imaging;
namespace FrameLib.Render
{
    public class RenderManager
    {

        private static Bitmap _result { get; set;}
        private static Bitmap _resultBg { get; set;}
        private static Bitmap _resultIcon { get; set;}
        public static Bitmap Render(FrameType frameType, string fileName, List<Image> imageInFrames)
        {
            var itemHeight = frameType.ImageInFrame.Height;
            var itemWidth = frameType.ImageInFrame.Width;
            var totalWidth = frameType.Width;
            var totalHeight = frameType.Height;

            Bitmap result0 = new Bitmap(totalWidth, totalHeight);

            Bitmap[] items = new Bitmap[imageInFrames.Count];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new Bitmap(imageInFrames[i]);
            }

            using (Graphics g = Graphics.FromImage(result0))
            {
                int index = 0;
                int marginLeft = frameType.ImageInFrame.MarginLeft;
                int marginTop = frameType.ImageInFrame.MarginTop;
                int marginRight = frameType.ImageInFrame.MarginRight;
                int marginBottom = frameType.ImageInFrame.MarginBottom;

                // Tính tổng lề của các cạnh
                int totalHorizontalMargin = marginLeft + marginRight;
                int totalVerticalMargin = marginTop + marginBottom;

                // Tính tổng chiều rộng và chiều cao của mỗi item kèm theo lề
                int itemWidthWithMargin = itemWidth + totalHorizontalMargin;
                int itemHeightWithMargin = itemHeight + totalVerticalMargin;

                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                // Vẽ từng item lên bitmap result với lề
                for (int row = 0; row < frameType.Row; row++) // hàng
                {
                    for (int col = 0; col < frameType.Column; col++) // item mỗi hàng
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
        public static Bitmap GhepHinh(FrameType frameType, List<Image> imageInFrames)
        {
            var itemHeight = frameType.ImageInFrame.Height;
            var itemWidth = frameType.ImageInFrame.Width;
            var totalWidth = frameType.Width;
            var totalHeight = frameType.Height;
            if (_result == null)
            {
                _result = new Bitmap(totalWidth, totalHeight, PixelFormat.Format32bppArgb);

            }

            Bitmap[] items = new Bitmap[imageInFrames.Count];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new Bitmap(imageInFrames[i]);
            }

            using (Graphics g = Graphics.FromImage(_result))
            {
                int index = 0;
                int marginLeft = frameType.ImageInFrame.MarginLeft;
                int marginTop = frameType.ImageInFrame.MarginTop;
                int marginRight = frameType.ImageInFrame.MarginRight;
                int marginBottom = frameType.ImageInFrame.MarginBottom;

                int totalHorizontalMargin = marginLeft + marginRight;
                int totalVerticalMargin = marginTop + marginBottom;

                int itemWidthWithMargin = itemWidth + totalHorizontalMargin;
                int itemHeightWithMargin = itemHeight + totalVerticalMargin;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.Transparent);
                for (int row = 0; row < frameType.Row; row++) // hàng
                {
                    for (int col = 0; col < frameType.Column; col++) // item mỗi hàng
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
            for (int i = 0; i < items.Length; i++)
            {
                items[i].Dispose();
            }   
            return _result;
        }
        
        public static Bitmap GhepBackground(FrameType frameType, Bitmap result0, string fileName)
        {
            Bitmap portrait = result0;
            var twoItems = frameType.BackgroundImages.Where(x => x.Item2.Equals(fileName)).FirstOrDefault();
            var image = twoItems.Item1;

            if (image == null) return null;

            Bitmap frame = new Bitmap(image);

            _resultBg = new Bitmap(frame.Width, frame.Height);

            using (Graphics g = Graphics.FromImage(_resultBg))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(frame, 0, 0, frame.Width, frame.Height);
                g.DrawImage(portrait, 0, 0, frame.Width, frame.Height);

                string currentTime = DateTime.Now.ToString("dd.MM.yyyy");
                Font font = new Font("Consolas", 30, FontStyle.Regular);
                Color customColor = Color.FromArgb(111, 98, 82);

                SolidBrush brush = new SolidBrush(customColor);
                g.DrawString(currentTime, font, brush, new PointF(719, 1741));

            }
            portrait.Dispose();
            frame.Dispose();
            return _resultBg;

           
            //result0.Dispose();
            //result.Dispose();
        }
        public static Bitmap RenderIcons(Bitmap bitmap, List<IconInImage> icons)
        {
            if (bitmap == null)
            {
                throw new ArgumentNullException(nameof(bitmap), "Bitmap cannot be null.");
            }

            _resultIcon = new Bitmap(bitmap.Width, bitmap.Height);

            using (Graphics g = Graphics.FromImage(_resultIcon))
            {
                g.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);

                foreach (IconInImage icon in icons)
                {
                    Bitmap transparentIcon = new Bitmap(icon.IconBitmap);
                    transparentIcon.MakeTransparent(Color.Black);

                    g.DrawImage(transparentIcon, new Rectangle(icon.Position, icon.Size));

                    transparentIcon.Dispose();
                }
            }

            return _resultIcon;
        }

        public static void Dispose()
        {
            if(_result != null)
            {
                _result.Dispose();
                _result = null;
            }
            if (_resultIcon != null)
            {
                _resultIcon.Dispose();
                _resultIcon = null;
            }
            if (_resultBg != null)
            {
                _resultBg.Dispose();
                _resultBg = null;
            }
        }
    }
}
