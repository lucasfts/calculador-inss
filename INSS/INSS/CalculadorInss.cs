using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSS
{
    public class CalculadorInss : ICalculadorInss
    {
        private readonly ITabelaAliquotaRepository _tabelaAliquotaRepository;

        public CalculadorInss(ITabelaAliquotaRepository tabelaAliquotaRepository)
        {
            _tabelaAliquotaRepository = tabelaAliquotaRepository;
        }

        public decimal CalcularDesconto(DateTime data, decimal salario)
        {
            var tabelaAnual = _tabelaAliquotaRepository.ObterTabelaPorAno(data.Year);

            var ehTeto = salario > tabelaAnual.AliquotasPercentuais.Max(x => x.Maximo);

            if (ehTeto)
                return tabelaAnual.ValorTeto;

            var aliquotaPercentual = tabelaAnual.AliquotasPercentuais
                .FirstOrDefault(x => salario >= x.Minimo && salario <= x.Maximo);

            return (aliquotaPercentual.Porcentagem / 100) * salario;
        }
    }
}
