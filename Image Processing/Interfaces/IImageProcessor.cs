
using System.Drawing;
using System;

namespace DVR.ImageProcessing
{
    public interface IImageProcessor
    {
        Guid id { get; set; }
        //Bitmap ProcessedBitmap(ICamera Cam);
        //void Process(ICamera Cam, Bitmap CapturedImage, Point FormLocation, Point MouseLocation);

        Bitmap ProcessedImage { get; }

        void Process(ImageSettingsModel imageSettings);
    }
}
