using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSS
{
    public class AliquotaPercentual
    {
        public decimal Minimo { get; }
        public decimal Maximo { get; }
        public decimal Porcentagem { get; }

        public AliquotaPercentual(decimal minimo, decimal maximo, decimal porcentagem)
        {
            Minimo = minimo;
            Maximo = maximo;
            Porcentagem = porcentagem;
        }
    }
}
