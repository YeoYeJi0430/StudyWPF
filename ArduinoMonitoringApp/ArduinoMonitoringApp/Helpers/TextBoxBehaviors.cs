using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using TextBox = System.Windows.Controls.TextBox;

namespace ArduinoMonitoringApp.Helpers
{
    public class TextBoxBehaviors : Behavior<UIElement>
    {
        public static readonly DependencyProperty AutoScrollToEndProperty =
                    DependencyProperty.RegisterAttached(
                        "AutoScrollToEnd", typeof(bool),
                        typeof(TextBoxBehaviors),
                        new UIPropertyMetadata(false, IsTextChanged)
                    );

        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static bool GetAutoScrollToEnd(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoScrollToEndProperty);
        }

        public static void SetAutoScrollToEnd(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoScrollToEndProperty, value);
        }

        private static void IsTextChanged
            (DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;
            textBox.TextChanged -= OnTextChanged;

            var newValue = (bool)e.NewValue;
            if (newValue)
            {
                textBox.TextChanged += OnTextChanged;
            }
        }

        private static void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            if (string.IsNullOrEmpty(textBox.Text))
            {
                return;
            }

            textBox.ScrollToEnd();
        }

    }
}
