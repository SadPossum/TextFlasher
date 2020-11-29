using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextFlasher.Presentation.Presenters;
using TextFlasher.DomainModel;

namespace TextFlasher.UI
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var presenter = new MainPresenter(new MainForm(), new TextService());
            presenter.Run();
        }
    }
}
