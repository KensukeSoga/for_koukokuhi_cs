using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHView.Detail;

namespace Isid.KKH.Mac.View.Detail
{
    class DetailInputMacNaviParameter : DetailFormNaviParameter
    {
        //●他
        Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow;
        int rowDetailIndex;
        FarPoint.Win.Spread.SheetView spdKkhDetail_Sheet1;
        FindMasterMaintenanceByCondServiceResult InpMastResult;

        //●基本情報
        string npStrEsqId;
        string npStrEgcd;
        string npStrTksKgyCd;
        string npStrTksBmnSeqNo;
        string npStrTksTntSeqNo;

        //基本
        public string pEsqId
        {
            set { npStrEsqId = value; }
            get { return npStrEsqId; }
        }
        public string pEgcd
        {
            set { npStrEgcd = value; }
            get { return npStrEgcd; }
        }
        public string pTksKgyCd
        {
            set { npStrTksKgyCd = value; }
            get { return npStrTksKgyCd; }
        }
        public string pTksBmnSeqNo
        {
            set { npStrTksBmnSeqNo = value; }
            get { return npStrTksBmnSeqNo; }
        }
        public string pTksTntSeqNo
        {
            set { npStrTksTntSeqNo = value; }
            get { return npStrTksTntSeqNo; }
        }

        //他
        public Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow DataRow
        {
            set { dataRow = value; }
            get { return dataRow; }
        }

        public int RowDetailIndex
        {
            set { rowDetailIndex = value; }
            get { return rowDetailIndex; }
        }

        public FarPoint.Win.Spread.SheetView SpdKkhDetail_Sheet1
        {
            set { spdKkhDetail_Sheet1 = value; }
            get { return spdKkhDetail_Sheet1; }
        }
        public FindMasterMaintenanceByCondServiceResult InpTenpoMastrslt
        {
            set { InpMastResult = value; }
            get { return InpMastResult; }
        }
    }
}
