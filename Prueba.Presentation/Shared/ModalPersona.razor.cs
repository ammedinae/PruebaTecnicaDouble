using Microsoft.AspNetCore.Components;
using PruebaApi.DTO.Request;
using PruebaApi.DTO.Response;

namespace Prueba.Presentation.Shared
{
    public partial class ModalPersona
    {
        //PARAMETER
        [Parameter]
        public EventCallback<bool> OnClose { get; set; }
        [Parameter]
        public Func<Task> BuscarPersona { get; set; }

        //DTO
        PersonaRequest personaRequest { get; set; } = new PersonaRequest();
        PersonaResponse personaResponse { get; set; } = new PersonaResponse();

        private async Task GuardarPersona()
        {
            try
            {
                var resultExist = await _iPersonaServiceBLL.GetByPerson(personaRequest.NumeroIdentificacion);
                if (resultExist.Code == 200)
                {
                    _swaAlerts.ShowWarningAlertWithIconNoAction("Info!", "La identificación ingresada ya existe, por favor ingrese una diferente");
                    StateHasChanged();
                }
                else
                {
                    personaRequest.NombresApellidos = $"{personaRequest.Nombres} {personaRequest.Apellidos}";
                    personaRequest.IdentificacionTipo = $"{personaRequest.NumeroIdentificacion} {personaRequest.TipoIdentificacion}";
                    var result = await _iPersonaServiceBLL.Create(personaRequest);
                    if (result.Code == 200)
                    {
                        _swaAlerts.ShowSuccesssWithIcon("Correcto!", "Persona guardado con exito");
                        StateHasChanged();
                        await BuscarPersona.Invoke();
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
