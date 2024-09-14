using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PingyPong.Screen
{
    public class Button {
        private Texture2D _texture;
        private SpriteFont _font;
        private string _text;
        private Vector2 _position;
        private Rectangle _bounds;
        private Color _textColor;
        private Color _defaultColor;
        private Color _hoverColor;

        private bool _isHovering;

        public event EventHandler OnClick;
        public bool Clicked { get; private set; }

        public Button(Texture2D texture, SpriteFont font, string text, Vector2 position) {
            _texture = texture;
            _font = font;
            _text = text;
            _position = position;
            _textColor = Color.Black;
            _defaultColor = Color.White;
            _hoverColor = Color.Gray;

            // calc bounds for button
            Vector2 textSize = _font.MeasureString(_text);
            _bounds = new Rectangle((int)position.X, (int)position.Y, _texture.Width, _texture.Height);
        }

        public void Update(GameTime time) {
            var mouseState = Mouse.GetState();
            var mousePosition = new Vector2(mouseState.X, mouseState.Y);

            // is mouse over the button bounds?
            _isHovering = _bounds.Contains(mousePosition);

            // handling button clicking
            if (_isHovering && mouseState.LeftButton == ButtonState.Pressed) {
                Clicked = true;
                OnClick?.Invoke(this, EventArgs.Empty);
            }
            else {
                Clicked = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            var color = _isHovering ? _hoverColor : _defaultColor;

            spriteBatch.Draw(_texture, _bounds, color);

            var textSize = _font.MeasureString(_text);
            var textPosition = new Vector2(
                _position.X + (_bounds.Width / 2) - (textSize.X / 2),
                _position.Y + (_bounds.Height / 2) - (textSize.Y / 2)
            );

            spriteBatch.DrawString(_font, _text, textPosition, _textColor);
        }


    }
}