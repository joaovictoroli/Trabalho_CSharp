using System;
using System.Threading;
using System.Globalization;
using Microsoft.VisualBasic;
using System.Linq.Expressions;
using System.Reflection;
using System.IO;
using System.Text;
using System.Threading.Channels;
using System.Collections;

//Trabalho realizado por João Victor Fagundes de Oliveira da turma de ADS
//O diretorio está dentro da bin/Debug/netcoreapp3.1

namespace Trabalho_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var diretorio = "dir";
            Directory.CreateDirectory(diretorio);
            var nomeArquivo = "Texto.csv";
            var caminhoArquivo = Path.Combine(diretorio, nomeArquivo);
            //var linhas = File.ReadAllLines(caminhoArquivo);
            var csv = new StringBuilder();
            String[] arrayNomes = new string[10];
            String[] arraySobrenome = new string[10];
            DateTime[] arrayNascimento = new DateTime[10];
            String[] arrayAniversariante = new string[10];
            String[] arrayNascimento2 = new string[10];
            arrayNomes[0] = "PYKE";
            arraySobrenome[0] = "CAPTAIN";
            arrayNascimento[0] = DateTime.Today;
            arrayNascimento2[0] = arrayNascimento[0].ToString("dd/MM/yyyy");
            DateTime agora = DateTime.Today; 
            int contador = 1;
            string nome = null;
            string sobrenome = null;
            DateTime Aniversario;
            string agoraaniversariante2 = agora.ToString("dd/MM/yyyy");
            string agoraaniversariante = agora.ToString("dd/MM");
        home:
            Console.Clear();
            int contador5 = 0;
            csv.Clear();
            csv.AppendLine("Nome;Sobrenome;Data de Nascimento");
            do
            {
                csv.Append(arrayNomes[contador5]);
                csv.Append(";");
                csv.Append(arraySobrenome[contador5]);
                csv.Append(";");
                csv.Append(arrayNascimento2[contador5]);
                csv.Append(";");
                csv.AppendLine();
                File.WriteAllText(caminhoArquivo, csv.ToString());
                contador5 = contador5 + 1;
            } while (contador5 < contador);
            //Console.WriteLine(csv.ToString());
            //File.WriteAllText(caminhoArquivo, csv.ToString());
            Console.WriteLine("Gerenciador de Aniversários");
            Console.WriteLine("Dia de hoje " + agoraaniversariante2 + ".");
            int contador4 = 0;
            do
            {
                arrayAniversariante[contador4] = arrayNascimento[contador4].ToString("dd/MM");
                if (agoraaniversariante == arrayAniversariante[contador4])
                {
                    Console.WriteLine("O aniversariante do dia é o " + arrayNomes[contador4] + ".");
                }
                    contador4 = contador4 + 1;
            } while (contador4 < contador);
            Console.WriteLine("");
            Console.WriteLine("Selecione uma das opções abaixo:");
            Console.WriteLine("1- Adicionar nova pessoa");
            Console.WriteLine("2- Pesquisar Pessoas");
            Console.WriteLine("3- Editar Pessoas");
            Console.WriteLine("4- Excluir Pessoas");
            Console.Write("5- Sair   Ação: ");
            int optionhome = Convert.ToInt32(Console.ReadLine()); 
            switch (optionhome)
            {
                case 1:
                adicionar:
                    Console.Clear();
                    Console.Write("Digite o nome da pessoa: ");
                    nome = Console.ReadLine();
                    Console.Write("Digite o sobrenome: ");
                    sobrenome = Console.ReadLine();
                    Console.Write("Digite a data de nascimento : ");
                    Aniversario = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Você adicinou os valores corretos?");
                    Console.Write("1- Sim    2- Não    Ação: ");
                    int optionadicionar = int.Parse(Console.ReadLine());
                    if (optionadicionar == 1)
                    {

                        Console.WriteLine("Você adicionou com sucesso.");
                        arrayNomes[contador] = nome;
                        arrayNomes[contador] = arrayNomes[contador].ToUpper();
                        //csv.AppendLine(arrayNomes[contador]);
                        arraySobrenome[contador] = sobrenome;
                        arraySobrenome[contador] = arraySobrenome[contador].ToUpper();
                        arrayNascimento[contador] = Aniversario;
                        arrayNascimento2[contador] = arrayNascimento[contador].ToString("dd/MM/yyyy");
                        Thread.Sleep(2000);
                        contador = contador + 1;
                        goto home;
                    }
                    else
                    {
                        Console.WriteLine("Você não adicionou com sucesso.");
                        Thread.Sleep(2000);
                        goto adicionar;
                    }
                case 2:
                    Console.Clear();
                    Console.Write("Digite o NOME ou DATA DE NASCIMENTO que deseja procurar: ");
                    string resultado = Console.ReadLine();
                    resultado = resultado.ToUpper();
                    string resultado2 = "não encontrou";
                    int contador3 = 0;
                pesquisar:
                    do
                        {
                        DateTime aniversario = new DateTime(agora.Year, arrayNascimento[contador3].Month, arrayNascimento[contador3].Day);
                        if (aniversario < agora)
                        {
                            aniversario = aniversario.AddYears(1);
                        }
                        int tempoAniversario = (aniversario - agora).Days;

                        if (!(arrayNomes[contador3] != null 
                            && arrayNascimento2[contador3] != null 
                            && arraySobrenome[contador3] != null))
                        {
                            Console.WriteLine("A pesquisa rodou e " + resultado2 + " resultado(s).");
                            Thread.Sleep(5000);
                            break;
                        } if 
                            (arrayNomes[contador3].Contains(resultado) == true
                            || arraySobrenome[contador3].Contains(resultado) == true
                            || arrayNascimento2[contador3].Contains(resultado) == true
                            )
                        {
                            Console.WriteLine("Pessoa encontrada");
                            Console.WriteLine("Nome: " + arrayNomes[contador3]);
                            Console.WriteLine("Sobrenome: " + arraySobrenome[contador3]);
                            Console.WriteLine("Data de nascimento: " + arrayNascimento2[contador3]);
                            Console.WriteLine("Faltam " + tempoAniversario + " dias para o aniversário.");
                            Console.WriteLine("");
                            contador3 = contador3 + 1;
                            resultado2 = "encontrou";
                            goto pesquisar;
                        } 
                        contador3 = contador3 + 1;
                    } while (contador3 < contador);
                    //if (contador3 == contador)
                    //{
                      //  Console.WriteLine("A pesquisa rodou e " + resultado2 + " resultado(s).");
                        //Thread.Sleep(5000);
                        //goto home;
                    //} 
                        goto home;
                case 3:
                    Console.Clear();
                    int contador2 = 0;
                    int numero2 = 1;
                    int opcaoeditar = 1;
                    int opcaoeditar2 = 0;
                    string editarnome = null;
                    DateTime editarnascimento;
                    string editarsobrenome = null;
                    if (!(arrayNomes[0] != null
                        && arraySobrenome[0] != null
                        && arrayNascimento2[0] != null))
                        {
                        Console.WriteLine("Não há o que pesquisar, tente adicionar alguma pessoa.");
                        Thread.Sleep(5000);
                        goto home;
                        }
                    do
                    {
                        Console.WriteLine(numero2 + "º nome é " + arrayNomes[contador2]);
                        contador2 = contador2 + 1;
                        numero2 = numero2 + 1;
                    } while (contador2 < contador);
                    Console.Write("Qual é o número referente ao nome que voce deseja editar?   Ação: ");
                    opcaoeditar = int.Parse(Console.ReadLine());
                    opcaoeditar2 = opcaoeditar - 1;
                    Console.WriteLine(opcaoeditar + "º NOME: " + arrayNomes[opcaoeditar2]);
                    Console.WriteLine(opcaoeditar + "º SOBRENOME: " + arraySobrenome[opcaoeditar2]);
                    Console.WriteLine(opcaoeditar + "º DATA NASCIMENTO: " + arrayNascimento2[opcaoeditar2]);
                    Console.Write("Novo nome: ");
                    editarnome = Console.ReadLine();
                    Console.Write("Novo sobrenome? ");
                    editarsobrenome = Console.ReadLine();
                    Console.Write("Nova data de nascimento:");
                    editarnascimento = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("NOME: " + editarnome.ToUpper());
                    Console.WriteLine("SOBRENOME: " + editarsobrenome.ToUpper());
                    Console.WriteLine("DATA DE NASCIMENTO: " + editarnascimento.ToString("dd/MM/yyyy"));
                    Console.WriteLine("Você tem certeza que digitou certo?");
                    Console.Write("1- Sim    2- Não    Ação: ");
                    int opçaoeditar3 = int.Parse(Console.ReadLine());
                    if (opçaoeditar3 == 1)
                    {
                        arrayNomes[opcaoeditar2] = editarnome.ToUpper();
                        arraySobrenome[opcaoeditar2] = editarsobrenome.ToUpper();
                        arrayNascimento[opcaoeditar2] = editarnascimento;
                        arrayNascimento2[opcaoeditar2] = editarnascimento.ToString("dd/MM/yyyy");
                        Console.Write("Você editou com sucesso.");
                        Thread.Sleep(2000);
                    } else if (opçaoeditar3 == 2)
                    {
                        Console.WriteLine("Você não editou com sucesso.");
                        Thread.Sleep(2000);
                    }
                    goto home;
                case 4:
                    Console.Clear();
                    numero2 = 1;
                    int contador6 = 0;
                    do
                    {
                        Console.WriteLine(numero2 + "º nome é " + arrayNomes[contador6]);
                        contador6 = contador6 + 1;
                        numero2 = numero2 + 1;
                    } while (contador6 < contador);
                    Console.Write("Qual é o número referente ao nome que voce deseja editar?   Ação: ");
                    int opcaoexcluir = int.Parse(Console.ReadLine());
                    int opcaoexcluir2 = opcaoexcluir - 1;
                    int opcaoexcluir3 = opcaoexcluir2 + 1;
                    arrayNomes[opcaoexcluir2] = null;
                    arraySobrenome[opcaoexcluir2] = null;
                    arrayNascimento[opcaoexcluir2] = new DateTime();
                    arrayNascimento2[opcaoexcluir2] = null;
                    int numero3 = contador - 1;
                    bool v = numero3 >= opcaoexcluir2;
                    if (v)
                    {
                        do
                        {
                            arrayNomes[opcaoexcluir2] = arrayNomes[opcaoexcluir3];
                            arraySobrenome[opcaoexcluir2] = arraySobrenome[opcaoexcluir3];
                            arrayNascimento[opcaoexcluir2] = arrayNascimento[opcaoexcluir3];
                            arrayNascimento2[opcaoexcluir2] = arrayNascimento2[opcaoexcluir3];
                            opcaoexcluir2 = opcaoexcluir2 + 1;
                            opcaoexcluir3 = opcaoexcluir3 + 1;
                        } while (opcaoexcluir3 < contador);
                        arrayNomes[opcaoexcluir2] = null;
                        arraySobrenome[opcaoexcluir2] = null;
                        arrayNascimento[opcaoexcluir2] = new DateTime();
                        arrayNascimento2[opcaoexcluir2] = null;
                        contador = contador - 1;
                    }
                    Console.WriteLine("Opção " + opcaoexcluir + " excluida com sucesso.");
                    Thread.Sleep(2000);
                    goto home;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Você saiu com sucesso. Aguarde o programa fechar.");
                    Thread.Sleep(2000);
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Você Digitou o valor inválido, por favor tente novamente.");
                    Thread.Sleep(3000);
                    goto home;
            }
        }
}
}