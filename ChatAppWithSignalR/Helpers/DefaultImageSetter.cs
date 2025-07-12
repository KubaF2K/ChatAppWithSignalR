using SkiaSharp;

namespace ChatAppWithSignalR.Helpers
{
    public static class DefaultImageSetter
    {
        private readonly static string ImgPath = "./Images/default.png";

        public static string GetDefaultPhoto()
        {
            using var inputStream = File.OpenRead(ImgPath);
            using var inputCodec = SKCodec.Create(inputStream);
            using var bitmap = new SKBitmap(inputCodec.Info);
            inputCodec.GetPixels(bitmap.Info, bitmap.GetPixels());
            using var image = SKImage.FromBitmap(bitmap);
            using var outputStream = new MemoryStream();
            image.Encode(SKEncodedImageFormat.Png, 100).SaveTo(outputStream);
            return Convert.ToBase64String(outputStream.ToArray());
        }
    }
}
