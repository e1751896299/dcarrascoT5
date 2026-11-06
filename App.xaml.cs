using dcarrascoT5.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace dcarrascoT5
{
    public partial class App : Application
    {
        public static PersonRepositry _personRepo { get; set; }
        public App(PersonRepositry repo)
        {
            InitializeComponent();
            _personRepo = repo;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Views.vPersona());
        }
    }
}