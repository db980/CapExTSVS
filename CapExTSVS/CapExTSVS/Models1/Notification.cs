﻿using Humanizer;
using System;
using System.ComponentModel;
using System.Reflection;
using toastr.Net.OptionEnums;

namespace toastr.Net
{
    public static class Notification
    {
        #region HELPERS
        private static string stringValueOf(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }
        private static string booToLowerString(this bool value)
        {
            return value.ToString().ToLower();
        }
        #endregion


        public static string Show(string message, string title = "",
            ToastType type = ToastType.Info,
            Position position = Position.TopRight,
            int timeOut = 5000,
            bool closeButton = true,
            bool progressBar = true,
            bool newestOnTop = true,
            string onclick = null)
        {
            var scriptOption = "<script>";
            scriptOption += "toastr.options = {";

            scriptOption += "'closeButton': '" + closeButton.booToLowerString() + "','debug': false,'newestOnTop': " + newestOnTop.booToLowerString() + ",'progressBar': " + progressBar.booToLowerString() + ",'positionClass': '" + stringValueOf(position) + "','preventDuplicates': false,'onclick': " + (onclick ?? "null") + ",'showDuration': '300','hideDuration': '1000','timeOut': '" + timeOut + "','extendedTimeOut': '1000','showEasing': 'swing','hideEasing': 'linear','showMethod': 'fadeIn','hideMethod': 'fadeOut'";
            scriptOption += "};";
            scriptOption += "toastr['" + stringValueOf(type) + "']('" + message + "', '" + title + "');</script>";

            return scriptOption;
        }



        public static string PopupConformation()
        {
            var scriptOption = "<script>";

            scriptOption += "Swal.fire({\r\n  title: \"Are you sure?\",\r\n  text: \"You won't be able to revert this!\",\r\n  icon: \"warning\",\r\n  showCancelButton: true,\r\n  confirmButtonColor: \"#3085d6\",\r\n  cancelButtonColor: \"#d33\",\r\n  confirmButtonText: \"Yes, delete it!\"\r\n}).then((result) => {\r\n  if (result.isConfirmed) {\r\n    Swal.fire({\r\n      title: \"Deleted!\",\r\n      text: \"Your file has been deleted.\",\r\n      icon: \"success\"\r\n    });\r\n  }\r\n});";
            scriptOption += "</script>";

            return scriptOption;


            
        }


        public static string PopupSave()
        {

            var da = "";
            var scriptOption = "<script>";

            scriptOption += "Swal.fire({\r\n  position: \"top-end\",\r\n  icon: \"success\",\r\n  title: \"Data  Saved SuccessFully\",\r\n  showConfirmButton: false,\r\n  timer: 4000\r\n});;";
            scriptOption += "</script>";

            return scriptOption;



        }

        public static string PopupError()
        {

            var da = "";
            var scriptOption = "<script>";

            scriptOption += " Swal.fire({\r\n  position: \"top-end\",\r\n  icon: \"error\",\r\n  title: \"Failed\",\r\n  showConfirmButton: false,\r\n  timer: 4000\r\n});";
            scriptOption += "</script>";

            return scriptOption;



        }

        public static string PopupUpdate()
        {

            var da = "";
            var scriptOption = "<script>";

            scriptOption += " Swal.fire({\r\n  position: \"top-end\",\r\n  icon: \"success\",\r\n  title: \"Data Update Successfully\",\r\n  showConfirmButton: false,\r\n  timer: 4000\r\n});";
            scriptOption += "</script>";

            return scriptOption;



        }


        public static string PopupNotFound(String Notification)
        {

            var da = "";
            var scriptOption = "<script>";

            scriptOption += " Swal.fire({\r\n  position: \"top-end\",\r\n  icon: \"info\",\r\n  title: \""+ Notification + "\",\r\n  showConfirmButton: false,\r\n  timer: 4000\r\n});";
            scriptOption += "</script>";

            return scriptOption;



        }









    }
}
