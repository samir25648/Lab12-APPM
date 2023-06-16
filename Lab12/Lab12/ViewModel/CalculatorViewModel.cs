using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lab12.ViewModel
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private string result;

        public CalculatorViewModel()
        {
            CalculateCommand = new Command<string>(Calculate);
            ClearCommand = new Command(Clear);
            result = string.Empty;
        }

        public string Result
        {
            get => result;
            set
            {
                if (result != value)
                {
                    result = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand CalculateCommand { get; }
        public ICommand ClearCommand { get; }

        private void Calculate(string parameter)
        {
            if (parameter == "=")
            {
                Result = new DataTable().Compute(Result, null).ToString();
            }
            else
            {
                Result += parameter;
            }
        }

        private void Clear()
        {
            Result = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
