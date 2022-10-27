﻿using CalculatorUI;
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



    [Binding]

    class SpecFlowTest
    {
        public string CharToName(char c)
        {
            switch (c)
            {

                case '0': return "Zero";
                case '1': return "One";
                case '2': return "Two";
                case '3': return "Three";
                case '4': return "Four";
                case '5': return "Five";
                case '6': return "Six";
                case '7': return "Seven";
                case '8': return "Eight";
                case '9': return "Nine";
                case '.': return "Dot";
                default:
                    throw new ArgumentException("Unknown char");
            }
        }

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
        public void TypeNumber(decimal number)
        {
            foreach (char c in number.ToString())
            {
                var btn = (Button)window.FindName(CharToName(c));
                btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        [Then("the result should be (.*) on the screen")]
        public void Result(decimal expected)
        {
            Assert.AreEqual(expected.ToString(), ((Label)window.FindName("Equation")).Content.ToString());
        }


    }
}