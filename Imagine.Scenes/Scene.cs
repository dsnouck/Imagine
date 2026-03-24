namespace Imagine.Scenes;

public static class Scene
{
	public static IScene Cone() =>
		new Cone();

	public static IScene Cube() =>
		CubeWithCircumradius(1D);

	public static IScene CubeWithCircumradius(double circumradius) =>
		CubeWithInradius(circumradius / double.Sqrt(3D));

	public static IScene CubeWithInradius(double inradius) =>
		Polyhedron(
			new Vector3(0D, 0D, -inradius),
			new Vector3(inradius, 0D, 0D),
			new Vector3(0D, inradius, 0D),
			new Vector3(-inradius, 0D, 0D),
			new Vector3(0D, -inradius, 0D),
			new Vector3(0D, 0D, inradius));

	public static IScene Cylinder() =>
		CylinderWithRadius(1D);

	public static IScene CylinderWithRadius(double radius) =>
		new Cylinder(radius);

	public static IScene Dodecahedron() =>
		DodecahedronWithCircumradius(1D);

	public static IScene DodecahedronWithCircumradius(double circumradius) =>
		DodecahedronWithInradius(circumradius / double.Sqrt(15D - (6D * double.Sqrt(5D))));

	public static IScene DodecahedronWithInradius(double inradius)
	{
		var dihedralAngle = double.Acos(-1D / double.Sqrt(5D));
		var azimuthStep = Math.PI / 5D;

		return Polyhedron(
			new Vector3Spherical(inradius, 0D, Math.PI),
			new Vector3Spherical(inradius, 0D * azimuthStep, dihedralAngle),
			new Vector3Spherical(inradius, 2D * azimuthStep, dihedralAngle),
			new Vector3Spherical(inradius, 4D * azimuthStep, dihedralAngle),
			new Vector3Spherical(inradius, 6D * azimuthStep, dihedralAngle),
			new Vector3Spherical(inradius, 8D * azimuthStep, dihedralAngle),
			new Vector3Spherical(inradius, 1D * azimuthStep, Math.PI - dihedralAngle),
			new Vector3Spherical(inradius, 3D * azimuthStep, Math.PI - dihedralAngle),
			new Vector3Spherical(inradius, 5D * azimuthStep, Math.PI - dihedralAngle),
			new Vector3Spherical(inradius, 7D * azimuthStep, Math.PI - dihedralAngle),
			new Vector3Spherical(inradius, 9D * azimuthStep, Math.PI - dihedralAngle),
			new Vector3Spherical(inradius, 0D, 0D));
	}

	public static IScene Empty() =>
		new Empty();

	public static IScene Except(this IScene scene, IScene otherScene) =>
		Intersection(scene, otherScene.Inverted());

	public static IScene Full() =>
		new Full();

	public static IScene Icosahedron() =>
		IcosahedronWithCircumradius(1D);

	public static IScene IcosahedronWithCircumradius(double circumradius) =>
		IcosahedronWithInradius(circumradius / double.Sqrt(15D - (6D * double.Sqrt(5D))));

	public static IScene IcosahedronWithInradius(double inradius)
	{
		var dihedralAngle = double.Acos(-double.Sqrt(5D) / 3D);
		var secondInclination = double.Acos(-1D / 3D);
		var azimuthStep = Math.PI / 3D;
		var azimuthOffset = (Math.PI / 3D) - double.Acos(double.Sqrt(5D / 8D));

		return Polyhedron(
			new Vector3Spherical(inradius, 0D, Math.PI),
			new Vector3Spherical(inradius, 0D * azimuthStep, dihedralAngle),
			new Vector3Spherical(inradius, 2D * azimuthStep, dihedralAngle),
			new Vector3Spherical(inradius, 4D * azimuthStep, dihedralAngle),
			new Vector3Spherical(inradius, (1D * azimuthStep) - azimuthOffset, secondInclination),
			new Vector3Spherical(inradius, (1D * azimuthStep) + azimuthOffset, secondInclination),
			new Vector3Spherical(inradius, (3D * azimuthStep) - azimuthOffset, secondInclination),
			new Vector3Spherical(inradius, (3D * azimuthStep) + azimuthOffset, secondInclination),
			new Vector3Spherical(inradius, (5D * azimuthStep) - azimuthOffset, secondInclination),
			new Vector3Spherical(inradius, (5D * azimuthStep) + azimuthOffset, secondInclination),
			new Vector3Spherical(inradius, (0D * azimuthStep) - azimuthOffset, Math.PI - secondInclination),
			new Vector3Spherical(inradius, (0D * azimuthStep) + azimuthOffset, Math.PI - secondInclination),
			new Vector3Spherical(inradius, (2D * azimuthStep) - azimuthOffset, Math.PI - secondInclination),
			new Vector3Spherical(inradius, (2D * azimuthStep) + azimuthOffset, Math.PI - secondInclination),
			new Vector3Spherical(inradius, (4D * azimuthStep) - azimuthOffset, Math.PI - secondInclination),
			new Vector3Spherical(inradius, (4D * azimuthStep) + azimuthOffset, Math.PI - secondInclination),
			new Vector3Spherical(inradius, 1D * azimuthStep, Math.PI - dihedralAngle),
			new Vector3Spherical(inradius, 3D * azimuthStep, Math.PI - dihedralAngle),
			new Vector3Spherical(inradius, 5D * azimuthStep, Math.PI - dihedralAngle),
			new Vector3Spherical(inradius, 0D, 0D));
	}

	public static IScene IntersectedWith(this IScene scene, IScene otherScene) =>
		new Intersection(scene, otherScene);

	public static IScene Intersection(params List<IScene> scenes) =>
		scenes.Aggregate(Full(), IntersectedWith);

	public static IScene Inverted(this IScene scene) =>
		new Inverted(scene);

	public static IScene Octahedron() =>
		OctahedronWithCircumradius(1D);

	public static IScene OctahedronWithCircumradius(double circumradius) =>
		OctahedronWithInradius(circumradius / double.Sqrt(3D));

	public static IScene OctahedronWithInradius(double inradius)
	{
		var dihedralAngle = double.Acos(-1D / 3D);
		var azimuthStep = Math.PI / 3D;

		return Polyhedron(
			new Vector3Spherical(inradius, 0D, Math.PI),
			new Vector3Spherical(inradius, 0D * azimuthStep, dihedralAngle),
			new Vector3Spherical(inradius, 2D * azimuthStep, dihedralAngle),
			new Vector3Spherical(inradius, 4D * azimuthStep, dihedralAngle),
			new Vector3Spherical(inradius, 1D * azimuthStep, Math.PI - dihedralAngle),
			new Vector3Spherical(inradius, 3D * azimuthStep, Math.PI - dihedralAngle),
			new Vector3Spherical(inradius, 5D * azimuthStep, Math.PI - dihedralAngle),
			new Vector3Spherical(inradius, 0D, 0D));
	}

	public static IScene Painted(this IScene scene, ColorRgb color) =>
		new Painted(scene, color);

	public static IScene Plane(Vector3 normal) =>
		new Plane(normal);

	public static IScene PlaneThroughOrigin(Vector3 normal) =>
		Plane(normal).Translated(-normal);

	public static IScene Polyhedron(params List<Vector3> normals) =>
		Intersection([.. normals.Select(Plane)]);

	public static IScene Polyhedron(params List<Vector3Spherical> normals) =>
		Intersection([.. normals.Select(normal => (Vector3)normal).Select(Plane)]);

	public static IScene Rotated(this IScene scene, double angle) =>
		scene.Rotated(new(0D, 0D, 1D), angle);

	public static IScene Rotated(this IScene scene, Vector3 axis, double angle) =>
		scene.Transformed(Matrix4.Rotation(axis, angle), Matrix4.Rotation(axis, -angle));

	public static IScene Scaled(this IScene scene, double factor) =>
		scene.Transformed(Matrix4.Scaling(factor), Matrix4.Scaling(1D / factor));

	public static IScene Sphere() =>
		SphereWithRadius(1D);

	public static IScene SphereWithRadius(double radius) =>
		new Sphere(radius);

	public static IScene Tetrahedron() =>
		TetrahedronWithCircumradius(1D);

	public static IScene TetrahedronWithCircumradius(double circumradius) =>
		TetrahedronWithInradius(circumradius / 3D);

	public static IScene TetrahedronWithInradius(double inradius)
	{
		var dihedralAngle = double.Acos(1D / 3D);
		var azimuthStep = 2D * Math.PI / 3D;

		return Polyhedron(
			new Vector3Spherical(inradius, 0D, Math.PI),
			new Vector3Spherical(inradius, 0D * azimuthStep, dihedralAngle),
			new Vector3Spherical(inradius, 1D * azimuthStep, dihedralAngle),
			new Vector3Spherical(inradius, 2D * azimuthStep, dihedralAngle));
	}

	public static IScene Transformed(this IScene scene, Matrix4 forward, Matrix4 backward) =>
		new Transformed(scene, forward, backward);

	public static IScene Translated(this IScene scene, Vector3 translation) =>
		scene.Transformed(Matrix4.Translation(translation), Matrix4.Translation(-translation));

	public static IScene Transparent(this IScene scene) =>
		new Transparent(scene);

	public static IScene Union(params List<IScene> scenes) =>
		scenes.Aggregate(Empty(), UnitedWith);

	public static IScene UnitedWith(this IScene scene, IScene otherScene) =>
		new Union(scene, otherScene);
}
