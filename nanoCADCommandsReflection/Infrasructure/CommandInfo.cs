using System.ComponentModel;
using Teigha.Runtime;

namespace nanoCADCommandsReflection.Infrasructure
{
    internal class CommandInfo
    {
        public CommandMethodAttribute MethodAttr { get; set; }
        public DescriptionAttribute descriptionAttr { get; set; }
    }
}
