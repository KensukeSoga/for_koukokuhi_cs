using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHView.Detail;

namespace Isid.KKH.Mac.View.Detail
{
    class DetailTenpoItrNaviParameter : DetailFormNaviParameter
    {
        //引数
        //●基本情報
        string npStrEsqId;
        string npStrEgcd;
        string npStrTksKgyCd;
        string npStrTksBmnSeqNo;
        string npStrTksTntSeqNo;
        //●全部、一部フラグ
        string npStrAllorFlg;
        //戻り値
        string npStrTenpoCd;
        string npStrTenpoNm;
        string npStrTenpoKbn;
        string npStrKanjyoKmk;
        FindMasterMaintenanceByCondServiceResult DivTenpoMastrslt;

        //ゲッターセッター
        public string EsqId
        {
            set { npStrEsqId = value; }
            get { return npStrEsqId; }
        }
        public string Egcd
        {
            set { npStrEgcd = value; }
            get { return npStrEgcd; }
        }
        public string TksKgyCd
        {
            set { npStrTksKgyCd = value; }
            get { return npStrTksKgyCd; }
        }
        public string TksBmnSeqNo
        {
            set { npStrTksBmnSeqNo = value; }
            get { return npStrTksBmnSeqNo; }
        }
        public string TksTntSeqNo
        {
            set { npStrTksTntSeqNo = value; }
            get { return npStrTksTntSeqNo; }
        }
        public string AllorFlg
        {
            set { npStrAllorFlg = value; }
            get { return npStrAllorFlg; }
        }

        public string TenpoCd
        {
            set { npStrTenpoCd = value; }
            get { return npStrTenpoCd; }
        }
        public string TenpoNm
        {
            set { npStrTenpoNm = value; }
            get { return npStrTenpoNm; }
        }
        public string TenpoKbn
        {
            set { npStrTenpoKbn = value; }
            get { return npStrTenpoKbn; }
        }
        public string KanjyoKmk
        {
            set { npStrKanjyoKmk = value; }
            get { return npStrKanjyoKmk; }
        }
        public FindMasterMaintenanceByCondServiceResult ItrTenpoMastrslt
        {
            set { DivTenpoMastrslt = value; }
            get { return DivTenpoMastrslt; }
        }




    }
}
