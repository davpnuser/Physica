using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Physica.Interfaces
{
    public interface IRenderableUI
    {
        public string Name { get; set; }
        public int ZIndex { get; set; }
        public void Draw();
    }
}
