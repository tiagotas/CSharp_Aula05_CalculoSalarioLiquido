using System;
using System.Transactions;

namespace Aula05_CalculoSalarioLiquido
{
    class Program
    {
        static void Main(string[] args)
        {
            string nome;
            double salario_bruto = 0;
            double salario_descontado_inss = 0;

            double valor_descontado_inss = 0;
            double valor_descontado_irpf = 0;

            double salario_liquido = 0;

            string aliquota_inss = "", aliquota_irpf = "";





            Console.WriteLine("Bem-vindo ao Sistema de Cálculo de Salário Liquido");
            
            Console.WriteLine("Olá, qual é o seu nome: ");
            nome = Console.ReadLine();

            Console.WriteLine("Digite seu salário bruto:");
            salario_bruto = Convert.ToDouble(Console.ReadLine());



            // Calculando o INSS
            if(salario_bruto <= 1045)
            {
                valor_descontado_inss = salario_bruto * (7.5 / 100);
                aliquota_inss = "7,5% de INSS";

            } else if(salario_bruto >= 1045.01 && salario_bruto <= 2089.6)
            {
                valor_descontado_inss = salario_bruto * 0.09;
                aliquota_inss = "9% de INSS";

            } else if(salario_bruto >= 2086.61 && salario_bruto <= 3134.40)
            {
                valor_descontado_inss = salario_bruto * (12.0 / 100);
                aliquota_inss = "12% de INSS";

            } else if(salario_bruto >= 3134.41 && salario_bruto <= 6101.06)
            {
                valor_descontado_inss = salario_bruto * (14.0 / 100);
                aliquota_inss = "14% de INSS";
            }


            // Calculando o salário já descontado o valor do INSS.
           // salario_descontado_inss = salario_bruto - valor_descontado_inss;

            // descontando a parte isenta
            salario_descontado_inss = salario_bruto - 1903.98;


            // Calcular o IRPF (Imposto do Renda)
            if (salario_descontado_inss <= 1903.98)
            {
                valor_descontado_irpf = salario_descontado_inss * 0.0;
                aliquota_irpf = "Isento";

            } else if(salario_descontado_inss >= 1903.99 && salario_descontado_inss <= 2826.65)
            {
                valor_descontado_irpf = salario_descontado_inss * (7.5 / 100);
                aliquota_irpf = "7,5% de IRPF";

            } else if(salario_descontado_inss >= 2826.66 && salario_descontado_inss <= 3751.05)
            {
                valor_descontado_irpf = salario_descontado_inss * (15.0 / 100);
                aliquota_irpf = "15% de IRPF";

            } else if(salario_descontado_inss >= 3751.06 && salario_descontado_inss <= 4664.68)
            {
                valor_descontado_irpf = salario_descontado_inss * (22.5 / 100);
                aliquota_irpf = "22,5% de IRPF";

            } else if(salario_descontado_inss > 4664.68)
            {
                valor_descontado_irpf = salario_descontado_inss * (27.5 / 100);
                aliquota_irpf = "27,5% de IRPF";
            }



            // Calculando o salario liquido descontado o IRPF.
            salario_liquido = salario_descontado_inss - valor_descontado_irpf;

            Console.WriteLine("Seu salário bruto é: " + salario_bruto);
            Console.WriteLine("Desconto INSS: " + aliquota_inss + " no valor de: " + valor_descontado_inss);
            Console.WriteLine("Desconto IRPF: " + aliquota_irpf + " no valor de: " + valor_descontado_irpf);
            Console.WriteLine("Seu salário na conta será de " + salario_liquido);


            Console.ReadKey();
        }
    }
}
