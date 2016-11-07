using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTramYTe.Classes
{
    public class UserModel
    {
        private string uid;
        private string pwd;

        public UserModel(string uid, string pwd)
        {
            this.uid=uid;
            this.pwd=pwd;
        }

        public string getUid()
        {
            return uid;
        }
        public string getPwd()
        {
            return pwd;
        }
    }
}
