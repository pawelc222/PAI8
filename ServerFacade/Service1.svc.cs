using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;


namespace ServerFacade
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private IEnumerable<SexServiceReference.Sex> sexData = null;

        public List<PersonComplete> GetCompleteData()
        {
            List<PersonComplete> persons = new List<PersonComplete>();
            
            foreach(PersonServiceReference.Person p in GetPersons())
            {
                PersonComplete person = new PersonComplete();
                person.Id = p.Id;
                person.Name = p.Name + " " + p.SurName;
                person.Money = p.Money;
                person.Sex = GetSex(p.SexId);
                persons.Add(person);
            }

            return persons;
        }

        private string GetSex(int p)
        {
            if (sexData == null)
                GetSexData();
            var sex = from s in sexData where s.Id == p select s;
            return sex.FirstOrDefault().Name;                  
        }

        private void GetSexData()
        {
            SexServiceReference.Service1Client client = new SexServiceReference.Service1Client();
            sexData = client.GetSexData();
        }

        private IEnumerable<PersonServiceReference.Person> GetPersons()
        {
            PersonServiceReference.Service1Client client = new PersonServiceReference.Service1Client();
            return client.GetAllPersons();
        }


        public int DoSocialism()
        {
            PersonServiceReference.Service1Client client = new PersonServiceReference.Service1Client();

            Thread.Sleep(3000);
            return client.DoSocialism();
        }
    }
}
