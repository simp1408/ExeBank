using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ExeBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContoCorrente conto = new ContoCorrente();
            conto.MenuIniziale();



        }

        public class ContoCorrente
        {

            public string _nomeCorrentista { get; set; }

            public string _cognomeCorrentista { get; set; }

            private decimal _saldo = 0;

            public decimal Saldo
            {
                get { return _saldo; }
                set { _saldo = value; }

            }

            private bool _contoAperto = false;

            public bool contoAperto
            {
                get { return _contoAperto; }
                set { _contoAperto = value; }
            }


            public void ApriContoCorrente()
            {
                Console.WriteLine("inserisci nome: ");
                string Nome = Console.ReadLine();
                Console.WriteLine("inserisci cognome: ");
                string Cognome = Console.ReadLine();
                Console.WriteLine();
                Console.ReadLine();

                _nomeCorrentista = Nome;
                _cognomeCorrentista = Cognome;
                _saldo = 0;
                _contoAperto = true;


                Console.WriteLine($"Conto Corrente n:255333 intestato a:{_nomeCorrentista} {_cognomeCorrentista}");
                MenuIniziale();

            }

            public void MenuIniziale()
            {
                Console.WriteLine("=======================================");
                Console.WriteLine(" INTESA SAIMONS BANK");
                Console.WriteLine("=======================================");
                Console.WriteLine("Scegli l'operazione da effettuare");
                Console.WriteLine("1. APRI CONTO CORRENTE");
                Console.WriteLine("2. EFFETTUA VERSAMENTO");
                Console.WriteLine("3. EFFETTUA PRELEVAMENTO");
                Console.WriteLine("4. ESCI");

                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        Console.WriteLine("hai scelto il tasto 1");
                        ApriContoCorrente();
                        break;
                    case "2":
                        Console.WriteLine("hai scelto il tasoto 2");
                        Versamento();
                        break;
                    case "3":
                        Console.WriteLine("hai scelto il tasto 3");
                        Prelevamento();
                        break;
                    case "4":
                        Console.WriteLine("GRAZIE E BUONA GIORNATA");
                        MenuIniziale();
                        break;
                    default:
                        Console.WriteLine("scelta non valida");
                        break;
                }

            }

            public void Versamento()
            {
                if (_contoAperto == false)
                {
                    Console.WriteLine("Devi aprire un conto corrente se vuoi effettuare questa operazione");
                }
                else
                {
                    Console.WriteLine("digita l'mporto che vuoi versare");
                    decimal importoVersato = decimal.Parse(Console.ReadLine());
                    _saldo += importoVersato;

                    Console.WriteLine($"il tuo saldo attaule è il seguente: {_saldo.ToString("N")}");
                }

                MenuIniziale();


            }

            public void Prelevamento()
            {
                if (_contoAperto == false)
                {
                    Console.WriteLine("devi aprire un conto corrente prima di effettuare l'operazione richiesta");
                }
                else
                {
                    Console.WriteLine("digita l'importo da prelevare");
                    decimal importoPrelevamento = decimal.Parse(Console.ReadLine());
                    if (_saldo < importoPrelevamento)
                    {
                        Console.WriteLine("non puoi prelevare questa somma");
                    }
                    else
                    {
                        _saldo -= importoPrelevamento;
                        Console.WriteLine($"operazione riuscita il tuo saldo attuale è:{_saldo.ToString("N")}");
                    }

                }

                MenuIniziale();
            }


        }












    }

}
