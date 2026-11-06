namespace dcarrascoT5.Views;

public partial class vPersona : ContentPage
{
	public vPersona()
	{
		InitializeComponent();
	}

    private void btnMostrar_Clicked(object sender, EventArgs e)
    {
        List<Models.Persona> people = App._personRepo.GetAllPersona();
        listaPersonas.ItemsSource = people;


    }

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";
        App._personRepo.AddNewPerson(txtName.Text);
        lblStatusMessage.Text = App._personRepo.StatusMessage;
    }

    private Models.Persona? personaSeleccionada;

    private void listaPersonas_SelectionChanged(
        object sender,
        SelectionChangedEventArgs e)
    {
        personaSeleccionada = e.CurrentSelection.FirstOrDefault()
            as Models.Persona;
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        if (personaSeleccionada == null)
        {
            lblStatusMessage.Text = "Selecciona una persona primero";
            return;
        }

        App._personRepo.DeletePerson(personaSeleccionada.Id);
        lblStatusMessage.Text = App._personRepo.StatusMessage;

        listaPersonas.ItemsSource = App._personRepo.GetAllPersona();
        listaPersonas.SelectedItem = null;
        personaSeleccionada = null;
    }
}