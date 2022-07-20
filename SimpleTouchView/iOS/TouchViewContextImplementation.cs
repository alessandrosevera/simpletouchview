using System;
using System.Threading.Tasks;
using SimpleTouchView.Core;
using SimpleTouchView.iOS;

namespace SimpleTouchView
{
    public class TouchViewContextImplementation : ITouchViewContext
    {
        public Task<bool> Initialize()
        {
            TouchViewRenderer.Initialize();
            TouchListViewRenderer.Initialize();

            return Task.FromResult(true);
        }
    }
}
