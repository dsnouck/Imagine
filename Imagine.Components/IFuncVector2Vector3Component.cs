namespace Imagine.Components;

public interface IFuncVector2Vector3Component
{
	// TODO: Do we really need this?
	Func<Vector2, Vector3> CreatePlane(Vector3 origin, Vector3 xDirection, Vector3 yDirection);
}
