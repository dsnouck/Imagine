namespace Imagine.Components;

public class FuncVector2Vector3Component(IVector3Component vector3Component) : IFuncVector2Vector3Component
{
	public Func<Vector2, Vector3> CreatePlane(Vector3 origin, Vector3 xDirection, Vector3 yDirection) =>
		// TODO: Introduce extension methods.
		point => origin + (xDirection * point.X) + (yDirection * point.Y);
}
