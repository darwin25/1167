using System;
using System.Collections.Generic;
using System.Text;
using Edge.SVA.Model.Domain.Operation.BasicViewModel;

namespace Edge.SVA.Model.Domain.Operation
{
    public class ImportMemberViewModel
    {
        Ord_ImportMember_H mainTable = new Ord_ImportMember_H();

        public Ord_ImportMember_H MainTable
        {
            get { return mainTable; }
            set { mainTable = value; }
        }

        private ImportMemberDetailViewModel modeldetail = new ImportMemberDetailViewModel();

        public ImportMemberDetailViewModel Modeldetail
        {
            get { return modeldetail; }
            set { modeldetail = value; }
        }

        private List<string> errorList = new List<string>();

        public List<string> ErrorList
        {
            get { return errorList; }
            set { errorList = value; }
        }

    }
}
