using System.Security.Principal;

namespace cguambaExamen.Vistas;

public partial class Login : ContentPage
{


    string[] users = { "Carlos", "Ana", "Jose" };
    string[] passwords = { "carlos123", "ana123", "jose123" };

    string[,] usersYpasswords = new string[2, 2];   


    public Login()
	{
        usersYpasswords[0, 0] = "estudiante";
        usersYpasswords[0, 1] = "moviles";
        usersYpasswords[1, 0] = "uisrael";
        usersYpasswords[1, 1] = "2024";
        InitializeComponent();
	}

    private void btnInicio_Clicked(object sender, EventArgs e)
    {
        string txtUsuario = this.txtUsuario.Text;
        string txtPassword = this.txtPassword.Text;

        bool usuarioEncontrado = false;
        int userIndex = -1;

        // Buscar el usuario ingresado en la matriz
        for (int i = 0; i < 2; i++)
        {
            if (usersYpasswords[i, 0] == txtUsuario)
            {
                usuarioEncontrado = true;
                userIndex = i;
                break;
            }
        }

        if (usuarioEncontrado)
        {
            if (usersYpasswords[userIndex, 1] == txtPassword)
            {
                Navigation.PushAsync(new Registro(txtUsuario));
            }
            else
            {
                DisplayAlert("Alerta", "Contraseña ingresada incorrecta", "OK");
            }
        }
        else
        {
            DisplayAlert("Alerta", "El usuario ingresado no está registrado", "OK");
        }
    }

}