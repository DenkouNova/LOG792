using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace ImageExtract.Observer
{
    // code from https://msdn.microsoft.com/en-us/library/ee817669.aspx
    //interface that all observable classes should implement
    public interface IObservable
    {

        void Register(IObserver anObserver);
        void UnRegister(IObserver anObserver);

    }
}