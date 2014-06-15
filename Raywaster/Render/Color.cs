
namespace Raywaster.Render
{
    public struct Color
    {
        private byte[] rgb;

        public byte R
        {
            get { return this.rgb[0]; }
            set { this.rgb[0] = value; }
        }

        public byte G
        {
            get { return this.rgb[1]; }
            set { this.rgb[1] = value; }
        }

        public byte B
        {
            get { return this.rgb[2]; }
            set { this.rgb[2] = value; }
        }

        public Color(byte r, byte g, byte b)
        {
            this.rgb = new byte[3];

            this.R = r;
            this.G = g;
            this.B = b;
        }
    }
}
