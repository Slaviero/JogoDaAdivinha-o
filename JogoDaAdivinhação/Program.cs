using System.Xml;

namespace JogoDaAdivinhação
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random valorAleatorio = new Random();
            int valorSistema = valorAleatorio.Next(1, 20);

            string saudacao = "------------------------------------\nBem-vindo(a) ao jogo da adivinhação!\n------------------------------------";
            Console.WriteLine(saudacao);
            Console.Write("\nEscolha o Nivel de dificuldade: \n(1) Fácil (2) Médio (3) Difícil\nEscolha: ");
            string dificuldade = Console.ReadLine();

            int tentativas = 0;
            int pontuacao = 1000;
            int reducaoPontuacao = 0;

            switch (dificuldade)
            {
                case "1": tentativas = 15; break;
                case "2": tentativas = 10; break;
                case "3": tentativas = 5; break;
            }
            
            Console.Clear();
            Console.WriteLine(saudacao);
            Console.WriteLine("\nO sistema pensou em um numero de 1 a 20!\nAdivinhe qual é!");
            for (int i = 1; i <= tentativas; i++)
            {
                Console.WriteLine("\n------------------------------------");
                Console.Write($"Você tem {pontuacao} pontos.\nTentativa {i} de {tentativas}\nAdivinhe o valor: ");
                int valorUsuario = int.Parse(Console.ReadLine());

                
                    if (valorUsuario > 20 || valorUsuario < 1)
                    {
                        Console.Write($"\n{valorUsuario}, está fora da faixa de valor permitida! Tentativa invalidada.");
                        continue;
                    }
                    else if (valorUsuario > valorSistema)
                    {
                        Console.Write("\nErrou! Deveria ter digitado um valor menor!");
                        reducaoPontuacao = Math.Abs((valorUsuario - valorSistema) / 2);
                        pontuacao = pontuacao - reducaoPontuacao;
                    }
                    else if (valorUsuario < valorSistema)
                    {
                        Console.Write("\nErrou! Deveria ter digitado um valor maior!");
                        reducaoPontuacao = Math.Abs((valorUsuario - valorSistema) / 2);
                        pontuacao = pontuacao - reducaoPontuacao;
                    }
                    else if (valorUsuario == valorSistema)
                    {
                        Console.Clear();
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine($"\nParabéns! Você acertou o número!\nSua pontuação final é de {pontuacao} pontos!\nO numero aleatorio escolhido pelo sistema era: {valorSistema}.\n");
                        Console.WriteLine("------------------------------------");
                        break;
                    }
                
            }

            Console.ReadLine();

        }
    }
}
//(numero chutado – numero aleatório) / 2