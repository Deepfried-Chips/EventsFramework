using System;
using System.Collections.Generic;
using MoonSharp.Interpreter;
using PluginAPI.Core;
using PluginAPI.Enums;

namespace EventsFramework.Hooks
{
    public class EventHooker
    {
        public static Dictionary<int, List<Hook>> EventHooks { get; set; } = new Dictionary<int, List<Hook>>() { };

        public static string Add(int EventId, DynValue function)
        {

            List<Hook> EventList = new List<Hook>();
            string EventUuid = Guid.NewGuid().ToString();
            Hook Event = new Hook()
            {
                Uuid = EventUuid,
                Value = function,
            };

            EventHooks.TryGetValue(EventId, out EventList);
            EventList.Add(Event);
            
            EventHooks.Add(EventId,EventList);

            return EventUuid;
        }
        
        public static void Run(int EventId, params object[] list)
        {
            List<Hook> EventList = new List<Hook>();
            if (EventHooks.TryGetValue(EventId, out EventList))
            {
                return;
            }

            foreach (var Event in EventList)
            {
                if (Event.Value.Type != DataType.Function) return;
                Plugin.Script.CallAsync(Event.Value,list);
            }
        }
    }
    
}