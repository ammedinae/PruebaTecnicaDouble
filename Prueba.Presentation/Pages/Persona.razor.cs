using Microsoft.AspNetCore.Components.QuickGrid;
using PruebaApi.Common.Helpers.SweetAlert;
using PruebaApi.DTO.Response;

namespace Prueba.Presentation.Pages
{
    public partial class Persona
    {
        //DTO
        IQueryable<PersonaResponse> personaResponseIList { get; set; }

        //Variables
        public bool MostrarModal { get; set; }

        //PAGINATION
        PaginationState paginationPersona = new PaginationState { ItemsPerPage = 10 };

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender)
                {
                    await BuscarPersona();
                    StateHasChanged();
                }
            }
            catch (Exception ex)
            {
                _swaAlerts.ShowWarningErrorWithIcon("Error!", "Ocurrio un error, intente nuevamente");
            }
        }

        public async Task BuscarPersona()
        {
            try
            {
                var result = await _iPersonaServiceBLL.GetAllPerson();
                if (result.Code == 200)
                {
                    var personaResponseList = (List<PersonaResponse>)result.Data;
                    personaResponseIList = personaResponseList.AsQueryable();
                }
            }
            catch (Exception ex)
            {
                _swaAlerts.ShowWarningErrorWithIcon("Error!", "Ocurrio un error, intente nuevamente");
            }
        }

        public void OpenModal()
        {
            MostrarModal = true;
            StateHasChanged();
        }

        public void CloseModal()
        {
            MostrarModal = false;
            StateHasChanged();
        }
    }
}
