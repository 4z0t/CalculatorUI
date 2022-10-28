using CalculatorUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;
using System.Windows.Controls;
using Moq;
using Calculator.Interfaces;
using Calculator;
using SpecFlow.Internal;
using SpecFlow;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace UnitTestProject1
{



    [Binding, Scope(Feature = "Calculator")]

    class SpecFlowTest
    {

        MainWindow window;

        [BeforeScenario("calculator")]
        [Given("Calculator is initialized")]
        public void InitCalculator()
        {
            window = new MainWindow();

        }

        [When(@"I press (.*)")]
        public void Press(string name)
        {
            var btn = (Button)window.FindName(name);
            btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

        }


        [When(@"I type number (.*)")]
        public void TypeNumber(double number)
        {
            foreach (char c in number.ToString())
            {
                var btn = (Button)window.FindName(MainWindow.CharToName(c));
                btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        [Then("the result should be (.*) on the screen")]
        public void Result(double expected)
        {
            Assert.AreEqual(expected.ToString(), ((Label)window.FindName("Display")).Content.ToString());
        }

        [Then("the error is on screen")]
        public void Error()
        {
            Assert.AreEqual("Error", ((Label)window.FindName("Display")).Content.ToString());
        }

    }
}
