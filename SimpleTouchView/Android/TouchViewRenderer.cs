using System;
using Android.Content;
using Android.Views;
using SimpleTouchView.Droid;
using SimpleTouchView;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TouchView), typeof(TouchViewRenderer))]
namespace SimpleTouchView.Droid
{
    public class TouchViewRenderer : VisualElementRenderer<TouchView>, Android.Views.View.IOnTouchListener
    {
        #region auto-properties

        private TouchView FormsElement { get; set; }

        #endregion

        #region ctor(s)

        public TouchViewRenderer(Context context) : base(context)
        {
        }

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

                SetOnTouchListener(this);
            }

            base.OnElementChanged(e);
        }

        public override bool DispatchTouchEvent(MotionEvent e)
        {
            var pointX = e.GetX() / Resources.DisplayMetrics.Density;
            var pointY = e.GetY() / Resources.DisplayMetrics.Density;
            var coordinate = new TouchView.TouchCoordinate(pointX, pointY);
            switch (e.Action)
            {
                case MotionEventActions.Down:
                case MotionEventActions.PointerDown:
                case MotionEventActions.Pointer2Down:
                case MotionEventActions.Pointer3Down:
                    FormsElement?.RaiseDown(coordinate);
                    break;
                case MotionEventActions.Up:
                case MotionEventActions.PointerUp:
                case MotionEventActions.Pointer2Up:
                case MotionEventActions.Pointer3Up:
                    FormsElement?.RaiseUp(coordinate);
                    FormsElement?.RaisePanned(coordinate);
                    break;
                case MotionEventActions.Move:
                    FormsElement?.RaisePanning(coordinate);
                    break;
            }
            return base.DispatchTouchEvent(e);
        }

        #endregion

        #region IOnTouchListener implementation

        public bool OnTouch(Android.Views.View v, MotionEvent e)
        {
            return true;
        }

        #endregion
    }
}
