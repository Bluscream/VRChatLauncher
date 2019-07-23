using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRChatLauncher
{
    class Arguments
    {
        public bool NoSSL = false;
        public IPC.Game.Command[] Commands;
        public Arguments FromArgs(List<string> args)
        {
            var arguments = new Arguments();
            foreach (var arg in args)
            {
                var curArg = arg;
                if (curArg.StartsWith("--")) curArg = curArg.Substring(2);
                if (curArg.StartsWith("-")) curArg = curArg.Substring(1);
                var splitarg = curArg.Split('=');
                var isSplitArg = splitarg.Length > 0;
                var argValue = isSplitArg ? splitarg[1] : null;
                var argBool = isSplitArg ? bool.TryParse(splitarg[1], out bool argBoolValue) : false;
                var argNumber = isSplitArg ? ulong.TryParse(splitarg[1], out ulong argNumberValue) : false;
                switch (curArg)
                {
                    case "--vrclauncher.nossl":
                        
                    default:
                        break;
                }
            }
            return arguments;
        }
    }
}
