using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Isid.KKH.Lion.Schema;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Common.KKHView.Mast;



namespace Isid.KKH.Lion.ProcessController.MastGet.Converter
{
    internal class MasterDataSetConverter 
    {

        //internal static List<masterDataVO> ConvertForMasterInsert(Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable masterresult)
        internal static lionTvMastDataVO[] ConvertForMasterInsert(Isid.KKH.Lion.Schema.MastLion.TvBnLionDataTable datatbvo)
        {
            List<lionTvMastDataVO> listTemp = new List<lionTvMastDataVO>();
            lionTvMastDataVO vo;
            //for (int i = 0; i < datatbvo.Rows.Count; i++)
            //{
            //    vo = VoConverter.Convert<masterDataVO>(datatbvo, new RowToVoDef(i, null));
            //    listTemp.Add(vo);
            //}

            foreach (DataRow row in datatbvo.Rows)
            {
                vo = VoConverter.Convert<lionTvMastDataVO>(datatbvo.DataSet, new RowToVoDef(row, null));
                listTemp.Add(vo);
            }



            lionTvMastDataVO[] result = listTemp.ToArray();
            return result;


        }

        //internal static List<masterDataVO> ConvertForRdMasterInsert(Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable masterresult)
        internal static lionRdMastDataVO[] ConvertForRdMasterInsert(Isid.KKH.Lion.Schema.MastLion.RdBnLionDataTable datatbvo)
        {
            List<lionRdMastDataVO> listTemp = new List<lionRdMastDataVO>();
            lionRdMastDataVO vo;
            //for (int i = 0; i < datatbvo.Rows.Count; i++)
            //{
            //    vo = VoConverter.Convert<masterDataVO>(datatbvo, new RowToVoDef(i, null));
            //    listTemp.Add(vo);
            //}

            foreach (DataRow row in datatbvo.Rows)
            {
                vo = VoConverter.Convert<lionRdMastDataVO>(datatbvo.DataSet, new RowToVoDef(row, null));
                listTemp.Add(vo);
            }



            lionRdMastDataVO[] result = listTemp.ToArray();
            return result;


        }

        //internal static List<masterDataVO> ConvertForTvKMasterInsert(Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable masterresult)
        internal static lionTvKMastDataVO[] ConvertForTvKMasterInsert(Isid.KKH.Lion.Schema.MastLion.TvKLionDataTable datatbvo)
        {
            List<lionTvKMastDataVO> listTemp = new List<lionTvKMastDataVO>();
            lionTvKMastDataVO vo;
            //for (int i = 0; i < datatbvo.Rows.Count; i++)
            //{
            //    vo = VoConverter.Convert<masterDataVO>(datatbvo, new RowToVoDef(i, null));
            //    listTemp.Add(vo);
            //}

            foreach (DataRow row in datatbvo.Rows)
            {
                vo = VoConverter.Convert<lionTvKMastDataVO>(datatbvo.DataSet, new RowToVoDef(row, null));
                listTemp.Add(vo);
            }



            lionTvKMastDataVO[] result = listTemp.ToArray();
            return result;


        }

        //internal static List<masterDataVO> ConvertForRdKMasterInsert(Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable masterresult)
        internal static lionRdKMastDataVO[] ConvertForRdKMasterInsert(Isid.KKH.Lion.Schema.MastLion.RdKLionDataTable datatbvo)
        {
            List<lionRdKMastDataVO> listTemp = new List<lionRdKMastDataVO>();
            lionRdKMastDataVO vo;
            //for (int i = 0; i < datatbvo.Rows.Count; i++)
            //{
            //    vo = VoConverter.Convert<masterDataVO>(datatbvo, new RowToVoDef(i, null));
            //    listTemp.Add(vo);
            //}

            foreach (DataRow row in datatbvo.Rows)
            {
                vo = VoConverter.Convert<lionRdKMastDataVO>(datatbvo.DataSet, new RowToVoDef(row, null));
                listTemp.Add(vo);
            }



            lionRdKMastDataVO[] result = listTemp.ToArray();
            return result;


        }

        //internal static List<masterDataVO> ConvertForMasterInsert(Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable masterresult)
        internal static masterDataVO[] ConvertForMasterInsert(Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable datatbvo)
        {
            List<masterDataVO> listTemp = new List<masterDataVO>();
            masterDataVO vo;
            //for (int i = 0; i < datatbvo.Rows.Count; i++)
            //{
            //    vo = VoConverter.Convert<masterVO>(datatbvo, new RowToVoDef(i, null));
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
