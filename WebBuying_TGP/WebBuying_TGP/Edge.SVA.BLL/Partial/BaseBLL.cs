using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;

namespace Edge.SVA.BLL
{
    public abstract class BaseBLL
    {
        protected abstract Edge.SVA.IDAL.IBaseDAL BaseDAL { get; }
       
        public string Order {
            get
            {
                return BaseDAL.Order;
            }
            set
            {
                BaseDAL.Order = value;  
            }
        }

        public string Fields
        {
            get
            {
                return BaseDAL.Fields;
            }
            set
            {
                BaseDAL.Fields = value; 
            }
        }

        public int Timeout
        {
            get
            {
                return BaseDAL.Timeout;
            }
            set
            {
                this.BaseDAL.Timeout = value;
            }
        }

        public bool Ascending
        {
            get
            {
                return BaseDAL.Ascending;
            }
            set
            {
                BaseDAL.Ascending = value;  
            }
        }

        public string StrWhere
        {
            get
            {
                return BaseDAL.StrWhere;
            }
            set
            {
                this.BaseDAL.StrWhere = value;
            }
        }

        public DataSet GetList(int pageSize, int pageIndex)
        {
            return BaseDAL.GetList(pageSize, pageIndex);
        }

        public DataSet GetList(int pageSize, int pageIndex, out int recordCount)
        {
            return BaseDAL.GetList(pageSize, pageIndex, out recordCount);
        }
        
    }
}
