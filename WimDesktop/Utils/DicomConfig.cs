using FellowOakDicom;
using FellowOakDicom.Imaging;

namespace WimDesktop
{
    public static class DicomConfig
    {
        private static bool initialized = false;

        public static void EnsureConfigured()
        {
            if (initialized) return;

            new DicomSetupBuilder()
                .RegisterServices(s => s
                    .AddFellowOakDicom()
                    .AddImageManager<WinFormsImageManager>() // backend GDI+ para Bitmap
                    .AddTranscoderManager<FellowOakDicom.Imaging.NativeCodec.NativeTranscoderManager>()) // opcional, mas bom para JPEG/JPEG2000
                .Build();

            initialized = true;
        }
    }
}
