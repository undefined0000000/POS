using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace Classes
{
     public static class Toastr
    {
        public enum ToastType { Success, Info, Warning, Error };
        public enum ToastPosition { TopRight, TopLeft, TopCenter, TopStretch, BottomRight, BottomLeft, BottomCenter, BottomStretch };

        public static void ShowToast(Page Page, ToastType Type, string Msg, string Title = "", ToastPosition Position = ToastPosition.BottomRight, bool ShowCloseButton = true)
        {
            string strType = "";
            string strPosition = "";
            switch (Type)
            {
                case ToastType.Success: strType = "success"; break;
                case ToastType.Info: strType = "info"; break;
                case ToastType.Warning: strType = "warning"; break;
                case ToastType.Error: strType = "error"; break;
                default: strType = "success"; break;
            }

            switch (Position)
            {
                case ToastPosition.TopRight: strPosition = "toast-top-right"; break;
                case ToastPosition.TopLeft:
                    strPosition = "toast-top-left"; break;
                case ToastPosition.TopCenter:
                    strPosition = "toast-top-center"; break;
                case ToastPosition.TopStretch:
                    strPosition = "toast-top-full-width"; break;
                case ToastPosition.BottomRight:
                    strPosition = "toast-bottom-right"; break;
                case ToastPosition.BottomLeft:
                    strPosition = "toast-bottom-left"; break;
                case ToastPosition.BottomCenter:
                    strPosition = "toast-bottom-center"; break;
                case ToastPosition.BottomStretch:
                    strPosition = "toast-bottom-full-width"; break;
                default: strPosition = "toast-top-right"; break;
            }

            string script = "toastify('" + strType + "','" + CleanStr(Msg) + "', '" + CleanStr(Title) + "', '" + strPosition + "', '" + ShowCloseButton.ToString().ToLower() + "');";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "toastedMsg", script, true);
        }
        private static string CleanStr(string Text)
        {
            return Text.Replace("'", "&#39;");
        }




    }
}
