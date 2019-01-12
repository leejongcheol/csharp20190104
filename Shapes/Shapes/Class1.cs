using System;
using System.Drawing;
namespace Shapes
{
    public class Circle
    {
        double radius;
        public Circle()
        {
            radius = 0;
        }
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public double Area()
        {
            return Math.PI * (radius * radius);
        }
        public void Draw()
        {
            Pen p = new Pen(Color.Red);
        }
    }
}