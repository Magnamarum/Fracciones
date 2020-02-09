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
            var frascoAgua = new Frasco();
            frascoAgua.SumaVolumen(Tipo.Agua,(double) 1 / 2);

            var frascoZumo = new Frasco();
            frascoZumo.SumaVolumen(Tipo.Zumo, (double)1 / 2);

            var cucharada1 = frascoZumo.RestaVolumenes((double)1 / 8);
            frascoAgua.SumaVolumenes(cucharada1);

        
            var cucharada2 = frascoAgua.RestaVolumenes((double)1 / 8);
            frascoZumo.SumaVolumenes(cucharada2);

        }
    }
}
