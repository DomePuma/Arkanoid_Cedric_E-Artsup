using System.Collections.Generic;
using UnityEngine;
using BrickBreaker.Score.Observer;

namespace BrickBreaker.Score.Subject
{
    public abstract class ObserverSubject : MonoBehaviour
    {
        private List<IObserver> _observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer) 
        { 
            _observers.Remove(observer); 
        }

        protected void NotifyObservers()
        {
            foreach (IObserver observer in _observers)
            {
                observer.OnNotify();
            }
        }
    }
}