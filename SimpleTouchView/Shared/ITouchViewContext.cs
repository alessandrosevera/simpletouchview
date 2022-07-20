using System;
using System.Threading.Tasks;

namespace SimpleTouchView.Core
{
    public interface ITouchViewContext
    {
        Task<bool> Initialize();
    }
}
