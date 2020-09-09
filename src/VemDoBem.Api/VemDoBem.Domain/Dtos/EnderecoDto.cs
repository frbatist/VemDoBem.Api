namespace VemDoBem.Domain.Dtos
{

    public class EnderecoDto : DtoBase
    {
        public string Cep { get; set; }
        public string Rua { get; set; }
        public short? Numero { get; set; }
        public string Uf { get; set; }
        public string Municipio { get; set; }
    }
}
