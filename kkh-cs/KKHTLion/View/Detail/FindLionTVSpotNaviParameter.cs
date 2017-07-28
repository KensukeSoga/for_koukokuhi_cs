using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHView.Common;

namespace Isid.KKH.Lion.View.Detail
{
    class FindLionTVSpotNaviParameter : KKHNaviParameter
    {
        public FindLionTVSpotNaviParameter()
        {
        }

        public FindLionTVSpotNaviParameter(KKHNaviParameter naviParameter)
        {
            //共通系の項目を初期値として引き継ぐ 
            if (!( naviParameter is FindLionTVSpotNaviParameter ))
            {
                this.strEsqId = naviParameter.strEsqId;
                this.strEgcd = naviParameter.strEgcd;
                this.strTksKgyCd = naviParameter.strTksKgyCd;
                this.strTksBmnSeqNo = naviParameter.strTksBmnSeqNo;
                this.strTksTntSeqNo = naviParameter.strTksTntSeqNo;
            }
        }

        //

        protected String strYM;

        public String StrYM
        {
            set { strYM = value; }
            get { return strYM; }
        }

        //

        protected Isid.KKH.Lion.Schema.DetailDSLion.KkhTVSpotDetailListViewRow[] detailListRow;

        public Isid.KKH.Lion.Schema.DetailDSLion.KkhTVSpotDetailListViewRow[] DetailListRow
        {
            set { detailListRow = value; }
            get { return detailListRow; }
        }
    }
}
