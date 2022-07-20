using System;
using System.Threading.Tasks;
using SimpleTouchView.Droid;
using SimpleTouchView.Core;

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
