using System;

namespace Maths.Comum.IRPF {
    public static class Tabela2021 {
        public static (double salario, float percentual)                               PrimeiraFaixaSalario = (1903.99, 7.5f);
        public static (double salario, float percentual, double descontoFaixaAnterior) SegundaFaixaSalario  = (2826.66, 15f, 69.20);
        public static (double salario, float percentual, double descontoFaixaAnterior) TerceiraFaixaSalario = (3751.06, 22.5f, 207.86);
        public static (double salario, float percentual, double descontoFaixaAnterior) QuartaFaixaSalario   = (4664.69, 27.5f, 413.42);
    }
    public static class Salario {
        public static double CalcularIRPF(int AnoVigencia, double Salario = 0, double QuantidadeDependentes = 0) {
            double retorno;
            double parcelaPorDepente = 189.59;

            Salario -= INSS.Salario.CalcularINSS(2020, Salario);

            retorno = Salario switch {
                _ when Salario >= Tabela2021.PrimeiraFaixaSalario.salario && Salario < Tabela2021.SegundaFaixaSalario.salario => ((Salario - Tabela2021.PrimeiraFaixaSalario.salario) * Tabela2021.PrimeiraFaixaSalario.percentual / 100) - (QuantidadeDependentes * parcelaPorDepente),
                _ when Salario >= Tabela2021.SegundaFaixaSalario.salario && Salario < Tabela2021.TerceiraFaixaSalario.salario => ((Salario - Tabela2021.SegundaFaixaSalario.salario) * Tabela2021.SegundaFaixaSalario.percentual / 100) - (QuantidadeDependentes * parcelaPorDepente) + Tabela2021.SegundaFaixaSalario.descontoFaixaAnterior,
                _ when Salario >= Tabela2021.TerceiraFaixaSalario.salario && Salario < Tabela2021.QuartaFaixaSalario.salario => ((Salario - Tabela2021.TerceiraFaixaSalario.salario) * Tabela2021.TerceiraFaixaSalario.percentual / 100) - (QuantidadeDependentes * parcelaPorDepente) + Tabela2021.TerceiraFaixaSalario.descontoFaixaAnterior,
                _ when Salario >= Tabela2021.QuartaFaixaSalario.salario => ((Salario - Tabela2021.QuartaFaixaSalario.salario) * Tabela2021.QuartaFaixaSalario.percentual / 100) - (QuantidadeDependentes * parcelaPorDepente) + Tabela2021.QuartaFaixaSalario.descontoFaixaAnterior,
                _ => 0
            };

            return Math.Round(retorno, 2);
        }
    }
}
