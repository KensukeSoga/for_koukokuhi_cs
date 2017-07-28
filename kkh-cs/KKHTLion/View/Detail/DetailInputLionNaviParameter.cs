using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHView.Detail;
using Isid.KKH.Lion.ProcessController.MastGet;

namespace Isid.KKH.Lion.View.Detail
{
    class DetailInputLionNaviParameter : DetailFormNaviParameter
    {
        public DetailInputLionNaviParameter()
        {
        }

        public DetailInputLionNaviParameter(DetailFormNaviParameter naviParameter)
        {
            //共通系の項目を初期値として引き継ぐ 
            if (naviParameter is DetailInputLionNaviParameter)
            {
            }
            else
            {
                this.strEsqId = naviParameter.strEsqId;
                this.strEgcd = naviParameter.strEgcd;
                this.strTksKgyCd = naviParameter.strTksKgyCd;
                this.strTksBmnSeqNo = naviParameter.strTksBmnSeqNo;
                this.strTksTntSeqNo = naviParameter.strTksTntSeqNo;
            }
        }
        //カードCDor業務区分での画面パターン制御 
        string npStrTypePtan;
        //媒体CD 
        string npBaitaiCd;
        //明細データ存在時のカードＮＯ 
        string npMeiCardNo;
        //番組、局、料金データ 
        Isid.KKH.Lion.Schema.MastLion.TvKeiKinSetDataTable nprTvRmast;//TV料金マスタ用 
        Isid.KKH.Lion.Schema.MastLion.RdKeiKinSetDataTable nprRdRmast;//RD料金マスタ用 
        FindLionMastByCondServiceResult nprTvBmast;//TV番組マスタ用 
        FindLionMastByCondServiceResult nprRdBmast;//RD番組マスタ用 
        FindLionMastByCondServiceResult nprTvKmast;//TV局マスタ用 
        FindLionMastByCondServiceResult nprRdKmast;//RD局マスタ用 
        Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable dtTvHenMast;//TV変換マスタ 
        Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable dtRdHenMast;//RD変換マスタ 
        

        //パターン（業務区分、カードＮＯで分岐） 
        public string pStrTypePtan
        {
            set { npStrTypePtan = value; }
            get { return npStrTypePtan; }
        }

        //媒体CD 
        public string pBaitaiCd
        {
            set { npBaitaiCd = value; }
            get { return npBaitaiCd; }
        }

        //明細データ存在時のカードＮＯ 
        public string pMeiCardNo
        {
            set { npMeiCardNo = value; }
            get { return npMeiCardNo; }
        }

        //TV番組マスタ 
        public FindLionMastByCondServiceResult prTvBmast
        {
            set { nprTvBmast = value; }
            get { return nprTvBmast; }
        }

        //RD番組マスタ 
        public FindLionMastByCondServiceResult prRdBmast
        {
            set { nprRdBmast = value; }
            get { return nprRdBmast; }
        }

        //TV局マスタ 
        public FindLionMastByCondServiceResult prTvKmast
        {
            set { nprTvKmast = value; }
            get { return nprTvKmast; }
        }

        //RD局マスタ 
        public FindLionMastByCondServiceResult prRdKmast
        {
            set { nprRdKmast = value; }
            get { return nprRdKmast; }
        }

        //TV料金マスタ 
        public Isid.KKH.Lion.Schema.MastLion.TvKeiKinSetDataTable prTvRmast
        {
            set { nprTvRmast = value; }
            get { return nprTvRmast; }
        }

        //RD料金マスタ 
        public Isid.KKH.Lion.Schema.MastLion.RdKeiKinSetDataTable prRdRmast
        {
            set { nprRdRmast = value; }
            get { return nprRdRmast; }
        }

        /// <summary>
        /// TV局コード変換マスタデータテーブル 
        /// </summary>
        public Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable DtTvHenMast
        {
            set { dtTvHenMast = value; }
            get { return dtTvHenMast; }
        }

        /// <summary>
        /// RD局コード変換マスタデータテーブル 
        /// </summary>
        public Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable DtRdHenMast
        {
            set { dtRdHenMast = value; }
            get { return dtRdHenMast; }
        }
    }
}
