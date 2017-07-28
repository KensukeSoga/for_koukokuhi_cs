using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Ash.Utility
{
    class KkhConstAsh
    {
        #region 定数.
        #endregion 定数.

        #region 構造体.
        #region 媒体コード.
        /// <summary>
        /// 媒体コード.
        /// </summary>
        public struct BaitaiCd
        {
            /// <summary>
            /// テレビタイム.
            /// </summary>
            public const String TV_TIME = "100";
            /* 2015/06/08 追加対応 HLC K.Fujisaki ADD Start */
            /// <summary>
            /// テレビネットスポット.
            /// </summary>
            public const String TV_NETSPOT = "105";
            /* 2015/06/08 追加対応 HLC K.Fujisaki ADD End */
            /// <summary>
            /// テレビスポット.
            /// </summary>
            public const String TV_SPOT = "110";
            /// <summary>
            /// ラジオタイム.
            /// </summary>
            public const String RADIO_TIME = "120";
            /// <summary>
            /// ラジオスポット.
            /// </summary>
            public const String RADIO_SPOT = "125";
            /// <summary>
            /// 新聞.
            /// </summary>
            public const String SHINBUN = "130";
            /// <summary>
            /// 雑誌.
            /// </summary>
            public const String ZASHI = "140";
            /// <summary>
            /// 交通.
            /// </summary>
            public const String KOUTSU = "150";
            /// <summary>
            /// 屋外看板.
            /// </summary>
            public const String OKUGAI = "160";
            /// <summary>
            /// 制作.
            /// </summary>
            public const String SEISAKU = "170";
            /// <summary>
            /// イベント.
            /// </summary>
            public const String EVENT = "180";
            /* 2013/02/22 PR媒体追加対応 HLC T.Sonobe ADD Start */
            /// <summary>
            /// PR.
            /// </summary>
            public const String PR = "119";
            /* 2013/02/22 PR媒体追加対応 HLC T.Sonobe ADD End */
            /// <summary>
            /// その他.
            /// </summary>
            public const String SONOTA = "190";
            /// <summary>
            /// ニューメディア.
            /// </summary>
            public const String NEW_MEDIA = "115";
            /// <summary>
            /// インターネット.
            /// </summary>
            public const String INTERNET = "116";
            /// <summary>
            /// BS放送.
            /// </summary>
            public const String BS = "117";
            /// <summary>
            /// CS放送.
            /// </summary>
            public const String CS = "118";
            /// <summary>
            /// 調査.
            /// </summary>
            public const String TYOUSA = "195";
            /// <summary>
            /// メディアフィー.
            /// </summary>
            public const String MEDIA_FEE = "230";
            /// <summary>
            /// ブランド管理フィー.
            /// </summary>
            public const String BRAND_FEE = "240";
            /* 2015/03/31 JSE K.Miyanoue アサヒ対応 ADD Start */
            /// <summary>
            /// イメージガール.
            /// </summary>
            public const String IMAGEGIRL = "193";
            /* 2015/03/31 JSE K.Miyanoue アサヒ対応 ADD End */
            /// <summary>
            /// 地元出稿.
            /// </summary>
            public const String JIMOTO = "194";
            /// <summary>
            /// ニッカ.
            /// </summary>
            public const String NIKKA = "199";
            /// <summary>
            /// ＰＲ（アサヒ飲料）.
            /// </summary>
            public const String PR_INRYOU = "321";
            /// <summary>
            /// アメフト.
            /// </summary>
            public const String AMEFUT = "322";
            /// <summary>
            /// タレント.
            /// </summary>
            public const String TALENT = "331";
            /// <summary>
            /// 著作権料.
            /// </summary>
            public const String COPYRIGHT = "332";
            /// <summary>
            /// 素材代.
            /// </summary>
            public const String SOZAI = "333";
            /// <summary>
            /// ＣＦ調査.
            /// </summary>
            public const String CF = "334";
            /// <summary>
            /// 制作フィー.
            /// </summary>
            public const String SEISAKU_FEE = "336";
            /// <summary>
            /// ＪＡＳＲＡＣ.
            /// </summary>
            public const String JASRAC = "380";
            /// <summary>
            /// 社内使用(広告料).
            /// </summary>
            public const String SYANAISHIRYOU = "382";
            /// <summary>
            /// 広告料(その他).
            /// </summary>
            public const String KOUKOKURYO = "389";
            /// <summary>
            /// 全媒体.
            /// </summary>
            public const String ALL_BAITAI = "ALL";
            /// <summary>
            /// 合計.
            /// </summary>
            public const String GOKEI = "GOKEI";
        }
        #endregion 媒体コード.

        #region 媒体名称.
        /// <summary>
        /// 媒体名称.
        /// </summary>
        public struct BaitaiNm
        {
            /// <summary>
            /// テレビタイム.
            /// </summary>
            public const String TV_TIME = "テレビタイム";
            /// <summary>
            /// テレビスポット.
            /// </summary>
            public const String TV_SPOT = "テレビスポット";
            /// <summary>
            /// ラジオタイム.
            /// </summary>
            public const String RADIO_TIME = "ラジオタイム";
            /// <summary>
            /// ラジオスポット.
            /// </summary>
            public const String RADIO_SPOT = "ラジオスポット";
            /* 2015/06/08 追加対応 HLC K.Fujisaki ADD Start */
            /// <summary>
            /// テレビネットスポット.
            /// </summary>
            public const String TV_NETSPOT = "テレビネットスポット";
            /* 2015/06/08 追加対応 HLC K.Fujisaki ADD End */
            /// <summary>
            /// 新聞.
            /// </summary>
            public const String SHINBUN = "新聞";
            /// <summary>
            /// 雑誌.
            /// </summary>
            public const String ZASHI = "雑誌";
            /// <summary>
            /// 交通.
            /// </summary>
            public const String KOUTSU = "交通";
            /// <summary>
            /// 屋外看板.
            /// </summary>
            public const String OKUGAI = "屋外看板";
            /// <summary>
            /// 屋外広告.
            /// </summary>
            public const String OKUGAIKOUKOKU = "屋外広告";
            /// </summary>
            /// 屋外.
            /// </summary>
            public const String OKUGAIBAITAI = "屋外";
            /// <summary>
            /// 制作.
            /// </summary>
            public const String SEISAKU = "制作";
            /// <summary>
            /// イベント.
            /// </summary>
            public const String EVENT = "イベント";
            /* 2013/02/22 PR媒体追加対応 HLC T.Sonobe Start */
            /// <summary>
            /// PR.
            /// </summary>
            public const String PR = "PR";
            /* 2013/02/22 PR媒体追加対応 HLC T.Sonobe End */
            /// <summary>
            /// その他.
            /// </summary>
            public const String SONOTA = "その他";
            /// <summary>
            /// ニューメディア.
            /// </summary>
            public const String NEW_MEDIA = "ニューメディア";
            /// <summary>
            /// インターネット.
            /// </summary>
            public const String INTERNET = "インターネット";
            /// <summary>
            /// BS放送.
            /// </summary>
            public const String BS = "BS放送";
            /// <summary>
            /// CS放送.
            /// </summary>
            public const String CS = "CS放送";
            /// <summary>
            /// 調査.
            /// </summary>
            public const String TYOUSA = "調査";
            /// <summary>
            /// メディアフィー.
            /// </summary>
            public const String MEDIA_FEE = "メディアフィー";
            /// <summary>
            /// ブランド管理フィー.
            /// </summary>
            public const String BRAND_FEE = "ブランド管理フィー";
            /* 2015/03/31 アサヒ対応 JSE K.Miyanoue ADD Start */
            /// <summary>
            /// ラジオ.
            /// </summary>
            public const String RADIO = "ラジオ";
            /// <summary>
            /// イメージガール.
            /// </summary>
            public const String IMAGEGIRL = "イメージガール";
            /// <summary>
            /// 地元出稿.
            /// </summary>
            public const String JIMOTO = "地元出稿";
            /// <summary>
            /// ニッカ.
            /// </summary>
            public const String NIKKA = "ニッカ";
            /// <summary>
            /// ＰＲ(アサヒ飲料).
            /// </summary>
            public const String PR_INRYOU = "ＰＲ";
            /// <summary>
            /// アメフト.
            /// </summary>
            public const String AMEFUT = "アメフト";
            /// <summary>
            /// タレント.
            /// </summary>
            public const String TALENT = "タレント";
            /// <summary>
            /// 著作権料.
            /// </summary>
            public const String COPYRIGHT = "著作権料";
            /// <summary>
            /// 素材代.
            /// </summary>
            public const String SOZAI = "素材代";
            /// <summary>
            /// ＣＦ調査.
            /// </summary>
            public const String CF = "ＣＦ調査";
            /// <summary>
            /// 制作フィー.
            /// </summary>
            public const String SEISAKU_FEE = "制作フィー";
            /// <summary>
            /// ＪＡＳＲＡＣ.
            /// </summary>
            public const String JASRAC = "ＪＡＳＲＡＣ";
            /// <summary>
            /// 社内使用(広告料).
            /// </summary>
            public const String SYANAISHIRYOU = "社内使用（広告料）";
            /// <summary>
            /// 広告料(その他).
            /// </summary>
            public const String KOUKOKURYO = "広告料（その他）";
            /// <summary>
            /// 新聞(広告料).
            /// </summary>
            public const String SHINBUN_KOUKOKU = "新聞（広告料）";
            /// <summary>
            /// 雑誌(広告料).
            /// </summary>
            public const String ZASSHI_KOUKOKU = "雑誌（広告料）";
            /// <summary>
            /// 交通(広告料).
            /// </summary>
            public const String KOUTSUU_KOUKOKU = "交通（広告料）";
            /// <summary>
            /// 広告料(屋外看板).
            /// </summary>
            public const String KOUKOKURYOU_OKUGAI = "広告料（屋外看板）";
            /// <summary>
            /// イベント(広告料).
            /// </summary>
            public const String EVENT_KOUKOU = "イベント（広告料）";
            /// <summary>
            /// ＢＳ放送(アサヒ飲料).
            /// </summary>
            public const String BS_INRYOU = "ＢＳ放送";
            /// <summary>
            /// ＣＳ放送(アサヒ飲料).
            /// </summary>
            public const String CS_INRYOU = "ＣＳ放送";
            /* 2015/03/31 アサヒ対応 JSE K.Miyanoue ADD End */
            /// <summary>
            /// 全媒体.
            /// </summary>
            public const String ALL_BAITAI = "全媒体";
            /// <summary>
            /// 媒体合計.
            /// </summary>
            public const String SUM_BAITAI = "媒体合計";
            /// <summary>
            /// 合計.
            /// </summary>
            public const String GOKEI = "合計";
        }
        #endregion 媒体名称.

        #region マスターキー.
        /// <summary>
        /// マスターキー.
        /// </summary>
        public struct MasterKey
        {
            /// <summary>
            /// 商品マスター.
            /// </summary>
            public const string SYOHIN = "0001";
            /// <summary>
            /// 新聞マスター.
            /// </summary>
            public const string SHINBUN = "0002";
            /// <summary>
            /// 雑誌マスター.
            /// </summary>
            public const string ZASSHI = "0003";
            /// <summary>
            /// テレビ局マスター.
            /// </summary>
            public const string TV_KYOKU = "0004";
            /// <summary>
            /// ラジオ局マスター.
            /// </summary>
            public const string RADIO_KYOKU = "0005";
            /// <summary>
            /// 交通広告マスター.
            /// </summary>
            public const string OOH = "0006";
            /// <summary>
            /// 媒体コード変換マスター.
            /// </summary>
            public const string BAITAI_HENNKAN = "0007";
            /// <summary>
            /// 新聞コード変換マスタ.
            /// </summary>
            public const string SHINBUN_HENNKAN = "0008";
            /// <summary>
            /// 雑誌コード変換マスタ.
            /// </summary>
            public const string ZASSHI_HENNKAN = "0009";
            /// <summary>
            /// テレビ局コード変換マスタ.
            /// </summary>
            public const string TV_KYOKU_HENNKAN = "0010";
            /// <summary>
            /// ラジオ局コード変換マスタ.
            /// </summary>
            public const string RADIO_KYOKU_HENNKAN = "0011";
            /// <summary>
            /// 交通広告コード変換マスタ.
            /// </summary>
            public const string OOH_HENNKAN = "0012";
            /// <summary>
            /// 制作マスター.
            /// </summary>
            public const string SEISAKU = "0013";
            /// <summary>
            /// 屋外・イベントマスター.
            /// </summary>
            public const string OKUGAI_EVENT = "0014";
            /// <summary>
            /// その他マスター.
            /// </summary>
            public const string SONOTA = "0015";
            /// <summary>
            /// メディアフィーマスター.
            /// </summary>
            public const string MEDIA_FEE = "0016";
            /// <summary>
            /// ブランド管理フィーマスター.
            /// </summary>
            public const string BRAND_MANEGE_FEE = "0017";
            /* 2013/02/22 PR媒体追加対応 HLC T.Sonobe DEL Start */
            /// <summary>
            /// PRマスター.
            /// </summary>
            public const String PR = "0018";
            /* 2013/02/22 PR媒体追加対応 HLC T.Sonobe DEL End */
            /* 2015/02/17 アサヒ対応(アップロードファイルシステム化) K.Fukuda ADD Start */
            /// <summary>
            /// 媒体マスター.
            /// </summary>
            public const String BAITAI = "0019";
            /// <summary>
            /// 得意先媒体変換マスター.
            /// </summary>
            public const String TOKUI_BAITAI_HENNKAN = "0020";
            /* 2015/02/17 アサヒ対応(アップロードファイルシステム化) K.Fukuda ADD End */
        }
        #endregion マスターキー.

        #region 朝夕区分.
        /// <summary>
        /// 朝夕区分.
        /// </summary>
        public struct TyouSekiKbn
        {
            /// <summary>
            /// 朝.
            /// </summary>
            public const String MORNING = "1";

            /// <summary>
            /// 夕.
            /// </summary>
            public const String EVENING = "2";
        }
        #endregion 朝夕区分.

        #region 朝夕名称.
        /// <summary>
        /// 朝夕名称.
        /// </summary>
        public struct TyouSekiNm
        {
            /// <summary>
            /// 朝.
            /// </summary>
            public const String MORNING = "朝";
            /// <summary>
            /// 夕.
            /// </summary>
            public const String EVENING = "夕";
        }
        #endregion 朝夕名称.

        #region 端数区分.
        /// <summary>
        /// 端数区分.
        /// </summary>
        public struct HasuKbn
        {
            /// <summary>
            /// 切上げ.
            /// </summary>
            public const String ROUNDUP = "1";
            /// <summary>
            /// 切捨て.
            /// </summary>
            public const String ROUNDDOWN = "2";
        }
        #endregion 端数区分.

        #region 端数名称.
        /// <summary>
        /// 端数名称.
        /// </summary>
        public struct HasuNm
        {
            /// <summary>
            /// 切上げ.
            /// </summary>
            public const String ROUNDUP = "切上げ";
            /// <summary>
            /// 切捨て.
            /// </summary>
            public const String ROUNDDOWN = "切捨て";
        }
        #endregion 端数名称.

        /* 2016/12/05 アサヒ消費税対応 HLC K.Soga Start */
        #region 掲載版区分.
        public struct KeisaiKbn
        {
            /// <summary>
            /// 全版通し.
            /// </summary>
            public const string KEIKBN_ZENBAN = "1";
            /// <summary>
            /// 統合版.
            /// </summary>
            public const string KEIKBN_TOUGOU = "2";
            /// <summary>
            /// 統合抜き.
            /// </summary>
            public const string KEIKBN_TOUGOUNUKI = "3";
            /// <summary>
            /// 夕刊＋統合版.
            /// </summary>
            public const string KEIKBN_YUKAN = "4";
            /// <summary>
            /// 地域広告.
            /// </summary>
            public const string KEIKBN_TIIKIKOUKOKU = "5";
        }
        #endregion 掲載版区分.
        /* 2016/12/05 アサヒ消費税対応 HLC K.Soga End */
        #endregion 構造体.
    }
}
