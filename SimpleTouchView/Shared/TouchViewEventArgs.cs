using System;
namespace SimpleTouchView
{
    public class TouchViewEventArgs : EventArgs
    {
        #region auto-properties

        public float X { get; }
        public float Y { get; }

        #endregion

        #region ctor(s)

        public TouchViewEventArgs(float x, float y)
        {
            X = x;
            Y = y;
        }

        #endregion
    }
}
