using nanoCADCommandsReflection.Infrasructure;
using System.ComponentModel;
using Teigha.Runtime;

namespace nanoCADCommandsReflection.CadCommands
{
    public static class Test2Cmd
    {
        [CommandMethod("test2")]
        [Description("Test 2 : Описание команды " + nameof(Test2Command))]
        public static void Test2Command()
        {
            MessageService msgService = new MessageService();
            msgService.ConsoleMessage("Test1 command");
        }
    }
}
