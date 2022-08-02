namespace CommandPattern.Core.Command
{
    using CommandPattern.Core.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class InfoCommand : ICommand // By just adding the "ICommand" interface as a new command, I can easily add commands without changing any other code.
    {
        public string Execute(string[] args)
        {
            return $" My name is {args[0]} I am {args[1]} years old! ";
        }
    }
}
