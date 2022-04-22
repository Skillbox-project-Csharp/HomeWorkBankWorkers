using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkBankWorkers.BankSystem.BankWorkers
{
    internal abstract class Worker
    {
        #region Методы
        #region Получение данных клиента
        internal abstract string GetName(BankClient client);
        internal abstract string GetSurName(BankClient client);
        internal abstract string GetPatronymic(BankClient client);
        internal abstract string GetPhoneNumber(BankClient client);
        internal abstract string GetPassportSeriesNumber(BankClient client);
        #endregion
        #region Изменение данных клиента
        internal abstract bool SetName(BankClient client, string name);
        internal abstract bool SetSurName(BankClient client, string surName);
        internal abstract bool SetPatronymic(BankClient client, string patronymic);
        internal abstract bool SetPhoneNumber(BankClient client, string phoneNumber);
        internal abstract bool SetPassportSeriesNumber(BankClient client, string passportSeriesNumber);
        #endregion
        #endregion
    }
}
