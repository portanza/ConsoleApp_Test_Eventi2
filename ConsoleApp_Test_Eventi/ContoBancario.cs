using System;

namespace ConsoleApp_Test_Eventi
{
    // Definizione di un publisher (informatore)
    public class ContoBancario
    {

        //Se sappiamo che una data situazione deve essere notificata a qualche classe perchè 
        //vogliamo che poi avvenga qualcosa in quel caso,
        //creiamo prima un delegato void, classico con object e EventArgs, poi se in seguito
        //capiamo che deve essere modificata la firma (input e output), lo facciamo.
        //Iniziamo in modo semplice.

        #region DICHIARAZIONE DEI DELEGATI USATI DALGLI EVENTI
        // Gli eventi, per essere utilizzati necessitano di delegati. 
        public delegate void SaldoInsufficienteHandler(object sender, EventArgs e);
        public delegate void PrelevaHandler(object sender, EventArgs e, decimal saldoProprietà, decimal importoProprietà);
        #endregion

        #region DICHIARAZIONE DEGLI EVENTI (SITUAZIONI CHE SI POSSONO NOTIFICARE)
        // Dichiarazione dell'evento utilizzando il delegato
        public event SaldoInsufficienteHandler? SaldoInsufficiente;
        public event PrelevaHandler? Preleva;
        #endregion

        #region DICHIARAZIONE CAMPI E PROPRIETA'
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
        #endregion

        #region COSTRUTTORE DEL SALDO INIZIALE 

        /// <summary>
        /// Setta il conto iniziale
        /// </summary>
        /// <param name="saldoIniziale"></param>
        public ContoBancario(decimal saldoIniziale)
        {
            _saldoProprietà = saldoIniziale;
        }
        #endregion

        #region TENTA IL PRELIEVO E PUNTA AD UN METODO SEGNALATORE A SECONDA CHE IL PRELIEVO SIA POSSIBILE O NO
        // Metodo per prelevare denaro dal conto


        public void TentativoDiPrelievo(decimal importo)
        {
            if (importo > _saldoProprietà)
            {
                // Se l'importo supera il saldo, esegue il metodo che costruisce la notifica
                // (scatena l'evento "segnalatore" SaldoInsufficiente)
                OnSaldoInsufficiente();
            }
            else
            {
                _saldoProprietà -= importo;
                OnPreleva();
            }
        }
        #endregion

        #region METODO CHE CONSENTE DI INFORMARE IL SOTTOSCRITTORE  (CHE IL SALDO E' INSUFFICIENTE)
        // Metodo per scatenare l'evento SaldoInsufficiente
        protected virtual void OnSaldoInsufficiente()
        {
            // Verifica se ci sono sottoscrittori all'evento prima di scatenarlo
            SaldoInsufficiente?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region METODO CHE CONSENTE DI INFORMARE IL SOTTOSCRITTORE  (CHE IL IL PRELIEVO E' AVVENUTO)
        protected virtual void OnPreleva()
        {
            // Scatena l'evento inviando la notifica al sottoscrittore che eseguirà il metodo agganciato
            Preleva?.Invoke(this, EventArgs.Empty, _saldoProprietà, _importoProprietà);
        }
        #endregion

        public void AggiornaSaldo(decimal nuovoSaldo)
        {
            SaldoProprietà = nuovoSaldo;
        }


    }
}