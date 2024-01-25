using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Test_Eventi
{

    class Program
    {
        static void Main()
        {

            bool erroreContoBancario = true;
            decimal importoDecimalContoBancario = 0;
            while (erroreContoBancario == true)
            {
            string ? importoStringContoBancario = "";
            Console.Clear();
            Console.WriteLine("Inserisci l'importo del Conto Bancario");
            Console.WriteLine("Conto Bancario: ");


            importoStringContoBancario = Console.ReadLine();
            

            if (!string.IsNullOrEmpty(importoStringContoBancario))
                {
                    decimal.TryParse(importoStringContoBancario, out importoDecimalContoBancario);
                    erroreContoBancario = false;
                }

            else
                {
                    erroreContoBancario = true;
                    //Console.Clear();
                }
            }



            bool errorePrelievo = true;
            decimal importoDecimalPrelievo = 0;
            while (errorePrelievo == true)
            {
                string? importoStringPrelievo = "";
                Console.Clear();
                Console.WriteLine("Quanto vuoi prelevare?");
                Console.WriteLine("Importo: ");


                importoStringPrelievo = Console.ReadLine();


                if (!string.IsNullOrEmpty(importoStringPrelievo))
                {
                    decimal.TryParse(importoStringPrelievo, out importoDecimalPrelievo);
                    errorePrelievo = false;
                }
                else
                {
                    errorePrelievo = true;
                    //Console.Clear();
                }
            }

            // Creazione di un'istanza del conto bancario
            ContoBancario conto = new ContoBancario(importoDecimalContoBancario);
            

            // Creazione di un'istanza del notificatore
            Notificatore notificatore = new Notificatore();

            // Associazione del gestore dell'evento al metodo (lanciare) del notificatore
            //il postino riceve la lettera e la invia quando si verifca l'evento saldo insufficiente.
            conto.SaldoInsufficiente += notificatore.MostraMessaggio_insufficiente;
            conto.Preleva += notificatore.MostraMessaggio_DomandaNuovoPrelievo;
            
            // Tentativo di prelievo con importo superiore al saldo
            //conto.Prelievo(importoDecimalPrelievo);


            // Output: "Attenzione: Saldo insufficiente!"

            Console.ReadKey();

        }
    }
 }
