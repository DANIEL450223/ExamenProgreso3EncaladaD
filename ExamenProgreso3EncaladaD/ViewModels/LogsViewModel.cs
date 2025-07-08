using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ExamenProgreso3EncaladaD.Services;

namespace ExamenProgreso3EncaladaD.ViewModels
{
    public class LogsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> Logs { get; set; } = new ObservableCollection<string>();

        public LogsViewModel()
        {
            CargarLogs();
        }

        public async void CargarLogs()
        {
            var lista = await LogService.LeerLogsAsync();
            Logs.Clear();
            foreach (var l in lista)
            {
                Logs.Add(l);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string n = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
    }
}
