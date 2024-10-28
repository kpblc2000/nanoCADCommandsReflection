using HostMgd.ApplicationServices;
using HostMgd.EditorInput;
using System.Windows.Forms;
using Application = HostMgd.ApplicationServices.Application;

namespace nanoCADCommandsReflection.Infrasructure
{
    public class MessageService
    {
        public void ErrorMessage(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void InfoMessage(string message)
        {
            MessageBox.Show(message, "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ConsoleMessage(string message)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            if (doc == null)
            {
                InfoMessage(message);
            }

            Editor ed = doc.Editor;
            ed.WriteMessage("\n" + message);
        }
    }
}
