using System;
using Android.Content;
using Android.Views;
using SimpleTouchView.Droid;
using SimpleTouchView;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TouchListView), typeof(TouchListViewRenderer))]
namespace SimpleTouchView.Droid
{
    public class TouchListViewRenderer : VisualElementRenderer<TouchListView>, Android.Views.View.IOnTouchListener
    {
        #region auto-properties

        private TouchListView FormsElement { get; set; }

        #endregion

        #region ctor(s)

        public TouchListViewRenderer(Context context) : base(context)
        {
        }

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

        protected override void OnElementChanged(ElementChangedEventArgs<TouchListView> e)
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
            var coordinate = new TouchCoordinate(pointX, pointY);
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
