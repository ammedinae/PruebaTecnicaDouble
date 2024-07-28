using Microsoft.JSInterop;
using PruebaApi.Common.Helpers.SweetAlert;
using PruebaApi.DTO.Request;

namespace Prueba.Presentation.Pages
{
    public partial class Login
    {
        //DTO
        LoginRequest loginRequest { get; set; } = new LoginRequest();

        //Variables
        public static bool MostrarLogin { get; set; } = true;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender)
                {
                    Loggin();
                    StateHasChanged();
                }
            }
            catch (Exception ex)
            {
                _swaAlerts.ShowWarningErrorWithIcon("Error!", "Ocurrio un error, intente nuevamente");
            }
        }

        private async Task Loggin()
        {
            try
            {
                var result = await _iUsuarioServiceBLL.GetUserLogin(loginRequest);
                if (result.Code == 200)
                {
                    var authModule = await JSRunTime.InvokeAsync<IJSObjectReference>("import", "./js/auth.js");
                    await authModule.InvokeVoidAsync("SignIn", loginRequest.Usuario1, loginRequest.Pass, "/");
                    MostrarLogin = false;
                    StateHasChanged();
                }
                else
                {
                    _swaAlerts.ShowWarningAlertWithIconNoAction("Alerta!", "Las credenciales ingresadas son incorrectas, por favor intente nuevamente");
                    MostrarLogin = true;
                    StateHasChanged();
                }
            }
            catch (Exception ex)
            {
                _swaAlerts.ShowWarningErrorWithIcon("Error!", "Ocurrio un error, intente nuevamente");
            }
        }
    }
}
