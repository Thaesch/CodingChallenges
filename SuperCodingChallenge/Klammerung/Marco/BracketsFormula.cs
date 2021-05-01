namespace Klammerung.Marco
{
    public class BracketsFormula
    {
        private readonly IFormula op;
        
        public BracketsFormula(IFormula op)
        {
            this.op = op;
        }
        
        public string FormulaString()
        {
            return $"({op.FormulaString()})";
        }
    }
}