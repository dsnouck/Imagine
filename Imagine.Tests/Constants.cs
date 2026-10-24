namespace Imagine.Tests;

internal static class Constants
{
	public const float Circumradius = 1F;
	public const float Narrow = 0.01F;
	public const string InputDirectory = "input";
	public const string OutputDirectory = "output";

	public static readonly float CubeOctahedronMidradius =
		Circumradius * float.Min(
			Scene.CubeMidradius / Scene.CubeCircumradius,
			Scene.OctahedronMidradius / Scene.OctahedronCircumradius);

	public static readonly float DodecahedronIcosahedronMidradius =
		Circumradius * float.Min(
			Scene.DodecahedronMidradius / Scene.DodecahedronCircumradius,
			Scene.IcosahedronMidradius / Scene.IcosahedronCircumradius);

	public static readonly float SphereAlmostTouchingCubeEdgeRadius =
		(Circumradius * Scene.CubeMidradius / Scene.CubeCircumradius) - Narrow;

	public static readonly float TetrahedronMidradius =
		Circumradius * Scene.TetrahedronMidradius / Scene.TetrahedronCircumradius;
}
