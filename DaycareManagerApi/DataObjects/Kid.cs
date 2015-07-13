using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaycareManagerApi.DataObjects
{
    public class Kid : EntityData
    {
        public Kid()
        {
            Parents = new List<Parent>();
        }
        //public int Id { get; set; }

        public int UserUnitId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Parent> Parents { get; set; }
    }
}
