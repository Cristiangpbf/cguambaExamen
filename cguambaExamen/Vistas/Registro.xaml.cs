
namespace cguambaExamen.Vistas;

public partial class Registro : ContentPage
{

	string usuario = string.Empty;
	double COSTO_CURSO = 1500;
	public Registro()
	{
		InitializeComponent();
	}
	public Registro(string user)
	{
		InitializeComponent();
		usuario = user;
        lblNombre.Text = $"Usuario conectado {usuario}!";
    }

    private void BtnCalcularPago_Clicked(object sender, EventArgs e)
	{
        try
        {            
            double txtMonto = ObtieneDoubleYValidaEntradaNumerica(txtMontoInicial);
            double montoRestante = COSTO_CURSO - txtMonto;
            double valorCuotaMensual =  (montoRestante / 4) + (0.04 * COSTO_CURSO);
            double montototal = (valorCuotaMensual * 4) + txtMonto;
            txtPagoMensual.Text = valorCuotaMensual.ToString();            
        }
        catch (Exception ex)
        {
            DisplayAlert("ERROR", ex.Message, "Cerrar");
        }
    }

    private void BtnVerResumen_Clicked(object sender, EventArgs e)
	{
        try
        {
            ValidarCampos();
            string fechaRegistro = dpFecha.Date.ToShortDateString();
            string pais = pkPaices.SelectedItem?.ToString();
            string ciudad = pkCiudades.SelectedItem?.ToString();
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            int edad = Convert.ToInt16(txtEdad.Text);
            Navigation.PushAsync(new Resumen(usuario));
        }
        catch (Exception ex)
        {
            DisplayAlert("ERROR", ex.Message, "Cerrar");
        }

    }

    private void ValidarCampos()
    {
        if (pkPaices.SelectedItem == null || string.IsNullOrWhiteSpace(pkPaices.SelectedItem.ToString()))
        {
            pkPaices.Focus();
            throw new Exception("Por favor seleccione un país.");
        }
        if (pkCiudades.SelectedItem == null || string.IsNullOrWhiteSpace(pkCiudades.SelectedItem.ToString()))
        {
            pkCiudades.Focus();
            throw new Exception("Por favor seleccione una ciudad.");
        }
        if (string.IsNullOrWhiteSpace(txtNombre.Text)
            || string.IsNullOrWhiteSpace(txtApellido.Text)
            || string.IsNullOrWhiteSpace(txtEdad.Text))
        {
            DisplayAlert("Error", "Por favor, rellena todos los campos", "OK");
        }
    }

    private double ObtieneDoubleYValidaEntradaNumerica(Entry txtEntry)
    {
        if (string.IsNullOrWhiteSpace(txtEntry.Text))
        {
            txtEntry.Focus();
            throw new Exception("Campo es obligatorio");
        }
        double valor;
        try
        {
            valor = Convert.ToDouble(txtEntry.Text);
        }
        catch (Exception ex)
        {
            txtEntry.Focus();
            throw new Exception($"Error con el campo numérico (Entero con decimales separado por coma), " +
                $"por favor corrija el valor y vuelva a intentar. {ex.Message}");
        }

        return valor;
    }    
}