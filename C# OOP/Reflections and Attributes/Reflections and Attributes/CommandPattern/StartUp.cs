using CommandPattern.Core;
using CommandPattern.Core.Contracts;
using CommandPattern.IO;
using CommandPattern.IO.Contracts;
using System;

namespace CommandPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsolReader();
            IWriter writer = new ConsolWriter();

            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command, reader,writer);
            engine.Run();
        }
    }
}
