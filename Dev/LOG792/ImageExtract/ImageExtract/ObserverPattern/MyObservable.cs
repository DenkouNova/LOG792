using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageExtract.ObserverPattern
{
    class MyObservable : IObservable<object>
    {
        private List<IObserver<object>> observers;

        public MyObservable()
        {
            observers = new List<IObserver<object>>();
        }

        // like comment and subscribe
        public IDisposable Subscribe(IObserver<object> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<object>> _observers;
            private IObserver<object> _observer;

            public Unsubscriber(List<IObserver<object>> observers, IObserver<object> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }



        public List<IObserver<object>> Observers
        { get { return this.observers; } }


        public void NotifyObservers(object value)
        {
            foreach (var observer in observers)
            {
                observer.OnNext(value);
            }
        }


    }
}
