using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Collections;

namespace TP.Aula07Exer02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParallelOptions threadNum = new ParallelOptions();
            Console.WriteLine("Em quantas threads devo usar na execução do programa?");
            threadNum.MaxDegreeOfParallelism = Convert.ToInt32(Console.ReadLine());

            Stopwatch cronometro = Stopwatch.StartNew();

            ChamadaMetodos(threadNum);

            cronometro.Stop();

            Console.WriteLine($"Tempo de execução {(cronometro.ElapsedMilliseconds) / 1000} segundos");
            Console.ReadLine();
        }

        static void ChamadaMetodos(ParallelOptions qtdThread)
        {
            Parallel.Invoke(() => AcertarBaseDeDados(),
                            () => EnviarEmail(),
                            () => LimparArquivosTemporarios());
        }

        static void AcertarBaseDeDados()
        {
            Console.WriteLine("Iniciando acesso à base de dados");
            Thread.Sleep(3000);
            Console.WriteLine("Concluído acesso à base de dados");
        }

        static void EnviarEmail()
        {
            Console.WriteLine("Iniciando envio de email ...");
            Thread.Sleep(3500);
            Console.WriteLine("Concluído envio de email");
        }

        static void LimparArquivosTemporarios()
        {
            Console.WriteLine("Iniciando limpeza de arquivos temporários");
            Thread.Sleep(4000);
            Console.WriteLine("Concluída limpeza de arquivos temporários");
        }
    }
}
