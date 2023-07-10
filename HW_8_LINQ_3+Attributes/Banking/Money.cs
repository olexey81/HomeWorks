namespace HW_4_Bank
{
    public class Money
    {
        private readonly int _UAH;
        private readonly int _Kopeck;


        public Money(int  uah, int kopeck)
        {
            _UAH = uah;
            _Kopeck = kopeck;
        }

        public Money AddMoney(Money amount) => new Money(_UAH + amount._UAH, _Kopeck + amount._Kopeck);

        public Money RemoveMoney(Money amount) => new Money(_UAH - amount._UAH, _Kopeck - amount._Kopeck);

        public bool IsMoreOrEqualMoney(Money amount)
        {
            return _UAH >= amount._UAH && _Kopeck >= amount._Kopeck;
        }

        public decimal ShowMoney() => _UAH + _Kopeck / 100m;

    }
}
// -Гроші складаються з гривень та копійок, з ними можна проводити прості арифмети. операції та порівняння. Має бути незмінним.