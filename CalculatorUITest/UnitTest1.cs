using NUnit.Framework;
using NUnit.Extensions.Forms;
using CalculatorUI;
using System.Windows;
using System.Windows.Controls;

namespace CalculatorUITest
{
    [TestFixture]
    public class Tests : NUnitFormTest
    {
        MainWindow window;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            window = new MainWindow();


        }
        [Test]
        [TestCase("One", "1")]
        [TestCase("Two", "2")]
        [TestCase("Three", "3")]
        [TestCase("Four", "4")]
        [TestCase("Five", "5")]
        [TestCase("Six", "6")]
        [TestCase("Seven", "7")]
        [TestCase("Eight", "8")]
        [TestCase("Nine", "9")]

        public void Test(string name, string result)
        {
            throw new System.Exception();
            var btn = (Button)window.FindName(name);
            window.ButtonClick(btn, new RoutedEventArgs());
            Assert.AreEqual(result, ((Label)window.FindName("Equation")).Content.ToString());
        }
    }
}