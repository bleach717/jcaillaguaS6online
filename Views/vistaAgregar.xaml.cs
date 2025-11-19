using System.Net;

namespace jcaillaguaS6online.Views;

public partial class vistaAgregar : ContentPage
{
	public vistaAgregar()
	{
		InitializeComponent();
	}

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
		try
		{
			WebClient cliente = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre", txtnombre.Text);
			parametros.Add("apellido", txtapellido.Text);
			parametros.Add("edad", txtedad.Text);
			cliente.UploadValues("http://192.168.2.19/wsestudiante/restEstudiante.php", "POST", parametros);
			DisplayAlert("Alert", "ingreso correcto", "OK");
			Navigation.PushAsync(new vistaEstudiante());
		}catch(Exception ex)
		{
			Console.WriteLine("Error: " + ex);
		}
    }
}