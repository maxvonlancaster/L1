using System;
using System.Collections.Generic;
using System.Text;

namespace L1.LabTwo
{
    public interface IDateAndCopy
    {
        object DeepCopy();
        DateTime Date { get; set; }
    }
}
