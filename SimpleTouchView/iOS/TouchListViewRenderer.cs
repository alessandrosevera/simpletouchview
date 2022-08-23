using System;
using Foundation;
using SimpleTouchView.iOS;
using SimpleTouchView;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TouchListView), typeof(TouchListViewRenderer))]
namespace SimpleTouchView.iOS
{
    public class TouchListViewRenderer : ListViewRenderer
    {
        #region auto-properties

        private TouchListView FormsElement { get; set; }

        #endregion

        #region access methods

        /// <summary>
		/// This method ensures that we don't get stripped out by the linker.
		/// </summary>
		public static void Initialize()
        {
#pragma warning disable 0219
            var ignore1 = typeof(TouchListViewRenderer);
            var ignore2 = typeof(TouchListView);
#pragma warning restore 0219
        }

        #endregion

        #region overrides

        public override void MotionBegan(UIEventSubtype motion, UIEvent evt)
        {
            base.MotionBegan(motion, evt);
        }
        public override void PressesBegan(NSSet<UIPress> presses, UIPressesEvent evt)
        {
            base.PressesBegan(presses, evt);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            if (!(e.OldElement is null) && e.OldElement is IDisposable disposableOldElement)
            {
                disposableOldElement.Dispose();
            }

            if (!(e.NewElement is null) && e.NewElement is TouchListView touchListView)
            {
                FormsElement = touchListView;
            }
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            if (touches.Count > 0)
            {

                var touch = touches.ToArray<UITouch>()[0];
                var locationInView = touch.LocationInView(this);

                var coordinate = new TouchCoordinate((float)locationInView.X, (float)locationInView.Y);
                FormsElement?.RaiseDown(coordinate);
            }

            base.TouchesBegan(touches, evt);
            System.Diagnostics.Debug.WriteLine("TouchesBegan + " + evt.Type);
        }

        public override void TouchesCancelled(NSSet touches, UIEvent evt)
        {
            if (touches.Count > 0)
            {
                var touch = touches.ToArray<UITouch>()[0];
                var locationInView = touch.LocationInView(this);

                var coordinate = new TouchCoordinate((float)locationInView.X, (float)locationInView.Y);
                FormsElement?.RaiseUp(coordinate);
                FormsElement?.RaisePanned(coordinate);
            }

            base.TouchesCancelled(touches, evt);
            System.Diagnostics.Debug.WriteLine("TouchesCancelled + " + evt.Type);
        }

        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            if (touches.Count > 0)
            {
                var touch = touches.ToArray<UITouch>()[0];
                var locationInView = touch.LocationInView(this);

                var coordinate = new TouchCoordinate((float)locationInView.X, (float)locationInView.Y);
                FormsElement?.RaiseUp(coordinate);
                FormsElement?.RaisePanned(coordinate);
            }

            base.TouchesEnded(touches, evt);
            System.Diagnostics.Debug.WriteLine("TouchesEnded + " + evt.Type);
        }

        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            if (touches.Count > 0)
            {
                var touch = touches.ToArray<UITouch>()[0];
                var locationInView = touch.LocationInView(this);

                var coordinate = new TouchCoordinate((float)locationInView.X, (float)locationInView.Y);
                FormsElement?.RaisePanning(coordinate);
            }

            base.TouchesMoved(touches, evt);
            System.Diagnostics.Debug.WriteLine("TouchesMoved + " + evt.Type);
        }

        #endregion
    }
}
