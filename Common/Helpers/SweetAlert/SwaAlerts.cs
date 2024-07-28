using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PruebaApi.Common.Helpers.SweetAlert.SweetAlertClasses;

namespace PruebaApi.Common.Helpers.SweetAlert
{
    public class SwaAlerts
    {
        private readonly SweetAlertService _sweetAlertService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _url;

        public SwaAlerts(SweetAlertService sweetAlertService, IHttpContextAccessor httpContextAccessor)
        {
            _sweetAlertService = sweetAlertService;
            _httpContextAccessor = httpContextAccessor;
        }

        public void ObtenerUrl()
        {
            _url = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.Path}";
        }

        public void ShowWarningAlertWithImage(ShowErrorAlertWithImageclass showErrorAlertWithImageclass, Action<bool> onConfirm)
        {
            _sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = showErrorAlertWithImageclass.Title,
                Text = showErrorAlertWithImageclass.Mensaje,
                ImageUrl = showErrorAlertWithImageclass.ImageUrl,
                ImageHeight = showErrorAlertWithImageclass.ImageHeight,
                ImageWidth = showErrorAlertWithImageclass.ImageWidth,
                ShowCancelButton = showErrorAlertWithImageclass.ShowCancelButton,
                ConfirmButtonText = showErrorAlertWithImageclass.ConfirmButtonText,
                ConfirmButtonColor = showErrorAlertWithImageclass.ConfirmButtonColor
            }).ContinueWith(result =>
            {
                bool confirmed = result.Result.IsConfirmed;
                onConfirm?.Invoke(confirmed);
            });

        }

        public void ShowWarningAlertWithIcon(ShowWarningAlertWithIcon showWarningAlertWithIcon, Action<bool> onConfirm)
        {
            _sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = showWarningAlertWithIcon.Title,
                Text = showWarningAlertWithIcon.Mensaje,
                Icon = SweetAlertIcon.Warning,
                IconColor = showWarningAlertWithIcon.IconColor,
                ShowCancelButton = false,
                ConfirmButtonText = showWarningAlertWithIcon.ConfirmButtonText,
                ConfirmButtonColor = showWarningAlertWithIcon.ConfirmButtonColor
            }).ContinueWith(result =>
            {
                bool confirmed = result.Result.IsConfirmed;
                onConfirm?.Invoke(confirmed);
            });
        }

        public void ShowWarningAlertWithIconNoAction(string title, string mensaje)
        {
            _sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = title,
                Text = mensaje,
                Icon = SweetAlertIcon.Warning,
                //IconColor = showWarningAlertWithIcon.IconColor,
                ShowCancelButton = false,
                ConfirmButtonText = "Aceptar",
                ConfirmButtonColor = "#e20331"
            });
        }

        public void ShowWarningErrorWithIcon(string title, string mensaje)
        {
            _sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = title,
                Text = mensaje,
                Icon = SweetAlertIcon.Error,
                //IconColor = showWarningAlertWithIcon.IconColor,
                ShowCancelButton = false,
                ConfirmButtonText = "Aceptar",
                ConfirmButtonColor = "#e20331"
            });
        }

        public void ShowSuccesssWithIcon(string title, string mensaje)
        {
            _sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = title,
                Text = mensaje,
                Icon = SweetAlertIcon.Success,
                //IconColor = showSuccessWithIcon.IconColor,
                ShowCancelButton = false,
                ConfirmButtonText = "Aceptar",
                ConfirmButtonColor = "#e20331"
            });
        }

        public void ShowInfoWithIcon(string title, string mensaje)
        {
            _sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = title,
                Text = mensaje,
                Icon = SweetAlertIcon.Info,
                //IconColor = ,
                ShowCancelButton = false,
                ConfirmButtonText = "Aceptar",
                ConfirmButtonColor = "#e20331"
            });
        }

        public void ShowWarningAlertWithImageInformative(ShowErrorAlertWithImageInformativeclass showErrorAlertWithImageclass)
        {
            _sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = showErrorAlertWithImageclass.Title,
                Text = showErrorAlertWithImageclass.Mensaje,
                ImageUrl = showErrorAlertWithImageclass.ImageUrl,
                ImageHeight = showErrorAlertWithImageclass.ImageHeight,
                ImageWidth = showErrorAlertWithImageclass.ImageWidth,
                ShowCancelButton = false,
                ConfirmButtonText = showErrorAlertWithImageclass.ConfirmButtonText,
                ConfirmButtonColor = showErrorAlertWithImageclass.ConfirmButtonColor
            });

        }

        public void ShowLoading()
        {
            _sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "",
                Color = "#FFFFFF",
                ShowCancelButton = false,
                ShowConfirmButton = false,
                AllowOutsideClick = false,
                //Background = "#ffffff00",
                ImageHeight = 300,
                ImageUrl = "/images/GifKairos.gif",
            });
        }

        public void ShowLoadingClose()
        {
            _sweetAlertService.CloseAsync();
        }
    }
}
