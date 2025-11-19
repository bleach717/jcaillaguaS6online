
using jcaillaguaS6online.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace jcaillaguaS6online.Views;

public partial class vistaEstudiante : ContentPage
{
	private const string Url = "http://192.168.2.19/wsestudiante/restEstudiante.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> _estudiante;

	public async void Mostrar()
	{
		var contet = await cliente.GetStringAsync(Url);
		List<Estudiante> mostarEstudiante = JsonConvert.DeserializeObject<List<Estudiante>>(contet);
		_estudiante = new ObservableCollection<Estudiante>(mostarEstudiante);
        listaEstudiantes.ItemsSource = _estudiante;
	}
    public vistaEstudiante()
	{
		InitializeComponent();
		Mostrar();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new vistaAgregar());

    }

    private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var ojetoEstudiante = (Estudiante)e.SelectedItem;
		Navigation.PushAsync(new vistaActualizarEliminar(ojetoEstudiante));
    }
}