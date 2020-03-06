using DVR.ImageProcessing;
using DVR.Logging;
using DVR.Media;
using Ninject.Modules;

namespace DVR.IoC
{
    public class ApplicationModule : NinjectModule
    {
        //IMotionCalculator motionCalc;

        public override void Load()
        {

            //Bind(typeof(ILogger)).To(typeof(TextLogger));
            //Bind(typeof(ILogger)).To(typeof(DBLogger));

            //Bind(typeof(IImageProcessor)).To(typeof(BitmapProcessor));
            //Bind(typeof(IMotionCalculator)).To(typeof(DefaultMotionCalculator));
            //Bind(typeof(IClipWriter)).To(typeof(AVIWriter));

            //Bind<IMotionCalculator>().To<DefaultMotionCalculator>().Named("MotionCalc1");
            //Bind<IMotionCalculator>().To<DefaultMotionCalculator>().Named("MotionCalc2");
        }

        //public void GetMotionCalculator([Named("MotionCalc1")] IMotionCalculator calc)
        //{
        //     motionCalc = calc;
        //}
    }
}
