using Microsoft.Extensions.DependencyInjection;

namespace MauiAppAula4
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Define a MainPage usando a pilha de navegação necessária para o PushAsync
            MainPage = new NavigationPage(new MainPage());
        }

        // APAGUE OU COMENTE O MÉTODO "CreateWindow" ABAIXO:
        // protected override Window CreateWindow(IActivationState? activationState)
        // {
        //     return new Window(new AppShell());
        // }
    }
}