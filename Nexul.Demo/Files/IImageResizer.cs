namespace Nexul.Demo.Files
{
    public interface IImageResizer
    {
        byte[] Resize(byte[] imgToResize, int width, int height);

        void CreateFileImageAlternates(File item);
    }
}
