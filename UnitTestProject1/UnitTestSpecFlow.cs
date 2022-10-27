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

namespace UnitTestProject1
{
    [Binding]

    class UnitTestSpecFlow
    {
        
        MainWindow window;

        [BeforeScenario("calculator")]
        [Given("Calculator is initialized")]
        public void InitCalculator()
        {
            window = new MainWindow();

        }

        [When("I press (.*)")]
        public void Press(string name)
        {
            var btn = (Button)window.FindName(name);
            btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

        }

        [Then("the result should be (.*) on the screen")]
        public void Result(string expected)
        {
            Assert.AreEqual(expected, ((Label)window.FindName("Equation")).Content.ToString());
        }
    }
}
