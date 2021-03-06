namespace Klammerung.Marco
{
    public class AndFormula : IFormula
    {
        private readonly IFormula left;
        private readonly IFormula right;

        public AndFormula(IFormula left, IFormula right)
        {
            this.left = left;
            this.right = right;
        }
        
        public string FormulaString()
        {
            return $"({left.FormulaString()} AND {right.FormulaString()})";
        }
    }
}