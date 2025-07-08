using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ExamenProgreso3EncaladaD.Models;
using ExamenProgreso3EncaladaD.Services;
using System;

namespace ExamenProgreso3EncaladaD.ViewModels
{
    public class ClienteViewModel : INotifyPropertyChanged
    {
        ClienteDatabase db;

        public ClienteViewModel()
        {
            var archivo = Path.Combine(FileSystem.AppDataDirectory, "clientes.db3");
            db = new ClienteDatabase(archivo);
            GuardarCommand = new Command(async () => await Guardar());
            Cargar();
        }

        string nombre;
        public string Nombre
        {
            get => nombre;
            set { nombre = value; OnPropertyChanged(); }
        }

        string empresa;
        public string Empresa
        {
            get => empresa;
            set { empresa = value; OnPropertyChanged(); }
        }

        int antiguedadMeses;
        public int AntiguedadMeses
        {
            get => antiguedadMeses;
            set { antiguedadMeses = value; OnPropertyChanged(); }
        }

        bool activo;
        public bool Activo
        {
            get => activo;
            set { activo = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Cliente> Clientes { get; set; } = new ObservableCollection<Cliente>();

        public ICommand GuardarCommand { get; set; }

        async Task Guardar()
        {
            if (AntiguedadMeses * 10 > 1500)
            {
                await App.Current.MainPage.DisplayAlert("Error", "No se puede guardar empresas con más de 1500 días", "Ok");
                return;
            }

            var c = new Cliente
            {
                Nombre = Nombre,
                    Empresa = Empresa,
                    AntiguedadMeses = AntiguedadMeses,
                Activo = Activo
            };

            await db.AddClienteAsync(c);
                await LogService.EscribirLogAsync(Nombre);
            Clientes.Add(c);

            await App.Current.MainPage.DisplayAlert("Guardado", "Cliente guardado con éxito", "Ok");

            Nombre = "";
                Empresa = "";
                AntiguedadMeses = 0;
            Activo = false;
        }

        async void Cargar()
        {
            var lista = await db.GetClientesAsync();
            Clientes.Clear();
            foreach (var item in lista)
            {
                Clientes.Add(item);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string n = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
    }
}
