using System;
using System.Collections.Generic;
using System.Text;
using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Common.KKHServiceProxy;

namespace Isid.KKH.Kmn.ProcessController.Converter
{
    public class RepKmnListDataSetConverter
    {
        /// <summary>
        /// 請求明細一覧データセットコンバーター 
        /// </summary>
        /// <param name="dsRepKmn"></param>
        /// <returns></returns>
        public static reportKmnListVO[] ConvertForRepKmnList(Isid.KKH.Kmn.Schema.RepDSKmn dsRepKmn)
        {
            reportKmnListVO[] repKmnList = new reportKmnListVO[dsRepKmn.RepKmnList.Rows.Count];

            for (int i = 0; i < dsRepKmn.RepKmnList.Rows.Count; i++)
            {
                Isid.KKH.Kmn.Schema.RepDSKmn.RepKmnListRow row = (Isid.KKH.Kmn.Schema.RepDSKmn.RepKmnListRow)dsRepKmn.RepKmnList.Rows[i];
                repKmnList[i] = VoConverter.Convert<reportKmnListVO>(dsRepKmn, new RowToVoDef(row));
            }

            return repKmnList;
        }
    }
}
