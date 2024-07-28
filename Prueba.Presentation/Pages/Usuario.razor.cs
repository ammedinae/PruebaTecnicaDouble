using Microsoft.AspNetCore.Components.QuickGrid;
using PruebaApi.Business.BLL;
using PruebaApi.Business.Interface;
using PruebaApi.DTO.Request;
using PruebaApi.DTO.Response;

namespace Prueba.Presentation.Pages
{
    public partial class Usuario
    {
        //DTO
        IQueryable<UsuarioResponse> usuarioResponseIList { get; set; } 

        //Variables
        public bool MostrarModal { get; set; }

        //PAGINATION
        PaginationState paginationUsuario = new PaginationState { ItemsPerPage = 10 };

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender)
                {
                    await BuscarUsuario();
                    StateHasChanged();
                }
            }
            catch (Exception ex)
            {
                _swaAlerts.ShowWarningErrorWithIcon("Error!", "Ocurrio un error, intente nuevamente");
            }
        }

        public async Task BuscarUsuario()
        {
            try
            {
                var result = await _iUsuarioServiceBLL.GetAllUser();
                if (result.Code == 200)
                {
                    var usuarioResponseList = (List<UsuarioResponse>)result.Data;
                    usuarioResponseIList = usuarioResponseList.AsQueryable();
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
