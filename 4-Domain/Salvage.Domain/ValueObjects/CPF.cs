using Salvage.Domain.Helpers; 

namespace Salvage.Domain.ValueObjects
{
    public class CPF
    {
        public const int ValorMaxCpf = 11;
        public string Codigo { get; private set; }

        protected CPF()
        {

        }

        public CPF(string cpf)
        {
            Codigo = cpf;
        }

        public static string CpfLimpo(string cpf)
        {
            cpf = TextoHelper.GetNumeros(cpf);

            if (string.IsNullOrEmpty(cpf))
                return "";

            while (cpf.StartsWith("0"))
                cpf = cpf.Substring(1);

            return cpf;
        }


        public string GetCpfCompleto()
        {
            var cpf = Codigo.ToString();

            if (string.IsNullOrEmpty(cpf))
                return "";

            while (cpf.Length < 11)
                cpf = "0" + cpf;

            return cpf;
        }

        public static bool Validar(string cpf)
        {
            if (cpf.Length > 11)
                return false;

            while (cpf.Length != 11)
                cpf = '0' + cpf;

            var igual = true;
            for (var i = 1; i < 11 && igual; i++)
                if (cpf[i] != cpf[0])
                    igual = false;

            if (igual || cpf == "12345678909")
                return false;

            var numeros = new int[11];

            for (var i = 0; i < 11; i++)
                numeros[i] = int.Parse(cpf[i].ToString());

            var soma = 0;
            for (var i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            var resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }
    }
}
