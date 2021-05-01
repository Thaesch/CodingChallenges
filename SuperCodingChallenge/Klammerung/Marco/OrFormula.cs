namespace Klammerung.Marco
{
    public class OrFormula : IFormula
    {
        private readonly IFormula left;
        private readonly IFormula right;

        public OrFormula(IFormula left, IFormula right)
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