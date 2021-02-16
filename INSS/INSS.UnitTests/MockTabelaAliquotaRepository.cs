using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSS.UnitTests
{
    public class MockTabelaAliquotaRepository : ITabelaAliquotaRepository
    {
        private readonly TabelaAliquota[] _tabelas;

        public MockTabelaAliquotaRepository()
        {
            var aliquotas2011 = new AliquotaPercentual[]
            {
                new AliquotaPercentual(0M, 1106.90M, 8.00M),
                new AliquotaPercentual(1106.91M, 1844.83M, 9.00M),
                new AliquotaPercentual(1844.84M, 3689.66M, 11.00M)
            };
            var teto2011 = 405.86M;
            var tabelaAliquota2011 = new TabelaAliquota(2011, teto2011, aliquotas2011);

            var aliquotas2012 = new AliquotaPercentual[]
            {
                new AliquotaPercentual(0M, 1000.00M, 7.00M),
                new AliquotaPercentual(1000.01M, 1500.00M, 8.00M),
                new AliquotaPercentual(1500.01M, 3000.00M, 9.00M),
                new AliquotaPercentual(3000.01M, 4000.00M, 11.00M)
            };
            var teto2012 = 500.00M;
            var tabelaAliquota2012 = new TabelaAliquota(2012, teto2012, aliquotas2012);

            _tabelas = new TabelaAliquota[] { tabelaAliquota2011, tabelaAliquota2012 };
        }

        public TabelaAliquota ObterTabelaPorAno(int ano)
        {
            return _tabelas.FirstOrDefault(x => x.Ano == ano);
        }
    }
}
