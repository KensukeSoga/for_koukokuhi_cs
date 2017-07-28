using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Common.KKHUtility
{
    /// <summary>
    /// 
    /// </summary>
    public class KKHGetMaxUpdDateByTogo
    {
        # region 受注登録内容(一覧)カラムインデックス
        /// <summary>
        /// 行番号列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_ROWNUM = 26;                   //行番号 
        #endregion 受注登録内容(一覧)カラムインデックス

        /// <summary>
        /// 統合されている受注登録内容のデータから更新日付の最大値を取得する。 
        /// </summary>
        /// <param name="parentSheet"></param>
        /// <param name="parentMaxUpdDate"></param>
        /// <param name="dsDetail"></param>
        /// <returns></returns>
        public DateTime GetMaxUpdDateByTogo(
            FarPoint.Win.Spread.SheetView parentSheet,
            DateTime parentMaxUpdDate, 
            Isid.KKH.Common.KKHSchema.Detail dsDetail)
        {
            //親タイムスタンプをセット 
            DateTime maxUpdDate = parentMaxUpdDate;

            //親シートの現在行を取得する 
            int rowIndex = parentSheet.ActiveRowIndex;

            //子シートを取得する 
            FarPoint.Win.Spread.SheetView childSheet = parentSheet.GetChildView(rowIndex, 0);

            for (int i = 0; i < childSheet.Rows.Count; i++)
            {
                //子シートのDataRowを取得する 
                Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow childRow = dsDetail.JyutyuData.FindByrowNum((int)childSheet.Cells[i, COLIDX_JLIST_ROWNUM].Value);
                //子タイムスタンプが変数より大きい場合 
                if (maxUpdDate < childRow.hb1TimStmp)
                {
                    maxUpdDate = childRow.hb1TimStmp;
                }
            }

            return maxUpdDate;
        }
    }
}
