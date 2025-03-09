using CommunityToolkit.Mvvm.ComponentModel;

namespace Atlas.ViewModels
{
    public partial class BaseViewModel : ObservableObject
        {
            [ObservableProperty]
            [NotifyPropertyChangedFor(nameof(IsNotBusy))]
            private bool _isBusy;

            public bool IsNotBusy => !IsBusy;
        }
}

