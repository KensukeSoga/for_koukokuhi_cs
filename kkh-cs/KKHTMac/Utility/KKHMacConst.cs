using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Mac.KKHUtility
{
    /// <summary>
    /// 得意先マクドナルド定数域 
    /// </summary>
    public struct KKHMacConst
    {

        #region "マスタメンテナンス" 

        #region 定数 

        /// <summary>
        /// マスタ（コード） 
        /// </summary>
        public const string C_MAST_TENPO_CD = "0001"; //店舗マスタ
        public const string C_MAST_TENPO_PTN_CD = "0004"; // 店舗パターンマスタ
        public const string C_MAST_TENPO_PTN_DT_CD = "0005"; // 店舗パターン内容マスタ

        /// <summary>
        /// マスタ（名称） 
        /// </summary>
        public const string C_MAST_TENPO_NM = "店舗マスター";
        public const string C_MAST_TENPO_PTN_NM = "店舗パターンマスター";
        public const string C_MAST_TENPO_PTN_DT_NM = "店舗パターン内容マスター";
       
        /// <summary>
        /// 店舗区分（コード） 
        /// </summary>
        public const string C_TENPO_KBN_CD1 = "0"; // 地区本部  
        public const string C_TENPO_KBN_CD2 = "1"; // MC直営店 
        public const string C_TENPO_KBN_CD3 = "2"; // ライセンシー 
        public const string C_TENPO_KBN_CD4 = "3"; // その他 

        /// <summary>
        /// 店舗区分（名称） 
        /// </summary>
        public const string C_TENPO_KBN_NM1 = "地区本部";
        public const string C_TENPO_KBN_NM2 = "MC直営店";
        public const string C_TENPO_KBN_NM3 = "ライセンシー";
        public const string C_TENPO_KBN_NM4 = "その他";

        /// <summary>
        /// テリトリー（コード） 
        /// </summary>
        public const string C_TERRITORY_CD1 = "1"; // 関東 
        public const string C_TERRITORY_CD2 = "2"; // 関西 
        public const string C_TERRITORY_CD3 = "3"; // 中央 
        public const string C_TERRITORY_CD4 = "4"; // その他 


        /// <summary>
        /// テリトリー（名称） 
        /// </summary>
        public const string C_TERRITORY_NM1 = "関東"; 
        public const string C_TERRITORY_NM2 = "関西";
        public const string C_TERRITORY_NM3 = "中央";
        public const string C_TERRITORY_NM4 = "その他";

        /// <summary>
        /// 明細行フラグ（コード） 
        /// </summary>
        public const string C_SPLIT_FLG_CD1 = "0"; // 分割する 
        public const string C_SPLIT_FLG_CD2 = "1"; // 分割しない 

        /// <summary>
        /// 明細行フラグ（名称） 
        /// </summary>
        public const string C_SPLIT_FLG_NM1 = "分割する";
        public const string C_SPLIT_FLG_NM2 = "分割しない";

        /// <summary>
        /// ファイル取込時ステータス 
        /// </summary>
        public const string C_INPUT_STAT_DEL = "削除";
        public const string C_INPUT_STAT_NEW = "新規";
        public const string C_INPUT_STAT_EDIT = "変更";
        public const string C_INPUT_STAT_OVER = "重複";
        public const string C_INPUT_STAT_NONE = "差分なし";

        /// <summary>
        /// 差分有無 
        /// </summary>
        public const string C_CHECK_TRUE = "1"; //差分あり 
        public const string C_CHECK_FALSE = "0"; //差分なし 

        /// <summary>
        /// スプレッドのインデックス(マックメンテ画面) 
        /// </summary>
        public const int C_INDEX_MACMANTE_TENPO_CD = 11;            // 店舗コード 
        public const int C_INDEX_MACMANTE_TENPO_NM = 12;            // 店舗名称 
        public const int C_INDEX_MACMANTE_TERRITORY = 13;           // テリトリー 
        public const int C_INDEX_MACMANTE_TENPO_KBN = 14;           // 店舗区分 
        public const int C_INDEX_MACMANTE_KAMOKU_CD = 15;           // 勘定科目 
        public const int C_INDEX_MACMANTE_YUBIN_NO = 16;            // 郵便番号 
        public const int C_INDEX_MACMANTE_ADDRESS1 = 17;            // 住所１ 
        public const int C_INDEX_MACMANTE_ADDRESS2 = 18;            // 住所２ 
        public const int C_INDEX_MACMANTE_TEL_NO = 19;              // 電話番号 
        public const int C_INDEX_MACMANTE_SPLIT_FLG = 20;           // 明細行フラグ 
        public const int C_INDEX_MACMANTE_COMPANY_NM = 21;          // ライセンシー社名 
        public const int C_INDEX_MACMANTE_NAME = 22;                // 代表者名 
        public const int C_INDEX_MACMANTE_TORIHIKISAKI_CD = 23;     // 取引先コード 
        public const int C_INDEX_MACMANTE_IN_STATUS = 24;           // ステータス 

        /// <summary>
        /// スプレッドのインデックス(データ取込一覧画面) 
        /// </summary>
        public const int C_INDEX_INPUTDATA_CHECKBOX = 0;             // チェックボックス 
        public const int C_INDEX_INPUTDATA_DISPLAY_STATUS = 1;       // 画面表示ステータス 
        public const int C_INDEX_INPUTDATA_TENPO_CD = 13;            // 店舗コード 
        public const int C_INDEX_INPUTDATA_TENPO_NM = 14;            // 店舗名称 
        public const int C_INDEX_INPUTDATA_TERRITORY = 15;           // テリトリー 
        public const int C_INDEX_INPUTDATA_TENPO_KBN = 16;           // 店舗区分  
        public const int C_INDEX_INPUTDATA_KAMOKU_CD = 17;           // 勘定科目  
        public const int C_INDEX_INPUTDATA_YUBIN_NO = 18;            // 郵便番号 
        public const int C_INDEX_INPUTDATA_ADDRESS1 = 19;            // 住所１ 
        public const int C_INDEX_INPUTDATA_ADDRESS2 = 20;            // 住所２ 
        public const int C_INDEX_INPUTDATA_TEL_NO = 21;              // 電話番号 
        public const int C_INDEX_INPUTDATA_SPLIT_FLG = 22;           // 明細行フラグ 
        public const int C_INDEX_INPUTDATA_COMPANY_NM = 23;          // ライセンシー社名 
        public const int C_INDEX_INPUTDATA_NAME = 24;                // 代表者名 
        public const int C_INDEX_INPUTDATA_TORIHIKISAKI_CD = 25;     // 取引先コード 
        public const int C_INDEX_INPUTDATA_IN_STATUS = 26;           // ステータス 
        public const int C_INDEX_INPUTDATA_SHOKIGOPEN = 27;          // 初期G.OPEN年月日  
        public const int C_INDEX_INPUTDATA_GOPEN = 28;               // G.OPEN年月日  
        public const int C_INDEX_INPUTDATA_GCLOSE = 29;              // G.CLOSE年月日  
        //public const int C_INDEX_INPUTDATA_CHECKBOX = 0;             // チェックボックス 
        //public const int C_INDEX_INPUTDATA_DISPLAY_STATUS = 1;       // 画面表示ステータス 

        //public const int C_INDEX_INPUTDATA_SHOKIGOPEN = 13;          // 初期G.OPEN年月日  
        //public const int C_INDEX_INPUTDATA_GOPEN = 14;               // G.OPEN年月日  
        //public const int C_INDEX_INPUTDATA_GCLOSE = 15;              // G.CLOSE年月日  

        //public const int C_INDEX_INPUTDATA_TENPO_CD = 16;            // 店舗コード 
        //public const int C_INDEX_INPUTDATA_TENPO_NM = 17;            // 店舗名称 
        //public const int C_INDEX_INPUTDATA_TERRITORY = 18;           // テリトリー 
        //public const int C_INDEX_INPUTDATA_TENPO_KBN = 19;           // 店舗区分  
        //public const int C_INDEX_INPUTDATA_KAMOKU_CD = 20;           // 勘定科目  
        //public const int C_INDEX_INPUTDATA_YUBIN_NO = 21;            // 郵便番号 
        //public const int C_INDEX_INPUTDATA_ADDRESS1 = 22;            // 住所１ 
        //public const int C_INDEX_INPUTDATA_ADDRESS2 = 23;            // 住所２ 
        //public const int C_INDEX_INPUTDATA_TEL_NO = 24;              // 電話番号 
        //public const int C_INDEX_INPUTDATA_SPLIT_FLG = 25;           // 明細行フラグ 
        //public const int C_INDEX_INPUTDATA_COMPANY_NM = 26;          // ライセンシー社名 
        //public const int C_INDEX_INPUTDATA_NAME = 27;                // 代表者名 
        //public const int C_INDEX_INPUTDATA_TORIHIKISAKI_CD = 28;     // 取引先コード 
        //public const int C_INDEX_INPUTDATA_IN_STATUS = 29;           // ステータス 

        /// <summary>
        /// 終了日 
        /// </summary>
        public const string C_CLOSE_DATE = "2077/12/31";   //終了日 

        /// <summary>
        /// デフォルトパターン名称
        /// </summary>
        public const string C_DEFAULT_PTN_NM = "名称未設定";


        /// <summary>
        /// 履歴種別（コード） 
        /// </summary>
        public const string C_RRKTYPE_CD1 = "1"; // 新規 
        public const string C_RRKTYPE_CD2 = "2"; // 変更 
        public const string C_RRKTYPE_CD3 = "3"; // 削除 

        /// <summary>
        /// 履歴種別（名称） 
        /// </summary>
        public const string C_RRKTYPE_NM1 = "新規";  
        public const string C_RRKTYPE_NM2 = "変更";  
        public const string C_RRKTYPE_NM3 = "削除";

        /// <summary>
        /// 更新タイプ（コード） 
        /// </summary>
        public const string C_UPDTYPE_CD1 = "1"; // 取込 
        public const string C_UPDTYPE_CD2 = "2"; // 単一更新 
        public const string C_UPDTYPE_CD3 = "3"; // 一覧更新 

        /// <summary>
        /// 更新タイプ（名称） 
        /// </summary>
        public const string C_UPDTYPE_NM1 = "取込";
        public const string C_UPDTYPE_NM2 = "単一更新";
        public const string C_UPDTYPE_NM3 = "一覧更新"; 

        #endregion

        #endregion

    }
}
