using Raywaster.Math;

namespace Raywaster.Render
{
    public class Camera
    {
        public Vector2 Position { get; private set; }
        public float Rotation { get; private set; }

        public Camera()
            : this(Vector2.Zero, 0.0f)
        {
        }

        public Camera(Vector2 position, float rotation)
        {
            this.Position = position;
            this.Rotation = rotation;
        }
    }
}
