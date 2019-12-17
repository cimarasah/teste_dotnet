using System.ComponentModel;

namespace AMcom.Teste.Service.Interface.Exceptions
{
    public enum ExceptionMessages
    {
        [Description("Erro ao fazer a Importação do Arquivo")]
        ImportacaoArquivo,
        [Description("Erro ao realizar a solicitação")]
        Erro
    }
}
