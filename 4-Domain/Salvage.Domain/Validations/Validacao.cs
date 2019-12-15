using System;
using System.Collections.Generic;
using System.Linq; 

namespace Salvage.Domain.Validations
{
    public class Validacao 
    {
        public List<string> Erros { get; private set; }
        private Validacao()
        {
            Erros = new List<string>();
        }
        public static Validacao NovoValidador()
        {
            return new Validacao();
        }

        public Validacao Quando(bool existeErro, string mensagemDeErro)
        {
            if(existeErro)
                Erros.Add(mensagemDeErro);
            return this;
        } 

        public void DispararExcessaoSeExistirErro()
        {
            if (Erros.Any())
                throw new ExcecaoDeDominio(Erros);
        } 
    }
     
    public sealed class ExcecaoDeDominio : Exception
    {
        public List<string> Mensagens { get; set; } 

        public ExcecaoDeDominio(List<string> erros) 
        {
            Mensagens = erros;
        }  
    }
}
