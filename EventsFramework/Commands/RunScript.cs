using System;
using CommandSystem;
using NWAPIPermissionSystem;

namespace EventsFramework.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class RunScript : ICommand
    {
        public string Command { get; } = "runscript_ef";

        public string[] Aliases { get; } = new string[] { "runscript" };

        public string Description { get; } = "Run an event script";

        public string Perm { get; } = "eventsframework.runscript";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission(Perm))
            {
                response = $"You do not have the right permission to use this command, permission required: {Perm}";
                return false;
            }

            response = "Not implemented";
            return true;
        }
    }
}