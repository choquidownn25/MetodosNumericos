using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intervalo.Types
{
    /// <summary>
    /// Una clase que define un intervalo
    /// </summary>
    /// <typeparam name="T">El parámetro de tipo T se utiliza en varios lugares donde normalmente</typeparam>
    public class Intervalo<T>
    {
        /// <summary>
        /// Clase Generica para inicio
        /// </summary>
        public T inicio { get; set; }
        /// <summary>
        /// Clase Generica para fin
        /// </summary>
        public T fin { get; set; }

        public Intervalo() { }
        public Intervalo(T inicio, T fin)
        {
            this.inicio = inicio;
            this.fin = fin;
        }
        public Intervalo(Intervalo<T> copia)
        {
            inicio = copia.inicio;
            fin = copia.fin;
        }
    }

}
