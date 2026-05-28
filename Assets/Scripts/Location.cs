namespace Assets.Scripts
{
    public class Location
    {
        // This represents grid position
        public float GridX { get; }
        public float GridY { get; }

        // This represents world postion
        public float WorldX { get; }
        public float WorldY { get; }
        public float WorldZ = 0;

        public Location(float x, float y, float roomSpacing)
        {
            GridX = x;
            GridY = y;
            WorldX = GridX * roomSpacing;
            WorldY = GridY * roomSpacing;
        }

        public void UpdatePosition()
        {

        }

    }
}
