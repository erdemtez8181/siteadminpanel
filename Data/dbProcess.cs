using DataStoreServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Siteyonetim.Framework.Data
{
    public class dbProcess
    {

        // private members

        public Sql_Gateway DB_Gateway;

        int m_UserId;
        string m_UserName;
        string m_Password;
        string m_Email;
        string m_Name;
        string m_Surname;
        string m_Mission;
        string m_Telephone;
        string m_ImageName;
        int m_Active;
        //int m_Active;
        bool _COMMIT = false;
        //Herhangi bir DB isleminin döndürdügü hata mesajini saklar
        public string Error_Message = "";

        // empty constructor
        public dbProcess()
        {
            DB_Gateway = new Sql_Gateway();
        }
        //private void TransferToClass(DataRow m_dtData)
        //{
        //    m_UserId = DataHelper.ReadInt32(m_dtData, "UserId");
        //    m_UserName = DataHelper.ReadString(m_dtData, "UserName");
        //    m_Password = DataHelper.ReadString(m_dtData, "Password");
        //    m_Email = DataHelper.ReadString(m_dtData, "Email");
        //    m_Name = DataHelper.ReadString(m_dtData, "Name");
        //    m_Surname = DataHelper.ReadString(m_dtData, "Surname");
        //    m_Mission = DataHelper.ReadString(m_dtData, "Mission");
        //    m_Telephone = DataHelper.ReadString(m_dtData, "Telephone");
        //    m_ImageName = DataHelper.ReadString(m_dtData, "ImageName");
        //    m_Active = DataHelper.ReadInt32(m_dtData, "Active");
        //}

    }


}
