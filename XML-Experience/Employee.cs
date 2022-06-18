using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimBT_Deneme
{
    public class Employee
    {
        private string name, surname, telno, gender;

        public string Name
        {
            get { return name; } 
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string TelNo
        {
            get { return telno; }
            set { telno = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
    }
}
