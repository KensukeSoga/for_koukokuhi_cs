using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHSchema;
using System.Collections;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHView.Common;

namespace Isid.KKH.Epson.Utility
{
    class KkhMasterUtilityEpson
    {
        #region 構造体

        /// <summary>
        /// 取引識別情報マスタ格納用
        /// </summary>
        public class TRISIKI_DATA
        {
            /// <summary>
            /// キーコード
            /// </summary>
            public String keyCode;

            /// <summary>
            /// 取引識別情報コード
            /// </summary>
            public String code;

            /// <summary>
            /// 取引識別情報名
            /// </summary>
            public String name;

            /// <summary>
            /// 指図番号
            /// </summary>
            public String ssNo;

            /// <summary>
            /// セグメント番号
            /// </summary>
            public String segNo;

            /// <summary>
            /// ソートキー
            /// </summary>
            public String sortKey;
        };

        /// <summary>
        /// 取引担当者マスタ格納用
        /// </summary>
        public class TRITNT_DATA
        {
            /// <summary>
            /// 取引担当者コード
            /// </summary>
            public String code;

            /// <summary>
            /// 取引担当者名
            /// </summary>
            public String name;
        };

        #endregion

        #region 定数

        #region マスタ検索キー

        /// <summary>
        /// 取引識別情報マスタ取得キー：0001 
        /// </summary>
        internal const string MST_TRISIKI = "0001";

        /// <summary>
        /// 取引担当者マスタ取得キー：0002 
        /// </summary>
        internal const string MST_TRITNT = "0002";

        #endregion

        #endregion

        #region メンバ変数

        #region マスタデータ

        /// <summary>
        /// 取引識別情報マスタ
        /// </summary>
        Hashtable _trisikiList = null;

        /// <summary>
        /// 取引担当者マスタ
        /// </summary>
        Hashtable _tritntList = null;

        /// <summary>
        /// 取引担当者マスタ
        /// </summary>
        //Hashtable _siiresakiList = null;


        #endregion

        #endregion

        #region メソッド

        /// <summary>
        /// マスタ情報を取得する 
        /// </summary>
        public void GetMasterData( KKHNaviParameter naviParam )
        {
            #region 取引識別情報の取得.

            {
                // 取引識別情報マスタ情報取得.

                MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();

                FindMasterMaintenanceByCondServiceResult result = process.FindMasterByCond
                (
                    naviParam.strEsqId,
                    naviParam.strEgcd,
                    naviParam.strTksKgyCd,
                    naviParam.strTksBmnSeqNo,
                    naviParam.strTksTntSeqNo,
                    MST_TRISIKI,
                    null
                );

                MasterMaintenance ds = result.MasterDataSet;

                MasterMaintenance.MasterDataVORow[] rows = (MasterMaintenance.MasterDataVORow[])ds.MasterDataVO.Select();

                Hashtable trisikiList = new Hashtable();

                foreach (MasterMaintenance.MasterDataVORow row in rows)
                {
                    TRISIKI_DATA t = new TRISIKI_DATA();

                    t.keyCode = row.Column1;

                    t.code = row.Column2;

                    t.name = row.Column3;

                    t.ssNo = row.Column4;

                    t.segNo = row.Column5;

                    t.sortKey = row.Column6;

                    trisikiList.Add(t.keyCode, t);
                }

                _trisikiList = trisikiList;
            }

            #endregion

            #region 取引担当者情報の取得.

            {
                // 取引担当者マスタ情報取得.

                MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();

                FindMasterMaintenanceByCondServiceResult result = process.FindMasterByCond
                (
                    naviParam.strEsqId,
                    naviParam.strEgcd,
                    naviParam.strTksKgyCd,
                    naviParam.strTksBmnSeqNo,
                    naviParam.strTksTntSeqNo,
                    MST_TRITNT,
                    null
                );

                MasterMaintenance ds = result.MasterDataSet;

                MasterMaintenance.MasterDataVORow[] rows = (MasterMaintenance.MasterDataVORow[])ds.MasterDataVO.Select();

                Hashtable tritntList = new Hashtable();

                foreach (MasterMaintenance.MasterDataVORow row in rows)
                {
                    TRITNT_DATA t = new TRITNT_DATA();

                    t.code = row.Column1;

                    t.name = row.Column2;

                    tritntList.Add(t.code, t);
                }

                _tritntList = tritntList;
            }

            #endregion

        }

        /// <summary>
        /// 取引識別情報マスタの取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public TRISIKI_DATA GetTRISIKI(String code)
        {
            TRISIKI_DATA retval = null;

            if (_trisikiList.Contains(code))
            {
                retval = (TRISIKI_DATA)_trisikiList[code];
            }

            return retval;
        }

        /// <summary>
        /// 取引担当者マスタの取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public TRITNT_DATA GetTRITNT(String code)
        {
            TRITNT_DATA retval = null;

            if (_tritntList.Contains(code))
            {
                retval = (TRITNT_DATA)_tritntList[code];
            }

            return retval;
        }

       
        #endregion

         
    }
}
