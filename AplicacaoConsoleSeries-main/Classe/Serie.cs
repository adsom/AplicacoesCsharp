using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroSeries.Classe
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }

        private string  Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }

        private bool Excluido { get; set; }


        //Metodos
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        //Quando executamos o metodo acima, o ToString faz os retornos.
        public override string ToString()
        {
            //Environment interpreta como o sistema descreve uma nova linha.
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;

            return retorno;
        }
        //Proximos dois metodos seram usados para listagem.
        public string RetornaTitulo()
        {
            return this.Titulo;
        }
        public int RetornoId()
        {
            return this.Id;
        }
        public bool RetornoExcluido()
        {
            return this.Excluido;
        }

        public bool Excluir()
        {
            return this.Excluido = true;
        }
    } 
}
