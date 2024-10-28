using nanoCADCommandsReflection.Infrasructure;
using Teigha.Runtime;

namespace nanoCADCommandsReflection.CadCommands
{
    public static class Test3Cmd
    {
        [CommandMethod("Test3")]
        public static void Test3Command()
        {
            MessageService msgService = new MessageService();
            msgService.InfoMessage(nameof(Test3Command));
        }
    }
}
