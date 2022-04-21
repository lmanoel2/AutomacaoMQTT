using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automacao.comandos.kiper
{
    abstract class ComandoBase
    {
        DateTime DateTime { get; set; }
        public long Id { get; set; }
    }
}
