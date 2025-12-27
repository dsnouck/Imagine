namespace Imagine.Components;

public interface IProjectorComponent
{
	Func<Vector2, ColorRgb> Project(ISceneComponent scene, ProjectorSettings settings);
}
