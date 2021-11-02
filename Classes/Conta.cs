using System;

namespace DIO.Bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            //Validação de saldo suficiente (Saldo menor que o negativo do crédito)
            //Exemplo: 1000,00 de saldo e 500,00 de crédito -> podesrá sacar 1500,00
            //Ao tentar sacar 1501,00 o alerta será exibido
            if (this.Saldo - valorSaque < (this.Credito *-1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;

            //Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            //Formatação composta da string:
            //https://dosc.microsoft.com/pt-br/dotnet/standard/base-types/composite-formating

            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");

            return true;
        }

        public void Depositar (double valorDeposito)
        {
            this.Saldo += valorDeposito;

            //Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = String.Empty;
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito;
            return retorno;
        }
    }
}