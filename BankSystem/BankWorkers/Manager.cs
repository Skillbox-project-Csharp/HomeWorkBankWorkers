using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkBankWorkers.BankSystem.BankWorkers
{
    internal class Manager : Worker
    {
        #region Конструкторы
        internal Manager() { }
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
            return client.PassportSeriesNumber;
        }
        #endregion
        #region Изменение данных клиента
        internal override bool SetName(BankClient client, string name)
        {
            client.Name = name;
            return true;
        }
        internal override bool SetSurName(BankClient client, string surName)
        {
            client.SurName = surName;
            return true;
        }
        internal override bool SetPatronymic(BankClient client, string patronymic)
        {
            client.Patronymic = patronymic;
            return true;
        }
        internal override bool SetPhoneNumber(BankClient client, string phoneNumber)
        {
            if (BankClient.CheckPhoneNumber(phoneNumber))
            {
                client.PhoneNumber = phoneNumber;
                return true;
            }
            else return false;
        }
        internal override bool SetPassportSeriesNumber(BankClient client, string passportSeriesNumber)
        {
            if (BankClient.CheckPassportSeriesNumber(passportSeriesNumber))
            {
                client.PassportSeriesNumber = passportSeriesNumber;
                return true;
            }
            else return false;
        }
        #endregion
        #endregion
    }
}
