using jcaillaguaS6online.Models;
using System.Net;

namespace jcaillaguaS6online.Views;

public partial class vistaActualizarEliminar : ContentPage
{
	public vistaActualizarEliminar(Estudiante datos)
	{
		InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre;
        txtApellido.Text = datos.apellido;
        txtEdad.Text = datos.edad.ToString();
    }

    private void btnActaulizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string url = $"http://192.168.2.19/wsestudiante/restEstudiante.php" +
                     $"?codigo={txtCodigo.Text}" +
                     $"&nombre={txtNombre.Text}" +
                     $"&apellido={txtApellido.Text}" +
                     $"&edad={txtEdad.Text}";

            WebClient cliente = new WebClient();
            cliente.UploadString(url, "PUT", "");

            DisplayAlert("Alert", "Actualización correcta", "OK");
            Navigation.PushAsync(new vistaEstudiante());
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex);
        }
    }

    private void brnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string codigo = txtCodigo.Text;

            string url = $"http://192.168.2.19/wsestudiante/restEstudiante.php?codigo={codigo}";

            WebClient cliente = new WebClient();
            cliente.UploadString(url, "DELETE", "");

            DisplayAlert("Alert", "Registro eliminado correctamente", "OK");
            Navigation.PushAsync(new vistaEstudiante());
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.ToString(), "OK");
        }
    }
}