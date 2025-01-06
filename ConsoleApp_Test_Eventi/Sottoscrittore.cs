using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Test_Eventi
{
    // Classe sottoscrittrice (subscriber) che esegue un'azione al verificarsi di un evento.
    //Prima si crea la classe del subscriber: dobbiamo prima sapere che azioni devono essere fatte
    //e quindi capire il tipo di valore da ritornare.
    //In questo caso è un void senza quindi andremo a creare
    //- un delegato con la stessa firma
    //- un evento del tipo del deleagato appena creato.
  
    public class Sottoscrittore
    {
        
        //Questo metodo può ricevere il segnale dal publisher (informatore) perché 
        //la firma del metodo è la stessa del delegato.
        //Ricevuto l'ok che si è verificato l'evento a cui "può" essere agganciato,
        //compie un'azione.


        public void MostraMessaggio_insufficiente(object sender, EventArgs e)
        {
            Console.WriteLine("Attenzione: Saldo insufficiente!");
        }
        public void MostraMessaggio_DomandaNuovoPrelievo(object sender, EventArgs e, decimal saldoProprietà, decimal importoProprietà)
        {

         
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
