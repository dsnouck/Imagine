namespace Imagine.Components;

public interface IProjectorComponent
{
	Func<Vector2, RgbColor> Project(ISceneComponent scene, ProjectorSettings settings);
}
