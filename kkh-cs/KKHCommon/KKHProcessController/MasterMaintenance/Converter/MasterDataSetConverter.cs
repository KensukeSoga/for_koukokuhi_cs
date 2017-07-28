using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Common.KKHView.Mast;



namespace Isid.KKH.Common.KKHProcessController.MasterMaintenance.Converter
{
    internal class MasterDataSetConverter 
    {

        //internal static List<masterDataVO> ConvertForMasterInsert(Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable masterresult)
        internal static masterDataVO[] ConvertForMasterInsert(Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable datatbvo)
        {
            List<masterDataVO> listTemp = new List<masterDataVO>();
            masterDataVO vo;
            //for (int i = 0; i < datatbvo.Rows.Count; i++)
            //{
            //    vo = VoConverter.Convert<masterDataVO>(datatbvo, new RowToVoDef(i, null));
            //    listTemp.Add(vo);
            //}

            foreach (DataRow row in datatbvo.Rows)
            {
                vo = VoConverter.Convert<masterDataVO>(datatbvo.DataSet, new RowToVoDef(row, null));
                listTemp.Add(vo);
            }



            masterDataVO[] result = listTemp.ToArray();
            return result;


        }

    }
}
