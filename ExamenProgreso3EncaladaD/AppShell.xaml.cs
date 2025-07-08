namespace ExamenProgreso3EncaladaD
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("RegistroClientePage", typeof(Views.RegistroClientePage));
            Routing.RegisterRoute("ClientesListPage", typeof(Views.ClientesListPage));
            Routing.RegisterRoute("LogsPage", typeof(Views.LogsPage));
        }
    }
}
