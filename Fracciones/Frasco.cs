using System;
using System.Collections.Generic;
using System.Linq;

namespace Fracciones
{
    public class Frasco
    {
        // Volumen total del frasco
        public double Volumen
        {
            get
            {
                return VolumenPorTipoDelFrasco.Values.Sum();
            }
        }

        // Volumenes por tipo
        public Dictionary<Tipo, double> VolumenPorTipoDelFrasco = new Dictionary<Tipo, double>();

        // Suma de la cucharada
        public void SumaVolumenes(Dictionary<Tipo, double> valoresPorTipo)
        {
            foreach (var valorPorTipo in valoresPorTipo)
            {
                this.SumaVolumen(valorPorTipo.Key, valorPorTipo.Value);
            }
        }

        // Suma parcial (el tipo de bebida dentro de la cucharada)
        public void SumaVolumen(Tipo t, double k)
        {
            //Si el tipo de liquido ya existe lo actualizamos
            double volumenActualDelTipoEnElFrasco;
            if(this.VolumenPorTipoDelFrasco.TryGetValue(t, out volumenActualDelTipoEnElFrasco))
            {
                VolumenPorTipoDelFrasco[t] = volumenActualDelTipoEnElFrasco + k;
            }
            else
            {
                //sino lo añadimos
                this.VolumenPorTipoDelFrasco.Add(t, k);
            }
        }

        // Resta parcial (el tipo de bebida dentro de la cucharada)
        public double RestaVolumen(Tipo tipoValor, double k)
        {
            var valorSubstraido = (VolumenPorTipoDelFrasco[tipoValor] / Volumen) * k;
            return valorSubstraido;
        }

        // Resta de la cucharada
        public Dictionary<Tipo, double> RestaVolumenes(double k)
        {
            var valoresSubstraidos = new Dictionary<Tipo, double>();
            var valoresCount = VolumenPorTipoDelFrasco.Count;

            foreach(var tipoValor in VolumenPorTipoDelFrasco.Keys.ToList())
            {
                valoresSubstraidos.Add(tipoValor, RestaVolumen(tipoValor, k));
            }

            foreach(var tipoYValorSubstraidos in valoresSubstraidos)
            {

                VolumenPorTipoDelFrasco[tipoYValorSubstraidos.Key] = VolumenPorTipoDelFrasco[tipoYValorSubstraidos.Key] - tipoYValorSubstraidos.Value;
            }
            return valoresSubstraidos;
        }
    }

    public enum Tipo
    {
        Agua,
        Zumo
    }
}
