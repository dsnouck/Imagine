namespace Imagine.Components;

public interface IProjectorComponent
{
	Func<Vector2, RgbColor> Project(ISceneComponent scene, ProjectorSettings settings);

	Func<Vector2, RgbColor> Project(ISceneComponent scene, Vector3 eye, Func<Vector2, Vector3> screen);
}
