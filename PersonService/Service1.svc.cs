using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PersonService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public List<Person> GetAllPersons()
        {
            return AllPersons();
        }

        private List<Person> AllPersons()
        {
            return new List<Person>()
            {
                new Person(){Id=1, Name="Jan", SurName="Kowalski", Money=1000, SexId=1},
                new Person(){Id=2, Name="Anna", SurName="Nowak", Money=10000, SexId=2},
                new Person(){Id=3, Name="Krzysztof", SurName="Skrzypek", Money=4000, SexId=1},
                new Person(){Id=4, Name="Halina", SurName="Krystyna", Money=1000, SexId=1}
            };
        }


        public int DoSocialism()
        {
            int money = 0;
            foreach(var p in AllPersons())
            {
                money += p.Money;
            }
            return money;
        }
    }
}
