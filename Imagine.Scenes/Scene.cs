namespace Imagine.Scenes;

public static class Scene
{
	public static readonly float Phi = (1F + float.Sqrt(5F)) / 2F;
	public static readonly float Xi = float.Sqrt(3F - Phi);
	public static readonly float CubeCircumradius = float.Sqrt(3F);
	public static readonly float CubeInradius = 1F;
	public static readonly float CubeMidradius = float.Sqrt(2F);
	public static readonly float DodecahedronCircumradius = float.Sqrt(3F) * Phi;
	public static readonly float DodecahedronInradius = Phi * Phi / Xi;
	public static readonly float DodecahedronMidradius = Phi * Phi;
	public static readonly float IcosahedronCircumradius = Xi * Phi;
	public static readonly float IcosahedronInradius = Phi * Phi / float.Sqrt(3F);
	public static readonly float IcosahedronMidradius = Phi;
	public static readonly float OctahedronCircumradius = float.Sqrt(2F);
	public static readonly float OctahedronInradius = float.Sqrt(2F / 3F);
	public static readonly float OctahedronMidradius = 1F;
	public static readonly float TetrahedronCircumradius = float.Sqrt(3F / 2F);
	public static readonly float TetrahedronInradius = 1F / float.Sqrt(6F);
	public static readonly float TetrahedronMidradius = 1F / float.Sqrt(2F);

	private static readonly ColorHsv ConeColor = new(11F / 12F, 1F, 1F);
	private static readonly ColorHsv CubeFaceDownColor = new(2F / 12F, 1F, 1F);
	private static readonly ColorHsv CubeVertexDownColor = new(4F / 12F, 1F, 1F);
	private static readonly ColorHsv CylinderColor = new(10F / 12F, 1F, 1F);
	private static readonly ColorHsv DodecahedronFaceDownColor = new(6F / 12F, 1F, 1F);
	private static readonly ColorHsv DodecahedronVertexDownColor = new(8F / 12F, 1F, 1F);
	private static readonly ColorHsv IcosahedronFaceDownColor = new(9F / 12F, 1F, 1F);
	private static readonly ColorHsv IcosahedronVertexDownColor = new(7F / 12F, 1F, 1F);
	private static readonly ColorHsv OctahedronFaceDownColor = new(5F / 12F, 1F, 1F);
	private static readonly ColorHsv OctahedronVertexDownColor = new(3F / 12F, 1F, 1F);
	private static readonly ColorHsv TetrahedronFaceDownColor = new(0F / 12F, 1F, 1F);
	private static readonly ColorHsv TetrahedronVertexDownColor = new(1F / 12F, 1F, 1F);

	public static IScene Cone(Vector3 axis, float angle) =>
		new Cone(axis, angle)
			.Painted(ConeColor);

	public static IScene CubeFaceDownWithCircumradius(float circumradius) =>
		CubeFaceDownWithInradius(circumradius * CubeInradius / CubeCircumradius);

	public static IScene CubeFaceDownWithInradius(float inradius)
	{
		var theta0 = 0F;
		var theta1 = float.Pi / 2F;
		var theta2 = float.Pi;

		var deltaPhi = float.Pi / 2F;

		return Polyhedron(
			new Vector3Spherical(inradius, 0F, theta0),
			new Vector3Spherical(inradius, 0F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 1F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 2F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 3F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 0F, theta2))
			.Painted(CubeFaceDownColor);
	}

	public static IScene CubeFaceDownWithMidradius(float midradius) =>
		CubeFaceDownWithInradius(midradius * CubeInradius / CubeMidradius);

	public static IScene CubeVertexDownWithCircumradius(float circumradius) =>
		CubeVertexDownWithInradius(circumradius * CubeInradius / CubeCircumradius);

	public static IScene CubeVertexDownWithInradius(float inradius)
	{
		var theta0 = float.Acos(1F / float.Sqrt(3F));
		var theta1 = float.Pi - theta0;

		var deltaPhi = float.Pi / 3F;

		return Polyhedron(
			new Vector3Spherical(inradius, 0F * deltaPhi, theta0),
			new Vector3Spherical(inradius, 2F * deltaPhi, theta0),
			new Vector3Spherical(inradius, 4F * deltaPhi, theta0),
			new Vector3Spherical(inradius, 1F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 3F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 5F * deltaPhi, theta1))
			.Painted(CubeVertexDownColor);
	}

	public static IScene CubeVertexDownWithMidradius(float midradius) =>
		CubeVertexDownWithInradius(midradius * CubeInradius / CubeMidradius);

	public static IScene Cylinder(Vector3 axis, float radius) =>
		new Cylinder(axis, radius)
			.Painted(CylinderColor);

	public static IScene DodecahedronFaceDownWithCircumradius(float circumradius) =>
		DodecahedronFaceDownWithInradius(circumradius * DodecahedronInradius / DodecahedronCircumradius);

	public static IScene DodecahedronFaceDownWithInradius(float inradius)
	{
		var theta0 = 0F;
		var theta1 = float.Acos(1F / float.Sqrt(5F));
		var theta2 = float.Pi - theta1;
		var theta3 = float.Pi;

		var deltaPhi = float.Pi / 5F;

		return Polyhedron(
			new Vector3Spherical(inradius, 0F, theta0),
			new Vector3Spherical(inradius, 1F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 3F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 5F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 7F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 9F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 0F * deltaPhi, theta2),
			new Vector3Spherical(inradius, 2F * deltaPhi, theta2),
			new Vector3Spherical(inradius, 4F * deltaPhi, theta2),
			new Vector3Spherical(inradius, 6F * deltaPhi, theta2),
			new Vector3Spherical(inradius, 8F * deltaPhi, theta2),
			new Vector3Spherical(inradius, 0F, theta3))
			.Painted(DodecahedronFaceDownColor);
	}

	public static IScene DodecahedronFaceDownWithMidradius(float midradius) =>
		DodecahedronFaceDownWithInradius(midradius * DodecahedronInradius / DodecahedronMidradius);

	public static IScene DodecahedronVertexDownWithCircumradius(float circumradius) =>
		DodecahedronVertexDownWithInradius(circumradius * DodecahedronInradius / DodecahedronCircumradius);

	public static IScene DodecahedronVertexDownWithInradius(float inradius)
	{
		var theta0 = float.Acos(float.Sqrt((5F + (2F * float.Sqrt(5F))) / 15F));
		var theta1 = float.Acos(float.Sqrt((5F - (2F * float.Sqrt(5F))) / 15F));
		var theta2 = float.Pi - theta1;
		var theta3 = float.Pi - theta0;

		var deltaPhi = float.Pi / 3F;

		return Polyhedron(
			new Vector3Spherical(inradius, 0F * deltaPhi, theta0),
			new Vector3Spherical(inradius, 2F * deltaPhi, theta0),
			new Vector3Spherical(inradius, 4F * deltaPhi, theta0),
			new Vector3Spherical(inradius, 1F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 3F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 5F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 0F * deltaPhi, theta2),
			new Vector3Spherical(inradius, 2F * deltaPhi, theta2),
			new Vector3Spherical(inradius, 4F * deltaPhi, theta2),
			new Vector3Spherical(inradius, 1F * deltaPhi, theta3),
			new Vector3Spherical(inradius, 3F * deltaPhi, theta3),
			new Vector3Spherical(inradius, 5F * deltaPhi, theta3))
			.Painted(DodecahedronVertexDownColor);
	}

	public static IScene DodecahedronVertexDownWithMidradius(float midradius) =>
		DodecahedronVertexDownWithInradius(midradius * DodecahedronInradius / DodecahedronMidradius);

	public static IScene Empty() =>
		new Empty();

	public static IScene Full() =>
		new Full();

	public static IScene IcosahedronFaceDownWithCircumradius(float circumradius) =>
		IcosahedronFaceDownWithInradius(circumradius * IcosahedronInradius / IcosahedronCircumradius);

	public static IScene IcosahedronFaceDownWithInradius(float inradius)
	{
		var theta0 = 0F;
		var theta1 = float.Acos(float.Sqrt(5F) / 3F);
		var theta2 = float.Acos(1F / 3F);
		var theta3 = float.Pi - theta2;
		var theta4 = float.Pi - theta1;
		var theta5 = float.Pi;

		var deltaPhi = float.Pi / 3F;
		var phiOffset = float.Acos(float.Sqrt(7F + (3F * float.Sqrt(5F))) / 4F);

		return Polyhedron(
			new Vector3Spherical(inradius, 0F, theta0),
			new Vector3Spherical(inradius, 1F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 3F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 5F * deltaPhi, theta1),
			new Vector3Spherical(inradius, (0F * deltaPhi) - phiOffset, theta2),
			new Vector3Spherical(inradius, (0F * deltaPhi) + phiOffset, theta2),
			new Vector3Spherical(inradius, (2F * deltaPhi) - phiOffset, theta2),
			new Vector3Spherical(inradius, (2F * deltaPhi) + phiOffset, theta2),
			new Vector3Spherical(inradius, (4F * deltaPhi) - phiOffset, theta2),
			new Vector3Spherical(inradius, (4F * deltaPhi) + phiOffset, theta2),
			new Vector3Spherical(inradius, (1F * deltaPhi) - phiOffset, theta3),
			new Vector3Spherical(inradius, (1F * deltaPhi) + phiOffset, theta3),
			new Vector3Spherical(inradius, (3F * deltaPhi) - phiOffset, theta3),
			new Vector3Spherical(inradius, (3F * deltaPhi) + phiOffset, theta3),
			new Vector3Spherical(inradius, (5F * deltaPhi) - phiOffset, theta3),
			new Vector3Spherical(inradius, (5F * deltaPhi) + phiOffset, theta3),
			new Vector3Spherical(inradius, 0F * deltaPhi, theta4),
			new Vector3Spherical(inradius, 2F * deltaPhi, theta4),
			new Vector3Spherical(inradius, 4F * deltaPhi, theta4),
			new Vector3Spherical(inradius, 0F, theta5))
			.Painted(IcosahedronFaceDownColor);
	}

	public static IScene IcosahedronFaceDownWithMidradius(float midradius) =>
		IcosahedronFaceDownWithInradius(midradius * IcosahedronInradius / IcosahedronMidradius);

	public static IScene IcosahedronVertexDownWithCircumradius(float circumradius) =>
		IcosahedronVertexDownWithInradius(circumradius * IcosahedronInradius / IcosahedronCircumradius);

	public static IScene IcosahedronVertexDownWithInradius(float inradius)
	{
		var theta0 = float.Acos(float.Sqrt((5F + (2F * float.Sqrt(5F))) / 15F));
		var theta1 = float.Acos(float.Sqrt((5F - (2F * float.Sqrt(5F))) / 15F));
		var theta2 = float.Pi - theta1;
		var theta3 = float.Pi - theta0;

		var deltaPhi = float.Pi / 5F;

		return Polyhedron(
			new Vector3Spherical(inradius, 0F * deltaPhi, theta0),
			new Vector3Spherical(inradius, 2F * deltaPhi, theta0),
			new Vector3Spherical(inradius, 4F * deltaPhi, theta0),
			new Vector3Spherical(inradius, 6F * deltaPhi, theta0),
			new Vector3Spherical(inradius, 8F * deltaPhi, theta0),
			new Vector3Spherical(inradius, 0F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 2F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 4F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 6F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 8F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 1F * deltaPhi, theta2),
			new Vector3Spherical(inradius, 3F * deltaPhi, theta2),
			new Vector3Spherical(inradius, 5F * deltaPhi, theta2),
			new Vector3Spherical(inradius, 7F * deltaPhi, theta2),
			new Vector3Spherical(inradius, 9F * deltaPhi, theta2),
			new Vector3Spherical(inradius, 1F * deltaPhi, theta3),
			new Vector3Spherical(inradius, 3F * deltaPhi, theta3),
			new Vector3Spherical(inradius, 5F * deltaPhi, theta3),
			new Vector3Spherical(inradius, 7F * deltaPhi, theta3),
			new Vector3Spherical(inradius, 9F * deltaPhi, theta3))
			.Painted(IcosahedronVertexDownColor);
	}

	public static IScene IcosahedronVertexDownWithMidradius(float midradius) =>
		IcosahedronVertexDownWithInradius(midradius * IcosahedronInradius / IcosahedronMidradius);

	public static IScene Intersection(params List<IScene> scenes) =>
		scenes.Aggregate(Full(), IntersectedWith);

	public static IScene OctahedronFaceDownWithCircumradius(float circumradius) =>
		OctahedronFaceDownWithInradius(circumradius * OctahedronInradius / OctahedronCircumradius);

	public static IScene OctahedronFaceDownWithInradius(float inradius)
	{
		var theta0 = 0F;
		var theta1 = float.Acos(1F / 3F);
		var theta2 = float.Pi - theta1;
		var theta3 = float.Pi;

		var deltaPhi = float.Pi / 3F;

		return Polyhedron(
			new Vector3Spherical(inradius, 0F, theta0),
			new Vector3Spherical(inradius, 1F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 3F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 5F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 0F * deltaPhi, theta2),
			new Vector3Spherical(inradius, 2F * deltaPhi, theta2),
			new Vector3Spherical(inradius, 4F * deltaPhi, theta2),
			new Vector3Spherical(inradius, 0F, theta3))
			.Painted(OctahedronFaceDownColor);
	}

	public static IScene OctahedronFaceDownWithMidradius(float midradius) =>
		OctahedronFaceDownWithInradius(midradius * OctahedronInradius / OctahedronMidradius);

	public static IScene OctahedronVertexDownWithCircumradius(float circumradius) =>
		OctahedronVertexDownWithInradius(circumradius * OctahedronInradius / OctahedronCircumradius);

	public static IScene OctahedronVertexDownWithInradius(float inradius)
	{
		var theta0 = float.Acos(1F / float.Sqrt(3F));
		var theta1 = float.Pi - theta0;

		var deltaPhi = float.Pi / 4F;

		return Polyhedron(
			new Vector3Spherical(inradius, 1F * deltaPhi, theta0),
			new Vector3Spherical(inradius, 3F * deltaPhi, theta0),
			new Vector3Spherical(inradius, 5F * deltaPhi, theta0),
			new Vector3Spherical(inradius, 7F * deltaPhi, theta0),
			new Vector3Spherical(inradius, 1F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 3F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 5F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 7F * deltaPhi, theta1))
			.Painted(OctahedronVertexDownColor);
	}

	public static IScene OctahedronVertexDownWithMidradius(float midradius) =>
		OctahedronVertexDownWithInradius(midradius * OctahedronInradius / OctahedronMidradius);

	public static IScene Plane(Vector3 normal) =>
		new Plane(normal);

	public static IScene PlaneThroughOrigin(Vector3 normal) =>
		Plane(normal).Translated(-normal);

	public static IScene Polyhedron(params List<Vector3> faces) =>
		Intersection([.. faces.Select(Plane)]);

	public static IScene Polyhedron(params List<Vector3Spherical> faces) =>
		Polyhedron([.. faces.Select(face => (Vector3)face)]);

	public static IScene SphereWithRadius(float radius) =>
		new Sphere(radius);

	public static IScene TetrahedronFaceDownWithCircumradius(float circumradius) =>
		TetrahedronFaceDownWithInradius(circumradius * TetrahedronInradius / TetrahedronCircumradius);

	public static IScene TetrahedronFaceDownWithInradius(float inradius)
	{
		var theta0 = float.Acos(1F / 3F);
		var theta1 = float.Pi;

		var deltaPhi = float.Pi / 3F;

		return Polyhedron(
			new Vector3Spherical(inradius, 0F * deltaPhi, theta0),
			new Vector3Spherical(inradius, 2F * deltaPhi, theta0),
			new Vector3Spherical(inradius, 4F * deltaPhi, theta0),
			new Vector3Spherical(inradius, 0F, theta1))
			.Painted(TetrahedronFaceDownColor);
	}

	public static IScene TetrahedronFaceDownWithMidradius(float midradius) =>
		TetrahedronFaceDownWithInradius(midradius * TetrahedronInradius / TetrahedronMidradius);

	public static IScene TetrahedronVertexDownWithCircumradius(float circumradius) =>
		TetrahedronVertexDownWithInradius(circumradius * TetrahedronInradius / TetrahedronCircumradius);

	public static IScene TetrahedronVertexDownWithInradius(float inradius)
	{
		var theta0 = 0F;
		var theta1 = float.Pi - float.Acos(1F / 3F);

		var deltaPhi = float.Pi / 3F;

		return Polyhedron(
			new Vector3Spherical(inradius, 0F, theta0),
			new Vector3Spherical(inradius, 1F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 3F * deltaPhi, theta1),
			new Vector3Spherical(inradius, 5F * deltaPhi, theta1))
			.Painted(TetrahedronVertexDownColor);
	}

	public static IScene TetrahedronVertexDownWithMidradius(float midradius) =>
		TetrahedronVertexDownWithInradius(midradius * TetrahedronInradius / TetrahedronMidradius);

	public static IScene Union(params List<IScene> scenes) =>
		scenes.Aggregate(Empty(), UnitedWith);

	extension(IScene source)
	{
		public IScene IntersectedWith(IScene scene) =>
			new Intersection(source, scene);

		public IScene Inverted() =>
			new Inverted(source);

		public IScene Painted(Func<Vector3, Color> colors) =>
			new Painted(source, colors);

		public IScene Painted(Func<Vector3Spherical, Color> colors) =>
			new Painted(source, colors);

		public IScene Painted(Color color) =>
			new Painted(source, color);

		public IScene Painted(Func<Vector3, ColorHsv> colors) =>
			new Painted(source, colors);

		public IScene Painted(Func<Vector3Spherical, ColorHsv> colors) =>
			new Painted(source, colors);

		public IScene Painted(ColorHsv color) =>
			new Painted(source, color);

		public IScene Rotated(float angle) =>
			source.Rotated(Vector3.UnitZ, angle);

		public IScene Rotated(Vector3 axis, float angle) =>
			source.Transformed(Matrix4.Rotation(axis, angle), Matrix4.Rotation(axis, -angle));

		public IScene Scaled(float factor) =>
			source.Transformed(Matrix4.Scaling(factor), Matrix4.Scaling(1F / factor));

		public IScene Transformed(Matrix4 forward, Matrix4 backward) =>
			new Transformed(source, forward, backward);

		public IScene Translated(Vector3 translation) =>
			source.Transformed(Matrix4.Translation(translation), Matrix4.Translation(-translation));

		public IScene Transparent() =>
			new Transparent(source);

		public IScene UnitedWith(IScene scene) =>
			new Union(source, scene);
	}
}
