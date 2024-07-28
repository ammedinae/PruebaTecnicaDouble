using Microsoft.AspNetCore.Components;
using PruebaApi.DTO.Request;
using PruebaApi.DTO.Response;

namespace Prueba.Presentation.Shared
{
    public partial class ModalUsuario
    {
        //PARAMETER
        [Parameter]
        public EventCallback<bool> OnClose { get; set; }
        [Parameter]
        public Func<Task> BuscarUsuario { get; set; }

        //DTO
        UsuarioRequest usuarioRequest { get; set; } = new UsuarioRequest();
        UsuarioResponse usuarioResponse { get; set; } = new UsuarioResponse();

        private async Task GuardarUsuario()
        {
            try
            {
                var resultExist = await _iUsuarioServiceBLL.GetByUser(usuarioRequest.Usuario1);
                if (resultExist.Code == 200)
                {
                    _swaAlerts.ShowWarningAlertWithIconNoAction("Info!", "El usuario ya existe, por favor ingrese uno diferente");
                    StateHasChanged();
                }
                else
                {
                    var result = await _iUsuarioServiceBLL.Create(usuarioRequest);
                    if (result.Code == 200)
                    {
                        _swaAlerts.ShowSuccesssWithIcon("Correcto!", "Usuario guardado con exito");
                        StateHasChanged();
                        await BuscarUsuario.Invoke();
                        await ModalCancel();
                    }
                    else
                    {
                        _swaAlerts.ShowWarningAlertWithIconNoAction("Alerta!", "Ocurrio un error, intente nuevamente");
                    }
                }
            }
            catch (Exception ex)
            {
                _swaAlerts.ShowWarningErrorWithIcon("Error!", "Ocurrio un error, intente nuevamente");
            }
        }

        private Task ModalCancel()
        {
            return OnClose.InvokeAsync(false);
        }
    }
}
