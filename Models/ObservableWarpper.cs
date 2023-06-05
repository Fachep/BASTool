using CommunityToolkit.Mvvm.ComponentModel;

namespace BiligameAccountSwitchTool.Models
{
    public class ObservableWarpper<T> : ObservableObject
    {
        private T _value;

        public T Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }

        public ObservableWarpper(T value)
        {
            SetProperty(ref _value, value);
        }
    }
}
