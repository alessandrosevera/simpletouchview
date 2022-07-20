using System;
using Xamarin.Forms;

namespace SimpleTouchView
{
    public class TouchListView : ListView, IDisposable
    {
        #region event handlers

        public event EventHandler<TouchViewEventArgs> Up;
        public event EventHandler<TouchViewEventArgs> Down;
        public event EventHandler<TouchViewEventArgs> Panning;
        public event EventHandler<TouchViewEventArgs> Panned;

        #endregion

        #region ctor(s)

        public TouchListView()
        {
        }

        #endregion

        #region IDisposable implementation

        public void Dispose()
        {

        }

        #endregion

        #region access methods

        public void RaiseUp(TouchCoordinate coordinate)
        {
            Up?.Invoke(this, new TouchViewEventArgs(coordinate.X, coordinate.Y));
        }

        public void RaiseDown(TouchCoordinate coordinate)
        {
            Down?.Invoke(this, new TouchViewEventArgs(coordinate.X, coordinate.Y));
        }

        public void RaisePanning(TouchCoordinate coordinate)
        {
            Panning?.Invoke(this, new TouchViewEventArgs(coordinate.X, coordinate.Y));
        }

        public void RaisePanned(TouchCoordinate coordinate)
        {
            Panned?.Invoke(this, new TouchViewEventArgs(coordinate.X, coordinate.Y));
        }

        #endregion
    }
}
