using GmodNET.API;

namespace GmodDiscordBot
{
    public class GmodDiscordBot : IModule
    {
        public string ModuleName => "GmodDiscordBot";

        public string ModuleVersion => "0.1.0";

        public void Load(ILua lua, bool is_serverside, ModuleAssemblyLoadContext assembly_context)
        {
            
        }

        public void Unload(ILua lua)
        {
            
        }
    }
}
