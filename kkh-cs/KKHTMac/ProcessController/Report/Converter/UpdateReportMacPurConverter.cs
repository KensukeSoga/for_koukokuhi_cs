using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Common.KKHView.Report;
using Isid.KKH.Mac.Schema;



namespace Isid.KKH.Common.KKHProcessController.Report.Converter
{
    internal class UpdateReportMacPurConverter 
    {

        //internal static List<masterDataVO> ConvertForMasterInsert(Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable masterresult)
        internal static updateReportMacPurVO[] ConvertForMasterInsert(RepDsMac.RepmacUpdPurchaseDataTable datatbvo)
        {
            List<updateReportMacPurVO> listTemp = new List<updateReportMacPurVO>();
            updateReportMacPurVO vo;
            //for (int i = 0; i < datatbvo.Rows.Count; i++)
            //{
            //    vo = VoConverter.Convert<masterDataVO>(datatbvo, new RowToVoDef(i, null));
            //    listTemp.Add(vo);
            //}

            foreach (DataRow row in datatbvo.Rows)
            {
                vo = VoConverter.Convert<updateReportMacPurVO>(datatbvo.DataSet, new RowToVoDef(row, null));
                listTemp.Add(vo);
            }



            updateReportMacPurVO[] result = listTemp.ToArray();
            return result;


        }

    }
}
