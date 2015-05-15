using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GriauleFingerprintLibrary.DataTypes;
using System.Data;

namespace FingerprintACL.Models.DB
{
    public interface IGRDal
    {
        void SaveTemplate(FingerprintTemplate fingerPrintTemplate);
        IDataReader GetTemplates();
        void SaveTemplate(string username, FingerprintTemplate fingerPrintTemplate);
        IDataReader GetTemplate(int idTemplate);
        void DeleteTemplate(int idTemplate);
        void DeleteTemplate();
    }
}
