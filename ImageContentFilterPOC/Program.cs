namespace ImageContentFilterPOC
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Application.Run(new ImageFilterPage());
        }
    }
}