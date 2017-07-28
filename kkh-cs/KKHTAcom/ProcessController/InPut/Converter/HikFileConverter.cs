using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Acom.Schema;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;

namespace Isid.KKH.Acom.ProcessController.InPut.Converter
{
    internal class HikFileConverter
    {
        #region メソッド

        //発注データ登録用データコンバータ
        internal static hikRegistVOList ConvertForHikFileInsert(InPutHik dsInPutHik)
        {
            List<hikVO> listTemp = new List<hikVO>();

            hikVO vo;
            foreach (InPutHik.FileImpRow row in dsInPutHik.FileImp.Rows)
            {
                vo = VoConverter.Convert<hikVO>(dsInPutHik, new RowToVoDef(row, null));

                listTemp.Add(vo);
            }

            hikRegistVOList result = new hikRegistVOList();
            result.hikRegistVOList1 = listTemp.ToArray();

            return result;
        }

        //日付データ検索用データコンバータ
        internal static hikSearchDateCntVOList ConvertForHikDateCntSelect(InPutHik dsInPutHik)
        {
            List<hikSearchDateCntVO> listTemp = new List<hikSearchDateCntVO>();

            hikSearchDateCntVO vo;
            foreach (InPutHik.DateCntDataRow row in dsInPutHik.DateCntData.Rows)
            {
                vo = VoConverter.Convert<hikSearchDateCntVO>(dsInPutHik, new RowToVoDef(row, null));

                listTemp.Add(vo);
            }

            hikSearchDateCntVOList result = new hikSearchDateCntVOList();
            result.hikSearchDateCntVOList1 = listTemp.ToArray();

            return result;
        }


        #endregion
    }
}
