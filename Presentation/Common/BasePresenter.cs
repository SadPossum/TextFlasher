namespace TextFlasher.Presentation.Common
{
    public class BasePresenter<TView> : IPresenter
        where TView : IView
    {
        protected TView View { get; private set; }

        protected BasePresenter(TView view)
        {
            View = view;
        }

        public void Run()
        {
            View.Show();
        }
    }

    public abstract class BasePresenter<TView, TArg> : IPresenter<TArg>
        where TView : IView
    {
        protected TView View { get; private set; }

        protected BasePresenter(TView view)
        {
            View = view;
        }

        public abstract void Run(TArg argument);
    }
}