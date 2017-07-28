using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Common.KKHView.Mast;


namespace Isid.KKH.Mac.ProcessController.MasterMaintenance.Converter
{
    internal class MacMasterDataSetConverter 
    {
        internal static masterDataVO[] ConvertForMacMasterInsert(Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable datatbvo)
        {
            List<masterDataVO> listTemp = new List<masterDataVO>();
            masterDataVO vo;

            foreach (DataRow row in datatbvo.Rows)
            {
                vo = VoConverter.Convert<masterDataVO>(datatbvo.DataSet, new RowToVoDef(row, null));
                listTemp.Add(vo);
            }



            masterDataVO[] result = listTemp.ToArray();
            return result;


        }

        // 2012/02/01 add start H.Okazaki
        internal static findMasterMacTnpRKeyByCondVO[] ConvertForMacUpdMstKeyTnpRrkInsert(Isid.KKH.Mac.Schema.MastDSMac.TenpoRrkDataTable datatbvo)
        {
            List<findMasterMacTnpRKeyByCondVO> listTemp = new List<findMasterMacTnpRKeyByCondVO>();
            findMasterMacTnpRKeyByCondVO vo;

            foreach (DataRow row in datatbvo.Rows)
            {
                vo = VoConverter.Convert<findMasterMacTnpRKeyByCondVO>(datatbvo.DataSet, new RowToVoDef(row, null));
                listTemp.Add(vo);
            }

            findMasterMacTnpRKeyByCondVO[] result = listTemp.ToArray();
            return result;
        }

        internal static findMasterMacTnpRByCondVO[] ConvertForMacMasterTnpRrkInsert(Isid.KKH.Mac.Schema.MastDSMac.TenpoRrkDataTable datatbvo)
        {
            List<findMasterMacTnpRByCondVO> listTemp = new List<findMasterMacTnpRByCondVO>();
            findMasterMacTnpRByCondVO vo;

            foreach (DataRow row in datatbvo.Rows)
            {
                vo = VoConverter.Convert<findMasterMacTnpRByCondVO>(datatbvo.DataSet, new RowToVoDef(row, null));
                listTemp.Add(vo);
            }
            
            findMasterMacTnpRByCondVO[] result = listTemp.ToArray();
            return result;
        }
        // 2012/02/01 add end H.Okazaki

    }
}
