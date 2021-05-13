using System.Windows.Forms;

namespace ContactsAppUI
{
    /// <summary>
    /// Класс формы About
    /// </summary>
    public partial class AboutForm : Form
    {
        /// <summary>
        /// Инициализирует все компоненты
        /// </summary>
        public AboutForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод для перехода пользователя по ссылке 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GitHubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Ani-Mnatsakanyan/ContactsApp");
        }
    }
}
