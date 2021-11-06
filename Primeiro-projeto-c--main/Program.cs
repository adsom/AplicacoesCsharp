using System;

namespace DigitalOne
{
    class Program
    {
        static void Main(string[] args)
        {
            var indice_aluno = 0;
            string opcao_usuario = Menu();
            Aluno[] alunos  = new Aluno[5];

            while (opcao_usuario != "4")
            {
                switch (opcao_usuario)
                {

                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota:");
                        if( decimal.TryParse(Console.ReadLine(), out decimal nota)){
                             aluno.Nota = nota;
                        }
                        else{
                            throw new ArgumentOutOfRangeException("O valor da nota deve ser decimal");
                        }

                        alunos[indice_aluno] = aluno;
                        indice_aluno++;
                        break;
                    case "2":
                        Console.WriteLine("--------------Lista de alunos----------------");
                        foreach(var pessoa in alunos ){
                            if(!string.IsNullOrEmpty(pessoa.Nome)){
                                Console.WriteLine($"Aluno : {pessoa.Nome} - Nota : {pessoa.Nota}");
                            }
                            
                        }
                        break;
                    case "3":
                        decimal nota_total =0;
                        var num_alunos = 0;
                        for(int i= 0; i<alunos.Length; i++){
                            if(!string.IsNullOrEmpty(alunos[i].Nome)){
                                nota_total = nota_total + alunos[i].Nota;
                                num_alunos++;
                            }
                        }

                        var media_geral = nota_total / num_alunos;
                        
                        Conceito conceitoGeral;

                        if(media_geral<2){
                            conceitoGeral = Conceito.E;
                        }
                        else if(media_geral<4){
                            conceitoGeral = Conceito.D;
                        }
                        else if(media_geral<6){
                            conceitoGeral = Conceito.C;
                        }
                        else if(media_geral<8){
                            conceitoGeral = Conceito.B;
                        }
                        else{
                            conceitoGeral = Conceito.A;
                        }
                        Console.WriteLine($" A média geral é {media_geral}, conceito geral é {conceitoGeral}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                Console.WriteLine();
                opcao_usuario = Menu();
            }
        }

        private static string Menu()
        {
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir novo aluno\n2- Listar alunos\n3- Caucular media geral\n4- Sair");
            string opcao_usuario = Console.ReadLine();
            Console.WriteLine();
            return opcao_usuario;
        }
    }
}
