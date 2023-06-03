using EventsFramework.Factory;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace EventsFramework.Hooks
{
    public class EventHandlers
    {
        [PluginEvent(ServerEventType.PlayerJoined)]
        public void PlayerJoined(EventPlayer player)
        {
            EventHooker.Run(0);
        }
    }
}