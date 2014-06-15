using System.Timers;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Raywaster.Client.WPF
{
    public partial class MainWindow : Window
    {
        private Renderer renderer;
        private WriteableBitmap renderTargetSource;
        private Timer updateTimer;

        public MainWindow()
        {
            InitializeComponent();

            renderer = new Renderer(320, 240);
            renderTargetSource = new WriteableBitmap(320, 240, 96, 96, PixelFormats.Rgb24, null);
            this.RenderTarget.Source = renderTargetSource;

            this.updateTimer = new Timer(1.0 / 30.0);
            this.updateTimer.Elapsed += updateTimer_Elapsed;
            this.updateTimer.Start();
        }

        void updateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
                {
                    this.renderer.Update();
                    this.renderer.Draw();

                    this.renderTargetSource.Lock();
                    this.renderTargetSource.WritePixels(new Int32Rect(0, 0, 320, 240), renderer.Framebuffer, 320 * 3, 0);
                    this.renderTargetSource.Unlock();
                });
        }
    }
}
