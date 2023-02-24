using Azimuth;
using Azimuth.GameObject;

using Raylib_cs;

using System.Numerics;

namespace Spasteroids.UI
{
	public delegate void OnClickEvent();
	public class Button : GameObject
	{
		public struct RenderSettings
		{
			public ColorBlock tint;
			public int fontSize;
			public Font font;

			public RenderSettings(ColorBlock _tint, int _fontSize, string _fontId)
			{
				tint = _tint;
				fontSize = _fontSize;
				font = Assets.Find<Font>(_fontId);
			}
		}
		private Vector2 size;
		public string text;

		private Color color;
		
		private Vector2 textSize;
		private RenderSettings renderSettings;

		private OnClickEvent? onClick;
		public Button(Vector2 _position, Vector2 _size, string _text, RenderSettings _settings)
		{
			position = _position;
			size = _size;
			text = _text;

			renderSettings = _settings;
			
			color = renderSettings.tint.normal;
			
			textSize = Raylib.MeasureTextEx(renderSettings.font, text, renderSettings.fontSize, 1f) * 0.5f ;
			textSize.Y = 0;
		}

		public void AddListener(OnClickEvent? _event)
		{
			if(onClick == _event)
			{
				onClick = _event;
			}
			else
			{
				{
					onClick += _event;
				}
			}
		}

		public void RemoveListener(OnClickEvent? _event)
		{
			if(_event != null && onClick != null)
			{
				onClick -= _event;
			}
		}

		public override void Draw()
		{
			Raylib.DrawRectanglePro(new Rectangle(position.X, position.Y, size.X, size.Y), size * 0.5f, 0f, color);
			Raylib.DrawTextPro(renderSettings.font, text, position + textSize, size * 0.5f, 0, renderSettings.fontSize, 1f, Color.BLACK);
			
		}

		public override void Update(float _deltaTime)
		{
			if(Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), GetBounds()) && Raylib.IsMouseButtonReleased(MouseButton.MOUSE_BUTTON_LEFT))
			{
				onClick?.Invoke();
			}
			color = renderSettings.tint.normal;
			if(Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), GetBounds()))
			{
				color = Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT) ?
					        renderSettings.tint.pressed : 
					        renderSettings.tint.hover;
			}
		}

		private Rectangle GetBounds()
		{
			float x = position.X - size.X * 0.5f;
			float y = position.Y - size.Y * 0.5f;

			return new Rectangle(x, y, size.X, size.Y);
		}
	}
}