using System;
using Foundation;
using SimpleTouchView.iOS;
using SimpleTouchView;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TouchView), typeof(TouchViewRenderer))]
namespace SimpleTouchView.iOS
{
    public class TouchViewRenderer : VisualElementRenderer<TouchView>
    {
        #region auto-properties

        private TouchView FormsElement { get; set; }

        #endregion

        #region overrides

        protected override void OnElementChanged(ElementChangedEventArgs<TouchView> e)
        {
            if (!(e.OldElement is null))
            {
                e.OldElement.Dispose();
            }

            if (!(e.NewElement is null))
            {
                FormsElement = e.NewElement;
            }

            base.OnElementChanged(e);
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            if (touches.Count > 0)
            {
                
                var touch = touches.ToArray<UITouch>()[0];
                var locationInView = touch.LocationInView(this);

                var coordinate = new TouchView.TouchCoordinate((float)locationInView.X, (float)locationInView.Y);
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

                var coordinate = new TouchView.TouchCoordinate((float)locationInView.X, (float)locationInView.Y);
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

                var coordinate = new TouchView.TouchCoordinate((float)locationInView.X, (float)locationInView.Y);
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

                var coordinate = new TouchView.TouchCoordinate((float)locationInView.X, (float)locationInView.Y);
                FormsElement?.RaisePanning(coordinate);
            }

            base.TouchesMoved(touches, evt);
            System.Diagnostics.Debug.WriteLine("TouchesMoved + " + evt.Type);
        }

        #endregion
    }
}
