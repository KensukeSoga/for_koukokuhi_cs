using Isid.KKH.Common.KKHView.Detail;

namespace Isid.KKH.Tkd.View.Detail
{
    /// <summary>
    /// 実施No自動UP/DOWNパラメータクラス 
    /// </summary>
    class DatailAutoUpDownNaviParameter : DetailFormNaviParameter
    {
        public DatailAutoUpDownNaviParameter()
        {
        }

        public DatailAutoUpDownNaviParameter(DetailFormNaviParameter naviParameter)
        {
            //共通系の項目を初期値として引き継ぐ 
            if (naviParameter is DatailAutoUpDownNaviParameter)
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
    }
}