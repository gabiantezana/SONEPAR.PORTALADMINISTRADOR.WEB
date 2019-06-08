using SONEPAR.PORTALADMINISTRADOR.WEB.EXCEPTION;
using System;
using System.Web.Mvc;
using System.Web.WebPages;

namespace SONEPAR.PORTALADMINISTRADOR.WEB.HELPER
{
    public static class HtmlHelpers
    {
        /// <summary>
        /// Genera Mensaje de Alerta Html Boostrap
        /// </summary>
        /// <param name="type">Tipo de Alerta</param>
        /// <param name="style">Tema Alerta</param>
        /// <param name="message">Mensaje</param>
        /// <returns>MvcHtmlString</returns>
        public static MvcHtmlString Alert(this HtmlHelper Html, TempDataEntity tempData)
        {
            var div = new TagBuilder("div");
            div.Attributes.Add("role", "alert");
            div.InnerHtml = String.Empty;

            var buttonDimiss = new System.Web.Mvc.TagBuilder("button");
            buttonDimiss.Attributes.Add("type", "button");
            buttonDimiss.Attributes.Add("data-dismiss", "alert");
            buttonDimiss.Attributes.Add("aria-label", "Close");
            buttonDimiss.AddCssClass("close");

            var span = new System.Web.Mvc.TagBuilder("span");
            span.Attributes.Add("aria-hidden", "true");
            span.InnerHtml = "×";

            buttonDimiss.InnerHtml = Html.Raw(span.ToString(System.Web.Mvc.TagRenderMode.Normal)).ToHtmlString();

            var i = new System.Web.Mvc.TagBuilder("i");
            var divClass = "alert alert-dismissible";

            divClass += " dark ";

            switch (tempData.TipoMensaje)
            {
                case MessageType.Success:
                    divClass += "alert-success";
                    i.AddCssClass("fa fa-check");
                    break;
                case MessageType.Warning:
                    divClass += " alert-warning";
                    i.AddCssClass("fa fa-exclamation-triangle");
                    break;
                case MessageType.Info:
                    divClass += " alert-info";
                    i.AddCssClass("fa fa-info");
                    break;
                case MessageType.Error:
                    divClass += " alert-danger";
                    i.AddCssClass("fa fa-times");
                    break;
                default:
                    break;
            }

            div.AddCssClass(divClass);
            div.InnerHtml += Html.Raw(i.ToString(System.Web.Mvc.TagRenderMode.Normal) + "&nbsp;").ToHtmlString();
            div.InnerHtml += Html.Raw(buttonDimiss.ToString(System.Web.Mvc.TagRenderMode.Normal)).ToHtmlString();
            div.InnerHtml += Html.Raw(tempData.Mensaje.ToSafeString()).ToHtmlString();

            return MvcHtmlString.Create(div.ToString(System.Web.Mvc.TagRenderMode.Normal));
        }

        /// <summary>
        /// Genera Mensaje de Alerta Html Boostrap basado en una exepcion customizada
        /// </summary>
        /// <param name="Html"></param>
        /// <param name="tempData"></param>
        /// <returns></returns>
        public static MvcHtmlString Alert(this HtmlHelper Html, CustomException exception)
        {
            var div = new System.Web.Mvc.TagBuilder("div");
            div.Attributes.Add("role", "alert");
            div.InnerHtml = String.Empty;

            var buttonDimiss = new System.Web.Mvc.TagBuilder("button");
            buttonDimiss.Attributes.Add("type", "button");
            buttonDimiss.Attributes.Add("data-dismiss", "alert");
            buttonDimiss.Attributes.Add("aria-label", "Close");
            buttonDimiss.AddCssClass("close");

            var span = new System.Web.Mvc.TagBuilder("span");
            span.Attributes.Add("aria-hidden", "true");
            span.InnerHtml = "×";

            buttonDimiss.InnerHtml = Html.Raw(span.ToString(System.Web.Mvc.TagRenderMode.Normal)).ToHtmlString();

            var i = new System.Web.Mvc.TagBuilder("i");
            var divClass = "alert alert-dismissible";

            divClass += " dark ";

            switch (exception.MessageTypeException)
            {
                case MessageTypeException.Success:
                    divClass += "alert-success";
                    i.AddCssClass("fa fa-check");
                    break;
                case MessageTypeException.Warning:
                    divClass += " alert-warning";
                    i.AddCssClass("fa fa-exclamation-triangle");
                    break;
                case MessageTypeException.Info:
                    divClass += " alert-info";
                    i.AddCssClass("fa fa-info");
                    break;
                case MessageTypeException.Error:
                    divClass += " alert-danger";
                    i.AddCssClass("fa fa-times");
                    break;
                default:
                    break;
            }

            div.AddCssClass(divClass);
            div.InnerHtml += Html.Raw(i.ToString(System.Web.Mvc.TagRenderMode.Normal) + "&nbsp;").ToHtmlString();
            div.InnerHtml += Html.Raw(buttonDimiss.ToString(System.Web.Mvc.TagRenderMode.Normal)).ToHtmlString();
            div.InnerHtml += Html.Raw(exception.Message.ToSafeString()).ToHtmlString();

            return MvcHtmlString.Create(div.ToString(System.Web.Mvc.TagRenderMode.Normal));
        }

        public static string ModalHelperFor(this UrlHelper url, string actionName, string controllerName, object routeValues = null, ModalSize size = new ModalSize())
        {
            var modalSize = String.Empty;
            switch (size)
            {
                case ModalSize.Small:
                    modalSize = "modal-sm";
                    break;
                case ModalSize.Normal:
                    modalSize = "modal-md";
                    break;
                case ModalSize.Large:
                    modalSize = "modal-lg";
                    break;
                default:
                    break;
            }

            return "data-type=modal-link data-modal-size=" + modalSize + " data-source-url=" + url.Action(actionName, controllerName, routeValues);
        }

    }
}
