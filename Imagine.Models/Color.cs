namespace Imagine.Models;

public class Color
{
	public Color(string name, string hex)
	{
		Name = name;
		Hex = hex;
	}

	public string Name { get; set; }
	public string Hex { get; set; }

}
