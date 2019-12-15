namespace Salvage.Domain.ValueObjects
{
    public class Endereco
    {
        public Endereco()
        {

        }
        public string Logradouro { get; set; }
        public string NomeLogradouro { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public Estado Estado { get; set; }

        public string JoinLogradouro()
        {
            return $"{Logradouro} {NomeLogradouro}";
        }
        public string SplitEndereco(string endereco)
        {
            return "";
        }
    }
}
