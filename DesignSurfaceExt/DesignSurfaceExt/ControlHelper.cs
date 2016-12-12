using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace pF.DesignSurfaceExt
{
    public static class ControlHelper
    {
        public static bool IsSaved { get; set; } = true;

        public static IEnumerable<Control> GetAll(Control control, Type type = null)
        {
            var controls = control.Controls.Cast<Control>();
            //check the all value, if true then get all the controls
            //otherwise get the controls of the specified type
            return type == null ? controls.SelectMany(ctrl => GetAll(ctrl)).Concat(controls) : controls.SelectMany(ctrl => GetAll(ctrl, type)).Concat(controls).Where(c => c.GetType() == type);
        }

        public static Type GetControlType(string ctrlName, string partialName)
        {
            try
            {
                Type ctrl;
                switch (ctrlName)
                {
                    case "Label":
                        ctrl = typeof(Label);
                        break;

                    case "TextBox":
                        ctrl = typeof(TextBox);
                        break;

                    case "PictureBox":
                        ctrl = typeof(PictureBox);
                        break;

                    case "ListView":
                        ctrl = typeof(ListView);
                        break;

                    case "ComboBox":
                        ctrl = typeof(ComboBox);
                        break;

                    case "Button":
                        ctrl = typeof(Button);
                        break;

                    case "CheckBox":
                        ctrl = typeof(CheckBox);
                        break;

                    case "MonthCalender":
                        ctrl = typeof(MonthCalendar);
                        break;

                    case "DateTimePicker":
                        ctrl = typeof(DateTimePicker);
                        break;

                    case "TreeView":
                        ctrl = typeof(TreeView);
                        break;

                    case "Panel":
                        ctrl = typeof(Panel);
                        break;

                    case "TabControl":
                        ctrl = typeof(TabControl);
                        break;

                    case "OpenFileDialog":
                        ctrl = typeof(OpenFileDialog);
                        break;

                    case "GroupBox":
                        ctrl = typeof(GroupBox);
                        break;

                    case "ImageList":
                        ctrl = typeof(ImageList);
                        break;

                    case "ProgressBar":
                        ctrl = typeof(ProgressBar);
                        break;

                    case "ToolBar":
                        ctrl = typeof(ToolBar);
                        break;

                    case "ToolTip":
                        ctrl = typeof(ToolTip);
                        break;

                    case "StatusBar":
                        ctrl = typeof(StatusBar);
                        break;

                    default:
#pragma warning disable 618
                        var controlAsm = Assembly.LoadWithPartialName(partialName);
#pragma warning restore 618
                        var controlType = controlAsm.GetType(partialName + "." + ctrlName);
                        //ctrl = (Control)Activator.CreateInstance(controlType);
                        ctrl = controlType;
                        break;
                }
                return ctrl;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("create control failed:" + ex.Message);
                return typeof(Control);
            }
        }

        /// <summary>
        /// Convert to suitable value
        /// </summary>
        /// <param name="propertyType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object ConvertFromString(Type propertyType, string value)
        {
            var converter = TypeDescriptor.GetConverter(propertyType);
            var convertedValue = converter.ConvertFromString(value);

            return convertedValue;
        }

        /// <summary>
        /// Convert value to string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ConvertToString(object value)
        {
            var typeValue = value.GetType();
            var converter = TypeDescriptor.GetConverter(typeValue);
            var convertedValue = converter.ConvertToString(value);

            return convertedValue;
        }

    }
}
