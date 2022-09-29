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

        public string Input
        { get; set; }


        public string Output
        { get; set; }

        public void DisplayChar(char c)
        {
            throw new NotImplementedException();
        }

        public void DisplayError()
        {
            throw new NotImplementedException();
        }

        public void DisplayResult(string result)
        {
            throw new NotImplementedException();
        }

        public void RemoveChar()
        {
            throw new NotImplementedException();
        }


        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Console.Write("hey");
        }
    }
}
