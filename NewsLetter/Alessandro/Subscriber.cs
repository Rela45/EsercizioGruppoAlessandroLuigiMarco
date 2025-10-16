using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsLetter.Alessandro
{
    public class Subscriber : IObserver
    {
        private string _nome;
        private List<IObserver> _observers = new List<IObserver>();

        public void NotificaCreazione(string nomeUtente)
        {
            foreach (var o in _observers)
            {
                o.NotificaCreazione(_nome);
            }
        }

        public void Subscribe(IObserver o)
        {
            _observers.Add(o);
        }
        public void UnSub(IObserver o)
        {
            _observers.Remove(o);
        }
    }
}