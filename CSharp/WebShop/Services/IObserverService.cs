using System;

namespace WebShop.Services
{
    public interface IObserverService
    {
        public void ChangeHappens();
        public event Action OnChange;
    }
}