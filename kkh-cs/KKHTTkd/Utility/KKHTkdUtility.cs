using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility;

namespace Isid.KKH.Tkd.Utility
{
    class KKHTkdUtility
    {
        /// <summary>
        /// 消費税率マスタ取得キー：0003 
        /// </summary>
        private const string MST_TAX = "0003";

        /// <summary>
        /// 消費税率 
        /// </summary>
        private const string DEF_TAX = "5.00";

        /// <summary>
        /// 消費税率を取得する 
        /// </summary>
        /// <returns>消費税率</returns>
        public static string GetTax(String strEsqId, String strEgcd, String strTksKgyCd, String strTksBmnSeqNo, String strTksTntSeqNo)
        {
            string ret = DEF_TAX;

            MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult result;
            MasterMaintenance ds;
            MasterMaintenance.MasterDataVORow[] rows;

            // 商品名取得 
            result = process.FindMasterByCond(strEsqId, strEgcd, strTksKgyCd, strTksBmnSeqNo, strTksTntSeqNo, MST_TAX, null);

            ds = result.MasterDataSet;
            rows = (MasterMaintenance.MasterDataVORow[])ds.MasterDataVO.Select();

            foreach (MasterMaintenance.MasterDataVORow row in rows)
            {
                // 期間Fromと期間Toを取得 
                DateTime now = DateTime.Now;
                DateTime from = KKHUtility.StringCnvDateTime(row.Column1);
                DateTime to = KKHUtility.StringCnvDateTime(row.Column2);

                // 期間内の消費税率を使用する 
                if (now.CompareTo(from) > 0 && now.CompareTo(to) < 0)
                {
                    ret = row.Column3;
                    break;
                }
            }

            return KKHUtility.DecParse(ret).ToString("0.00");
        }
    }
}
