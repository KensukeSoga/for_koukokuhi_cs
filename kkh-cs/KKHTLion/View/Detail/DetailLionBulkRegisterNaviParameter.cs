using System;
using System.Collections.Generic;
using System.Text;

using Isid.KKH.Common.KKHView.Common;

namespace Isid.KKH.Lion.View.Detail
{
    class DetailLionBulkRegisterNaviParameter : KKHNaviParameter
    {
        public DetailLionBulkRegisterNaviParameter()
        {
        }

        public DetailLionBulkRegisterNaviParameter(KKHNaviParameter naviParameter)
        {
            //共通系の項目を初期値として引き継ぐ 
            if (naviParameter is DetailLionBulkRegisterNaviParameter)
            {
            }
            else
            {
                this.strEsqId = naviParameter.strEsqId;
                this.strEgcd = naviParameter.strEgcd;
                this.strTksKgyCd = naviParameter.strTksKgyCd;
                this.strTksBmnSeqNo = naviParameter.strTksBmnSeqNo;
                this.strTksTntSeqNo = naviParameter.strTksTntSeqNo;
            }
        }

        private string _brandCd;
        public string BrandCd
        {
            get { return _brandCd; }
            set { _brandCd = value; }
        }
    }
}
