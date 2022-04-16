using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PH1_App
{
    class StatusMatrix
    {
        private StatusOfPriviledge[,] matrix;
        public StatusMatrix(role role)
        {
            matrix = new StatusOfPriviledge[4, 5];
        }
        public int convertPriviledge(string p)
        {
            if(p=="INSERT")
            {
                return 0;
            }
            if(p=="DELETE")
            {
                return 1;
            }
            if(p=="UPDATE")
            {
                return 2;
            }
            if(p=="SELECT")
            {
                return 4;
            }
            return -1;
        }
        public int convertTableName(string name)
        {
            if(name == "HSBA")
            {
                return 0;
            }
            if(name =="HSBA_DV")
            {
                return 1;
            }
            if(name == "BENHNHAN")
            {
                return 2;
            }
            if(name == "CSYT")
            {
                return 3;
            }
            if(name =="NHANVIEN")
            {
                return 4;
            }
            return -1;
        }
        public void setPriviledge(string p,string tablename,int period, int number)
        {
            int x = convertPriviledge(p);
            int y = convertTableName(tablename);
            if (period==1)
            {
                matrix[x, y].setNew(number);
            }
            else if(period==-1)
            {
                matrix[x, y].setOld(number);
            }
        }
    }
}
