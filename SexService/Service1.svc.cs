using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SexService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<Sex> GetSexData()
        {
            return GetAllSex();
        }

        private List<Sex> GetAllSex()
        {
            return new List<Sex>()
            {
                new Sex(){Id=1, Name="Mężczyzna"},
                new Sex(){Id=2, Name="Kobieta"}
            };
        }
    }
}
