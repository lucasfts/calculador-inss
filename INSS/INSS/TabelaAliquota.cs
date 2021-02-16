using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSS
{
    public class TabelaAliquota
    {
        public int Ano { get; }
        public decimal ValorTeto { get; }
        public AliquotaPercentual[] AliquotasPercentuais { get; }

        public TabelaAliquota(int ano, decimal valorTeto, AliquotaPercentual[] aliquotasPercentuais)
        {
            Ano = ano;
            ValorTeto = valorTeto;
            AliquotasPercentuais = aliquotasPercentuais;
        }
    }
}
