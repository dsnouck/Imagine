namespace Imagine.Scenes;

public static class SceneExtensions
{
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
