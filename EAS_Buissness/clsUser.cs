using EAS_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAS_Buissness
{
    public class clsUser
    {
        private enum enMode { AddNew = 0, Update }
        private enMode _Mode = enMode.AddNew;
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public clsEmployee EmployeeInfo { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int permissions { get; set; }
        public bool isActive { get; set; }

        public clsUser()
        {
            this.ID = -1;
            this.EmployeeID = -1;
            this.EmployeeInfo = null;
            this.username = null;
            this.password = null;
            this.permissions = 0;
            this.isActive = false;

            _Mode = enMode.AddNew;
        }
        private clsUser(stUser user)
        {
            this.ID = user.ID;
            this.EmployeeID = user.EmployeeID;
            this.EmployeeInfo = clsEmployee.Find(this.EmployeeID);
            this.username = user.username;
            this.password = user.password;
            this.permissions = user.permissions;
            this.isActive = user.isActive;

            _Mode = enMode.Update;
        }

        public static clsUser Find(int UserID)
        {
            stUser user = new stUser();
            if (UsersData.getUserInfo(UserID, ref user))
                return new clsUser(user);
            else
                return null;
        }

        public static clsUser Find(string username, string password)
        {
            stUser user = new stUser();
            if (UsersData.getUserInfo(username, password, ref user))
                return new clsUser(user);
            else
                return null;
        }

        private bool _AddNew()
        {
            stUser user = new stUser
            {
                username = this.username,
                password = this.password,
                permissions = this.permissions,
                EmployeeID = this.EmployeeID,
                isActive = this.isActive
            };

            this.ID = UsersData.Add(user);
            return this.ID != -1;
        }

        private bool _Update()
        {
            stUser user = new stUser
            {
                ID = this.ID,
                username = this.username,
                password = this.password,
                permissions = this.permissions,
                EmployeeID = this.EmployeeID,
                isActive = this.isActive
            };

            return UsersData.Update(user);
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

        public bool ChangeUsername(string new_username)
        {
            return UsersData.UpdateUsername(this.ID, new_username); 
        }
        public bool Delete()
        {
            return UsersData.Delete(this.ID);
        }

        public static bool isExist(int ID)
        {
            return UsersData.isExist(ID);
        }

        public static bool isExist(string username)
        {
            return UsersData.isExist(username);
        }

        public static DataTable UserseList()
        {
            return UsersData.List();
        }

        public bool Deactivate()
        {
            return UsersData.Deactivate(this.ID);
        }

    }
}
