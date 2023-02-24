using Raylib_cs;

namespace Spasteroids.UI
{
	public struct ColorBlock
	{
		public Color normal;
		public Color hover;
		public Color pressed;
		public Color disabled;

		public ColorBlock(Color _normal, Color _hover, Color _pressed, Color _disabled)
		{
			normal = _normal;
			hover = _hover;
			pressed = _pressed;
			disabled = _disabled;
		}
	}
}