using System;
using EventsFramework.Factory;
using EventsFramework.Hooks;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;

namespace EventsFramework
{
    public class Plugin
    {
        public static Plugin Singleton { get; private set; }
        
        [PluginPriority(LoadPriority.Medium)]
        [PluginEntryPoint("EventsFramework", "1.0.0", "Enhancing events with the help of lua", "Deepfried-Chips")]
        private void LoadPlugin()
        {
            Singleton = this;
            Log.Info("Loading and Registering events", "EventsFramework");
            EventManager.RegisterEvents<EventHandlers>(this);
            FactoryManager.RegisterPlayerFactory(this, new EventPlayerFactory());

            var handler = PluginHandler.Get(this);

            Log.Info(handler.PluginName);
        }
    }
}