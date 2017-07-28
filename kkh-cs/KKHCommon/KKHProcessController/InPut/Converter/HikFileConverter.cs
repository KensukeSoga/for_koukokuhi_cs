using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;

namespace Isid.KKH.Common.KKHProcessController.InPut.Converter
{
    internal class HikFileConverter
    {
        #region メソッド

        internal static hikRegistVOList ConvertForHikFileInsert(InPutHik dsInPutHik)
        {
            List<hikRegistVOList> listTemp = new List<hikRegistVOList>();

            hikRegistVOList vo;
            foreach (InPutHik.FileImpRow row in dsInPutHik.FileImp.Rows)
            {
                vo = VoConverter.Convert<hikRegistVOList>(dsInPutHik, new RowToVoDef(row,null));

                listTemp.Add(vo);
            }

            //hikRegistVOList result = listTemp.ToArray();
            hikRegistVOList result = listTemp[0];

            return result;
        }

        #endregion
    }
}
