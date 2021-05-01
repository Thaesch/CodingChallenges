using System;
using System.Collections.Generic;
using System.Text;
using static Klammerung.Program;

namespace Klammerung
{
    public class TomSolution : IProcessable<string, string>
    {

        private abstract class Term
        {
        }

        private class BinaryTerm : Term
        {
            Term lContent;
            Term rContent;
            string ownContent;

            public BinaryTerm(string ownContent, Term lContent, Term rContent)
            {
                this.lContent = lContent;
                this.rContent = rContent;
                this.ownContent = ownContent;
            }

            public override string ToString()
            {
                { return $"({lContent} {ownContent} {rContent})"; }
            }
        }

        private class Atom : Term
        {
            string content;

            public Atom(string content)
            {
                this.content = content;
            }

            public override string ToString()
            {
                return $"({content})";
            }
        }

        private class SingularTerm : Term
        {
            string ownOperator;
            Term ownTerm;

            public SingularTerm(string ownOperator, Term ownTerm)
            {
                this.ownOperator = ownOperator;
                this.ownTerm = ownTerm;
            }

            public override string ToString()
            {
                return $"({ownOperator}{ownTerm})";
            }
        }

        static string[] binaryOperators = new string[] { "AND", "OR", "=>"};
        static string[] singularOperators = new string[] { "!" };

        public string Process(string input)
        {

            //Print(input);


            input = input.Replace(binaryOperators[0], ",");
            input = input.Replace(binaryOperators[1], ".");
            input = input.Replace(binaryOperators[2], "_");



            Term formula = BuildFormula(input);

            //Print(formula);
            return formula.ToString();
        }

        private Term BuildFormula(string input)
        {
            Term nextTerm = FindNextTerm(input);

            return nextTerm;

        }

        private Term FindNextTerm(string input)
        {
            List<Tuple<Tuple<string, int>, int>> operatordistance = new List<Tuple<Tuple<string, int>, int>>();
            int numBrackets = 0;
            for (int c = 0; c < input.Length; c++)
            {
                if (input[c] == '(')
                    numBrackets += 1;
                if (input[c] == ')')
                    numBrackets -= 1;

                if (input[c] == ',')
                    operatordistance.Add(new Tuple<Tuple<string, int>, int>(new Tuple<string, int>("AND", c), numBrackets));
                if (input[c] == '.')
                    operatordistance.Add(new Tuple<Tuple<string, int>, int>(new Tuple<string, int>("OR", c), numBrackets));
                if (input[c] == '_')
                    operatordistance.Add(new Tuple<Tuple<string, int>, int>(new Tuple<string, int>("=>", c), numBrackets));
                if (input[c] == '!')
                    operatordistance.Add(new Tuple<Tuple<string, int>, int>(new Tuple<string, int>("!", c), numBrackets));

            }


            operatordistance.Sort(SortTuples);


            if (operatordistance.Count > 0)
            {
                //Print($"Count: {operatordistance.Count} Name: {operatordistance[0].Item1.Item1} Index: {operatordistance[0].Item1.Item2}");
                //Print($"Left Term: {input.Substring(0, operatordistance[0].Item1.Item2)} " +
                //    $"Right Term: {input.Substring(operatordistance[0].Item1.Item2 + 1)}");

                if (operatordistance[0].Item1.Item1 != "!")
                {
                    return new BinaryTerm(
                        operatordistance[0].Item1.Item1,
                        FindNextTerm(input.Substring(0, operatordistance[0].Item1.Item2)),
                        FindNextTerm(input.Substring(operatordistance[0].Item1.Item2 + 1)));
                }
                else
                {
                    return new SingularTerm(operatordistance[0].Item1.Item1,
                        FindNextTerm(input.Substring(operatordistance[0].Item1.Item2 + 1)));
                }
            }



            return new Atom(input.Trim());
        }


        private static int SortTuples(Tuple<Tuple<string, int>, int> first, Tuple<Tuple<string, int>, int> second)
        {
            if(first == null)
            {
                if(second == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else if(second == null)
            {
                return 1;
            }
            else
            {
                if (first.Item2 > second.Item2) return 1;
                if (second.Item2 > first.Item2) return -1;



                if (first.Item1.Item1 != "!" && second.Item1.Item1 != "!")
                {
                    if (Array.IndexOf(binaryOperators, first.Item1.Item1) < Array.IndexOf(binaryOperators, second.Item1.Item1))
                        return 1;
                    if (Array.IndexOf(binaryOperators, first.Item1.Item1) > Array.IndexOf(binaryOperators, second.Item1.Item1))
                        return -1;
                }
                if (first.Item1.Item1 == "!" && second.Item1.Item1 != "!")
                    return 1;

                if (first.Item1.Item1 != "!" && second.Item1.Item1 == "!")
                    return -1;

                return 0;
            }
        }

    }
}
