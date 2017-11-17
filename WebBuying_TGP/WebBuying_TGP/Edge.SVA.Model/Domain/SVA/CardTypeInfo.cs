using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.Model.Domain.SVA
{
    public class CardTypeInfo:IKeyValue
    {
        public string Key { get; set; }
        public string Value { get; set; }
        private List<CardGradeInfo> cardGrades = new List<CardGradeInfo>();
        public List<CardGradeInfo> CardGrades
        {
            get { return cardGrades; }
        }
    }
}
