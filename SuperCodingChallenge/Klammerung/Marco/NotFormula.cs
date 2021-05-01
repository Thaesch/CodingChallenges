namespace Klammerung.Marco
{
    public class NotFormula
    {
        private readonly IFormula op;

        public NotFormula(IFormula op)
        {
            this.op = op;
        }
        
        public string FormulaString()
        {
            return $"(! ({op.FormulaString()}))";
        }
    }
}