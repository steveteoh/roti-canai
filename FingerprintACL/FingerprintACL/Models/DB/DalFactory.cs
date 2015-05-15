using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FingerprintACL.Models.DB
{
    public enum GrConnector
    {
        SQLDal
    }

    public abstract class DalFactory
    {
        public static IGRDal GetDal(GrConnector connector)
        {
            switch (connector)
            {
                case GrConnector.SQLDal: return (IGRDal)Activator.CreateInstance(typeof(SQLDataAccessLayer), true);

                default: return null;
            }
        }
    }
}