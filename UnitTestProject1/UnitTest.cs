using CalculatorUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;
using System.Windows.Controls;
using Moq;
using Calculator.Interfaces;
using Calculator;
using SpecFlow.Internal;
using TechTalk.SpecFlow.CommonModels;


namespace UnitTestProject1
{

    [TestClass]
    public class UnitTest
    {
        MainWindow window;
        public UnitTest()
        {
            window = new MainWindow();

        }

        [DataTestMethod]
        [DataRow("Zero", "0")]
        [DataRow("One", "1")]
        [DataRow("Two", "2")]
        [DataRow("Three", "3")]
        [DataRow("Four", "4")]
        [DataRow("Five", "5")]
        [DataRow("Six", "6")]
        [DataRow("Seven", "7")]
        [DataRow("Eight", "8")]
        [DataRow("Nine", "9")]
        [DataRow("Dot", ".")]
        public void
        TestDigitClick(string name, string result)
        {


            var btn = (Button)window.FindName(name);
            btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            Assert.AreEqual(result, ((Label)window.FindName("Equation")).Content.ToString());
        }

        [TestMethod]
        public void TestClearClick()
        {
            window.Input = "2+2";
            window.Output = "2+2";
            var btn = (Button)window.FindName("Clear_Copy");
            btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            Assert.AreEqual(string.Empty, ((Label)window.FindName("Equation")).Content.ToString());
            Assert.AreEqual("0", ((Label)window.FindName("Display")).Content.ToString());
        }

        [TestMethod]
        public void TestEmptyEqualsClick()
        {
            var btn = (Button)window.FindName("Equals");
            btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            Assert.AreEqual(string.Empty, ((Label)window.FindName("Equation")).Content.ToString());
            Assert.AreEqual("0", ((Label)window.FindName("Display")).Content.ToString());
        }


        [DataTestMethod]
        [DataRow("Plus", "+")]
        [DataRow("Minus", "-")]
        [DataRow("Multiply", "*")]
        [DataRow("Divide", "/")]

        public void
       TestOpClick(string name, string result)
        {
            var btn = (Button)window.FindName(name);
            btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            Assert.AreEqual(result, ((Label)window.FindName("Equation")).Content.ToString());
        }

        [DataTestMethod]
        [DataRow("Zero", '0')]
        [DataRow("One", '1')]
        [DataRow("Two", '2')]
        [DataRow("Three", '3')]
        [DataRow("Four", '4')]
        [DataRow("Five", '5')]
        [DataRow("Six", '6')]
        [DataRow("Seven", '7')]
        [DataRow("Eight", '8')]
        [DataRow("Nine", '9')]
        [DataRow("Dot", '.')]
        public void MoqTestDigitClick(string name, char c)
        {

            var moqModel = new Mock<IModel>();
            var moqPresenter = new Mock<IPresenter>();

            window.Model = moqModel.Object;
            window.Presenter = moqPresenter.Object;
            var btn = (Button)window.FindName(name);
            btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            moqPresenter.Verify(m => m.OnCharInput(It.Is<char>(i => i == c)), Times.Once());
        }

        [TestMethod]
        public void MoqTestEqualsClick()
        {
            var moqModel = new Mock<IModel>();
            var moqPresenter = new Mock<IPresenter>();

            window.Model = moqModel.Object;
            window.Presenter = moqPresenter.Object;
            var btn = (Button)window.FindName("Equals");
            btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            moqPresenter.Verify(m => m.ProcessString(It.IsAny<string>()), Times.Once());
        }

        [TestMethod]
        public void MoqTestClearClick()
        {

            var moqModel = new Mock<IModel>();
            var moqPresenter = new Mock<IPresenter>();

            window.Model = moqModel.Object;
            window.Presenter = moqPresenter.Object;
            var btn = (Button)window.FindName("Clear_Copy");
            btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            moqPresenter.Verify(m => m.ClearAll(), Times.Once());
        }


        [DataTestMethod]
        [DataRow("Plus", '+')]
        [DataRow("Minus", '-')]
        [DataRow("Multiply", '*')]
        [DataRow("Divide", '/')]

        public void
       MoqTestOpClick(string name, char c)
        {
            var moqModel = new Mock<IModel>();
            var moqPresenter = new Mock<IPresenter>();

            window.Model = moqModel.Object;
            window.Presenter = moqPresenter.Object;
            var btn = (Button)window.FindName(name);
            btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            moqPresenter.Verify(m => m.OnCharInput(It.Is<char>(i => i == c)), Times.Once());
        }

        [DataTestMethod]
        [DataRow("1+1", 2)]
        [DataRow("2-1", 1)]
        [DataRow("2*2", 4)]
        [DataRow("2.5+3.6", 6.1)]
        public void TestOperationOn2Numbers(string input, double expected)
        {
            window.Input=input;
            window.ButtonEquals(window, new RoutedEventArgs(Button.ClickEvent));
            Assert.AreEqual(expected.ToString(),window.Output);
        }
    }
}
