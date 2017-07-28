using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHView.Detail;
using Isid.KKH.Common.KKHView.Common;


namespace Isid.KKH.Lion.View.Detail
{
    class FindLionCodeItrNaviParameter2 : DetailFormNaviParameter
    {

        public FindLionCodeItrNaviParameter2()
        {
        }
        public FindLionCodeItrNaviParameter2(KKHNaviParameter naviParameter)
        {
            //共通系の項目を初期値として引き継ぐ 
            if (naviParameter is FindLionCodeItrNaviParameter2)
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

        /// <summary>
        /// 種別を取得、または設定します.
        /// </summary>
        private string _cdNo;

        public string CdNo
        {
            get { return _cdNo; }
            set { _cdNo = value; }
        }

        /// <summary>
        /// 媒体CDを取得、または設定します.
        /// </summary>
        private string _btCd;

        public string BtCd
        {
            get { return _btCd; }
            set { _btCd = value; }
        }

    }
}

