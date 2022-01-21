using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;

namespace DocSo_PC.DAL.VanThu
{
    class ImageUtil
    {
        private static readonly Bitmap noImage = new Bitmap(Properties.Resources.no_image);
        public static Bitmap FromByteArray(byte[] data)
        {
            Bitmap result;
            if (data == null || data.Length == 0)
                return noImage;
            result = new ImageConverter().ConvertFrom(data) as Bitmap;
            return result;
        }
        public static byte[] ToByteArray(Image data)
        {
            using (var stream = new MemoryStream())
            {
                data.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }
        public static void Rotate(Bitmap image, int angle)
        {
            RotateFlipType type;
            switch (angle)
            {
                case 90:
                    type = RotateFlipType.Rotate90FlipNone;
                    break;
                case 180:
                    type = RotateFlipType.Rotate180FlipNone;
                    break;
                case -90:
                case 270:
                    type = RotateFlipType.Rotate270FlipNone;
                    break;
                default:
                    type = RotateFlipType.RotateNoneFlipNone;
                    break;
            }
            image.RotateFlip(type);
        }
        public static void Rotate(Image image, int angle)
        {
            Rotate(image as Bitmap, angle);
        }
        private static Matrix transform = new Matrix();
        private static float m_dZoomscale = 1f;
        private const float s_dScrollValue = 0.2f;
        public static Matrix ZoomScroll(Point location, bool zoomIn)
        {
            float newScale = Math.Min(Math.Max(m_dZoomscale + (m_dZoomscale <= 1 ? 0.5f : 1f) * (zoomIn ? s_dScrollValue : -s_dScrollValue), 0.5f), 5f);
            if (newScale != m_dZoomscale)
            {
                float adjust = newScale / m_dZoomscale;
                m_dZoomscale = newScale;
                transform.Translate(-location.X, -location.Y, MatrixOrder.Append);
                transform.Scale(adjust, adjust, MatrixOrder.Append);
                transform.Translate(location.X, location.Y, MatrixOrder.Append);
                return transform;
            }
            return null;
        }
        public static Matrix DragScroll(int dX, int dY)
        {
            if (dX != 0 || dY != 0)
            {
                transform.Translate(dX, dY, MatrixOrder.Append);
                return transform;
            }
            return null;
        }
        public static void ScrollReset()
        {
            m_dZoomscale = 1f;
            transform.Reset();
        }
    }
}
