using System;
using EventsFramework.Hooks;
using MoonSharp.Interpreter;

namespace EventsFramework.VM
{
    public static class LuaVirtualMachine
    {
        public static Script New()
        {
            Script script = new Script();

            script.Globals["hookAdd"] = (Func<int, DynValue, string>)(EventHooker.Add);
            
            return script;
        }
    }
}