using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    public enum ShapeTypes
    {
        Rectengle,
        Circle,
        Triangle
    }
    public class DrawingTool
    {
        public void DrawShape(ShapeTypes shape , string color)
        {
            if(shape == ShapeTypes.Rectengle) // Here OCP violation occered
            {
                // Code to draw shape
            }
            else if(shape == ShapeTypes.Circle)
            {
                // Code to draw shape
            }
            else
            {
                // Code to draw shape
            }
        }
    }
}
