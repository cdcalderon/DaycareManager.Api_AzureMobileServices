using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaycareManagerApi.DataObjects
{
    public class Parent : EntityData
    {
        //public int Id { get; set; }

        public int UserUnitId { get; set; }

        public int FirstName { get; set; }

        public int LastName { get; set; }
    }
}
