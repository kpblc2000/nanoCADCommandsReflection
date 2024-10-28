using System;
using System.ComponentModel;
using System.Reflection;
using nanoCADCommandsReflection.Infrasructure;
using Teigha.Runtime;

namespace nanoCADCommandsReflection.CadCommands
{
    public static class GetAllCmdsCmd
    {
        [CommandMethod("get-all-commands")]
        public static void GetAllCommandsCommand()
        {
            MessageService msgService = new MessageService();
            
            Assembly asm = Assembly.GetExecutingAssembly();
            Type[] expTyped = asm.GetTypes();
            foreach (Type t in expTyped)
            {
                MethodInfo[] methods = t.GetMethods();
                foreach (MethodInfo method in methods)
                {
                    CommandInfo temp = GetCommandInfo(method);
                    if (temp != null)
                    {
                        if (temp.descriptionAttr !=null)
                        {
                            msgService.ConsoleMessage(temp.MethodAttr.GlobalName + " >> " +
                                temp.descriptionAttr.Description ?? "");
                        }
                        else
                        {
                            msgService.ConsoleMessage(temp.MethodAttr.GlobalName);
                        }
                    }
                }
            }
        }

        private static CommandInfo GetCommandInfo(MethodInfo method)
        {
            object[] attrs = method.GetCustomAttributes(true);

            CommandInfo res = new CommandInfo();

            foreach (object attr in attrs)
            {
                if (attr is CommandMethodAttribute cmdAttr)
                {
                    res.MethodAttr = cmdAttr;
                }
                else if (attr is DescriptionAttribute descrAttr)
                {
                    res.descriptionAttr = descrAttr;
                }
            }

            return res.MethodAttr == null ? null : res;
        }
    }
}
