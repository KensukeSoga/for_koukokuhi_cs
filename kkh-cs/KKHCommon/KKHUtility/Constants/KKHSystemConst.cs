using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Common.KKHUtility.Constants
{
    /// <summary>
    /// 新広告費明細システム定数郡.
    /// </summary>
    public struct KKHSystemConst
    {
        #region 定数.
        /// <summary>
        /// 区切り文字.
        /// </summary>
        public const string SPLIT_VAL = ",";
        /* 2017/04/17 エプソン仕入先情報変更対応 HLC K.Soga ADD Start */
        /// <summary>
        /// 数値型.
        /// </summary>
        public const string SUTI = "1";
        /// <summary>
        /// 0.
        /// </summary>
        public const string ZERO = "0";
        /* 2017/04/17 エプソン仕入先情報変更対応 HLC K.Soga ADD End */
        #endregion 定数.

        #region 構造体.
        #region 得意先コード.
        /// <summary>
        /// 得意先コード.
        /// </summary>
        public struct TksKgyCode
        {
            /// <summary>
            /// アコム.
            /// </summary>
            public const string TksKgyCode_Acom = "0088260101";     
            /// <summary>
            /// アサヒ飲料.
            /// </summary>
            public const string TksKgyCode_Ash = "2851470301";
            /// <summary>
            /// アサヒビール.
            /// </summary>
            public const string TksKgyCode_AshBear = "0168020101";
            /// <summary>
            /// スカパー.
            /// </summary>
            public const string TksKgyCode_Skyp = "6954651301";
            /// <summary>
            /// ユニチャーム.
            /// </summary>
            public const string TksKgyCode_Uni = "0310540201";
            /// <summary>
            /// ライオン.
            /// </summary>
            public const string TksKgyCode_Lion = "1809830201";
            /// <summary>
            /// 武田製薬.
            /// </summary>
            public const string TksKgyCode_Tkd = "3855040303";
            /// <summary>
            /// マクドナルド.
            /// </summary>
            public const string TksKgyCode_Mac = "2711430101";
            /// <summary>
            /// 東宝.
            /// </summary>
            public const string TksKgyCode_Toh = "4007020601";
            /* 2015/06/11 東宝アド対応 HLC K.Soga ADD Start */
            /// <summary>
            /// 東宝アド.
            /// </summary>
            public const string TksKgyCode_TohAd = "4006480301";
            /* 2015/06/11 東宝アド対応 HLC K.Soga ADD End */
            /// <summary>
            /// EPSON.
            /// </summary>
            public const string TksKgyCode_Epson = "0040170101";
            /// <summary>
            /// 公文.
            /// </summary>
            public const string TksKgyCode_Kmn = "0470200101";
            /* 2015/04/01 公文得意先変更対応 HLC K.Fujisaki ADD Start */
            /// <summary>
            /// 公文教育研究会(公文得意先変更対応).
            /// </summary>
            public const string TksKgyCode_Kmn_2015 = "1709810401";
            /* 2015/04/01 公文得意先変更対応 HLC K.Fujisaki ADD End */
        }
        #endregion 得意先コード.

        #region 得意先名称.
        /// <summary>
        /// 得意先名称.
        /// </summary>
        public struct TksKgyName
        {
            /// <summary>
            /// アコム.
            /// </summary>
            public const string TksKgyName_Acom = "アコム";
            /// <summary>
            /// アサヒ飲料.
            /// </summary>
            public const string TksKgyName_Ash = "アサヒ飲料(株)";
            /// <summary>
            /// アサヒビール.
            /// </summary>
            public const string TksKgyName_AshBear = "アサヒビール(株)";
            /// <summary>
            /// スカパー.
            /// </summary>
            public const string TksKgyName_Skyp = "スカパー";
            /// <summary>
            /// ユニチャーム.
            /// </summary>
            public const string TksKgyName_Uni = "ユニチャーム";
            /// <summary>
            /// ライオン.
            /// </summary>
            public const string TksKgyName_Lion = "ライオン";
            /// <summary>
            /// 武田製薬.
            /// </summary>
            public const string TksKgyName_Tkd = "武田製薬";
            /// <summary>
            /// マクドナルド.
            /// </summary>
            public const string TksKgyName_Mac = "マクドナルド";
            /// <summary>
            /// 東宝.
            /// </summary>
            public const string TksKgyName_Toh = "東宝";
            /// <summary>
            /// エプソン.
            /// </summary>
            public const string TksKgyName_Epson = "エプソン";
            /// <summary>
            /// 公文.
            /// </summary>
            public const string TksKgyName_Kmn = "公文";
        }
        #endregion 得意先名称.

        #region 請求区分.
        /// <summary>
        /// 請求区分.
        /// </summary>
        public struct SeiKbn
        {
            /// <summary>
            /// 新聞.
            /// </summary>
            public const string NewsPaper = "11";
            /// <summary>
            /// 雑誌.
            /// </summary>
            public const string Magazine = "21";
            /// <summary>
            /// タイム.
            /// </summary>
            public const string Time = "41";
            /// <summary>
            /// スポット.
            /// </summary>
            public const string Spot = "42";
            /// <summary>
            /// IC.
            /// </summary>
            public const string IC = "61";
            /// <summary>
            /// 交通広告.
            /// </summary>
            public const string Ooh = "71";
            /// <summary>
            /// 諸作業.
            /// </summary>
            public const string Works = "81";
            /// <summary>
            /// 国際マス.
            /// </summary>
            public const string KMas = "31";
            /// <summary>
            /// 国際(諸作業).
            /// </summary>
            public const string KWorks = "32";
        }
        #endregion 請求区分.

        #region 業務区分.
        /// <summary>
        /// 業務区分.
        /// </summary>
        public struct GyomKbn
        {
            /// <summary>
            /// 新聞.
            /// </summary>
            public const string Shinbun = "11010";
            /// <summary>
            /// 雑誌.
            /// </summary>
            public const string Zashi = "11020";
            /// <summary>
            /// ラジオ.
            /// </summary>
            public const string Radio = "11030";
            /// <summary>
            /// テレビタイム.
            /// </summary>
            public const string TVTime = "11040";
            /// <summary>
            /// テレビスポット.
            /// </summary>
            public const string TVSpot = "11045";
            /// <summary>
            /// 衛星メディア.
            /// </summary>
            public const string EiseiM = "11050";
            /// <summary>
            /// インタラクティブメディア.
            /// </summary>
            public const string InteractiveM = "11060";
            /// <summary>
            /// OOHメディア.
            /// </summary>
            public const string OohM = "11070";
            /// <summary>
            /// その他メディア.
            /// </summary>
            public const string SonotaM = "11080";
            /// <summary>
            /// メディアプランニング.
            /// </summary>
            public const string MPlan = "11090";
            /// <summary>
            /// クリエーティブ.
            /// </summary>
            public const string Creative = "12010";
            /// <summary>
            /// マーケティング/プロモーション.
            /// </summary>
            public const string MarkePromo = "13010";
            /// <summary>
            /// スポーツ.
            /// </summary>
            public const string Sports = "14010";
            /// <summary>
            /// エンタテイメント.
            /// </summary>
            public const string Entertainment = "14020";
            /// <summary>
            /// その他コンテンツ.
            /// </summary>
            public const string SonotaC = "14030";
        }
        #endregion 業務区分.

        #region 国際区分.
        /// <summary>
        /// 国際区分.
        /// </summary>
        public struct KoksaiKbn
        {
            /// <summary>
            /// 国内.
            /// </summary>
            public const string Kokunai = "0";
            /// <summary>
            /// 国際.
            /// </summary>
            public const string Kokusai = "1";
        }
        #endregion 国際区分.

        #region タイム/スポット区分.
        /// <summary>
        /// タイム/スポット区分.
        /// </summary>
        public struct TimeSpotKbn
        {
            /// <summary>
            /// タイム.
            /// </summary>
            public const string Time = "1";
            /// <summary>
            /// スポット.
            /// </summary>
            public const string Spot = "2";
        }
        #endregion タイム/スポット区分.

        #region レポート.
        /// <summary>
        /// レポート.
        /// </summary>
        public struct TempDir
        {
            /// <summary>
            /// テンプレート保管場所.
            /// </summary>
            public const string ReportDir = @"C:\";
            /// <summary>
            /// テンプレート保管場所.
            /// </summary>
            public const string MainType = @"002";
            /// <summary>
            /// テンプレート保管場所.
            /// </summary>
            public const string ReportType = @"003";
        }
        #endregion レポート.

        #region アプリID.
        /// <summary>
        /// アプリID.
        /// </summary>
        public struct ApplicationID
        {
            /// <summary>
            /// アコム.
            /// </summary>
            public const string AcomApplicationID = "00";
            /// <summary>
            /// アサヒ(明細登録).
            /// </summary>
            public const string APLID_DTL_ASH = "DtlAsh";
            /// <summary>
            /// アサヒ(請求データ作成).
            /// </summary>
            public const string APLID_FD_ASH = "FDAsh";
            /// <summary>
            /// アサヒ(媒体別帳票).
            /// </summary>
            public const String APLID_MEDIUM = "Medium";
            /// <summary>
            /// エプソン(明細登録).
            /// </summary>
            public const String APLID_DTL_EPSON = "DtlEpson";
        }
        #endregion アプリID.

        #region メッセージレベル.
        /// <summary>
        /// メッセージレベル.
        /// </summary>
        public struct MessageLevel
        {
            /// <summary>
            /// 情報.
            /// </summary>
            public const string Information = "I";
            /// <summary>
            /// 確認.
            /// </summary>
            public const string Confirmation = "C";
            /// <summary>
            /// 警告.
            /// </summary>
            public const string Warning = "W";
            /// <summary>
            /// エラー.
            /// </summary>
            public const string Error = "E";
        }
        #endregion メッセージレベル.

        #region ヘルプファイル.
        /// <summary>
        /// ヘルプファイル.
        /// </summary>
        public struct HelpFile
        {
            /// <summary>
            /// アコム.
            /// </summary>
            public const string Acom = "KKH_Help_Acom.chm";
            /// <summary>
            /// ライオン.
            /// </summary>
            public const string Lion = "KKH_Help_Lion.chm";
            /// <summary>
            /// スカパー.
            /// </summary>
            public const string Skyp = "KKH_Help_Skyp.chm";
        }
        #endregion ヘルプファイル.

        #region ヘルプ場所.
        /// <summary>
        /// ヘルプ場所.
        /// </summary>
        public struct HelpLocation
        {
            /// <summary>
            /// メインメニュー.
            /// </summary>
            public const string MainManue = "メニュー画面・機能一覧";
            /// <summary>
            /// マスター.
            /// </summary>
            public const string MasterMaintenance = "マスター";
            /// <summary>
            /// マスタメンテナンス.
            /// </summary>
            public const string MasterMaintenance1 = "マスタメンテナンス";
            /// <summary>
            /// 帳票出力.
            /// </summary>
            public const string TyouHyou = "帳票出力";
            /// <summary>
            /// 帳票.
            /// </summary>
            public const string Report = "帳票";
            /// <summary>
            /// 納品／請求書.
            /// </summary>
            public const string ReportSkp = "納品／請求書";
            /// <summary>
            /// 発注データ取込機能.
            /// </summary>
            public const string InputHik = "発注データ取込機能";
            /// <summary>
            /// 請求原票取込履歴. 
            /// </summary>
            public const string HisDownLoad = "請求原票取込履歴";
            /// <summary>
            /// 広告費明細入力機能.
            /// </summary>
            public const string Detail = "広告費明細入力機能";
            /// <summary>
            /// 請求データ送信.
            /// </summary>
            public const string Claim = "請求データ送信";
            /// <summary>
            /// 請求書作成指示書.
            /// </summary>
            public const string SeiSakuSei = "請求書作成指示書";
        }
        #endregion ヘルプ場所.

        /* 2016/12/05 アサヒ消費税対応 HLC K.Soga Start */
        #region 記雑区分.
        /// <summary>
        /// 記雑区分.
        /// </summary>
        public struct KizatsuKbn
        {
            /// <summary>
            /// 記事下.
            /// </summary>
            public const string KIZKN_KIJISITA = "10";
            /// <summary>
            /// 記事中.
            /// </summary>
            public const string KIZKN_KIJINAKA = "21";
            /// <summary>
            /// 突出.
            /// </summary>
            public const string KIZKN_TOSYUTU = "22";
            /// <summary>
            /// 題字.
            /// </summary>
            public const string KIZKN_DAIJI = "23";
            /// <summary>
            /// 挟込.
            /// </summary>
            public const string KIZKN_HASAKOMI = "24";
            /// <summary>
            /// 特殊雑報.
            /// </summary>
            public const string KIZKN_TOKUSYU = "25";
            /// <summary>
            /// 案内.
            /// </summary>
            public const string KIZKN_ANNAI = "30";
        }
        #endregion 記雑区分.

        #region 商品マスタ.
        /// <summary>
        /// 商品マスタ.
        /// </summary>
        public struct SyouhinMaster
        {
            /// <summary>
            /// 商品マスタ種別.
            /// </summary>
            public const string MAST_SYBT = "101";
        }
        #endregion 商品マスタ.

        #region 統合フラグ.
        /// <summary>
        /// 統合フラグ.
        /// </summary>
        public struct Tougou
        {
            /// <summary>
            /// 統合済み.
            /// </summary>
            public const string TOUGOU_FLG = "1";
        }
        #endregion 統合フラグ.

        #region 固定文言.
        /// <summary>
        /// 固定文言.
        /// </summary>
        public struct KoteiMongon
        {
            /// <summary>
            /// 明細登録.
            /// </summary>
            public const string DETAIL_REGIST = "明細登録";
            /// <summary>
            /// 明細入力.
            /// </summary>
            public const string DETAIL_INPUT = "明細入力";
            /// <summary>
            /// 媒体合計.
            /// </summary>
            public const string BAITAI_GOUKEI = "媒体合計";
            /// <summary>
            /// 総合計.
            /// </summary>
            public const string SOUGOUKEI = "総合計";
            /// <summary>
            /// 小計.
            /// </summary>
            public const string SYOKEI = "小計";
            /// <summary>
            /// 明細登録エラー.
            /// </summary>
            public const string ERR_DETAIL_REGIST = "明細登録エラー";
            /// <summary>
            /// 入力エラー.
            /// </summary>
            public const string ERR_INPUT = "入力エラー";
            /// <summary>
            /// 詳細情報未設定エラー.
            /// </summary>
            public const string ERR_SET_DETAIL_INFO = "詳細情報未設定エラー";
            /// <summary>
            /// 新聞発売日.
            /// </summary>
            public const string KEISAI_DATE_SHINBUN = "新聞発売日";
            /// <summary>
            /// 雑誌掲載日.
            /// </summary>
            public const string KEISAI_DATE_ZASSI = "雑誌掲載日";
            /* 2017/04/17 エプソン仕入先情報変更対応 HLC K.Soga ADD Start */
            /// <summary>
            /// マスターメンテナンス.
            /// </summary>
            public const string MASTERMAINTENANCE = "マスターメンテナンス";
            /* 2017/04/17 エプソン仕入先情報変更対応 HLC K.Soga ADD End */
        }
        #endregion 固定文言.

        #region フォーマット.
        /// <summary>
        /// フォーマット.
        /// </summary>
        public struct Format
        {
            /// <summary>
            /// 額書式.
            /// </summary>
            public const string GAKU_FORMAT = "###,###,###,##0";
            /// <summary>
            /// 年月日書式.
            /// </summary>
            public const string YEAR_MONTH_DAY_FORMAT = "yyyy/MM/dd";
        }
        #endregion フォーマット.

        #region 年月日.
        /// <summary>
        /// 年月日.
        /// </summary>
        public struct Date
        {
            /// <summary>
            /// 年.
            /// </summary>
            public const string YEAR = "年";
            /// <summary>
            /// 月.
            /// </summary>
            public const string MONTH = "月";
            /// <summary>
            /// 日.
            /// </summary>
            public const string DAY = "日";
        }
        #endregion 年月日.

        #region 記号.
        /// <summary>
        /// 記号.
        /// </summary>
        public struct Kigou
        {
            /// <summary>
            /// -.
            /// </summary>
            public const string HYPHEN = " - ";
            /// <summary>
            /// 空白.
            /// </summary>
            public const string SPACE = " ";
        }
        #endregion 記号.

        /* 2017/04/17 エプソン仕入先情報変更対応 HLC K.Soga ADD Start */
        #region フィールド.
        /// <summary>
        /// フィールド.
        /// </summary>
        public class Field
        {
            /// <summary>
            /// フィールド1.
            /// </summary>
            public const string FIELD_1 = "field1";
        };
        #endregion フィールド.
        /* 2017/04/17 エプソン仕入先情報変更対応 HLC K.Soga ADD End */
        /* 2016/12/05 アサヒ消費税対応 HLC K.Soga End */
        #endregion 構造体.
    }
}