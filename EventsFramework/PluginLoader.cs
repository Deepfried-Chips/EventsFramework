using System;
using EventsFramework.Hooks;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;

namespace EventsFramework
{
    public class PluginLoader
    {
        public static PluginLoader Singleton { get; private set; }

        [PluginPriority(LoadPriority.Medium)]
        [PluginEntryPoint("EventsFramework", "1.0.0", "Enhancing events with the help of lua", "Deepfried-Chips")]
        void Load()
        {
            Singleton = this;
            EventManager.RegisterEvents<EventHandlers>(this);
        }
    }
}