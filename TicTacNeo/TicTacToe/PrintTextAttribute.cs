using System;
using System.Reflection;

namespace TicTacToe
{
    public class PrintTextAttribute : Attribute
    {
        public string Text { get; private set; }

        public PrintTextAttribute(string text)
        {
            Text = text;
        }
    }
}