using System;
using System.Drawing;
using TextFlasher.Presentation.Common;

namespace TextFlasher.Presentation.Views
{
    public interface IMainView : IView
    {
        int Interval { get; }
        string WorkableText { get; set; }
        Color TextColor { set; }

        event Action ViewClosed;
        event Action FlashIntervalChanged;
    }
}
