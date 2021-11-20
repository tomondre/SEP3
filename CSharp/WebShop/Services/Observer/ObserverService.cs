using System;

namespace WebShop.Services
{
    public class ObserverService : IObserverService
    {
        public delegate void Change();
        public event Action OnChange;

        public void ChangeHappens()
        {
            OnChange.Invoke();
        }
    }
}