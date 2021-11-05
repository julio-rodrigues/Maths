using System;

namespace Maths.Comum.IRPF {
    public static class Salario {
        public static double CalcularIRPF(int AnoVigencia, double Salario = 0, double QuantidadeDependentes = 0) {
            double retorno;
            double parcelaPorDepente = 189.59;

            Salario -= INSS.Salario.CalcularINSS(2020, Salario);

            retorno = Salario switch {
                _ when Salario >= 1903.99 && Salario <= 2826.65 => ((Salario - 1903.99) * 7.5 / 100) - (QuantidadeDependentes * parcelaPorDepente),
                _ when Salario >= 2826.66 && Salario <= 3751.05 => ((Salario - 2826.66) * 15 / 100) - (QuantidadeDependentes * parcelaPorDepente) + 69.20,
                _ when Salario >= 3751.06 && Salario <= 4664.68 => ((Salario - 3751.06) * 22.5 / 100) - (QuantidadeDependentes * parcelaPorDepente) + 207.86,
                _ when Salario >= 4664.69  => ((Salario - 4664.69) * 27.5 / 100) - (QuantidadeDependentes * parcelaPorDepente) + 413.42,
                _ => 0
            };

            return Math.Round(retorno, 2);
        }
    }
}
