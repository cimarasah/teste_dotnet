using AMcom.Teste.Service.Interface.Enum;

namespace AMcom.Teste.Service.Interface.DTO
{
    public class UbsDTO
    {
        // Esta classe deve conter as seguintes propriedades:
        // Nome, Endereco e Avaliacao
        public string Nome { get; set; }
        public string DscEndereco { get; set; }
        public double VlrLatitude { get; set; }
        public double VlrLongitude { get; set; }
        public AvaliacaoEnum Avaliacao { get; set; }
        public string DscBairro { get; set; }
        public string DscCidade { get; set; }
    }
}
