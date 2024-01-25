using System;

namespace ConsoleApp_Test_Eventi
{
    // Definizione di un publisher (editore)
    public class ContoBancario
    {
        // Dichiarazione di un delegato per l'evento
        public delegate void SaldoInsufficienteHandler(object sender, EventArgs e);
        public delegate void PrelevaHandler(object sender, EventArgs e, decimal saldoProprietà, decimal importoProprietà);

        // Dichiarazione dell'evento utilizzando il delegato
        public event SaldoInsufficienteHandler SaldoInsufficiente;
        public event PrelevaHandler Preleva;

        private decimal _importoProprietà;
        private decimal _saldoProprietà;

        public decimal importoProprietà
        {
            get
            {
                return _importoProprietà;
            }

            set
            {
                _importoProprietà = value;
            }
        }

        public decimal SaldoProprietà
        {
            get
            {
                return _saldoProprietà;
            }
            private set
            {
                _saldoProprietà = value;
            }
        }

        /// <summary>
        /// Setta il conto iniziale
        /// </summary>
        /// <param name="saldoIniziale"></param>
        public ContoBancario(decimal saldoIniziale)
        {
            _saldoProprietà = saldoIniziale;
        }

        // Metodo per prelevare denaro dal conto
        public void Prelievo(decimal importo)
        {
            if (importo > _saldoProprietà)
            {
                // Se l'importo supera il saldo, esegue il metodo che costruisce la notifica
                // (scatena l'evento "segnalatore" SaldoInsufficiente)
                OnSaldoInsufficiente();
            }
            else
            {
                OnPreleva();
            }
        }

        // Metodo per scatenare l'evento SaldoInsufficiente
        protected virtual void OnSaldoInsufficiente()
        {
            // Verifica se ci sono sottoscrittori all'evento prima di scatenarlo
            SaldoInsufficiente?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnPreleva()
        {
            // Scatena l'evento inviando la notifica al sottoscrittore che eseguirà il metodo agganciato
            Preleva?.Invoke(this, EventArgs.Empty, _saldoProprietà, _importoProprietà);
        }

        public void AggiornaSaldo(decimal nuovoSaldo)
        {
            SaldoProprietà = nuovoSaldo;
        }

    }
}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp_Test_Eventi
//{

//    // Definizione di un publisher (editore)
//    public class ContoBancario
//    {

//        // Dichiarazione di un delegato per l'evento
//        public delegate void SaldoInsufficienteHandler(object sender, EventArgs e);
//        public delegate void PrelevaHandler(object sender, EventArgs e, decimal saldoProprietà, decimal importoProprietà);


//        // Dichiarazione dell'evento utilizzando il delegato
//        public event SaldoInsufficienteHandler SaldoInsufficiente;
//        public event PrelevaHandler Preleva;

//        public decimal importoProprietà {
//            get
//            {
//                return importoProprietà; 
//            }

//            set
//            {
//                importoProprietà=value;
//            }
//        }

//        public decimal SaldoProprietà {
//            get
//            {
//                return SaldoProprietà;
//            }
//            private set
//            {
//                 SaldoProprietà = value;
//            }
//        }


//        /// <summary>
//        /// Setta il conto iniziale
//        /// </summary>
//        /// <param name="saldoIniziale"></param>
//        public ContoBancario(decimal saldoIniziale)
//        {
//            SaldoProprietà = saldoIniziale;
//        }



//        // Metodo per prelevare denaro dal conto
//        public void Prelievo(decimal importo)
//        {
//            if (importo > SaldoProprietà)
//            {
//                // Se l'importo supera il saldo, esegue il motodo che costruisce la notifica
//                // (scatena l'evento "segnalatore" SaldoInsufficiente)
//                OnSaldoInsufficiente();
//            }
//            else
//            {
//                OnPreleva();
//            }
//        }

//        // Metodo per scatenare l'evento SaldoInsufficiente
//        //Con questo codice è possibile informare/notificare il sottoscrittore, se esiste.
//        //Crea la busta.
//        protected virtual void OnSaldoInsufficiente()
//        {
//            // Verifica se ci sono sottoscrittori all'evento prima di scatenarlo
//            if (SaldoInsufficiente != null)
//            {
//                // Scatena l'evento ovvero invia la notifica al sottoscrittore che eseguirà il metodo agganciato
//                SaldoInsufficiente(this, EventArgs.Empty);
//            }
//        }

//        protected virtual void OnPreleva()
//        {
//            if (Preleva != null)
//            {
//                // Scatena l'evento ovvero invia la notifica al sottoscrittore che eseguirà il metodo agganciato
//                Preleva(this, EventArgs.Empty, SaldoProprietà, importoProprietà);
//            }
//        }
//    }
//}


