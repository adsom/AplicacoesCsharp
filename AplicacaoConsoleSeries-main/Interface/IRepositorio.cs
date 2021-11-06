using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroSeries.Interface
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Inserir(T entidade);
        void Excluir(int Id);
        void Atualizar(int Id, T entidade);
        int ProximoId();
    }
}
