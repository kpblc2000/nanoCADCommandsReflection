using nanoCADCommandsReflection.Infrasructure;
using System;
using System.ComponentModel;
using System.Reflection;
using Teigha.Runtime;

namespace nanoCADCommandsReflection
{
    public class ExtensionInitalization :IExtensionApplication
    {
        public void Initialize()
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
                        if (temp.descriptionAttr != null)
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

        public void Terminate() { }

        private CommandInfo GetCommandInfo(MethodInfo method)
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
