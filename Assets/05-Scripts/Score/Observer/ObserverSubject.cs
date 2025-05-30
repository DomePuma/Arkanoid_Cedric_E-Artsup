using System.Collections.Generic;
using UnityEngine;
using BrickBreaker.BrickDestroyed.Observer;
using System;

namespace BrickBreaker.BrickDestroyed.Subject
{
    public abstract class ObserverSubject : MonoBehaviour
    {
        private List<IBrickDestroyedObserver> _observers = new List<IBrickDestroyedObserver>();

        public void AddObserver(IBrickDestroyedObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IBrickDestroyedObserver observer) 
        { 
            _observers.Remove(observer); 
        }

        protected void NotifyObservers(Vector3 brickPosition, int scoreOnBrickDestroyed)
        {
            foreach (IBrickDestroyedObserver observer in _observers)
            {
                //Debug.Log("Notification sent");
                observer.OnNotify(brickPosition, scoreOnBrickDestroyed);
            }
        }
    }
}