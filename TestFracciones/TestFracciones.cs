using Fracciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestFracciones
{
    [TestClass]
    public class TestFracciones
    {
        [TestMethod]
        public void TestMedioLitroZumoYAgua()
        {
            // Añadimos medio litro de agua al frasco 1
            var frasco1 = new Frasco();
            frasco1.SumaVolumen(Tipo.Agua,(double) 1 / 2);

            // Añadimos medio litro de zumo al frasco 2
            var frasco2 = new Frasco();
            frasco2.SumaVolumen(Tipo.Zumo, (double)1 / 2);
            
            // Cogemos una cucharada de 1/8 de litro del frasco 2 y la llevamos al frasco 1
            var cucharada1 = frasco2.RestaVolumenes((double)1 / 8);
            frasco1.SumaVolumenes(cucharada1);


            // Cogemos una cucharada de 1/8 de litro del frasco 1 y la llevamos al frasco 2
            var cucharada2 = frasco1.RestaVolumenes((double)1 / 8);
            frasco2.SumaVolumenes(cucharada2);

            // Comprobamos si las cantidades de agua en zumo y zumo en agua son las mismas
            Assert.AreEqual(frasco1.VolumenPorTipoDelFrasco[Tipo.Agua], frasco2.VolumenPorTipoDelFrasco[Tipo.Zumo]);
            Assert.AreEqual(frasco1.VolumenPorTipoDelFrasco[Tipo.Zumo], frasco2.VolumenPorTipoDelFrasco[Tipo.Agua]);

        }
    }
}
