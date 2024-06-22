namespace cguambaExamen
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Vistas.Login());
        }
    }
}
