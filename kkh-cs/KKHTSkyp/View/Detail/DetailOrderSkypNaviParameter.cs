using Isid.KKH.Common.KKHView.Detail;

namespace Isid.KKH.Skyp.View.Detail
{
    /// <summary>
    /// 並び順画面（スカパー）パラメータクラス 
    /// </summary>
    class DetailOrderSkypNaviParameter : DetailFormNaviParameter
    {
        public DetailOrderSkypNaviParameter()
        {
        }

        public DetailOrderSkypNaviParameter(DetailFormNaviParameter naviParameter)
        {
            //共通系の項目を初期値として引き継ぐ 
            if (naviParameter is DetailOrderSkypNaviParameter)
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