using Raywaster.Render;

namespace Raywaster
{
    public class Renderer
    {
        public byte[] Framebuffer { get; private set; }
        public int ViewportWidth { get; private set; }
        public int ViewportHeight { get; private set; }

        public Color FloorColor { get; set; }
        public Color CeilingColor { get; set; }

        public Renderer(int viewportWidth, int viewportHeight)
        {
            this.ViewportWidth = viewportWidth;
            this.ViewportHeight = viewportHeight;

            this.Framebuffer = new byte[this.ViewportWidth * this.ViewportHeight * 3];

            this.FloorColor = new Color(112, 112, 112);
            this.CeilingColor = new Color(56, 56, 56);
        }

        public void Update()
        {
        }

        public void Draw()
        {
            #region Floor and ceiling
            for (int i = 0; i < this.ViewportWidth; i++)
            {
                for (int j = 0; j < this.ViewportHeight; j++)
                {
                    Color pixelColor;

                    if (j < this.ViewportHeight / 2)
                    {
                        pixelColor = this.CeilingColor;
                    }
                    else
                    {
                        pixelColor = this.FloorColor;
                    }

                    this.PutPixel(i, j, pixelColor);
                }
            }
            #endregion
        }

        private void PutPixel(int x, int y, Color color)
        {
            int pixelOffset = (y * this.ViewportWidth * 3) + (x * 3);
            this.Framebuffer[pixelOffset] = color.R;
            this.Framebuffer[pixelOffset + 1] = color.G;
            this.Framebuffer[pixelOffset + 2] = color.B;
        }
    }
}
