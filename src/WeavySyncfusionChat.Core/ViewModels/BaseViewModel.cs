using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.ViewModels;

namespace WeavySyncfusionChat.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        private bool _busy;
        public bool IsBusy
        {
            get => _busy;
            set => SetProperty(ref _busy, value);
        }
    }
}
