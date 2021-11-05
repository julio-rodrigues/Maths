using System;

namespace Maths.Comum.INSS {
    public static class Salario {
        public static double CalcularINSS(int AnoVigencia, double Salario = 0) {
            double retorno;

            retorno = Salario switch {
                _ when Salario <= 1100 => Salario * 7.5 / 100,
                _ when Salario >= 1100.01 && Salario <= 2203.48 => ((Salario - 1100.01) * 9 / 100) + 82.50,
                _ when Salario >= 2203.49 && Salario <= 3305.22 => ((Salario - 2203.49) * 12 / 100) + 181.81,
                _ when Salario >= 3305.23 && Salario <= 6433.57 => ((Salario - 3305.23) * 14 / 100) + 314.02,
                _ when Salario > 6433.57 => 751.99,
                _ => 0
            };

            return Math.Round(retorno, 2);
        }
    }

}