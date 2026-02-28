using Assets.Scripts.Enums;

namespace Assets.Scripts.Map
{
	public static class MapGenerator
	{
		public static MapData CreateSmallMap() => new MapData(MapSize.Small);
		public static MapData CreateMediumMap() => new MapData(MapSize.Medium);
		public static MapData CreateLargeMap() => new MapData(MapSize.Large);
	}
}