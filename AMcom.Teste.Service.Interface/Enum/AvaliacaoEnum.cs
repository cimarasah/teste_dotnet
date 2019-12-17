using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AMcom.Teste.Service.Interface.Enum
{
    public enum AvaliacaoEnum
    {
        [Description("Desempenho muito acima da média")]
        MuitoAcimaMedia = 1,
        [Description("Desempenho acima da média")]
        AcimaDaMedia = 2,
        [Description("Desempenho mediano ou um pouco abaixo da média")]
        MedianoOuPoucoAbaixoMedia = 3
    }
}
