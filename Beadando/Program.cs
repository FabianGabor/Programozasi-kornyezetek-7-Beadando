using System;
// ReSharper disable SuggestVarOrType_SimpleTypes

namespace Beadando
{
    /*
     * Készíts osztályt, ami egy tetszőleges karakter második előfordulását figyeli! Ha ugyanazt a karaktert kapja meg,
     * mint amit közvetlenül előtte, jelezze egy eseménnyel!
     * Készíts programot, ami a billentyűzetről karakterek leütését figyeli, és reagál a kettőzött karakterekre
     * eseményfeliratkozással!
     */

    internal class CharWatch
    {
        private char _prevChar;

        public void Check(char c)
        {
            if (c == _prevChar) DupeChar(EventArgs.Empty);
            _prevChar = c;
        }

        private void DupeChar(EventArgs e)
        {
            EventHandler handler = DupeCharHandler;
            if (handler != null) handler(this, e);
        }
        
        public event EventHandler DupeCharHandler;
    }
    
    internal static class Program
    {
        public static void Main(string[] args)
        {
            CharWatch cw = new CharWatch();
            char c;
            cw.DupeCharHandler += DupeCharHandlerMethod;
            do {
                c = Console.ReadKey().KeyChar;
                cw.Check(c);
            } while (c != (int) ConsoleKey.Enter);
        }

        private static void DupeCharHandlerMethod(object sender, EventArgs e)
        {
            Console.WriteLine("\ndupe char");
        }
    }
}