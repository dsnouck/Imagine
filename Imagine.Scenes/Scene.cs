namespace Imagine.Scenes;

public static class Scene
{
	public static readonly double Phi = (1D + double.Sqrt(5D)) / 2D;
	public static readonly double Xi = double.Sqrt(3D - Phi);
	public static readonly double CubeCircumradius = double.Sqrt(3D);
	public static readonly double CubeInradius = 1D;
	public static readonly double CubeMidradius = double.Sqrt(2D);
	public static readonly double DodecahedronCircumradius = double.Sqrt(3D) * Phi;
	public static readonly double DodecahedronInradius = Phi * Phi / Xi;
	public static readonly double DodecahedronMidradius = Phi * Phi;
	public static readonly double IcosahedronCircumradius = Xi * Phi;
	public static readonly double IcosahedronInradius = Phi * Phi / double.Sqrt(3D);
	public static readonly double IcosahedronMidradius = Phi;
	public static readonly double OctahedronCircumradius = double.Sqrt(2D);
	public static readonly double OctahedronInradius = double.Sqrt(2D / 3D);
	public static readonly double OctahedronMidradius = 1D;
	public static readonly double TetrahedronCircumradius = double.Sqrt(3D / 2D);
	public static readonly double TetrahedronInradius = 1D / double.Sqrt(6D);
	public static readonly double TetrahedronMidradius = 1D / double.Sqrt(2D);

	public static IScene Cone(Vector3 axis, double angle) =>
		new Cone(axis, angle);

	public static IScene CubeFaceDownWithCircumradius(double circumradius) =>
		CubeFaceDownWithInradius(circumradius * CubeInradius / CubeCircumradius);

	public static IScene CubeFaceDownWithInradius(double inradius)
	{
		var theta0 = 0D;
		var theta1 = double.Pi / 2D;
		var theta2 = double.Pi;

		var deltaPhi = double.Pi / 2D;

		return Polyhedron(
			new Vector3Spherical(inradius, 0D, theta0),
			new Vector3Spherical(inradius, 0D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 1D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 2D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 3D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 0D, theta2));
	}

	public static IScene CubeFaceDownWithMidradius(double midradius) =>
		CubeFaceDownWithInradius(midradius * CubeInradius / CubeMidradius);

	public static IScene CubeVertexDownWithCircumradius(double circumradius) =>
		CubeVertexDownWithInradius(circumradius * CubeInradius / CubeCircumradius);

	public static IScene CubeVertexDownWithInradius(double inradius)
	{
		var theta0 = double.Acos(1D / double.Sqrt(3D));
		var theta1 = double.Pi - theta0;

		var deltaPhi = double.Pi / 3D;

		return Polyhedron(
			new Vector3Spherical(inradius, 0D * deltaPhi, theta0),
			new Vector3Spherical(inradius, 2D * deltaPhi, theta0),
			new Vector3Spherical(inradius, 4D * deltaPhi, theta0),
			new Vector3Spherical(inradius, 1D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 3D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 5D * deltaPhi, theta1));
	}

	public static IScene CubeVertexDownWithMidradius(double midradius) =>
		CubeVertexDownWithInradius(midradius * CubeInradius / CubeMidradius);

	public static IScene Cylinder(Vector3 axis, double radius) =>
		new Cylinder(axis, radius);

	public static IScene DodecahedronFaceDownWithCircumradius(double circumradius) =>
		DodecahedronFaceDownWithInradius(circumradius * DodecahedronInradius / DodecahedronCircumradius);

	public static IScene DodecahedronFaceDownWithInradius(double inradius)
	{
		var theta0 = 0D;
		var theta1 = double.Acos(1D / double.Sqrt(5D));
		var theta2 = double.Pi - theta1;
		var theta3 = double.Pi;

		var deltaPhi = double.Pi / 5D;

		return Polyhedron(
			new Vector3Spherical(inradius, 0D, theta0),
			new Vector3Spherical(inradius, 1D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 3D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 5D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 7D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 9D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 0D * deltaPhi, theta2),
			new Vector3Spherical(inradius, 2D * deltaPhi, theta2),
			new Vector3Spherical(inradius, 4D * deltaPhi, theta2),
			new Vector3Spherical(inradius, 6D * deltaPhi, theta2),
			new Vector3Spherical(inradius, 8D * deltaPhi, theta2),
			new Vector3Spherical(inradius, 0D, theta3));
	}

	public static IScene DodecahedronFaceDownWithMidradius(double midradius) =>
		DodecahedronFaceDownWithInradius(midradius * DodecahedronInradius / DodecahedronMidradius);

	public static IScene DodecahedronVertexDownWithCircumradius(double circumradius) =>
		DodecahedronVertexDownWithInradius(circumradius * DodecahedronInradius / DodecahedronCircumradius);

	public static IScene DodecahedronVertexDownWithInradius(double inradius)
	{
		var theta0 = double.Acos(double.Sqrt((5D + (2D * double.Sqrt(5D))) / 15D));
		var theta1 = double.Acos(double.Sqrt((5D - (2D * double.Sqrt(5D))) / 15D));
		var theta2 = double.Pi - theta1;
		var theta3 = double.Pi - theta0;

		var deltaPhi = double.Pi / 3D;

		return Polyhedron(
			new Vector3Spherical(inradius, 0D * deltaPhi, theta0),
			new Vector3Spherical(inradius, 2D * deltaPhi, theta0),
			new Vector3Spherical(inradius, 4D * deltaPhi, theta0),
			new Vector3Spherical(inradius, 1D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 3D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 5D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 0D * deltaPhi, theta2),
			new Vector3Spherical(inradius, 2D * deltaPhi, theta2),
			new Vector3Spherical(inradius, 4D * deltaPhi, theta2),
			new Vector3Spherical(inradius, 1D * deltaPhi, theta3),
			new Vector3Spherical(inradius, 3D * deltaPhi, theta3),
			new Vector3Spherical(inradius, 5D * deltaPhi, theta3));
	}

	public static IScene DodecahedronVertexDownWithMidradius(double midradius) =>
		DodecahedronVertexDownWithInradius(midradius * DodecahedronInradius / DodecahedronMidradius);

	public static IScene Empty() =>
		new Empty();

	public static IScene Full() =>
		new Full();

	public static IScene IcosahedronFaceDownWithCircumradius(double circumradius) =>
		IcosahedronFaceDownWithInradius(circumradius * IcosahedronInradius / IcosahedronCircumradius);

	public static IScene IcosahedronFaceDownWithInradius(double inradius)
	{
		var theta0 = 0D;
		var theta1 = double.Acos(double.Sqrt(5D) / 3D);
		var theta2 = double.Acos(1D / 3D);
		var theta3 = double.Pi - theta2;
		var theta4 = double.Pi - theta1;
		var theta5 = double.Pi;

		var deltaPhi = double.Pi / 3D;
		var phiOffset = double.Acos(double.Sqrt(7D + (3D * double.Sqrt(5D))) / 4D);

		return Polyhedron(
			new Vector3Spherical(inradius, 0D, theta0),
			new Vector3Spherical(inradius, 1D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 3D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 5D * deltaPhi, theta1),
			new Vector3Spherical(inradius, (0D * deltaPhi) - phiOffset, theta2),
			new Vector3Spherical(inradius, (0D * deltaPhi) + phiOffset, theta2),
			new Vector3Spherical(inradius, (2D * deltaPhi) - phiOffset, theta2),
			new Vector3Spherical(inradius, (2D * deltaPhi) + phiOffset, theta2),
			new Vector3Spherical(inradius, (4D * deltaPhi) - phiOffset, theta2),
			new Vector3Spherical(inradius, (4D * deltaPhi) + phiOffset, theta2),
			new Vector3Spherical(inradius, (1D * deltaPhi) - phiOffset, theta3),
			new Vector3Spherical(inradius, (1D * deltaPhi) + phiOffset, theta3),
			new Vector3Spherical(inradius, (3D * deltaPhi) - phiOffset, theta3),
			new Vector3Spherical(inradius, (3D * deltaPhi) + phiOffset, theta3),
			new Vector3Spherical(inradius, (5D * deltaPhi) - phiOffset, theta3),
			new Vector3Spherical(inradius, (5D * deltaPhi) + phiOffset, theta3),
			new Vector3Spherical(inradius, 0D * deltaPhi, theta4),
			new Vector3Spherical(inradius, 2D * deltaPhi, theta4),
			new Vector3Spherical(inradius, 4D * deltaPhi, theta4),
			new Vector3Spherical(inradius, 0D, theta5));
	}

	public static IScene IcosahedronFaceDownWithMidradius(double midradius) =>
		IcosahedronFaceDownWithInradius(midradius * IcosahedronInradius / IcosahedronMidradius);

	public static IScene IcosahedronVertexDownWithCircumradius(double circumradius) =>
		IcosahedronVertexDownWithInradius(circumradius * IcosahedronInradius / IcosahedronCircumradius);

	public static IScene IcosahedronVertexDownWithInradius(double inradius)
	{
		var theta0 = double.Acos(double.Sqrt((5D + (2D * double.Sqrt(5D))) / 15D));
		var theta1 = double.Acos(double.Sqrt((5D - (2D * double.Sqrt(5D))) / 15D));
		var theta2 = double.Pi - theta1;
		var theta3 = double.Pi - theta0;

		var deltaPhi = double.Pi / 5D;

		return Polyhedron(
			new Vector3Spherical(inradius, 0D * deltaPhi, theta0),
			new Vector3Spherical(inradius, 2D * deltaPhi, theta0),
			new Vector3Spherical(inradius, 4D * deltaPhi, theta0),
			new Vector3Spherical(inradius, 6D * deltaPhi, theta0),
			new Vector3Spherical(inradius, 8D * deltaPhi, theta0),
			new Vector3Spherical(inradius, 0D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 2D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 4D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 6D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 8D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 1D * deltaPhi, theta2),
			new Vector3Spherical(inradius, 3D * deltaPhi, theta2),
			new Vector3Spherical(inradius, 5D * deltaPhi, theta2),
			new Vector3Spherical(inradius, 7D * deltaPhi, theta2),
			new Vector3Spherical(inradius, 9D * deltaPhi, theta2),
			new Vector3Spherical(inradius, 1D * deltaPhi, theta3),
			new Vector3Spherical(inradius, 3D * deltaPhi, theta3),
			new Vector3Spherical(inradius, 5D * deltaPhi, theta3),
			new Vector3Spherical(inradius, 7D * deltaPhi, theta3),
			new Vector3Spherical(inradius, 9D * deltaPhi, theta3));
	}

	public static IScene IcosahedronVertexDownWithMidradius(double midradius) =>
		IcosahedronVertexDownWithInradius(midradius * IcosahedronInradius / IcosahedronMidradius);

	public static IScene Intersection(params List<IScene> scenes) =>
		scenes.Aggregate(Full(), IntersectedWith);

	public static IScene OctahedronFaceDownWithCircumradius(double circumradius) =>
		OctahedronFaceDownWithInradius(circumradius * OctahedronInradius / OctahedronCircumradius);

	public static IScene OctahedronFaceDownWithInradius(double inradius)
	{
		var theta0 = 0D;
		var theta1 = double.Acos(1D / 3D);
		var theta2 = double.Pi - theta1;
		var theta3 = double.Pi;

		var deltaPhi = double.Pi / 3D;

		return Polyhedron(
			new Vector3Spherical(inradius, 0D, theta0),
			new Vector3Spherical(inradius, 1D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 3D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 5D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 0D * deltaPhi, theta2),
			new Vector3Spherical(inradius, 2D * deltaPhi, theta2),
			new Vector3Spherical(inradius, 4D * deltaPhi, theta2),
			new Vector3Spherical(inradius, 0D, theta3));
	}

	public static IScene OctahedronFaceDownWithMidradius(double midradius) =>
		OctahedronFaceDownWithInradius(midradius * OctahedronInradius / OctahedronMidradius);

	public static IScene OctahedronVertexDownWithCircumradius(double circumradius) =>
		OctahedronVertexDownWithInradius(circumradius * OctahedronInradius / OctahedronCircumradius);

	public static IScene OctahedronVertexDownWithInradius(double inradius)
	{
		var theta0 = double.Acos(1D / double.Sqrt(3D));
		var theta1 = double.Pi - theta0;

		var deltaPhi = double.Pi / 4D;

		return Polyhedron(
			new Vector3Spherical(inradius, 1D * deltaPhi, theta0),
			new Vector3Spherical(inradius, 3D * deltaPhi, theta0),
			new Vector3Spherical(inradius, 5D * deltaPhi, theta0),
			new Vector3Spherical(inradius, 7D * deltaPhi, theta0),
			new Vector3Spherical(inradius, 1D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 3D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 5D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 7D * deltaPhi, theta1));
	}

	public static IScene OctahedronVertexDownWithMidradius(double midradius) =>
		OctahedronVertexDownWithInradius(midradius * OctahedronInradius / OctahedronMidradius);

	public static IScene Plane(Vector3 normal) =>
		new Plane(normal);

	public static IScene PlaneThroughOrigin(Vector3 normal) =>
		Plane(normal).Translated(-normal);

	public static IScene Polyhedron(params List<Vector3> faces) =>
		Intersection([.. faces.Select(Plane)]);

	public static IScene Polyhedron(params List<Vector3Spherical> faces) =>
		Polyhedron([.. faces.Select(face => (Vector3)face)]);

	public static IScene Sphere() =>
		SphereWithRadius(1D);

	public static IScene SphereWithRadius(double radius) =>
		new Sphere(radius);

	public static IScene TetrahedronFaceDownWithCircumradius(double circumradius) =>
		TetrahedronFaceDownWithInradius(circumradius * TetrahedronInradius / TetrahedronCircumradius);

	public static IScene TetrahedronFaceDownWithInradius(double inradius)
	{
		var theta0 = double.Acos(1D / 3D);
		var theta1 = double.Pi;

		var deltaPhi = double.Pi / 3D;

		return Polyhedron(
			new Vector3Spherical(inradius, 0D * deltaPhi, theta0),
			new Vector3Spherical(inradius, 2D * deltaPhi, theta0),
			new Vector3Spherical(inradius, 4D * deltaPhi, theta0),
			new Vector3Spherical(inradius, 0D, theta1));
	}

	public static IScene TetrahedronFaceDownWithMidradius(double midradius) =>
		TetrahedronFaceDownWithInradius(midradius * TetrahedronInradius / TetrahedronMidradius);

	public static IScene TetrahedronVertexDownWithCircumradius(double circumradius) =>
		TetrahedronVertexDownWithInradius(circumradius * TetrahedronInradius / TetrahedronCircumradius);

	public static IScene TetrahedronVertexDownWithInradius(double inradius)
	{
		var theta0 = 0D;
		var theta1 = double.Pi - double.Acos(1D / 3D);

		var deltaPhi = double.Pi / 3D;

		return Polyhedron(
			new Vector3Spherical(inradius, 0D, theta0),
			new Vector3Spherical(inradius, 1D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 3D * deltaPhi, theta1),
			new Vector3Spherical(inradius, 5D * deltaPhi, theta1));
	}

	public static IScene TetrahedronVertexDownWithMidradius(double midradius) =>
		TetrahedronVertexDownWithInradius(midradius * TetrahedronInradius / TetrahedronMidradius);

	public static IScene Union(params List<IScene> scenes) =>
		scenes.Aggregate(Empty(), UnitedWith);

	extension(IScene source)
	{
		public IScene Except(IScene scene) =>
			Intersection(source, scene.Inverted());

		public IScene IntersectedWith(IScene scene) =>
			new Intersection(source, scene);

		public IScene Inverted() =>
			new Inverted(source);

		public IScene Painted(ColorRgb color) =>
			new Painted(source, color);

		public IScene Rotated(double angle) =>
			source.Rotated(new(0D, 0D, 1D), angle);

		public IScene Rotated(Vector3 axis, double angle) =>
			source.Transformed(Matrix4.Rotation(axis, angle), Matrix4.Rotation(axis, -angle));

		public IScene Scaled(double factor) =>
			source.Transformed(Matrix4.Scaling(factor), Matrix4.Scaling(1D / factor));

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
