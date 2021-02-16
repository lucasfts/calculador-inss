using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace INSS.UnitTests
{
    [TestClass]
    public class CalculadorInssTests
    {
        CalculadorInss calculador;

        [TestInitialize]
        public void Setup()
        {
            calculador = new CalculadorInss(new MockTabelaAliquotaRepository());
        }

        [TestMethod]
        [DataTestMethod]
        [DynamicData(nameof(DadosTeste))]
        public void CalcularDesconto_TabelaAnualExiste_Sucesso(DateTime data, decimal salario, decimal descontoExperado)
        {
            var desconto = calculador.CalcularDesconto(data, salario);

            Assert.AreEqual(descontoExperado, desconto);
        }

        [TestMethod]
        public void CalcularDesconto_TabelaAnualNaoExiste_Erro()
        {
            try
            {
                var desconto = calculador.CalcularDesconto(new DateTime(9999, 1, 1), 100.00M);

                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(System.NullReferenceException), ex.GetType());
            }
        }

        public static IEnumerable<object[]> DadosTeste => new List<object[]>
        {
            new object[] { new DateTime(2011, 01, 01), 1000.00M, 80.00M },
            new object[] { new DateTime(2011, 02, 05), 4000.00M, 405.86M },
            new object[] { new DateTime(2011, 12, 05), 1500.00M, 135.00M },
            new object[] { new DateTime(2012, 03, 07), 1000.00M, 70.00M },
            new object[] { new DateTime(2012, 02, 10), 4000.00M, 440.00M },
            new object[] { new DateTime(2012, 02, 10), 4100.00M, 500.00M }
        };
    }
}
