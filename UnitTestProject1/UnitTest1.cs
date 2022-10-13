using CalculatorUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;
using System.Windows.Controls;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        MainWindow window;
        public UnitTest1()
        {
            window = new MainWindow();

        }

        [DataTestMethod]
        [DataRow("One", "1")]
        [DataRow("Two", "2")]
        [DataRow("Three", "3")]
        [DataRow("Four", "4")]
        [DataRow("Five", "5")]
        [DataRow("Six", "6")]
        [DataRow("Seven", "7")]
        [DataRow("Eight", "8")]
        [DataRow("Nine", "9")]
        public void Test(string name, string result)
        {
            var btn = (Button)window.FindName(name);
            window.ButtonClick(btn, new RoutedEventArgs());
            Assert.AreEqual(result, ((Label)window.FindName("Equation")).Content.ToString());
        }
    }
}
