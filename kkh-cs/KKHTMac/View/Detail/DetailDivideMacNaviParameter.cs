using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHView.Detail;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
namespace Isid.KKH.Mac.View.Detail
{
    class DetailDivideMacNaviParameter : DetailFormNaviParameter
    {
        //●他 
        Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow;
        int rowDetailIndex;
        FarPoint.Win.Spread.SheetView spdKkhDetail_Sheet1;
        //FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        FindMasterMaintenanceByCondServiceResult DivMastResult;
        FindMasterMaintenanceByCondServiceResult DivMastResult2;
        FindMasterMaintenanceByCondServiceResult DivMastResult3;

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
        public FindMasterMaintenanceByCondServiceResult DivTenpoMastrslt
        {
            set { DivMastResult = value; }
            get { return DivMastResult; }
        }

        public FindMasterMaintenanceByCondServiceResult DivTenpoPtnMastrslt
        {
            set { DivMastResult2 = value; }
            get { return DivMastResult2; }
        }

        public FindMasterMaintenanceByCondServiceResult DivTenpoPtn2Mastrslt
        {
            set { DivMastResult3 = value; }
            get { return DivMastResult3; }
        }
    }
}
