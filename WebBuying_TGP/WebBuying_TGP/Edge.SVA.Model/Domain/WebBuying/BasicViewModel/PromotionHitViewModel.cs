using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Edge.SVA.Model.Domain.WebBuying.BasicViewModel
{
    public class PromotionHitViewModel : Promotion_Hit
    {
        private string objectKey = Guid.NewGuid().ToString();

        public string ObjectKey
        {
            get { return objectKey; }
            set { objectKey = value; }
        }

        private string oprFlag;

        public string OprFlag
        {
            get { return oprFlag; }
            set { oprFlag = value; }
        }

        DataTable hitPluTable = new DataTable();

        public DataTable HitPluTable
        {
            get { return hitPluTable; }
            set { hitPluTable = value; }
        }

        private string hitTypeName;

        public string HitTypeName
        {
            get { return hitTypeName; }
            set { hitTypeName = value; }
        }

        private string hitItemName;

        public string HitItemName
        {
            get { return hitItemName; }
            set { hitItemName = value; }
        }

        private string logicalOprName;

        public string LogicalOprName
        {
            get { return logicalOprName; }
            set { logicalOprName = value; }
        }

        private string hitOPName;

        public string HitOPName
        {
            get { return hitOPName; }
            set { hitOPName = value; }
        }
    }
}
