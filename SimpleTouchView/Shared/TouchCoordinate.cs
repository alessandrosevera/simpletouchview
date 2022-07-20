using System;
namespace SimpleTouchView
{
    public readonly struct TouchCoordinate
    {
        public float X { get; }
        public float Y { get; }

        public TouchCoordinate(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
