namespace Klammerung.Marco
{
    public class Variable : IFormula
    {
        private readonly string literal;

        public Variable(string literal)
        {
            this.literal = literal;
        }
        public string FormulaString()
        {
            return $"({literal})";
        }
    }
}