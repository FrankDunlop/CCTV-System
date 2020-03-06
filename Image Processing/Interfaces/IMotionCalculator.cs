using System.Drawing;

namespace DVR.ImageProcessing
{
    public interface IMotionCalculator
    {
        int Sensitivity { get; set; }
        int Count { get; set; }
        void XORCalc(byte a, byte b);
        unsafe void XOR();
        void CloneFrames(Bitmap Previous, Bitmap Current);
    }
}
