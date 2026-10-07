using MauiAppAula4.Mod;

namespace MauiAppAula4
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            CarregarOperacao();
            BindingContext = this;
        }

        public List<Oper> Operacao { get; set; }

        public void CarregarOperacao()
        {
                Operacao = new List<Oper>
                {
                new Oper { Id = 1, Nome = "Somar" },
                new Oper { Id = 2, Nome = "Multiplicar" },
                new Oper { Id = 3, Nome = "Subtrair" },
                new Oper { Id = 4, Nome = "Dividir" }

                };
        }

        private int idOperacaoSelecionada = 0;

        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;

            if (picker.SelectedItem is Oper listaItens)
            {
               
                idOperacaoSelecionada = listaItens.Id;
                System.Diagnostics.Debug.WriteLine($"ID Selecionado: {idOperacaoSelecionada}");
            }
        }

        private async void btnCalOper(object sender, EventArgs e)
        {
            if (idOperacaoSelecionada == 1) CalcularParam("+");
            else if (idOperacaoSelecionada == 2) CalcularParam("*");
            else if (idOperacaoSelecionada == 3) CalcularParam("-");
            else if (idOperacaoSelecionada == 4) CalcularParam("/");
            else 
                await DisplayAlert("Aviso", "Por favor, selecione uma operação no Picker!", "OK");
        }

        private async Task ClearForm()
        {
            txtNum1.Text = string.Empty;
            txtNum2.Text = string.Empty;
            await Task.Delay(50);

            txtNum1.Focus();
        }

        private async Task setForm(DoisParametro dp, string operacao)
        {
            string sinal = "";

            // Escolhe o método correto baseado no botão clicado
            if (operacao == "+") { dp.CalcularSoma(); sinal = "+"; }
            else if (operacao == "-") { dp.CalcularSub(); sinal = "-"; }
            else if (operacao == "*") { dp.CalcularMult(); sinal = "x"; }
            else if (operacao == "/") { dp.CalcularDiv(); sinal = "/"; }


            string resultadoTexto = $"A operação {dp.gsN1} {sinal} {dp.gsN2} = {dp.gsS:0.00}";
            //MANDANDO O RESULTADO PARA A NOVA PAGINA
            await Navigation.PushAsync(new ResultPage2(resultadoTexto));
        }

        private DoisParametro getForm()
        {
            DoisParametro dp = new DoisParametro();
            dp.gsN1 = Convert.ToInt32(txtNum1.Text);
            dp.gsN2 = Convert.ToInt32(txtNum2.Text);
            return dp;
        }

        private async void CalcularParam(string operacao)
        {
            if (await ValidarForm())
            {
                DoisParametro dp = getForm();
                await setForm(dp, operacao);
                await ClearForm();
            }
        }

        private async Task<bool> ValidarForm()
        {
            string num1 = txtNum1.Text;
            if (num1 == string.Empty || num1 == null) 
            {
                await DisplayAlert("Campo Obrigatório", "Campo número 1 obrigatório.", "OK");
                txtNum1.Focus();
                return false;
            }
            else
            {
                string num2 = txtNum2.Text;
                if (num2 == string.Empty || num2 == null)
                {
                    await DisplayAlert("Campo Obrigatório", "Campo número 2 obrigatório.", "OK");
                    txtNum2.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
