using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace DVR.ImageProcessing
{
    public class DefaultMotionCalculator : IMotionCalculator
	{
        public Bitmap Prev { get; set; }
        public Bitmap Current { get; set; }
        public int Sensitivity { get; set; }
        public int Count { get; set; }
        BitmapData Data1 { get; set; }
        BitmapData Data2 { get; set; }

        public DefaultMotionCalculator()
	    {
            Count = 0;
	    }
        
        public unsafe void XOR()
        {
            try
            {
                if ((Current.Width == Prev.Width) && (Current.Height == Prev.Height))
                {
                    int avg = 0;
                    Data1 = Prev.LockBits(new Rectangle(0, 0, Prev.Width, Prev.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                    Data2 = Current.LockBits(new Rectangle(0, 0, Current.Width, Current.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                    //BitmapData data3 = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                    int offset = Data2.Stride - Data2.Width * 4;

                    byte* ptr1 = (byte*)Data1.Scan0;
                    byte* ptr2 = (byte*)Data2.Scan0;
                    //byte* ptr3 = (byte*)data3.Scan0;

                    for (int y = 0; y < Current.Height; y++)
                    {
                        for (int x = 0; x < Current.Width * 4; x++)
                        {
                            //http://www.codeproject.com/KB/graphics/quickgrayscale.aspx
                            //convert pixels to greyscale by averaging the colour components 
                            //Array index 0 is blue, index 1 is green, index 2 is red
                            avg = (ptr1[0] + ptr1[1] + ptr1[2]) / 3;
                            ptr1[0] = (byte)avg;
                            ptr1[1] = (byte)avg;
                            ptr1[2] = (byte)avg;

                            avg = (ptr2[0] + ptr2[1] + ptr2[2]) / 3;
                            ptr2[0] = (byte)avg;
                            ptr2[1] = (byte)avg;
                            ptr2[2] = (byte)avg;

                            //ptr3[0] = (byte)XORCalc(ptr1[0], ptr2[0]);
                            XORCalc(ptr1[0], ptr2[0]);
                            ptr1++;
                            ptr2++;
                            //ptr3++;
                        }

                        ptr1 += offset;
                        ptr2 += offset;
                        //ptr3 += offset;
                    }

                    Prev.UnlockBits(Data1);
                    Current.UnlockBits(Data2);
                    //result.UnlockBits(data3);
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.Out.WriteLine("XOR Image Processing Error: " + ex.Message);
#endif
                Prev.UnlockBits(Data1);
                Current.UnlockBits(Data2);
            }
        }

		public void XORCalc(byte a , byte b)
		{
			byte A = (byte)(255 - a);
			byte B = (byte)(255 - b);

            if (((a & B) | (A & b)) >= Sensitivity)
            {
                Count += 1;
            }
		}

        public void CloneFrames(Bitmap previous, Bitmap current)
		{
		    Prev = (Bitmap)previous.Clone();
		    Current = (Bitmap)current.Clone();
		}
    }
}
