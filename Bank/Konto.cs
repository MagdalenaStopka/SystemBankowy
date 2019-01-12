using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Konto
    {
        public const string MsgKwotaUjemna = "Kwota ujemna";
        public const string MsgBrakSrodkow = "Brak środków na koncie";



        private string _klient;
        private double _bilans; //stan środków na koncie
        private bool _zablokowane = false;

        private Konto() { }
        public Konto(string klient, double bilansNaStart = 0)
        {
            if (bilansNaStart < 0)
                throw new ArgumentException(MsgKwotaUjemna);

            _klient = klient;
            _bilans = bilansNaStart;
        }

        public override string ToString()
        {
            return $"Klient: {_klient}, stan środków: {_bilans}";

        }

        public string Klient
        {
            get { return _klient; }
        }

        public double Bilans => _bilans; //properties typu get

        public void Wplata(double kwota)
        {
            if (kwota < 0)
                throw new ArgumentException(MsgKwotaUjemna);

            _bilans += kwota;
        }

        public void Wyplata(double kwota)
        {
            if (kwota < 0)
                throw new ArgumentException(MsgKwotaUjemna);

            if (kwota < _bilans)
                throw new ArgumentException(MsgBrakSrodkow);

            _bilans -= kwota;
        }

    }
}
