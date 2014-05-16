using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace PixelPower
{
  class ColorPicker
  {
    private Texture2D image;
    private bool _activated;
    private Vector2 pos;

    public ColorPicker(ContentManager c)
    {
      image = c.Load<Texture2D>("colorpicker");
      /* decomment this line when Map is ready  Etape10 */
      // pos = new Vector2(Map.width - image.Width, 0);
      _activated = false;
    }

    public bool activated
    {
      get{return _activated;}
      set{_activated = value;}
    }
    public Color getColor(int X, int Y)
    {
      Color c = new Color(0, 0, 0, 0);
      if (checkInsideBounds(X, Y))
      {
        Color[] data = new Color[1];

        Rectangle sourceRectangle = new Rectangle(X - (int)pos.X, Y - (int)pos.Y, 1, 1);

        image.GetData<Color>(
            0,//mipmap level
            sourceRectangle,//rectangle
            data, //array where to store retrieved data (Color in this case)
            0,//start index
            1);//element count

        c = data[0];
      }

      return c;
    }
    private bool checkInsideBounds(int X, int Y)
    {
      return X >= (int)pos.X
             && X < pos.X + image.Width
             && Y >= (int)pos.Y
             && Y < pos.Y + image.Height;
    }

    public void Draw(SpriteBatch sb)
    {
      sb.Draw(image,pos, Color.White);
    }

  }
}
