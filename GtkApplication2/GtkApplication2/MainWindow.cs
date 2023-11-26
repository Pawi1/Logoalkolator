using System;
using System.Globalization;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
using Window = Gtk.Window;
namespace GtkApplication2
{
    class MainWindow : Window
    {
        [UI] private Entry _calculationField = null;
        [UI] private Button _cancelButton = null;
        [UI] private Button _minusButton = null;
        [UI] private Button _plusButton = null;
        [UI] private Button _divideButton = null;
        [UI] private Button _timesButton = null;
        [UI] private Button _eqaulButton = null;
        [UI] private Button _dotButton = null;
        [UI] private Button _button0 = null;
        [UI] private Button _button1 = null;
        [UI] private Button _button2 = null;
        [UI] private Button _button3 = null;
        [UI] private Button _button4 = null;
        [UI] private Button _button5 = null;
        [UI] private Button _button6 = null;
        [UI] private Button _button7 = null;
        [UI] private Button _button8 = null;
        [UI] private Button _button9 = null;
        [UI] private Button _rightBButton = null;
        [UI] private Button _leftBButton = null;
        [UI] private Button _acButton = null;
        
        public MainWindow() : this(new Builder("MainWindow.glade")) { }
        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);
            DeleteEvent += Window_DeleteEvent;
            _button9.Clicked += Button9_Clicked;
            _button8.Clicked += Button8_Clicked;
            _button7.Clicked += Button7_Clicked;
            _button6.Clicked += Button6_Clicked;
            _button5.Clicked += Button5_Clicked;
            _button4.Clicked += Button4_Clicked;
            _button3.Clicked += Button3_Clicked;
            _button2.Clicked += Button2_Clicked;
            _button1.Clicked += Button1_Clicked;
            _button0.Clicked += Button0_Clicked;
            _cancelButton.Clicked += CancelButton_Clicked;
            _minusButton.Clicked += MinusButton_Clicked;
            _plusButton.Clicked += PlusButton_Clicked;
            _timesButton.Clicked += TimesButton_Clicked;
            _divideButton.Clicked += DivideButton_Clicked;
            _dotButton.Clicked += DotButton_Clicked;
            _rightBButton.Clicked += RightBButton_Clicked;
            _leftBButton.Clicked += LeftBButton_Clicked;
            _eqaulButton.Clicked += EqaulButton_Clicked;
            _acButton.Clicked += AcButton_Clicked;
        }
        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private void Button9_Clicked(object sender, EventArgs a)
        {
            _calculationField.Text += "9";
        }
        private void Button8_Clicked(object sender, EventArgs a)
        {
            _calculationField.Text += "8";
        }
        private void Button7_Clicked(object sender, EventArgs a)
        {
            _calculationField.Text += "7";
        }
        private void Button6_Clicked(object sender, EventArgs a)
        {
            _calculationField.Text += "6";
        }
        private void Button5_Clicked(object sender, EventArgs a)
        {
            _calculationField.Text += "5";
        }
        private void Button4_Clicked(object sender, EventArgs a)
        {
            _calculationField.Text += "4";
        }
        private void Button3_Clicked(object sender, EventArgs a)
        {
            _calculationField.Text += "3";
        }
        private void Button2_Clicked(object sender, EventArgs a)
        {
            _calculationField.Text += "2";
        }
        private void Button1_Clicked(object sender, EventArgs a)
        {
            _calculationField.Text += "1";
        }
        private void Button0_Clicked(object sender, EventArgs a)
        {
            _calculationField.Text += "0";
        }
        
        private void MinusButton_Clicked (object sender, EventArgs a)
        {
            _calculationField.Text += "-";
        }
        private void PlusButton_Clicked (object sender, EventArgs a)
        {
            _calculationField.Text += "+";
        }
        
        private void CancelButton_Clicked(object sender, EventArgs a)
        {
            if (_calculationField.Text.Length != 0)
            {
                _calculationField.Text = _calculationField.Text.Remove(_calculationField.Text.Length - 1);
            }
        }

        private void TimesButton_Clicked(object sender, EventArgs a)
        {
            _calculationField.Text += "*";
        }

        private void DivideButton_Clicked(object sender, EventArgs a)
        {
            _calculationField.Text += "/";
        }

        private void LeftBButton_Clicked(object sender, EventArgs a)
        {
            _calculationField.Text += "(";
        }
        private void RightBButton_Clicked(object sender, EventArgs a)
        {
            _calculationField.Text += ")";
        }

        private void DotButton_Clicked(object sender, EventArgs a)
        {
            _calculationField.Text += ".";
        }
        private void EqaulButton_Clicked(object sender, EventArgs a)
        {
            try
            {
                _calculationField.Text = Convert.ToString(Calc.CalculateRPN(Calc.ConvertToRPN(Calc.expressionToList(_calculationField.Text))), CultureInfo.CurrentCulture);
            }
            catch (Exception)
            {
                _calculationField.Text = "Error";
            }

        }

        private void AcButton_Clicked(object sender, EventArgs a)
        {
            _calculationField.Text = "";
        }
    }
}