using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Test_Eventi
{
    // Classe sottoscrittrice (subscriber) che gestisce l'evento
    // crea la lettera da inserire nella busta contente le azioni da eseguire
    public class Notificatore
    {
        public void MostraMessaggio_insufficiente(object sender, EventArgs e)
        {
            Console.WriteLine("Attenzione: Saldo insufficiente!");
        }
        public void MostraMessaggio_DomandaNuovoPrelievo(object sender, EventArgs e, decimal saldoProprietà, decimal importoProprietà)
        {

            saldoProprietà -= importoProprietà;
            Console.WriteLine($"Prelievo di {importoProprietà} effettuato. Nuovo saldo: {importoProprietà}");

            // Aggiorna il saldo utilizzando il nuovo metodo
            (sender as ContoBancario)?.AggiornaSaldo(saldoProprietà);

            Console.Clear();
            Console.WriteLine("Vuoi prelevare ancora?");
            Console.Write("S/N: ");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            char risposta = consoleKeyInfo.KeyChar;
            if (risposta == 'S')
            {

            }
            else
            {
                return;
            }
        }


    }
}
