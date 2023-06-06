using CommunityToolkit.Mvvm.ComponentModel;

namespace BASTool.Models
{
    public class ObservableWrapper<T> : ObservableObject
    {
        private T _value;

        public T Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }

        public ObservableWrapper(T value)
        {
            _value = value;
        }
    }
}
