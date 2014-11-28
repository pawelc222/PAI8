using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    public class ServiceLocator
    {
        public const string ServiceTypeFacade = "SERVICE_TYPE_FACADE";

        private FacadeServiceReference.Service1Client _facadeServiceClassClient;

        private static ServiceLocator _instance;

        public static ServiceLocator GetInstance()
        {
            if (_instance == null)
                _instance = new ServiceLocator();
            return _instance;
        }

        public Object GetService(string serviceType)
        {
            switch (serviceType)
            {
                case ServiceTypeFacade:
                    if (_facadeServiceClassClient == null)
                        _facadeServiceClassClient = (FacadeServiceReference.Service1Client) CreateServiceProxy(serviceType);
                    return _facadeServiceClassClient;
                default:
                    throw new NotImplementedException();
            }
        }

        private Object CreateServiceProxy(string serviceType)
        {
            switch (serviceType)
            {
                case ServiceTypeFacade:
                    return new FacadeServiceReference.Service1Client();                
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
