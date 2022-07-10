using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface IRobot :IId
    {
        public string Model { get;}
    }
}
