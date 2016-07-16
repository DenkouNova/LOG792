using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace ImageExtract.Observer
{
    // code from https://msdn.microsoft.com/en-us/library/ee817669.aspx
    // interface the all observer classes should implement
    public interface IObserver
    {
        void Notify(object anObject);
    }
}
