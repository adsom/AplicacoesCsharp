using CadastroSeries.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroSeries.Classe
{
    class SerieRepositorio : IRepositorio<Serie>
    {
        //Criação de lista que contem todas as series.
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualizar(int id, Serie entidade)
        {
            listaSerie[id] = entidade;
        }

        public void Excluir(int Id)
        {
            listaSerie[Id].Excluir();
        }

        public void Inserir(Serie entidade)
        {
            listaSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}
