using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Calculator.Interfaces
{
    public interface IPresenter
    {

        void OnCharInput(char c);

        string Input { get; set; }

        bool OnOperatorInput(Operation op);

        void OnBackspace();

        void OnEnterInput();

        bool OnNumberInput(char c);

        bool OnBracketOpen();

        bool OnBracketClose();

        (double, bool) ProcessString(string s);

        void ClearAll();

    }
}
