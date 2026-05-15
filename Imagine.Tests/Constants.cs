namespace Imagine.Tests;

internal static class Constants
{
	public const float Circumradius = 1F;
	public const float Narrow = 0.01F;
	public const string EmptyOutput = "Empty output";
	public const string LongDuration = "Takes a long time to run";
	public const string InputDirectory = "input";
	public const string OutputDirectory = "output";

	public static readonly float CubeOctahedronMidradius =
		Constants.Circumradius * float.Min(
			Scene.CubeMidradius / Scene.CubeCircumradius,
			Scene.OctahedronMidradius / Scene.OctahedronCircumradius);

	public static readonly float DodecahedronIcosahedronMidradius =
		Constants.Circumradius * float.Min(
			Scene.DodecahedronMidradius / Scene.DodecahedronCircumradius,
			Scene.IcosahedronMidradius / Scene.IcosahedronCircumradius);

	public static readonly float SphereAlmostTouchingCubeEdgeRadius =
		(Constants.Circumradius * Scene.CubeMidradius / Scene.CubeCircumradius) - Narrow;

	public static readonly float TetrahedronMidradius =
		Constants.Circumradius * Scene.TetrahedronMidradius / Scene.TetrahedronCircumradius;
}
