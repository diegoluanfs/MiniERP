using System;
using System.Text.RegularExpressions;

namespace MiniERP.Tools
{
    public class Sanitize
    {
        public string ClearString(string phrase)
        {
            Regex regex = new Regex("^[a-zA-Z]*$");

            if (!regex.IsMatch(phrase))
            {
                throw new ArgumentException("A string contém caracteres inválidos. Apenas letras são permitidas.");
            }

            return phrase;
        }
    }
}
