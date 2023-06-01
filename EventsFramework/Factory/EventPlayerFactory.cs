using System;
using PluginAPI.Core.Factories;
using PluginAPI.Core.Interfaces;

namespace EventsFramework.Factory
{
    public class EventPlayerFactory : PlayerFactory
    {
        public override Type BaseType { get; } = typeof(EventPlayer);

        public override IPlayer Create(IGameComponent component) => new EventPlayer(component);
    }
}