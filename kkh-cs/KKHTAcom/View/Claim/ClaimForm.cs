using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using FarPoint.Win.Spread;

using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHProcessController.Log;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Acom.ProcessController.Claim;
using Isid.KKH.Acom.Schema;
using Isid.KKH.Acom.Utility;

namespace Isid.KKH.Acom.View.Claim
{
    /// <summary>
    /// 請求データ出力 
    /// </summary>
    public partial class ClaimForm : KKHForm
    {
        #region 定数 

        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "ClaiAcom";

        ///// <summary>
        ///// 帳票設定情報取得キー：002 
        ///// </summary>
        //private const string KV7_SYBT = "002";

        /// <summary>
        /// 帳票保存先取得用キー
        /// </summary>
        private const String SYSTEM_KEY_SAVEFILE_PATH = "003";

        /// <summary>
        ///// 請求データ出力＿起動ディレクトリ 
        ///// </summary>
        //private const string CLAIM_SFD_INITDIR = @"C:\";

        /// <summary>
        /// 請求データ出力＿起動ディレクトリ 
        /// </summary>
        private const string CLAIM_SFD_INITDIRTMP = @"C:\Temp\";
        /// <summary>
        /// 請求データ出力＿ファイ名 
        /// </summary>
        private const string CLAIM_SFD_FILENAME = "Adntks_0002";
        /// <summary>
        /// 請求データ出力＿ファイル拡張子 
        /// </summary>
        private const string CLAIM_SFD_EXT = ".txt";
        /// <summary>
        /// 請求データ出力＿フィルタ 
        /// </summary>
        private const string CLAIM_SFD_FILTER = "テキスト ファイル (*.txt)|*.txt";
        /// <summary>
        /// 請求データ出力＿タイトル 
        /// </summary>
        private const string CLAIM_SFD_TITLE = "保存先のファイルを設定して下さい。";
        /// <summary>
        /// 種別＿S 
        /// </summary>
        private const string SYBT_S = "S";
        /// <summary>
        /// 種別＿T 
        /// </summary>
        private const string SYBT_T = "T";
        /// <summary>
        /// 種別＿H 
        /// </summary>
        private const string SYBT_H = "H";

        #endregion 定数 

        #region 構造体 

        /// <summary>
        /// 処理区分名称の構造体 
        /// </summary>
        private struct ShoriKbnNm
        {
            /// <summary>
            /// 未出力 
            /// </summary>
            internal const string MiSyutu = "未出力";
            /// <summary>
            /// 未送信 
            /// </summary>
            internal const string MiSoushin = "未送信";
            /// <summary>
            /// 送信済 
            /// </summary>
            internal const string SoushinZumi = "送信済";
            /// <summary>
            /// 一部出力済 
            /// </summary>
            internal const string IchbuSyutuZumi = "一部出力済";
        }

        /// <summary>
        /// 発注/請求番号 一覧のカラム番号構造体 
        /// </summary>
        private struct ClaimNoListColNo
        {
            /// <summary>
            /// 処理区分
            /// </summary>
            internal const int SHORIKBN = 0;
            /// <summary>
            /// 出力選択
            /// </summary>
            internal const int OUTSELECT = 1;
            /// <summary>
            /// 依頼番号 
            /// </summary>
            internal const int IRAINO = 2;
            /// <summary>
            /// 請求書番号
            /// </summary>
            internal const int SEINO = 3;
            /// <summary>
            /// 請求書発行日 
            /// </summary>
            internal const int SEIYYMM = 4;
            /// <summary>
            /// 出力日時 
            /// </summary>
            internal const int OUTDATE = 7;
        }

        /// <summary>
        /// 発注/請求番号 差異一覧のカラム番号構造体 
        /// </summary>
        private struct ClaimDiffListColNo
        {
            /// <summary>
            /// 種別 
            /// </summary>
            internal const int SYBT = 0;
            /// <summary>
            /// 依頼番号 
            /// </summary>
            internal const int IRAINO = 1;
            /// <summary>
            /// 依頼行番号 
            /// </summary>
            internal const int IRAIGYONO = 2;
            /// <summary>
            /// 請求年月日 
            /// </summary>
            internal const int SEIYYMM = 6;
            /// <summary>
            /// 請求書番号 
            /// </summary>
            internal const int SEINO = 7;
            /// <summary>
            /// 内容区分 
            /// </summary>
            internal const int NAIYOKBN = 8;
            /// <summary>
            /// 請求書行番号 
            /// </summary>
            internal const int SEIGYONO = 9;
            /// <summary>
            /// 商品区分 
            /// </summary>
            internal const int SYOHINKBN = 11;
            /// <summary>
            /// 摘要コード 
            /// </summary>
            internal const int TEKIYOCD = 12;
            /// <summary>
            /// 媒体コード 
            /// </summary>
            internal const int BAITAICD = 13;
            /// <summary>
            /// メディアコード 
            /// </summary>
            internal const int MEDIACD = 14;
            /// <summary>
            /// 形態区分コード 
            /// </summary>
            internal const int KEITAIKBNCD = 17;
            /// <summary>
            /// 形態区分名称 
            /// </summary>
            internal const int KEITAIKBNNM = 18;
            /// <summary>
            /// CM秒数名1 
            /// </summary>
            internal const int CMNAME1 = 19;
            /// <summary>
            /// CM秒数名2 
            /// </summary>
            internal const int CMNAME2 = 20;
            /// <summary>
            /// CM秒数名3 
            /// </summary>
            internal const int CMNAME3 = 21;
            /// <summary>
            /// CM秒数名4 
            /// </summary>
            internal const int CMNAME4 = 22;
            /// <summary>
            /// 内容名称1 
            /// </summary>
            internal const int NAIYONAME1 = 23;
            /// <summary>
            /// 内容名称2 
            /// </summary>
            internal const int NAIYONAME2 = 24;
            /// <summary>
            /// 内容名称3 
            /// </summary>
            internal const int NAIYONAME3 = 25;
            /// <summary>
            /// 内容名称4 
            /// </summary>
            internal const int NAIYONAME4 = 26;
            /// <summary>
            /// 番組名名称1 
            /// </summary>
            internal const int BNGMNAME1 = 27;
            /// <summary>
            /// 番組名名称2 
            /// </summary>
            internal const int BNGMNAME2 = 28;
            /// <summary>
            /// 番組名名称3 
            /// </summary>
            internal const int BNGMNAME3 = 29;
            /// <summary>
            /// 番組名名称4 
            /// </summary>
            internal const int BNGMNAME4 = 30;
            /// <summary>
            /// 掲載場所コード 
            /// </summary>
            internal const int KEISAIBASCD = 31;
            /// <summary>
            /// 掲載場所名称 
            /// </summary>
            internal const int KEISAIBASNM = 32;
            /// <summary>
            /// 種別1コード 
            /// </summary>
            internal const int SYBT1CD = 33;
            /// <summary>
            /// 種別1名称 
            /// </summary>
            internal const int SYBT1NM = 34;
            /// <summary>
            /// 種別2コード 
            /// </summary>
            internal const int SYBT2CD = 35;
            /// <summary>
            /// 種別2名称 
            /// </summary>
            internal const int SYBT2NM = 36;
            /// <summary>
            /// 色刷コード 
            /// </summary>
            internal const int SISACD = 37;
            /// <summary>
            /// 色刷名称 
            /// </summary>
            internal const int SISANM = 38;
            /// <summary>
            /// サイズコード 
            /// </summary>
            internal const int SIZECD = 39;
            /// <summary>
            /// スペースコード 
            /// </summary>
            internal const int SPACECD = 40;
            /// <summary>
            /// サイズ名称
            /// </summary>
            internal const int SIZENM = 41;
            /// <summary>
            /// 交通掲載コード 
            /// </summary>
            internal const int KOTUKEICD = 42;
            /// <summary>
            /// 交通掲載名称 
            /// </summary>
            internal const int KOTUKEINM = 43;
            /// <summary>
            /// 期間 
            /// </summary>
            internal const int KIKAN = 44;
            /// <summary>
            /// 掲載回数 
            /// </summary>
            internal const int KEISAIKAISU = 45;
            /// <summary>
            /// 金額 
            /// </summary>
            internal const int KINGAK = 49;
            /// <summary>
            /// 按分種別 
            /// </summary>
            internal const int ANBUNSYBT = 52;
        }

        /// <summary>
        /// 請求データ 一覧のカラム番号構造体 
        /// </summary>
        private struct ClaimListColNo
        {
            /// <summary>
            /// 種別 
            /// </summary>
            internal const int SYBT = 0;
            /// <summary>
            /// 依頼番号 
            /// </summary>
            internal const int IRAINO = 1;
            /// <summary>
            /// 依頼行番号 
            /// </summary>
            internal const int IRAIGYONO = 2;
            /// <summary>
            /// 取引先コード 
            /// </summary>
            internal const int TORICD = 3;
            /// <summary>
            /// 会社名 
            /// </summary>
            internal const int KAINM = 4;
            /// <summary>
            /// 請求部署コード 
            /// </summary>
            internal const int SEIBUCD = 5;
            /// <summary>
            /// 請求年月日 
            /// </summary>
            internal const int SEIYYMM = 6;
            /// <summary>
            /// 請求書番号 
            /// </summary>
            internal const int SEINO = 7;
            /// <summary>
            /// 内容区分  
            /// </summary>
            internal const int NAIYOKBN = 8;
            /// <summary>
            /// 請求書行番号 
            /// </summary>
            internal const int SEIGYONO = 9;
            /// <summary>
            /// 値引行区分 
            /// </summary>
            internal const int NEBIKBN = 10;
            /// <summary>
            /// 支払日 
            /// </summary>
            internal const int PAYDAY = 11;
            /// <summary>
            /// 商品区分 
            /// </summary>
            internal const int SYOHINKBN = 12;
            /// <summary>
            /// 商品区分名称 
            /// </summary>
            internal const int SYOHINKBNNM = 13;
            /// <summary>
            /// 摘要コード 
            /// </summary>
            internal const int TEKIYOCD = 15;
            /// <summary>
            /// 媒体コード 
            /// </summary>
            internal const int BAITAICD = 16;
            /// <summary>
            /// メディアコード 
            /// </summary>
            internal const int MEDIACD = 17;
            /// <summary>
            /// 形態区分コード 
            /// </summary>
            internal const int KEITAIKBNCD = 20;
            /// <summary>
            /// 形態区分名称 
            /// </summary>
            internal const int KEITAIKBNNM = 21;
            /// <summary>
            /// CM秒数名1 
            /// </summary>
            internal const int CMNAME1 = 22;
            /// <summary>
            /// CM秒数名2 
            /// </summary>
            internal const int CMNAME2 = 23;
            /// <summary>
            /// CM秒数名3 
            /// </summary>
            internal const int CMNAME3 = 24;
            /// <summary>
            /// CM秒数名4 
            /// </summary>
            internal const int CMNAME4 = 25;
            /// <summary>
            /// 内容名称1 
            /// </summary>
            internal const int NAIYONAME1 = 26;
            /// <summary>
            /// 内容名称2 
            /// </summary>
            internal const int NAIYONAME2 = 27;
            /// <summary>
            /// 内容名称3 
            /// </summary>
            internal const int NAIYONAME3 = 28;
            /// <summary>
            /// 内容名称4 
            /// </summary>
            internal const int NAIYONAME4 = 29;
            /// <summary>
            /// 番組名称1 
            /// </summary>
            internal const int BNGMNAME1 = 30;
            /// <summary>
            /// 番組名称2 
            /// </summary>
            internal const int BNGMNAME2 = 31;
            /// <summary>
            /// 番組名称3 
            /// </summary>
            internal const int BNGMNAME3 = 32;
            /// <summary>
            /// 番組名称4 
            /// </summary>
            internal const int BNGMNAME4 = 33;
            /// <summary>
            /// 掲載場所コード 
            /// </summary>
            internal const int KEISAIBASCD = 34;
            /// <summary>
            /// 掲載場所名称 
            /// </summary>
            internal const int KEISAIBASNM = 35;
            /// <summary>
            /// 種別1コード 
            /// </summary>
            internal const int SYBT1CD = 36;
            /// <summary>
            /// 種別1名称 
            /// </summary>
            internal const int SYBT1NM = 37;
            /// <summary>
            /// 種別2コード 
            /// </summary>
            internal const int SYBT2CD = 38;
            /// <summary>
            /// 種別2名称 
            /// </summary>
            internal const int SYBT2NM = 39;
            /// <summary>
            /// 色刷コード 
            /// </summary>
            internal const int SISACD = 40;
            /// <summary>
            /// 色刷名称 
            /// </summary>
            internal const int SISANM = 41;
            /// <summary>
            /// サイズコード 
            /// </summary>
            internal const int SIZECD = 42;
            /// <summary>
            /// サイズ名称 
            /// </summary>
            internal const int SIZENM = 43;
            /// <summary>
            /// 交通掲載コード 
            /// </summary>
            internal const int KOTUKEICD = 44;
            /// <summary>
            /// 交通掲載名称 
            /// </summary>
            internal const int KOTUKEINM = 45;
            /// <summary>
            /// 期間 
            /// </summary>
            internal const int KIKAN = 46;
            /// <summary>
            /// 金額 
            /// </summary>
            internal const int KINGAK = 51;
            /// <summary>
            /// 消費税 
            /// </summary>
            internal const int SYOHIZEI = 52;
            /// <summary>
            /// 按分種別 
            /// </summary>
            internal const int ANBUNSYBT = 54;
            /// <summary>
            /// 処理区分名 
            /// </summary>
            internal const int SHORIKBNNM = 59;
            /// <summary>
            /// 登録年月日 
            /// </summary>
            internal const int TOUDATE = 60;
            /// <summary>
            /// 受注No 
            /// </summary>
            internal const int JYUTNO = 64;
            /// <summary>
            /// 受注明細No 
            /// </summary>
            internal const int JYMEINO = 65;
            /// <summary>
            /// 売上明細No 
            /// </summary>
            internal const int URMEINO = 66;
            /// <summary>
            /// 連番 
            /// </summary>
            internal const int RENBAN = 67;
        }

        /// <summary>
        /// 請求データ出力文字列長構造体 
        /// </summary>
        private struct ClaimDataItemLength
        {
            /// <summary>
            /// 依頼番号 
            /// </summary>
            internal const int IRAINO = 8;
            /// <summary>
            /// 依頼行番号  
            /// </summary>
            internal const int IRAIGYONO = 4;
            /// <summary>
            /// 取引先コード 
            /// </summary>
            internal const int TORICD = 7;
            /// <summary>
            /// 会社名 
            /// </summary>
            internal const int KAINM = 20;
            /// <summary>
            /// 請求部署コード 
            /// </summary>
            internal const int SEIBUCD = 5;
            /// <summary>
            /// 売上部署コード 
            /// </summary>
            internal const int URIBUCD = 5;
            /// <summary>
            /// 請求年月日 
            /// </summary>
            internal const int SEIYYMM = 8;
            /// <summary>
            /// 請求書番号 
            /// </summary>
            internal const int SEINO = 8;
            /// <summary>
            /// 内容区分 
            /// </summary>
            internal const int NAIYOKBN = 1;
            /// <summary>
            /// 値引行区分 
            /// </summary>
            internal const int NEBIKBN = 1;
            /// <summary>
            /// 請求書行番号 
            /// </summary>
            internal const int SEIGYONO = 4;
            /// <summary>
            /// 支払日 
            /// </summary>
            internal const int PAYDAY = 8;
            /// <summary>
            /// 課税区分 
            /// </summary>
            internal const int KAZEIKBN = 1;
            /// <summary>
            /// 売上区分 
            /// </summary>
            internal const int URIKBN = 1;
            /// <summary>
            /// 売上区分名称 
            /// </summary>
            internal const int URIKBNNM = 16;
            /// <summary>
            /// 商品区分 
            /// </summary>
            internal const int SYOHINKBN = 3;
            /// <summary>
            /// 商品区分名称 
            /// </summary>
            internal const int SYOHINKBNNM = 16;
            /// <summary>
            /// 摘要コード 
            /// </summary>
            internal const int TEKIYOCD = 5;
            /// <summary>
            /// 媒体コード 
            /// </summary>
            internal const int BAITAICD = 2;
            /// <summary>
            /// メディアコード 
            /// </summary>
            internal const int MEDIACD = 6;
            /// <summary>
            /// 地区部署コード 
            /// </summary>
            internal const int TIKBUSCD = 5;
            /// <summary>
            /// 店番 
            /// </summary>
            internal const int TENBAN = 5;
            /// <summary>
            /// 明細コード１ 
            /// </summary>
            internal const int MEISAICD1 = 5;
            /// <summary>
            /// 明細名称１ 
            /// </summary>
            internal const int MEISAINM1 = 20;
            /// <summary>
            /// 明細コード２ 
            /// </summary>
            internal const int MEISAICD2 = 5;
            /// <summary>
            /// 明細名称２ 
            /// </summary>
            internal const int MEISAINM2 = 20;
            /// <summary>
            /// 明細コード３ 
            /// </summary>
            internal const int MEISAICD3 = 5;
            /// <summary>
            /// 明細名称３ 
            /// </summary>
            internal const int MEISAINM3 = 20;
            /// <summary>
            /// 明細コード４ 
            /// </summary>
            internal const int MEISAICD4 = 5;
            /// <summary>
            /// 明細名称４ 
            /// </summary>
            internal const int MEISAINM4 = 20;
            /// <summary>
            /// 明細コード５ 
            /// </summary>
            internal const int MEISAICD5 = 5;
            /// <summary>
            /// 明細名称５ 
            /// </summary>
            internal const int MEISAINM5 = 20;
            /// <summary>
            /// 明細コード６ 
            /// </summary>
            internal const int MEISAICD6 = 5;
            /// <summary>
            /// 明細名称６ 
            /// </summary>
            internal const int MEISAINM6 = 20;
            /// <summary>
            /// 明細コード７ 
            /// </summary>
            internal const int MEISAICD7 = 5;
            /// <summary>
            /// 明細名称７ 
            /// </summary>
            internal const int MEISAINM7 = 20;
            /// <summary>
            /// 明細コード８ 
            /// </summary>
            internal const int MEISAICD8 = 5;
            /// <summary>
            /// 明細名称８ 
            /// </summary>
            internal const int MEISAINM8 = 20;
            /// <summary>
            /// 明細コード９ 
            /// </summary>
            internal const int MEISAICD9 = 5;
            /// <summary>
            /// 明細名称９ 
            /// </summary>
            internal const int MEISAINM9 = 20;
            /// <summary>
            /// 明細コード１０ 
            /// </summary>
            internal const int MEISAICD10 = 5;
            /// <summary>
            /// 明細名称１０ 
            /// </summary>
            internal const int MEISAINM10 = 20;
            /// <summary>
            /// 明細名称１１ 
            /// </summary>
            internal const int MEISAINM11 = 4;
            /// <summary>
            /// 明細名称１２ 
            /// </summary>
            internal const int MEISAINM12 = 20;
            /// <summary>
            /// 明細名称１３ 
            /// </summary>
            internal const int MEISAINM13 = 20;
            /// <summary>
            /// 明細名称１４ 
            /// </summary>
            internal const int MEISAINM14 = 60;
            /// <summary>
            /// 明細名称１５ 
            /// </summary>
            internal const int MEISAINM15 = 50;
            /// <summary>
            /// 明細名称１６ 
            /// </summary>
            internal const int MEISAINM16 = 50;
            /// <summary>
            /// 明細名称１７ 
            /// </summary>
            internal const int MEISAINM17 = 66;
            /// <summary>
            /// 明細名称１８ 
            /// </summary>
            internal const int MEISAINM18 = 3;
            /// <summary>
            /// 明細名称１９ 
            /// </summary>
            internal const int MEISAINM19 = 12;
            /// <summary>
            /// 明細名称２０ 
            /// </summary>
            internal const int MEISAINM20 = 10;
            /// <summary>
            /// 明細名称２１ 
            /// </summary>
            internal const int MEISAINM21 = 12;
            /// <summary>
            /// 明細名称２２ 
            /// </summary>
            internal const int MEISAINM22 = 13;
            /// <summary>
            /// 明細名称２３ 
            /// </summary>
            internal const int MEISAINM23 = 60;
            /// <summary>
            /// 明細名称２４ 
            /// </summary>
            internal const int MEISAINM24 = 60;
            /// <summary>
            /// 明細名称２５ 
            /// </summary>
            internal const int MEISAINM25 = 60;
            /// <summary>
            /// 数量 
            /// </summary>
            internal const int SURYO = 13;
            /// <summary>
            /// 単価 
            /// </summary>
            internal const int KEISAITNK = 13;
            /// <summary>
            /// 金額 
            /// </summary>
            internal const int KINGAK = 14;
            /// <summary>
            /// 消費税 
            /// </summary>
            internal const int SYOHIZEI = 14;
            /// <summary>
            /// JLA合計金額 
            /// </summary>
            internal const int GOUKEI = 14;
            /// <summary>
            /// 処理区分 
            /// </summary>
            internal const int SHORIKBN = 1;
            /// <summary>
            /// 処理番号 
            /// </summary>
            internal const int SHORINO = 8;
            /// <summary>
            /// 按分種別 
            /// </summary>
            internal const int ANBUNSYBT = 1;
            /// <summary>
            /// 按分パターン 
            /// </summary>
            internal const int ANBUNPATTERN = 3;
            /// <summary>
            /// 入力処理区分 
            /// </summary>
            internal const int INSHORIKBN = 1;
            /// <summary>
            /// プログラムＩＤ 
            /// </summary>
            internal const int PRGID = 8;
            /// <summary>
            /// 端末ＩＤ 
            /// </summary>
            internal const int PCID = 8;
            /// <summary>
            /// 入力部署コード 
            /// </summary>
            internal const int INBUSCD = 5;
            /// <summary>
            /// 入力担当者コード 
            /// </summary>
            internal const int INUSERCD = 7;
            /// <summary>
            /// 入力年月 
            /// </summary>
            internal const int INYYMM = 8;
            /// <summary>
            /// 入力時間 
            /// </summary>
            internal const int INTIME = 6;
            /// <summary>
            /// 登録年月日 
            /// </summary>
            internal const int TOUDATE = 8;
            /// <summary>
            /// 変更年月日 
            /// </summary>
            internal const int HENDATE = 8;
            /// <summary>
            /// 取消年月日 
            /// </summary>
            internal const int TORDATE = 8;
            /// <summary>
            /// 出力日時 
            /// </summary>
            internal const int OUTDATE = 40;
        }

        private class CheckException : Exception
        {
            private int m_index;

            public int Index
            {
                set{ m_index = value; }
                get{ return m_index; }
            }

            private int m_type;

            public int Type
            {
                set{ m_type = value; }
                get{ return m_type; }
            }

            public CheckException(int index, int type)
            {
                Index = index;

                Type = type;
            }
        };

        #endregion 構造体 

        #region メンバ変数 

        /// <summary>
        /// Rgナビパラメータ 
        /// </summary>
        private KKHNaviParameter _naviParameter = new KKHNaviParameter();
 
        /// <summary>
        /// 検索年月 
        /// </summary>
        private string _yyyyMM;

        /// <summary>
        /// 選択行 
        /// </summary>
        private int _row = 0;

        /// <summary>
        /// 編集前の請求書発行日 
        /// </summary>
        private string _beforeSeiYymm = string.Empty;
        
        /// <summary>
        /// 編集前の請求書番号 
        /// </summary>
        private string _beforeSeiSeiNo = string.Empty;

        /// <summary>
        /// 編集前の発注番号 
        /// </summary>
        private string _beforeHatyuNo = string.Empty;

        /// <summary>
        /// 編集前の検索時に取得したデータ 
        /// </summary>
        private ClaimDSAcom.ClaimNoDataRow _beforeRow;

        /// <summary>
        /// 保持用
        /// </summary>
        ClaimDSAcom HokanDs = new ClaimDSAcom();

        #endregion メンバ変数

        #region コンストラクタ 

        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public ClaimForm()
        {
            InitializeComponent();
        }

        #endregion コンストラクタ 

        #region イベント 

        /// <summary>
        /// 画面遷移するたびに発生します。 
        /// </summary>
        /// <param name="sender">遷移元フォーム</param>
        /// <param name="arg">イベントデータ</param>
        private void ClaimForm_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParameter = (KKHNaviParameter)arg.NaviParameter;
            }
        }

        /// <summary>
        /// フォームLoadイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
//      private void ClaimForm_Load(object sender, EventArgs e)
        private void ClaimForm_Shown(object sender, EventArgs e)
        {
            this.InitializeControl();
        }

        /// <summary>
        /// フォームResizeイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClaimForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.tabControl1.ItemSize =
                    new Size(this.tabControl1.Width / this.tabControl1.TabCount - 1
                           , this.tabControl1.ItemSize.Height);
            }
        }

        /// <summary>
        /// チェックボックスCheckedChangedイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = null;

            // 選択された内容により項目の表示、非表示を設定する 
            if (sender.GetType() == this.chkShin.GetType())
            {
                chk = (CheckBox)sender;

                if (this.chkShin.Name.Equals(chk.Name))
                {
                    #region 新聞

                    if (chk.Checked == true)
                    {
                        // 発注/請求番号 差異一覧 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KEISAIBASCD].Visible = true;      // 掲載場所コード 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KEISAIBASNM].Visible = true;      // 掲載場所名称 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SYBT1CD].Visible = true;          // 種別1コード 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SYBT1NM].Visible = true;          // 種別1名称 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SYBT2CD].Visible = true;          // 種別2コード 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SYBT2NM].Visible = true;          // 種別2名称 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SISACD].Visible = true;           // 色刷コード 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SISANM].Visible = true;           // 色刷名称 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SIZECD].Visible = true;          // スペースコード 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SIZENM].Visible = true;           // サイズ名称 

                        // 請求データ 一覧 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KEISAIBASCD].Visible = true;              // 掲載場所コード 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KEISAIBASNM].Visible = true;              // 掲載場所名称 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SYBT1CD].Visible = true;                  // 種別1コード 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SYBT1NM].Visible = true;                  // 種別1名称 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SYBT2CD].Visible = true;                  // 種別2コード 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SYBT2NM].Visible = true;                  // 種別2名称 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SISACD].Visible = true;                   // 色刷コード 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SISANM].Visible = true;                   // 色刷名称 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SIZECD].Visible = true;                   // サイズコード 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SIZENM].Visible = true;                   // サイズ名称 
                    }
                    else
                    {
                        // 発注/請求番号 差異一覧 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KEISAIBASCD].Visible = false;     // 掲載場所コード 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KEISAIBASNM].Visible = false;     // 掲載場所名称 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SYBT1CD].Visible = false;         // 種別1コード 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SYBT1NM].Visible = false;         // 種別1名称 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SYBT2CD].Visible = false;         // 種別2コード 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SYBT2NM].Visible = false;         // 種別2名称 

                        //雑誌もOFFの場合 
                        if (this.chkZashi.Checked == false)
                        {
                            this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SISACD].Visible = false;          // 色刷コード 
                            this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SISANM].Visible = false;          // 色刷名称 
                            this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SIZECD].Visible = false;          // サイズコード 
                            this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SIZENM].Visible = false;          // サイズ名称 
                        }
                        // 請求データ 一覧 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KEISAIBASCD].Visible = false;             // 掲載場所コード 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KEISAIBASNM].Visible = false;             // 掲載場所名称 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SYBT1CD].Visible = false;                 // 種別1コード 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SYBT1NM].Visible = false;                 // 種別1名称 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SYBT2CD].Visible = false;                 // 種別2コード 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SYBT2NM].Visible = false;                 // 種別2名称 
                        //雑誌もOFFの場合 
                        if (this.chkZashi.Checked == false)
                        {
                            this.spdClaim_Sheet1.Columns[ClaimListColNo.SISACD].Visible = false;                  // 色刷コード 
                            this.spdClaim_Sheet1.Columns[ClaimListColNo.SISANM].Visible = false;                  // 色刷名称 
                            this.spdClaim_Sheet1.Columns[ClaimListColNo.SIZECD].Visible = false;                  // サイズコード 
                            this.spdClaim_Sheet1.Columns[ClaimListColNo.SIZENM].Visible = false;                  // サイズ名称 
                        }
                    }

                    #endregion 新聞
                }

                if (this.chkZashi.Name.Equals(chk.Name))
                {
                    #region 雑誌 

                    if (chk.Checked == true)
                    {
                        // 発注/請求番号 差異一覧 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SISACD].Visible = true;           // 色刷コード 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SISANM].Visible = true;           // 色刷名称 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SIZECD].Visible = true;           // サイズコード 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SIZENM].Visible = true;           // サイズ名称 

                        // 請求データ 一覧 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SISACD].Visible = true;                   // 色刷コード 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SISANM].Visible = true;                   // 色刷名称 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SIZECD].Visible = true;                   // サイズコード 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.SIZENM].Visible = true;                   // サイズ名称 
                    }
                    else
                    {
                        //新聞もOFFの場合 
                        if (this.chkShin.Checked == false)
                        {
                            // 発注/請求番号 差異一覧 
                            this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SISACD].Visible = false;          // 色刷コード 
                            this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SISANM].Visible = false;          // 色刷名称 
                            this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SIZECD].Visible = false;          // サイズコード 
                            this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.SIZENM].Visible = false;          // サイズ名称 
                            // 請求データ 一覧 
                            this.spdClaim_Sheet1.Columns[ClaimListColNo.SISACD].Visible = false;                  // 色刷コード 
                            this.spdClaim_Sheet1.Columns[ClaimListColNo.SISANM].Visible = false;                  // 色刷名称 
                            this.spdClaim_Sheet1.Columns[ClaimListColNo.SIZECD].Visible = false;                  // サイズコード 
                            this.spdClaim_Sheet1.Columns[ClaimListColNo.SIZENM].Visible = false;                  // サイズ名称 
                        }
                    }

                    #endregion 雑誌 
                }

                if (this.chkDenpa.Name.Equals(chk.Name))
                {
                    #region 電波 

                    if (chk.Checked == true)
                    {
                        // 発注/請求番号 差異一覧 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KEITAIKBNCD].Visible = true;      // 形態区分コード 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KEITAIKBNNM].Visible = true;      // 形態区分名称 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.CMNAME1].Visible = true;          // CM秒数名1 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.CMNAME2].Visible = true;          // CM秒数名2 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.CMNAME3].Visible = true;          // CM秒数名3 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.CMNAME4].Visible = true;          // CM秒数名4 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.NAIYONAME1].Visible = true;       // 内容名称1 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.NAIYONAME2].Visible = true;       // 内容名称2 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.NAIYONAME3].Visible = true;       // 内容名称3 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.NAIYONAME4].Visible = true;       // 内容名称4 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.BNGMNAME1].Visible = true;        // 番組名1 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.BNGMNAME2].Visible = true;        // 番組名2 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.BNGMNAME3].Visible = true;        // 番組名3 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.BNGMNAME4].Visible = true;        // 番組名4 

                        // 請求データ 一覧 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KEITAIKBNCD].Visible = true;              // 形態区分コード 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KEITAIKBNNM].Visible = true;              // 形態区分名称 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.CMNAME1].Visible = true;                  // CM秒数名1 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.CMNAME2].Visible = true;                  // CM秒数名2 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.CMNAME3].Visible = true;                  // CM秒数名3 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.CMNAME4].Visible = true;                  // CM秒数名4 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.NAIYONAME1].Visible = true;               // 内容名称1 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.NAIYONAME2].Visible = true;               // 内容名称2 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.NAIYONAME3].Visible = true;               // 内容名称3 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.NAIYONAME4].Visible = true;               // 内容名称4 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.BNGMNAME1].Visible = true;                // 番組名1 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.BNGMNAME2].Visible = true;                // 番組名2 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.BNGMNAME3].Visible = true;                // 番組名3 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.BNGMNAME4].Visible = true;                // 番組名4 
                    }
                    else
                    {
                        // 発注/請求番号 差異一覧 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KEITAIKBNCD].Visible = false;     // 形態区分コード 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KEITAIKBNNM].Visible = false;     // 形態区分名称 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.CMNAME1].Visible = false;         // CM秒数名1 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.CMNAME2].Visible = false;         // CM秒数名2 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.CMNAME3].Visible = false;         // CM秒数名3 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.CMNAME4].Visible = false;         // CM秒数名4 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.NAIYONAME1].Visible = false;      // 内容名称1 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.NAIYONAME2].Visible = false;      // 内容名称2 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.NAIYONAME3].Visible = false;      // 内容名称3 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.NAIYONAME4].Visible = false;      // 内容名称4 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.BNGMNAME1].Visible = false;       // 番組名1 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.BNGMNAME2].Visible = false;       // 番組名2 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.BNGMNAME3].Visible = false;       // 番組名3 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.BNGMNAME4].Visible = false;       // 番組名4 

                        // 請求データ 一覧 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KEITAIKBNCD].Visible = false;             // 形態区分コード 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KEITAIKBNNM].Visible = false;             // 形態区分名称 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.CMNAME1].Visible = false;                 // CM秒数名1 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.CMNAME2].Visible = false;                 // CM秒数名2 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.CMNAME3].Visible = false;                 // CM秒数名3 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.CMNAME4].Visible = false;                 // CM秒数名4 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.NAIYONAME1].Visible = false;              // 内容名称1 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.NAIYONAME2].Visible = false;              // 内容名称2 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.NAIYONAME3].Visible = false;              // 内容名称3 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.NAIYONAME4].Visible = false;              // 内容名称4 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.BNGMNAME1].Visible = false;               // 番組名1 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.BNGMNAME2].Visible = false;               // 番組名2 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.BNGMNAME3].Visible = false;               // 番組名3 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.BNGMNAME4].Visible = false;               // 番組名4 
                    }

                    #endregion 電波 
                }

                if (this.chkKotsu.Name.Equals(chk.Name))
                {
                    #region 交通 

                    if (this.chkKotsu.Checked == true)
                    {
                        // 発注/請求番号 差異一覧 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KOTUKEICD].Visible = true;        // 交通掲載コード 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KOTUKEINM].Visible = true;        // 交通掲載名称 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KIKAN].Visible = true;            // 期間 

                        // 請求データ 一覧 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KOTUKEICD].Visible = true;                // 交通掲載コード 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KOTUKEINM].Visible = true;                // 交通掲載名称 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KIKAN].Visible = true;                    // 期間 
                    }
                    else
                    {
                        // 発注/請求番号 差異一覧 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KOTUKEICD].Visible = false;       // 交通掲載コード 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KOTUKEINM].Visible = false;       // 交通掲載名称 
                        this.spdClaimDiff_Sheet1.Columns[ClaimDiffListColNo.KIKAN].Visible = false;           // 期間 

                        // 請求データ 一覧 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KOTUKEICD].Visible = false;               // 交通掲載コード 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KOTUKEINM].Visible = false;               // 交通掲載名称 
                        this.spdClaim_Sheet1.Columns[ClaimListColNo.KIKAN].Visible = false;                   // 期間 
                    }

                    #endregion 交通 
                }
            }

        }

        /// <summary>
        /// ボタンMouseMoveイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MouseMove(object sender, MouseEventArgs e)
        {
            tslCnt.Text = njToolTip1.GetToolTip((Control)sender);
        }

        /// <summary>
        /// ボタンMouseLeaveイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MouseLeave(object sender, EventArgs e)
        {
            tslCnt.Text = String.Empty;
        }

        /// <summary>
        /// 検索ボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {
            BtnSrcClick();

            this.ActiveControl = null;
        }

        /// <summary>
        /// 出力ボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOut_Click(object sender, EventArgs e)
        {
            BtnOutClick();

            this.ActiveControl = null;
        }

        /// <summary>
        /// ヘルプボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            string tkskgy = _naviParameter.strTksKgyCd + _naviParameter.strTksBmnSeqNo + _naviParameter.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //実行
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Claim, this, HelpNavigator.KeywordIndex);

            this.ActiveControl = null;
        }

        /// <summary>
        /// 戻るボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, _naviParameter, true);
        }

        /// <summary>
        /// 明細スプレッドのセルにフォーカスを移動するときに発生します 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdClaimNo_EnterCell(object sender, EnterCellEventArgs e)
        {
            _row = e.Row;
            _beforeSeiYymm = KKHUtility.ToString(spdClaimNo_Sheet1.Cells[_row, ClaimNoListColNo.SEIYYMM].Value);
            _beforeSeiSeiNo = KKHUtility.ToString(spdClaimNo_Sheet1.Cells[_row, ClaimNoListColNo.SEINO].Value);
        }

        /// <summary>
        /// 明細スプレッドの編集モードが開始するときに発生します 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdClaimNo_EditModeOn(object sender, EventArgs e)
        {
            _row = spdClaimNo_Sheet1.ActiveRow.Index;
            //_beforeSeiYymm = KKHUtility.ToString(spdClaimNo_Sheet1.Cells[_row, ClaimNoListColNo.SEIYYMM].Value);
            //_beforeHatyuNo = KKHUtility.ToString(spdClaimNo_Sheet1.Cells[_row, ClaimNoListColNo.IRAINO].Value);
            //_beforeSeiSeiNo = KKHUtility.ToString(spdClaimNo_Sheet1.Cells[_row, ClaimNoListColNo.SEINO].Value);

            _beforeRow = (ClaimDSAcom.ClaimNoDataRow)HokanDs.ClaimNoData.Rows[_row];

            // 入力制御の有効化
            InputControlOn( spdClaimNo_Sheet1.ActiveColumn.Index );
        }

        /// <summary>
        /// 明細スプレッドの編集モードが終了するときに発生します 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdClaimNo_EditModeOff(object sender, EventArgs e)
        {
            // 入力制御の無効化
            InputControlOff( spdClaimNo_Sheet1.ActiveColumn.Index );

            // 編集された行の項目取得 
            // 発注番号 
            string iraiNo = KKHUtility.ToString(spdClaimNo_Sheet1.Cells[_row, ClaimNoListColNo.IRAINO].Value);
            // 請求書番号 
            string seiNo = KKHUtility.ToString(spdClaimNo_Sheet1.Cells[_row, ClaimNoListColNo.SEINO].Value);
            // 出力日時 
            string outDate = KKHUtility.ToString(spdClaimNo_Sheet1.Cells[_row, ClaimNoListColNo.OUTDATE].Value);
            // 請求書発行日 
            string seiYymm = KKHUtility.ToString(spdClaimNo_Sheet1.Cells[_row, ClaimNoListColNo.SEIYYMM].Value);

            int seiGyoNo = 1;

            //変更された行を取得する
            ClaimDSAcom.ClaimDataRow[] SelectDataRow = (ClaimDSAcom.ClaimDataRow[])HokanDs.ClaimData.Select("iraiNo = '" + _beforeRow.iraiNo + "' AND seiNo = '" + _beforeRow.seiNo + "' ");
            ClaimDSAcom.ClaimDiffDataRow[] SelectDiffRow = (ClaimDSAcom.ClaimDiffDataRow[])HokanDs.ClaimDiffData.Select("iraiNo = '" + _beforeRow.iraiNo + "' AND seiNo = '" + _beforeRow.seiNo + "' ");


            //foreach (ClaimDSAcom.ClaimDataRow row in HokanDs.ClaimData)
            //{
            //    if (row.iraiNo.Trim().Equals(_beforeRow.iraiNo.Trim()))
            //    {

            //    }
            //}

            //List<string> list = new List<string>();

            //foreach (ClaimDSAcom.ClaimDataRow row in HokanDs.ClaimData.Rows)
            //{
            //    if (row.iraiNo.Equals(_beforeRow.iraiNo) && row.seiNo.Equals(_beforeRow.seiNo))
            //    {
            //        //インデックスを頂いたる。
            //        list.Add(HokanDs.ClaimData.Rows.IndexOf(row).ToString());
            //    }
            //}


            List<ClaimDSAcom.ClaimDataRow> sprRow = new List<ClaimDSAcom.ClaimDataRow>();
            //ClaimDSAcom.ClaimDataRow[] sprRow = new ClaimDSAcom.ClaimDataRow[SelectDataRow.Length];
            foreach (ClaimDSAcom.ClaimDataRow row in SelectDataRow)
            {
                
                //_dsClaim.ClaimData.Rows[HokanDs.ClaimData.Rows.IndexOf(row)]
                
                // 請求書発行日を設定する
                spdClaim_Sheet1.Cells[HokanDs.ClaimData.Rows.IndexOf(row), ClaimListColNo.SEIYYMM].Value = seiYymm;

                //請求書番号を設定する 
                spdClaim_Sheet1.Cells[HokanDs.ClaimData.Rows.IndexOf(row), ClaimListColNo.SEINO].Value = seiNo;

                if (SYBT_S.Equals(KKHUtility.ToString(spdClaim_Sheet1.Cells[HokanDs.ClaimData.Rows.IndexOf(row), ClaimListColNo.SYBT].Value)))
                {
                    // 請求書行番号 
                    spdClaim_Sheet1.Cells[HokanDs.ClaimData.Rows.IndexOf(row), ClaimListColNo.SEIGYONO].Value = seiGyoNo.ToString("000");
                    seiGyoNo += 1;
                }

                sprRow.Add((ClaimDSAcom.ClaimDataRow)_dsClaim.ClaimData.Rows[HokanDs.ClaimData.Rows.IndexOf(row)]);

            }

            _dsClaim.ClaimData.AcceptChanges();

            
            


            //foreach (ClaimDSAcom.ClaimDataRow _dsrow in _dsClaim.ClaimData.Rows)
            //{


            //    foreach (ClaimDSAcom.ClaimDataRow SelRow in SelectRow)
            //    {
            //        if ()
            //        {

            //        }
            //    }



            //}

            // 請求データ一覧へ反映 
            //foreach (Row row in spdClaim_Sheet1.Rows)
            //{
                //if (iraiNo.Trim().Equals(KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.IRAINO].Value).Trim()))
                //{

                


                        // 請求書発行日を設定する  
                        //spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SEIYYMM].Value = seiYymm;
                    


                        // 請求書番号を設定する 
                        //spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SEINO].Value = seiNo;

                        // 種別が「S」の場合に請求書行番号を設定する 
                        //if (SYBT_S.Equals(KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SYBT].Value)))
                        //{
                        //    // 請求書行番号 
                        //    spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SEIGYONO].Value = seiGyoNo.ToString("000");
                        //    seiGyoNo += 1;
                        //}

                //}
            //}

            foreach (ClaimDSAcom.ClaimDiffDataRow row in SelectDiffRow)
            {

                // 請求書発行日を設定する 
                spdClaimDiff_Sheet1.Cells[HokanDs.ClaimDiffData.Rows.IndexOf(row), ClaimDiffListColNo.SEIYYMM].Value = seiYymm;
                // 請求書番号を設定する 
                spdClaimDiff_Sheet1.Cells[HokanDs.ClaimDiffData.Rows.IndexOf(row), ClaimDiffListColNo.SEINO].Value = seiNo;



                foreach (ClaimDSAcom.ClaimDataRow row1 in SelectDataRow)
                {
                    if (row.iraiNo.Equals(row1.iraiNo) && row.seiNo.Equals(row1.seiNo) && row.iraiGyoNo.Equals(row1.iraiGyoNo))
                    {
                        ClaimDSAcom.ClaimDataRow srow = (ClaimDSAcom.ClaimDataRow)_dsClaim.ClaimData.Rows[HokanDs.ClaimData.Rows.IndexOf(row1)];

                        if (SYBT_S.Equals(KKHUtility.ToString(spdClaimDiff_Sheet1.Cells[HokanDs.ClaimDiffData.Rows.IndexOf(row), ClaimListColNo.SYBT].Value)))
                        {
                            //請求書行番号
                            spdClaimDiff_Sheet1.Cells[HokanDs.ClaimDiffData.Rows.IndexOf(row), ClaimListColNo.SEIGYONO].Value = srow.seiGyoNo.Trim();
                        }
                        break;
                    }
                }





            }

            _dsClaim.ClaimDiffData.AcceptChanges();








            // 差異一覧へ反映 
            //foreach (Row row in spdClaimDiff_Sheet1.Rows)
            //{
            //    // 種別が「S」の場合に請求書行番号を設定する 
            //    if (SYBT_S.Equals(KKHUtility.ToString(spdClaimDiff_Sheet1.Cells[row.Index, ClaimDiffListColNo.SYBT].Value).Trim()))
            //    {
            //        if (iraiNo.Trim().Equals(KKHUtility.ToString(spdClaimDiff_Sheet1.Cells[row.Index, ClaimDiffListColNo.IRAINO].Value).Trim()))
            //        {
            //            // 編集前の値と同じ場合のみ、 
            //            if (_beforeSeiYymm.Equals(KKHUtility.ToString(spdClaimDiff_Sheet1.Cells[row.Index, ClaimDiffListColNo.SEIYYMM].Value)))
            //            {
            //                // 請求書発行日を設定する 
            //                spdClaimDiff_Sheet1.Cells[row.Index, ClaimDiffListColNo.SEIYYMM].Value = seiYymm;
            //            }

            //            // 編集前の値と同じ場合のみ、 
            //            if (_beforeSeiSeiNo.Equals(KKHUtility.ToString(spdClaimDiff_Sheet1.Cells[row.Index, ClaimDiffListColNo.SEINO].Value)))
            //            {
            //                // 請求書番号を設定する 
            //                spdClaimDiff_Sheet1.Cells[row.Index, ClaimDiffListColNo.SEINO].Value = seiNo;
            //            }

            //            foreach (Row row2 in spdClaim_Sheet1.Rows)
            //            {
            //                if (!SYBT_S.Equals(KKHUtility.ToString(spdClaim_Sheet1.Cells[row2.Index, ClaimListColNo.SYBT].Value)))
            //                {
            //                    continue;
            //                }

            //                String claimDiff_IRAINO    = KKHUtility.ToString(spdClaimDiff_Sheet1.Cells[row.Index, ClaimDiffListColNo.IRAINO].Value).Trim();
            //                String claimDiff_IRAIGYONO = KKHUtility.ToString(spdClaimDiff_Sheet1.Cells[row.Index, ClaimDiffListColNo.IRAIGYONO].Value).Trim();
            //                String claimDiff_SEINO     = KKHUtility.ToString(spdClaimDiff_Sheet1.Cells[row.Index, ClaimDiffListColNo.SEINO].Value).Trim();

            //                String claim_IRAINO        = KKHUtility.ToString(spdClaim_Sheet1.Cells[row2.Index, ClaimListColNo.IRAINO].Value).Trim();
            //                String claim_IRAIGYONO     = KKHUtility.ToString(spdClaim_Sheet1.Cells[row2.Index, ClaimListColNo.IRAIGYONO].Value).Trim();
            //                String claim_SEINO         = KKHUtility.ToString(spdClaim_Sheet1.Cells[row2.Index, ClaimListColNo.SEINO].Value).Trim();

            //                if
            //                (
            //                    ( claimDiff_IRAINO    != claim_IRAINO    ) ||
            //                    ( claimDiff_IRAIGYONO != claim_IRAIGYONO ) ||
            //                    ( claimDiff_SEINO     != claim_SEINO     )
            //                )
            //                {
            //                    continue;
            //                }

            //                String seiGyoNo2 = KKHUtility.ToString(spdClaim_Sheet1.Cells[row2.Index, ClaimListColNo.SEIGYONO].Value).Trim();

            //                // 請求書行番号 
            //                spdClaimDiff_Sheet1.Cells[row.Index, ClaimDiffListColNo.SEIGYONO].Value = seiGyoNo2;

            //                break;
            //            }
            //        }
            //    }
            //}

        }

        /// <summary>
        /// セル内でマウスのボタンを２回押すときに発生します（ダブルクリック） 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdClaimNo_CellDoubleClick(object sender, CellClickEventArgs e)
        {
            // 出力選択列で、列ヘッダの場合 
            if (e.Column == ClaimNoListColNo.OUTSELECT)
            {
                if (e.ColumnHeader)
                {
                    string value = "False";     // 出力選択値 

                    string outSelect =
                        KKHUtility.ToString(spdClaimNo_Sheet1.Cells[0, ClaimNoListColNo.OUTSELECT].Value);  // 出力選択 

                    // 先頭行の出力選択項目が、チェックＯＮの場合 
                    if ("True".Equals(outSelect))
                    {
                        // 全てのチェックボックスをＯＦＦにする 
                        value = "False";
                    }
                    else
                    {
                        // 全てのチェックボックスをチェックＯＮにする 
                        value = "True";
                    }

                    foreach (Row row in spdClaimNo_Sheet1.Rows)
                    {
                        spdClaimNo_Sheet1.Cells[row.Index, ClaimNoListColNo.OUTSELECT].Value = value;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void condChg(object sender, EventArgs e)
        {
            //[出力]ボタンを非活性化 
            btnOut.Enabled = false;
        }

        #endregion イベント 

        #region メソッド 

        /// <summary>
        /// 各コントロールの初期設定メソッド 
        /// </summary>
        private void InitializeControl()
        {
            // 年月コントロール 
            string strDate = _naviParameter.strDate.Replace("/", string.Empty).Substring(0, 6);

            if (strDate != "")
            {
                strDate = strDate.Trim().Replace("/", "");
                if (strDate.Trim().Length >= 6)
                {
                    txtYm.Value = strDate.Substring(0, 6);
                }
                else
                {
                    txtYm.Value = strDate;
                }
                txtYm.cmbYM_SetDate();
            }

            // ステータス設定 
            tslName.Text = _naviParameter.strName;
            tslDate.Text = _naviParameter.strDate;

            // 出力ボタン 
            btnOut.Enabled = false;

            //スプレッドの入力マップ設定 
            InputMap im = new InputMap();

            // 発注/請求番号 一覧 
            //非編集セルでの[F2]キーを無効 
            im = spdClaimNo.GetInputMap(InputMapMode.WhenFocused);
            im.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);
            //編集中セルでの[F2]キーを無効 
            im = spdClaimNo.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);
            //非編集セルでの[ESC]キーを無効 
            im = spdClaimNo.GetInputMap(InputMapMode.WhenFocused);
            im.Put(new Keystroke(Keys.Escape , Keys.None), SpreadActions.None);
            //編集中セルでの[ESC]キーを無効 
            im = spdClaimNo.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Escape, Keys.None), SpreadActions.None);

            // 発注/請求 差異一覧 
            //非編集セルでの[F2]キーを無効 
            im = spdClaimDiff.GetInputMap(InputMapMode.WhenFocused);
            im.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);
            //編集中セルでの[F2]キーを無効 
            im = spdClaimDiff.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);

            // 請求データ 一覧 
            //非編集セルでの[F2]キーを無効 
            im = spdClaim.GetInputMap(InputMapMode.WhenFocused);
            im.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);
            //編集中セルでの[F2]キーを無効 
            im = spdClaim.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);
        }

        /// <summary>
        /// 選択された媒体種別の条件を編集するメソッド 
        /// </summary>
        /// <returns></returns>
        private string GetBaitaiSybtJoken()
        {
            StringBuilder ret = new StringBuilder();

            // 新聞 
            if (chkShin.Checked)
            {
                ret.Append("'" + KkhConstAcom.MediaKindCode.SYBT_SNBN + "'");
            }
            // 雑誌 
            if (chkZashi.Checked)
            {
                if (!string.IsNullOrEmpty(ret.ToString()))
                {
                    ret.Append(", '" + KkhConstAcom.MediaKindCode.SYBT_ZASI + "'");
                }
                else
                {
                    ret.Append("'" + KkhConstAcom.MediaKindCode.SYBT_ZASI + "'");
                }
            }
            // 電波 
            if (chkDenpa.Checked)
            {
                if (!string.IsNullOrEmpty(ret.ToString()))
                {
                    ret.Append(", '" + KkhConstAcom.MediaKindCode.SYBT_DENP + "'");
                }
                else
                {
                    ret.Append("'" + KkhConstAcom.MediaKindCode.SYBT_DENP + "'");
                }
            }
            // 交通 
            if (chkKotsu.Checked)
            {
                if (!string.IsNullOrEmpty(ret.ToString()))
                {
                    ret.Append(", '" + KkhConstAcom.MediaKindCode.SYBT_KOTU + "'");
                }
                else
                {
                    ret.Append("'" + KkhConstAcom.MediaKindCode.SYBT_KOTU + "'");
                }
            }

            return ret.ToString();
        }

        /// <summary>
        /// 請求データ検索メソッド 
        /// </summary>
        /// <returns>検索結果件数</returns> 
        private int FindReportData()
        {

            // データセットクリア 
            _dsClaim.ClaimNoData.Clear();
            _dsClaim.ClaimData.Clear();
            _dsClaim.ClaimDiffData.Clear();
            _dsClaim.ClaimNoData.AcceptChanges();
            _dsClaim.ClaimData.AcceptChanges();
            _dsClaim.ClaimDiffData.AcceptChanges();

            // 件数表示クリア 
            statusStrip1.Items["tslval1"].Text = string.Empty;

            ClaimAcomProcessController.FindClaimByCondParam param =
                new ClaimAcomProcessController.FindClaimByCondParam();

            // パラメータ設定 
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;
            param.yymm = txtYm.Value;
            // 媒体種別 
            string sybt = this.GetBaitaiSybtJoken();
            if (string.IsNullOrEmpty(sybt))
            {
                // 媒体種別が選択されていない場合は終了 
                return 0;
            }
            param.sybt = sybt;

            // 検索時の年月を保持 
            _yyyyMM = param.yymm;

            // 請求データ検索 
            ClaimAcomProcessController processController = ClaimAcomProcessController.GetInstance();
            FindClaimAcomByCondServiceResult result = processController.FindClaimByCond(param);

            if (result.HasError == true)
            {
                // サーバーから返すエラーが特定のメッセージの場合
                if (result.MessageCode == MessageCode.HB_W0144)
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0144, null, Text, MessageBoxButtons.OK);
                }

                return 0;
            }

            ////保持用に格納
            //HokanDs.Clear();
            //HokanDs.Merge(result.ClaimDataSet);
            //HokanDs.AcceptChanges();

            // 発注/請求番号一覧 
            _dsClaim.ClaimNoData.Merge(result.ClaimDataSet.ClaimNoData);
            _dsClaim.ClaimNoData.AcceptChanges();

            // 請求データ 一覧 
            _dsClaim.ClaimData.Merge(result.ClaimDataSet.ClaimData);
            _dsClaim.ClaimData.AcceptChanges();

            // 発注/請求番号 差異一覧 
            // 並び変えを行いスプレッドにセットする 
            ClaimDSAcom.ClaimDiffDataDataTable dt = this.SetOrderForClaimDiff(result.ClaimDataSet.ClaimDiffData);
            _dsClaim.ClaimDiffData.Merge(dt);
            _dsClaim.ClaimDiffData.AcceptChanges();


            if (result.ClaimDataSet.ClaimData.Rows.Count == 0)
            {
                // データが存在しない場合は0を返す 
                return 0;
            }
            
            return result.ClaimDataSet.ClaimData.Rows.Count;
        }

        /// <summary>
        /// 発注/請求番号 差異一覧の並び順を設定するメソッド 
        /// </summary>
        /// <param name="resultDt">発注/請求番号 差異一覧情報</param>
        /// <returns>並び変えを行ったデータテーブル</returns>
        private ClaimDSAcom.ClaimDiffDataDataTable SetOrderForClaimDiff(ClaimDSAcom.ClaimDiffDataDataTable resultDt)
        {
            

            ClaimDSAcom.ClaimDiffDataDataTable dt = (ClaimDSAcom.ClaimDiffDataDataTable)resultDt;
            // クローンを生成 
            ClaimDSAcom.ClaimDiffDataDataTable newdt = (ClaimDSAcom.ClaimDiffDataDataTable)resultDt.Clone();

            // ソート実行 
            ClaimDSAcom.ClaimDiffDataRow[] drs;
            drs = (ClaimDSAcom.ClaimDiffDataRow[])dt.Select(string.Empty, dt.sortNoColumn.ColumnName);
            foreach (ClaimDSAcom.ClaimDiffDataRow row in drs)
            {
                newdt.ImportRow(row);
            }

            return newdt;
        }

        /// <summary>
        /// 発注/請求番号 差異一覧の背景色を設定するメソッド 
        /// </summary>
        private void SetBackColorForClaimDiff()
        {
            // 異なる項目があるデータの発注書NOと同じデータを検索 
            foreach (Row row in spdClaimDiff_Sheet1.Rows)
            {
                // 種別取得  
                string sybt = KKHUtility.ToString(spdClaimDiff_Sheet1.Cells[row.Index, ClaimDiffListColNo.SYBT].Value);

                if (SYBT_H.Equals(sybt))
                {
                    // 行の背景色を設定 
                    spdClaimDiff_Sheet1.Rows[row.Index].BackColor = KkhConstAcom.SpreadBackColor.C_BACK_COLOR_DGRAY;
                }

                // 最終行の場合は、以降の処理を行わない 
                if (row.Index == spdClaimDiff_Sheet1.RowCount - 1)
                {
                    break;
                }

                foreach (Column col in spdClaimDiff_Sheet1.Columns)
                {
                    // データ取得 
                    string value = spdClaimDiff_Sheet1.Cells[row.Index, col.Index].Text;
                    // データ取得（比較用） 
                    string value2 = spdClaimDiff_Sheet1.Cells[row.Index + 1, col.Index].Text;

                    // 種別の場合 
                    if (col.Index == ClaimDiffListColNo.SYBT)
                    {
                        // 以下の条件の場合、breakする 
                        if ((SYBT_S.Equals(value) && SYBT_S.Equals(value2)) ||
                            (SYBT_H.Equals(value) && SYBT_H.Equals(value2)) ||
                            (SYBT_S.Equals(value) && SYBT_H.Equals(value2)))
                        {
                            break;
                        }
                    }
                    // 商品区分の場合 
                    else if (col.Index == ClaimDiffListColNo.SYOHINKBN)
                    {
                        bool flg = false;

                        // NULL、空文字の場合 
                        if ((!string.IsNullOrEmpty(value) && string.IsNullOrEmpty(value2)) ||
                            (string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(value2)))
                        {
                            flg = true;
                        }
                        // 値が同一でない場合 
                        else if (!value.Substring(0, 2).Equals(value2.Substring(0, 2)))
                        {
                            flg = true;
                        }

                        if (flg)
                        {
                            // 異なる項目が存在するレコード種別を赤くする 
                            spdClaimDiff_Sheet1.Cells[row.Index + 1, col.Index].BackColor =
                                KkhConstAcom.SpreadBackColor.C_BACK_COLOR_LPINK;

                            // 異なる項目が存在するﾚｺｰﾄﾞ種別を赤くする(見やすいように媒体種別を赤くする) 
                            spdClaimDiff_Sheet1.Cells[row.Index + 1, ClaimDiffListColNo.SYBT].BackColor =
                                KkhConstAcom.SpreadBackColor.C_BACK_COLOR_LPINK;
                        }
                    }
                    // 発注番号、発注行番号、内容区分、摘要コード、 
                    // 媒体コード、メディアコード、金額、按分種別の場合 
                    else if (col.Index == ClaimDiffListColNo.IRAINO ||
                             col.Index == ClaimDiffListColNo.IRAIGYONO ||
                             col.Index == ClaimDiffListColNo.NAIYOKBN ||
                             col.Index == ClaimDiffListColNo.TEKIYOCD ||
                             col.Index == ClaimDiffListColNo.BAITAICD ||
                             col.Index == ClaimDiffListColNo.MEDIACD ||
                             col.Index == ClaimDiffListColNo.KINGAK ||
                             col.Index == ClaimDiffListColNo.ANBUNSYBT)
                    {
                        // 値が同一でない場合 
                        if (!value.Equals(value2))
                        {
                            // 異なる項目が存在するレコード種別を赤くする 
                            spdClaimDiff_Sheet1.Cells[row.Index + 1, col.Index].BackColor =
                                KkhConstAcom.SpreadBackColor.C_BACK_COLOR_LPINK;

                            // 異なる項目が存在するﾚｺｰﾄﾞ種別を赤くする(見やすいように媒体種別を赤くする) 
                            spdClaimDiff_Sheet1.Cells[row.Index + 1, ClaimDiffListColNo.SYBT].BackColor =
                                KkhConstAcom.SpreadBackColor.C_BACK_COLOR_LPINK;
                        }
                    }
                }
            }

        }

        /// <summary>
        /// 請求データ一覧の背景色を設定するメソッド 
        /// </summary>
        /// <param name="shoriKbnDict">処理区分リスト</param>
        private void SetBackColorForClaim(Dictionary<string, string> shoriKbnDict)
        {

            foreach (Row row in spdClaim_Sheet1.Rows)
            {
                // 請求書番号取得 
                string seiNo = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SEINO].Value);

                // 引数の処理区分リストに存在する場合 
                if (shoriKbnDict.ContainsKey(seiNo))
                {
                    // 背景色、処理区分を設定する 
                    if (ShoriKbnNm.MiSyutu.Equals(shoriKbnDict[seiNo]))
                    {
                        // 未出力 
                        // 背景色を設定する 
                        spdClaim_Sheet1.Rows[row.Index].BackColor = KkhConstAcom.SpreadBackColor.C_BACK_COLOR_WHITE;
                        // 処理区分に値を設定する 
                        spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SHORIKBNNM].Value = ShoriKbnNm.MiSyutu;
                    }
                    else if (ShoriKbnNm.MiSoushin.Equals(shoriKbnDict[seiNo]))
                    {
                        // 未送信 
                        // 背景色を設定する 
                        spdClaim_Sheet1.Rows[row.Index].BackColor = KkhConstAcom.SpreadBackColor.C_BACK_COLOR_WHITE;
                        // 処理区分に値を設定する 
                        spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SHORIKBNNM].Value = ShoriKbnNm.MiSoushin;
                    }
                    else if (ShoriKbnNm.SoushinZumi.Equals(shoriKbnDict[seiNo]))
                    {
                        // 送信済 
                        // 背景色を設定する 
                        spdClaim_Sheet1.Rows[row.Index].BackColor = KkhConstAcom.SpreadBackColor.C_BACK_COLOR_MROSE;
                        // 処理区分に値を設定する 
                        spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SHORIKBNNM].Value = ShoriKbnNm.SoushinZumi;
                    }
                    else if (ShoriKbnNm.IchbuSyutuZumi.Equals(shoriKbnDict[seiNo]))
                    {
                        // 一時送信済 
                        // 背景色を設定する 
                        spdClaim_Sheet1.Rows[row.Index].BackColor = KkhConstAcom.SpreadBackColor.C_BACK_COLOR_LYELLOW;
                        // 処理区分に値を設定する 
                        spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SHORIKBNNM].Value = ShoriKbnNm.IchbuSyutuZumi;
                    }
                }
            }

        }

        /// <summary>
        /// 発注/請求番号 一覧の背景色を設定するメソッド 
        /// </summary>
        /// <param name="shoriKbnDict">処理区分リスト</param>
        private void SetBackColorForClaimNo(Dictionary<string, string> shoriKbnDict)
        {

            foreach (Row row in spdClaimNo_Sheet1.Rows)
            {
                // 請求書番号取得 
                string seiNo = KKHUtility.ToString(spdClaimNo_Sheet1.Cells[row.Index, ClaimNoListColNo.SEINO].Value);

                // 引数の処理区分リストに存在する場合 
                if (shoriKbnDict.ContainsKey(seiNo))
                {
                    // 背景色、処理区分、出力選択を設定する 
                    if (ShoriKbnNm.MiSyutu.Equals(shoriKbnDict[seiNo]))
                    {
                        // 未出力 
                        // 背景色を設定する 
                        spdClaimNo_Sheet1.Rows[row.Index].BackColor = KkhConstAcom.SpreadBackColor.C_BACK_COLOR_WHITE;
                        spdClaimNo_Sheet1.Cells[row.Index, ClaimNoListColNo.SHORIKBN].Value = ShoriKbnNm.MiSyutu;
                        spdClaimNo_Sheet1.Cells[row.Index, ClaimNoListColNo.OUTSELECT].Value = "True";
                    }
                    else if (ShoriKbnNm.MiSoushin.Equals(shoriKbnDict[seiNo]))
                    {
                        // 未送信 
                        // 背景色を設定する 
                        spdClaimNo_Sheet1.Rows[row.Index].BackColor = KkhConstAcom.SpreadBackColor.C_BACK_COLOR_PBLUE;
                        spdClaimNo_Sheet1.Cells[row.Index, ClaimNoListColNo.SHORIKBN].Value = ShoriKbnNm.MiSoushin;
                    }
                    else if (ShoriKbnNm.SoushinZumi.Equals(shoriKbnDict[seiNo]))
                    {
                        // 送信済 
                        // 背景色を設定する 
                        spdClaimNo_Sheet1.Rows[row.Index].BackColor = KkhConstAcom.SpreadBackColor.C_BACK_COLOR_MROSE;
                        spdClaimNo_Sheet1.Cells[row.Index, ClaimNoListColNo.SHORIKBN].Value = ShoriKbnNm.SoushinZumi;
                    }
                    else if (ShoriKbnNm.IchbuSyutuZumi.Equals(shoriKbnDict[seiNo]))
                    {
                        // 一時送信済 
                        // 背景色を設定する 
                        spdClaimNo_Sheet1.Rows[row.Index].BackColor = KkhConstAcom.SpreadBackColor.C_BACK_COLOR_LYELLOW;
                        spdClaimNo_Sheet1.Cells[row.Index, ClaimNoListColNo.SHORIKBN].Value = ShoriKbnNm.IchbuSyutuZumi;
                        spdClaimNo_Sheet1.Cells[row.Index, ClaimNoListColNo.OUTSELECT].Value = "True";
                    }
                }
            }

        }

        /// <summary>
        /// 処理区分の判定処理を行うメソッド 
        /// </summary>
        /// <returns>処理結果</returns>
        private Dictionary<string, string> ShoriKbnCheck()
        {
            Dictionary<string, string> retDict = new Dictionary<string, string>();  // 処理区分リスト 
            string shoriKbnNm = ShoriKbnNm.MiSyutu;                                 // 処理区分 

            foreach (Row row in spdClaimNo_Sheet1.Rows)
            {
                // 処理区分取得 
                string shoriKbn = KKHUtility.ToString(spdClaimNo_Sheet1.Cells[row.Index, ClaimNoListColNo.SHORIKBN].Value);

                // 請求書番号取得 
                string key = KKHUtility.ToString(spdClaimNo_Sheet1.Cells[row.Index, ClaimNoListColNo.SEINO].Value);

                // リストに同一の請求書番号が存在する場合 
                if (retDict.ContainsKey(key))
                {
                    // リストを編集 
                    if (retDict[key].Equals(shoriKbnNm))
                    {
                        // リストで保持している値と同一の場合、値をそのまま代入する 
                        retDict[key] = shoriKbnNm;
                    }
                    else
                    {
                        // リストで保持している値と同一でない場合、「一部出力済」とする 
                        retDict[key] = ShoriKbnNm.IchbuSyutuZumi;
                    }
                }
                else
                {
                    // リストに追加 
                    retDict.Add(key, shoriKbn);
                }
            }

            return retDict;
        }

        /// <summary>
        /// 請求データ出力チェック（発注/請求番号 一覧）メソッド 
        /// ・チェックが全てＯＫの場合、引数の出力請求書番号リストに、 
        ///   発注/請求番号 一覧でチェックされた請求書番号をセットする 
        /// </summary>
        /// <param name="seiNoList">出力請求書番号リスト</param>
        /// <returns>処理結果</returns>
        private bool PutClimDataCheckClaimNo(out List<string> seiNoList)
        {
            seiNoList = new List<string>();    // 出力請求書番号リスト 
            bool selFlg = false;               // 請求済み選択フラグ 

            for (int iRow = 0; iRow <= spdClaimNo_Sheet1.RowCount - 1; iRow++)
            {
                string shoriKbn =
                    KKHUtility.ToString(spdClaimNo_Sheet1.Cells[iRow, ClaimNoListColNo.SHORIKBN].Value);   // 処理区分 
                string outSelect =
                    KKHUtility.ToString(spdClaimNo_Sheet1.Cells[iRow, ClaimNoListColNo.OUTSELECT].Value);  // 出力選択 

                // 出力選択が選択されている場合 
                if ("True".Equals(outSelect))
                {
                    string seiNo =
                        KKHUtility.ToString(spdClaimNo_Sheet1.Cells[iRow, ClaimNoListColNo.SEINO].Value);      // 請求書番号 

                    // 請求書番号チェック -----------------------------------------------------------------------------
                    for (int iRow2 = iRow + 1; iRow2 < spdClaimNo_Sheet1.RowCount; iRow2++)
                    {
                        string seiNo2 =
                            KKHUtility.ToString(spdClaimNo_Sheet1.Cells[iRow2, ClaimNoListColNo.SEINO].Value); // 請求書番号(比較用) 

                        // 請求書番号と請求書番号(比較用)が同じ場合、メッセージを表示し処理を終了する 
                        if (!string.IsNullOrEmpty(seiNo) &&
                            !string.IsNullOrEmpty(seiNo2) &&
                            seiNo.Equals(seiNo2))
                        {
                            MessageUtility.ShowMessageBox(MessageCode.HB_W0112, null, this.Text, MessageBoxButtons.OK);
                            return false;
                        }
                    }

                    //// 請求書番号入力チェック -------------------------------------------------------------------------
                    //if (string.IsNullOrEmpty(seiNo))
                    //{
                    //    MessageUtility.ShowMessageBox(MessageCode.HB_W0113, null, this.Text, MessageBoxButtons.OK);
                    //    return false;
                    //}

                    // 請求書番号桁数チェック -------------------------------------------------------------------------
                    if (seiNo.Length != 8)
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0114, null, this.Text, MessageBoxButtons.OK);
                        return false;
                    }

                    // 現行に合わせるためにあえて桁数チェックの後ろで行う.

                    // 請求書番号入力チェック -------------------------------------------------------------------------
                    if (string.IsNullOrEmpty(seiNo))
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0113, null, this.Text, MessageBoxButtons.OK);
                        return false;
                    }

                    // 出力選択チェック -------------------------------------------------------------------------------
                    // 未送信にチェックがついている場合 
                    if (ShoriKbnNm.MiSoushin.Equals(shoriKbn))
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0115, null, this.Text, MessageBoxButtons.OK);
                        return false;
                    }

                    // 出力済にチェックがついている場合 
                    if (ShoriKbnNm.SoushinZumi.Equals(shoriKbn))
                    {
                        selFlg = true;
                    }

                    // 請求書番号をリストに格納 
                    seiNoList.Add(seiNo);
                }
            }

            if (selFlg)
            {
                //メッセージを出力 
                if (DialogResult.No == MessageUtility.ShowMessageBox(MessageCode.HB_C0013, null, this.Text, MessageBoxButtons.YesNo))
                {
                    //「キャンセル」の場合、処理を終了する 
                    return false;
                }
            }

            // 出力選択が０件の場合、メッセージを表示し処理を終了する 
            if (seiNoList.Count == 0)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0116, null, this.Text, MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 請求データ出力チェック（請求データ 一覧）メソッド 
        /// </summary>
        /// <param name="seiNoList">出力請求書番号リスト</param>
        /// <returns>処理結果</returns>
        private bool PutClaimDataCheckClaim(List<string> seiNoList)
        {
            string seiNo = string.Empty;        // 請求書番号 
            string saveSeiNo = string.Empty;    // 請求書番号 
            string sybt = string.Empty;         // 種別 

            // 請求データ 一覧の入力値をチェックする 
            foreach (Row row in spdClaim_Sheet1.Rows)
            {
                seiNo = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SEINO].Value);  // 請求書番号                
                sybt = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SYBT].Value);    // 種別 

                if (!seiNoList.Contains(seiNo))
                {
                    // 対象外のデータの為、読み飛ばす 
                    continue;
                }

                // 取引先コード 
                string toriCd = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.TORICD].Value);
                if (string.IsNullOrEmpty(toriCd.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"取引先コード"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                // 会社名 
                string kaiNm = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.KAINM].Value);
                if (SYBT_T.Equals(sybt) && string.IsNullOrEmpty(kaiNm.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"会社名"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                // 請求部署コード 
                string seibuCd = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SEIBUCD].Value);
                if (SYBT_T.Equals(sybt) && string.IsNullOrEmpty(seibuCd.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"請求部署コード"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                // 請求年月日 
                string seiYymm = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SEIYYMM].Value);
                if (SYBT_T.Equals(sybt) && string.IsNullOrEmpty(seiYymm.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"請求書発行日"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }
                if (seiYymm.Length != 8 || !KKHUtility.IsDate(seiYymm, "yyyyMMdd"))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0118, new string[] {seiNo}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                // 請求書番号 
                if (string.IsNullOrEmpty(seiNo.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"請求書番号"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                // 請求書行番号 
                string seiGyoNo = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SEIGYONO].Value);
                if (!SYBT_T.Equals(sybt) && string.IsNullOrEmpty(seiGyoNo.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"請求書行番号"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                // 支払日 
                string payDay = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.PAYDAY].Value);
                if (SYBT_T.Equals(sybt) && string.IsNullOrEmpty(payDay.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"支払日"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                // 商品区分 
                string syohinKbn = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SYOHINKBN].Value);
                if (SYBT_T.Equals(sybt) && string.IsNullOrEmpty(syohinKbn.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"商品区分"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                // 商品区分名称 
                string syohinKbnNm = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SYOHINKBNNM].Value);
                if (SYBT_T.Equals(sybt) && string.IsNullOrEmpty(syohinKbnNm.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"商品区分名称"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                // 摘要コード 
                string tekiyoCd = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.TEKIYOCD].Value);
                if (SYBT_S.Equals(sybt) && string.IsNullOrEmpty(tekiyoCd.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"摘要コード"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                // 媒体コード 
                string baitaiCd = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.BAITAICD].Value);
                if (SYBT_S.Equals(sybt) && string.IsNullOrEmpty(baitaiCd.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"媒体コード"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                // メディアコード 
                string mediaCd = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.MEDIACD].Value);
                if (SYBT_S.Equals(sybt) && string.IsNullOrEmpty(mediaCd.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"メディアコード"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                if (!string.IsNullOrEmpty(saveSeiNo) && seiNo.Equals(saveSeiNo))
                {
                    // 金額 
                    decimal kingak = KKHUtility.DecParse(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.KINGAK].Text);
                    if (SYBT_H.Equals(sybt))
                    {
                        kingak = 0M;
                    }
                    if (kingak == 0M)
                    {
                        // メッセージを出力 
                        if (DialogResult.Cancel == MessageUtility.ShowMessageBox(MessageCode.HB_C0012
                                                                                , new string[] { seiNo, "金額" }
                                                                                , this.Text
                                                                                , MessageBoxButtons.OKCancel))
                        {
                            //「キャンセル」の場合、処理を終了する 
                            return false;
                        }
                    }

                    // 消費税 
                    decimal syohiZei = KKHUtility.DecParse(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SYOHIZEI].Text);
                    if (SYBT_H.Equals(sybt))
                    {
                        syohiZei = 0M;
                    }
                    if (syohiZei == 0M)
                    {
                        // メッセージを出力 
                        if (DialogResult.Cancel == MessageUtility.ShowMessageBox(MessageCode.HB_C0012
                                                                                , new string[] { seiNo, "消費税" }
                                                                                , this.Text
                                                                                , MessageBoxButtons.OKCancel))
                        {
                            //「キャンセル」の場合、処理を終了する 
                            return false;
                        }
                    }
                }

                // 按分種別 
                string anbunSybt = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.ANBUNSYBT].Value);
                if (SYBT_S.Equals(sybt) && string.IsNullOrEmpty(anbunSybt.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"按分種別"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                // 登録年月日 
                string touDate = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.TOUDATE].Value);
                if (SYBT_S.Equals(sybt) && string.IsNullOrEmpty(touDate.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"登録年月日"}, this.Text, MessageBoxButtons.OK);
                    return false;
                }

                // 請求書番号を保持 
                saveSeiNo = seiNo;
            }

            return true;
        }

        /// <summary>
        /// 請求データ出力メソッド 
        /// </summary>
        /// <param name="seiNoList">請求書番号リスト</param>
        /// <param name="cancelState"></param>
        /// <returns>出力結果</returns>
        private bool PutClaimData(List<string> seiNoList, out Boolean cancelState)
        {
            cancelState = false;

            bool ret = false;

            // 帳票設定情報取得 (テンプレート保存場所、パスワード等） 
            Common.KKHSchema.Common.SystemCommonRow repInfo = this.GetReportInfo();

            // SaveFileDialogクラスのインスタンスを作成 
            SaveFileDialog sfd = new SaveFileDialog();

            // はじめのファイル名を指定する 
            sfd.FileName = repInfo.field3 + CLAIM_SFD_EXT;

            // はじめに表示されるフォルダを指定する 
            sfd.InitialDirectory = repInfo.field2;

            // [ファイルの種類]に表示される選択肢を指定する 
            sfd.Filter = CLAIM_SFD_FILTER;

            // [ファイルの種類]ではじめに 
            // 「すべてのファイル」が選択されているようにする 
            sfd.FilterIndex = 0;

            // タイトルを設定する 
            sfd.Title = CLAIM_SFD_TITLE;

            // ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする 
            sfd.RestoreDirectory = true;

            // ダイアログを表示する 
            DialogResult result = sfd.ShowDialog();

            if (result == DialogResult.OK)
            {
                //*************************************
                // 出力実行 
                //*************************************
                ret = this.OutFile(sfd.FileName, seiNoList);
            }
            else if (result == DialogResult.Cancel)
            {
                cancelState = true;
            }

            sfd.Dispose();

            return ret;
        }

        /// <summary>
        /// 帳票出力設定情報取得メソッド 
        /// </summary>
        /// <returns>帳票出力設定情報</returns>
        private Common.KKHSchema.Common.SystemCommonRow GetReportInfo()
        {
            Common.KKHSchema.Common.SystemCommonRow ret;
            CommonProcessController commonProcessController = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult;

            // 帳票設定情報取得 
            comResult = commonProcessController.FindCommonByCond(_naviParameter.strEsqId,
                                                                _naviParameter.strEgcd,
                                                                _naviParameter.strTksKgyCd,
                                                                _naviParameter.strTksBmnSeqNo,
                                                                _naviParameter.strTksTntSeqNo,
                                                                Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.ReportType,
                                                                SYSTEM_KEY_SAVEFILE_PATH);

            if (comResult.CommonDataSet.SystemCommon.Count != 0)
            {
                ret = comResult.CommonDataSet.SystemCommon[0];
            }
            else
            {
                // 取得できなかった場合はデフォルト値を設定 
                Common.KKHSchema.Common.SystemCommonDataTable dt =
                    new Common.KKHSchema.Common.SystemCommonDataTable();
                ret = (Common.KKHSchema.Common.SystemCommonRow)dt.NewRow();

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ret[i] = string.Empty;
                }

                // 以下、空文字以外をデフォルト値として設定 
                ret.field2 = CLAIM_SFD_INITDIRTMP;      // 保存先パス 
                ret.field3 = CLAIM_SFD_FILENAME;        // ファイル名 
            }

            return ret;
        }   

        /// <summary>
        /// 請求データ出力メソッド 
        /// </summary>
        /// <param name="fileName">ファイル</param>
        /// <param name="seiNoList">出力請求書番号リスト</param>
        /// <returns>処理結果</returns>
        private bool OutFile(string fileName, List<string> seiNoList)
        {
            bool ret = false;
            int rowCount = 0;

            try
            {
                // 保存ファイルと同じ名前のファイルが存在する場合 
                if (File.Exists(fileName))
                {
                    if (File.Exists(fileName + "copy"))
                    {
                        File.Delete(fileName + "copy");
                    }

                    // ファイルを一時退避する 
                    File.Copy(fileName, fileName + "copy");
                }

                using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.GetEncoding("shift_jis")))
                {
                    // 請求データより、出力請求書番号リストの請求書番号と一致するデータ取得 
                    ClaimDSAcom.ClaimDataDataTable dt = new ClaimDSAcom.ClaimDataDataTable();

                    // フィルタ設定 
                    StringBuilder filter = new StringBuilder();
                    foreach (string seiNo in seiNoList)
                    {
                        if (string.IsNullOrEmpty(filter.ToString()))
                        {
                            filter.Append(dt.seiNoColumn.ColumnName + " = '" + seiNo + "'");
                        }
                        else
                        {
                            filter.Append(" OR " + dt.seiNoColumn.ColumnName + " = '" + seiNo + "'");
                        }
                    }

                    // データ出力順にソートする
                    dt = SortForOutFile(_dsClaim.ClaimData);

                    // データ取得 
                    ClaimDSAcom.ClaimDataRow[] drs = (ClaimDSAcom.ClaimDataRow[])dt.Select(filter.ToString(), "");

                    foreach (ClaimDSAcom.ClaimDataRow row in drs)
                    {
                        StringBuilder sb = new StringBuilder();     // 出力用文字列の生成 
                        string tmp = string.Empty;                  // 出力データ一時保持用 
                        string sybt = row.sybt;                     // 種別 
                        string baitaiCd = row.baitaiCd;             // 媒体コード 

                        rowCount += 1;

                        #region ファイル出力.

                        //  1.依頼番号 ------------------------------------------------------------------------------------
                        if (SYBT_S.Equals(sybt))
                        {
                            tmp = row.iraiNo;
                        }
                        // 半角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "依頼番号"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.IRAINO));

                        //  2.依頼行番号 ----------------------------------------------------------------------------------
                        // 合計行の場合 
                        if (SYBT_T.Equals(sybt))
                        {
                            tmp = "000";
                        }
                        else
                        {
                            tmp = KKHUtility.DecParse(row.iraiGyoNo).ToString("000");
                        }
                        // 半角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "依頼行番号"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue("+" + tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.IRAIGYONO));

                        //  3.取引先コード --------------------------------------------------------------------------------
                        tmp = row.toriCd;
                        // 半角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "取引先コード"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.TORICD));

                        //  4.会社名 --------------------------------------------------------------------------------------
                        tmp = row.kaiNm;
                        // 全角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "会社名"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.KAINM));

                        //  5.請求部署コード ------------------------------------------------------------------------------
                        tmp = row.seibuCd;
                        // 半角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "請求部署コード"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.SEIBUCD));

                        //  6.売上部署コード ------------------------------------------------------------------------------
                        tmp = string.Empty;
                        // 半角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "売上部署コード"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.URIBUCD));

                        //  7.請求年月日 ----------------------------------------------------------------------------------
                        tmp = row.seiYymm;
                        // 半角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "請求年月日"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.SEIYYMM));

                        //  8.請求書番号 ----------------------------------------------------------------------------------
                        tmp = row.seiNo;
                        // 数値チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU, rowCount, "請求年月日"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU, ClaimDataItemLength.SEINO));

                        //  9.内容区分 ------------------------------------------------------------------------------------
                        tmp = row.naiyoKbn;
                        // 半角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "内容区分"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.NAIYOKBN));

                        // 10.値引行区分 ----------------------------------------------------------------------------------
                        tmp = row.nebiKbn;
                        // 半角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "値引行区分"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.NEBIKBN));

                        // 11.請求書行番号 --------------------------------------------------------------------------------
                        if (SYBT_T.Equals(sybt))
                        {
                            tmp = "000";
                        }
                        else
                        {
                            tmp = KKHUtility.DecParse(row.seiGyoNo).ToString("000");
                        }
                        // 数値チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU, rowCount, "請求年月日"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue("+" + tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU, ClaimDataItemLength.SEIGYONO));

                        // 12.支払日 --------------------------------------------------------------------------------------
                        tmp = row.payDay;
                        // 半角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "支払日"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.PAYDAY));

                        // 13.課税区分 ------------------------------------------------------------------------------------
                        tmp = string.Empty;
                        // 追加 
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.KAZEIKBN));

                        // 14.売上区分 ------------------------------------------------------------------------------------
                        tmp = string.Empty;
                        // 追加 
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.URIKBN));

                        // 15.売上区分名称 --------------------------------------------------------------------------------
                        tmp = string.Empty;
                        // 追加 
                        sb.Append(tmp.PadLeft(( ClaimDataItemLength.URIKBNNM / 2 ), '　'));

                        // 16.商品区分 ------------------------------------------------------------------------------------
                        tmp = row.syohinKbn;
                        if (tmp.Length < ClaimDataItemLength.SYOHINKBN)
                        {
                            if (tmp.Length < ClaimDataItemLength.SYOHINKBN - 1)
                            {
                                // 細目区分が存在する場合、末尾に追加する 
                                if (!string.IsNullOrEmpty(row.saimokuKbn))
                                {
                                    sb.Append(tmp + row.saimokuKbn);
                                }
                                else
                                {
                                    string space = string.Empty;
                                    sb.Append(tmp + space.PadLeft(1));
                                }
                            }
                            else
                            {
                                string space = string.Empty;
                                sb.Append(tmp + space.PadLeft(ClaimDataItemLength.SYOHINKBN - tmp.Length));
                            }
                        }
                        else
                        {
                            sb.Append(tmp.Substring(0, ClaimDataItemLength.SYOHINKBN));
                        }

                        // 17.商品区分名称 --------------------------------------------------------------------------------
                        tmp = row.syohinKbnNm;
                        // 全角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "商品区分名称"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.SYOHINKBNNM));

                        // 18.摘要コード ----------------------------------------------------------------------------------
                        tmp = row.tekiyoCd;
                        // 半角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "摘要コード"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.TEKIYOCD));

                        // 19.媒体コード ----------------------------------------------------------------------------------
                        tmp = row.baitaiCd;
                        // 半角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "媒体コード"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.BAITAICD));

                        // 20.メディアコード ------------------------------------------------------------------------------
                        tmp = row.mediaCd;
                        // 半角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "メディアコード"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.MEDIACD));

                        // 21.地区部署コード ------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.TIKBUSCD));

                        // 22.店番 ----------------------------------------------------------------------------------------
                        tmp = row.tenBan;
                        // 半角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "店番"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.TENBAN));

                        // 23.明細コード１ --------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.MEISAICD1));

                        // 24.明細名称１ ----------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(( ClaimDataItemLength.MEISAINM1 / 2 ), '　'));

                        // 25.明細コード２ --------------------------------------------------------------------------------
                        // 電波、新聞の場合 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd) ||
                            KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd))
                        {
                            tmp = string.Empty;
                        }
                        // 雑誌の場合 
                        else if (KkhConstAcom.MediaKindCode.SYBT_ZASI.Equals(baitaiCd))
                        {
                            // 色刷コード 
                            tmp = row.sisaCd;
                        }
                        // 交通の場合 
                        else if (KkhConstAcom.MediaKindCode.SYBT_KOTU.Equals(baitaiCd))
                        {
                            // 交通掲載コード 
                            tmp = row.kotukeiCd;
                        }

                        // 半角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "明細コード２"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.MEISAICD2));

                        // 26.明細名称２ ----------------------------------------------------------------------------------
                        // 電波、新聞の場合 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd) ||
                            KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd))
                        {
                            tmp = string.Empty;
                        }
                        // 雑誌の場合 
                        else if (KkhConstAcom.MediaKindCode.SYBT_ZASI.Equals(baitaiCd))
                        {
                            // 色刷名称 
                            tmp = row.sisaNm;
                        }
                        // 交通の場合 
                        else if (KkhConstAcom.MediaKindCode.SYBT_KOTU.Equals(baitaiCd))
                        {
                            // 交通掲載名称 
                            tmp = row.kotukeiNm;
                        }

                        // 全角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "明細名称２"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM2));

                        // 27.明細コード３ --------------------------------------------------------------------------------
                        // 電波の場合 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // 形態区分コード 
                            tmp = row.keitaiKbnCd;
                        }
                        // 雑誌の場合 
                        else if (KkhConstAcom.MediaKindCode.SYBT_ZASI.Equals(baitaiCd))
                        {
                            // サイズコード 
                            tmp = row.sizeCd;
                        }
                        // 新聞の場合 
                        else if (KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd))
                        {
                            // 掲載場所コード 
                            tmp = row.keisaiBasCd;
                        }
                        // 交通の場合 
                        else if (KkhConstAcom.MediaKindCode.SYBT_KOTU.Equals(baitaiCd))
                        {
                            tmp = string.Empty;
                        }

                        // 半角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "明細コード３"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.MEISAICD3));

                        // 28.明細名称３ ----------------------------------------------------------------------------------
                        // 電波の場合 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // 形態区分名称 
                            tmp = row.keitaiKbnNm;
                        }
                        // 雑誌の場合 
                        else if (KkhConstAcom.MediaKindCode.SYBT_ZASI.Equals(baitaiCd))
                        {
                            // サイズ名称 
                            tmp = row.sizeNm;
                        }
                        // 新聞の場合 
                        else if (KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd))
                        {
                            // 掲載場所名称 
                            tmp = row.keisaiBasNm;
                        }
                        // 交通の場合 
                        else if (KkhConstAcom.MediaKindCode.SYBT_KOTU.Equals(baitaiCd))
                        {
                            tmp = string.Empty;
                        }

                        // 全角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "明細名称３"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM3));

                        // 29.明細コード４ --------------------------------------------------------------------------------
                        // 新聞の場合 
                        if (KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd))
                        {
                            // 種別1コード 
                            tmp = row.sybt1Cd;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // 半角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "明細コード４"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.MEISAICD4));

                        // 30.明細名称４ ----------------------------------------------------------------------------------
                        // 電波の場合 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // CM秒数名1 
                            tmp = row.cm1;
                        }
                        // 新聞の場合 
                        else if (KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd))
                        {
                            // 種別1名称 
                            tmp = row.sybt1Nm;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // 全角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "明細名称４"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM4));

                        // 31.明細コード５ --------------------------------------------------------------------------------
                        // 新聞の場合 
                        if (KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd))
                        {
                            // 種別2コード 
                            tmp = row.sybt2Cd;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // 半角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "明細コード５"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.MEISAICD5));

                        // 32.明細名称５ ----------------------------------------------------------------------------------
                        // 電波の場合 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // 内容名称1 
                            tmp = row.name1;
                        }
                        // 新聞の場合 
                        else if (KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd))
                        {
                            // 種別2名称 
                            tmp = row.sybt2Nm;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // 全角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "明細名称５"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM5));

                        // 33.明細コード６ --------------------------------------------------------------------------------
                        // 新聞の場合 
                        if (KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd))
                        {
                            // 色刷コード 
                            tmp = row.sisaCd;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // 半角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "明細コード６"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.MEISAICD6));

                        // 34.明細名称６ ----------------------------------------------------------------------------------
                        // 電波の場合 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // CM秒数名2 
                            tmp = row.cm2;
                        }
                        // 新聞の場合 
                        else if (KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd))
                        {
                            // 色刷名称 
                            tmp = row.sisaNm;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // 全角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "明細名称６"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM6));

                        // 35.明細コード７ --------------------------------------------------------------------------------
                        // 新聞の場合 
                        if (KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd))
                        {
                            // サイズコード 
                            tmp = row.sizeCd;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // 半角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "明細コード７"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.MEISAICD7));

                        // 36.明細名称７ ----------------------------------------------------------------------------------
                        // 電波の場合 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // 内容名称2 
                            tmp = row.name2;
                        }
                        // 新聞の場合 
                        else if (KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd))
                        {
                            // サイズ名称 
                            tmp = row.sizeNm;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // ※全角半角混在（チェックなし） 
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_NONE, ClaimDataItemLength.MEISAINM7));

                        // 37.明細コード８ --------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.MEISAICD8));

                        // 38.明細名称８ ----------------------------------------------------------------------------------
                        // 電波の場合 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // CM秒数名3 
                            tmp = row.cm3;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // 全角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "明細名称８"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM8));

                        // 39.明細コード９ --------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.MEISAICD9));

                        // 40.明細名称９ ----------------------------------------------------------------------------------
                        // 電波の場合 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // 内容名称3 
                            tmp = row.name3;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // 全角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "明細名称９"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM9));

                        // 41.明細コード１０ ------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.MEISAICD10));

                        // 42.明細名称１０ --------------------------------------------------------------------------------
                        // 電波の場合 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // CM秒数名4 
                            tmp = row.cm4;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // 全角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "明細名称１０"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM10));

                        // 43.明細名称１１ --------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(( ClaimDataItemLength.MEISAINM11 / 2 ), '　'));

                        // 44.明細名称１２ --------------------------------------------------------------------------------
                        // 電波の場合 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // 内容名称4 
                            tmp = row.name4;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // 全角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "明細名称１２"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM12));

                        // 45.明細名称１３ --------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.MEISAINM13));

                        // 46.明細名称１４ --------------------------------------------------------------------------------
                        // 電波の場合 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // 番組名1 
                            tmp = row.bngm1;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // 全角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "明細名称１４"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM14));

                        // 47.明細名称１５ --------------------------------------------------------------------------------
                        // 備考１ 
                        tmp = row.biko1;
                        // 全角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "明細名称１５"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM15));

                        // 48.明細名称１６ --------------------------------------------------------------------------------
                        // 備考２ 
                        tmp = row.biko2;
                        // 全角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "明細名称１６"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM16));

                        int count = 0;
                        // 49.明細名称１７ --------------------------------------------------------------------------------
                        tmp = string.Empty;
                        if (SYBT_S.Equals(sybt))
                        {
                            // 新聞の場合 
                            if (KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd))
                            {
                                if (0 < row.keisaiDay.Split(',').Length)
                                {
                                    // 掲載日 
                                    foreach (string str in row.keisaiDay.Split(','))
                                    {
                                        if (!string.IsNullOrEmpty(str.Trim()))
                                        {
                                            tmp += str;
                                            // 回数をカウント 
                                            count += 1;
                                        }
                                        else
                                        {
                                            tmp += "0";
                                        }
                                    }
                                }
                                string space = string.Empty;
                                sb.Append(tmp + space.PadLeft(35));

                            }
                            // 雑誌の場合 
                            else if (KkhConstAcom.MediaKindCode.SYBT_ZASI.Equals(baitaiCd))
                            {
                                // 掲載日 
                                string[] keisaiArr = row.keisaiDay.Split(',');
                                if (5 < keisaiArr.Length)
                                {
                                    for (int i = 0; i < 6; i++)
                                    {
                                        if (!string.IsNullOrEmpty(keisaiArr[i].Trim()))
                                        {
                                            string space = string.Empty;
                                            tmp += keisaiArr[i].Trim() + space.PadLeft(1);

                                            // 回数をカウント 
                                            count += 1;
                                        }
                                        else
                                        {
                                            string space = string.Empty;
                                            tmp += keisaiArr[i] + space.PadLeft(9);
                                        }
                                    }
                                }
                                string space2 = string.Empty;
                                sb.Append(tmp + space2.PadLeft(ClaimDataItemLength.MEISAINM17 - tmp.Length));

                            }
                            // 交通の場合 
                            else if (KkhConstAcom.MediaKindCode.SYBT_KOTU.Equals(baitaiCd))
                            {
                                tmp = row.kikan;
                                sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_NONE, ClaimDataItemLength.MEISAINM17));
                            }
                            else
                            {
                                tmp = string.Empty;
                                sb.Append(tmp.PadLeft(ClaimDataItemLength.MEISAINM17));
                            }
                        }
                        else
                        {
                            tmp = string.Empty;
                            sb.Append(tmp.PadLeft(ClaimDataItemLength.MEISAINM17));
                        }

                        // 50.明細名称１８ --------------------------------------------------------------------------------
                        // 新聞、雑誌の場合 
                        if (KkhConstAcom.MediaKindCode.SYBT_SNBN.Equals(baitaiCd) ||
                            KkhConstAcom.MediaKindCode.SYBT_ZASI.Equals(baitaiCd))
                        {
                            tmp = count.ToString("00");
                        }
                        // 交通の場合 
                        else if (KkhConstAcom.MediaKindCode.SYBT_KOTU.Equals(baitaiCd))
                        {
                            tmp = "00" + row.keisaiSu;
                            tmp = tmp.Substring(tmp.Length - 2, 2);
                        }
                        else
                        {
                            tmp = "00";
                        }

                        // 数値チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU, rowCount, "明細名称１８"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue("+" + tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU, ClaimDataItemLength.MEISAINM18));

                        // 51.明細名称１９ --------------------------------------------------------------------------------
                        tmp = "+00000000000";
                        // 追加 
                        sb.Append(tmp);

                        // 52.明細名称２０ --------------------------------------------------------------------------------
                        tmp = "+000.00000";
                        // 追加 
                        sb.Append(tmp);

                        // 53.明細名称２１ --------------------------------------------------------------------------------
                        tmp = "+00000000000";
                        // 追加 
                        sb.Append(tmp);

                        // 54.明細名称２２ --------------------------------------------------------------------------------
                        tmp = "+000000000.00";
                        // 追加 
                        sb.Append(tmp);

                        // 55.明細名称２３ --------------------------------------------------------------------------------
                        // 電波の場合 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // 番組名称2 
                            tmp = row.bngm2;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // 全角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "明細名称２３"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM23));

                        // 56.明細名称２４ --------------------------------------------------------------------------------
                        // 電波の場合 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // 番組名称3 
                            tmp = row.bngm3;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // 全角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "明細名称２４"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM24));

                        // 57.明細名称２５ --------------------------------------------------------------------------------
                        // 電波の場合 
                        if (KkhConstAcom.MediaKindCode.SYBT_DENP.Equals(baitaiCd))
                        {
                            // 番組名称4 
                            tmp = row.bngm4;
                        }
                        else
                        {
                            tmp = string.Empty;
                        }

                        // 全角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, rowCount, "明細名称２５"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK, ClaimDataItemLength.MEISAINM25));

                        // 58.数量 ----------------------------------------------------------------------------------------
                        sb.Append("+000000000.00");

                        // 59.単価 ----------------------------------------------------------------------------------------
                        decimal tanka = KKHUtility.DecParse(row.keisaiTnk);
                        if (tanka == 0M)
                        {
                            tmp = "+000000000.00";
                        }
                        else if (tanka < 0M)
                        {
                            tmp = tanka.ToString("000000000") + ".00";
                        }
                        else
                        {
                            tmp = "+" + tanka.ToString("000000000") + ".00";
                        }

                        // 数値チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU, rowCount, "単価"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU);
                        }
                        // 追加 
                        sb.Append(tmp);

                        // 60.JLA金額 -------------------------------------------------------------------------------------
                        decimal kingak = row.kingak;
                        if (SYBT_H.Equals(sybt))
                        {
                            tmp = "+0000000000000";
                        }
                        else if (kingak < 0M)
                        {
                            tmp = kingak.ToString("0000000000000");
                        }
                        else
                        {
                            tmp = "+" + kingak.ToString("0000000000000");
                        }

                        // 数値チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU, rowCount, "JLA金額"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU);
                        }
                        // 追加 
                        sb.Append(tmp);

                        // 61.JLA消費税 -----------------------------------------------------------------------------------
                        decimal syohizei = row.syohizei;
                        if (SYBT_H.Equals(sybt))
                        {
                            tmp = "0000000000000";
                        }
                        else if (syohizei < 0M)
                        {
                            tmp = syohizei.ToString("0000000000000");
                        }
                        else
                        {
                            tmp = "+" + syohizei.ToString("0000000000000");
                        }

                        // 数値チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU, rowCount, "JLA消費税"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU);
                        }
                        // 追加 
                        sb.Append(tmp);

                        // 62.JLA合計金額 ---------------------------------------------------------------------------------
                        decimal goukei = row.kingakSum;
                        if (SYBT_H.Equals(sybt))
                        {
                            tmp = "0000000000000";
                        }
                        else if (goukei < 0M)
                        {
                            tmp = goukei.ToString("0000000000000");
                        }
                        else
                        {
                            tmp = "+" + goukei.ToString("0000000000000");
                        }

                        // 数値チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU, rowCount, "JLA合計金額"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_SU);
                        }
                        // 追加 
                        sb.Append(tmp);

                        // 63.処理区分 ------------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.SHORIKBN));

                        // 64.処理番号 ------------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.SHORINO));

                        // 65.按分種別 ------------------------------------------------------------------------------------
                        tmp = row.anbunSybt;
                        // 半角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "按分種別"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.ANBUNSYBT));

                        // 66.按分パターン --------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.ANBUNPATTERN));

                        // 67.入力処理区分 --------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.INSHORIKBN));

                        // 68.プログラムＩＤ ------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.PRGID));

                        // 69.端末ＩＤ ------------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.PCID));

                        // 70.入力部署コード ------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.INBUSCD));

                        // 71.入力担当者コード ----------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.INUSERCD));

                        // 72.入力年月 ------------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.INYYMM));

                        // 73.入力時間 ------------------------------------------------------------------------------------
                        tmp = string.Empty;
                        sb.Append(tmp.PadLeft(ClaimDataItemLength.INTIME));

                        // 74.登録年月日 ----------------------------------------------------------------------------------
                        if (SYBT_T.Equals(sybt))
                        {
                            tmp = String.Empty;

                            // 同一請求書番号から一番早い登録日を算出する.

                            // 同一請求書番号が見つかるまでループ.
                            for( int i1 = 0; i1 < drs.Length; i1++ )
                            {
                                if( row.seiNo != drs[ i1 ].seiNo )
                                {
                                    continue;
                                }

                                // 別の請求書番号が見つかるまでループ.
                                for( int i2 = i1; i2 < drs.Length; i2++ )
                                {
                                    if( row.seiNo != drs[ i2 ].seiNo )
                                    {
                                        break;
                                    }

                                    if (( String.IsNullOrEmpty(tmp) || ( String.Compare(tmp, drs[i2].touDate) > 0 ) ) && ( !String.IsNullOrEmpty(drs[i2].touDate) ))
                                    {
                                        tmp = drs[i2].touDate;
                                    }
                                }

                                break;
                            }
                        }
                        else
                        {
                            tmp = row.touDate;
                        }

                        // 半角チェック 
                        if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "登録年月日"))
                        {
                            throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.TOUDATE));

                        // 75.変更年月日 ----------------------------------------------------------------------------------
                        tmp = string.Empty;
                        if (SYBT_S.Equals(sybt))
                        {
                            tmp = row.henDate;
                            // 半角チェック 
                            if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "変更年月日"))
                            {
                                throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                            }
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.HENDATE));

                        // 76.取消年月日 ----------------------------------------------------------------------------------
                        tmp = string.Empty;
                        if (SYBT_S.Equals(sybt))
                        {
                            tmp = row.torDate;
                            // 半角チェック 
                            if (!this.ZokuseiCheck(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, rowCount, "取消年月日"))
                            {
                                throw new CheckException(rowCount, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK);
                            }
                        }
                        // 追加 
                        sb.Append(this.SetStringValue(tmp, KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK, ClaimDataItemLength.TORDATE));

                        // ファイルに書き込む 
                        sw.WriteLine(sb.ToString());

                        #endregion ファイル出力
                    }
                }

                ret = true;
            }
            catch (CheckException cex)
            {
                ret = false;

                if (File.Exists(fileName + "copy"))
                {
                    // 一時退避ファイルを元のファイル名で置き換える 
                    File.Delete(fileName);
                    File.Move(fileName + "copy", fileName);
                }

                String m = String.Empty;

                m += "出力形式チェックエラー" + " ";
                m += "カラム名：" + spdClaimNo_Sheet1.Columns[cex.Index].Label + " ";

                if (cex.Type == KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK)
                {
                    m += "タイプ：全角";
                }
                else if (cex.Type == KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK)
                {
                    m += "タイプ：半角";
                }
                else if (cex.Type == KkhConstAcom.AttributeCheckType.CHECKTYPE_SU)
                {
                    m += "タイプ：数値";
                }

                // 出力履歴の登録.
                this.RegistLog("送信", this.Text, m, "メール", "1");
            }
            catch (Exception)
            {
                ret = false;

                if (File.Exists(fileName + "copy"))
                {
                    // 一時退避ファイルを元のファイル名で置き換える 
                    File.Delete(fileName);
                    File.Move(fileName + "copy", fileName);
                }
            }
            finally
            {
                if (File.Exists(fileName + "copy"))
                {
                    // 一時退避ファイルを削除する  
                    File.Delete(fileName + "copy");
                    //// 一時退避ファイルを元のファイル名で置き換える 
                    //File.Delete(fileName);
                    //File.Move(fileName + "copy", fileName);
                }
            }

            return ret;
        }

        /// <summary>
        /// 出力データを設定するメソッド 
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="checkType">チェックタイプ(全角・半角・数値・チェック無し)</param>
        /// <param name="len">長さ</param>
        /// <returns>編集した値</returns>
        private string SetStringValue(string value, int checkType, int len)
        {
            string ret = string.Empty;
            int valueLen = KKHUtility.GetByteCount(value);

            if (valueLen < len)
            {
                // 引数で指定された長さに満たない場合、不足分を空白で埋める 
                string space = string.Empty;

                if (checkType == KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK)
                {
                    ret = value + space.PadLeft(( len - valueLen ) / 2, '　');
                }
                else if (checkType == KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK)
                {
                    ret = value + space.PadLeft(len - valueLen, ' ');
                }
                else if (checkType == KkhConstAcom.AttributeCheckType.CHECKTYPE_SU)
                {
                    ret = value + space.PadLeft(len - valueLen, ' ');
                }
                else if (checkType == KkhConstAcom.AttributeCheckType.CHECKTYPE_NONE)
                {
                    ret = value + space.PadLeft(len - valueLen, ' ');
                }
            }
            else
            {
                // 引数で指定された文字数分を返却する 
                ret = KKHUtility.GetByteString(value, len);
            }

            return ret;
        }

        /// <summary>
        /// データの属性チェックメソッド 
        /// チェックエラーの場合メッセージを表示する 
        /// </summary>
        /// <param name="checkData">チェック対象データ</param>
        /// <param name="checkType">チェックタイプ(全角・半角・数値・チェック無し)</param>
        /// <param name="rowNo">行番号</param>
        /// <param name="colName">項目名</param>
        /// <returns>処理結果</returns>
        private bool ZokuseiCheck(object checkData, int checkType, int rowNo, string colName)
        {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            string zokusei = string.Empty;
            bool result = false;

            // 全角チェック 
            if (checkType == KkhConstAcom.AttributeCheckType.CHECKTYPE_ZNKK)
            {
                zokusei = "全角";
                int num = sjisEnc.GetByteCount(checkData.ToString());
                result = (num == checkData.ToString().Length * 2);
            }

            // 半角チェック 
            else if (checkType == KkhConstAcom.AttributeCheckType.CHECKTYPE_HNKK)
            {
                zokusei = "半角";
                int num = sjisEnc.GetByteCount(checkData.ToString());
                result = (num == checkData.ToString().Length);
            }

            // 数値チェック 
            else if (checkType == KkhConstAcom.AttributeCheckType.CHECKTYPE_SU)
            {
                zokusei = "数値以外";
                result = KKHUtility.IsNumeric(checkData.ToString());
            }

            // チェックエラーの場合 
            if (!result)
            {
                // メッセージを表示 
                MessageUtility.ShowMessageBox(MessageCode.HB_W0119
                                            , new string[] { rowNo.ToString(), colName, zokusei }
                                            , this.Text
                                            , MessageBoxButtons.OK);
            }

            return result;
        }

        /// <summary>
        /// 送信フラグ更新メソッド 
        /// </summary>
        /// <param name="seiNoList">出力請求書番号リスト</param>
        /// <returns>処理結果</returns>
        private bool UpdateOutFlg(List<string> seiNoList)
        {
            ClaimAcomProcessController.UpdateOutFlgParam param =
                new ClaimAcomProcessController.UpdateOutFlgParam();

            // 送信フラグ更新パラメータ設定 
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;      // ログイン担当者ESQID 
            param.egCd = _naviParameter.strEgcd;                        // 営業所（取）コード 
            param.tksKgyCd = _naviParameter.strTksKgyCd;                // 得意先企業コード 
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;          // 得意先部門SEQNO 
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;          // 得意先担当SEQNO 
            param.outDate  = DateTime.Now.ToString("yyyy/MM/dd HH:mm"); // 出力日時 
            param.outFlg = "2";                                         // 更新フラグ 
            string seiNo = string.Empty;                                // 請求書No 
            string sybt = string.Empty;                                 // 種別 

            List<string> pJyutNoList = new List<string>();              // 受注No 
            List<string> pJyMeiNoList = new List<string>();             // 受注明細No 
            List<string> pUrMeiNoList = new List<string>();             // 売上明細No 
            List<string> pRenBanList = new List<string>();              // 連番 
            List<string> pSeiNoList = new List<string>();               // 請求書No 
            List<string> pSeiGyoNoList = new List<string>();            // 請求書行No 
            List<string> pSeiYymmList = new List<string>();             // 請求年月日 

            foreach (Row row in spdClaim_Sheet1.Rows)
            {
                sybt = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SYBT].Value);
                seiNo = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SEINO].Value);

                // 出力請求書番号リストに請求書番号が存在しない場合 
                if (!seiNoList.Contains(seiNo))
                {
                    // 対象外のデータの為、読み飛ばす 
                    continue;
                }

                // 種別が「S」以外の場合 
                if (!SYBT_S.Equals(sybt))
                {

                    // 対象外のデータの為、読み飛ばす 
                    continue;
                }

                string[] jyutNo = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.JYUTNO].Value).Split(',');
                string[] jymeiNo = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.JYMEINO].Value).Split(',');
                string[] urmeiNo = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.URMEINO].Value).Split(',');
                string[] renBan = KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.RENBAN].Value).Split(',');

                for (int i = 0; i < jyutNo.Length; i++)
                {
                    pJyutNoList.Add(jyutNo[i]);
                    pJyMeiNoList.Add(jymeiNo[i]);
                    pUrMeiNoList.Add(urmeiNo[i]);
                    pRenBanList.Add(renBan[i]);
                    pSeiNoList.Add(KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SEINO].Value));
                    pSeiGyoNoList.Add(KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SEIGYONO].Value));
                    pSeiYymmList.Add(KKHUtility.ToString(spdClaim_Sheet1.Cells[row.Index, ClaimListColNo.SEIYYMM].Value));
                }
            }
            param.jyutNo = pJyutNoList.ToArray();       // 受注No 
            param.jyMeiNo = pJyMeiNoList.ToArray();     // 受注明細No
            param.urMeiNo = pUrMeiNoList.ToArray();     // 売上明細No
            param.renban = pRenBanList.ToArray();       // 連番 
            param.seiNo = pSeiNoList.ToArray();         // 請求書No 
            param.seiGyoNo = pSeiGyoNoList.ToArray();   // 請求書行No
            param.seiYymm = pSeiYymmList.ToArray();     // 請求年月日

            // 送信フラグ更新 
            ClaimAcomProcessController processController = ClaimAcomProcessController.GetInstance();
            UpdateOutFlgServiceResult result = processController.UpdateOutFlg(param);

            if (result.HasError == true)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 履歴登録メソッド 
        /// </summary>
        /// <param name="kbn">区分</param>
        /// <param name="desc">内容</param>
        /// <param name="errDesc">エラー内容</param>
        /// <param name="reception">送受信種類</param>
        /// <param name="status">送信ステータス</param>
        /// <returns>処理結果</returns>
        private bool RegistLog(string kbn, string desc, string errDesc, string reception, string status)
        {
            //LogProcessController processController;
            //RegistLogServiceResult result;
            //
            //processController = LogProcessController.GetInstance();
            //result = processController.registLog(
            //                                    "ClaiAcom"
            //                                    , _naviParameter.strEsqId
            //                                    , _naviParameter.strEgcd
            //                                    , _naviParameter.strTksKgyCd
            //                                    , _naviParameter.strTksBmnSeqNo
            //                                    , _naviParameter.strTksTntSeqNo
            //                                    , KkhConstAcom.LogShowList.LOG_SHOW
            //                                    , "002"
            //                                    , kbn
            //                                    , desc
            //                                    , errDesc
            //                                    , _naviParameter.strName
            //                                    , reception
            //                                    , status);

            RegistLogServiceResult result = KKHLogUtilityAcom.WriteSendLogToDB(_naviParameter, APLID, desc, errDesc, reception, status);

            if (result.HasError == true)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 入力制御を有効にする
        /// </summary>
        /// <param name="index"></param>
        private void InputControlOn(int index)
        {
            if (IsInputControlNumberOnly(index))
            {
                spdClaimNo.EditingControl.KeyPress += new KeyPressEventHandler(KkhInputControlAcom.KeyPress_InputControlNumberOnly);
            }
        }

        /// <summary>
        /// 入力制御を無効にする
        /// </summary>
        /// <param name="index"></param>
        private void InputControlOff(int index)
        {
            if (IsInputControlNumberOnly(index))
            {
                spdClaimNo.EditingControl.KeyPress -= new KeyPressEventHandler(KkhInputControlAcom.KeyPress_InputControlNumberOnly);
            }
        }

        /// <summary>
        /// キー入力制限（数字のみ）の対象かを返す
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Boolean IsInputControlNumberOnly(int index)
        {
            return (
                ( index == ClaimNoListColNo.SEIYYMM ) ||
                ( index == ClaimNoListColNo.SEINO   )
            );
        }

        /// <summary>
        /// ソートを行う
        /// </summary>
        private void sprSort()
        {
            //発注/請求 差異一覧タブのソート
            hatyuOrSeikyuSort();

            //請求データ一覧タブのソート
            SeikyuSort();

        }

        /// <summary>
        /// 発注/請求 差異一覧タブのソート
        /// </summary>
        private void hatyuOrSeikyuSort()
        {

            string HatyuBan = string.Empty;
            int count = 0;
            //ソートキーの設定
            string SortKey = string.Empty;
            
            SortKey = "iraiNo Asc,";                               //発注番号(降順)
            SortKey = SortKey + "iraiGyoNo Asc,";                  //発注行番号ナンバー(降順)
            SortKey = SortKey + "sybt Asc,";                       //種別(昇順)
            SortKey = SortKey + "seiNo Asc,";                      //請求書番号(昇順)
            SortKey = SortKey + "seiGyoNo Asc,";                   //請求書行番号(昇順)
            SortKey = SortKey + "baitaiCd Asc";                   //媒体コード(昇順)


            ClaimDSAcom.ClaimDiffDataDataTable dt = (ClaimDSAcom.ClaimDiffDataDataTable)_dsClaim.ClaimDiffData.Clone();
            ClaimDSAcom.ClaimDiffDataDataTable hoji = (ClaimDSAcom.ClaimDiffDataDataTable)_dsClaim.ClaimDiffData.Clone();
            ClaimDSAcom.ClaimDiffDataDataTable hoji2 = (ClaimDSAcom.ClaimDiffDataDataTable)_dsClaim.ClaimDiffData.Clone();
            ClaimDSAcom.ClaimDiffDataDataTable SpaceTaiou = (ClaimDSAcom.ClaimDiffDataDataTable)_dsClaim.ClaimDiffData.Clone();
            DataView dv = new DataView(_dsClaim.ClaimDiffData);
            dv.Sort = SortKey;
            
            foreach (DataRowView row in dv)
            {
                //請求書番号空白対応--Start1--
                if (count == 0) 
                {
                    HatyuBan = row.Row["iraiNo"].ToString();
                }

                if (!row.Row["iraiNo"].ToString().Equals(HatyuBan))
                {
                    foreach (ClaimDSAcom.ClaimDiffDataRow row1 in SpaceTaiou.Rows)
                    {
                        dt.ImportRow(row1);
                    }
                    SpaceTaiou.Clear();
                    SpaceTaiou.AcceptChanges();
                    HatyuBan = row.Row["iraiNo"].ToString();
                }
                //請求書番号空白対応--End1--

                if (string.IsNullOrEmpty(row.Row["iraiNo"].ToString().Trim()))
                {
                    hoji.ImportRow(row.Row);
                }
                //請求書番号空白対応--Start2--
                else if (string.IsNullOrEmpty(row.Row["seino"].ToString().Trim()) && row.Row["sybt"].Equals(ClaimListColNo.SYBT))
                {
                    SpaceTaiou.ImportRow(row.Row);
                }
                //請求書番号空白対応--End2--
                else
                {
                    dt.ImportRow(row.Row);
                }

                count++;

            }

            


            foreach (ClaimDSAcom.ClaimDiffDataRow hojirow in hoji.Rows)
            {
                if (string.IsNullOrEmpty(hojirow.seiNo.Trim()))
                {
                    hoji2.ImportRow(hojirow);
                }
                else
                {
                    dt.ImportRow(hojirow);
                }
            }

            foreach (ClaimDSAcom.ClaimDiffDataRow hojirow2 in hoji2.Rows)
            {
                dt.ImportRow(hojirow2);
            }

            _dsClaim.ClaimDiffData.Clear();
            _dsClaim.ClaimDiffData.Merge(dt);
            _dsClaim.ClaimDiffData.AcceptChanges();

        }

        /// <summary>
        /// 請求データ一覧タブのソート
        /// </summary>
        private void SeikyuSort()
        {
            //発注番号
            string hatyuNo = string.Empty;
            //請求書番号
            string seikyuNo = string.Empty;

            //ソートキーの設定
            string SortKey = string.Empty;

            SortKey = "iraiNo desc,";                               //発注番号(降順)
            SortKey = SortKey + "seiNo desc,";                      //請求書ナンバー(降順)
            SortKey = SortKey + "sybt Asc,";                        //種別(昇順)
            SortKey = SortKey + "nebiKbn Asc,";                     //値引行区分(昇順)
            SortKey = SortKey + "iraiGyoNo Asc,";                   //発注行番号(昇順)
            SortKey = SortKey + "jyutNo Asc,";                      //受注No(昇順)
            SortKey = SortKey + "jymeiNo Asc,";                     //受注明細No(昇順)
            SortKey = SortKey + "urmeiNo Asc,";                     //売上No(昇順)
            SortKey = SortKey + "renBan Asc";                       //連番(昇順)




            //ソート用にクローンを作成
            ClaimDSAcom.ClaimDataDataTable dt = (ClaimDSAcom.ClaimDataDataTable)_dsClaim.ClaimData.Clone();
            // ClaimDSAcom.ClaimDataDataTable dtHai = (ClaimDSAcom.ClaimDataDataTable)_dsClaim.ClaimData.Clone();
            ClaimDSAcom.ClaimDataDataTable dtset = (ClaimDSAcom.ClaimDataDataTable)_dsClaim.ClaimData.Clone();
            ClaimDSAcom.ClaimDataDataTable secResult = (ClaimDSAcom.ClaimDataDataTable)_dsClaim.ClaimData.Clone();
            //ソートされたデータビューを作成
            //DataView dv = new DataView(dt);
            //dv.Sort = SortKey;
            //foreach (DataRowView drv in dv)
            //{
            //    dt.ImportRow(drv.Row);
            //}



            #region １番目のソート
            //for (int i = 0; i < _dsClaim.ClaimData.Count; i++)
            //{
            //dtHai.Clear();
            //int cunt =0;
            //foreach (ClaimDSAcom.ClaimDataRow hairow in _dsClaim.ClaimData.Rows)
            //{
            //    if (i == 0)
            //    {
            //        dtHai.ImportRow(hairow);
            //    }
            //    if (i != 0 && cunt >= i)
            //    {
            //        dtHai.ImportRow(hairow);
            //    }
            //    cunt++;
            //}

            //ソートされたデータビューを作成
            DataView dv = new DataView(_dsClaim.ClaimData);
            dv.Sort = SortKey;
            int endrow = _dsClaim.ClaimData.Rows.Count;
            SortKey = string.Empty;
            SortKey = "iraiNo Asc,";                               //発注番号(昇順)
            SortKey = SortKey + "seiNo desc,";                      //請求書ナンバー(降順)
            SortKey = SortKey + "sybt Asc,";                        //種別(昇順)
            SortKey = SortKey + "nebiKbn Asc,";                     //値引行区分(昇順)
            SortKey = SortKey + "iraiGyoNo Asc,";                   //発注行番号(昇順)
            SortKey = SortKey + "jyutNo Asc,";                      //受注No(昇順)
            SortKey = SortKey + "jymeiNo Asc,";                     //受注明細No(昇順)
            SortKey = SortKey + "urmeiNo Asc,";                     //売上No(昇順)
            SortKey = SortKey + "renBan Asc";                       //連番(昇順)
            dv.Sort = SortKey;
            for (int i = 0; i < endrow; i++)
            {
                DataRow delInserRow = dv[0].Row;
                dtset.ImportRow(delInserRow);
                dv[0].Row.Delete();
                dv.Sort = SortKey;
            }


            //foreach (DataRowView drv in dv)
            //{
            //    dtset.ImportRow(drv.Row);
            //    break;
            //}

            //}
            #endregion

            #region ２番目のソート

            int count1 = 0;              //カウント
            bool SeikyuUMU = true;      //請求書番号の有無(有:True,無:False)
            SortKey = string.Empty;
            SortKey = "iraiNo Asc,";                               //発注番号(昇順)
            SortKey = SortKey + "seiNo Asc,";                      //請求書ナンバー(昇順)
            SortKey = SortKey + "sybt Asc,";                        //種別(昇順)
            SortKey = SortKey + "nebiKbn Asc,";                     //値引行区分(昇順)
            SortKey = SortKey + "iraiGyoNo Asc,";                   //発注行番号(昇順)
            SortKey = SortKey + "jyutNo Asc,";                      //受注No(昇順)
            SortKey = SortKey + "jymeiNo Asc,";                     //受注明細No(昇順)
            SortKey = SortKey + "urmeiNo Asc,";                     //売上No(昇順)
            SortKey = SortKey + "renBan Asc";                       //連番(昇順)
            //DataView dtsetView = new DataView(dtset);
            //foreach (DataRowView vrow in dtsetView)
            //{
            //    if (count1 == 0)
            //    {
            //        hatyuNo = vrow.Row["iraiNo"].ToString().Trim();
            //    }

            //    if (!hatyuNo.Equals(vrow.Row["iraiNo"].ToString().Trim()))
            //    {

            //        hatyuNo = vrow.Row["iraiNo"].ToString().Trim();
            //    }
            //    count1++;
            //}



            foreach (ClaimDSAcom.ClaimDataRow row in dtset.Rows)
            {

                if (count1 == 0)                         //１行目か確認
                {
                    hatyuNo = row.iraiNo.Trim();    //発注番号を保持
                    if (row.seiNo.Trim().Length > 0)
                    {
                        SeikyuUMU = true;
                    }
                    else
                    {
                        SeikyuUMU = false;
                    }
                }

                //カレントの発注番号と保持した発注番号が不一致か確認
                if (!hatyuNo.Equals(row.iraiNo.Trim()))
                {
                    //請求書Ｎｏがある場合ソートを行う
                    if (SeikyuUMU)
                    {
                        DataView dtsetView = new DataView(dt);
                        dtsetView.Sort = SortKey;

                        foreach (DataRowView dtsetrowview in dtsetView)
                        {
                            secResult.ImportRow(dtsetrowview.Row);
                        }


                    }
                    else
                    {
                        foreach (ClaimDSAcom.ClaimDataRow korow in dt.Rows)
                        {
                            secResult.ImportRow(korow);
                        }

                    }
                    dt.Clear();
                    dt.ImportRow(row);
                    //if (sortStartRow > 0)                           //ソート開始位置が取得されているか確認
                    //{

                    //}
                    hatyuNo = row.iraiNo.Trim();            //カレントの発注番号を保持

                    //カレントの請求ナンバーの有無を確認する
                    if (row.seiNo.Trim().Length > 0)
                    {
                        SeikyuUMU = true;
                    }
                    else
                    {
                        SeikyuUMU = false;
                    }
                }
                else
                {
                    //カレント行を追加する
                    dt.ImportRow(row);

                    //最終行の場合
                    if (count1 == dtset.Rows.Count - 1)
                    {
                        //請求書Ｎｏがある場合ソートを行う
                        if (SeikyuUMU)
                        {
                            DataView dtsetView = new DataView(dt);
                            dtsetView.Sort = SortKey;

                            foreach (DataRowView dtsetrowview in dtsetView)
                            {
                                secResult.ImportRow(dtsetrowview.Row);
                            }

                            dt.Clear();
                        }
                        else
                        {
                            foreach (ClaimDSAcom.ClaimDataRow korow in dt.Rows)
                            {
                                secResult.ImportRow(korow);
                            }
                        }
                    }
                }
                count1++;
            }

            #endregion

            #region ３番目のソート

            dt.Clear();
            dtset.Clear();
            SortKey = string.Empty;
            hatyuNo = string.Empty;
            seikyuNo = string.Empty;

            int count2 = 0; //カウント
            foreach (ClaimDSAcom.ClaimDataRow row in secResult.Rows)
            {
                //最初の行の場合、発注番号、請求書番号を保持する
                if (count2 == 0)
                {
                    hatyuNo = row.iraiNo.Trim();
                    seikyuNo = row.seiNo.Trim();
                }

                //発注番号"または"請求書番号が異なった場合。
                if (!hatyuNo.Equals(row.iraiNo.Trim()) || !seikyuNo.Equals(row.seiNo.Trim()))
                {



                    SortKey = string.Empty;
                    if (row.baitaiCd.Trim().Equals(KkhConstAcom.MediaKindCode.SYBT_KOTU))
                    {
                        SortKey = "iraiNo desc,";                               //発注番号(昇順)
                        SortKey = SortKey + "seiNo desc,";                      //請求書ナンバー(昇順)
                        SortKey = SortKey + "sybt Asc,";                        //種別(昇順)
                        SortKey = SortKey + "nebiKbn Asc,";                     //値引行区分(昇順)
                        SortKey = SortKey + "iraiGyoNo Asc,";                   //発注行番号(昇順)
                        SortKey = SortKey + "jyutNo Asc,";                      //受注No(昇順)
                        SortKey = SortKey + "jymeiNo Asc,";                     //受注明細No(昇順)
                        SortKey = SortKey + "urmeiNo Asc,";                     //売上No(昇順)
                        SortKey = SortKey + "renBan Asc";                       //連番(昇順)
                    }
                    else
                    {
                        SortKey = "iraiNo Asc,";                                //発注番号(昇順)
                        SortKey = SortKey + "seiNo Asc,";                       //請求書ナンバー(昇順)
                        SortKey = SortKey + "sybt Asc,";                        //種別(昇順)
                        SortKey = SortKey + "nebiKbn Asc,";                     //値引行区分(昇順)
                        SortKey = SortKey + "mediaCd Asc,";                     //メディアコード(昇順)
                        SortKey = SortKey + "iraiGyoNo Asc,";                   //発注行番号(昇順)
                        SortKey = SortKey + "jyutNo Asc,";                      //受注No(昇順)
                        SortKey = SortKey + "jymeiNo Asc,";                     //受注明細No(昇順)
                        SortKey = SortKey + "urmeiNo Asc,";                     //売上No(昇順)
                        SortKey = SortKey + "renBan Asc";                       //連番(昇順)
                    }
                    DataView dvs = new DataView(dt);
                    dvs.Sort = SortKey;
                    foreach (DataRowView dvsrow in dvs)
                    {
                        dtset.ImportRow(dvsrow.Row);
                    }

                    dt.Clear();
                    dt.ImportRow(row);

                    hatyuNo = row.iraiNo.Trim();
                    seikyuNo = row.seiNo.Trim();
                }
                else
                {
                    dt.ImportRow(row);

                    //最終行の場合
                    if (count2 == secResult.Rows.Count - 1)
                    {
                        SortKey = string.Empty;
                        if (row.baitaiCd.Trim().Equals(KkhConstAcom.MediaKindCode.SYBT_KOTU))
                        {
                            SortKey = "iraiNo desc,";                               //発注番号(昇順)
                            SortKey = SortKey + "seiNo desc,";                      //請求書ナンバー(昇順)
                            SortKey = SortKey + "sybt Asc,";                        //種別(昇順)
                            SortKey = SortKey + "nebiKbn Asc,";                     //値引行区分(昇順)
                            SortKey = SortKey + "iraiGyoNo Asc,";                   //発注行番号(昇順)
                            SortKey = SortKey + "jyutNo Asc,";                      //受注No(昇順)
                            SortKey = SortKey + "jymeiNo Asc,";                     //受注明細No(昇順)
                            SortKey = SortKey + "urmeiNo Asc,";                     //売上No(昇順)
                            SortKey = SortKey + "renBan Asc";                       //連番(昇順)
                        }
                        else
                        {
                            SortKey = "iraiNo Asc,";                                //発注番号(昇順)
                            SortKey = SortKey + "seiNo Asc,";                       //請求書ナンバー(昇順)
                            SortKey = SortKey + "sybt Asc,";                        //種別(昇順)
                            SortKey = SortKey + "nebiKbn Asc,";                     //値引行区分(昇順)
                            SortKey = SortKey + "mediaCd Asc,";                     //メディアコード(昇順)
                            SortKey = SortKey + "iraiGyoNo Asc,";                   //発注行番号(昇順)
                            SortKey = SortKey + "jyutNo Asc,";                      //受注No(昇順)
                            SortKey = SortKey + "jymeiNo Asc,";                     //受注明細No(昇順)
                            SortKey = SortKey + "urmeiNo Asc,";                     //売上No(昇順)
                            SortKey = SortKey + "renBan Asc";                       //連番(昇順)
                        }
                        DataView dvs = new DataView(dt);
                        dvs.Sort = SortKey;
                        foreach (DataRowView dvsrow in dvs)
                        {
                            dtset.ImportRow(dvsrow.Row);
                        }

                        dt.Clear();
                    }
                }
                count2++;
            }

            #endregion

            _dsClaim.ClaimData.Clear();
            _dsClaim.ClaimData.Merge(dtset);
            _dsClaim.ClaimData.AcceptChanges();
        }

        /// <summary>
        /// 出力データ用にソートする.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private ClaimDSAcom.ClaimDataDataTable SortForOutFile( ClaimDSAcom.ClaimDataDataTable source )
        {
            // 編集用テーブル.
            ClaimDSAcom.ClaimDataDataTable dtw = new ClaimDSAcom.ClaimDataDataTable();

            // 出力用テーブル.
            ClaimDSAcom.ClaimDataDataTable dto = new ClaimDSAcom.ClaimDataDataTable();

            // ブレイク用キー.
            String strBaitaiCdKey = String.Empty;

            // ソート条件（初期）.
            const String order1 = "seiNo, sybt DESC";

            // ソート条件（交通）.
            const String order2 = "seiNo, sybt DESC, seiGyoNo";

            // ソート条件（交通以外）.
            const String order3 = "seiNo, sybt DESC, mediaCd, seiGyoNo";

            // テーブルを空にする.
            dtw.Clear();

            dto.Clear();

            // 入力テーブルにソート条件（初期）を適用してループ.
            foreach (ClaimDSAcom.ClaimDataRow r1 in (ClaimDSAcom.ClaimDataRow[])source.Select("", order1))
            {
                // 媒体コードでブレイク.
                if (strBaitaiCdKey != r1.baitaiCd)
                {
                    // キーが空の場合にスルー（最初のループの場合）.
                    if (!String.IsNullOrEmpty(strBaitaiCdKey))
                    {
                        // ソート条件格納用.
                        String ow = String.Empty;

                        // 交通のソート条件.
                        if (strBaitaiCdKey == KkhConstAcom.MediaKindCode.SYBT_KOTU)
                        {
                            ow = order2;
                        }
                        // 交通以外のソート条件.
                        else
                        {
                            ow = order3;
                        }

                        // 編集用テーブルにソート条件を適用して出力用テーブルに追加.
                        foreach (ClaimDSAcom.ClaimDataRow r2 in (ClaimDSAcom.ClaimDataRow[])dtw.Select("", ow))
                        {
                            dto.ImportRow(r2);
                        }

                        // 編集用テーブルをクリア.
                        dtw.Clear();
                    }

                    // ブレイク用キーを更新.
                    strBaitaiCdKey = r1.baitaiCd;
                }

                // 編集用テーブルに追加.
                dtw.ImportRow(r1);
            }

            // キーが空の場合にスルー（最初のループの場合）.
            if (!String.IsNullOrEmpty(strBaitaiCdKey))
            {
                // ソート条件格納用.
                String ow = String.Empty;

                // 交通のソート条件.
                if (strBaitaiCdKey == KkhConstAcom.MediaKindCode.SYBT_KOTU)
                {
                    ow = order2;
                }
                // 交通以外のソート条件.
                else
                {
                    ow = order3;
                }

                // 編集用テーブルにソート条件を適用して出力用テーブルに追加.
                foreach (ClaimDSAcom.ClaimDataRow r in (ClaimDSAcom.ClaimDataRow[])dtw.Select("", ow))
                {
                    dto.ImportRow(r);
                }

                // 編集用テーブルをクリア.
                dtw.Clear();
            }

            // ソート結果を返す.
            return dto;
        }

        /// <summary>
        /// OKボタンクリックメソッド 
        /// </summary>
        private void BtnOutClick()
        { 
                        // 請求データ出力チェック（発注/請求番号 一覧） 
            List<string> seiNoList;
            Boolean cancelState = false;

            if (!this.PutClimDataCheckClaimNo(out seiNoList))
            {
                return;
            }

            // 請求データ出力チェック（請求データ 一覧） 
            if (!this.PutClaimDataCheckClaim(seiNoList))
            {
                return;
            }

            // 請求データ出力 
            if (!this.PutClaimData(seiNoList, out cancelState))
            {
                // ファイル選択ダイアログをキャンセルの場合はメッセージを出さずに終了.
                if (cancelState)
                {
                    return;
                }

                // メッセージ表示 
                MessageUtility.ShowMessageBox(MessageCode.HB_W0121, null, this.Text, MessageBoxButtons.OK);
                return;
            }

            // 送信フラグ更新 
            if (!this.UpdateOutFlg(seiNoList))
            {
                return;
            }

            // 出力履歴の登録 
            if (!this.RegistLog("送信", this.Text, " ", "メール", "0"))
            {
                return;
            }

            // オペレーションログの出力
            KKHLogUtilityAcom.WriteOperationLogToDB(_naviParameter, APLID, KKHLogUtilityAcom.KINO_ID_OPERATION_LOG_CLAME, KKHLogUtilityAcom.DESC_OPERATION_LOG_CLAIM);

            // メッセージ表示 
            MessageUtility.ShowMessageBox(MessageCode.HB_I0007, null, this.Text, MessageBoxButtons.OK);

        }

        /// <summary>
        /// 検索ボタンクリックメソッド 
        /// </summary>
        private void BtnSrcClick()
        {

            base.ShowLoadingDialog();

            // データ検索 
            if (0 < this.FindReportData())
            {
                //ソートを行う
                sprSort();

                // 発注/請求番号 差異一覧の背景色を設定 
                this.SetBackColorForClaimDiff();

                // 処理区分の判定処理 
                Dictionary<string, string> shoriKbnList = this.ShoriKbnCheck();

                // 請求データ 一覧の背景色を設定 
                this.SetBackColorForClaim(shoriKbnList);

                // 発注/請求番号 一覧の背景色を設定 
                this.SetBackColorForClaimNo(shoriKbnList);


                HokanDs.Clear();
                HokanDs.Merge(_dsClaim);
                HokanDs.AcceptChanges();

                base.CloseLoadingDialog();
                this.btnOut.Enabled = true;
                statusStrip1.Items["tslval1"].Text = spdClaimNo_Sheet1.Rows.Count.ToString() + "件"; ;
            }
            else
            {
                base.CloseLoadingDialog();
                this.btnOut.Enabled = false;
                statusStrip1.Items["tslval1"].Text = "0件";
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, this.Text, MessageBoxButtons.OK);
            }

        }

        #endregion メソッド 
    }
}