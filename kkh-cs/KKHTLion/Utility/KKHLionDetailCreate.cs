using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHView.Detail;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Lion.Schema;
using Isid.KKH.Lion.ProcessController.MastGet;
using Isid.KKH.Lion.ProcessController.Detail;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Lion.Utility;

namespace Isid.KKH.Lion.Utility
{
    class KKHLionDetailCreate
    {
        /// <summary>
        /// ライオンコード取得(局誌コードの電通→ライオン変換).
        /// </summary>
        /// <param name="row"></param>
        /// <param name="_naviParameter"></param>
        /// <returns></returns>
        public string GetLionCd(Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow row,KKHNaviParameter _naviParameter)
        {
            Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable dtMaster = new Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable();
            string masterKey = "";   //取得マスタのマスタキー 
            string filter = "";      //抽出条件.
            //業務区分によって使用するマスタ、取得条件を変更する
            //新聞.
            if (row.hb1GyomKbn == KKHSystemConst.GyomKbn.Shinbun)
            {
                masterKey = KKHLionConst.C_MAST_SHINBUN_HEN_CD;
                filter = dtMaster.Column1Column.ColumnName + "='" + row.hb1Field1 + "' AND " + dtMaster.Column2Column.ColumnName + "='" + row.hb1Field4 + ".0000'";
            }
            //雑誌.
            else if (row.hb1GyomKbn == KKHSystemConst.GyomKbn.Zashi)
            {
                masterKey = KKHLionConst.C_MAST_ZASHI_HEN_CD;
                filter = dtMaster.Column1Column.ColumnName + "='" + row.hb1Field1 + "'";
            }
            //テレビ、テレビスポット.
            else if (row.hb1GyomKbn == KKHSystemConst.GyomKbn.TVTime || row.hb1GyomKbn == KKHSystemConst.GyomKbn.TVSpot)
            {
                masterKey = KKHLionConst.C_MAST_TV_HEN_CD;
                filter = dtMaster.Column1Column.ColumnName + "='" + row.hb1Field1 + "'";
            }
            //ラジオ
            else if (row.hb1GyomKbn == KKHSystemConst.GyomKbn.Radio)
            {
                masterKey = KKHLionConst.C_MAST_RADIO_HEN_CD;
                filter = dtMaster.Column1Column.ColumnName + "='" + row.hb1Field1 + "'";
            }
            //インタラクティブ.
            else if (row.hb1GyomKbn == KKHSystemConst.GyomKbn.InteractiveM)
            {
                masterKey = KKHLionConst.C_MAST_SONOTA_HEN_CD;
                filter = dtMaster.Column1Column.ColumnName + "='" + row.hb1Field1 + "'";
            }
            //BS/CS
            else if (row.hb1GyomKbn == KKHSystemConst.GyomKbn.EiseiM)
            {
                //※とりあえずテレビ変換マスタを検索する(現行は全変換マスタを検索).
                masterKey = KKHLionConst.C_MAST_TV_HEN_CD;
                filter = dtMaster.Column1Column.ColumnName + "='" + row.hb1Field1 + "'";
            }
            else
            {
            }

            if (masterKey == "")
            {
                return "";
            }

            //マスタデータから取得条件に一致するデータを抽出.
            dtMaster = FindMasterData(masterKey, _naviParameter);
            //DataRow[] dr = dtMaster.Select("");
            DataRow[] dr = dtMaster.Select(filter);
            if (dr.Length == 0)
            {
                return "";
            }
            Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow mastRow = (Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow)dr[0];

            //業務区分によってライオンコードの取得する項目を変更.
            if (row.hb1GyomKbn == KKHSystemConst.GyomKbn.Shinbun)
            {
                return mastRow.Column3;
            }
            else
            {
                return mastRow.Column2;
            }

            //return "";
        }

        //***************************************************
        //検索データ保持用Hashtable
        //　再利用するデータ(マスタデータ等)を保持.
        //***************************************************
        //マスタデータ.
        public Hashtable htMasterData = new Hashtable();

        /// <summary>
        /// 汎用マスタの検索を行う.
        /// </summary>
        /// <param name="masterKey">取得するマスタのマスタキー</param>
        /// <param name="_naviParameter"></param>
        /// <returns></returns>
        public Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable FindMasterData(string masterKey,
            KKHNaviParameter _naviParameter)
        {
            Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable rv;

            if (htMasterData[masterKey] == null/* || reFlag == true*/)
            {

                Isid.KKH.Common.KKHProcessController.MasterMaintenance.MasterMaintenanceProcessController proccessController = Isid.KKH.Common.KKHProcessController.MasterMaintenance.MasterMaintenanceProcessController.GetInstance();
                FindMasterMaintenanceByCondServiceResult result = proccessController.FindMasterByCond(
                                                                        _naviParameter.strEsqId
                                                                        , _naviParameter.strEgcd
                                                                        , _naviParameter.strTksKgyCd
                                                                        , _naviParameter.strTksBmnSeqNo
                                                                        , _naviParameter.strTksTntSeqNo
                                                                        , masterKey
                                                                        , ""
                                                                    );
                rv = result.MasterDataSet.MasterDataVO;
                htMasterData[masterKey] = result.MasterDataSet.MasterDataVO;
            }
            else
            {
                rv = (Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable)htMasterData[masterKey];
            }

            return rv;
        }

        /// <summary>
        /// カードNO,媒体区分での項目変更用 kbn:業務orカードNO/no:カードNOor業務区分.
        /// </summary>
        public string CardNoAndBaitaiKbnKmkCheck(string kbn, string no, string seikbn)
        {
            //業務の場合.
            if (kbn.ToString().Equals(KKHLionConst.COLSTR_BTPATARN))
            {
                //テレビタイム、ラジオタイム、BSCS
                if (no.ToString().Equals(KKHLionConst.COLSTR_GYOM_TV)
                    || (no.ToString().Equals(KKHLionConst.COLSTR_GYOM_RD) && seikbn.ToString().Equals(KKHLionConst.gcstrSeikbn_Tm))
                    || no.ToString().Equals(KKHLionConst.COLSTR_GYOM_BSCS))
                {
                    return KKHLionConst.COLSTR_KMKTYPE_1;
                }
                //スポット(TVorRADIO)
                else if (no.ToString().Equals(KKHLionConst.COLSTR_GYOM_SPOT)
                    || (no.ToString().Equals(KKHLionConst.COLSTR_GYOM_RD) && seikbn.ToString().Equals(KKHLionConst.gcstrSeikbn_Sp)))
                {
                    return KKHLionConst.COLSTR_KMKTYPE_2;
                }
                //新聞.
                else if (no.ToString().Equals(KKHLionConst.COLSTR_GYOM_SINBN))
                {
                    return KKHLionConst.COLSTR_KMKTYPE_3;
                }
                //雑誌.
                else if (no.ToString().Equals(KKHLionConst.COLSTR_GYOM_ZASSI))
                {
                    return KKHLionConst.COLSTR_KMKTYPE_4;
                }
                //交通.
                else if (no.ToString().Equals(KKHLionConst.COLSTR_GYOM_KOTU))
                {
                    return KKHLionConst.COLSTR_KMKTYPE_5;
                }
                //その他系.
                else if (no.ToString().Equals(KKHLionConst.COLSTR_GYOM_SONOTA1) ||
                no.ToString().Equals(KKHLionConst.COLSTR_GYOM_SONOTA2) ||
                no.ToString().Equals(KKHLionConst.COLSTR_GYOM_SONOTA3) ||
                no.ToString().Equals(KKHLionConst.COLSTR_GYOM_SONOTA4) ||
                no.ToString().Equals(KKHLionConst.COLSTR_GYOM_SONOTA5) ||
                no.ToString().Equals(KKHLionConst.COLSTR_GYOM_SONOTA6))
                {
                    return KKHLionConst.COLSTR_KMKTYPE_6;
                }
                //制作.
                else if (no.ToString().Equals(KKHLionConst.COLSTR_GYOM_SEISAKU))
                {
                    return KKHLionConst.COLSTR_KMKTYPE_7;
                }
                //インターネット、モバイル.
                else
                {
                    return KKHLionConst.COLSTR_KMKTYPE_8;
                }
            }
            //カードNOの場合.
            else if (kbn.ToString().Equals(KKHLionConst.COLSTR_CDPATARN))
            {
                //テレビタイム、ラジオタイム、BSCS
                if (no.ToString().Equals(KKHLionConst.COLSTR_CARDNO_TVNET) ||
                    no.ToString().Equals(KKHLionConst.COLSTR_CARDNO_RDNET) ||
                    no.ToString().Equals(KKHLionConst.COLSTR_CARDNO_TVLCL) ||
                    no.ToString().Equals(KKHLionConst.COLSTR_CARDNO_RDLCL) ||
                    no.ToString().Equals(KKHLionConst.COLSTR_CARDNO_BSCS)
                    )
                {
                    return KKHLionConst.COLSTR_KMKTYPE_1;
                }
                //テレビスポット.
                else if (no.ToString().Equals(KKHLionConst.COLSTR_CARDNO_SPOT))
                {
                    return KKHLionConst.COLSTR_KMKTYPE_2;
                }
                //新聞.
                else if (no.ToString().Equals(KKHLionConst.COLSTR_CARDNO_SINBN))
                {
                    return KKHLionConst.COLSTR_KMKTYPE_3;
                }
                //雑誌.
                else if (no.ToString().Equals(KKHLionConst.COLSTR_CARDNO_ZASSI))
                {
                    return KKHLionConst.COLSTR_KMKTYPE_4;
                }
                //交通.
                else if (no.ToString().Equals(KKHLionConst.COLSTR_CARDNO_KOTU))
                {
                    return KKHLionConst.COLSTR_KMKTYPE_5;
                }
                //その他、チラシ、サンプリング、事業費.
                else if (no.ToString().Equals(KKHLionConst.COLSTR_CARDNO_SONOTA) ||
                    no.ToString().Equals(KKHLionConst.COLSTR_CARDNO_CHIRASI) ||
                    no.ToString().Equals(KKHLionConst.COLSTR_CARDNO_SAMPLING) ||
                    no.ToString().Equals(KKHLionConst.COLSTR_CARDNO_JIGYOHI))
                {
                    return KKHLionConst.COLSTR_KMKTYPE_6;
                }
                //制作.
                else if (no.ToString().Equals(KKHLionConst.COLSTR_CARDNO_SEISAKU))
                {
                    return KKHLionConst.COLSTR_KMKTYPE_7;
                }
                //インターネット、モバイル.
                else if (no.ToString().Equals(KKHLionConst.COLSTR_CARDNO_INTERNET) ||
                        no.ToString().Equals(KKHLionConst.COLSTR_CARDNO_MOBIL))
                {
                    return KKHLionConst.COLSTR_KMKTYPE_8;
                }
            }

            return "";
        }

        /// <summary>
        /// 明細スプレッドの項目名、幅、編集可能、不可設定.
        /// </summary>
        /// <param name="TrkOrInp">明細登録、入力どちらからの呼び出しか</param>
        /// <param name="spread"></param>
        /// <returns></returns>
        public void sheetset(string TrkOrInp,FarPoint.Win.Spread.SheetView spread)
        {
            //スプレッドの項目の設定.
            foreach (Column col in spread.Columns)
            {
                //共通設定.
                col.Locked = true;//セルの編集不可.
                col.AllowAutoFilter = true;//フィルタ機能を有効.
                col.AllowAutoSort = true;  //ソート機能を有効.

                //列毎に異なる設定.
                //カードNO.
                if (col.Index == KKHLionConst.COLIDX_MLIST_CARDNO)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_CARDNO;
                    col.Width = 70;
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                //請求書番号.
                else if (col.Index == KKHLionConst.COLIDX_MLIST_SEIKYUNO)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_SEIKYUNO;
                    col.Width = 100;
                }
                //年月.
                else if (col.Index == KKHLionConst.COLIDX_MLIST_YYMM)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_YYMM;
                    col.Width = 100;
                }
                //代理店.
                else if (col.Index == KKHLionConst.COLIDX_MLIST_DAIRITEN)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_DAIRITEN;
                    col.Width = 100;
                }
                //媒体CD
                else if (col.Index == KKHLionConst.COLIDX_MLIST_BAITAI)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_BAITAI;
                    col.Width = 100;
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                //番組CD
                else if (col.Index == KKHLionConst.COLIDX_MLIST_BANGCD)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_BANGCD;
                    col.Width = 100;
                }
                //費目CD
                else if (col.Index == KKHLionConst.COLIDX_MLIST_HIMKCD)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_HIMKCD;
                    col.Width = 100;
                }
                //ブランドCD
                else if (col.Index == KKHLionConst.COLIDX_MLIST_BRANDCD)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_BRANDCD;
                    col.Width = 200;
                }
                //府県CD
                else if (col.Index == KKHLionConst.COLIDX_MLIST_FUKENCD)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_FUKENCD;
                    col.Width = 100;
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                //局誌CD
                else if (col.Index == KKHLionConst.COLIDX_MLIST_KYOKUSICD)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_KYOKUSICD;
                    col.Width = 100;
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                //可変項目STR1
                else if (col.Index == KKHLionConst.COLIDX_MLIST_STR1)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_STR1_KYOKU;
                    col.Width = 200;
                }
                //NETFC.
                else if (col.Index == KKHLionConst.COLIDX_MLIST_NETFC)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_NETFC;
                    col.Width = 100;
                }
                //スペース.
                else if (col.Index == KKHLionConst.COLIDX_MLIST_SPACE)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_SPACE;
                    col.Width = 200;
                }
                //可変項目INT1
                else if (col.Index == KKHLionConst.COLIDX_MLIST_INT1)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_INT1_JISI;
                    col.Width = 100;
                    col.CellType = new NumberCellType();
                    NumberCellType cellType = (NumberCellType)col.CellType;
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    cellType.MaximumValue = 99999999999999;
                    cellType.MinimumValue = 0;
                }
                //実施電波料.
                else if (col.Index == KKHLionConst.COLIDX_MLIST_JISIDENPA)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_JISIDENPA;
                    col.Width = 100;
                    col.CellType = new NumberCellType();
                    NumberCellType cellType = (NumberCellType)col.CellType;
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    //cellType.MaximumValue = 99999999999999;
                    cellType.MaximumValue = 9999999999999;
                    cellType.MinimumValue = 0;
                }
                //値引率.
                else if (col.Index == KKHLionConst.COLIDX_MLIST_NBKRITU)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_NBKRITU;
                    col.Width = 100;
                    col.CellType = new NumberCellType();
                    NumberCellType cellType = (NumberCellType)col.CellType;
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    cellType.MaximumValue = 999;
                    cellType.MinimumValue = -999;
                }
                //値引き電波料.
                else if (col.Index == KKHLionConst.COLIDX_MLIST_NBKDENPARYO)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_NBKDENPARYO;
                    col.Width = 100;
                    col.CellType = new NumberCellType();
                    NumberCellType cellType = (NumberCellType)col.CellType;
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    //cellType.MaximumValue = 99999999999999;
                    cellType.MaximumValue = 9999999999999;
                    cellType.MinimumValue = 0;
                }
                //ネット料.
                else if (col.Index == KKHLionConst.COLIDX_MLIST_NETRYO)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_NETRYO;
                    col.Width = 100;
                    col.CellType = new NumberCellType();
                    NumberCellType cellType = (NumberCellType)col.CellType;
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    //cellType.MaximumValue = 99999999999999;
                    cellType.MaximumValue = 9999999999999;
                    cellType.MinimumValue = 0;
                }
                //可変INT2
                else if (col.Index == KKHLionConst.COLIDX_MLIST_INT2)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_INT2_SEISAKU;
                    col.Width = 100;
                    col.CellType = new NumberCellType();
                    NumberCellType cellType = (NumberCellType)col.CellType;
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    //cellType.MaximumValue = 99999999999999;
                    cellType.MaximumValue = 9999999999999;
                    cellType.MinimumValue = 0;
                }
                //値引き合計金額.
                else if (col.Index == KKHLionConst.COLIDX_MLIST_NBKGOKNGK)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_NBKGOKNGK;
                    col.Width = 100;
                    col.CellType = new NumberCellType();
                    NumberCellType cellType = (NumberCellType)col.CellType;
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    //cellType.MaximumValue = 99999999999999;
                    cellType.MaximumValue = 9999999999999;
                    cellType.MinimumValue = 0;
                }
                //税率.
                else if (col.Index == KKHLionConst.COLIDX_MLIST_TAXRITU)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_TAXRITU;
                    col.Width = 100;
                    col.CellType = new NumberCellType();
                    NumberCellType cellType = (NumberCellType)col.CellType;
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    cellType.MaximumValue = 99;
                    cellType.MinimumValue = 0;
                }
                //消費税.
                else if (col.Index == KKHLionConst.COLIDX_MLIST_TAX)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_TAX;
                    col.Width = 100;
                    col.CellType = new NumberCellType();
                    NumberCellType cellType = (NumberCellType)col.CellType;
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    cellType.MaximumValue = 99999999999999;
                    cellType.MinimumValue = 0;
                }
                //本数.
                else if (col.Index == KKHLionConst.COLIDX_MLIST_HONSU)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_HONSU;
                    col.Width = 100;
                    col.CellType = new NumberCellType();
                    NumberCellType cellType = (NumberCellType)col.CellType;
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = false;
                    cellType.MaximumValue = 999;
                    cellType.MinimumValue = 0;
                }
                //秒数.
                else if (col.Index == KKHLionConst.COLIDX_MLIST_BYOSU)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_BYOSU;
                    col.Width = 100;
                    col.CellType = new NumberCellType();
                    NumberCellType cellType = (NumberCellType)col.CellType;
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = false;
                    cellType.MaximumValue = 99999999;
                    cellType.MinimumValue = 0;
                }
                //総秒数.
                else if (col.Index == KKHLionConst.COLIDX_MLIST_SOBYOSU)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_SOBYOSU;
                    col.Width = 100;
                    col.CellType = new NumberCellType();
                    NumberCellType cellType = (NumberCellType)col.CellType;
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = false;
                    cellType.MaximumValue = 99999999;
                    cellType.MinimumValue = 0;
                }
                //放送回数.
                else if (col.Index == KKHLionConst.COLIDX_MLIST_HOSOSU)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_HOSOSU;
                    col.Width = 100;
                }
                //休止回数.
                else if (col.Index == KKHLionConst.COLIDX_MLIST_KYUSISU)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_KYUSISU;
                    col.Width = 100;
                }
                //オンエアー数.
                else if (col.Index == KKHLionConst.COLIDX_MLIST_ONAIRSU)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_ONAIRSU;
                    col.Width = 100;
                }
                //件名.
                else if (col.Index == KKHLionConst.COLIDX_MLIST_KENMEI)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_KENMEI;
                    col.Width = 300;
                }
                //掲載.
                else if (col.Index == KKHLionConst.COLIDX_MLIST_KEISAI)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_KEISAI;
                    col.Width = 100;
                }
                //路線.
                else if (col.Index == KKHLionConst.COLIDX_MLIST_ROSEN)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_ROSEN;
                    col.Width = 200;
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                //期間.
                else if (col.Index == KKHLionConst.COLIDX_MLIST_KIKAN)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_KIKAN;
                    col.Width = 200;
                }
                //備考.
                else if (col.Index == KKHLionConst.COLIDX_MLIST_BIKO)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_BIKO;
                    col.Width = 200;
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                //売上明細NO
                else if (col.Index == KKHLionConst.COLIDX_MLIST_URIMEI)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_URIMEI;
                    col.Width = 200;
                }
                //表示順.
                else if (col.Index == KKHLionConst.COLIDX_MLIST_HYOJIJYN)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_HYOJIJYN;
                    col.Width = 100;
                }
                //地区合計.
                else if (col.Index == KKHLionConst.COLIDX_MLIST_TIKUGO)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_TIKUGO;
                    col.Width = 100;
                    //col.CellType = (NumberCellType)col.CellType;
                    col.CellType = new NumberCellType();
                    NumberCellType cellType = (NumberCellType)col.CellType;
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    cellType.MaximumValue = 99999999999999;
                    cellType.MinimumValue = 0;
                }
                //地区CD
                else if (col.Index == KKHLionConst.COLIDX_MLIST_TIKUCD)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_TIKUCD;
                    col.Width = 100;
                }
                //件名変更フラグ.
                else if (col.Index == KKHLionConst.COLIDX_MLIST_KENCHANGE)
                {
                    col.Label = KKHLionConst.COLSTR_MLIST_KENCHANGE;
                    col.Width = 100;
                }

                if (col.CellType == null)
                {
                    col.CellType = new TextCellType();
                }
            }
        }

        /// <summary>
        /// パターン（カードNO、業務区分で設定）による項目設定処理.
        /// </summary>
        /// <param name="kmkptn"></param>
        /// <param name="tvorrd"></param>
        /// <param name="spread"></param>
        public void kmkset(string kmkptn, string tvorrd, FarPoint.Win.Spread.SheetView spread)
        {
            //カードNOもしくは媒体区分で項目が変更される.
            if (kmkptn.Equals(KKHLionConst.COLSTR_KMKTYPE_1))
            {
                foreach (FarPoint.Win.Spread.Column col in spread.Columns)
                {
                    //列毎に異なる設定.
                    //カードNO
                    if (col.Index == KKHLionConst.COLIDX_MLIST_CARDNO)
                    {
                        //okazaki
                        col.Visible = true;
                        //col.Visible = false;
                        //okazaki
                    }
                    //請求NO
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_SEIKYUNO)
                    {
                        col.Visible = false;
                    }
                    //年月.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_YYMM)
                    {
                        col.Visible = false;
                    }
                    //代理店CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_DAIRITEN)
                    {
                        col.Visible = false;
                    }
                    //媒体CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BAITAI)
                    {
                        col.Visible = false;
                    }
                    //番組CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BANGCD)
                    {
                        col.Visible = false;
                    }
                    //費目CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HIMKCD)
                    {
                        col.Visible = false;
                    }
                    //ブランドCD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BRANDCD)
                    {
                        col.Visible = false;
                    }
                    //府県CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_FUKENCD)
                    {
                        col.Visible = false;
                    }
                    //局誌CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KYOKUSICD)
                    {
                        col.Visible = true;
                    }
                    //変更STR項目1
                    //※カードNO、媒体で変更有り.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_STR1)
                    {
                        col.Visible = true;
                        col.Label = KKHLionConst.COLSTR_MLIST_STR1_KYOKU;//局誌名称.
                    }
                    //ネットFC
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NETFC)
                    {
                        col.Visible = false;
                    }
                    //スペース
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_SPACE)
                    {
                        col.Visible = false;
                    }
                    //変更INT項目1
                    //カードNO、媒体で変更有り.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_INT1)
                    {
                        col.Label = KKHLionConst.COLSTR_MLIST_INT1_JISI;
                        col.Visible = false;
                    }
                    //実施電波料.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_JISIDENPA)
                    {
                        col.Visible = true;
                    }
                    //値引率.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NBKRITU)
                    {
                        col.Visible = true;
                    }
                    //値引き電波料.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NBKDENPARYO)
                    {
                        col.Visible = true;
                    }
                    //ネット料.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NETRYO)
                    {
                        col.Visible = true;
                    }
                    //変更INT項目2
                    //カードNO、媒体で変更有り.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_INT2)
                    {
                        col.Label = KKHLionConst.COLSTR_MLIST_INT2_SEISAKU;
                        col.Visible = true;
                    }
                    //値引後金額.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NBKGOKNGK)
                    {
                        col.Visible = true;
                    }
                    //消費税率.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TAXRITU)
                    {
                        col.Visible = true;
                    }
                    //消費税.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TAX)
                    {
                        col.Visible = true;
                    }
                    //本数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HONSU)
                    {
                        col.Visible = true;
                    }
                    //秒数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BYOSU)
                    {
                        col.Visible = true;
                    }
                    //総秒数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_SOBYOSU)
                    {
                        col.Visible = true;
                    }
                    //放送数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HOSOSU)
                    {
                        col.Visible = false;
                    }
                    //休止数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KYUSISU)
                    {
                        col.Visible = false;
                    }
                    //オンエアー数
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_ONAIRSU)
                    {
                        col.Visible = false;
                    }
                    //件名.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KENMEI)
                    {
                        col.Visible = true;
                    }
                    //掲載.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KEISAI)
                    {
                        col.Visible = false;
                    }
                    //路線.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_ROSEN)
                    {
                        col.Visible = false;
                    }
                    //期間.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KIKAN)
                    {
                        col.Visible = false;
                    }
                    //備考.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BIKO)
                    {
                        //okazaki
                        col.Visible = true;
                        //col.Visible = false;
                        //okazaki
                    }
                    //売上明細NO
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_URIMEI)
                    {
                        //okazaki
                        col.Visible = true;
                        //col.Visible = false;
                        //okazaki
                    }
                    //表示順.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HYOJIJYN)
                    {
                        col.Visible = false;
                    }
                    //地区合計.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TIKUGO)
                    {
                        col.Visible = false;
                    }
                    //地区CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TIKUCD)
                    {
                        col.Visible = false;
                    }
                    //件名チェンジフラグ
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KENCHANGE)
                    {
                        col.Visible = false;
                    }
                }
            }
            //TYPE2
            else if (kmkptn.Equals(KKHLionConst.COLSTR_KMKTYPE_2))
            {
                foreach (FarPoint.Win.Spread.Column col in spread.Columns)
                {
                    //列毎に異なる設定.
                    //カードNO
                    if (col.Index == KKHLionConst.COLIDX_MLIST_CARDNO)
                    {
                        //okazaki
                        col.Visible = true;
                        //col.Visible = false;
                        //okazaki
                    }
                    //請求NO
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_SEIKYUNO)
                    {
                        col.Visible = false;
                    }
                    //年月.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_YYMM)
                    {
                        col.Visible = false;
                    }
                    //代理店CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_DAIRITEN)
                    {
                        col.Visible = false;
                    }
                    //媒体CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BAITAI)
                    {
                        col.Visible = false;
                    }
                    //番組CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BANGCD)
                    {
                        col.Visible = false;
                    }
                    //費目CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HIMKCD)
                    {
                        col.Visible = false;
                    }
                    //ブランドCD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BRANDCD)
                    {
                        //okazaki
                        //col.Visible = false;
                        col.Visible = true;
                        //okazaki
                    }
                    //府県CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_FUKENCD)
                    {
                        col.Visible = false;
                    }
                    //局誌CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KYOKUSICD)
                    {
                        col.Visible = true;
                    }
                    //変更STR項目1
                    //※カードNO、媒体で変更有り.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_STR1)
                    {
                        col.Visible = true;
                        col.Label = KKHLionConst.COLSTR_MLIST_STR1_KYOKU;//局誌名称.
                    }
                    //ネットFC
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NETFC)
                    {
                        col.Visible = false;
                    }
                    //スペース
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_SPACE)
                    {
                        col.Visible = false;
                    }
                    //変更INT項目1
                    //カードNO、媒体で変更有り.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_INT1)
                    {
                        col.Label = KKHLionConst.COLSTR_MLIST_INT1_JISI;
                        col.Visible = false;
                    }
                    //実施電波料.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_JISIDENPA)
                    {
                        col.Visible = true;
                    }
                    //値引率.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NBKRITU)
                    {
                        col.Visible = true;
                    }
                    //値引き電波料.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NBKDENPARYO)
                    {
                        col.Visible = true;
                    }
                    //ネット料.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NETRYO)
                    {
                        col.Visible = false;
                    }
                    //変更INT項目2
                    //カードNO、媒体で変更有り.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_INT2)
                    {
                        col.Label = KKHLionConst.COLSTR_MLIST_INT2_SEISAKU;
                        col.Visible = false;
                    }
                    //値引後金額.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NBKGOKNGK)
                    {
                        col.Visible = true;
                    }
                    //消費税率.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TAXRITU)
                    {
                        col.Visible = true;
                    }
                    //消費税.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TAX)
                    {
                        col.Visible = true;
                    }
                    //本数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HONSU)
                    {
                        col.Visible = true;
                    }
                    //秒数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BYOSU)
                    {
                        col.Visible = true;
                    }
                    //総秒数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_SOBYOSU)
                    {
                        col.Visible = true;
                    }
                    //放送数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HOSOSU)
                    {
                        col.Visible = false;
                    }
                    //休止数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KYUSISU)
                    {
                        col.Visible = false;
                    }
                    //オンエアー数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_ONAIRSU)
                    {
                        col.Visible = false;
                    }
                    //件名.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KENMEI)
                    {
                        col.Visible = true;
                    }
                    //掲載.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KEISAI)
                    {
                        col.Visible = false;
                    }
                    //路線.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_ROSEN)
                    {
                        col.Visible = false;
                    }
                    //期間.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KIKAN)
                    {
                        col.Visible = false;
                    }
                    //備考.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BIKO)
                    {
                        //okazaki
                        col.Visible = true;
                        //col.Visible = false;
                        //okazaki
                    }
                    //売上明細NO
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_URIMEI)
                    {
                        //okazaki
                        col.Visible = true;
                        //col.Visible = false;
                        //okazaki
                    }
                    //表示順.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HYOJIJYN)
                    {
                        col.Visible = false;
                    }
                    //地区合計.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TIKUGO)
                    {
                        //テレビスポットのみ表示.
                        if (tvorrd.Equals(KKHLionConst.BAITAIKBN_TV_SPOT))
                        {
                            col.Visible = true;
                        }
                        else
                        {
                            col.Visible = false;
                        }
                    }
                    //地区CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TIKUCD)
                    {
                        col.Visible = false;
                    }
                    //件名チェンジフラグ
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KENCHANGE)
                    {
                        col.Visible = false;
                    }
                }
            }
            //TYPE3
            else if (kmkptn.Equals(KKHLionConst.COLSTR_KMKTYPE_3))
            {
                foreach (FarPoint.Win.Spread.Column col in spread.Columns)
                {
                    //列毎に異なる設定.
                    //カードNO
                    if (col.Index == KKHLionConst.COLIDX_MLIST_CARDNO)
                    {
                        //okazaki
                        col.Visible = true;
                        //col.Visible = false;
                        //okazaki
                    }
                    //請求NO
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_SEIKYUNO)
                    {
                        col.Visible = false;
                    }
                    //年月.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_YYMM)
                    {
                        col.Visible = false;
                    }
                    //代理店CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_DAIRITEN)
                    {
                        col.Visible = false;
                    }
                    //媒体CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BAITAI)
                    {
                        col.Visible = false;
                    }
                    //番組CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BANGCD)
                    {
                        col.Visible = false;
                    }
                    //費目CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HIMKCD)
                    {
                        col.Visible = false;
                    }
                    //ブランドCD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BRANDCD)
                    {
                        //okazaki
                        //col.Visible = false;
                        col.Visible = true;
                        //okazaki
                    }
                    //府県CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_FUKENCD)
                    {
                        col.Visible = false;
                    }
                    //局誌CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KYOKUSICD)
                    {
                        col.Visible = true;
                    }
                    //変更STR項目1
                    //※カードNO、媒体で変更有り.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_STR1)
                    {
                        col.Visible = true;
                        col.Label = KKHLionConst.COLSTR_MLIST_STR1_KYOKU;//局誌名称.
                    }
                    //ネットFC
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NETFC)
                    {
                        col.Visible = false;
                    }
                    //スペース
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_SPACE)
                    {
                        col.Visible = false;
                    }
                    //変更INT項目1
                    //カードNO、媒体で変更有り.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_INT1)
                    {
                        col.Label = KKHLionConst.COLSTR_MLIST_INT1_JISI;
                        col.Visible = true;
                    }
                    //実施電波料.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_JISIDENPA)
                    {
                        col.Visible = false;
                    }
                    //値引率.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NBKRITU)
                    {
                        col.Visible = false;
                    }
                    //値引き電波料.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NBKDENPARYO)
                    {
                        col.Visible = false;
                    }
                    //ネット料.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NETRYO)
                    {
                        col.Visible = false;
                    }
                    //変更INT項目2
                    //カードNO、媒体で変更有り.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_INT2)
                    {
                        col.Label = KKHLionConst.COLSTR_MLIST_INT2_SEISAKU;
                        col.Visible = false;
                    }
                    //値引後金額.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NBKGOKNGK)
                    {
                        col.Visible = true;
                    }
                    //消費税率.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TAXRITU)
                    {
                        col.Visible = true;
                    }
                    //消費税.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TAX)
                    {
                        col.Visible = true;
                    }
                    //本数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HONSU)
                    {
                        col.Visible = false;
                    }
                    //秒数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BYOSU)
                    {
                        col.Visible = false;
                    }
                    //総秒数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_SOBYOSU)
                    {
                        col.Visible = false;
                    }
                    //放送数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HOSOSU)
                    {
                        col.Visible = false;
                    }
                    //休止数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KYUSISU)
                    {
                        col.Visible = false;
                    }
                    //オンエアー数
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_ONAIRSU)
                    {
                        col.Visible = false;
                    }
                    //件名.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KENMEI)
                    {
                        col.Visible = true;
                    }
                    //掲載.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KEISAI)
                    {
                        col.Visible = true;
                    }
                    //路線.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_ROSEN)
                    {
                        col.Visible = false;
                    }
                    //期間.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KIKAN)
                    {
                        col.Visible = true;
                    }
                    //備考.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BIKO)
                    {
                        //okazaki
                        col.Visible = true;
                        //col.Visible = false;
                        //okazaki
                    }
                    //売上明細NO
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_URIMEI)
                    {
                        //okazaki
                        col.Visible = true;
                        //col.Visible = false;
                        //okazaki
                    }
                    //表示順.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HYOJIJYN)
                    {
                        col.Visible = false;
                    }
                    //地区合計.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TIKUGO)
                    {
                        col.Visible = false;
                    }
                    //地区CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TIKUCD)
                    {
                        col.Visible = false;
                    }
                    //件名チェンジフラグ
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KENCHANGE)
                    {
                        col.Visible = false;
                    }
                }
            }
            //TYPE4
            else if (kmkptn.Equals(KKHLionConst.COLSTR_KMKTYPE_4))
            {
                foreach (FarPoint.Win.Spread.Column col in spread.Columns)
                {
                    //列毎に異なる設定.
                    //カードNO
                    if (col.Index == KKHLionConst.COLIDX_MLIST_CARDNO)
                    {
                        //okazaki
                        col.Visible = true;
                        //col.Visible = false;
                        //okazaki
                    }
                    //請求NO
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_SEIKYUNO)
                    {
                        col.Visible = false;
                    }
                    //年月.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_YYMM)
                    {
                        col.Visible = false;
                    }
                    //代理店CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_DAIRITEN)
                    {
                        col.Visible = false;
                    }
                    //媒体CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BAITAI)
                    {
                        col.Visible = false;
                    }
                    //番組CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BANGCD)
                    {
                        col.Visible = false;
                    }
                    //費目CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HIMKCD)
                    {
                        col.Visible = false;
                    }
                    //ブランドCD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BRANDCD)
                    {
                        //okazaki
                        //col.Visible = false;
                        col.Visible = true;
                        //okazaki
                    }
                    //府県CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_FUKENCD)
                    {
                        col.Visible = false;
                    }
                    //局誌CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KYOKUSICD)
                    {
                        col.Visible = true;
                    }
                    //変更STR項目1
                    //※カードNO、媒体で変更有り.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_STR1)
                    {
                        col.Visible = true;
                        col.Label = KKHLionConst.COLSTR_MLIST_STR1_KYOKU;//局誌名称.
                    }
                    //ネットFC
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NETFC)
                    {
                        col.Visible = false;
                    }
                    //スペース
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_SPACE)
                    {
                        col.Visible = true;
                    }
                    //変更INT項目1
                    //カードNO、媒体で変更有り.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_INT1)
                    {
                        col.Label = KKHLionConst.COLSTR_MLIST_INT1_JISI;//実施料.
                        col.Visible = true;
                    }
                    //実施電波料.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_JISIDENPA)
                    {
                        col.Visible = false;
                    }
                    //値引率.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NBKRITU)
                    {
                        col.Visible = true;
                    }
                    //値引き電波料.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NBKDENPARYO)
                    {
                        col.Visible = false;
                    }
                    //ネット料.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NETRYO)
                    {
                        col.Visible = false;
                    }
                    //変更INT項目2
                    //カードNO、媒体で変更有り.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_INT2)
                    {
                        col.Label = KKHLionConst.COLSTR_MLIST_INT2_TAIUP;
                        col.Visible = true;
                    }
                    //値引後金額.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NBKGOKNGK)
                    {
                        col.Visible = true;
                    }
                    //消費税率.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TAXRITU)
                    {
                        col.Visible = true;
                    }
                    //消費税.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TAX)
                    {
                        col.Visible = true;
                    }
                    //本数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HONSU)
                    {
                        col.Visible = false;
                    }
                    //秒数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BYOSU)
                    {
                        col.Visible = false;
                    }
                    //総秒数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_SOBYOSU)
                    {
                        col.Visible = false;
                    }
                    //放送数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HOSOSU)
                    {
                        col.Visible = false;
                    }
                    //休止数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KYUSISU)
                    {
                        col.Visible = false;
                    }
                    //オンエアー数
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_ONAIRSU)
                    {
                        col.Visible = false;
                    }
                    //件名.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KENMEI)
                    {
                        col.Visible = true;
                    }
                    //掲載.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KEISAI)
                    {
                        col.Visible = true;
                    }
                    //路線.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_ROSEN)
                    {
                        col.Visible = false;
                    }
                    //期間.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KIKAN)
                    {
                        col.Visible = true;
                    }
                    //備考.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BIKO)
                    {
                        //okazaki
                        col.Visible = true;
                        //col.Visible = false;
                        //okazaki
                    }
                    //売上明細NO
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_URIMEI)
                    {
                        //okazaki
                        col.Visible = true;
                        //col.Visible = false;
                        //okazaki
                    }
                    //表示順.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HYOJIJYN)
                    {
                        col.Visible = false;
                    }
                    //地区合計.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TIKUGO)
                    {
                        col.Visible = false;
                    }
                    //地区CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TIKUCD)
                    {
                        col.Visible = false;
                    }
                    //件名チェンジフラグ
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KENCHANGE)
                    {
                        col.Visible = false;
                    }
                }
            }
            //TYPE5
            else if (kmkptn.Equals(KKHLionConst.COLSTR_KMKTYPE_5))
            {
                foreach (FarPoint.Win.Spread.Column col in spread.Columns)
                {
                    //列毎に異なる設定.
                    //カードNO
                    if (col.Index == KKHLionConst.COLIDX_MLIST_CARDNO)
                    {
                        //okazaki
                        col.Visible = true;
                        //col.Visible = false;
                        //okazaki
                    }
                    //請求NO
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_SEIKYUNO)
                    {
                        col.Visible = false;
                    }
                    //年月.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_YYMM)
                    {
                        col.Visible = false;
                    }
                    //代理店CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_DAIRITEN)
                    {
                        col.Visible = false;
                    }
                    //媒体CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BAITAI)
                    {
                        col.Visible = false;
                    }
                    //番組CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BANGCD)
                    {
                        col.Visible = false;
                    }
                    //費目CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HIMKCD)
                    {
                        col.Visible = false;
                    }
                    //ブランドCD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BRANDCD)
                    {
                        //okazaki
                        //col.Visible = false;
                        col.Visible = true;
                        //okazaki
                    }
                    //府県CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_FUKENCD)
                    {
                        col.Visible = true;
                    }
                    //局誌CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KYOKUSICD)
                    {
                        col.Visible = false;
                    }
                    //変更STR項目1
                    //※カードNO、媒体で変更有り.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_STR1)
                    {
                        col.Visible = true;
                        col.Label = KKHLionConst.COLSTR_MLIST_STR1_KEN;//県名称.
                    }
                    //ネットFC
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NETFC)
                    {
                        col.Visible = false;
                    }
                    //スペース
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_SPACE)
                    {
                        col.Visible = false;
                    }
                    //変更INT項目1
                    //カードNO、媒体で変更有り.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_INT1)
                    {
                        col.Label = KKHLionConst.COLSTR_MLIST_INT1_JISI;
                        col.Visible = true;
                    }
                    //実施電波料.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_JISIDENPA)
                    {
                        col.Visible = false;
                    }
                    //値引率.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NBKRITU)
                    {
                        col.Visible = false;
                    }
                    //値引き電波料.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NBKDENPARYO)
                    {
                        col.Visible = false;
                    }
                    //ネット料.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NETRYO)
                    {
                        col.Visible = false;
                    }
                    //変更INT項目2
                    //カードNO、媒体で変更有り.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_INT2)
                    {
                        col.Label = KKHLionConst.COLSTR_MLIST_INT2_TAIUP;
                        col.Visible = false;
                    }
                    //値引後金額.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NBKGOKNGK)
                    {
                        col.Visible = true;
                    }
                    //消費税率.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TAXRITU)
                    {
                        col.Visible = true;
                    }
                    //消費税.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TAX)
                    {
                        col.Visible = true;
                    }
                    //本数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HONSU)
                    {
                        col.Visible = false;
                    }
                    //秒数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BYOSU)
                    {
                        col.Visible = false;
                    }
                    //総秒数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_SOBYOSU)
                    {
                        col.Visible = false;
                    }
                    //放送数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HOSOSU)
                    {
                        col.Visible = false;
                    }
                    //休止数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KYUSISU)
                    {
                        col.Visible = false;
                    }
                    //オンエアー数
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_ONAIRSU)
                    {
                        col.Visible = false;
                    }
                    //件名.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KENMEI)
                    {
                        col.Visible = true;
                    }
                    //掲載.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KEISAI)
                    {
                        col.Visible = false;
                    }
                    //路線.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_ROSEN)
                    {
                        col.Visible = true;
                    }
                    //期間.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KIKAN)
                    {
                        col.Visible = true;
                    }
                    //備考.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BIKO)
                    {
                        //okazaki
                        col.Visible = true;
                        //col.Visible = false;
                        //okazaki
                    }
                    //売上明細NO
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_URIMEI)
                    {
                        //okazaki
                        col.Visible = true;
                        //col.Visible = false;
                        //okazaki
                    }
                    //表示順.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HYOJIJYN)
                    {
                        col.Visible = false;
                    }
                    //地区合計.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TIKUGO)
                    {
                        col.Visible = false;
                    }
                    //地区CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TIKUCD)
                    {
                        col.Visible = false;
                    }
                    //件名チェンジフラグ
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KENCHANGE)
                    {
                        col.Visible = false;
                    }
                }
            }
            //TYPE6
            else if (kmkptn.Equals(KKHLionConst.COLSTR_KMKTYPE_6))
            {
                foreach (FarPoint.Win.Spread.Column col in spread.Columns)
                {
                    //列毎に異なる設定.
                    //カードNO
                    if (col.Index == KKHLionConst.COLIDX_MLIST_CARDNO)
                    {
                        //okazaki
                        col.Visible = true;
                        //col.Visible = false;
                        //okazaki
                    }
                    //請求NO
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_SEIKYUNO)
                    {
                        col.Visible = false;
                    }
                    //年月.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_YYMM)
                    {
                        col.Visible = false;
                    }
                    //代理店CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_DAIRITEN)
                    {
                        col.Visible = false;
                    }
                    //媒体CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BAITAI)
                    {
                        col.Visible = false;
                    }
                    //番組CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BANGCD)
                    {
                        col.Visible = false;
                    }
                    //費目CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HIMKCD)
                    {
                        col.Visible = false;
                    }
                    //ブランドCD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BRANDCD)
                    {
                        col.Visible = true;
                    }
                    //府県CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_FUKENCD)
                    {
                        col.Visible = false;
                    }
                    //局誌CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KYOKUSICD)
                    {
                        col.Visible = false;
                    }
                    //変更STR項目1
                    //※カードNO、媒体で変更有り.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_STR1)
                    {
                        col.Visible = false;
                        col.Label = KKHLionConst.COLSTR_MLIST_STR1_KYOKU;//県名称.
                    }
                    //ネットFC
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NETFC)
                    {
                        col.Visible = false;
                    }
                    //スペース
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_SPACE)
                    {
                        col.Visible = false;
                    }
                    //変更INT項目1
                    //カードNO、媒体で変更有り.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_INT1)
                    {
                        col.Label = KKHLionConst.COLSTR_MLIST_INT1_SENDEN;//宣伝費.
                        col.Visible = true;
                    }
                    //実施電波料.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_JISIDENPA)
                    {
                        col.Visible = false;
                    }
                    //値引率.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NBKRITU)
                    {
                        col.Visible = false;
                    }
                    //値引き電波料.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NBKDENPARYO)
                    {
                        col.Visible = false;
                    }
                    //ネット料.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NETRYO)
                    {
                        col.Visible = false;
                    }
                    //変更INT項目2
                    //カードNO、媒体で変更有り.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_INT2)
                    {
                        col.Label = KKHLionConst.COLSTR_MLIST_INT2_TAIUP;
                        col.Visible = false;
                    }
                    //値引後金額.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NBKGOKNGK)
                    {
                        col.Visible = true;
                    }
                    //消費税率.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TAXRITU)
                    {
                        col.Visible = true;
                    }
                    //消費税.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TAX)
                    {
                        col.Visible = true;
                    }
                    //本数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HONSU)
                    {
                        col.Visible = false;
                    }
                    //秒数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BYOSU)
                    {
                        col.Visible = false;
                    }
                    //総秒数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_SOBYOSU)
                    {
                        col.Visible = false;
                    }
                    //放送数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HOSOSU)
                    {
                        col.Visible = false;
                    }
                    //休止数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KYUSISU)
                    {
                        col.Visible = false;
                    }
                    //オンエアー数
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_ONAIRSU)
                    {
                        col.Visible = false;
                    }
                    //件名.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KENMEI)
                    {
                        col.Visible = true;
                    }
                    //掲載.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KEISAI)
                    {
                        col.Visible = false;
                    }
                    //路線.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_ROSEN)
                    {
                        col.Visible = false;
                    }
                    //期間.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KIKAN)
                    {
                        col.Visible = false;
                    }
                    //備考.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BIKO)
                    {
                        //okazaki
                        col.Visible = true;
                        //col.Visible = false;
                        //okazaki
                    }
                    //売上明細NO
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_URIMEI)
                    {
                        //okazaki
                        col.Visible = true;
                        //col.Visible = false;
                        //okazaki
                    }
                    //表示順.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HYOJIJYN)
                    {
                        col.Visible = false;
                    }
                    //地区合計.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TIKUGO)
                    {
                        col.Visible = false;
                    }
                    //地区CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TIKUCD)
                    {
                        col.Visible = false;
                    }
                    //件名チェンジフラグ
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KENCHANGE)
                    {
                        col.Visible = false;
                    }
                }
            }
            //TYPE7
            else if (kmkptn.Equals(KKHLionConst.COLSTR_KMKTYPE_7))
            {
                foreach (FarPoint.Win.Spread.Column col in spread.Columns)
                {
                    //列毎に異なる設定.
                    //カードNO
                    if (col.Index == KKHLionConst.COLIDX_MLIST_CARDNO)
                    {
                        //okazaki
                        col.Visible = true;
                        //col.Visible = false;
                        //okazaki
                    }
                    //請求NO
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_SEIKYUNO)
                    {
                        col.Visible = false;
                    }
                    //年月.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_YYMM)
                    {
                        col.Visible = false;
                    }
                    //代理店CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_DAIRITEN)
                    {
                        col.Visible = false;
                    }
                    //媒体CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BAITAI)
                    {
                        col.Visible = true;
                    }
                    //番組CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BANGCD)
                    {
                        col.Visible = false;
                    }
                    //費目CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HIMKCD)
                    {
                        col.Visible = false;
                    }
                    //ブランドCD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BRANDCD)
                    {
                        //okazaki
                        //col.Visible = false;
                        col.Visible = true;
                        //okazaki
                    }
                    //府県CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_FUKENCD)
                    {
                        col.Visible = false;
                    }
                    //局誌CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KYOKUSICD)
                    {
                        col.Visible = false;
                    }
                    //変更STR項目1
                    //※カードNO、媒体で変更有り.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_STR1)
                    {
                        col.Visible = true;
                        col.Label = KKHLionConst.COLSTR_MLIST_STR1_BAITAI;//県名称.
                    }
                    //ネットFC
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NETFC)
                    {
                        col.Visible = false;
                    }
                    //スペース
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_SPACE)
                    {
                        col.Visible = false;
                    }
                    //変更INT項目1
                    //カードNO、媒体で変更有り.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_INT1)
                    {
                        col.Label = KKHLionConst.COLSTR_MLIST_INT1_JISI;//実施料.
                        col.Visible = true;
                    }
                    //実施電波料.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_JISIDENPA)
                    {
                        col.Visible = false;
                    }
                    //値引率.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NBKRITU)
                    {
                        col.Visible = false;
                    }
                    //値引き電波料.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NBKDENPARYO)
                    {
                        col.Visible = false;
                    }
                    //ネット料.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NETRYO)
                    {
                        col.Visible = false;
                    }
                    //変更INT項目2
                    //カードNO、媒体で変更有り.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_INT2)
                    {
                        col.Label = KKHLionConst.COLSTR_MLIST_INT2_TAIUP;
                        col.Visible = false;
                    }
                    //値引後金額.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NBKGOKNGK)
                    {
                        col.Visible = true;
                    }
                    //消費税率.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TAXRITU)
                    {
                        col.Visible = true;
                    }
                    //消費税.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TAX)
                    {
                        col.Visible = true;
                    }
                    //本数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HONSU)
                    {
                        col.Visible = false;
                    }
                    //秒数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BYOSU)
                    {
                        col.Visible = false;
                    }
                    //総秒数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_SOBYOSU)
                    {
                        col.Visible = false;
                    }
                    //放送数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HOSOSU)
                    {
                        col.Visible = false;
                    }
                    //休止数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KYUSISU)
                    {
                        col.Visible = false;
                    }
                    //オンエアー数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_ONAIRSU)
                    {
                        col.Visible = false;
                    }
                    //件名.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KENMEI)
                    {
                        col.Visible = true;
                    }
                    //掲載.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KEISAI)
                    {
                        col.Visible = false;
                    }
                    //路線.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_ROSEN)
                    {
                        col.Visible = false;
                    }
                    //期間.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KIKAN)
                    {
                        col.Visible = false;
                    }
                    //備考.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BIKO)
                    {
                        //okazaki
                        col.Visible = true;
                        //col.Visible = false;
                        //okazaki
                    }
                    //売上明細NO
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_URIMEI)
                    {
                        //okazaki
                        col.Visible = true;
                        //col.Visible = false;
                        //okazaki
                    }
                    //表示順.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HYOJIJYN)
                    {
                        col.Visible = false;
                    }
                    //地区合計.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TIKUGO)
                    {
                        col.Visible = false;
                    }
                    //地区CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TIKUCD)
                    {
                        col.Visible = false;
                    }
                    //件名チェンジフラグ
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KENCHANGE)
                    {
                        col.Visible = false;
                    }
                }
            }
            //TYPE8
            else if (kmkptn.Equals(KKHLionConst.COLSTR_KMKTYPE_8))
            {
                foreach (FarPoint.Win.Spread.Column col in spread.Columns)
                {
                    //列毎に異なる設定.
                    //カードNO
                    if (col.Index == KKHLionConst.COLIDX_MLIST_CARDNO)
                    {
                        //okazaki
                        col.Visible = true;
                        //col.Visible = false;
                        //okazaki
                    }
                    //請求NO
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_SEIKYUNO)
                    {
                        col.Visible = false;
                    }
                    //年月.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_YYMM)
                    {
                        col.Visible = false;
                    }
                    //代理店CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_DAIRITEN)
                    {
                        col.Visible = false;
                    }
                    //媒体CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BAITAI)
                    {
                        col.Visible = false;
                    }
                    //番組CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BANGCD)
                    {
                        col.Visible = false;
                    }
                    //費目CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HIMKCD)
                    {
                        col.Visible = false;
                    }
                    //ブランドCD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BRANDCD)
                    {
                        col.Visible = true;
                    }
                    //府県CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_FUKENCD)
                    {
                        col.Visible = false;
                    }
                    //局誌CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KYOKUSICD)
                    {
                        col.Visible = true;
                    }
                    //変更STR項目1
                    //※カードNO、媒体で変更有り.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_STR1)
                    {
                        col.Visible = true;
                        col.Label = KKHLionConst.COLSTR_MLIST_STR1_KYOKU;//局誌名称.
                    }
                    //ネットFC
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NETFC)
                    {
                        col.Visible = false;
                    }
                    //スペース
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_SPACE)
                    {
                        col.Visible = false;
                    }
                    //変更INT項目1
                    //カードNO、媒体で変更有り.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_INT1)
                    {
                        col.Label = KKHLionConst.COLSTR_MLIST_INT1_SENDEN;//実施料.
                        col.Visible = true;
                    }
                    //実施電波料.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_JISIDENPA)
                    {
                        col.Visible = false;
                    }
                    //値引率.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NBKRITU)
                    {
                        col.Visible = false;
                    }
                    //値引き電波料.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NBKDENPARYO)
                    {
                        col.Visible = false;
                    }
                    //ネット料.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NETRYO)
                    {
                        col.Visible = false;
                    }
                    //変更INT項目2
                    //カードNO、媒体で変更有り.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_INT2)
                    {
                        col.Label = KKHLionConst.COLSTR_MLIST_INT2_TAIUP;
                        col.Visible = false;
                    }
                    //値引後金額.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_NBKGOKNGK)
                    {
                        col.Visible = true;
                    }
                    //消費税率.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TAXRITU)
                    {
                        col.Visible = true;
                    }
                    //消費税.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TAX)
                    {
                        col.Visible = true;
                    }
                    //本数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HONSU)
                    {
                        col.Visible = false;
                    }
                    //秒数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BYOSU)
                    {
                        col.Visible = false;
                    }
                    //総秒数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_SOBYOSU)
                    {
                        col.Visible = false;
                    }
                    //放送数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HOSOSU)
                    {
                        col.Visible = false;
                    }
                    //休止数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KYUSISU)
                    {
                        col.Visible = false;
                    }
                    //オンエアー数.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_ONAIRSU)
                    {
                        col.Visible = false;
                    }
                    //件名.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KENMEI)
                    {
                        col.Visible = true;
                    }
                    //掲載.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KEISAI)
                    {
                        col.Visible = false;
                    }
                    //路線.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_ROSEN)
                    {
                        col.Visible = false;
                    }
                    //期間.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KIKAN)
                    {
                        col.Visible = false;
                    }
                    //備考.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_BIKO)
                    {
                        //okazaki
                        col.Visible = true;
                        //col.Visible = false;
                        //okazaki
                    }
                    //売上明細NO
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_URIMEI)
                    {
                        //okazaki
                        col.Visible = true;
                        //col.Visible = false;
                        //okazaki
                    }
                    //表示順.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_HYOJIJYN)
                    {
                        col.Visible = false;
                    }
                    //地区合計.
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TIKUGO)
                    {
                        col.Visible = false;
                    }
                    //地区CD
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_TIKUCD)
                    {
                        col.Visible = false;
                    }
                    //件名チェンジフラグ
                    else if (col.Index == KKHLionConst.COLIDX_MLIST_KENCHANGE)
                    {
                        col.Visible = false;
                    }
                }
            }
        }
    }

}
