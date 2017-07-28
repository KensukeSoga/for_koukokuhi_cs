using System;
using System.Collections.Generic;
using System.Text;

using Isid.KKH.Common.KKHView.Common;

namespace Isid.KKH.Lion.View.Mast
{
    class frmMastLionNaviParameter : KKHNaviParameter
    {
        public frmMastLionNaviParameter()
        {
        }

        public frmMastLionNaviParameter(KKHNaviParameter naviParameter)
        {
            //共通系の項目を初期値として引き継ぐ 
            if (naviParameter is frmMastLionNaviParameter)
            {
            }
            else
            {
                this.strEsqId = naviParameter.strEsqId;
                this.AplId = naviParameter.AplId;
                this.strEgcd = naviParameter.strEgcd;
                this.strTksKgyCd = naviParameter.strTksKgyCd;
                this.strTksBmnSeqNo = naviParameter.strTksBmnSeqNo;
                this.strTksTntSeqNo = naviParameter.strTksTntSeqNo;
                this.strMasterKey = naviParameter.strMasterKey;
                this.strFilterValue = naviParameter.strFilterValue;
            }
        }

        /// <summary>
        /// コードを取得、または設定します.
        /// </summary>
        private string _cd;

        public string Cd
        {
            get { return _cd; }
            set { _cd = value; }
        }

        /// <summary>
        /// 名称を取得、または設定します.
        /// </summary>
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
