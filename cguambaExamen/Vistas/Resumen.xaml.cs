namespace cguambaExamen.Vistas;

public partial class Resumen : ContentPage
{
    string usuario = string.Empty;
    public Resumen()
	{
		InitializeComponent();
	}
	public Resumen(string user)
	{
        InitializeComponent();
        usuario = user;
        lblNombre.Text = $"Usuario conectado {usuario}!";
    }
}