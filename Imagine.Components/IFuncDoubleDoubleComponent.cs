namespace Imagine.Components;

public interface IFuncDoubleDoubleComponent
{
	Func<double, double> CreateLineThrough(Vector2 point, Vector2 otherPoint);

	List<double> GetRealZerosOfQuadraticFunction(double a, double b, double c);
}
