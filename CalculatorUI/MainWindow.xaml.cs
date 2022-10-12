using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Calculator;
using Calculator.Interfaces;

namespace CalculatorUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        private IPresenter _presenter;
        private IModel _model;


        public MainWindow()
        {
            InitializeComponent();
            _model = new Model();
            _presenter = new Presenter(this, _model);
        }

        private string _inPut;
        public string Input
        {
            get { return _inPut; }
            set
            {
                _inPut = value;
                Equation.Content = _inPut;
            }
        }


        private string _outPut;
        public string Output
        {
            get
            {
                return _outPut;
            }
            set
            {
                _outPut = value;
                Display.Content = _outPut;
            }
        }

        public void DisplayChar(char c)
        {
            Input += c;
        }

        public void DisplayError()
        {
            Output = "Error";
        }

        public void DisplayResult(string result)
        {
            Output = result;
        }

        public void RemoveChar()
        {
            if (Input.Length == 0) return;
            Input = Input.Remove(Input.Length - 1);
        }


        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            _presenter.OnCharInput(btn.Content.ToString()[0]);
        }

        private void ButtonOperand(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            char op = ' ';
            switch (btn.Name)
            {
                case "Multiply": op = '*'; break;
                case "Minus": op = '-'; break;
                case "Plus": op = '+'; break;
                case "Divide": op = '/'; break;
                default: op = '\0'; break;
            }

            _presenter.OnCharInput(op);
        }
        private void ButtonClear(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            _presenter.OnBackspace();
        }

        private void ButtonClearAll(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            _presenter.ClearAll();

        }


        private void ButtonEquals(object sender, RoutedEventArgs e)
        {
            (double r, bool err) = _presenter.ProcessString(Input);
            if (err)
            {
                return;
            }
            Input = r.ToString();
            _presenter.OnEnterInput();

        }

        private void WindowKeyDownPreview(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                _presenter.OnEnterInput();
            else if (e.Key == Key.Back)
            {

                _presenter.OnBackspace();
            }
            else
            {
                char c;
                switch (e.Key)
                {
                    case Key.NumPad0: c = '0'; break;
                    case Key.NumPad1: c = '1'; break;
                    case Key.NumPad2: c = '2'; break;
                    case Key.NumPad3: c = '3'; break;
                    case Key.NumPad4: c = '4'; break;
                    case Key.NumPad5: c = '5'; break;
                    case Key.NumPad6: c = '6'; break;
                    case Key.NumPad7: c = '7'; break;
                    case Key.NumPad8: c = '8'; break;
                    case Key.NumPad9: c = '9'; break;
                    case Key.OemComma: c = '.'; break;
                    case Key.OemPlus: c = '+'; break;
                    case Key.Add: c = '+'; break;
                    case Key.OemMinus: c = '-'; break;
                    case Key.Subtract: c = '-'; break;
                    case Key.Multiply: c = '*'; break;
                    case Key.Divide: c = '/'; break;
                    default: return;
                }
                _presenter.OnCharInput(c);
            }
        }

        public void ClearAll()
        {
            Input = String.Empty;
            Output = "0";
        }

    }
}
