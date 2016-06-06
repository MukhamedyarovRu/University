using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication4
{
    interface INameAndCopy
    {
        object DeepCopy();
        string Name { get; set; }
    }
}
