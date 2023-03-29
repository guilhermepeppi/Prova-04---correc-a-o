using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova_Semana04;

internal class Biblioteca
{
    //Atributos
    private List<Pessoa> ListaPessoas { get; set; }
    private List<Livros> ListaLivros { get; set; }


    //Métodos:
    public void CadastrarPessoa(Pessoa pessoa)
    {
        if (ListaPessoas == null)
            ListaPessoas = new List<Pessoa>();
        ListaPessoas.Add(pessoa);
    }

    public void CadastrarLivro(Livros livros)
    {
        if (ListaLivros == null)
            ListaLivros = new List<Livros>();
        ListaLivros.Add(livros);
    }

    public void EmprestarLivroBiblioteca(int idLivro, int idPessoa, int quantidadeEmprestada)
    {
        //Encontrar a pessoa
        //Encontrar o livro
        //Adicionar na lista pessoa o livro que foi emprestado
        //Diminuir a quantidade de exemplares do livro

        Pessoa pessoa = ListaPessoas.Where(pessoa => pessoa.ObterIdPessoa() == idPessoa).FirstOrDefault();
        if (pessoa != null)
        {
            Livros livro = ListaLivros.Where(livro => livro.ObterIdLivro() == idLivro).FirstOrDefault();
            if (livro != null)
            {
                pessoa.AdicionarLivroLista(livro);
                livro.EmprestarLivro(quantidadeEmprestada);
            }
        }
    }

    public void DevolverLivroBiblioteca(int idLivro, int idPessoa, int quantidadeDevolvida)
    {
        //Encontrar a pessoa
        //Encontrar o livro
        //Remover na lista pessoa o livro que foi emprestado
        //Aumentar a quantidade de exemplares do livro

        Pessoa pessoa = ListaPessoas.Where(pessoa => pessoa.ObterIdPessoa() == idPessoa).FirstOrDefault();
        if (pessoa != null)
        {
            pessoa.RemoverLivroLista(idLivro);

            Livros livro = ListaLivros.Where(livro => livro.ObterIdLivro() == idLivro).FirstOrDefault();
            if (livro != null)
            {

                livro.EmprestarLivro(quantidadeDevolvida);
            }
        }
    }

    public Livros ConsultarLivrosPorId(int id)
    {
        Livros livro = ListaLivros.Where(livro => livro.ObterIdLivro() == id).FirstOrDefault();
        return livro;
    }

    public Pessoa ConsultarPessoasPorId(int id)
    {
        Pessoa pessoa = ListaPessoas.Where(pessoa => pessoa.ObterIdPessoa() == id).FirstOrDefault();
        return pessoa;
    }

    public void ImprimirRelatorioLivros()
    {
        if (ListaLivros != null)
        {
            foreach (var livros in ListaLivros)
            {
                System.Console.WriteLine($"ID: {livros.ObterIdLivro()} - Nome: {livros.ObterNomeLivro()}");
            }
        }
    }

    public void ImprimirRelatorioPessoas()
    {
        if (ListaPessoas != null)
        {
            foreach (var pessoa in ListaPessoas)
            {
                System.Console.WriteLine($"ID: {pessoa.ObterIdPessoa()} - Nome: {pessoa.ObterNomePessoa()}");
            }
        }
    }

    public void ImprimirLivrosEmprestados()
    {
        if (ListaPessoas != null)
        {
            foreach (var pessoa in ListaPessoas)
            {
                if (pessoa.ObterLivrosEmprestados().Count() > 0 && pessoa.ObterLivrosEmprestados() != null)
                {
                    foreach (var livro in pessoa.ObterLivrosEmprestados())
                    {
                        System.Console.WriteLine($"ID: {pessoa.ObterIdPessoa()} - Nome: {pessoa.ObterNomePessoa()}");

                        System.Console.WriteLine($"ID: {livro.ObterIdLivro()} - Nome: {livro.ObterNomeLivro()}");
                    }
                }
            }
        }
    }


}

