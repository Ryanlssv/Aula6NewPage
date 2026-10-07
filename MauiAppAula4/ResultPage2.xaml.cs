namespace MauiAppAula4;

public partial class ResultPage2 : ContentPage
{
	public ResultPage2()
	{
		InitializeComponent();
	}

    public ResultPage2(string mensagemResultado)
    {
        InitializeComponent();
        lblResultadoFinal.Text = mensagemResultado;
    }

    private void OnVoltarClicked(object sender, EventArgs e)
    {
        // Define a MainPage do app como uma nova instância do zero
        Application.Current.MainPage = new NavigationPage(new MainPage());
    }
}