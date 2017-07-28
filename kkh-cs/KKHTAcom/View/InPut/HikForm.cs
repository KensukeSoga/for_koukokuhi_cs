using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHProcessController.Log;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHUtility;

using Isid.KKH.Acom.ProcessController.InPut;
using Isid.KKH.Acom.Schema;
using Isid.KKH.Acom.View.Top;
using FarPoint.Win.Spread;
using Isid.KKH.Common.KKHView.Common.Control;
using System.Collections.Specialized;
using System.Collections;
using Isid.KKH.View.Input;
using Isid.KKH.Acom.Utility;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHUtility.Security;


namespace Isid.KKH.Acom.View.InPut
{
    /// <summary>
    /// 
    /// </summary>
    public partial class HikForm : KKHForm
    {
        #region 定数

        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "AcomMenu";

        /// <summary>
        /// 更新プログラム名 
        /// </summary>
        private const string updateAplID = "Inp_Acom";

        /// <summary>
        /// 帳票保存先取得用キー
        /// </summary>
        private const String SYSTEM_KEY_FILE_PATH = "002";

        /// <summary>
        /// デフォルトファイルパス.
        /// </summary>
        private const String DefaultReadFilePath = "C:\\Work\\";

        /// <summary>
        /// デフォルトログファイルパス.
        /// </summary>
        private const String DefaultLogFilePath = "C:\\TMP\\";

        /// <summary>
        /// デフォルトログファイル名.
        /// </summary>
        private const String DefaultLogFilename = "RGerrorNew.log";

        #region 発注データ項目No.(新聞)

        /// <summary>
        /// 発注番号
        /// </summary>
        private const int ACMH_hatCD = 0;

        /// <summary>
        /// 依頼区分
        /// </summary>
        private const int ACMH_Ircd = 1;

        /// <summary>
        /// 依頼月
        /// </summary>
        private const int ACMH_IrDT = 2;

        /// <summary>
        /// 売上予定年月
        /// </summary>
        private const int ACMH_UriDT = 3;

        /// <summary>
        /// 得意先コード
        /// </summary>
        private const int ACMH_ClCD = 4;

        /// <summary>
        /// 営業部コード
        /// </summary>
        private const int ACMH_EgCD = 5;

        /// <summary>
        /// 営業部名
        /// </summary>
        private const int ACMH_EgNM = 6;

        /// <summary>
        /// 店番
        /// </summary>
        private const int ACMH_TenCD = 7;

        /// <summary>
        /// 店名
        /// </summary>
        private const int ACMH_TenNM = 8;

        /// <summary>
        /// 商品区分
        /// </summary>
        private const int ACMH_ShohinKBN = 9;

        /// <summary>
        /// 細目区分
        /// </summary>
        private const int ACMH_SaiCDKBN = 10;

        /// <summary>
        /// 摘要コード
        /// </summary>
        private const int ACMH_TkyCD = 11;

        /// <summary>
        /// 摘要名
        /// </summary>
        private const int ACMH_TkyNM = 12;

        /// <summary>
        /// 媒体コード
        /// </summary>
        private const int ACMH_BtiCD = 13;

        /// <summary>
        /// 媒体名
        /// </summary>
        private const int ACMH_BtiNM = 14;

        /// <summary>
        /// メディアコード
        /// </summary>
        private const int ACMH_MdaCD = 15;

        /// <summary>
        /// メディア名
        /// </summary>
        private const int ACMH_MDnm = 16;

        /// <summary>
        /// 依頼内容
        /// </summary>
        private const int ACMH_irnaiyou = 17;

        /// <summary>
        /// 行番号
        /// </summary>
        private const int ACMH_GyoNUM = 18;

        /// <summary>
        /// 担当者名
        /// </summary>
        private const int ACMH_UserNM = 19;

        /// <summary>
        /// 担当者勤務部署名
        /// </summary>
        private const int ACMH_UserKNM = 20;

        /// <summary>
        /// 予算区分
        /// </summary>
        private const int ACMH_YosanKBN = 21;

        /// <summary>
        /// 按分種別
        /// </summary>
        private const int ACMH_AnSYBT = 22;

        /// <summary>
        /// 備考１
        /// </summary>
        private const int ACMH_Bikou1 = 23;

        /// <summary>
        /// 備考２
        /// </summary>
        private const int ACMH_Bikou2 = 24;

        /// <summary>
        /// 掲載場所コード
        /// </summary>
        private const int ACMH_Men = 25;

        /// <summary>
        /// 種別１コード
        /// </summary>
        private const int ACMH_SYBT1CD = 26;

        /// <summary>
        /// 種別２コード
        /// </summary>
        private const int ACMH_SYBT2CD = 27;

        /// <summary>
        /// 色刷コード
        /// </summary>
        private const int ACMH_ColorCD = 28;

        /// <summary>
        /// サイズコード
        /// </summary>
        private const int ACMH_SpaceCD = 29;

        /// <summary>
        /// サイズ名
        /// </summary>
        private const int ACMH_SpaceNM = 30;

        /// <summary>
        /// 掲載日
        /// </summary>
        private const int ACMH_Keisai = 31;

        /// <summary>
        /// 掲載回数
        /// </summary>
        private const int ACMH_KeisaiCNT = 32;

        /// <summary>
        /// 掲載単価
        /// </summary>
        private const int ACMH_KeisaiTAN = 33;

        /// <summary>
        /// 掲載料
        /// </summary>
        private const int ACMH_keisaiRYO = 34;

        /// <summary>
        /// デザイン変更回数
        /// </summary>
        private const int ACMH_DhenCNT = 35;

        /// <summary>
        /// デザイン料
        /// </summary>
        private const int ACMH_DhenRYO = 36;

        /// <summary>
        /// 版下代
        /// </summary>
        private const int ACMH_Han = 37;

        /// <summary>
        /// 製版代
        /// </summary>
        private const int ACMH_SeiD = 38;

        /// <summary>
        /// 登録年月日
        /// </summary>
        private const int ACMH_InsDT = 39;

        /// <summary>
        /// 変更年月日
        /// </summary>
        private const int ACMH_UpdDT = 40;

        /// <summary>
        /// 取消年月日
        /// </summary>
        private const int ACMH_DelDT = 41;

        #endregion

        #region 発注データ項目No.(雑誌)

        /// <summary>
        /// 発注番号
        /// </summary>
        private const int ZASI_HATNM = 0;

        /// <summary>
        /// 依頼区分
        /// </summary>
        private const int ZASI_IRKBN = 1;

        /// <summary>
        /// 依頼月
        /// </summary>
        private const int ZASI_IRYYMM = 2;

        /// <summary>
        /// 売上予定年月
        /// </summary>
        private const int ZASI_URYYMM = 3;

        /// <summary>
        /// 得意先コード
        /// </summary>
        private const int ZASI_TOKCD = 4;

        /// <summary>
        /// 営業部コード
        /// </summary>
        private const int ZASI_EIGCD = 5;

        /// <summary>
        /// 営業部名
        /// </summary>
        private const int ZASI_EIGNM = 6;

        /// <summary>
        /// 店番
        /// </summary>
        private const int ZASI_TENBAN = 7;

        /// <summary>
        /// 店名
        /// </summary>
        private const int ZASI_TENNM = 8;

        /// <summary>
        /// 商品区分
        /// </summary>
        private const int ZASI_SHOHKBN = 9;

        /// <summary>
        /// 細目区分
        /// </summary>
        private const int ZASI_SAIMKBN = 10;

        /// <summary>
        /// 摘要コード
        /// </summary>
        private const int ZASI_TEKICD = 11;

        /// <summary>
        /// 摘要名
        /// </summary>
        private const int ZASI_TEKINM = 12;

        /// <summary>
        /// 媒体コード
        /// </summary>
        private const int ZASI_BAICD = 13;

        /// <summary>
        /// 媒体名
        /// </summary>
        private const int ZASI_BAINM = 14;

        /// <summary>
        /// メディアコード
        /// </summary>
        private const int ZASI_MEDIACD = 15;

        /// <summary>
        /// メディア名
        /// </summary>
        private const int ZASI_MEDIANM = 16;

        /// <summary>
        /// 依頼内容
        /// </summary>
        private const int ZASI_IRNAIYO = 17;

        /// <summary>
        /// 行番号
        /// </summary>
        private const int ZASI_HATROWNO = 18;

        /// <summary>
        /// 担当者名
        /// </summary>
        private const int ZASI_TANNM = 19;

        /// <summary>
        /// 担当者勤務部署名
        /// </summary>
        private const int ZASI_TANBUNM = 20;

        /// <summary>
        /// 予算区分
        /// </summary>
        private const int ZASI_YOSANKBN = 21;

        /// <summary>
        /// 按分種別
        /// </summary>
        private const int ZASI_ANBSBT = 22;

        /// <summary>
        /// 備考１
        /// </summary>
        private const int ZASI_BIKO1 = 23;

        /// <summary>
        /// 備考２
        /// </summary>
        private const int ZASI_BIKO2 = 24;

        /// <summary>
        /// 掲載場所名
        /// </summary>
        private const int ZASI_KEINM = 25;

        /// <summary>
        /// 色刷コード
        /// </summary>
        private const int ZASI_COLCD = 26;

        /// <summary>
        /// サイズコード
        /// </summary>
        private const int ZASI_SIZCD = 27;

        /// <summary>
        /// サイズ名
        /// </summary>
        private const int ZASI_SIZNM = 28;

        /// <summary>
        /// 発売日１
        /// </summary>
        private const int ZASI_HATUBAI1 = 29;

        /// <summary>
        /// 発売日２
        /// </summary>
        private const int ZASI_HATUBAI2 = 30;

        /// <summary>
        /// 発売日３
        /// </summary>
        private const int ZASI_HATUBAI3 = 31;

        /// <summary>
        /// 発売日４
        /// </summary>
        private const int ZASI_HATUBAI4 = 32;

        /// <summary>
        /// 発売日５
        /// </summary>
        private const int ZASI_HATUBAI5 = 33;

        /// <summary>
        /// 掲載回数
        /// </summary>
        private const int ZASI_KEICNT = 34;

        /// <summary>
        /// 掲載単価
        /// </summary>
        private const int ZASI_KEITANKA = 35;

        /// <summary>
        /// 掲載料
        /// </summary>
        private const int ZASI_KEIRYO = 36;

        /// <summary>
        /// デザイン変更回数
        /// </summary>
        private const int ZASI_DESIGNCNT = 37;

        /// <summary>
        /// デザイン料
        /// </summary>
        private const int ZASI_DESIGNRYO = 38;

        /// <summary>
        /// 版下代
        /// </summary>
        private const int ZASI_HANSHITADAI = 39;

        /// <summary>
        /// 製版代
        /// </summary>
        private const int ZASI_SEIHANDAI = 40;

        /// <summary>
        /// 登録年月日
        /// </summary>
        private const int ZASI_TOUDATE = 41;

        /// <summary>
        /// 変更年月日
        /// </summary>
        private const int ZASI_HENDATE = 42;

        /// <summary>
        /// 取消年月日
        /// </summary>
        private const int ZASI_TORIDATE = 43;

        #endregion

        #region 発注データ項目No.(電波)

        /// <summary>
        /// 発注番号
        /// </summary>
        private const int DENP_HATNM = 0;

        /// <summary>
        /// 依頼区分
        /// </summary>
        private const int DENP_IRKBN = 1;

        /// <summary>
        /// 依頼月
        /// </summary>
        private const int DENP_IRYYMM = 2;

        /// <summary>
        /// 売上予定年月
        /// </summary>
        private const int DENP_URYYMM = 3;

        /// <summary>
        /// 得意先コード
        /// </summary>
        private const int DENP_TOKCD = 4;

        /// <summary>
        /// 営業部コード
        /// </summary>
        private const int DENP_EIGCD = 5;

        /// <summary>
        /// 営業部名
        /// </summary>
        private const int DENP_EIGNM = 6;

        /// <summary>
        /// 店番
        /// </summary>
        private const int DENP_TENBAN = 7;

        /// <summary>
        /// 店名
        /// </summary>
        private const int DENP_TENNM = 8;

        /// <summary>
        /// 商品区分
        /// </summary>
        private const int DENP_SHOHKBN = 9;

        /// <summary>
        /// 細目区分
        /// </summary>
        private const int DENP_SAIMKBN = 10;

        /// <summary>
        /// 摘要コード
        /// </summary>
        private const int DENP_TEKICD = 11;

        /// <summary>
        /// 摘要名
        /// </summary>
        private const int DENP_TEKINM = 12;

        /// <summary>
        /// 媒体コード
        /// </summary>
        private const int DENP_BAICD = 13;

        /// <summary>
        /// 媒体名
        /// </summary>
        private const int DENP_BAINM = 14;

        /// <summary>
        /// メディアコード
        /// </summary>
        private const int DENP_MEDIACD = 15;

        /// <summary>
        /// メディア名
        /// </summary>
        private const int DENP_MEDIANM = 16;

        /// <summary>
        /// 依頼内容
        /// </summary>
        private const int DENP_IRNAIYO = 17;

        /// <summary>
        /// 行番号
        /// </summary>
        private const int DENP_HATROWNO = 18;

        /// <summary>
        /// 担当者名
        /// </summary>
        private const int DENP_TANNM = 19;

        /// <summary>
        /// 担当者勤務部署名
        /// </summary>
        private const int DENP_TANBUNM = 20;

        /// <summary>
        /// 予算区分
        /// </summary>
        private const int DENP_YOSANKBN = 21;

        /// <summary>
        /// 按分種別
        /// </summary>
        private const int DENP_ANBSBT = 22;

        /// <summary>
        /// 備考１
        /// </summary>
        private const int DENP_BIKO1 = 23;

        /// <summary>
        /// 備考２
        /// </summary>
        private const int DENP_BIKO2 = 24;

        /// <summary>
        /// 形態区分
        /// </summary>
        private const int DENP_KEIKBN = 25;

        /// <summary>
        /// 形態区分名
        /// </summary>
        private const int DENP_KEIKBNNM = 26;

        /// <summary>
        /// 依頼月１
        /// </summary>
        private const int DENP_IRYYMM1 = 27;

        /// <summary>
        /// 放送料１
        /// </summary>
        private const int DENP_HOSORYO1 = 28;

        /// <summary>
        /// 依頼月２
        /// </summary>
        private const int DENP_IRYYMM2 = 29;

        /// <summary>
        /// 放送料２
        /// </summary>
        private const int DENP_HOSORYO2 = 30;

        /// <summary>
        /// 依頼月３
        /// </summary>
        private const int DENP_IRYYMM3 = 31;

        /// <summary>
        /// 放送料３
        /// </summary>
        private const int DENP_HOSORYO3 = 32;

        /// <summary>
        /// 依頼月４
        /// </summary>
        private const int DENP_IRYYMM4 = 33;

        /// <summary>
        /// 放送料４
        /// </summary>
        private const int DENP_HOSORYO4 = 34;

        /// <summary>
        /// 依頼月５
        /// </summary>
        private const int DENP_IRYYMM5 = 35;

        /// <summary>
        /// 放送料５
        /// </summary>
        private const int DENP_HOSORYO5 = 36;

        /// <summary>
        /// 依頼月６
        /// </summary>
        private const int DENP_IRYYMM6 = 37;

        /// <summary>
        /// 放送料６
        /// </summary>
        private const int DENP_HOSORYO6 = 38;

        /// <summary>
        /// 登録年月日
        /// </summary>
        private const int DENP_TOUDATE = 39;

        /// <summary>
        /// 変更年月日
        /// </summary>
        private const int DENP_HENDATE = 40;

        /// <summary>
        /// 取消年月日
        /// </summary>
        private const int DENP_TORIDATE = 41;

        #endregion

        #region 発注データ項目No.(交通)

        /// <summary>
        /// 発注番号
        /// </summary>
        private const int KOTU_HATNM = 0;

        /// <summary>
        /// 依頼区分
        /// </summary>
        private const int KOTU_IRKBN = 1;

        /// <summary>
        /// 依頼月
        /// </summary>
        private const int KOTU_IRYYMM = 2;

        /// <summary>
        /// 売上予定年月
        /// </summary>
        private const int KOTU_URYYMM = 3;

        /// <summary>
        /// 得意先コード
        /// </summary>
        private const int KOTU_TOKCD = 4;

        /// <summary>
        /// 営業部コード
        /// </summary>
        private const int KOTU_EIGCD = 5;

        /// <summary>
        /// 営業部名
        /// </summary>
        private const int KOTU_EIGNM = 6;

        /// <summary>
        /// 店番
        /// </summary>
        private const int KOTU_TENBAN = 7;

        /// <summary>
        /// 店名
        /// </summary>
        private const int KOTU_TENNM = 8;

        /// <summary>
        /// 商品区分
        /// </summary>
        private const int KOTU_SHOHKBN = 9;

        /// <summary>
        /// 細目区分
        /// </summary>
        private const int KOTU_SAIMKBN = 10;

        /// <summary>
        /// 摘要コード
        /// </summary>
        private const int KOTU_TEKICD = 11;

        /// <summary>
        /// 摘要名
        /// </summary>
        private const int KOTU_TEKINM = 12;

        /// <summary>
        /// 媒体コード
        /// </summary>
        private const int KOTU_BAICD = 13;

        /// <summary>
        /// 媒体名
        /// </summary>
        private const int KOTU_BAINM = 14;

        /// <summary>
        /// メディアコード
        /// </summary>
        private const int KOTU_MEDIACD = 15;

        /// <summary>
        /// メディア名
        /// </summary>
        private const int KOTU_MEDIANM = 16;

        /// <summary>
        /// 依頼内容
        /// </summary>
        private const int KOTU_IRNAIYO = 17;

        /// <summary>
        /// 行番号
        /// </summary>
        private const int KOTU_HATROWNO = 18;

        /// <summary>
        /// 担当者名
        /// </summary>
        private const int KOTU_TANNM = 19;

        /// <summary>
        /// 担当者勤務部署名
        /// </summary>
        private const int KOTU_TANBUNM = 20;

        /// <summary>
        /// 予算区分
        /// </summary>
        private const int KOTU_YOSANKBN = 21;

        /// <summary>
        /// 按分種別
        /// </summary>
        private const int KOTU_ANBSBT = 22;

        /// <summary>
        /// 備考１
        /// </summary>
        private const int KOTU_BIKO1 = 23;

        /// <summary>
        /// 備考２
        /// </summary>
        private const int KOTU_BIKO2 = 24;

        /// <summary>
        /// 種類コード
        /// </summary>
        private const int KOTU_KEICD = 25;

        /// <summary>
        /// サイズ名
        /// </summary>
        private const int KOTU_KEINM = 26;

        /// <summary>
        /// 掲載日
        /// </summary>
        private const int KOTU_KEISAI = 27;

        /// <summary>
        /// 掲載回数
        /// </summary>
        private const int KOTU_KEICNT = 28;

        /// <summary>
        /// 掲載単価
        /// </summary>
        private const int KOTU_KEITANKA = 29;

        /// <summary>
        /// 掲載料
        /// </summary>
        private const int KOTU_KEIRYO = 30;

        /// <summary>
        /// 印刷単価
        /// </summary>
        private const int KOTU_INSTANKA = 31;

        /// <summary>
        /// 印刷部数
        /// </summary>
        private const int KOTU_INSBUCNT = 32;

        /// <summary>
        /// 印刷代
        /// </summary>
        private const int KOTU_INSDAI = 33;

        /// <summary>
        /// 差替作業料
        /// </summary>
        private const int KOTU_SASHIRYO = 34;

        /// <summary>
        /// デザイン変更回数
        /// </summary>
        private const int KOTU_DESIGNCNT = 35;

        /// <summary>
        /// デザイン料
        /// </summary>
        private const int KOTU_DESIGNRYO = 36;

        /// <summary>
        /// 版下代
        /// </summary>
        private const int KOTU_HANSHITADAI = 37;

        /// <summary>
        /// 製版代
        /// </summary>
        private const int KOTU_SEIHANDAI = 38;

        /// <summary>
        /// 登録年月日
        /// </summary>
        private const int KOTU_TOUDATE = 39;

        /// <summary>
        /// 変更年月日
        /// </summary>
        private const int KOTU_HENDATE = 40;

        /// <summary>
        /// 取消年月日
        /// </summary>
        private const int KOTU_TORIDATE = 41;

        #endregion

        #region インポートカラム数

        /// <summary>
        /// インポートカラム数（新聞）.
        /// </summary>
        private const int IMPORT_COLUMN_COUNT_SNBN = 42;

        /// <summary>
        /// インポートカラム数（雑誌）.
        /// </summary>
        private const int IMPORT_COLUMN_COUNT_ZASI = 44;

        /// <summary>
        /// インポートカラム数（電波）.
        /// </summary>
        private const int IMPORT_COLUMN_COUNT_DENP = 42;

        /// <summary>
        /// インポートカラム数（交通）.
        /// </summary>
        private const int IMPORT_COLUMN_COUNT_KOTU = 42;

        #endregion

        #endregion

        #region メンバ変数

        /// <summary>
        /// 必須パラメータ(KKHNaviParameter)
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();

        /// <summary>
        /// 読み込みファイルパス
        /// </summary>
        private String strReadFilePath = "";

        /// <summary>
        /// 出力ログファイルパス
        /// </summary>
        private String strLogFilePath = "";

        /// <summary>
        /// 出力ログファイル名
        /// </summary>
        private String strLogFilename = "";

        /// <summary>
        /// 発注取込用データ(全件)
        /// </summary>
        InPutHik _dsHikTrkm_All;

        /// <summary>
        /// 得意先別マスターデータ(全件)
        /// </summary>
        private MasterMaintenance _dsMasterData_All;

        /// <summary>
        /// マスタデータ取得用ハッシュテーブル
        /// </summary>
        private Hashtable MasterSybtKey; 

        /// <summary>
        /// 媒体種別名取得用ハッシュテーブル
        /// </summary>
        private Hashtable SybtCodeSybtKey; 

        /// <summary>
        /// 発注取込用データ(スプレッド表示中のみ)
        /// </summary>
        private InPutHik _dsHikTrkm_SpdList;

        /// <summary>
        /// 発注読み込みファイル名 
        /// </summary>
        private string stFileName;

        /// <summary>
        /// 新聞シート以外の各列のサイズ 
        /// </summary>
        string[] colCntArr  = new string[55];

        /// <summary>
        /// 新聞シートの各列のサイズ 
        /// </summary>
        string[] colCntArrSnbn = new string[36];

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public HikForm()
        {
            InitializeComponent();
        }

        #endregion コンストラクタ

        #region イベント
        /// <summary>
        /// 画面遷移時に必ず実行されるイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void HikForm_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg == null)
            {
                return;
            }
            else {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
            }
        }

        /// <summary>
        /// 「画面」が初期表示されたときに発生します 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HikForm_Shown(object sender, EventArgs e)
        {

            //初期年月を表示
            string _hostDate = string.Empty;

            CommonProcessController processController = CommonProcessController.GetInstance();
            _hostDate = processController.GetEigyoBi(KKHSecurityInfo.GetInstance().UserEsqId);
            //tbxYyMm.Value = _hostDate.Substring(0, 6);

            if (_hostDate != "")
            {
                _hostDate = _hostDate.Trim().Replace("/", "");
                if (_hostDate.Trim().Length >= 6)
                {
                    tbxYyMm.Value = _hostDate.Substring(0, 6);
                }
                else
                {
                    tbxYyMm.Value = _hostDate;
                }
                tbxYyMm.cmbYM_SetDate();
            }


            // 発注取込用データセットと一覧表示データセットの初期セット 
            _dsHikTrkm_All = new InPutHik();
            _dsHikTrkm_SpdList = new InPutHik();

            //新聞シートの各列の幅を取得 
            for (int i = 0; i < spdHikTrkmList_Sheet_Snbn.Columns.Count; i++)
            {
                colCntArrSnbn[i] = spdHikTrkmList_Sheet_Snbn.Columns[i].Width.ToString();
            }


            //新聞シート以外の各列の幅を取得 
            for (int i = 0; i < spdHikTrkmList_Sheet1.Columns.Count; i++)
            {
                colCntArr[i] = spdHikTrkmList_Sheet1.Columns[i].Width.ToString();
            }

            //スプレッド初期化 
            UpdateSpd_Design(new InPutHik());

            //コンボボックスの初期値セット
            DataTable SybtNameTable = new DataTable("SybtNameTable");
            SybtNameTable.Columns.Add("Display", typeof(string));
            SybtNameTable.Columns.Add("Value", typeof(int));
            SybtNameTable.Rows.Add(KkhConstAcom.MediaKindName.SYBT_SNBN_NAME, KkhConstAcom.MediaKindCode.SYBT_SNBN);
            SybtNameTable.Rows.Add(KkhConstAcom.MediaKindName.SYBT_ZASI_NAME, KkhConstAcom.MediaKindCode.SYBT_ZASI);
            SybtNameTable.Rows.Add(KkhConstAcom.MediaKindName.SYBT_DENP_NAME, KkhConstAcom.MediaKindCode.SYBT_DENP);
            SybtNameTable.Rows.Add(KkhConstAcom.MediaKindName.SYBT_KOTU_NAME, KkhConstAcom.MediaKindCode.SYBT_KOTU);
            
            cbxSybtName.DataSource = SybtNameTable;
            cbxSybtName.DisplayMember = "Display";
            cbxSybtName.ValueMember = "Value";

            // 初期表示設定 
            spdHikTrkmList_Sheet1.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_SAISINFLG].Visible = false;
            spdHikTrkmList_Sheet1.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_KOUKBNCODE].Visible = false;
            spdHikTrkmList_Sheet_Snbn.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_SNBN_SAISINFLG].Visible = false;
            spdHikTrkmList_Sheet_Snbn.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_SNBN_KOUKBNCODE].Visible = false;

            // 新聞シートを表示にする 
            spdHikTrkmList_Sheet_Snbn.Visible = true;
            spdHikTrkmList_Sheet1.Visible = false;

            //ステータスバーの編集 
            tslName.Text = _naviParam.strName;
            tslDate.Text = _naviParam.strDate;

            // デフォルトパス、ファイル名等を取得.
            CommonProcessController commonProcessController2 = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult2 = commonProcessController2.FindCommonByCond(
                                                                                            _naviParam.strEsqId,
                                                                                            _naviParam.strEgcd,
                                                                                            _naviParam.strTksKgyCd,
                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                            _naviParam.strTksTntSeqNo,
                                                                                            Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.ReportType,
                                                                                            SYSTEM_KEY_FILE_PATH);
            if (comResult2.CommonDataSet.SystemCommon.Count != 0)
            {
                //読み込みファイルパス.
                strReadFilePath = comResult2.CommonDataSet.SystemCommon[0].field2.ToString();
                //出力ログファイルパス.
                strLogFilePath = comResult2.CommonDataSet.SystemCommon[0].field3.ToString();
                //出力ログファイル名.
                strLogFilename = comResult2.CommonDataSet.SystemCommon[0].field4.ToString();
            }
            else
            {
                //読み込みファイルパス.
                strReadFilePath = DefaultReadFilePath;
                //出力ログファイルパス.
                strLogFilePath = DefaultLogFilePath;
                //出力ログファイル名.
                strLogFilename = DefaultLogFilename;
            }
        }

        /// <summary>
        /// 「読込ファイル一覧」ボタンコントロールがクリックされたときに発生します 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRead_Click(object sender, EventArgs e)
        {
            //ファイル選択ダイアログ表示 
            OpenFileDialog MyDialog = new OpenFileDialog();

            //デフォルトディレクトリ
            MyDialog.InitialDirectory = strReadFilePath;

            //ファイル選択制限 
            if (KKHUtility.ToString(cbxSybtName.SelectedValue).CompareTo(KkhConstAcom.MediaKindCode.SYBT_ZASI) == 0)
            {
                //雑誌.
                MyDialog.Filter = KkhConstAcom.InputFileNameCheckType.FILENAME_ZASI;
            }
            else if (KKHUtility.ToString(cbxSybtName.SelectedValue).CompareTo(KkhConstAcom.MediaKindCode.SYBT_DENP) == 0)
            {
                //電波.
                MyDialog.Filter = KkhConstAcom.InputFileNameCheckType.FILENAME_DENP;
            }
            else if (KKHUtility.ToString(cbxSybtName.SelectedValue).CompareTo(KkhConstAcom.MediaKindCode.SYBT_KOTU) == 0)
            {
                //交通.
                MyDialog.Filter = KkhConstAcom.InputFileNameCheckType.FILENAME_KOTU;
            }
            else
            {
                //新聞.
                MyDialog.Filter = KkhConstAcom.InputFileNameCheckType.FILENAME_SNBN;
            }

            //ダイアログOKの場合 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                //選択したファイル名を取得 
                string textName = MyDialog.FileName;

                //選択ファイルの拡張子取得 
                string stExtension = System.IO.Path.GetExtension(@textName);
                string stRoot = System.IO.Path.GetDirectoryName(@textName);
                stFileName = System.IO.Path.GetFileName(@textName);

                //ファイル読み込み 
                string[] lines1 = File.ReadAllLines(@textName, System.Text.Encoding.GetEncoding("Shift_JIS"));
                Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

                //データ数チェック 
                //読み込みデータが0件の場合 
                if(lines1.Length == 0)
                {
                    string[] comment = new string[]{KkhConstAcom.MessageList.FILE_INPUT_OK_ZERO};
                    //MessageBox.Show(KkhConstAcom.MessageList.FILE_INPUT_OK_ZERO, KkhConstAcom.MessageList.FILE_INPUT_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MessageUtility.ShowMessageBox(MessageCode.HB_I0013, comment, KkhConstAcom.MessageList.FILE_INPUT_TITLE, MessageBoxButtons.OK);
                    return;
                }

                //保存対象のデータセット設定 
                InPutHik targetDS = new InPutHik();
                int fileImpLoopCnt = 0;                                //ループ回数(エラーメッセージで使用) 
                int columnsCnt = targetDS.FileImp.Columns.Count;       //カラム数 
                string strErrorMsg = string.Empty;                     //エラーメッセージ 
                DialogResult OCFlg;
                

                //マスターデータ取得用ハッシュテーブル設定 
                MasterSybtKey = new Hashtable();
                MasterSybtKey.Add(KkhConstAcom.MediaKindMasterKey.MEDIA_KIND_MASTERKEY, KkhConstAcom.MasterConvertKey.MEDIA_KIND_SYBTKEY);
                MasterSybtKey.Add(KkhConstAcom.MediaKindMasterKey.KEISAI_MASTERKEY, KkhConstAcom.MasterConvertKey.KEISAI_SYBTKEY);
                MasterSybtKey.Add(KkhConstAcom.MediaKindMasterKey.SIZE_MASTERKEY, KkhConstAcom.MasterConvertKey.SIZE_SYBTKEY);
                MasterSybtKey.Add(KkhConstAcom.MediaKindMasterKey.KIZATSU_MASTERKEY, KkhConstAcom.MasterConvertKey.KIZATSU_SYBTKEY);
                MasterSybtKey.Add(KkhConstAcom.MediaKindMasterKey.ASAYUU_MASTERKEY, KkhConstAcom.MasterConvertKey.ASAYUU_SYBTKEY);
                MasterSybtKey.Add(KkhConstAcom.MediaKindMasterKey.MEDIA_MASTERKEY, KkhConstAcom.MasterConvertKey.MEDIA_SYBTKEY);
                MasterSybtKey.Add(KkhConstAcom.MediaKindMasterKey.COLOR_MASTERKEY, KkhConstAcom.MasterConvertKey.COLOR_SYBTKEY);

                //媒体種別名取得用ハッシュテーブル設定 
                SybtCodeSybtKey = new Hashtable();
                SybtCodeSybtKey.Add(KkhConstAcom.MediaKindCode.SYBT_SNBN, KkhConstAcom.MediaKindName.SYBT_SNBN_NAME);
                SybtCodeSybtKey.Add(KkhConstAcom.MediaKindCode.SYBT_ZASI, KkhConstAcom.MediaKindName.SYBT_ZASI_NAME);
                SybtCodeSybtKey.Add(KkhConstAcom.MediaKindCode.SYBT_DENP, KkhConstAcom.MediaKindName.SYBT_DENP_NAME);
                SybtCodeSybtKey.Add(KkhConstAcom.MediaKindCode.SYBT_KOTU, KkhConstAcom.MediaKindName.SYBT_KOTU_NAME);

                //数値変換エラー保存List 
                foreach (string fileData in lines1)
                {
                    if (CheckFileLength(KKHUtility.ToString(cbxSybtName.SelectedValue), fileData) == false)
                    {
                        // ファイル長さチェック不正 
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0017, new string[] { ( fileImpLoopCnt + 1 ).ToString() }, "データエラー", MessageBoxButtons.OK);
                        return;
                    }

                    // ワークにファイル内容をセット.
                    SetFileImpTemp_FileData(targetDS, fileData, fileImpLoopCnt);

                    // カラム数分ファイルの属性チェック(半角、全角、数値) 
                    if (CheckAttribute(targetDS.FileImpTemp[fileImpLoopCnt], KKHUtility.ToString(cbxSybtName.SelectedValue), fileImpLoopCnt, ref strErrorMsg) == false)
                    {
                        // ファイル属性エラー 
                        // ダイアログ表示 
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new string[] { strErrorMsg }, "データエラー", MessageBoxButtons.OK);
                        return;
                    }

                    // チェック後のワークをインポート用に移し替える
                    SetFileImp_FileData(targetDS, fileImpLoopCnt);

                    //必須パラメータをセット 
                    targetDS.FileImp[fileImpLoopCnt].EsqId = _naviParam.strEsqId;
                    targetDS.FileImp[fileImpLoopCnt].Egcd = _naviParam.strEgcd;
                    targetDS.FileImp[fileImpLoopCnt].TksKgyCd = _naviParam.strTksKgyCd;
                    targetDS.FileImp[fileImpLoopCnt].TksBmnSeqNo = _naviParam.strTksBmnSeqNo;
                    targetDS.FileImp[fileImpLoopCnt].TksTntSeqNo = _naviParam.strTksTntSeqNo;

                    fileImpLoopCnt++;
                }

                //マスタ存在チェック 
                if (GetTokuibetuMasterData(targetDS, KKHUtility.ToString(cbxSybtName.SelectedValue)) == false)
                {
                    // マスタに存在しないコードのチェック 
                    strErrorMsg = "発注データの中にマスタで存在しないコードが含まれているため取込を中止します。" + Environment.NewLine +
                                  "ログファイル(" + strLogFilePath + strLogFilename + ")を確認して対象となるデータをマスタ登録してから再度取込を行ってください。"; 

                    //ダイアログ表示 
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new string[] { strErrorMsg }, "マスタに存在しないコードあり", MessageBoxButtons.OK);
                    return;
                }

                //登録前日付チェック 
                targetDS = CheckRegistDateData(targetDS);

                // 読み込みデータが1件以上の場合 
                if (targetDS.FileImp.Count > 0)
                {
                    //登録前に比較情報取得のために検索を行う 
                    InPutProcessController inPutProcessController = InPutProcessController.GetInstance();
                    FindHikCheckDataByCondServiceResult cdresult = inPutProcessController.FindHikCheckDataByCond(targetDS);
                    List<int> compA = new List<int>();
                    Double TmpA = 0.0d;
                    Double TmpB = 0.0d;
                    DataRow[] UnRepeatedDataListRows = null;
                    string strFilter = "";
                    string  IrRowBanCnt = "";

                    //DBから値を取得できない場合 
                    if (cdresult.HasError)
                    {
                        ShowDBErrMsg(cdresult.MessageCode);
                        return;
                    }

                    if (cdresult.HikDataSet.FileImp.Count > 0)
                    {
                        for (int cnt = 0; cnt < targetDS.FileImp.Count; cnt++)
                        {
                            //読み込みデータから重複データの除外を行う。 
                            string tmpFilter = "IrBan = '" + targetDS.FileImp[cnt].IrBan + "'";
                            tmpFilter += " AND IrRowBan = '" + targetDS.FileImp[cnt].IrRowBan + "'";
                            UnRepeatedDataListRows = cdresult.HikDataSet.FileImp.Select(tmpFilter);

                            //比較データと登録データの比較処理を行う 
                            foreach (InPutHik.FileImpRow row in UnRepeatedDataListRows)
                            {
                                if (KKHUtility.ToString(cbxSybtName.SelectedValue).CompareTo(KkhConstAcom.MediaKindCode.SYBT_ZASI) == 0)
                                {
                                    // 種別が【雑誌】の場合 

                                    #region 登録前比較チェック(雑誌)

                                    //ファイル対象項目の1～9桁目をDoble型で取得		
                                    //テーブルとファイルの対象項目で、StrCompを実行して、結果Aをセット		

                                    //掲載単価.
                                    TmpA = Double.Parse(targetDS.FileImp[cnt].KeisaiTanka.Substring(0, 9));
                                    TmpB = Double.Parse(row.KeisaiTanka);
                                    compA.Add(String.Compare(TmpA.ToString().Trim(), TmpB.ToString().Trim()));

                                    //ファイル対象項目をDoble型で取得
                                    //テーブルとファイルの対象項目で、StrCompを実行して、結果Aをセット

                                    //掲載料.
                                    TmpA = Double.Parse(targetDS.FileImp[cnt].KeisaiRyo.ToString());
                                    TmpB = Double.Parse(row.KeisaiRyo.ToString());
                                    compA.Add(String.Compare(TmpA.ToString().Trim(), TmpB.ToString().Trim()));

                                    //デザイン料.
                                    TmpA = Double.Parse(targetDS.FileImp[cnt].DesignRyo.ToString());
                                    TmpB = Double.Parse(row.DesignRyo.ToString());
                                    compA.Add(String.Compare(TmpA.ToString().Trim(), TmpB.ToString().Trim()));

                                    //版下代.
                                    TmpA = Double.Parse(targetDS.FileImp[cnt].HanShitaRyo.ToString());
                                    TmpB = Double.Parse(row.HanShitaRyo.ToString());
                                    compA.Add(String.Compare(TmpA.ToString().Trim(), TmpB.ToString().Trim()));

                                    //製版代.
                                    TmpA = Double.Parse(targetDS.FileImp[cnt].SeiHanRyo.ToString());
                                    TmpB = Double.Parse(row.SeiHanRyo.ToString());
                                    compA.Add(String.Compare(TmpA.ToString().Trim(), TmpB.ToString().Trim()));

                                    //通常の比較処理
                                    //掲載場所名はチェック対象外.

                                    //色刷コード.
                                    compA.Add(String.Compare(row.ColorCd, targetDS.FileImp[cnt].ColorCd.Trim()));

                                    //サイズコード.
                                    compA.Add(String.Compare(row.SizeCd, targetDS.FileImp[cnt].SizeCd.Trim()));

                                    //サイズ名.
                                    compA.Add(String.Compare(row.SizeName, targetDS.FileImp[cnt].SizeName.Trim()));

                                    //掲載日1.
                                    compA.Add(String.Compare(row.Keisai1, targetDS.FileImp[cnt].Keisai1.Trim()));

                                    //掲載日2.
                                    compA.Add(String.Compare(row.Keisai2, targetDS.FileImp[cnt].Keisai2.Trim()));

                                    //掲載日3.
                                    compA.Add(String.Compare(row.Keisai3, targetDS.FileImp[cnt].Keisai3.Trim()));

                                    //掲載日4.
                                    compA.Add(String.Compare(row.Keisai4, targetDS.FileImp[cnt].Keisai4.Trim()));

                                    //掲載日5.
                                    compA.Add(String.Compare(row.Keisai5, targetDS.FileImp[cnt].Keisai5.Trim()));

                                    //掲載回数.
                                    compA.Add(String.Compare(row.KeisaiCnt, targetDS.FileImp[cnt].KeisaiCnt.Trim()));

                                    //デザイン変更回数.
                                    compA.Add(String.Compare(row.DesignCnt, targetDS.FileImp[cnt].DesignCnt.Trim()));

                                    //共通項目の比較.
                                    RepeatDataChk(targetDS.FileImp[cnt], row, compA);

                                    #endregion
                                }
                                else if (KKHUtility.ToString(cbxSybtName.SelectedValue).CompareTo(KkhConstAcom.MediaKindCode.SYBT_DENP) == 0)
                                {
                                    //種別が【電波】の場合 

                                    #region 登録前比較チェック(電波)

                                    //ファイル対象項目をDoble型で取得
                                    //テーブルとファイルの対象項目で、StrCompを実行して、結果Aをセット

                                    //放送料1.
                                    TmpA = Double.Parse(targetDS.FileImp[cnt].HosoRyo1.ToString().Trim());
                                    TmpB = Double.Parse(row.HosoRyo1.ToString());
                                    compA.Add(String.Compare(TmpA.ToString().Trim(), TmpB.ToString().Trim()));

                                    //放送料2.
                                    TmpA = Double.Parse(targetDS.FileImp[cnt].HosoRyo2.ToString().Trim());
                                    TmpB = Double.Parse(row.HosoRyo2.ToString());
                                    compA.Add(String.Compare(TmpA.ToString().Trim(), TmpB.ToString().Trim()));

                                    //放送料3.
                                    TmpA = Double.Parse(targetDS.FileImp[cnt].HosoRyo3.ToString().Trim());
                                    TmpB = Double.Parse(row.HosoRyo3.ToString());
                                    compA.Add(String.Compare(TmpA.ToString().Trim(), TmpB.ToString().Trim()));

                                    //放送料4.
                                    TmpA = Double.Parse(targetDS.FileImp[cnt].HosoRyo4.ToString().Trim());
                                    TmpB = Double.Parse(row.HosoRyo4.ToString());
                                    compA.Add(String.Compare(TmpA.ToString().Trim(), TmpB.ToString().Trim()));

                                    //放送料5.
                                    TmpA = Double.Parse(targetDS.FileImp[cnt].HosoRyo5.ToString().Trim());
                                    TmpB = Double.Parse(row.HosoRyo5.ToString());
                                    compA.Add(String.Compare(TmpA.ToString().Trim(), TmpB.ToString().Trim()));

                                    //放送料6.
                                    TmpA = Double.Parse(targetDS.FileImp[cnt].HosoRyo6.ToString().Trim());
                                    TmpB = Double.Parse(row.HosoRyo6.ToString());
                                    compA.Add(String.Compare(TmpA.ToString().Trim(), TmpB.ToString().Trim()));

                                    //通常の比較処理

                                    //形態区分. 
                                    compA.Add(String.Compare(row.KeitaiCd, targetDS.FileImp[cnt].KeitaiCd.Trim()));

                                    //形態区分名.
                                    compA.Add(String.Compare(row.KeitaiName, targetDS.FileImp[cnt].KeitaiName.Trim()));

                                    //依頼月１.
                                    compA.Add(String.Compare(row.IrMonth1, targetDS.FileImp[cnt].IrMonth1.Trim()));

                                    //依頼月２.
                                    compA.Add(String.Compare(row.IrMonth2, targetDS.FileImp[cnt].IrMonth2.Trim()));

                                    //依頼月３.
                                    compA.Add(String.Compare(row.IrMonth3, targetDS.FileImp[cnt].IrMonth3.Trim()));

                                    //依頼月４.
                                    compA.Add(String.Compare(row.IrMonth4, targetDS.FileImp[cnt].IrMonth4.Trim()));

                                    //依頼月５.
                                    compA.Add(String.Compare(row.IrMonth5, targetDS.FileImp[cnt].IrMonth5.Trim()));

                                    //依頼月６.
                                    compA.Add(String.Compare(row.IrMonth6, targetDS.FileImp[cnt].IrMonth6.Trim()));

                                    //共通項目の比較 .
                                    RepeatDataChk(targetDS.FileImp[cnt], row, compA);

                                    #endregion
                                }
                                else if (KKHUtility.ToString(cbxSybtName.SelectedValue).CompareTo(KkhConstAcom.MediaKindCode.SYBT_KOTU) == 0)
                                {
                                    //種別が【交通】の場合 

                                    #region 登録前比較チェック(交通)

                                    //ファイル対象項目の1～9桁目をDoble型で取得		
                                    //テーブルとファイルの対象項目で、StrCompを実行して、結果Aをセット		

                                    //掲載単価.
                                    TmpA = Double.Parse(targetDS.FileImp[cnt].KeisaiTanka.ToString().Substring(0, 9));
                                    TmpB = Double.Parse(row.KeisaiTanka.ToString());
                                    compA.Add(String.Compare(TmpA.ToString().Trim(), TmpB.ToString().Trim()));

                                    //ファイル対象項目をDoble型で取得
                                    //テーブルとファイルの対象項目で、StrCompを実行して、結果Aをセット

                                    //掲載料.
                                    TmpA = Double.Parse(targetDS.FileImp[cnt].KeisaiRyo.ToString().Trim());
                                    TmpB = Double.Parse(row.KeisaiRyo.ToString());
                                    compA.Add(String.Compare(TmpA.ToString().Trim(), TmpB.ToString().Trim()));

                                    //印刷料.
                                    TmpA = Double.Parse(targetDS.FileImp[cnt].PrintRyo.ToString().Trim());
                                    TmpB = Double.Parse(row.PrintRyo.ToString());
                                    compA.Add(String.Compare(TmpA.ToString().Trim(), TmpB.ToString().Trim()));

                                    //差し替え料.
                                    TmpA = Double.Parse(targetDS.FileImp[cnt].SashikaeRyo.ToString().Trim());
                                    TmpB = Double.Parse(row.SashikaeRyo.ToString());
                                    compA.Add(String.Compare(TmpA.ToString().Trim(), TmpB.ToString().Trim()));

                                    //デザイン料.
                                    TmpA = Double.Parse(targetDS.FileImp[cnt].DesignRyo.ToString().Trim());
                                    TmpB = Double.Parse(row.DesignRyo.ToString());
                                    compA.Add(String.Compare(TmpA.ToString().Trim(), TmpB.ToString().Trim()));

                                    //版下代.
                                    TmpA = Double.Parse(targetDS.FileImp[cnt].HanShitaRyo.ToString().Trim());
                                    TmpB = Double.Parse(row.HanShitaRyo.ToString());
                                    compA.Add(String.Compare(TmpA.ToString().Trim(), TmpB.ToString().Trim()));

                                    //製版代.
                                    TmpA = Double.Parse(targetDS.FileImp[cnt].SeiHanRyo.ToString().Trim());
                                    TmpB = Double.Parse(row.SeiHanRyo.ToString());
                                    compA.Add(String.Compare(TmpA.ToString().Trim(), TmpB.ToString().Trim()));

                                    //通常の比較処理
                                    //種類コード.
                                    compA.Add(String.Compare(row.KotuKeiCd, targetDS.FileImp[cnt].KotuKeiCd.Trim()));

                                    //サイズ名.
                                    compA.Add(String.Compare(row.KotuKeiName, targetDS.FileImp[cnt].KotuKeiName.Trim()));

                                    //掲載日.
                                    compA.Add(String.Compare(row.Keisai, targetDS.FileImp[cnt].Keisai.Trim()));

                                    //掲載回数.
                                    compA.Add(String.Compare(row.KeisaiCnt, targetDS.FileImp[cnt].KeisaiCnt.Trim()));

                                    //印刷単価はチェック対象外.

                                    //印刷部数はチェック対象外.

                                    //デザイン変更回数.
                                    compA.Add(String.Compare(row.DesignCnt, targetDS.FileImp[cnt].DesignCnt.Trim()));

                                    //共通項目の比較.
                                    RepeatDataChk(targetDS.FileImp[cnt], row, compA);

                                    #endregion
                                }
                                else
                                {
                                    //媒体が【新聞】場合             

                                    #region 登録前比較チェック(新聞)

                                    //ファイル対象項目をDoble型で取得して、100で割って取得
                                    //テーブルとファイルの対象項目で、StrCompを実行して、結果Aをセット

                                    //掲載単価.
                                    if (targetDS.FileImp[cnt].KeisaiTanka.CompareTo("0") != 0)
                                    {
                                        //0割り防止
                                        TmpA = Double.Parse(targetDS.FileImp[cnt].KeisaiTanka.Trim()) / 100;
                                    }
                                    else
                                    {
                                        TmpA = 0;
                                    }

                                    TmpB = Double.Parse(row.KeisaiTanka);
                                    compA.Add(String.Compare(TmpA.ToString().Trim(), TmpB.ToString().Trim()));

                                    //ファイル対象項目をDoble型で取得
                                    //テーブルとファイルの対象項目で、StrCompを実行して、結果Aをセット
                                    //掲載料
                                    TmpA = Double.Parse(targetDS.FileImp[cnt].KeisaiRyo.ToString().Trim());
                                    TmpB = Double.Parse(row.KeisaiRyo.ToString());
                                    compA.Add(String.Compare(TmpA.ToString().Trim(), TmpB.ToString().Trim()));

                                    //デザイン料.
                                    TmpA = Double.Parse(targetDS.FileImp[cnt].DesignRyo.ToString().Trim());
                                    TmpB = Double.Parse(row.DesignRyo.ToString());
                                    compA.Add(String.Compare(TmpA.ToString().Trim(), TmpB.ToString().Trim()));

                                    //版下料.
                                    TmpA = Double.Parse(targetDS.FileImp[cnt].HanShitaRyo.ToString().Trim());
                                    TmpB = Double.Parse(row.HanShitaRyo.ToString());
                                    compA.Add(String.Compare(TmpA.ToString().Trim(), TmpB.ToString().Trim()));

                                    //製版料.
                                    TmpA = Double.Parse(targetDS.FileImp[cnt].SeiHanRyo.ToString().Trim());
                                    TmpB = Double.Parse(row.SeiHanRyo.ToString());
                                    compA.Add(String.Compare(TmpA.ToString().Trim(), TmpB.ToString().Trim()));

                                    //通常の比較処理
                                    //掲載場所コード.
                                    compA.Add(String.Compare(row.PlaceCd, targetDS.FileImp[cnt].PlaceCd.Trim()));

                                    //種別コード1.
                                    compA.Add(String.Compare(row.Sybt1Cd, targetDS.FileImp[cnt].Sybt1Cd.Trim()));

                                    //種別コード2.
                                    compA.Add(String.Compare(row.Sybt2Cd, targetDS.FileImp[cnt].Sybt2Cd.Trim()));

                                    //色刷コード.
                                    compA.Add(String.Compare(row.ColorCd, targetDS.FileImp[cnt].ColorCd.Trim()));

                                    //サイズコード（スペースコード）.
                                    compA.Add(String.Compare(row.SpaceCd, targetDS.FileImp[cnt].SpaceCd.Trim()));

                                    //サイズ名（スペース名）.
                                    compA.Add(String.Compare(row.SpaceName, targetDS.FileImp[cnt].SpaceName.Trim()));

                                    //掲載日.
                                    compA.Add(String.Compare(row.Keisai, targetDS.FileImp[cnt].Keisai.Trim()));

                                    //掲載回数.
                                    compA.Add(String.Compare(row.KeisaiCnt, targetDS.FileImp[cnt].KeisaiCnt.Trim()));

                                    //デザイン変更回数.
                                    compA.Add(String.Compare(row.DesignCnt, targetDS.FileImp[cnt].DesignCnt.Trim()));

                                    //共通項目の比較.
                                    RepeatDataChk(targetDS.FileImp[cnt], row, compA);

                                    #endregion
                                }

                                //最新の履歴管理番号取得 
                                targetDS.FileImp[cnt].RireNo = DecimalParse(row.RireNo).ToString();

                                bool flg = false;
                                foreach (int i in compA)
                                {
                                    if (i != 0)
                                    {
                                        flg = true;
                                        break;
                                    }
                                }

                                //全部比較結果が同じであったら通常は登録を行わないため 
                                //除外するためのフィルターを生成する 
                                if (flg == false)
                                {
                                    strFilter += "'" + targetDS.FileImp[cnt].IrBan + "',";
                                    break;
                                }

                                compA.Clear();
                            }
                        }
                    }

                    //読み込みデータから重複データの除外を行う。 
                    InPutHik targetDS_Ins = new InPutHik();
                    DataRow[] insDataListRows;
                    ArrayList tmpArry = new ArrayList();

                    //重複データが1件以上ある場合 
                    if (strFilter.CompareTo("") != 0)
                    {
                        //カンマの削除を行う 
                        strFilter = strFilter.Substring(0, strFilter.Length - 1);
                        string[] tmp = strFilter.Split(new char[] { ',' });
                        strFilter = null;

                        foreach (string ary in tmp)
                        {
                            if (!tmpArry.Contains(ary))
                            {
                                //判定用のために保存する 
                                tmpArry.Add(ary);
                                strFilter += ary + ",";
                            }
                        }

                        //カンマの削除を行う 
                        strFilter = strFilter.Substring(0, strFilter.Length - 1);
                        IrRowBanCnt = strFilter;//メッセージ用履歴番号取得 
                        strFilter = "IrBan NOT IN(" + strFilter + ")";//フィルター文字列設定 

                        //重複確認ダイアログ出力 
                        OCFlg = MessageUtility.ShowMessageBox(MessageCode.HB_W0021,
                                                new string[]{Environment.NewLine, IrRowBanCnt + Environment.NewLine},
                                                "差異がない発注の取込確認", 
                                                 MessageBoxButtons.YesNo);

                        //OK 
                        if (OCFlg == DialogResult.Yes)
                        {
                            targetDS_Ins.Merge(targetDS.FileImp);
                        }
                        //Cancel 
                        else
                        {
                            //フィルターを使用して重複データを除外する 
                            insDataListRows = targetDS.FileImp.Select(strFilter);
                            targetDS_Ins.Merge(insDataListRows);
                        }
                    }
                    else
                    {
                        targetDS_Ins.Merge(targetDS.FileImp);
                    }

                    //読み込みデータが1件以上の場合のみ登録処理を行う 
                    if (targetDS_Ins.FileImp.Rows.Count > 0)
                    {
                        //履歴管理番号を付加する。  
                        for (int i = 0; i < targetDS_Ins.FileImp.Rows.Count; i++)
                        {
                            //新規発注取込情報の場合、履歴管理番号を001で登録する 
                            if (targetDS_Ins.FileImp[i].RireNo.CompareTo(" ") == 0)
                            {
                                //履歴管理番号の設定 
                                targetDS_Ins.FileImp[i].RireNo = "001";   //履歴管理番号 
                            }
                            //それ以外の場合は、既存の履歴管理番号に+1した値で登録する 
                            else
                            {
                                //履歴管理番号の設定 
                                Decimal tmp = DecimalParse(targetDS_Ins.FileImp[i].RireNo) + 1;   //履歴管理番号 
                                targetDS_Ins.FileImp[i].RireNo = string.Format("{0:000}", tmp);
         
                            }

                            targetDS_Ins.FileImp[i].TrkPl = updateAplID;                                     //登録プログラム 
                            targetDS_Ins.FileImp[i].TrkTnt = _naviParam.strEsqId;                            //登録担当者 


                            targetDS_Ins.FileImp[i].UpdaPl = updateAplID;                                    //更新プログラム  
                            targetDS_Ins.FileImp[i].UpdTnt = _naviParam.strEsqId;                            //更新担当者 


                            targetDS_Ins.FileImp[i].RecCd = KkhConstAcom.REC_CD; ;                           //レコード種別   
                            targetDS_Ins.FileImp[i].KouKbn = " ";                                            //更新区分      

                            //下記の項目は、媒体種別毎にセットする方法が異なる 
                            //媒体種別が【新聞】の場合 
                            if (KKHUtility.ToString(cbxSybtName.SelectedValue).CompareTo(KkhConstAcom.MediaKindCode.SYBT_SNBN) == 0)
                            {
                                //掲載単価 
                                //targetDS_Ins.FileImp[i].KeisaiTanka = Double.Parse(targetDS_Ins.FileImp[i].KeisaiTanka.Substring(1, 9)).ToString();
                                Double tmpdbl;
                                
                                if(targetDS_Ins.FileImp[i].KeisaiTanka.CompareTo("0") == 0)
                                {
                                    //0割り防止 
                                    tmpdbl = 0;
                                    targetDS_Ins.FileImp[i].KeisaiTanka = tmpdbl.ToString();
                                }
                                else
                                {
                                    tmpdbl = Double.Parse(targetDS_Ins.FileImp[i].KeisaiTanka) / 100;
                                    targetDS_Ins.FileImp[i].KeisaiTanka = tmpdbl.ToString();
                                }
                            }
                            //媒体種別が【雑誌】【交通】の場合 
                            else if ((KKHUtility.ToString(cbxSybtName.SelectedValue).CompareTo(KkhConstAcom.MediaKindCode.SYBT_KOTU) == 0) || 
                                     (KKHUtility.ToString(cbxSybtName.SelectedValue).CompareTo(KkhConstAcom.MediaKindCode.SYBT_ZASI) == 0))
                            {
                                //掲載単価 
                                Double tmpdbl;
                                tmpdbl = Double.Parse(targetDS_Ins.FileImp[i].KeisaiTanka.Substring(0, 9));
                                targetDS_Ins.FileImp[i].KeisaiTanka = tmpdbl.ToString();
                            }
                        }

                        //データの登録を行う。 
                        HikFileInsertServiceResult result = inPutProcessController.RegistHikInsert(targetDS_Ins);
                        
                        //DBから値を取得できない場合 
                        if (result.HasError)
                        {
                            ShowDBErrMsg(result.MessageCode);
                            return;
                        }
                        //登録完了 
                        //MessageBox.Show(KkhConstAcom.MessageList.FILE_INPUT_OK, KkhConstAcom.MessageList.FILE_INPUT_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        MessageUtility.ShowMessageBox(MessageCode.HB_I0013, new string[] { KkhConstAcom.MessageList.FILE_INPUT_OK }, KkhConstAcom.MessageList.FILE_INPUT_TITLE, MessageBoxButtons.OK);
                        //ログ出力 
                        OutPutLogData();

                        ////スプレッドの更新 
                        //SearchHattyuData();
                    }
                    //読み込みデータが0件の場合 
                    else
                    {
                       // MessageBox.Show(KkhConstAcom.MessageList.FILE_INPUT_OK_ZERO, KkhConstAcom.MessageList.FILE_INPUT_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        MessageUtility.ShowMessageBox(MessageCode.HB_I0013, new string[] { KkhConstAcom.MessageList.FILE_INPUT_OK_ZERO }, KkhConstAcom.MessageList.FILE_INPUT_TITLE, MessageBoxButtons.OK);
                    }
                }
                //読み込みデータが0件の場合 
                else
                {
                    //MessageBox.Show(KkhConstAcom.MessageList.FILE_INPUT_OK_ZERO, KkhConstAcom.MessageList.FILE_INPUT_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MessageUtility.ShowMessageBox(MessageCode.HB_I0013, new string[] { KkhConstAcom.MessageList.FILE_INPUT_OK_ZERO }, KkhConstAcom.MessageList.FILE_INPUT_TITLE, MessageBoxButtons.OK);
                }
            }
        }

        /// <summary>
        /// 「帳票作成」ボタンコントロールがクリックされたときに発生します 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcelOut_Click(object sender, EventArgs e)
        {
            // 一覧が0件の場合 
            if (spdHikList.ActiveSheet.Rows.Count == 0)
            {
                //帳票出力不可メッセージ表示 
                //MessageBox.Show("帳票作成対象データが表示されていません", "作成対象なし", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageUtility.ShowMessageBox(MessageCode.HB_W0061, null, "作成対象なし", MessageBoxButtons.OK);

                this.ActiveControl = null;

                return;
            }

            // 出力パス 
            string excelOutPut = string.Empty;

            //SaveFileDialogクラスのインスタンスを作成 
            SaveFileDialog sfd = new SaveFileDialog();

            //ファイル名を指定 
            sfd.FileName = "発注データ取込.xls";

            //初期表示フォルダを指定 
            sfd.InitialDirectory = @"C:\work\";

            //[ファイルの種類]を指定 
            sfd.Filter = "EXCELﾌｧｲﾙ|*.xls";

            //「すべてのファイル」が選択されているようにする 
            sfd.FilterIndex = 2;

            //タイトルを設定 
            sfd.Title = "保存先のファイルを選択してください";

            //ダイアログボックスを閉じる前に復元するようにする 
            sfd.RestoreDirectory = true;

            //ダイアログを表示する 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //文字列末の".xls"を削除する 
                sfd.FileName = sfd.FileName.Substring(0, sfd.FileName.Length - 4);

                //OKボタンがクリックされたとき 
                excelOutPut = System.IO.Path.GetDirectoryName(sfd.FileName);
            }
            else
            {
                return;
            }

            using (KKHSpreadOutPutExcelHandler spreadOutPutExcelHandler
                = new KKHSpreadOutPutExcelHandler(this.spdHikList, sfd.FileName))
            {
                spreadOutPutExcelHandler.OutPutExcel();
                spreadOutPutExcelHandler.ProcessStart();
            }
        }

        /// <summary>
        /// 「戻る」ボタンコントロールがクリックされたときに発生します 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, _naviParam, true);
        }

        /// <summary>
        /// 「表示」ボタンコントロールがクリックされたときに発生します 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 指定年月日の確認と設定 
            string strCheckYyMm = tbxYyMm.Value;
            bool isCheckYyMm = false;

            // 指定年月確認 
            if (strCheckYyMm.Length == 6)
            {
                strCheckYyMm = strCheckYyMm.Insert(4, "/");
                DateTime dtimeCheckYyMm;

                // 年月正常確認 
                if (DateTime.TryParse(strCheckYyMm, out dtimeCheckYyMm) == true)
                {
                    // 指定年月正常 
                    isCheckYyMm = true;
                }
            }

            if (isCheckYyMm == false)
            {
                // 指定年月エラー 
                MessageUtility.ShowMessageBox(MessageCode.HB_W0039, null, "指定年月不正", MessageBoxButtons.OK);

                this.ActiveControl = null;
                return;
            }
            else 
            {
                //ローディング表示開始 
                base.ShowLoadingDialog();

                SearchHattyuData();

                //ローディング表示終了
                base.CloseLoadingDialog();
            }
        }

        /// <summary>
        /// 「種別」コンボボックスのリストが閉じられた時に発生します 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxBaiName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // 列表示変更 
            // スプレッドのクリア 
            UpdateSpd_Design(new InPutHik());
        }

        /// <summary>
        /// 「最新」ラジオコントロールがクリックされたときに発生します 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbnSaiSin_CheckedChanged(object sender, EventArgs e)
        {
            // チェック確認 
            if (rbnSaiSin.Checked == false)
            {
                return;
            }

            // 一覧件数確認 
            if (spdHikList.ActiveSheet.Rows.Count == 0)
            {
                return;
            }

            // 「最新」のみを表示 
            UpdateSpd_SaiSin();
        }

        /// <summary>
        /// 「履歴」ラジオコントロールがクリックされたときに発生します 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbnRireki_CheckedChanged(object sender, EventArgs e)
        {
            // チェック確認 
            if (rbnRireki.Checked == false)
            {
                return;
            }

            // 一覧件数確認 
            if (spdHikList.ActiveSheet.Rows.Count == 0)
            {
                return;
            }

            // スプレッドの更新(履歴) 
            UpdateSpd_Rireki();
        }

        /// <summary>
        /// ヘルプボタンクリック処理 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            string tkskgy = _naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //実行 
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.InputHik, this, HelpNavigator.KeywordIndex);

            this.ActiveControl = null;
        }

        #endregion

        #region プライベートメソッド
        /// <summary>
        /// スプレッド更新(最新)
        /// </summary>
        private void UpdateSpd_SaiSin()
        {
            // 一覧のフィルタ実行 
            string strFilter = KkhConstAcom.FILTER_SAISINFLG1;
            if (KKHUtility.ToString(cbxSybtName.SelectedValue).CompareTo(KkhConstAcom.MediaKindCode.SYBT_DENP) == 0)
            {
                // 電波の場合は、当月のみ対象 
                strFilter += " AND " + KkhConstAcom.FILTER_IRYYMM + "'" + tbxYyMm.Value + "'";
            }

            InPutHik dsHikTrkm_Filter = new InPutHik();
            DataRow[] selectedHikListRows;
            if (KKHUtility.ToString(cbxSybtName.SelectedValue).CompareTo(KkhConstAcom.MediaKindCode.SYBT_SNBN) != 0)
            {
                selectedHikListRows = _dsHikTrkm_All.InPutHikData.Select(strFilter);
            }
            else
            {
                selectedHikListRows = _dsHikTrkm_All.InPutHikData_Snbn.Select(strFilter);
            }
            dsHikTrkm_Filter.Merge(selectedHikListRows);

            // スプレッドの更新 
            UpdateSpd_Design(dsHikTrkm_Filter);
        }

        /// <summary>
        /// スプレッド更新(履歴) 
        /// </summary>
        private void UpdateSpd_Rireki()
        {
            // 履歴の場合は並び順を変更 
            InPutHik dsHikTrkm_Filter = new InPutHik();
            DataRow[] selectedHikListRows;
            if (KKHUtility.ToString(cbxSybtName.SelectedValue).CompareTo(KkhConstAcom.MediaKindCode.SYBT_SNBN) != 0)
            {
                selectedHikListRows = _dsHikTrkm_All.InPutHikData.Select("", KkhConstAcom.FILTER_ORDER_RIREKI);
            }
            else
            {
                selectedHikListRows = _dsHikTrkm_All.InPutHikData_Snbn.Select("", KkhConstAcom.FILTER_ORDER_RIREKI);
            }
            dsHikTrkm_Filter.Merge(selectedHikListRows);

            // スプレッドの更新(一覧全件表示) 
            UpdateSpd_Design(dsHikTrkm_Filter);
        }

        /// <summary>
        /// スプレッドの表示更新 
        /// </summary>
        /// <param name="dsInPutHik">出力対象データセット</param>
        private void UpdateSpd_Design(InPutHik dsInPutHik)
        {

            _dsHikTrkm_SpdList.Clear();
            _dsHikTrkm_SpdList.Merge(dsInPutHik);
            _dsHikTrkm_All.AcceptChanges();
            FarPoint.Win.Spread.CellType.NumberCellType ct = new FarPoint.Win.Spread.CellType.NumberCellType();

            ct.MaximumValue =  999999999.99;
            ct.MinimumValue = -999999999.99;
           
            // バインド 
            //新聞以外の場合 
            if (KKHUtility.ToString(cbxSybtName.SelectedValue).CompareTo(KkhConstAcom.MediaKindCode.SYBT_SNBN) != 0)
            {
                spdHikTrkmList_Sheet1.DataSource = _dsHikTrkm_SpdList;
                spdHikTrkmList_Sheet1.DataMember = _dsHikTrkm_SpdList.InPutHikData.TableName;

                //スプレッド(Decimal)小数点非表示対応 
                spdHikList.Sheets[0].Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_KEISAIRYO].CellType = ct;
                spdHikList.Sheets[0].Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_KEISAITANKA].CellType = ct;
                spdHikList.Sheets[0].Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_HANSHITA].CellType = ct;
                spdHikList.Sheets[0].Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_DESIGNRYO].CellType = ct;
                spdHikList.Sheets[0].Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_SEIHAN].CellType = ct;
                spdHikList.Sheets[0].Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_SASHIKAE].CellType = ct;
                spdHikList.Sheets[0].Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_PRINT].CellType = ct;
                spdHikList.Sheets[0].Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_HOSORYO1].CellType = ct;
                spdHikList.Sheets[0].Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_HOSORYO2].CellType = ct;
                spdHikList.Sheets[0].Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_HOSORYO3].CellType = ct;
                spdHikList.Sheets[0].Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_HOSORYO4].CellType = ct;
                spdHikList.Sheets[0].Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_HOSORYO5].CellType = ct;
                spdHikList.Sheets[0].Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_HOSORYO6].CellType = ct;
                ct.DecimalPlaces = 0;
                ct.ShowSeparator = true;

                //各列のサイズを設定 
                for (int i = 0; i < spdHikTrkmList_Sheet1.Columns.Count; i++)
                {
                    spdHikTrkmList_Sheet1.Columns[i].Width = float.Parse(colCntArr[i]);
                }

                spdHikList.ActiveSheet = spdHikTrkmList_Sheet1;
                spdHikTrkmList_Sheet1.Visible = true;
                spdHikTrkmList_Sheet_Snbn.Visible = false;
            }
            //新聞の場合 
            else
            {
                spdHikTrkmList_Sheet_Snbn.DataSource = _dsHikTrkm_SpdList;
                spdHikTrkmList_Sheet_Snbn.DataMember = _dsHikTrkm_SpdList.InPutHikData_Snbn.TableName;

                //スプレッド(Decimal)小数点非表示対応 
                spdHikTrkmList_Sheet_Snbn.Columns[9].CellType = ct;  //単価 
                spdHikTrkmList_Sheet_Snbn.Columns[10].CellType = ct; //掲載料 
                spdHikTrkmList_Sheet_Snbn.Columns[28].CellType = ct; //デザイン料 
                spdHikTrkmList_Sheet_Snbn.Columns[29].CellType = ct; //版下料 
                spdHikTrkmList_Sheet_Snbn.Columns[30].CellType = ct; //製版代 
                ct.DecimalPlaces = 0;
                ct.ShowSeparator = true;

                spdHikList.ActiveSheet = spdHikTrkmList_Sheet_Snbn;
                spdHikTrkmList_Sheet1.Visible = false;
                spdHikTrkmList_Sheet_Snbn.Visible = true;

                //各列のサイズを設定 
                for (int i = 0; i < spdHikTrkmList_Sheet_Snbn.Columns.Count; i++)
                {
                    spdHikTrkmList_Sheet_Snbn.Columns[i].Width = float.Parse(colCntArrSnbn[i]);
                }

            }

            // スプレッドのタイトル更新 
            UpdateSpd_TitleList();

            // スプレッドの表示項目設定 
            if (rbnRireki.Checked == true)
            {
                // 履歴の場合は、背景色を変更 
                UpdateSpd_Design_RirekiBackColor();
            }
        }

        /// <summary>
        /// スプレッドのタイトル更新 
        /// </summary>
        private void UpdateSpd_TitleList()
        {
            string strSelectSybt = KKHUtility.ToString(cbxSybtName.SelectedValue);

            // 種別確認 
            bool isZasiVisible = false;         // 雑誌表示 
            bool isDenpVisible = false;         // 電波表示 
            bool isKotuVisible = false;         // 交通表示 
            bool isZasiOrKotuVisible = false;   // 雑誌、または交通表示 

            if (strSelectSybt.CompareTo(KkhConstAcom.MediaKindCode.SYBT_ZASI) == 0)
            {
                isZasiVisible = true;
                isZasiOrKotuVisible = true;
            }
            else if (strSelectSybt.CompareTo(KkhConstAcom.MediaKindCode.SYBT_DENP) == 0)
            {
                isDenpVisible = true;
            }
            else if (strSelectSybt.CompareTo(KkhConstAcom.MediaKindCode.SYBT_KOTU) == 0)
            {
                isKotuVisible = true;
                isZasiOrKotuVisible = true;
            }


            if (strSelectSybt.CompareTo(KkhConstAcom.MediaKindCode.SYBT_SNBN) != 0)
            {
                #region 新聞以外の場合、表示項目の設定
                // 雑誌表示項目 
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_SIZECD].Visible = isZasiVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_SIZENAME].Visible = isZasiVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_KEISAI1].Visible = isZasiVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_KEISAI2].Visible = isZasiVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_KEISAI3].Visible = isZasiVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_KEISAI4].Visible = isZasiVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_KEISAI5].Visible = isZasiVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_COLORCD].Visible = isZasiVisible;
                // 電波表示項目                             
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_KEITAICD].Visible = isDenpVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_KEITAINAME].Visible = isDenpVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_IRMONTH1].Visible = isDenpVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_HOSORYO1].Visible = isDenpVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_IRMONTH2].Visible = isDenpVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_HOSORYO2].Visible = isDenpVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_IRMONTH3].Visible = isDenpVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_HOSORYO3].Visible = isDenpVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_IRMONTH4].Visible = isDenpVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_HOSORYO4].Visible = isDenpVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_IRMONTH5].Visible = isDenpVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_HOSORYO5].Visible = isDenpVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_IRMONTH6].Visible = isDenpVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_HOSORYO6].Visible = isDenpVisible;
                // 交通表示項目 
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_KOUTUKEICD].Visible = isKotuVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_KOUTUKEINAME].Visible = isKotuVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_KEISAI].Visible = isKotuVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_PRINT].Visible = isKotuVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_SASHIKAE].Visible = isKotuVisible;
                // 雑誌or交通表示項目                       
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_KEISAIRYO].Visible = isZasiOrKotuVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_KEISAITANKA].Visible = isZasiOrKotuVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_KEISAICNT].Visible = isZasiOrKotuVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_DESIGNCNT].Visible = isZasiOrKotuVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_DESIGNRYO].Visible = isZasiOrKotuVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_HANSHITA].Visible = isZasiOrKotuVisible;
                spdHikList.ActiveSheet.ColumnHeader.Columns[KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_SEIHAN].Visible = isZasiOrKotuVisible;

                #endregion
            }
        }

        /// <summary>
        ///  スプレッドの履歴背景色更新 
        /// </summary>
        private void UpdateSpd_Design_RirekiBackColor()
        {
            SheetView svSpd = spdHikList.ActiveSheet;
            int iSpdIrBan = 0;
            int iSpdIrRowBan = 0;

            if (KKHUtility.ToString(cbxSybtName.SelectedValue) != KkhConstAcom.MediaKindCode.SYBT_SNBN)
            {
                iSpdIrBan = KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_IRBAN;
                iSpdIrRowBan = KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_IRROWBAN;
            }
            else
            {
                iSpdIrBan = KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_SNBN_IRBAN;
                iSpdIrRowBan = KkhConstAcom.SpreadColumunsNo.SPD_COLUMUNS_SNBN_IRROWBAN;
            }

            // 明細行-1行ループ 
            for (int rowIndex = 0; rowIndex + 1 < svSpd.Rows.Count; rowIndex++)
            {
                // 現在行の比較値を取得 
                Row row_Now = svSpd.Rows[rowIndex];

                // 発注番号・発注行番号 
                Cell cellIrBan_Now = svSpd.Cells[rowIndex, iSpdIrBan];
                Cell cellIrRowBan_Now = svSpd.Cells[rowIndex, iSpdIrRowBan];

                // 次の行の比較値を取得 
                Row row_Next = svSpd.Rows[rowIndex + 1];
                Cell cellIrBan_Next = svSpd.Cells[rowIndex + 1, iSpdIrBan];
                Cell cellIrRowBan_Next = svSpd.Cells[rowIndex + 1, iSpdIrRowBan];

                // 発注番号が次の行と同じか確認 
                if (cellIrBan_Now.Text == cellIrBan_Next.Text)
                {
                    // 発注行番号が次の行と同じか確認 
                    if (cellIrRowBan_Now.Text == cellIrRowBan_Next.Text)
                    {
                        // 相違点の確認(更新区分は対象外の為、1から開始) 
                        for (int columnIndex = 1; columnIndex < svSpd.Columns.Count; columnIndex++)
                        {
                            // 現在行 
                            Cell cell_Now = svSpd.Cells[rowIndex, columnIndex];

                            // 次の行 
                            Cell cell_Next = svSpd.Cells[rowIndex + 1, columnIndex];

                            if (cell_Now.Text != cell_Next.Text)
                            {
                                // 背景色を設定 
                                cell_Now.BackColor = KKHSystemColor.AcomFormColor.RirekiCngBackColor;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ファイル長チェックメソッド 
        /// </summary>
        /// <param name="strSybt">媒体種別</param>
        /// <param name="fileData">チェック対象データ</param>
        /// <returns></returns>
        private bool CheckFileLength(string strSybt, string fileData)
        {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

            if (strSybt.CompareTo(KkhConstAcom.MediaKindCode.SYBT_ZASI) == 0)
            {
                // 雑誌の場合の長さ確認 
                if (sjisEnc.GetByteCount(fileData) != KkhConstAcom.MediaByFileSize.FILEIMP_ZASI_LENGTH)
                {
                    return false;
                }
            }
            else if (strSybt.CompareTo(KkhConstAcom.MediaKindCode.SYBT_DENP) == 0)
            {
                // 電波の場合の長さ確認 
                if (sjisEnc.GetByteCount(fileData) != KkhConstAcom.MediaByFileSize.FILEIMP_DENP_LENGTH)
                {
                    return false;
                }
            }
            else if (strSybt.CompareTo(KkhConstAcom.MediaKindCode.SYBT_KOTU) == 0)
            {
                // 交通の場合の長さ確認 
                if (sjisEnc.GetByteCount(fileData) != KkhConstAcom.MediaByFileSize.FILEIMP_KOTU_LENGTH)
                {
                    return false;
                }
            }
            else if (strSybt.CompareTo(KkhConstAcom.MediaKindCode.SYBT_SNBN) == 0)
            {
                // 新聞の場合の長さ確認 
                if (sjisEnc.GetByteCount(fileData) != KkhConstAcom.MediaByFileSize.FILEIMP_SNBN_LENGTH)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 発注読込ファイルデータ設定メソッド 
        /// </summary>
        /// <param name="targetDS">読込データ格納用DataSet</param>
        /// <param name="fileData">読み込み(項目ごと分割)対象データ</param>
        /// <param name="fileImpAddCnt">格納用データセット添え字</param>
        private void SetFileImpTemp_FileData(InPutHik targetDS, string fileData, int fileImpAddCnt)
        {
            // レコードの追加.
            targetDS.FileImpTemp.AddFileImpTempRow(targetDS.FileImpTemp.NewFileImpTempRow());

            // 共通項目の読み込み.
            targetDS.FileImpTemp[fileImpAddCnt].Column1  = MidB(fileData, 0, 8);        //発注番号 
            targetDS.FileImpTemp[fileImpAddCnt].Column2  = MidB(fileData, 8, 2);        //依頼区分 
            targetDS.FileImpTemp[fileImpAddCnt].Column3  = MidB(fileData, 10, 6);       //依頼月 
            targetDS.FileImpTemp[fileImpAddCnt].Column4  = MidB(fileData, 16, 6);       //売上予定年月 
            targetDS.FileImpTemp[fileImpAddCnt].Column5  = MidB(fileData, 22, 4);       //得意先コード 
            targetDS.FileImpTemp[fileImpAddCnt].Column6  = MidB(fileData, 26, 5);       //営業部コード 
            targetDS.FileImpTemp[fileImpAddCnt].Column7  = MidB(fileData, 31, 50);      //営業部名 
            targetDS.FileImpTemp[fileImpAddCnt].Column8  = MidB(fileData, 81, 5);       //店番 
            targetDS.FileImpTemp[fileImpAddCnt].Column9  = MidB(fileData, 86, 50);      //店名 
            targetDS.FileImpTemp[fileImpAddCnt].Column10 = MidB(fileData, 136, 2);      //商品区分 
            targetDS.FileImpTemp[fileImpAddCnt].Column11 = MidB(fileData, 138, 1);      //細目区分 
            targetDS.FileImpTemp[fileImpAddCnt].Column12 = MidB(fileData, 139, 5);      //摘要コード 
            targetDS.FileImpTemp[fileImpAddCnt].Column13 = MidB(fileData, 144, 30);     //摘要名 
            targetDS.FileImpTemp[fileImpAddCnt].Column14 = MidB(fileData, 174, 2);      //媒体コード 
            targetDS.FileImpTemp[fileImpAddCnt].Column15 = MidB(fileData, 176, 10);     //媒体名 
            targetDS.FileImpTemp[fileImpAddCnt].Column16 = MidB(fileData, 186, 6);      //メディアコード 
            targetDS.FileImpTemp[fileImpAddCnt].Column17 = MidB(fileData, 192, 40);     //メディア名 
            targetDS.FileImpTemp[fileImpAddCnt].Column18 = MidB(fileData, 232, 3);      //依頼内容 
            targetDS.FileImpTemp[fileImpAddCnt].Column19 = MidB(fileData, 235, 3);      //行番号 
            targetDS.FileImpTemp[fileImpAddCnt].Column20 = MidB(fileData, 238, 20);     //担当者名 
            targetDS.FileImpTemp[fileImpAddCnt].Column21 = MidB(fileData, 258, 20);     //担当者勤務部署名 
            targetDS.FileImpTemp[fileImpAddCnt].Column22 = MidB(fileData, 278, 1);      //予算区分 
            targetDS.FileImpTemp[fileImpAddCnt].Column23 = MidB(fileData, 279, 1);      //按分種別 
            targetDS.FileImpTemp[fileImpAddCnt].Column24 = MidB(fileData, 280, 50);     //備考1 
            targetDS.FileImpTemp[fileImpAddCnt].Column25 = MidB(fileData, 330, 50);     //備考2 

            //雑誌. 
            if (KKHUtility.ToString(cbxSybtName.SelectedValue).CompareTo(KkhConstAcom.MediaKindCode.SYBT_ZASI) == 0)
            {
                targetDS.FileImpTemp[fileImpAddCnt].Column26 = MidB(fileData, 380, 30); //掲載場所名 
                targetDS.FileImpTemp[fileImpAddCnt].Column27 = MidB(fileData, 410, 2);  //色印コード 
                targetDS.FileImpTemp[fileImpAddCnt].Column28 = MidB(fileData, 412, 2);  //サイズコード 
                targetDS.FileImpTemp[fileImpAddCnt].Column29 = MidB(fileData, 414, 30); //サイズ名 
                targetDS.FileImpTemp[fileImpAddCnt].Column30 = MidB(fileData, 444, 8);  //発売日1 
                targetDS.FileImpTemp[fileImpAddCnt].Column31 = MidB(fileData, 452, 8);  //発売日2 
                targetDS.FileImpTemp[fileImpAddCnt].Column32 = MidB(fileData, 460, 8);  //発売日3 
                targetDS.FileImpTemp[fileImpAddCnt].Column33 = MidB(fileData, 468, 8);  //発売日4 
                targetDS.FileImpTemp[fileImpAddCnt].Column34 = MidB(fileData, 476, 8);  //発売日5 
                targetDS.FileImpTemp[fileImpAddCnt].Column35 = MidB(fileData, 484, 1);  //掲載回数 
                targetDS.FileImpTemp[fileImpAddCnt].Column36 = MidB(fileData, 485, 11); //掲載単価 
                targetDS.FileImpTemp[fileImpAddCnt].Column37 = MidB(fileData, 496, 9);  //掲載料 
                targetDS.FileImpTemp[fileImpAddCnt].Column38 = MidB(fileData, 505, 2);  //デザイン変更回数 
                targetDS.FileImpTemp[fileImpAddCnt].Column39 = MidB(fileData, 507, 9);  //デザイン料 
                targetDS.FileImpTemp[fileImpAddCnt].Column40 = MidB(fileData, 516, 9);  //版下代 
                targetDS.FileImpTemp[fileImpAddCnt].Column41 = MidB(fileData, 525, 9);  //製版代 
                targetDS.FileImpTemp[fileImpAddCnt].Column42 = MidB(fileData, 534, 8);  //登録年月日 
                targetDS.FileImpTemp[fileImpAddCnt].Column43 = MidB(fileData, 542, 8);  //変更年月日 
                targetDS.FileImpTemp[fileImpAddCnt].Column44 = MidB(fileData, 550, 8);  //取消年月日 
            }
            //電波.
            else if (KKHUtility.ToString(cbxSybtName.SelectedValue).CompareTo(KkhConstAcom.MediaKindCode.SYBT_DENP) == 0)
            {
                targetDS.FileImpTemp[fileImpAddCnt].Column26 = MidB(fileData, 380, 2);  //形態区分 
                targetDS.FileImpTemp[fileImpAddCnt].Column27 = MidB(fileData, 382, 10); //形態区分名 
                targetDS.FileImpTemp[fileImpAddCnt].Column28 = MidB(fileData, 392, 6);  //依頼月1 
                targetDS.FileImpTemp[fileImpAddCnt].Column29 = MidB(fileData, 398, 9);  //放送料1 
                targetDS.FileImpTemp[fileImpAddCnt].Column30 = MidB(fileData, 407, 6);  //依頼月2 
                targetDS.FileImpTemp[fileImpAddCnt].Column31 = MidB(fileData, 413, 9);  //放送料2 
                targetDS.FileImpTemp[fileImpAddCnt].Column32 = MidB(fileData, 422, 6);  //依頼月3 
                targetDS.FileImpTemp[fileImpAddCnt].Column33 = MidB(fileData, 428, 9);  //放送料3 
                targetDS.FileImpTemp[fileImpAddCnt].Column34 = MidB(fileData, 437, 6);  //依頼月4 
                targetDS.FileImpTemp[fileImpAddCnt].Column35 = MidB(fileData, 443, 9);  //放送料4 
                targetDS.FileImpTemp[fileImpAddCnt].Column36 = MidB(fileData, 452, 6);  //依頼月5 
                targetDS.FileImpTemp[fileImpAddCnt].Column37 = MidB(fileData, 458, 9);  //放送料5 
                targetDS.FileImpTemp[fileImpAddCnt].Column38 = MidB(fileData, 467, 6);  //依頼月6 
                targetDS.FileImpTemp[fileImpAddCnt].Column39 = MidB(fileData, 473, 9);  //放送料6 
                targetDS.FileImpTemp[fileImpAddCnt].Column40 = MidB(fileData, 482, 8);  //登録年月日 
                targetDS.FileImpTemp[fileImpAddCnt].Column41 = MidB(fileData, 490, 8);  //変更年月日 
                targetDS.FileImpTemp[fileImpAddCnt].Column42 = MidB(fileData, 498, 8);  //取消年月日 
            }
            //交通.
            else if (KKHUtility.ToString(cbxSybtName.SelectedValue).CompareTo(KkhConstAcom.MediaKindCode.SYBT_KOTU) == 0)
            {
                targetDS.FileImpTemp[fileImpAddCnt].Column26 = MidB(fileData, 380, 2);  //種類コード 
                targetDS.FileImpTemp[fileImpAddCnt].Column27 = MidB(fileData, 382, 30); //サイズ名 
                targetDS.FileImpTemp[fileImpAddCnt].Column28 = MidB(fileData, 412, 20); //掲載日 
                targetDS.FileImpTemp[fileImpAddCnt].Column29 = MidB(fileData, 432, 2);  //掲載回数 
                targetDS.FileImpTemp[fileImpAddCnt].Column30 = MidB(fileData, 434, 11); //掲載単価 
                targetDS.FileImpTemp[fileImpAddCnt].Column31 = MidB(fileData, 445, 9);  //掲載料 
                targetDS.FileImpTemp[fileImpAddCnt].Column32 = MidB(fileData, 454, 11); //印刷単価 
                targetDS.FileImpTemp[fileImpAddCnt].Column33 = MidB(fileData, 465, 9);  //印刷部数 
                targetDS.FileImpTemp[fileImpAddCnt].Column34 = MidB(fileData, 474, 9);  //印刷代 
                targetDS.FileImpTemp[fileImpAddCnt].Column35 = MidB(fileData, 483, 9);  //差替作業料 
                targetDS.FileImpTemp[fileImpAddCnt].Column36 = MidB(fileData, 492, 2);  //デザイン変更回数 
                targetDS.FileImpTemp[fileImpAddCnt].Column37 = MidB(fileData, 494, 9);  //デザイン料 
                targetDS.FileImpTemp[fileImpAddCnt].Column38 = MidB(fileData, 503, 9);  //版下代 
                targetDS.FileImpTemp[fileImpAddCnt].Column39 = MidB(fileData, 512, 9);  //製版代 
                targetDS.FileImpTemp[fileImpAddCnt].Column40 = MidB(fileData, 521, 8);  //登録年月日 
                targetDS.FileImpTemp[fileImpAddCnt].Column41 = MidB(fileData, 529, 8);  //変更年月日 
                targetDS.FileImpTemp[fileImpAddCnt].Column42 = MidB(fileData, 537, 8);  //取消年月日 
            }
            //新聞.
            else if (KKHUtility.ToString(cbxSybtName.SelectedValue).CompareTo(KkhConstAcom.MediaKindCode.SYBT_SNBN) == 0)
            {
                targetDS.FileImpTemp[fileImpAddCnt].Column26 = MidB(fileData, 380, 2);  //掲載場所コード 
                targetDS.FileImpTemp[fileImpAddCnt].Column27 = MidB(fileData, 382, 2);  //種別1コード 
                targetDS.FileImpTemp[fileImpAddCnt].Column28 = MidB(fileData, 384, 2);  //種別2コード 
                targetDS.FileImpTemp[fileImpAddCnt].Column29 = MidB(fileData, 386, 2);  //色刷コード 
                targetDS.FileImpTemp[fileImpAddCnt].Column30 = MidB(fileData, 388, 2);  //サイズコード 
                targetDS.FileImpTemp[fileImpAddCnt].Column31 = MidB(fileData, 390, 30); //サイズ名 
                targetDS.FileImpTemp[fileImpAddCnt].Column32 = MidB(fileData, 420, 31); //掲載日 
                targetDS.FileImpTemp[fileImpAddCnt].Column33 = MidB(fileData, 451, 2);  //掲載回数 
                targetDS.FileImpTemp[fileImpAddCnt].Column34 = MidB(fileData, 453, 11); //掲載単価 
                targetDS.FileImpTemp[fileImpAddCnt].Column35 = MidB(fileData, 464, 9);  //掲載料 
                targetDS.FileImpTemp[fileImpAddCnt].Column36 = MidB(fileData, 473, 2);  //デザイン変更回数 
                targetDS.FileImpTemp[fileImpAddCnt].Column37 = MidB(fileData, 475, 9);  //デザイン料 
                targetDS.FileImpTemp[fileImpAddCnt].Column38 = MidB(fileData, 484, 9);  //版下代 
                targetDS.FileImpTemp[fileImpAddCnt].Column39 = MidB(fileData, 493, 9);  //製版代 
                targetDS.FileImpTemp[fileImpAddCnt].Column40 = MidB(fileData, 502, 8);  //登録年月日 
                targetDS.FileImpTemp[fileImpAddCnt].Column41 = MidB(fileData, 510, 8);  //変更年月日 
                targetDS.FileImpTemp[fileImpAddCnt].Column42 = MidB(fileData, 518, 8);  //取消年月日 
            }
        }

        /// <summary>
        /// ワークからインポート用に移し替える
        /// </summary>
        /// <param name="targetDS"></param>
        /// <param name="fileImpAddCnt"></param>
        private void SetFileImp_FileData(InPutHik targetDS, int fileImpAddCnt)
        {
            // 配列に初期値セット 
            SetFileImp_Init(targetDS);
            //targetDS.FileImp.AddFileImpRow(targetDS.FileImp.NewFileImpRow());

            ////共通部  
            targetDS.FileImp[fileImpAddCnt].IrBan       = targetDS.FileImpTemp[fileImpAddCnt].Column1;  //発注番号 
            targetDS.FileImp[fileImpAddCnt].IrKbn       = targetDS.FileImpTemp[fileImpAddCnt].Column2;  //依頼区分 
            targetDS.FileImp[fileImpAddCnt].IrYyMm      = targetDS.FileImpTemp[fileImpAddCnt].Column3;  //依頼月 
            targetDS.FileImp[fileImpAddCnt].UriYyMm     = targetDS.FileImpTemp[fileImpAddCnt].Column4;  //売上予定年月 
            targetDS.FileImp[fileImpAddCnt].TokuiCd     = targetDS.FileImpTemp[fileImpAddCnt].Column5;  //得意先コード 
            targetDS.FileImp[fileImpAddCnt].EiCode      = targetDS.FileImpTemp[fileImpAddCnt].Column6;  //営業部コード 
            targetDS.FileImp[fileImpAddCnt].EiName      = targetDS.FileImpTemp[fileImpAddCnt].Column7;  //営業部名 
            targetDS.FileImp[fileImpAddCnt].TenCd       = targetDS.FileImpTemp[fileImpAddCnt].Column8;  //店番 
            targetDS.FileImp[fileImpAddCnt].TenName     = targetDS.FileImpTemp[fileImpAddCnt].Column9;  //店名 
            targetDS.FileImp[fileImpAddCnt].SyohiKbn    = targetDS.FileImpTemp[fileImpAddCnt].Column10; //商品区分 
            targetDS.FileImp[fileImpAddCnt].SaiKbn      = targetDS.FileImpTemp[fileImpAddCnt].Column11; //細目区分 
            targetDS.FileImp[fileImpAddCnt].TekiCd      = targetDS.FileImpTemp[fileImpAddCnt].Column12; //摘要コード 
            //targetDS.FileImp[fileImpAddCnt].TekiName  = targetDS.FileImpTemp[fileImpAddCnt].Column13; //摘要名 
            //targetDS.FileImp[fileImpAddCnt].          = targetDS.FileImpTemp[fileImpAddCnt].Column14; //媒体コード 
            //targetDS.FileImp[fileImpAddCnt].          = targetDS.FileImpTemp[fileImpAddCnt].Column15; //媒体名 
            targetDS.FileImp[fileImpAddCnt].MediaCd     = targetDS.FileImpTemp[fileImpAddCnt].Column16; //メディアコード 
            targetDS.FileImp[fileImpAddCnt].MediaName   = targetDS.FileImpTemp[fileImpAddCnt].Column17; //メディア名 
            targetDS.FileImp[fileImpAddCnt].IrNai       = targetDS.FileImpTemp[fileImpAddCnt].Column18; //依頼内容 
            targetDS.FileImp[fileImpAddCnt].IrRowBan    = targetDS.FileImpTemp[fileImpAddCnt].Column19; //行番号 
            targetDS.FileImp[fileImpAddCnt].TanName     = targetDS.FileImpTemp[fileImpAddCnt].Column20; //担当者名 
            targetDS.FileImp[fileImpAddCnt].TanKinName  = targetDS.FileImpTemp[fileImpAddCnt].Column21; //担当者勤務部署名 
            targetDS.FileImp[fileImpAddCnt].YosaKbn     = targetDS.FileImpTemp[fileImpAddCnt].Column22; //予算区分 
            targetDS.FileImp[fileImpAddCnt].AnSyube     = targetDS.FileImpTemp[fileImpAddCnt].Column23; //按分種別 
            targetDS.FileImp[fileImpAddCnt].Bikou1      = targetDS.FileImpTemp[fileImpAddCnt].Column24; //備考1 
            targetDS.FileImp[fileImpAddCnt].Bikou2      = targetDS.FileImpTemp[fileImpAddCnt].Column25; //備考2 
            targetDS.FileImp[fileImpAddCnt].RecCd       = KkhConstAcom.REC_CD;                          //レコード種別 

            //雑誌.
            if (KKHUtility.ToString(cbxSybtName.SelectedValue).CompareTo(KkhConstAcom.MediaKindCode.SYBT_ZASI) == 0)
            {
                targetDS.FileImp[fileImpAddCnt].Sybt        = KkhConstAcom.MediaKindCode.SYBT_ZASI;                                 //媒体コード 

                //targetDS.FileImp[fileImpAddCnt].KeiName   = targetDS.FileImpTemp[fileImpAddCnt].Column26;                         //掲載場所名 
                targetDS.FileImp[fileImpAddCnt].ColorCd     = targetDS.FileImpTemp[fileImpAddCnt].Column27;                         //色印コード 
                targetDS.FileImp[fileImpAddCnt].SizeCd      = targetDS.FileImpTemp[fileImpAddCnt].Column28;                         //サイズコード 
                targetDS.FileImp[fileImpAddCnt].SizeName    = targetDS.FileImpTemp[fileImpAddCnt].Column29;                         //サイズ名 
                targetDS.FileImp[fileImpAddCnt].Keisai1     = targetDS.FileImpTemp[fileImpAddCnt].Column30;                         //発売日1 
                targetDS.FileImp[fileImpAddCnt].Keisai2     = targetDS.FileImpTemp[fileImpAddCnt].Column31;                         //発売日2 
                targetDS.FileImp[fileImpAddCnt].Keisai3     = targetDS.FileImpTemp[fileImpAddCnt].Column32;                         //発売日3 
                targetDS.FileImp[fileImpAddCnt].Keisai4     = targetDS.FileImpTemp[fileImpAddCnt].Column33;                         //発売日4 
                targetDS.FileImp[fileImpAddCnt].Keisai5     = targetDS.FileImpTemp[fileImpAddCnt].Column34;                         //発売日5 
                targetDS.FileImp[fileImpAddCnt].KeisaiCnt   = targetDS.FileImpTemp[fileImpAddCnt].Column35;                         //掲載回数 
                targetDS.FileImp[fileImpAddCnt].KeisaiTanka = targetDS.FileImpTemp[fileImpAddCnt].Column36;                         //掲載単価 
                targetDS.FileImp[fileImpAddCnt].KeisaiRyo   = KKHUtility.DecParse(targetDS.FileImpTemp[fileImpAddCnt].Column37);    //掲載料 
                targetDS.FileImp[fileImpAddCnt].DesignCnt   = targetDS.FileImpTemp[fileImpAddCnt].Column38;                         //デザイン変更回数 
                targetDS.FileImp[fileImpAddCnt].DesignRyo   = KKHUtility.DecParse(targetDS.FileImpTemp[fileImpAddCnt].Column39);    //デザイン料 
                targetDS.FileImp[fileImpAddCnt].HanShitaRyo = KKHUtility.DecParse(targetDS.FileImpTemp[fileImpAddCnt].Column40);    //版下代 
                targetDS.FileImp[fileImpAddCnt].SeiHanRyo   = KKHUtility.DecParse(targetDS.FileImpTemp[fileImpAddCnt].Column41);    //製版代 
                targetDS.FileImp[fileImpAddCnt].TouDate     = targetDS.FileImpTemp[fileImpAddCnt].Column42;                         //登録年月日 
                targetDS.FileImp[fileImpAddCnt].HenDate     = targetDS.FileImpTemp[fileImpAddCnt].Column43;                         //変更年月日 
                targetDS.FileImp[fileImpAddCnt].TorDate     = targetDS.FileImpTemp[fileImpAddCnt].Column44;                         //取消年月日 
            }                                                                                     
            //電波.
            else if (KKHUtility.ToString(cbxSybtName.SelectedValue).CompareTo(KkhConstAcom.MediaKindCode.SYBT_DENP) == 0)
            {
                targetDS.FileImp[fileImpAddCnt].Sybt        = KkhConstAcom.MediaKindCode.SYBT_DENP;                                 //媒体コード 

                targetDS.FileImp[fileImpAddCnt].KeitaiCd    = targetDS.FileImpTemp[fileImpAddCnt].Column26;                         //形態区分 
                targetDS.FileImp[fileImpAddCnt].KeitaiName  = targetDS.FileImpTemp[fileImpAddCnt].Column27;                         //形態区分名 
                targetDS.FileImp[fileImpAddCnt].IrMonth1    = targetDS.FileImpTemp[fileImpAddCnt].Column28;                         //依頼月1 
                targetDS.FileImp[fileImpAddCnt].HosoRyo1    = KKHUtility.DecParse(targetDS.FileImpTemp[fileImpAddCnt].Column29);    //放送料1 
                targetDS.FileImp[fileImpAddCnt].IrMonth2    = targetDS.FileImpTemp[fileImpAddCnt].Column30;                         //依頼月2 
                targetDS.FileImp[fileImpAddCnt].HosoRyo2    = KKHUtility.DecParse(targetDS.FileImpTemp[fileImpAddCnt].Column31);    //放送料2 
                targetDS.FileImp[fileImpAddCnt].IrMonth3    = targetDS.FileImpTemp[fileImpAddCnt].Column32;                         //依頼月3 
                targetDS.FileImp[fileImpAddCnt].HosoRyo3    = KKHUtility.DecParse(targetDS.FileImpTemp[fileImpAddCnt].Column33);    //放送料3 
                targetDS.FileImp[fileImpAddCnt].IrMonth4    = targetDS.FileImpTemp[fileImpAddCnt].Column34;                         //依頼月4 
                targetDS.FileImp[fileImpAddCnt].HosoRyo4    = KKHUtility.DecParse(targetDS.FileImpTemp[fileImpAddCnt].Column35);    //放送料4 
                targetDS.FileImp[fileImpAddCnt].IrMonth5    = targetDS.FileImpTemp[fileImpAddCnt].Column36;                         //依頼月5 
                targetDS.FileImp[fileImpAddCnt].HosoRyo5    = KKHUtility.DecParse(targetDS.FileImpTemp[fileImpAddCnt].Column37);    //放送料5 
                targetDS.FileImp[fileImpAddCnt].IrMonth6    = targetDS.FileImpTemp[fileImpAddCnt].Column38;                         //依頼月6 
                targetDS.FileImp[fileImpAddCnt].HosoRyo6    = KKHUtility.DecParse(targetDS.FileImpTemp[fileImpAddCnt].Column39);    //放送料6 
                targetDS.FileImp[fileImpAddCnt].TouDate     = targetDS.FileImpTemp[fileImpAddCnt].Column40;                         //登録年月日 
                targetDS.FileImp[fileImpAddCnt].HenDate     = targetDS.FileImpTemp[fileImpAddCnt].Column41;                         //変更年月日 
                targetDS.FileImp[fileImpAddCnt].TorDate     = targetDS.FileImpTemp[fileImpAddCnt].Column42;                         //取消年月日 
            }                                                                                      
            //交通.
            else if (KKHUtility.ToString(cbxSybtName.SelectedValue).CompareTo(KkhConstAcom.MediaKindCode.SYBT_KOTU) == 0)
            {
                targetDS.FileImp[fileImpAddCnt].Sybt        = KkhConstAcom.MediaKindCode.SYBT_KOTU;                                 //媒体コード 

                targetDS.FileImp[fileImpAddCnt].KotuKeiCd   = targetDS.FileImpTemp[fileImpAddCnt].Column26;                         //種類コード 
                targetDS.FileImp[fileImpAddCnt].KotuKeiName = targetDS.FileImpTemp[fileImpAddCnt].Column27;                         //サイズ名 
                targetDS.FileImp[fileImpAddCnt].Keisai      = targetDS.FileImpTemp[fileImpAddCnt].Column28;                         //掲載日 
                targetDS.FileImp[fileImpAddCnt].KeisaiCnt   = targetDS.FileImpTemp[fileImpAddCnt].Column29;                         //掲載回数 
                targetDS.FileImp[fileImpAddCnt].KeisaiTanka = targetDS.FileImpTemp[fileImpAddCnt].Column30;                         //掲載単価 
                targetDS.FileImp[fileImpAddCnt].KeisaiRyo   = KKHUtility.DecParse(targetDS.FileImpTemp[fileImpAddCnt].Column31);    //掲載料 
                //targetDS.FileImp[fileImpAddCnt].          = targetDS.FileImpTemp[fileImpAddCnt].Column32;                         //印刷単価 
                //targetDS.FileImp[fileImpAddCnt].          = targetDS.FileImpTemp[fileImpAddCnt].Column33;                         //印刷部数 
                targetDS.FileImp[fileImpAddCnt].PrintRyo    = KKHUtility.DecParse(targetDS.FileImpTemp[fileImpAddCnt].Column34);    //印刷代 
                targetDS.FileImp[fileImpAddCnt].SashikaeRyo = KKHUtility.DecParse(targetDS.FileImpTemp[fileImpAddCnt].Column35);    //差替作業料 
                targetDS.FileImp[fileImpAddCnt].DesignCnt   = targetDS.FileImpTemp[fileImpAddCnt].Column36;                         //デザイン変更回数 
                targetDS.FileImp[fileImpAddCnt].DesignRyo   = KKHUtility.DecParse(targetDS.FileImpTemp[fileImpAddCnt].Column37);    //デザイン料 
                targetDS.FileImp[fileImpAddCnt].HanShitaRyo = KKHUtility.DecParse(targetDS.FileImpTemp[fileImpAddCnt].Column38);    //版下代 
                targetDS.FileImp[fileImpAddCnt].SeiHanRyo   = KKHUtility.DecParse(targetDS.FileImpTemp[fileImpAddCnt].Column39);    //製版代 
                targetDS.FileImp[fileImpAddCnt].TouDate     = targetDS.FileImpTemp[fileImpAddCnt].Column40;                         //登録年月日 
                targetDS.FileImp[fileImpAddCnt].HenDate     = targetDS.FileImpTemp[fileImpAddCnt].Column41;                         //変更年月日 
                targetDS.FileImp[fileImpAddCnt].TorDate     = targetDS.FileImpTemp[fileImpAddCnt].Column42;                         //取消年月日 
            }
            //新聞.
            else if (KKHUtility.ToString(cbxSybtName.SelectedValue).CompareTo(KkhConstAcom.MediaKindCode.SYBT_SNBN) == 0)
            {
                targetDS.FileImp[fileImpAddCnt].Sybt        = KkhConstAcom.MediaKindCode.SYBT_SNBN;                                 //媒体コード 

                targetDS.FileImp[fileImpAddCnt].PlaceCd     = targetDS.FileImpTemp[fileImpAddCnt].Column26;                         //掲載場所コード 
                targetDS.FileImp[fileImpAddCnt].Sybt1Cd     = targetDS.FileImpTemp[fileImpAddCnt].Column27;                         //種別1コード 
                targetDS.FileImp[fileImpAddCnt].Sybt2Cd     = targetDS.FileImpTemp[fileImpAddCnt].Column28;                         //種別2コード 
                targetDS.FileImp[fileImpAddCnt].ColorCd     = targetDS.FileImpTemp[fileImpAddCnt].Column29;                         //色刷コード 
                targetDS.FileImp[fileImpAddCnt].SpaceCd     = targetDS.FileImpTemp[fileImpAddCnt].Column30;                         //サイズコード 
                targetDS.FileImp[fileImpAddCnt].SpaceName   = targetDS.FileImpTemp[fileImpAddCnt].Column31;                         //サイズ名 
                targetDS.FileImp[fileImpAddCnt].Keisai      = targetDS.FileImpTemp[fileImpAddCnt].Column32;                         //掲載日 
                targetDS.FileImp[fileImpAddCnt].KeisaiCnt   = targetDS.FileImpTemp[fileImpAddCnt].Column33;                         //掲載回数 
                targetDS.FileImp[fileImpAddCnt].KeisaiTanka = targetDS.FileImpTemp[fileImpAddCnt].Column34;                         //掲載単価 
                targetDS.FileImp[fileImpAddCnt].KeisaiRyo   = KKHUtility.DecParse(targetDS.FileImpTemp[fileImpAddCnt].Column35);    //掲載料 
                targetDS.FileImp[fileImpAddCnt].DesignCnt   = targetDS.FileImpTemp[fileImpAddCnt].Column36;                         //デザイン変更回数 
                targetDS.FileImp[fileImpAddCnt].DesignRyo   = KKHUtility.DecParse(targetDS.FileImpTemp[fileImpAddCnt].Column37);    //デザイン料 
                targetDS.FileImp[fileImpAddCnt].HanShitaRyo = KKHUtility.DecParse(targetDS.FileImpTemp[fileImpAddCnt].Column38);    //版下代 
                targetDS.FileImp[fileImpAddCnt].SeiHanRyo   = KKHUtility.DecParse(targetDS.FileImpTemp[fileImpAddCnt].Column39);    //製版代 
                targetDS.FileImp[fileImpAddCnt].TouDate     = targetDS.FileImpTemp[fileImpAddCnt].Column40;                         //登録年月日 
                targetDS.FileImp[fileImpAddCnt].HenDate     = targetDS.FileImpTemp[fileImpAddCnt].Column41;                         //変更年月日 
                targetDS.FileImp[fileImpAddCnt].TorDate     = targetDS.FileImpTemp[fileImpAddCnt].Column42;                         //取消年月日 
            }
        }

        /// <summary>
        /// ファイル取得列の初期値設定 
        /// </summary>
        /// <param name="targetDS">初期設定対象データ</param>
        private void SetFileImp_Init(InPutHik targetDS)
        {
            InPutHik.FileImpRow rowFileImp = targetDS.FileImp.NewFileImpRow();

            for (int i = 0; i < targetDS.FileImp.Columns.Count; i++)
            {
                DataColumn dataColumn = targetDS.FileImp.Columns[i];

                if (dataColumn.DataType.Name.Equals("String"))
                {
                    rowFileImp[i] = " ";
                }
                else if (dataColumn.DataType.Name.Equals("Decimal"))
                {
                    rowFileImp[i] = 0;
                }
            }

            targetDS.FileImp.AddFileImpRow(rowFileImp);
        }

        /// <summary>
        /// 属性チェックメソッド 
        /// </summary>
        /// <param name="rowTarget">チェック対象データ</param>
        /// <param name="sybt">媒体種別</param>
        /// <param name="RowCnt">行数</param>
        /// <param name="strErrorMsg">エラー時に出力するエラーメッセージ</param>
        /// <returns>True:正常 False：異常</returns>
        private bool CheckAttribute(InPutHik.FileImpTempRow rowTarget, string sybt, int RowCnt, ref string strErrorMsg)
        {
            int column = 0;

            String message = String.Empty;

            int i_max = 0;

            if (sybt == KkhConstAcom.MediaKindCode.SYBT_SNBN)
            {
                i_max = IMPORT_COLUMN_COUNT_SNBN;
            }
            else if (sybt == KkhConstAcom.MediaKindCode.SYBT_ZASI)
            {
                i_max = IMPORT_COLUMN_COUNT_ZASI;
            }
            else if (sybt == KkhConstAcom.MediaKindCode.SYBT_DENP)
            {
                i_max = IMPORT_COLUMN_COUNT_DENP;
            }
            else if (sybt == KkhConstAcom.MediaKindCode.SYBT_KOTU)
            {
                i_max = IMPORT_COLUMN_COUNT_KOTU;
            }

            // 属性チェック処理.
            for (int i = 0; i < i_max; i++)
            {
                // 半角チェック対象.
                if (isHnkkCheckTarget(sybt, i))
                {
                    if (checkHnkk(rowTarget[i].ToString(), out message))
                    {
                        column = i;
                        break;
                    }
                }
                // 全角チェック対象.
                else if (isZnkkCheckTarget(sybt, i))
                {
                    if (checkZnkk(rowTarget[i].ToString(), out message))
                    {
                        column = i;
                        break;
                    }
                }
                // 数値チェック対象.
                else if (isSuCheckTarget(sybt, i))
                {
                    if (checkSu(rowTarget[i].ToString(), out message))
                    {
                        column = i;
                        break;
                    }
                }
            }

            // エラーが起きていたらメッセージを出力する
            if (!String.IsNullOrEmpty(message))
            {
                strErrorMsg = "データの属性が一致しません。" + "\r\n\r\n" + "行番号： " + ( RowCnt + 1 ) + "\r\n" + "項目番号: " + ( column + 1 ) + "\r\n" + "エラー： " + message;

                return false;
            }

            return true;
        }

        /// <summary>
        /// 半角チェック対象かを返す.
        /// </summary>
        /// <param name="sybt"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private Boolean isHnkkCheckTarget(String sybt, int index)
        {
            if (sybt == KkhConstAcom.MediaKindCode.SYBT_SNBN)
            {
                return isHnkkCheckTargetShin(index);
            }
            else if (sybt == KkhConstAcom.MediaKindCode.SYBT_ZASI)
            {
                return isHnkkCheckTargetZashi(index);
            }
            else if (sybt == KkhConstAcom.MediaKindCode.SYBT_DENP)
            {
                return isHnkkCheckTargetDenpa(index);
            }
            else if (sybt == KkhConstAcom.MediaKindCode.SYBT_KOTU)
            {
                return isHnkkCheckTargetKotsu(index);
            }

            return false;
        }

        /// <summary>
        /// 全角チェック対象かを返す.
        /// </summary>
        /// <param name="sybt"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private Boolean isZnkkCheckTarget(String sybt, int index)
        {
            if (sybt == KkhConstAcom.MediaKindCode.SYBT_SNBN)
            {
                return isZnkkCheckTargetShin(index);
            }
            else if (sybt == KkhConstAcom.MediaKindCode.SYBT_ZASI)
            {
                return isZnkkCheckTargetZashi(index);
            }
            else if (sybt == KkhConstAcom.MediaKindCode.SYBT_DENP)
            {
                return isZnkkCheckTargetDenpa(index);
            }
            else if (sybt == KkhConstAcom.MediaKindCode.SYBT_KOTU)
            {
                return isZnkkCheckTargetKotsu(index);
            }

            return false;
        }

        /// <summary>
        /// 数値チェック対象かを返す.
        /// </summary>
        /// <param name="sybt"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private Boolean isSuCheckTarget(String sybt, int index)
        {
            if (sybt == KkhConstAcom.MediaKindCode.SYBT_SNBN)
            {
                return isSuCheckTargetShin(index);
            }
            else if (sybt == KkhConstAcom.MediaKindCode.SYBT_ZASI)
            {
                return isSuCheckTargetZashi(index);
            }
            else if (sybt == KkhConstAcom.MediaKindCode.SYBT_DENP)
            {
                return isSuCheckTargetDenpa(index);
            }
            else if (sybt == KkhConstAcom.MediaKindCode.SYBT_KOTU)
            {
                return isSuCheckTargetKotsu(index);
            }

            return false;
        }

        /// <summary>
        /// 半角チェック対象かを返す（新聞）.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Boolean isHnkkCheckTargetShin(int index)
        {
            return 
            (
                ( index == ACMH_hatCD     ) ||
                ( index == ACMH_Ircd      ) ||
                ( index == ACMH_IrDT      ) ||
                ( index == ACMH_UriDT     ) ||
                ( index == ACMH_ClCD      ) ||
                ( index == ACMH_EgCD      ) ||
                ( index == ACMH_TenCD     ) ||
                ( index == ACMH_ShohinKBN ) ||
                ( index == ACMH_SaiCDKBN  ) ||
                ( index == ACMH_TkyCD     ) ||
                ( index == ACMH_BtiCD     ) ||
                ( index == ACMH_MdaCD     ) ||
                ( index == ACMH_irnaiyou  ) ||
                ( index == ACMH_GyoNUM    ) ||
                ( index == ACMH_YosanKBN  ) ||
                ( index == ACMH_AnSYBT    ) ||
                ( index == ACMH_Keisai    ) ||
                ( index == ACMH_InsDT     ) ||
                ( index == ACMH_UpdDT     ) ||
                ( index == ACMH_DelDT     )
            );
        }

        /// <summary>
        /// 全角チェック対象かを返す（新聞）.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Boolean isZnkkCheckTargetShin(int index)
        {
            return
            (
                ( index == ACMH_EgNM    ) ||
                ( index == ACMH_TenNM   ) ||
                ( index == ACMH_TkyNM   ) ||
                ( index == ACMH_BtiNM   ) ||
                ( index == ACMH_MDnm    ) ||
                ( index == ACMH_UserNM  ) ||
                ( index == ACMH_UserKNM ) ||
                ( index == ACMH_Bikou1  ) ||
                ( index == ACMH_Bikou2  ) ||
                ( index == ACMH_SpaceNM )
            );
        }

        /// <summary>
        /// 数値チェック対象かを返す（新聞）.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Boolean isSuCheckTargetShin(int index)
        {
            return
            (
                ( index == ACMH_Men       ) ||
                ( index == ACMH_SYBT1CD   ) ||
                ( index == ACMH_SYBT2CD   ) ||
                ( index == ACMH_ColorCD   ) ||
                ( index == ACMH_SpaceCD   ) ||
                ( index == ACMH_KeisaiCNT ) ||
                ( index == ACMH_KeisaiTAN ) ||
                ( index == ACMH_keisaiRYO ) ||
                ( index == ACMH_DhenCNT   ) ||
                ( index == ACMH_DhenRYO   ) ||
                ( index == ACMH_Han       ) ||
                ( index == ACMH_SeiD      )
            );
        }

        /// <summary>
        /// 半角チェック対象かを返す（雑誌）.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Boolean isHnkkCheckTargetZashi(int index)
        {
            return
            (
                ( index == ZASI_HATNM    ) ||
                ( index == ZASI_IRKBN    ) ||
                ( index == ZASI_IRYYMM   ) ||
                ( index == ZASI_URYYMM   ) ||
                ( index == ZASI_TOKCD    ) ||
                ( index == ZASI_EIGCD    ) ||
                ( index == ZASI_TENBAN   ) ||
                ( index == ZASI_SHOHKBN  ) ||
                ( index == ZASI_SAIMKBN  ) ||
                ( index == ZASI_TEKICD   ) ||
                ( index == ZASI_BAICD    ) ||
                ( index == ZASI_MEDIACD  ) ||
                ( index == ZASI_IRNAIYO  ) ||
                ( index == ZASI_HATROWNO ) ||
                ( index == ZASI_YOSANKBN ) ||
                ( index == ZASI_ANBSBT   ) ||
                ( index == ZASI_HATUBAI1 ) ||
                ( index == ZASI_HATUBAI2 ) ||
                ( index == ZASI_HATUBAI3 ) ||
                ( index == ZASI_HATUBAI4 ) ||
                ( index == ZASI_HATUBAI5 ) ||
                ( index == ZASI_TOUDATE  ) ||
                ( index == ZASI_HENDATE  ) ||
                ( index == ZASI_TORIDATE ) 
            );
        }

        /// <summary>
        /// 全角チェック対象かを返す（雑誌）.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Boolean isZnkkCheckTargetZashi(int index)
        {
            return
            (
                ( index == ZASI_EIGNM   ) ||
                ( index == ZASI_TENNM   ) ||
                ( index == ZASI_TEKINM  ) ||
                ( index == ZASI_BAINM   ) ||
                ( index == ZASI_MEDIANM ) ||
                ( index == ZASI_TANNM   ) ||
                ( index == ZASI_TANBUNM ) ||
                ( index == ZASI_BIKO1   ) ||
                ( index == ZASI_BIKO2   ) ||
                ( index == ZASI_KEINM   ) ||
                ( index == ZASI_SIZNM   )
            );
        }

        /// <summary>
        /// 数値チェック対象かを返す（雑誌）.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Boolean isSuCheckTargetZashi(int index)
        {
            return
            (
                ( index == ZASI_COLCD       ) ||
                ( index == ZASI_SIZCD       ) ||
                ( index == ZASI_KEICNT      ) ||
                ( index == ZASI_KEITANKA    ) ||
                ( index == ZASI_KEIRYO      ) ||
                ( index == ZASI_DESIGNCNT   ) ||
                ( index == ZASI_DESIGNRYO   ) ||
                ( index == ZASI_HANSHITADAI ) ||
                ( index == ZASI_SEIHANDAI   )
            );
        }

        /// <summary>
        /// 半角チェック対象かを返す（電波）.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Boolean isHnkkCheckTargetDenpa(int index)
        {
            return
            (
                ( index == DENP_HATNM    ) ||
                ( index == DENP_IRKBN    ) ||
                ( index == DENP_IRYYMM   ) ||
                ( index == DENP_URYYMM   ) ||
                ( index == DENP_TOKCD    ) ||
                ( index == DENP_EIGCD    ) ||
                ( index == DENP_TENBAN   ) ||
                ( index == DENP_SHOHKBN  ) ||
                ( index == DENP_SAIMKBN  ) ||
                ( index == DENP_TEKICD   ) ||
                ( index == DENP_BAICD    ) ||
                ( index == DENP_MEDIACD  ) ||
                ( index == DENP_IRNAIYO  ) ||
                ( index == DENP_HATROWNO ) ||
                ( index == DENP_YOSANKBN ) ||
                ( index == DENP_ANBSBT   ) ||
                ( index == DENP_KEIKBN   ) ||
                ( index == DENP_IRYYMM1  ) ||
                ( index == DENP_IRYYMM2  ) ||
                ( index == DENP_IRYYMM3  ) ||
                ( index == DENP_IRYYMM4  ) ||
                ( index == DENP_IRYYMM5  ) ||
                ( index == DENP_IRYYMM6  ) ||
                ( index == DENP_TOUDATE  ) ||
                ( index == DENP_HENDATE  ) ||
                ( index == DENP_TORIDATE )
            );
        }

        /// <summary>
        /// 全角チェック対象かを返す（電波）.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Boolean isZnkkCheckTargetDenpa(int index)
        {
            return
            (
                ( index == DENP_EIGNM   ) ||
                ( index == DENP_TENNM   ) ||
                ( index == DENP_TEKINM  ) ||
                ( index == DENP_BAINM   ) ||
                ( index == DENP_MEDIANM ) ||
                ( index == DENP_TANNM   ) ||
                ( index == DENP_TANBUNM ) ||
                ( index == DENP_BIKO1   ) ||
                ( index == DENP_BIKO2   ) ||
                ( index == DENP_KEIKBNNM )
            );
        }

        /// <summary>
        /// 数値チェック対象かを返す（電波）.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Boolean isSuCheckTargetDenpa(int index)
        {
            return
            (
                ( index == DENP_HOSORYO1 ) ||
                ( index == DENP_HOSORYO2 ) ||
                ( index == DENP_HOSORYO3 ) ||
                ( index == DENP_HOSORYO4 ) ||
                ( index == DENP_HOSORYO5 ) ||
                ( index == DENP_HOSORYO6 )
            );
        }

        /// <summary>
        /// 半角チェック対象かを返す（交通）.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Boolean isHnkkCheckTargetKotsu(int index)
        {
            return 
            (
                ( index == KOTU_HATNM    ) ||
                ( index == KOTU_IRKBN    ) ||
                ( index == KOTU_IRYYMM   ) ||
                ( index == KOTU_URYYMM   ) ||
                ( index == KOTU_TOKCD    ) ||
                ( index == KOTU_EIGCD    ) ||
                ( index == KOTU_TENBAN   ) ||
                ( index == KOTU_SHOHKBN  ) ||
                ( index == KOTU_SAIMKBN  ) ||
                ( index == KOTU_TEKICD   ) ||
                ( index == KOTU_BAICD    ) ||
                ( index == KOTU_MEDIACD  ) ||
                ( index == KOTU_IRNAIYO  ) ||
                ( index == KOTU_HATROWNO ) ||
                ( index == KOTU_YOSANKBN ) ||
                ( index == KOTU_ANBSBT   ) ||
                ( index == KOTU_TOUDATE  ) ||
                ( index == KOTU_HENDATE  ) ||
                ( index == KOTU_TORIDATE )
            );
        }

        /// <summary>
        /// 全角チェック対象かを返す（交通）.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Boolean isZnkkCheckTargetKotsu(int index)
        {
            return
            (
                ( index == KOTU_EIGNM   ) ||
                ( index == KOTU_TENNM   ) ||
                ( index == KOTU_TEKINM  ) ||
                ( index == KOTU_BAINM   ) ||
                ( index == KOTU_MEDIANM ) ||
                ( index == KOTU_TANNM   ) ||
                ( index == KOTU_TANBUNM ) ||
                ( index == KOTU_BIKO1   ) ||
                ( index == KOTU_BIKO2   ) ||
                ( index == KOTU_KEINM )
            );
        }

        /// <summary>
        /// 数値チェック対象かを返す（交通）.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Boolean isSuCheckTargetKotsu(int index)
        {
            return
            (
                ( index == KOTU_KEICD       ) ||
                ( index == KOTU_KEISAI      ) ||
                ( index == KOTU_KEICNT      ) ||
                ( index == KOTU_KEITANKA    ) ||
                ( index == KOTU_KEIRYO      ) ||
                ( index == KOTU_INSTANKA    ) ||
                ( index == KOTU_INSBUCNT    ) ||
                ( index == KOTU_INSDAI      ) ||
                ( index == KOTU_SASHIRYO    ) ||
                ( index == KOTU_DESIGNCNT   ) ||
                ( index == KOTU_DESIGNRYO   ) ||
                ( index == KOTU_HANSHITADAI ) ||
                ( index == KOTU_SEIHANDAI   )
            );
        }

        /// <summary>
        /// 半角チェック
        /// </summary>
        /// <param name="value"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool checkHnkk(String value, out String message)
        {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

            for (int i = 0; i < value.Length; i++)
            {
                if (sjisEnc.GetByteCount(value[i].ToString()) != 1)
                {
                    message = "全角";

                    return true;
                }
            }

            message = String.Empty;

            return false;
        }

        /// <summary>
        /// 全角チェック
        /// </summary>
        /// <param name="value"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool checkZnkk(String value, out String message)
        {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

            for (int i = 0; i < value.Length; i++)
            {
                if (sjisEnc.GetByteCount(value[i].ToString()) != 2)
                {
                    message = "半角";

                    return true;
                }
            }

            message = String.Empty;

            return false;
        }

        /// <summary>
        /// 数値チェック
        /// </summary>
        /// <param name="value"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool checkSu(String value, out String message)
        {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

            for (int i = 0; i < value.Length; i++)
            {
                if (sjisEnc.GetByteCount(value[i].ToString()) != 1)
                {
                    message = "全角、数字以外";

                    return true;
                }
            }

            if (!KKHUtility.IsNumeric(value))
            {
                message = "数字以外";

                return true;
            }

            message = String.Empty;

            return false;
        }

        /// <summary>
        /// 登録データと比較用データの比較を行います。(共通部分用) 
        /// </summary>
        /// <param name="CdA">チェック対象データ(取込発注データ)</param>
        /// <param name="CdB">チェック対象データ(DB)</param>
        /// <param name="compA">チェック結果を格納する</param>
        private List<int> RepeatDataChk(InPutHik.FileImpRow CdA, InPutHik.FileImpRow CdB, List<int> compA)
        {
            //登録年月日.
            compA.Add(String.Compare(CdA.TouDate.Trim(), CdB.TouDate));

            //変更年月日.
            compA.Add(String.Compare(CdA.HenDate.Trim(), CdB.HenDate));

            //取消年月日.
            compA.Add(String.Compare(CdA.TorDate.Trim(), CdB.TorDate));

            //発注番号.
            compA.Add(String.Compare(CdA.IrBan.Trim(), CdB.IrBan));

            //依頼区分.
            compA.Add(String.Compare(CdA.IrKbn.Trim(), CdB.IrKbn));

            //依頼月.
            compA.Add(String.Compare(CdA.IrYyMm.Trim(), CdB.IrYyMm));

            //売上予定年月. 
            compA.Add(String.Compare(CdA.UriYyMm.Trim(), CdB.UriYyMm));

            //得意先コード. 
            compA.Add(String.Compare(CdA.TksKgyCd.Trim(), CdB.TksKgyCd));

            //営業部コード.
            compA.Add(String.Compare(CdA.EiCode.Trim(), CdB.EiCode));

            //営業部名. 
            compA.Add(String.Compare(CdA.EiName.Trim(), CdB.EiName));

            //店番. 
            compA.Add(String.Compare(CdA.TenCd.Trim(), CdB.TenCd));

            //店名. 
            compA.Add(String.Compare(CdA.TenName.Trim(), CdB.TenName));

            //商品区分. 
            compA.Add(String.Compare(CdA.SyohiKbn.Trim(), CdB.SyohiKbn));

            //明細区分. 
            compA.Add(String.Compare(CdA.SaiKbn.Trim(), CdB.SaiKbn));

            //摘要コード. 
            compA.Add(String.Compare(CdA.TekiCd.Trim(), CdB.TekiCd));

            //摘要名はチェック対象外.

            //媒体コードはチェック対象外.

            //媒体名はチェック対象外.

            //メディアコード. 
            compA.Add(String.Compare(CdA.MediaCd.Trim(), CdB.MediaCd));

            //メディア名. 
            compA.Add(String.Compare(CdA.MediaName.Trim(), CdB.MediaName));

            //依頼内容. 
            compA.Add(String.Compare(CdA.IrNai.Trim(), CdB.IrNai));

            //依頼行番号. 
            compA.Add(String.Compare(CdA.IrRowBan.Trim(), CdB.IrRowBan));

            //担当者名. 
            compA.Add(String.Compare(CdA.TanName.Trim(), CdB.TanName));

            //担当者勤務部署名. 
            compA.Add(String.Compare(CdA.TanKinName.Trim(), CdB.TanKinName));

            //予算区分. 
            compA.Add(String.Compare(CdA.YosaKbn.Trim(), CdB.YosaKbn));

            //按分種別. 
            compA.Add(String.Compare(CdA.AnSyube.Trim(), CdB.AnSyube));

            //備考1. 
            compA.Add(String.Compare(CdA.Bikou1.Trim(), CdB.Bikou1));

            //備考2. 
            compA.Add(String.Compare(CdA.Bikou2.Trim(), CdB.Bikou2));

            return compA;
        }


        /// <summary>
        /// 日付データの検索件数取得 
        /// </summary>
        /// <param name="TargetDS"></param>
        /// <returns></returns>
        private InPutHik SearchHikDateCnt(InPutHik TargetDS)
        {
            InPutProcessController inPutProcessController = InPutProcessController.GetInstance();
            InPutHik tmpHik = new InPutHik();
            List<string> tmpList = new List<string>();

            //
            for (int i = 0; i < TargetDS.FileImp.Rows.Count; i++ )
            {
                tmpHik.DateCntData.AddDateCntDataRow(tmpHik.DateCntData.NewDateCntDataRow());
                tmpHik.DateCntData[i].TksKgyCd    = _naviParam.strTksKgyCd;       //得意先企業コード 
                tmpHik.DateCntData[i].TksBmnSeqNo = _naviParam.strTksBmnSeqNo;    //得意先部門SEQNO    
                tmpHik.DateCntData[i].TksTntSeqNo = _naviParam.strTksTntSeqNo;    //得意先担当SEQNO 
                tmpHik.DateCntData[i].Sybt        = TargetDS.FileImp[i].Sybt;     //媒体コード 
                tmpHik.DateCntData[i].RecCd       = TargetDS.FileImp[i].RecCd;    //レコード種別 
                tmpHik.DateCntData[i].IrBan       = TargetDS.FileImp[i].IrBan;    //発注番号 
                tmpHik.DateCntData[i].IrRowBan    = TargetDS.FileImp[i].IrRowBan; //発注行番号 
            }

           //
           FindHikDateCntByCondServiceResult result = inPutProcessController.FindHikDateCntByCond(tmpHik);

           //DBから値を取得できない場合 
           if(result.HasError){
               ShowDBErrMsg(result.MessageCode);
               return null;
           }


           // 取得データを全件DataSetにセット 
           //tmpHik.Merge(result.HikDataSet); 
           return result.HikDataSet;
        }

        /// <summary>
        /// マスタデータの取得済みチェックを行う 
        /// </summary>
        /// <param name="MasterKeyList">チェック対象データ</param>
        /// <returns></returns>
        private MasterMaintenance GetMasterData(List<string> MasterKeyList)
        {
            DataRow[] tmpRows;
            FindMasterMaintenanceByCondServiceResult result = new FindMasterMaintenanceByCondServiceResult();

            foreach(string MasterKey in MasterKeyList){
                //得意先別使用マスタデータ取得 
                if(_dsMasterData_All != null){
                    tmpRows = _dsMasterData_All.MasterDataVO.Select("sybt = '" + MasterSybtKey[MasterKey] + "'");//ここでは別のものを渡す
                    //データセットにデータがある場合 
                    //マスターキーでデータの取得済みの有無を確認する  
                    if (tmpRows.Length == 0)
                    {
                        //未取得のマスタデータを取得する 
                        result = GetTokuibetuMasterData(MasterKey);

                        if (result.HasError != true)
                        {
                            //マージ処理 
                            _dsMasterData_All.Merge(result.MasterDataSet.MasterDataVO);
                        }else{
                            //エラーメッセージ表示 
                            ShowDBErrMsg(result.MessageCode);
                            return null;
                        }
                    }
                }
                else
                {
                    //得意先別マスタデータ取得用 
                    _dsMasterData_All = new MasterMaintenance();

                    //未取得のマスタデータを取得する 
                    result = GetTokuibetuMasterData(MasterKey);

                    if (result.HasError != true)
                    {
                        //マージ処理 
                        _dsMasterData_All.Merge(result.MasterDataSet.MasterDataVO);
                    }
                    else {
                        //エラーメッセージ表示 
                        ShowDBErrMsg(result.MessageCode);
                        return null;
                    }
                }
            }
            return _dsMasterData_All;
        }

        /// <summary>
        /// 得意先別マスターキー取得 
        /// </summary>
        /// <returns></returns>
        private MasterMaintenance GetMasterKindData()
        {
            MasterMaintenanceProcessController masterProcessController = MasterMaintenanceProcessController.GetInstance();

            FindMasterMaintenanceByCondServiceResult result = masterProcessController.FindMasterDefineByCond(_naviParam.strEsqId,
                                                                                                             _naviParam.strEgcd,
                                                                                                             _naviParam.strTksKgyCd,
                                                                                                             _naviParam.strTksBmnSeqNo,
                                                                                                             _naviParam.strTksTntSeqNo
                                                                                                             );

            
            MasterMaintenance tmpMasterKindData = new MasterMaintenance();
            tmpMasterKindData.Merge(result.MasterDataSet);

            return tmpMasterKindData;
        }

        /// <summary>
        /// 得意先別マスタデータ取得 
        /// </summary>
        /// <param name="MasterKey">マスタ選別用キー</param>
        /// <returns></returns>
        private FindMasterMaintenanceByCondServiceResult GetTokuibetuMasterData(string MasterKey)
        {
            MasterMaintenanceProcessController masterProcessController = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult result;

            result = masterProcessController.FindMasterByCond(_naviParam.strEsqId,
                                                              _naviParam.strEgcd,
                                                              _naviParam.strTksKgyCd,
                                                              _naviParam.strTksBmnSeqNo,
                                                              _naviParam.strTksTntSeqNo,
                                                              MasterKey,
                                                              null
            
                                                              );
            //DBから値を取得できない場合 
        　　if(result.HasError){
              //エラーメッセージ表示 
              ShowDBErrMsg(result.MessageCode);
              return new FindMasterMaintenanceByCondServiceResult();
            }
            return result;
        }

        /// <summary>
        /// 登録前日付チェックメソッド 
        /// </summary>
        /// <param name="targetDS"></param>
        /// <returns></returns>
        private InPutHik CheckRegistDateData(InPutHik targetDS)
        {
            List<int> deleteList = new List<int>();
            List<int> tmpList = new List<int>();
            InPutHik checkDateCntDS;               //日付検索結果件数 
            DataRow[] tmpRows;                      //作業用 
            DialogResult OCFlg;
            int deleteCnt = 0;

            //日付検索件数取得 
            checkDateCntDS = SearchHikDateCnt(targetDS);
            if (checkDateCntDS == null)
            {
                return null;
            }
            
            
            for (int i = 0; targetDS.FileImp.Count > i ; i++)
            {
                //登録年月日、変更年月日、取消年月日のパターンチェック 
                //登録年月日が無い場合 
                if (targetDS.FileImp[i].TouDate.Trim().CompareTo("") == 0)
                {
                    OCFlg = MessageUtility.ShowMessageBox(MessageCode.HB_W0005,
                            new string[]{(i + 1).ToString() ,targetDS.FileImp[i].IrBan,
                           targetDS.FileImp[i].IrRowBan,(i + 1).ToString() },
                           "データエラー", MessageBoxButtons.YesNo);

                    //削除候補に加える 
                    if (OCFlg == DialogResult.Yes)
                    {
                        tmpList.Add(i);
                    }
                }

                //登録年月日、変更年月日、取消年月日が全てある場合 
                if ((targetDS.FileImp[i].TouDate.Trim().CompareTo("") > 0) &&
                    (targetDS.FileImp[i].HenDate.Trim().CompareTo("") > 0) &&
                    (targetDS.FileImp[i].TorDate.Trim().CompareTo("") > 0))
                {
                    OCFlg = MessageUtility.ShowMessageBox(MessageCode.HB_W0007,
                            new string[]{(i + 1).ToString(), targetDS.FileImp[i].IrBan,
                            targetDS.FileImp[i].IrRowBan, (i + 1).ToString()},
                            "データエラー", MessageBoxButtons.YesNo);

                    //削除候補に加える 
                    if (OCFlg == DialogResult.Yes)
                    {
                        tmpList.Add(i);
                    }
                }
               
                //登録年月日、取消年月日があり、変更年月日がない場合 
                if ((targetDS.FileImp[i].TouDate.Trim().CompareTo("") > 0) &&
                    (targetDS.FileImp[i].HenDate.Trim().CompareTo("") == 0) &&
                    (targetDS.FileImp[i].TorDate.Trim().CompareTo("") > 0))
                {
                    tmpRows = checkDateCntDS.DateCntData.Select("IrBan = '" + targetDS.FileImp[i].IrBan + "' AND " +
                                                                "IrRowBan = '" + targetDS.FileImp[i].IrRowBan + "'");

                    if (tmpRows.Length == 0)
                    {
                        OCFlg = MessageUtility.ShowMessageBox(MessageCode.HB_W0006,
                                new string[]{(i + 1).ToString(), targetDS.FileImp[i].IrBan,
                                targetDS.FileImp[i].IrRowBan, (i + 1).ToString()},
                                "データエラー", MessageBoxButtons.YesNo);

                        //削除候補に加える 
                        if (OCFlg == DialogResult.Yes)
                        {
                            tmpList.Add(i);
                        }
                    }
                }
            }

            //削除候補が1件以上ある場合 
            if (tmpList.Count > 0)
            {
                foreach (int ary in tmpList.ToArray())
                {
                    if (!deleteList.Contains(ary))
                    {
                        //判定用のために保存する 
                        deleteList.Add(ary);
                        targetDS.FileImp[ary - deleteCnt].Delete();
                        deleteCnt++;
                    }
                }
                deleteList.Clear();
                tmpList.Clear();
            }

            return targetDS;
        }

        /// <summary>
        /// 種別ごとに各マスタへ存在チェックを行う 
        /// </summary>
        /// <param name="CheckData">マスタ存在チェック対象データ</param>
        /// <param name="Sybt">マスタ種別コード</param>
        /// <returns></returns>
        private Boolean GetTokuibetuMasterData(InPutHik CheckData, string Sybt)
        {
            string strFilter = "TksKgyCd = '" + _naviParam.strTksKgyCd + "' AND Sybt = ";
            DataRow[] dataRow;
            List<string> MasterKeyList = new List<string>();
            MasterMaintenance dsMasterData_All;
            Boolean ErrFlag = true;

            //種別【雑誌】 
            if (Sybt.CompareTo(KkhConstAcom.MediaKindCode.SYBT_ZASI) == 0)
            {
                MasterKeyList.Add(KkhConstAcom.MediaKindMasterKey.SIZE_MASTERKEY);
                MasterKeyList.Add(KkhConstAcom.MediaKindMasterKey.MEDIA_MASTERKEY);
                MasterKeyList.Add(KkhConstAcom.MediaKindMasterKey.COLOR_MASTERKEY);

                for (int i = 0; i < CheckData.FileImp.Count; i++ )
                {
                    //マスタデータ取得 
                    dsMasterData_All = GetMasterData(MasterKeyList);
                    if (dsMasterData_All == null)
                    {
                        return false;
                    }

                    //媒体種別データ取得 
                    //MasterKindDataRow = dsMasterData_All.MasterDataVO.Select(strFilter + "'" + MasterSybtKey[MEDIA_KIND_MASTERKEY] + "' AND Column1 = '" + CheckData.FileImp[i].SizeCd + "'");

                    //サイズコード変換マスタ(サイズコード) 
                    dataRow = dsMasterData_All.MasterDataVO.Select(strFilter + "'" 
                        + MasterSybtKey[KkhConstAcom.MediaKindMasterKey.SIZE_MASTERKEY] 
                        + "' AND Column2 = '" + CheckData.FileImp[i].SizeCd + "'" + "  AND Column1 = '03'");
                    if (dataRow.Length == 0)
                    {
                        //エラーログ(テーブル)出力 
                        ErrFlag = false;
                        if (OutPutMasterLogData(i, CheckData.FileImp[i].SizeCd, KkhConstAcom.MasterCodeName.SIZE_CODE_NAME) == false)
                        {
                            return false;
                        }
                    }

                    //メディアコード変換マスタ(メディアコード) 
                    dataRow = dsMasterData_All.MasterDataVO.Select(strFilter + "'" 
                        + MasterSybtKey[KkhConstAcom.MediaKindMasterKey.MEDIA_MASTERKEY] 
                        + "' AND Column2 = '" + CheckData.FileImp[i].MediaCd + "'" + "  AND Column1 = '03'");
                    if (dataRow.Length == 0)
                    {
                        //エラーログ(テーブル)出力 
                        ErrFlag = false;
                        if (OutPutMasterLogData(i, CheckData.FileImp[i].MediaCd, KkhConstAcom.MasterCodeName.MEDIA_CODE_NAME) == false)
                        {
                            return false;
                        }
                    }

                    //色刷変換マスタ(カラーコード) 
                    dataRow = dsMasterData_All.MasterDataVO.Select(strFilter + "'" 
                        + MasterSybtKey[KkhConstAcom.MediaKindMasterKey.COLOR_MASTERKEY] 
                        + "' AND Column2 = '" + CheckData.FileImp[i].ColorCd + "'" + "  AND Column1 = '03'");
                    if (dataRow.Length == 0)
                    {
                        //エラーログ(テーブル)出力 
                        ErrFlag = false;
                        if (OutPutMasterLogData(i, CheckData.FileImp[i].ColorCd, KkhConstAcom.MasterCodeName.COLOR_CODE_NAME) == false)
                        {
                            return false;
                        }
                    }
                }
            }
            //種別【電波】            
            else if (Sybt.CompareTo(KkhConstAcom.MediaKindCode.SYBT_DENP) == 0)
            {
                MasterKeyList.Add(KkhConstAcom.MediaKindMasterKey.MEDIA_MASTERKEY);

                for (int i = 0; i < CheckData.FileImp.Count; i++ )
                {
                    //マスタデータ取得 
                    dsMasterData_All = GetMasterData(MasterKeyList);
                    if (dsMasterData_All == null)
                    {
                        return false;
                    }

                    //メディアコード変換マスタ(メディアコード) 
                    dataRow = dsMasterData_All.MasterDataVO.Select(strFilter + "'" 
                        + MasterSybtKey[KkhConstAcom.MediaKindMasterKey.MEDIA_MASTERKEY] 
                        + "' AND Column2 = '" + CheckData.FileImp[i].MediaCd + "'" + "  AND Column1 in ( '04', '05', '07' )");
                    if (dataRow.Length == 0)
                    {
                        //エラーログ(テーブル)出力 
                        ErrFlag = false;
                        if (OutPutMasterLogData(i, CheckData.FileImp[i].MediaCd, KkhConstAcom.MasterCodeName.MEDIA_CODE_NAME) == false)
                        {
                            return false;
                        }
                    }
                }
            }
            //種別【交通】 
            else if (Sybt.CompareTo(KkhConstAcom.MediaKindCode.SYBT_KOTU) == 0)
            {
                MasterKeyList.Add(KkhConstAcom.MediaKindMasterKey.MEDIA_MASTERKEY);
                MasterKeyList.Add(KkhConstAcom.MediaKindMasterKey.KEISAI_MASTERKEY);

                for (int i = 0; i < CheckData.FileImp.Count; i++ )
                {
                    //マスタデータ取得 
                    dsMasterData_All = GetMasterData(MasterKeyList);
                    if (dsMasterData_All == null)
                    {
                        return false;
                    }

                    //掲載場所変換マスタ(掲載場所コード) 
                    dataRow = dsMasterData_All.MasterDataVO.Select(strFilter + "'" 
                        + MasterSybtKey[KkhConstAcom.MediaKindMasterKey.KEISAI_MASTERKEY] 
                        + "' AND Column2 = '" + CheckData.FileImp[i].KotuKeiCd + "'" + "  AND Column1 = '06'");
                    if (dataRow.Length == 0)
                    {
                        //エラーログ(テーブル)出力 
                        ErrFlag = false;
                        if (OutPutMasterLogData(i, CheckData.FileImp[i].KotuKeiCd, KkhConstAcom.MasterCodeName.KEISAI_CODE_NAME) == false)
                        {
                            return false;
                        }
                    }

                    //メディアコード変換マスタ(メディアコード) 
                    dataRow = dsMasterData_All.MasterDataVO.Select(strFilter + "'" 
                        + MasterSybtKey[KkhConstAcom.MediaKindMasterKey.MEDIA_MASTERKEY] 
                        + "' AND Column2 = '" + CheckData.FileImp[i].MediaCd + "'" + "  AND Column1 = '06'");
                    if (dataRow.Length == 0)
                    {
                        //エラーログ(テーブル)出力 
                        ErrFlag = false;
                        if (OutPutMasterLogData(i, CheckData.FileImp[i].MediaCd, KkhConstAcom.MasterCodeName.MEDIA_CODE_NAME) == false)
                        {
                            return false;
                        }
                    }
                }
            }
            //種別【新聞】 
            else if (Sybt.CompareTo(KkhConstAcom.MediaKindCode.SYBT_SNBN) == 0)
            {
                MasterKeyList.Add(KkhConstAcom.MediaKindMasterKey.MEDIA_MASTERKEY);  //メディアコード 
                MasterKeyList.Add(KkhConstAcom.MediaKindMasterKey.COLOR_MASTERKEY);  //色刷コード 
                MasterKeyList.Add(KkhConstAcom.MediaKindMasterKey.SIZE_MASTERKEY);   //サイズコード 
                MasterKeyList.Add(KkhConstAcom.MediaKindMasterKey.KEISAI_MASTERKEY); //掲載場所コード 
                MasterKeyList.Add(KkhConstAcom.MediaKindMasterKey.KIZATSU_MASTERKEY);//記雑コード 
                MasterKeyList.Add(KkhConstAcom.MediaKindMasterKey.ASAYUU_MASTERKEY); //朝夕コード 

                for (int i = 0; i < CheckData.FileImp.Count; i++)
                {
                    //マスタデータ取得
                    dsMasterData_All = GetMasterData(MasterKeyList);
                    if (dsMasterData_All == null)
                    {
                        return false;
                    }

                    //dsMasterData_All.MasterDataVO.Select(strFilter + "'" + 101 + "' AND Field4 = '" + CheckData.FileImp[i]. + "'");//媒体種別マスタ
                    
                    //記雑コード変換マスタ 
                    dataRow = dsMasterData_All.MasterDataVO.Select(strFilter + "'" 
                        + MasterSybtKey[KkhConstAcom.MediaKindMasterKey.KIZATSU_MASTERKEY] 
                        + "' AND Column2 = '" + CheckData.FileImp[i].Sybt1Cd + "'" + "  AND Column1 = '02'");
                    if (dataRow.Length == 0)
                    {
                        //エラーログ(テーブル)出力 
                        ErrFlag = false;
                        if (OutPutMasterLogData(i, CheckData.FileImp[i].Sybt1Cd, KkhConstAcom.MasterCodeName.KIZATSU_CODE_NAME) == false) {
                            return false;
                        }
                    }

                    //朝夕コード変換マスタ 
                    dataRow = dsMasterData_All.MasterDataVO.Select(strFilter + "'" 
                        + MasterSybtKey[KkhConstAcom.MediaKindMasterKey.ASAYUU_MASTERKEY] 
                        + "' AND Column2 = '" + CheckData.FileImp[i].Sybt2Cd + "'" + "  AND Column1 = '02'");
                    if (dataRow.Length == 0)
                    {
                        //エラーログ(テーブル)出力 
                        ErrFlag = false;
                        if (OutPutMasterLogData(i, CheckData.FileImp[i].Sybt2Cd, KkhConstAcom.MasterCodeName.ASAYUU_CODE_NAME) == false)
                        {
                            return false;
                        }
                    }

                    //掲載場所変換マスタ(掲載場所コード) 
                    dataRow = dsMasterData_All.MasterDataVO.Select(strFilter + "'" 
                        + MasterSybtKey[KkhConstAcom.MediaKindMasterKey.KEISAI_MASTERKEY] 
                        + "' AND Column2 = '" + CheckData.FileImp[i].PlaceCd + "'" + "  AND Column1 = '02'");
                    if (dataRow.Length == 0)
                    {
                        //エラーログ(テーブル)出力 
                        ErrFlag = false;
                        if (OutPutMasterLogData(i, CheckData.FileImp[i].PlaceCd, KkhConstAcom.MasterCodeName.KEISAI_CODE_NAME) == false)
                        {
                            return false;
                        }
                    }

                    //サイズコード変換マスタ(サイズコード) 
                    dataRow = dsMasterData_All.MasterDataVO.Select(strFilter + "'" 
                        + MasterSybtKey[KkhConstAcom.MediaKindMasterKey.SIZE_MASTERKEY] 
                        + "' AND Column2 = '" + CheckData.FileImp[i].SpaceCd + "'" + "  AND Column1 = '02'");
                    if (dataRow.Length == 0)
                    {
                        //エラーログ(テーブル)出力 
                        ErrFlag = false;
                        if (OutPutMasterLogData(i, CheckData.FileImp[i].SpaceCd, KkhConstAcom.MasterCodeName.SIZE_CODE_NAME) == false)
                        {
                            return false;
                        }
                    }

                    //メディアコード変換マスタ(メディアコード) 
                    dataRow = dsMasterData_All.MasterDataVO.Select(strFilter + "'" + MasterSybtKey[KkhConstAcom.MediaKindMasterKey.MEDIA_MASTERKEY] + "' AND Column2 = '" + CheckData.FileImp[i].MediaCd + "'" + "  AND Column1 = '02'");
                    if (dataRow.Length == 0)
                    {
                        //エラーログ(テーブル)出力 
                        ErrFlag = false;
                        if (OutPutMasterLogData(i, CheckData.FileImp[i].MediaCd, KkhConstAcom.MasterCodeName.MEDIA_CODE_NAME) == false)
                        {
                            return false;
                        }
                    }

                    //色刷変換マスタ(カラーコード) 
                    dataRow = dsMasterData_All.MasterDataVO.Select(strFilter + "'" 
                        + MasterSybtKey[KkhConstAcom.MediaKindMasterKey.COLOR_MASTERKEY] 
                        + "' AND Column2 = '" + CheckData.FileImp[i].ColorCd + "'" + "  AND Column1 = '02'");
                    if (dataRow.Length == 0)
                    {
                        //エラーログ(テーブル)出力 
                        ErrFlag = false;
                        if (OutPutMasterLogData(i, CheckData.FileImp[i].ColorCd, KkhConstAcom.MasterCodeName.COLOR_CODE_NAME) == false)
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                //該当なし 
            }
            return ErrFlag;
        }

        /// <summary>
        /// ログ出力管理メソッド(異常) 
        /// </summary>
        /// <param name="FileRowCnt">エラー対象行番号</param>
        /// <param name="FileData">エラー対象データ</param>
        /// <param name="ErrMasterCodeName">エラー対象マスタ名</param>
        private Boolean OutPutMasterLogData(int FileRowCnt,string FileData,string ErrMasterCodeName)
        {
            //Logのタイトル 
            String LogTitle = "【発注データ取込:マスタ未登録】";

            //Logの内容 
            String LogMessage = ( FileRowCnt + 1 ) + "行目の" + ErrMasterCodeName + "[" + FileData + "]" 
                + "はマスタに登録がありません" + "\t" + "ファイル名：" + stFileName + "\t" + "媒体:" 
                + SybtCodeSybtKey[KKHUtility.ToString(cbxSybtName.SelectedValue)] + "\t";

            //ログ出力(ファイル) 
            CreateMasterLogFile(FileRowCnt, FileData, LogTitle, LogMessage);

            ////ログ出力(DB) 
            RegistLogServiceResult logResult = KKHLogUtilityAcom.WriteMasterLogToDB(_naviParam, 
                APLID, "発注データ受信", LogTitle + " " + LogMessage, "メール", "1");

            if (logResult.HasError)
            {
                ShowDBErrMsg(logResult.MessageCode);
                return false;
            }

            return true;
        }



        /// <summary>
        /// ログ出力メソッド(正常) 
        /// </summary>
        private void OutPutLogData()
        {
            //登録完了(ログ出力)  
            RegistLogServiceResult logResult = KKHLogUtilityAcom.WriteReceiveLogToDB(_naviParam, 
                APLID, "発注データ受信", " ", "メール", "0");

            if (logResult.HasError)
            {
                ShowDBErrMsg(logResult.MessageCode);
                return;
            }
        }

        /// <summary>
        /// DBから値が取得できない場合、エラーメッセージを表示する 
        /// </summary>
        /// <returns></returns>
        private void ShowDBErrMsg(String ErrCode)
        {
            MessageUtility.ShowMessageBox(MessageCode.HB_E0001, new string[] { ErrCode },
                                "エラー", MessageBoxButtons.OKCancel);
        }

        /// <summary>
        /// 文字列をDecimal型に変換するメソッド 
        /// parseに失敗した場合にはDECIMAL_PARSE_CHECK_ERR_NUMを返す。 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private Decimal DecimalParse(string value)
        {
            Decimal resultValue;
            if (Decimal.TryParse(value, out resultValue) == true)
            {
                //数値変換成功(変換後の値を返す) 
                return resultValue;
            }
            else
            {
                //数値変換失敗(エラーとしてDECIMAL_PARSE_CHECK_ERR_NUMを返す) 
                return KkhConstAcom.DECIMAL_PARSE_CHECK_ERR_NUM;
            }
        }

        /// <summary>
        /// 文字列から指定バイト数取得メソッド 
        /// </summary>
        /// <param name="stTarget">バイト抜き出し対象文字列</param>
        /// <param name="iStart">バイト抜き出し開始位置</param>
        /// <param name="iByteSize">バイト抜き出しサイズ</param>
        /// <returns></returns>
        private string MidB(string stTarget, int iStart, int iByteSize)
        {
            System.Text.Encoding hEncoding = System.Text.Encoding.GetEncoding("Shift_JIS");
            byte[] btBytes = hEncoding.GetBytes(stTarget);

            return hEncoding.GetString(btBytes, iStart, iByteSize);
        }

        /// <summary>
        /// Logファイル作成メソッド 
        /// </summary>
        /// <param name="FileRowCnt">エラー該当行番号</param>
        /// <param name="FileData">ログ(ファイル)出力文字列</param>
        /// <param name="title">エラータイトル</param>
        /// /// <param name="message">エラーメッセージ</param>
        private void CreateMasterLogFile(int FileRowCnt, string FileData, String title, String message)
        {
            StringBuilder sb = new StringBuilder();

            // タイトルとメッセージ.
            sb.Append(title + "\t" + message);

            // その他情報.
            String DateString = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            sb.Append("日時：" + DateString + "\t");
            sb.Append("PG名:" + updateAplID + "\t");
            sb.Append("担当者コード:" + _naviParam.strEsqId + "\t");
            sb.Append("担当者名:" + _naviParam.strName + "\t");
            sb.Append("得意先CD:" + _naviParam.strTksKgyCd + "\t");
            sb.Append("得意先部門CD:" + _naviParam.strTksBmnSeqNo + "\t");
            sb.Append("得意先担当CD:" + _naviParam.strTksTntSeqNo + "\t");
            sb.Append(Environment.NewLine);

            // フォルダ (ディレクトリ) が存在しているかどうか確認する 
            if (!System.IO.Directory.Exists(strLogFilePath))
            {
                // ログフォルダ名作成 
                System.IO.Directory.CreateDirectory(strLogFilePath);
            }

            // Log作成.
            StreamWriter sw = new StreamWriter(strLogFilePath + strLogFilename, true, Encoding.GetEncoding("shift_jis"));

            sw.Write(sb.ToString());
            sw.Close();
        }

        /// <summary>
        /// 発注データ検索(SearchHattyuData) 
        /// </summary>
        private void SearchHattyuData()
        {
            // パラメータの設定 
            InPutProcessController inPutProcessController = InPutProcessController.GetInstance();
            FindHikByCondServiceResult result = inPutProcessController.FindHikByCond(
                                                                                      _naviParam.strTksKgyCd,
                                                                                      _naviParam.strTksBmnSeqNo,
                                                                                      _naviParam.strTksTntSeqNo,
                                                                                      KKHUtility.ToString(cbxSybtName.SelectedValue),
                                                                                      tbxYyMm.Value
                                                                                   );
            //DBから値を取得できない場合  
            if (result.HasError)
            {
                ShowDBErrMsg(result.MessageCode);

                this.ActiveControl = null;

                return;
            }

            // 取得データを全件DataSetにセット 
            _dsHikTrkm_All.Clear();
            _dsHikTrkm_All.Merge(result.HikDataSet);

            // スプレッド更新 
            if (rbnSaiSin.Checked == true)
            {
                UpdateSpd_SaiSin();
            }
            else
            {
                UpdateSpd_Rireki();
            }
        }

    }
    #endregion
}