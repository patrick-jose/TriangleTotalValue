using System;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using TriangleTotalValue.Controllers;

namespace TriangleTotalValue.Domain
{
    public class Triangle
    {
        private ILogger<TriangleTotalValueController> _logger;

        public Triangle(string txt, ILogger<TriangleTotalValueController> logger)
        {
            this._logger = logger;

            CalculateTrianguleTotalValue(txt);
        }

        public int totalValue { get; private set; }

        void CalculateTrianguleTotalValue(string txt)
        {
            try
            {
                var lines = txt.Split('\n');

                var values = new List<int>();

                foreach (var line in lines)
                {
                    var numbers = line.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries).Select(x => new TriangleNumber(int.Parse(x)));

                    if (numbers.Count() != 1)
                    {
                        if (numbers.Count() == 2 || numbers.Count() % 2 == 0)
                            values.Add(numbers.ToList().ElementAt((numbers.Count() / 2) - 1).Value);
                        else
                            values.Add(numbers.ToList().ElementAt(numbers.Count() / 2).Value);
                    }
                    else
                        values.Add(numbers.ToList().ElementAt(numbers.Count() - 1).Value);
                }

                this.totalValue = values.Sum();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                throw;
            }
        }
    }
}

