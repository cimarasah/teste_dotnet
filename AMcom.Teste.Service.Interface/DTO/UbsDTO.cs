using AMcom.Teste.Service.Interface.Enum;

namespace AMcom.Teste.Service.Interface.DTO
{
    public class UbsDTO
    {
        // Esta classe deve conter as seguintes propriedades:
        // Nome, Endereco e Avaliacao
        public string Nome { get; set; }
        public string DscEndereco { get; set; }
        public AvaliacaoEnum Avaliacao { get; set; }
    }
}
