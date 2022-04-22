using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkBankWorkers.BankSystem.BankWorkers
{
    internal class Consultant : Worker
    {
        #region Конструкторы
        internal Consultant() { }
        #endregion
        #region Методы
        #region Получение данных клиента
        internal override string GetName(BankClient client)
        {
            return client.Name;
        }
        internal override string GetSurName(BankClient client)
        {
            return client.SurName;
        }
        internal override string GetPatronymic(BankClient client)
        {
            return client.Patronymic;
        }
        internal override string GetPhoneNumber(BankClient client)
        {
            return client.PhoneNumber;
        }
        internal override string GetPassportSeriesNumber(BankClient client)
        {
            return string.IsNullOrEmpty(client.PassportSeriesNumber) ? client.PassportSeriesNumber : "**********";
        }
        #endregion
        #region Изменение данных клиента
        internal override bool SetName(BankClient client, string name)
        {
            return false;
        }
        internal override bool SetSurName(BankClient client, string surName)
        {
            return false;
        }
        internal override bool SetPatronymic(BankClient client, string patronymic)
        {
            return false;
        }
        internal override bool SetPhoneNumber(BankClient client, string phoneNumber)
        {
            if (BankClient.CheckPhoneNumber(phoneNumber) && !string.IsNullOrEmpty(phoneNumber))
            {
                client.PhoneNumber = phoneNumber;
                return true;
            }
            else return false;
        }
        internal override bool SetPassportSeriesNumber(BankClient client, string passportSeriesNumber)
        {
            return false;
        }
        #endregion
        #endregion
    }
}
