using PluginAPI.Core;
using PluginAPI.Core.Interfaces;

namespace EventsFramework.Factory
{
    public class EventPlayer : Player
    {
        public EventPlayer(IGameComponent component) : base(component)
        {
            Log.Info("wawa");
        }
    }
}