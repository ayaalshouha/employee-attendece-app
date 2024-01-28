using EAS_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAS_Buissness
{
    public class clsDepartment
    {
        private enum enMode { AddNew = 0, Update }
        private enMode _Mode = enMode.AddNew;
        public int ID { get; set; }
        public string Name { get; set; }
        public int RequiredWorkHours { get; set; }
        public decimal DollarPerHour { get; set; }
        public int TotalEmployeesCount { get; set; }

        public clsDepartment()
        {
            this.ID = -1;
            this.Name = string.Empty;
            this.RequiredWorkHours = -1;
            this.DollarPerHour = -1;
            this.TotalEmployeesCount = -1;

            _Mode = enMode.AddNew;
        }
        private clsDepartment(stDepartment department)
        {
            this.ID = department.ID;
            this.Name = department.Name;
            this.RequiredWorkHours = department.RequiredWorkHours;
            this.TotalEmployeesCount = department.TotalEmployeesCount;
            this.DollarPerHour = department.DollarPerHour;

            _Mode = enMode.Update;
        }

        public static clsDepartment Find(int departmentID)
        {
            stDepartment department = new stDepartment();
            if (DepartmentsData.getDepartmentInfo(departmentID, ref department))
                return new clsDepartment(department);
            else
                return null;
        }

        private bool _AddNew()
        {
            stDepartment department = new stDepartment
            {
                Name = this.Name,
                RequiredWorkHours = this.RequiredWorkHours,
                DollarPerHour = this.DollarPerHour,
                TotalEmployeesCount = this.TotalEmployeesCount
            };

            this.ID = DepartmentsData.Add(department);
            return this.ID != -1;
        }

        private bool _Update()
        {
            stDepartment department = new stDepartment
            {
                ID = this.ID,
                Name = this.Name,
                RequiredWorkHours = this.RequiredWorkHours,
                DollarPerHour = this.DollarPerHour,
                TotalEmployeesCount = this.TotalEmployeesCount
            };

            return DepartmentsData.Update(department);
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
            return DepartmentsData.Delete(this.ID);
        }
        public static DataTable DepartmentsList()
        {
            return DepartmentsData.GetAllDepartments();
        }
    }
}
