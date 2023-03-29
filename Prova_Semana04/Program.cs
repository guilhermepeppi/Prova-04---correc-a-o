using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova_Semana04;

internal class Program
{
    private static void Main(string[] args)
    {
        int menu = 0;
        Biblioteca biblioteca = new Biblioteca();

        do
        {
            Console.WriteLine("Digite a opção desejada: ");
            Console.WriteLine("1 - Cadastrar Pessoa " +
                              "\n2 - Cadastrar Livro" +
                              "\n3 - Emprestar Livro" +
                              "\n4 - Devolver Livro" +
                              "\n5 - Listar todos os livros" +
                              "\n6 - Listar todas as pessoas cadastradas" +
                              "\n7 - Listar todos os livros emprestados");


            menu = int.Parse(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    System.Console.WriteLine("Digite o ID da pessoa: ");
                    int id = int.Parse(Console.ReadLine());

                    if (biblioteca.ConsultarPessoasPorId(id) != null)
                    {
                        System.Console.WriteLine("Pessoa já cadastrada!");
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine("Digite o nome da pessoa: ");
                        string nome = Console.ReadLine();
                        System.Console.WriteLine("Digite o CPF da pessoa: ");
                        string cpf = Console.ReadLine();
                        System.Console.WriteLine("Digite o telefone da pessoa: ");
                        string telefone = Console.ReadLine();

                        Pessoa pessoa = new Pessoa(id, nome, cpf, telefone);
                        biblioteca.CadastrarPessoa(pessoa);
                    }
                    break;

                case 2:
                    System.Console.WriteLine("Digite o ID do livro: ");
                    int idLivro = int.Parse(Console.ReadLine());

                    if (biblioteca.ConsultarLivrosPorId(idLivro) != null)
                    {
                        System.Console.WriteLine("Livro já cadastrado!");
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine("Digite o título do livro: ");
                        string titulo = Console.ReadLine();
                        System.Console.WriteLine("Digite o autor do livro: ");
                        string autor = Console.ReadLine();
                        System.Console.WriteLine("Digite a editora do livro: ");
                        string editora = Console.ReadLine();
                        System.Console.WriteLine("Digite a quantidade de exemplares: ");
                        int quantidade = int.Parse(Console.ReadLine());

                        Livros livro = new Livros(idLivro, titulo, autor, editora, quantidade);
                        biblioteca.CadastrarLivro(livro);
                    }
                    break;

                case 3:
                    System.Console.WriteLine("Digite o ID da pessoa: ");
                    int idPessoa = int.Parse(Console.ReadLine());
                    System.Console.WriteLine("Digite o ID do livro: ");
                    int idLivroEmprestado = int.Parse(Console.ReadLine());
                    System.Console.WriteLine("Digite a quantidade de exemplares emprestados: ");
                    int quantidadeEmprestada = int.Parse(Console.ReadLine());
                    biblioteca.EmprestarLivroBiblioteca(idPessoa, idLivroEmprestado, quantidadeEmprestada);
                    break;

                case 4:
                    System.Console.WriteLine("Digite o ID da pessoa: ");
                    int idPessoaDevolucao = int.Parse(Console.ReadLine());
                    System.Console.WriteLine("Digite o ID do livro: ");
                    int idLivroDevolucao = int.Parse(Console.ReadLine());
                    System.Console.WriteLine("Digite a quantidade de exemplares devolvidos: ");
                    int quantidadeDevolvida = int.Parse(Console.ReadLine());
                    biblioteca.DevolverLivroBiblioteca(idPessoaDevolucao, idLivroDevolucao, quantidadeDevolvida);
                    break;

                case 5:
                    biblioteca.ImprimirRelatorioLivros();
                    Console.ReadKey();
                    break;
                case 6:
                    biblioteca.ImprimirRelatorioPessoas();
                    Console.ReadKey();
                    break;
                case 7:
                    biblioteca.ImprimirLivrosEmprestados();
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
        } while (menu > 0 && menu < 8);
    }

}
