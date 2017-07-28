using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using Isid.NJ.View.Navigator;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHView.Mast;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;

using Isid.KKH.Mac.Utility;
using Isid.KKH.Mac.KKHUtility;
using Isid.KKH.Mac.Schema;
using Isid.KKH.Mac.ProcessController.MasterMaintenance;
using Isid.KKH.Mac.ProcessController.MasterMaintenance.Parser;
using FarPoint.Win.Spread;

namespace Isid.KKH.Mac.View.Mast
{
    public partial class frmMastTnpRrk : KKHForm
    {

        #region "定数"

        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "TnpRrkS";

        /// <summary>
        /// マスタメンテナンス呼び出し元画面名（店舗マスター(単一検索)）
        /// </summary>
        private const String MACMSTNAME_SINGLE = "店舗マスター(単一検索)";

        /// <summary>
        /// マスタメンテナンス呼び出し元画面名（店舗マスター(一覧)）
        /// </summary>
        private const String MACMSTNAME_ALL = "店舗マスタ(一覧)";

        #region スプレッド項目番号

        /// <summary>
        /// スプレッド項目番号:反映対象
        /// </summary>
        private const int cKTarget = 0;

        /// <summary>
        /// スプレッド項目番号:更新実施キー
        /// </summary>
        private const int cKUpdRrkTimstmp = 1;

        /// <summary>
        /// スプレッド項目番号:更新種別
        /// </summary>
        private const int cKRrkSybt = 2;

        /// <summary>
        /// スプレッド項目番号:更新種別コード
        /// </summary>
        private const int cKRrkSybtCD = 3;

        /// <summary>
        /// スプレッド項目番号:更新タイプ
        /// </summary>
        private const int cKTorikomiFlg = 4;

        /// <summary>
        /// スプレッド項目番号:更新タイプコード
        /// </summary>
        private const int cKTorikomiFlgCD = 5;

        /// <summary>
        /// スプレッド項目番号:店舗コード
        /// </summary>
        private const int cKTenpoCd = 6;

        /// <summary>
        /// スプレッド項目番号:店舗名
        /// </summary>
        private const int cKTenpoNm = 7;

        /// <summary>
        /// スプレッド項目番号:テリトリー
        /// </summary>
        private const int cKTerritory = 8;

        /// <summary>
        /// スプレッド項目番号:テリトリーコード
        /// </summary>
        private const int cKTerritoryCD = 9;

        /// <summary>
        /// スプレッド項目番号:店舗区分
        /// </summary>
        private const int cKTenpoKbn = 10;

        /// <summary>
        /// スプレッド項目番号:店舗区分コード
        /// </summary>
        private const int cKTenpoKbnCD = 11;

        /// <summary>
        /// スプレッド項目番号:勘定課目
        /// </summary>
        private const int cKKamoku = 12;

        /// <summary>
        /// スプレッド項目番号:郵便番号
        /// </summary>
        private const int cKYubinNo = 13;

        /// <summary>
        /// スプレッド項目番号:住所１
        /// </summary>
        private const int cKAddress1 = 14;

        /// <summary>
        /// スプレッド項目番号:住所２
        /// </summary>
        private const int cKAddress2 = 15;

        /// <summary>
        /// スプレッド項目番号:電話番号
        /// </summary>
        private const int cKTelNo = 16;

        /// <summary>
        /// スプレッド項目番号:明細行フラグ
        /// </summary>
        private const int cKSplitFlg = 17;

        /// <summary>
        /// スプレッド項目番号:明細行フラグコード
        /// </summary>
        private const int cKSplitFlgCD = 18;

        /// <summary>
        /// スプレッド項目番号:ライセンシー社名
        /// </summary>
        private const int cKCompanyNm = 19;

        /// <summary>
        /// スプレッド項目番号:代表者名
        /// </summary>
        private const int cKName = 20;

        /// <summary>
        /// スプレッド項目番号:取引先コード
        /// </summary>
        private const int cKTorihikiCd = 21;

        /// <summary>
        /// スプレッド項目番号:ステータス
        /// </summary>
        private const int cKInStatus = 22;

        /// <summary>
        /// スプレッド項目番号:初期G.OPEN年月日
        /// </summary>
        private const int cKSGOpen = 23;

        /// <summary>
        /// スプレッド項目番号:G.OPEN年月日
        /// </summary>
        private const int cKGOpen = 24;

        /// <summary>
        /// スプレッド項目番号:G.CLOSE年月日
        /// </summary>
        private const int cKGClose = 25;

        #endregion スプレッド項目番号

        #endregion "定数"

        #region "メンバ変数"
        /// <summary>
        /// ナビパラメーター
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();

        // 履歴種別
        Hashtable htRrkType = new Hashtable();    // 履歴種別表示用（1:新規、2:変更、3:削除）

        // 更新タイプ
        Hashtable htUpdType = new Hashtable();    // 更新タイプ表示用（1:取込、2:単一更新、3:一覧更新）

        // 店舗区分
        Hashtable htTenpoKbn = new Hashtable();   // 店舗区分表示用（0:地区本部、1:MC直営店、2:ライセンシー、3:その他）

        // テリトリー
        Hashtable htTerritory = new Hashtable();  // テリトリー表示用（1:関東、2:関西、3:中央、4:その他）

        // 明細行フラグ
        Hashtable htSplitFlg = new Hashtable();   // 明細行フラグ表示用（0:分割する、1:単一更新）


        #endregion "メンバ変数"

        #region "コンストラクタ"

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmMastTnpRrk()
        {
            InitializeComponent();
        }
        #endregion "コンストラクタ"

        #region "イベント"

        /// <summary>
        /// 画面遷移時に発生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void frmMastTnpRrk_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
            }
        }

        /// <summary>
        /// フォームロード時 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMastTnpRrk_Shown(object sender, EventArgs e)
        {
            //ローディング表示  
            base.ShowLoadingDialog();

            // 営業日設定 
            tslDate.Text = _naviParam.strDate;

            // 担当者名設定 
            tslName.Text = _naviParam.strName;

            // 履歴種別設定
            htRrkType.Add(KKHMacConst.C_RRKTYPE_CD1, KKHMacConst.C_RRKTYPE_NM1);
            htRrkType.Add(KKHMacConst.C_RRKTYPE_CD2, KKHMacConst.C_RRKTYPE_NM2);
            htRrkType.Add(KKHMacConst.C_RRKTYPE_CD3, KKHMacConst.C_RRKTYPE_NM3);

            // 更新タイプ設定
            htUpdType.Add(KKHMacConst.C_UPDTYPE_CD1, KKHMacConst.C_UPDTYPE_NM1);
            htUpdType.Add(KKHMacConst.C_UPDTYPE_CD2, KKHMacConst.C_UPDTYPE_NM2);
            htUpdType.Add(KKHMacConst.C_UPDTYPE_CD3, KKHMacConst.C_UPDTYPE_NM3);

            // 店舗区分設定
            htTenpoKbn.Add(KKHMacConst.C_TENPO_KBN_CD1, KKHMacConst.C_TENPO_KBN_NM1);
            htTenpoKbn.Add(KKHMacConst.C_TENPO_KBN_CD2, KKHMacConst.C_TENPO_KBN_NM2);
            htTenpoKbn.Add(KKHMacConst.C_TENPO_KBN_CD3, KKHMacConst.C_TENPO_KBN_NM3);
            htTenpoKbn.Add(KKHMacConst.C_TENPO_KBN_CD4, KKHMacConst.C_TENPO_KBN_NM4);

            // テリトリー設定
            htTerritory.Add(KKHMacConst.C_TERRITORY_CD1, KKHMacConst.C_TERRITORY_NM1);
            htTerritory.Add(KKHMacConst.C_TERRITORY_CD2, KKHMacConst.C_TERRITORY_NM2);
            htTerritory.Add(KKHMacConst.C_TERRITORY_CD3, KKHMacConst.C_TERRITORY_NM3);
            htTerritory.Add(KKHMacConst.C_TERRITORY_CD4, KKHMacConst.C_TERRITORY_NM4);

            // 明細行フラグ設定
            htSplitFlg.Add(KKHMacConst.C_SPLIT_FLG_CD1, KKHMacConst.C_SPLIT_FLG_NM1);
            htSplitFlg.Add(KKHMacConst.C_SPLIT_FLG_CD2, KKHMacConst.C_SPLIT_FLG_NM2);

            //表示
            DisplayView();

            //コントロールを未選択状態にする 
            this.ActiveControl = null;

            //ローディング非表示 
            base.CloseLoadingDialog();
        }

        /// <summary>
        /// 反映ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpd_Click(object sender, EventArgs e)
        {
            String strUpdRrkTimstmp = String.Empty;
            int count = 0;
            // パラメータセット 
            KKHNaviParameter naviParam = new KKHNaviParameter();

            naviParam = _naviParam;

            //***************************************************************
            //必要な情報を入力していない場合は空のデータテーブルを返す
            //***************************************************************
            MastDSMac.DisplayTenpoRrkDataTable dtTenpoRrk = new MastDSMac.DisplayTenpoRrkDataTable();

            for (int i = 0; i < medMain_Sheet1.RowCount; i++)
            {

                //件名が空の場合返さない
                if (medMain_Sheet1.Cells[i, cKTarget].Text.Equals("False") )
                {
                    continue;
                }

                if (count > 0)
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0161, null, "店舗マスター更新履歴", MessageBoxButtons.OK);
                    return;
                }
                count++;

                MastDSMac.DisplayTenpoRrkRow addrow = dtTenpoRrk.NewDisplayTenpoRrkRow();

                addrow.check = medMain_Sheet1.Cells[i, cKTarget].Value.ToString();
                strUpdRrkTimstmp = medMain_Sheet1.Cells[i, cKUpdRrkTimstmp].Text.Replace("/", "");
                strUpdRrkTimstmp = strUpdRrkTimstmp.Replace(":", "");
                strUpdRrkTimstmp = strUpdRrkTimstmp.Replace(" ", "");
                addrow.updRrkTimstmp = strUpdRrkTimstmp;
                addrow.rrkSybt = medMain_Sheet1.Cells[i, cKRrkSybtCD].Text;
                addrow.torikomiFlg = medMain_Sheet1.Cells[i, cKTorikomiFlgCD].Text;
                addrow.tenpoCd = medMain_Sheet1.Cells[i, cKTenpoCd].Text;
                addrow.tenpoNm = medMain_Sheet1.Cells[i, cKTenpoNm].Text;
                addrow.territory = medMain_Sheet1.Cells[i, cKTerritoryCD].Text;
                addrow.tenpoKbn = medMain_Sheet1.Cells[i, cKTenpoKbnCD].Text;
                addrow.kamoku = medMain_Sheet1.Cells[i, cKKamoku].Text;
                addrow.yubinNo = medMain_Sheet1.Cells[i, cKYubinNo].Text;
                addrow.address1 = medMain_Sheet1.Cells[i, cKAddress1].Text;
                addrow.address2 = medMain_Sheet1.Cells[i, cKAddress2].Text;
                addrow.telNo = medMain_Sheet1.Cells[i, cKTelNo].Text;
                addrow.splitFlg = medMain_Sheet1.Cells[i, cKSplitFlgCD].Text;
                addrow.companyNm = medMain_Sheet1.Cells[i, cKCompanyNm].Text;
                addrow.name = medMain_Sheet1.Cells[i, cKName].Text;
                addrow.torihikiCd = medMain_Sheet1.Cells[i, cKTorihikiCd].Text;
                addrow.inStatus = medMain_Sheet1.Cells[i, cKInStatus].Text;
                addrow.sGOpen = medMain_Sheet1.Cells[i, cKSGOpen].Text;
                addrow.gOpen = medMain_Sheet1.Cells[i, cKGOpen].Text;
                addrow.gClose = medMain_Sheet1.Cells[i, cKGClose].Text;

                dtTenpoRrk.AddDisplayTenpoRrkRow(addrow);
            }

            if (count == 0)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0160, null, "店舗マスター更新履歴", MessageBoxButtons.OK);
                return;
            }

            // 選択したデータをセット
            naviParam.DataTable1 = dtTenpoRrk;
            
            // マスタメンテナンスの画面名をセット
            naviParam.StrValue1 = MACMSTNAME_SINGLE;

            Navigator.Forward(this, "tofrmMastMac", naviParam);
        }

        /// <summary>
        /// 戻るボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            // マスタメンテナンス画面に遷移
            // パラメータセット 
            KKHNaviParameter naviParam = new KKHNaviParameter();

            naviParam = _naviParam;

            if (!String.IsNullOrEmpty(naviParam.strFilterValue))
            {
                // 店舗一覧画面に遷移
                Navigator.Backward(this, null, naviParam, true);
            }
            else
            {
                // マスタメンテナンスの画面名をセット
                naviParam.StrValue1 = MACMSTNAME_SINGLE;

                Navigator.Forward(this, "tofrmMastMac", naviParam);
            }            
        }

        /// <summary>
        /// ヘルプボタンクリック処理 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            //得意先コード 
            string tkskgy = _naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //実行 
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.MasterMaintenance, this, HelpNavigator.KeywordIndex);

            this.ActiveControl = null;
        }

        #endregion "イベント"

        #region "メソッド"

        /// <summary>
        /// 各コントロール編集
        /// </summary>
        private void EditControl()
        {
            ////年月の取得
            //String hostDate = "";
            //hostDate = getHostDate();
            //if (hostDate != "")
            //{
            //    hostDate = hostDate.Trim().Replace("/", "");
            //    if (hostDate.Trim().Length >= 6)
            //    {
            //        txtYm.Value = hostDate.Substring(0, 6);
            //    }
            //    else
            //    {
            //        txtYm.Value = hostDate;
            //    }
            //    txtYm.cmbYM_SetDate();
            //}

            ////ステータスの設定
            //txtYm.Value = hostDate.Substring(0, 6);

            //tslName.Text = _naviParam.strName;
            //tslDate.Text = _naviParam.strDate;
        }

        /// <summary>
        /// データ表示
        /// </summary>
        /// <returns></returns>
        private void DisplayView()
        {
            //ローディング表示開始 
            base.ShowLoadingDialog();

            MastDSMac dsMac = new MastDSMac();

            // 店舗マスター取得（単一）
            MasterMaintenanceProcessController processController = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult resultNow = processController.FindMasterByCond(_naviParam.strEsqId,
                                                                                                 _naviParam.strEgcd,
                                                                                                 _naviParam.strTksKgyCd,
                                                                                                 _naviParam.strTksBmnSeqNo,
                                                                                                 _naviParam.strTksTntSeqNo,
                                                                                                 KKHMacConst.C_MAST_TENPO_CD,
                                                                                                 _naviParam.StrValue1);

            // 該当データが存在する場合
            if (resultNow.MasterDataSet.MasterDataVO.Rows.Count != 0)
            {
                // 該当データ取得
                MasterMaintenance.MasterDataVORow rowTenpoMaster = (MasterMaintenance.MasterDataVORow)resultNow.MasterDataSet.MasterDataVO.Rows[0];

                //表示用データRow
                MastDSMac.DisplayTenpoRrkRow addrowNow = dsMac.DisplayTenpoRrk.NewDisplayTenpoRrkRow();

                //表示用データRow初期化
                addrowNow = syokirowSet(addrowNow);

                //チェック
                addrowNow.check = "0";

                //更新履歴キー
                addrowNow.updRrkTimstmp = String.Empty;

                //更新種別
                addrowNow.rrkSybt = "現状";
                addrowNow.rrkSybtCd = "";

                //更新タイプ
                addrowNow.torikomiFlg = String.Empty;
                addrowNow.torikomiFlgCd = String.Empty;

                //店舗コード
                addrowNow.tenpoCd = _naviParam.StrValue1;

                //店舗名
                addrowNow.tenpoNm = rowTenpoMaster.Column2;

                //テリトリー
                addrowNow.territory = htTerritory[rowTenpoMaster.Column3].ToString();
                addrowNow.territoryCd = rowTenpoMaster.Column3;

                //店舗区分
                addrowNow.tenpoKbn = htTenpoKbn[rowTenpoMaster.Column4].ToString();
                addrowNow.tenpoKbnCd = rowTenpoMaster.Column4;

                //勘定科目
                addrowNow.kamoku = rowTenpoMaster.Column5;

                //郵便番号
                addrowNow.yubinNo = rowTenpoMaster.Column6;

                //住所１
                addrowNow.address1 = rowTenpoMaster.Column7;

                //住所２
                addrowNow.address2 = rowTenpoMaster.Column8;

                //電話番号
                addrowNow.telNo = rowTenpoMaster.Column9;

                //明細行フラグ
                addrowNow.splitFlg = htSplitFlg[rowTenpoMaster.Column10].ToString();
                addrowNow.splitFlgCd = rowTenpoMaster.Column10;

                //ライセンシー社名
                addrowNow.companyNm = rowTenpoMaster.Column11;

                //代表者名
                addrowNow.name = rowTenpoMaster.Column12;

                //取引先コード
                addrowNow.torihikiCd = rowTenpoMaster.Column13;

                //ステータス
                addrowNow.inStatus = rowTenpoMaster.Column14;

                //初期G.OPEN年月日
                addrowNow.sGOpen = rowTenpoMaster.Column15;

                //G.OPEN年月日
                addrowNow.gOpen = rowTenpoMaster.Column16;

                //G.CLOSE年月日
                addrowNow.gClose = rowTenpoMaster.Column17;

                //追加
                dsMac.DisplayTenpoRrk.AddDisplayTenpoRrkRow(addrowNow);

            }

            //検索
            MasterMaintenanceMacProcessController processControllerMac = MasterMaintenanceMacProcessController.GetInstance();
            FindMasterTenpoRirekiByCondServiceResult result = processControllerMac.FindMasterTenpoRirekiResult(_naviParam.strEsqId,
                                                                                                            _naviParam.strEgcd,
                                                                                                            _naviParam.strTksKgyCd,
                                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                                            _naviParam.strTksTntSeqNo,
                                                                                                            _naviParam.StrValue1,
                                                                                                            "",
                                                                                                            "",
                                                                                                            "");


            //エラーの場合
            if (result.HasError)
            {
                //ローディング表示終了 
                base.CloseLoadingDialog();
                medMain_Sheet1.Rows.Count = 0;
                return;
            }

            MastDSMac.TenpoRrkRow[] resultRow = (MastDSMac.TenpoRrkRow[])result.TenpoRrkMasterDataSet.TenpoRrk.Select("", "");

            foreach (MastDSMac.TenpoRrkRow row in resultRow)
            {
                //表示用データRow
                MastDSMac.DisplayTenpoRrkRow addrow = dsMac.DisplayTenpoRrk.NewDisplayTenpoRrkRow();

                //表示用データRow初期化
                addrow = syokirowSet(addrow);

                //チェック
                addrow.check = "0";

                //更新履歴キー
                addrow.updRrkTimstmp = row.updRrkTimstmp.Insert(14," ").Insert(12,":").Insert(10,":").Insert(8," ").Insert(6,"/").Insert(4,"/"); 

                //更新種別
                addrow.rrkSybt = htRrkType[row.rrkSybt].ToString();
                addrow.rrkSybtCd = row.rrkSybt;

                //更新タイプ
                addrow.torikomiFlg = htUpdType[row.torikomiFlg].ToString();
                addrow.torikomiFlgCd = row.torikomiFlg;

                //店舗コード
                addrow.tenpoCd = row.tenpoCd;

                //店舗名
                addrow.tenpoNm = row.tenpoNm;

                //テリトリー
                addrow.territory = htTerritory[row.territory].ToString();
                addrow.territoryCd = row.territory;

                //店舗区分
                addrow.tenpoKbn = htTenpoKbn[row.tenpoKbn].ToString();
                addrow.tenpoKbnCd = row.tenpoKbn;

                //勘定科目
                addrow.kamoku = row.kamoku;

                //郵便番号
                addrow.yubinNo = row.yubinNo;

                //住所１
                addrow.address1 = row.address1;

                //住所２
                addrow.address2 = row.address2;

                //電話番号
                addrow.telNo = row.telNo;

                //明細行フラグ
                addrow.splitFlg = htSplitFlg[row.splitFlg].ToString();
                addrow.splitFlgCd = row.splitFlg;

                //ライセンシー社名
                addrow.companyNm = row.companyNm;

                //代表者名
                addrow.name = row.name;

                //取引先コード
                addrow.torihikiCd = row.torihikiCd;

                //ステータス
                addrow.inStatus = row.inStatus;

                //初期G.OPEN年月日
                addrow.sGOpen = row.sGOpen;

                //G.OPEN年月日
                addrow.gOpen = row.gOpen;

                //G.CLOSE年月日
                addrow.gClose = row.gClose;

                //追加
                dsMac.DisplayTenpoRrk.AddDisplayTenpoRrkRow(addrow);

            }

            if (resultNow.MasterDataSet.MasterDataVO.Rows.Count == 0 &&
                result.TenpoRrkMasterDataSet.TenpoRrk.Rows.Count == 0)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "店舗マスター更新履歴", MessageBoxButtons.OK);
                btnUpd.Enabled = false;
                return;
            }

            //スプレッドデータソースへ入れる
            medMain_Sheet1.DataSource = dsMac.DisplayTenpoRrk;

            if (resultNow.MasterDataSet.MasterDataVO.Rows.Count != 0)
            {
                //更新種別を1行ずつ上に移動
                for (int i = 0; i < dsMac.DisplayTenpoRrk.Rows.Count - 1; i++)
                {
                    medMain_Sheet1.Cells[i, cKTorikomiFlg].Value = medMain_Sheet1.Cells[i + 1, cKTorikomiFlg].Value;
                    medMain_Sheet1.Cells[i, cKTorikomiFlgCD].Value = medMain_Sheet1.Cells[i + 1, cKTorikomiFlgCD].Value;
                }
                medMain_Sheet1.Cells[dsMac.DisplayTenpoRrk.Rows.Count - 1, cKTorikomiFlg].Value = "";
                medMain_Sheet1.Cells[dsMac.DisplayTenpoRrk.Rows.Count - 1, cKTorikomiFlgCD].Value = "";
            }
          
            //件数の表示
            lblKensu.Text = dsMac.DisplayTenpoRrk.Rows.Count.ToString() + "件";

            //ローディング表示終了 
            base.CloseLoadingDialog();

        }

        /// <summary>
        /// データRow初期セット
        /// </summary>
        /// <param name="addrow"></param>
        /// <returns></returns>
        private MastDSMac.DisplayTenpoRrkRow syokirowSet(MastDSMac.DisplayTenpoRrkRow addrow)
        {

            addrow.check = string.Empty;
            addrow.updRrkTimstmp  = string.Empty;
            addrow.rrkSybt = string.Empty;
            addrow.rrkSybtCd = string.Empty;
            addrow.torikomiFlg = string.Empty;
            addrow.torikomiFlgCd = string.Empty;
            addrow.tenpoCd = string.Empty;
            addrow.tenpoNm = string.Empty;
            addrow.territory = string.Empty;
            addrow.territoryCd = string.Empty;
            addrow.tenpoKbn = string.Empty;
            addrow.tenpoKbnCd = string.Empty;            
            addrow.kamoku = string.Empty;
            addrow.yubinNo = string.Empty;
            addrow.address1 = string.Empty;
            addrow.address2 = string.Empty;
            addrow.telNo = string.Empty;
            addrow.splitFlg = string.Empty;
            addrow.splitFlgCd = string.Empty;            
            addrow.companyNm = string.Empty;
            addrow.name = string.Empty;
            addrow.torihikiCd = string.Empty;
            addrow.inStatus = string.Empty;
            addrow.sGOpen = string.Empty;
            addrow.gOpen = string.Empty;
            addrow.gClose = string.Empty;

            return addrow;
        }

        #endregion  "メソッド"
    }
}
