using System;
using System.Drawing;

namespace DVR.ImageProcessing
{
    public class BitmapProcessor : IImageProcessor
    {
        public Guid id { get; set; }
        public Bitmap ProcessedImage { get; set; }
        private int FontSize { get;  set; }
        private const string MotionIndicator = "M";

        public BitmapProcessor()
        {
            id = Guid.NewGuid();
            FontSize = 11;
        }

        public void Process(ImageSettingsModel imageSettings)
        {
            try
            {
                float verticalLocation;
                float horizontalLocation = 5;

                //if (Cam.CameraSettings[(int)Camera.Settings.LowRes])
                if (imageSettings.ImageCapture.Width == 320 && imageSettings.ImageCapture.Height == 240)
                {
                    ProcessedImage = imageSettings.ImageCapture;
                    FontSize = 11;
                    verticalLocation = imageSettings.TextBottom ? 220 : 2;
                }
                else
                {
                    ProcessedImage = imageSettings.ImageCapture;
                    FontSize = 20;
                    verticalLocation = imageSettings.TextBottom ? 440 : 2;
                }

                if (imageSettings.PrivacyEnabled)
                {
                    //draw a black shape on the location designated by privacy point
                    Color black = Color.FromArgb(0xff, 0x00, 0x00, 0x00);
                    Brush blackBrush = new SolidBrush(black);
                    Pen blackPen = new Pen(black);

                    //if privacy selection started draw a rectangle around the selected area
                    if (!imageSettings.PrivacySelected)
                    {
                        int valX = imageSettings.FormLocation.X + imageSettings.WindowLocationX + imageSettings.PrivacyStartX + imageSettings.WindowOffsetX;
                        int valY = imageSettings.FormLocation.Y + imageSettings.WindowLocationY + imageSettings.PrivacyStartY + imageSettings.WindowOffsetY;
                        int currentX = imageSettings.MouseLocation.X - valX;
                        int currentY = imageSettings.MouseLocation.Y - valY;
                        using (Graphics g = Graphics.FromImage(ProcessedImage))
                            g.DrawRectangle(blackPen, imageSettings.PrivacyStartX, imageSettings.PrivacyStartY, currentX, currentY);
                    }
                    //when the mouse button is released fill the area
                    else
                    {
                        using (Graphics g = Graphics.FromImage(ProcessedImage))
                            g.FillRectangle(blackBrush, imageSettings.PrivacyStartX, imageSettings.PrivacyStartY, imageSettings.PrivacyEndX, imageSettings.PrivacyEndY);
                    }
                }

                if (imageSettings.ShowTimeDate)
                {
                    //get the current time and draw it on the bitmap, this is put here so the text is not covered by the privacy object  
                    string timeStamp = string.Format("Cam{0} " + "{1:d}" + " " + "{1:T}" + "  {2}fps", imageSettings.CamNum, DateTime.Now, imageSettings.CalculatedFPS);

                    using (Graphics g = Graphics.FromImage(ProcessedImage))
                    {
                        if (imageSettings.MotionDetected)
                        {
                            g.DrawString(MotionIndicator, new Font("Arial", 15, FontStyle.Bold), Brushes.Blue, new PointF(295, 2));
                        }

                        if (imageSettings.BlackText)
                        {
                            g.DrawString(timeStamp, new Font("Arial", FontSize), Brushes.Black, new PointF(horizontalLocation, verticalLocation));
                        }
                        else
                        {
                            g.DrawString(timeStamp, new Font("Arial", FontSize), Brushes.White, new PointF(horizontalLocation, verticalLocation));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.Out.WriteLine("Image Processing Error: " + ex.Message);
#endif
            }
        }
    }
}
