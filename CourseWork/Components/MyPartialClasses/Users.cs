using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Components
{
    public partial class Users
    {
        public string FullName
        {
            get
            {
                return $"{Surname} {FirstName} {Patronymic}";

            }
        }
    }
}
