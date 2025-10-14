namespace Imagine.Components;

public class FuncVector2Vector3Component(IVector3Component vector3Component) : IFuncVector2Vector3Component
{
	public Func<Vector2, Vector3> CreatePlane(Vector3 origin, Vector3 xDirection, Vector3 yDirection)
	{
		// TODO: Introduce extension methods.
		return point2 => vector3Component.Add(
			origin,
			vector3Component.Add(
				vector3Component.Multiply(xDirection, point2.X),
				vector3Component.Multiply(yDirection, point2.Y)));
	}
}
