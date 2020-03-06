using System.Drawing;

namespace DVR.Media
{
    public interface IClipWriter
    {
        int FrameRate { get; set; }

        void CreateFile(string fname, int width, int height);
        void CloseFile();
        void AddFrameToFile(Bitmap bmp);
    }
}
