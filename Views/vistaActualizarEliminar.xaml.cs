using jcaillaguaS6online.Models;

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

    }

    private void brnEliminar_Clicked(object sender, EventArgs e)
    {

    }
}