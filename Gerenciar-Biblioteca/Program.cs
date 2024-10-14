using System.Collections.Generic;
using System.Security.Cryptography;

class Program
{
    public static void Main()
    {
        Console.Clear();
        HashSet<string> usuarios = new HashSet<string> ();
        List<int> senhas = new List<int> ();
        
        string usuarioAdm = "user.adm",
            nomeUsuario = "";

        int senhaAdm = 25072003;

        usuarios.Add(usuarioAdm);
        senhas.Add(senhaAdm);

        SigIn(usuarios,senhas);
        LogIn(ref nomeUsuario,usuarios,senhas);

    }
    public static void SigIn(HashSet<string> usuarios, List<int> senhas)
    {
        Console.Clear();
        Console.Write("Nome de usuario: ");
        nu:
        string nomeUsuario = Console.ReadLine()?.ToLower()?? "";

        if(!usuarios.Add(nomeUsuario))
        {
            Console.Clear();
            Console.Write("Nome de usuario já utilizado, escolha outro: ");
            goto nu;
        }
        
        su:
        Console.Write("Adicione uma senha númerica: ");
        if(!int.TryParse(Console.ReadLine(), out int senhaUsuario))
            goto su;

        senhas.Add(senhaUsuario);
    }
    public static bool LogIn(ref string nomeUsuario, HashSet<string> usuarios, List<int> senhas)
    {
        Console.Clear();
        us:
        Console.Write("Nome de usuario: ");
        nomeUsuario = Console.ReadLine()?.ToLower()?? "";

        if(usuarios.Add(nomeUsuario))
        {
            usuarios.Remove(nomeUsuario);
            Console.Write("Usuario não cadastrado!!!");
            Thread.Sleep(2500);
            Console.Clear();
            goto us;
        }
        else
        {
            int verificacaoPosiacao = usuarios.ToList().IndexOf(nomeUsuario);
            su:
            Console.Write("Senha: ");
            if(!int.TryParse(Console.ReadLine(), out int senhaUsuario))
                goto su;
            if(senhaUsuario == senhas[verificacaoPosiacao])
                return true;
            else
                return false;
        }
    }
    public static void AddLivro()
    {
        
    }
}