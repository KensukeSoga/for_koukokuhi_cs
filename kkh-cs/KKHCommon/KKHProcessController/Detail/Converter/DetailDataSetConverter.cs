using System;
using System.Collections.Generic;
using System.Text;

using Isid.Soa.Framework.Client.DataSetConverter;

using Isid.KKH.Common.KKHServiceProxy;

namespace Isid.KKH.Common.KKHProcessController.Detail.Converter
{
    /// <summary>
    /// 
    /// </summary>
    public class DetailDataSetConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dsDetail"></param>
        /// <returns></returns>
        public static thb1DownVO[] ConvertForTHB1DOWN(Isid.KKH.Common.KKHSchema.Detail dsDetail)
        {
            thb1DownVO[] thb1DownList = new thb1DownVO[dsDetail.THB1DOWN.Rows.Count];

            for (int i = 0; i < dsDetail.THB1DOWN.Rows.Count; i++)
            {
                Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow row = (Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow)dsDetail.THB1DOWN.Rows[i];
                thb1DownList[i] = VoConverter.Convert<thb1DownVO>(dsDetail, new RowToVoDef(row));
            }

            return thb1DownList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dsDetail"></param>
        /// <returns></returns>
        public static thb2KmeiVO[] ConvertForTHB2KMEI(Isid.KKH.Common.KKHSchema.Detail dsDetail)
        {
            thb2KmeiVO[] thb2KmeiList = new thb2KmeiVO[dsDetail.THB2KMEI.Rows.Count];

            for (int i = 0; i < dsDetail.THB2KMEI.Rows.Count; i++)
            {
                Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow row = (Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow)dsDetail.THB2KMEI.Rows[i];
                thb2KmeiList[i] = VoConverter.Convert<thb2KmeiVO>(dsDetail, new RowToVoDef(row));
            }

            return thb2KmeiList;
        }
    }
}
