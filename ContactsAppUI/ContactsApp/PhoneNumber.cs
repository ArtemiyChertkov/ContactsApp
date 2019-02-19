using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс телефоннных номеров
    /// </summary>
    public class PhoneNumber
    {
        private long _number;
        /// <summary>
        /// номер телефона содержит 11 цифр и начинается с 7
        /// </summary>
        public long Number
        {
            get { return _number; }

            set
            {

                if (value < 10000000000 || value > 99999999999)
                {
                    throw new ArgumentException("Номер должен состоять из 11 цифр.");
                }
                if (value < 70000000000 || value > 79999999999)
                {
                    throw new ArgumentException("Номер должен начинаться с цифры 7.");
                }
                else { _number = value; }

            }

        }

    }

}
