using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHView.Detail;

namespace Isid.KKH.Uni.View.Detail
{
    class DetailInputUniNaviParameter : DetailFormNaviParameter
    {
        Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow;
        int rowDetailIndex;
        FarPoint.Win.Spread.SheetView spdKkhDetail_Sheet1;


        /// <summary>
        /// ログインユーザESQID.
        /// </summary>
        private string _strEsqId;
        /// <summary>
        /// ログインユーザESQIDを取得または設定します.
        /// </summary>
        public string EsqId
        {
            get { return _strEsqId; }
            set { _strEsqId = value; }
        }

        /// <summary>
        /// ログインユーザ名.
        /// </summary>
        private string _strName;
        /// <summary>
        /// ログインユーザ名を取得または設定します.
        /// </summary>
        public string Name
        {
            get { return _strName; }
            set { _strName = value; }
        }

        /// <summary>
        /// egcd.
        /// </summary>
        private string _strEgcd;
        /// <summary>
        /// egcdを取得または設定します.
        /// </summary>
        public string Egcd
        {
            get { return _strEgcd; }
            set { _strEgcd = value; }
        }

        /// <summary>
        /// 得意先企業名.
        /// </summary>
        private string _strTksKgyName;
        /// <summary>
        /// 得意先企業名を取得または設定します.
        /// </summary>
        public string TksKgyName
        {
            get { return _strTksKgyName; }
            set { _strTksKgyName = value; }
        }

        /// <summary>
        /// 得意先企業コード.
        /// </summary>
        private string _strTksKgyCd;
        /// <summary>
        /// 得意先企業コードを取得または設定します.
        /// </summary>
        public string TksKgyCd
        {
            get { return _strTksKgyCd; }
            set { _strTksKgyCd = value; }
        }

        /// <summary>
        /// 得意先部門コード.
        /// </summary>
        private string _strTksBmnSeqNo;
        /// <summary>
        /// 得意先部門コードを取得または設定します.
        /// </summary>
        public string TksBmnSeqNo
        {
            get { return _strTksBmnSeqNo; }
            set { _strTksBmnSeqNo = value; }
        }

        /// <summary>
        /// 得意先担当者コード.
        /// </summary>
        private string _strTksTntSeqNo;
        /// <summary>
        /// 得意先担当者コードを取得または設定します.
        /// </summary>
        public string TksTntSeqNo
        {
            get { return _strTksTntSeqNo; }
            set { _strTksTntSeqNo = value; }
        }
        /// <summary>
        /// 広告費明細行データ 
        /// </summary>
        public Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow DataRowUni
        {
            set { dataRow = value; }
            get { return dataRow; }
        }
        /// <summary>
        /// 広告費明細行インデックス 
        /// </summary>
        public int RowDetailIndexUni
        {
            set { rowDetailIndex = value; }
            get { return rowDetailIndex; }
        }
        /// <summary>
        /// スプレッドシート 
        /// </summary>
        public FarPoint.Win.Spread.SheetView SpdKkhDetailUni_Sheet1
        {
            set { spdKkhDetail_Sheet1 = value; }
            get { return spdKkhDetail_Sheet1; }
        }

        ///// </summary>
        //private string _strDate;
        ///// <summary>
        ///// 日付を取得または設定します.
        ///// </summary>
        //public string DateUni
        //{
        //    get { return _strDate; }
        //    set { _strDate = value; }
        //}
    }
}
