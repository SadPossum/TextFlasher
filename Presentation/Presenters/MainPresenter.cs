using System;
using System.Drawing;
using System.Threading;
using TextFlasher.DomainModel;
using TextFlasher.Presentation.Common;
using TextFlasher.Presentation.Views;

namespace TextFlasher.Presentation.Presenters
{
    public class MainPresenter : BasePresenter<IMainView>
    {
        private ITextService _service;
        private Timer _timer;
        private Random rnd = new Random();

        public MainPresenter(IMainView view, ITextService service) : base(view)
        {
            _service = service;
            _timer = new Timer(new TimerCallback(ChangeColor), null, -1, -1);

            View.FlashIntervalChanged += () => FlashIntervalChanged(View.Interval);
            View.ViewClosed += () => ViewClosed(view.WorkableText);
        }

        public new void Run()
        {
            View.WorkableText = _service.LoadText();
            base.Run();
        }

        private void ViewClosed(string text)
        {
            _service.SaveText(View.WorkableText);
        }

        private void ChangeColor(object sender)
        {
            View.TextColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }

        private void FlashIntervalChanged(int interval)
        {
            if (interval != 0)
            {
                _timer.Change(0, 5000 / interval);
            }
            else
            {
                _timer.Change(-1, -1);
                View.TextColor = Color.FromArgb(0, 0, 0);
            }
        }
    }
}
