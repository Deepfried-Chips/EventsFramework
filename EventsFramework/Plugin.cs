using System;
using System.IO;
using MoonSharp.Interpreter;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;

namespace EventsFramework
{
    using Factory;
    using Hooks;
    using Configs;
    using VM;
    public class Plugin
    {

        public const string Name = "EventsFramework";
        
        public static Plugin Singleton { get; private set; }
        
        public static string EventsFrameworkDirectory { get; private set; }

        public static Script Script { get; private set; } = LuaVirtualMachine.New();
        
        [PluginConfig] public Config Config;
        
        [PluginPriority(LoadPriority.Medium)]
        [PluginEntryPoint(Name, "1.0.0", "Enhancing events with the help of lua", "Deepfried-Chips")]
        private void LoadPlugin()
        {
            Singleton = this;
            Log.Info("Loading and Registering events", Name);
            EventManager.RegisterEvents<EventHandlers>(this);
            FactoryManager.RegisterPlayerFactory(this, new EventPlayerFactory());

            var handler = PluginHandler.Get(this);
            

            EventsFrameworkDirectory = handler.PluginDirectoryPath;

            if (!Directory.Exists(EventsFrameworkDirectory))
            {
                Log.Info("Config Directory does not exist, making one", Name);
                Directory.CreateDirectory(EventsFrameworkDirectory);
            }

            string ScriptsDirectory = Path.Combine(EventsFrameworkDirectory, "scripts");
            if (!Directory.Exists(ScriptsDirectory))
            {
                Directory.CreateDirectory(ScriptsDirectory);
            }
        }
    }
}