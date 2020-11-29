using System;
using System.Drawing;
using System.Windows.Forms;
using TextFlasher.Presentation.Views;


namespace TextFlasher.UI
{
    public partial class MainForm : Form, IMainView
    {
        public string WorkableText { get => textBox.Text; set => textBox.Text = value; }
        public Color TextColor { set => textBox.ForeColor = value; }
        public int Interval { get => flashIntervalTrackBar.Value; }

        public MainForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            flashIntervalTrackBar.Scroll += (sender, args) => Invoke(FlashIntervalChanged);
            FormClosed += (sender, args) => Invoke(ViewClosed);
        }

        public new void Show()
        {
            Application.Run(this);
        }

        public event Action ViewClosed;
        public event Action FlashIntervalChanged;

        private void Invoke(Action action)
        {
            if (action != null)
                action();
        }
    }
}
