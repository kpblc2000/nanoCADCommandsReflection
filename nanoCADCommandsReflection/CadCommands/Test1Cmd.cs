using System.ComponentModel;
using nanoCADCommandsReflection.Infrasructure;
using Teigha.Runtime;

namespace nanoCADCommandsReflection.CadCommands
{
    public static class Test1Cmd
    {
        [CommandMethod("test1")]
        [Description("Описание команды " + nameof(Test1Command))]
        public static void Test1Command()
        {
            MessageService msgService = new MessageService();
            msgService.ConsoleMessage("Test1 command");
        }
    }
}
