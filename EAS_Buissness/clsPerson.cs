using EAS_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EAS_Buissness
{
    public class clsPerson
    {
        private enum enMode { AddNew = 0, Update }
        private enMode _Mode = enMode.AddNew;

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }

        public string FullName()
        {
            if (this.ThirdName != "")
                return FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
            else
                return FirstName + " " + SecondName + " " + LastName;
        }

        public string ShortName()
        {
            return FirstName + " " + LastName;
        }

        public clsPerson()
        {
            this.ID = -1;
            this.FirstName = string.Empty;
            this.SecondName = string.Empty;
            this.LastName = string.Empty;
            this.ThirdName = string.Empty;
            this.Address = string.Empty;
            this.Nationality = string.Empty;
            this.Gender = string.Empty;
            this.PhoneNumber = string.Empty;
            this.Email = string.Empty;
            this.BirthDate = DateTime.MinValue;

            this._Mode = enMode.AddNew;
        }

        private clsPerson(stPerson person)
        {
            this.ID = person.ID;
            this.FirstName = person.FirstName;
            this.SecondName = person.SecondName;
            this.LastName = person.LastName;
            this.ThirdName = person.ThirdName;
            this.Address = person.Address;
            this.Nationality = person.Nationality;
            this.Gender = person.Gender;
            this.PhoneNumber = person.PhoneNumber;
            this.Email = person.Email;
            this.BirthDate = person.BirthDate;

            this._Mode = enMode.Update;
        }

        public static clsPerson Find(int PersonID)
        {
            stPerson person = new stPerson();
            if (PeopleData.getPersonInfo(PersonID, ref person))
                return new clsPerson(person);
            else
                return null;
        }

        private bool _AddNew()
        {
            stPerson person = new stPerson
            {
                Address = this.Address,
                FirstName = this.FirstName,
                LastName = this.LastName,
                ThirdName = this.ThirdName,
                SecondName = this.SecondName,
                Email = this.Email,
                PhoneNumber = this.PhoneNumber,
                BirthDate = this.BirthDate,
                Nationality = this.Nationality,
                Gender = this.Gender,
            };

            this.ID = PeopleData.Add(person);
            return this.ID != -1;
        }

        private bool _Update()
        {
            stPerson person = new stPerson
            {
                ID = this.ID,
                Address = this.Address,
                FirstName = this.FirstName,
                LastName = this.LastName,
                ThirdName = this.ThirdName,
                SecondName = this.SecondName,
                Email = this.Email,
                PhoneNumber = this.PhoneNumber,
                BirthDate = this.BirthDate,
                Nationality = this.Nationality,
                Gender = this.Gender,
            };

            return PeopleData.Update(person);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        this._Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _Update();
            }

            return false;
        }

        public bool Delete()
        {
            if (clsEmployee.isExist_ByPersonID(this.ID))
            {
                return false;
            }

            return PeopleData.Delete(this.ID);
        }

        public static bool isExist(int ID)
        {
            return PeopleData.isExist(ID);
        }

        public static DataTable PeopleList()
        {
            return PeopleData.List();
        }

    }
}
