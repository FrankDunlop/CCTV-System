using System;
using System.Drawing;
using System.Threading;
using DVR.Devices;
using DVR.ImageProcessing;

namespace DVR
{
    public class CameraFeedProcessor
    {
        private ICamera Cam { get; }
        private Point FormLocation { get; set; }
        private Point MouseLocation { get; set; }

        public CameraFeedProcessor(ICamera cam)
        {
            Cam = cam;
        }

        public void ProcessImage(CameraEventArgs args, Point formLocation, Point mouseLocation)
        {
            FormLocation = formLocation;
            MouseLocation = mouseLocation;
            CheckForMotion(args);
            ProcessBitmap(args);
        }

        private void CheckForMotion(CameraEventArgs args)
        {
            if (args.Cam.CameraSettings.MotionDetectionEnabled)
            {
                try
                {
                    if (Cam.PrevLastFrame == null)
                    {
                        Cam.PrevLastFrame = new Bitmap(320, 240);
                    }

                    if (Cam.LastFrame != null)
                    {
                        Bitmap previous = Cam.PrevLastFrame;
                        Bitmap current = Cam.LastFrame;
                        Cam.MotionCalculator.Sensitivity = Cam.CameraSettings.Sensitivity;

                        if (previous != null && current != null)
                        {
                            Cam.MotionCalculator.CloneFrames(previous, current);
                            Cam.MotionCalculator.XOR();

#if DEBUG
                            Console.Out.WriteLine($"Cam {Cam.CamNum} Motion Pixel Count: {Cam.MotionCalculator.Count}");
#endif

                            //compare the previous and the current frame, get the number of pixels different. 50000 is noise threshold
                            if (Cam.MotionCalculator.Count > 50000)
                            {
                                //if movement has been detected set the cameras flag one for on screen display and one for motion recording
                                Cam.MotionDetected = true;
                                Cam.MotionMonitor = true;

                                //if record on motion is enabled
                                if (Cam.CameraSettings.RecordOnMotionEnabled)
                                {
                                    //turn the write avi timer on and check if motion is detected every x number of seconds to keep recording
                                    Cam.MotionTimer.Enabled = true;
                                    //Motion1Timer.Enabled = true;
                                }
                            }
                            else
                            {
                                //if movement is not detected unset the cameras motion detect flag, this is only for on screen indicator
                                Cam.MotionDetected = false;
                            }

                            //reset the pixels different count
                            Cam.MotionCalculator.Count = 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Out.WriteLine("ProcessImage Error: " + ex.Message);
                }
            }
            else
            {
                args.Cam.MotionDetected = false;
                args.Cam.MotionMonitor = false;
            }
        }

        private void ProcessBitmap(ICameraEventArgs e)
        {
            e.Cam.FrameCount += 1;
            Thread editBitmap = new Thread(() =>
            {
                ImageSettingsModel imageModel = CreateImageModel(e.Cam, e.Frame, FormLocation, MouseLocation);
                e.Cam.ImageProcessor.Process(imageModel);
                if (e.Cam.Connected)
                {
                    e.Cam.CameraScreen.Image = e.Cam.ImageProcessor.ProcessedImage;
                    e.Cam.PrevLastFrame = e.Cam.LastFrame;
                    e.Cam.LastFrame = e.Cam.ImageProcessor.ProcessedImage;
                }
            });
            editBitmap.Start();
            editBitmap.Join(1000);
        }

        private ImageSettingsModel CreateImageModel(ICamera camera, Bitmap imageCapture, Point formLocation, Point mouseLocation)
        {
            return new ImageSettingsModel
            {
                CamNum = camera.CamNum,
                TextBottom = camera.CameraSettings.TextBottom,
                PrivacyEnabled = camera.CameraSettings.PrivacyEnabled,
                PrivacySelected = camera.CameraSettings.PrivacySelected,
                ShowTimeDate = camera.CameraSettings.ShowTimeDate,
                BlackText = camera.CameraSettings.BlackText,
                WindowLocationX = camera.WindowLocation.X,
                WindowLocationY = camera.WindowLocation.Y,
                PrivacyStartX = camera.PrivacyStart.X,
                PrivacyStartY = camera.PrivacyStart.Y,
                PrivacyEndX = camera.PrivacyEnd.X,
                PrivacyEndY = camera.PrivacyEnd.Y,
                WindowOffsetX = camera.WindowOffset.X,
                WindowOffsetY = camera.WindowOffset.Y,
                CalculatedFPS = camera.CalculatedFPS,
                MotionDetected = camera.MotionDetected,
                ImageCapture = imageCapture,
                FormLocation = formLocation,
                MouseLocation = mouseLocation
            };
        }
    }
}
