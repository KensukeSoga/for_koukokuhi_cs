using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Kmn.Utility
{
    class KkhConstKmn
    {
        #region 定数

        #endregion 定数

        #region 構造体
        /// <summary>
        /// 媒体コード.
        /// </summary>
        public struct BaitaiCd
        {
            /// <summary>
            /// テレビタイム
            /// </summary>
            public const String TV_TIME = "100";
            /// <summary>
            /// テレビスポット 
            /// </summary>
            public const String TV_SPOT = "110";
            /// <summary>
            /// ラジオタイム
            /// </summary>
            public const String RADIO_TIME = "120";
            /// <summary>
            /// ラジオスポット 
            /// </summary>
            public const String RADIO_SPOT = "125";
            /// <summary>
            /// 新聞 
            /// </summary>
            public const String SHINBUN = "130";
            /// <summary>
            /// 雑誌 
            /// </summary>
            public const String Zashi = "140";
            /// <summary>
            /// 交通 
            /// </summary>
            public const String KOUTSU = "150";
            /// <summary>
            /// 屋外看板 
            /// </summary>
            public const String OKUGAI = "160";
            /// <summary>
            /// 制作 
            /// </summary>
            public const String SEISAKU = "170";
            /// <summary>
            /// イベント 
            /// </summary>
            public const String EVENT = "180";
            /// <summary>
            /// その他 
            /// </summary>
            public const String SONOTA = "190";
            /// <summary>
            /// ニューメディア 
            /// </summary>
            public const String NEW_MEDIA = "115";
            /// <summary>
            /// インターネット 
            /// </summary>
            public const String INTERNET = "116";
            /// <summary>
            /// BS放送 
            /// </summary>
            public const String BS = "117";
            /// <summary>
            /// CS放送 
            /// </summary>
            public const String CS = "118";
            /// <summary>
            /// 調査 
            /// </summary>
            public const String TYOUSA = "195";
            /// <summary>
            /// メディアフィー 
            /// </summary>
            public const String MEDIA_FEE = "230";
            /// <summary>
            /// ブランド管理フィー 
            /// </summary>
            public const String BRAND_FEE = "240";
            /// <summary>
            /// 全媒体 
            /// </summary>
            public const String ALL_BAITAI = "ALL";
            /// <summary>
            /// 合計  
            /// </summary>
            public const String GOKEI = "GOKEI";
        }

        /// <summary>
        /// 媒体名称.
        /// </summary>
        public struct BaitaiNm
        {
            /// <summary>
            /// テレビタイム 
            /// </summary>
            public const String TV_TIME = "テレビタイム";
            /// <summary>
            /// テレビスポット 
            /// </summary>
            public const String TV_SPOT = "テレビスポット";
            /// <summary>
            /// ラジオタイム 
            /// </summary>
            public const String RADIO_TIME = "ラジオタイム";
            /// <summary>
            /// ラジオスポット  
            /// </summary>
            public const String RADIO_SPOT = "ラジオスポット";
            /// <summary>
            /// 新聞 
            /// </summary>
            public const String SHINBUN = "新聞";
            /// <summary>
            /// 雑誌 
            /// </summary>
            public const String Zashi = "雑誌";
            /// <summary>
            /// 交通 
            /// </summary>
            public const String KOUTSU = "交通";
            /// <summary>
            /// 屋外看板 
            /// </summary>
            public const String OKUGAI = "屋外看板";
            /// <summary>
            /// 屋外広告 
            /// </summary>
            public const String OKUGAIKOUKOKU = "屋外広告";
            /// </summary>
            /// 屋外 
            /// </summary>
            public const String OKUGAIBAITAI = "屋外";
            /// <summary>
            /// 制作 
            /// </summary>
            public const String SEISAKU = "制作";
            /// <summary>
            /// イベント 
            /// </summary>
            public const String EVENT = "イベント";
            /// <summary>
            /// その他 
            /// </summary>
            public const String SONOTA = "その他";
            /// <summary>
            /// ニューメディア 
            /// </summary>
            public const String NEW_MEDIA = "ニューメディア";
            /// <summary>
            /// インターネット 
            /// </summary>
            public const String INTERNET = "インターネット";
            /// <summary>
            /// BS放送 
            /// </summary>
            public const String BS = "BS放送";
            /// <summary>
            /// CS放送 
            /// </summary>
            public const String CS = "CS放送";
            /// <summary>
            /// 調査 
            /// </summary>
            public const String TYOUSA = "調査";
            /// <summary>
            /// メディアフィー 
            /// </summary>
            public const String MEDIA_FEE = "メディアフィー";
            /// <summary>
            /// ブランド管理フィー 
            /// </summary>
            public const String BRAND_FEE = "ブランド管理フィー";

            /// <summary>
            /// 全媒体 
            /// </summary>
            public const String ALL_BAITAI = "全媒体";
            /// <summary>
            /// 媒体合計 
            /// </summary>
            public const String SUM_BAITAI = "媒体合計";
            /// <summary>
            /// 合計 
            /// </summary>
            public const String GOKEI = "合計";
        }
        public struct MasterKey
        {
            /// <summary>
            /// 部署マスター取得キー：0001 
            /// </summary>
            public const string C_MST_BUMON = "0001";
        }

        /// <summary>
        /// 朝夕区分.
        /// </summary>
        public struct TyouSekiKbn
        {
            /// <summary>
            /// 朝 
            /// </summary>
            public const String MORNING = "1";

            /// <summary>
            /// 夕 
            /// </summary>
            public const String EVENING = "2";
        }

        /// <summary>
        /// 朝夕名称.
        /// </summary>
        public struct TyouSekiNm
        {
            /// <summary>
            /// 朝 
            /// </summary>
            public const String MORNING = "朝";

            /// <summary>
            /// 夕 
            /// </summary>
            public const String EVENING = "夕";
        }

        /// <summary>
        /// 端数区分.
        /// </summary>
        public struct HasuKbn
        {
            /// <summary>
            /// 切上げ
            /// </summary>
            public const String ROUNDUP = "1";

            /// <summary>
            /// 切捨て
            /// </summary>
            public const String ROUNDDOWN = "2";
        }

        /// <summary>
        /// 端数名称.
        /// </summary>
        public struct HasuNm
        {
            /// <summary>
            /// 切上げ 
            /// </summary>
            public const String ROUNDUP = "切上げ";

            /// <summary>
            /// 切捨て 
            /// </summary>
            public const String ROUNDDOWN = "切捨て";
        }

        /// <summary>
        /// 種別コード.
        /// </summary>
        public struct ShubetsuCd
        {
            /// <summary>
            /// テレビ番組 
            /// </summary>
            public const String C_TV_BANGUMI = "001";
            /// <summary>
            /// テレビ特番
            /// </summary>
            public const String C_TV_TOKUBAN = "002";
            /// <summary>
            /// テレビスポット 
            /// </summary>
            public const String C_TV_SPOT = "003";
            /// <summary>
            /// 雑誌 
            /// </summary>
            public const String C_ZASHI = "004";
            /// <summary>
            /// 新聞 
            /// </summary>
            public const String C_SHINBUN = "005";
            /// <summary>
            /// その他 
            /// </summary>
            public const String C_SONOTA = "006";
            /// <summary>
            /// 制作 
            /// </summary>
            public const String C_SEISAKU = "007";
        }
        /// <summary>
        /// 種別名.
        /// </summary>
        public struct ShubetsuMei
        {
            /// <summary>
            /// テレビ番組 
            /// </summary>
            public const String C_TV_BANGUMI = "TV番組";
            /// <summary>
            /// テレビ特番
            /// </summary>
            public const String C_TV_TOKUBAN = "TV特番";
            /// <summary>
            /// テレビスポット 
            /// </summary>
            public const String C_TV_SPOT = "TV SPOT";
            /// <summary>
            /// 雑誌 
            /// </summary>
            public const String C_ZASHI = "雑誌";
            /// <summary>
            /// 新聞 
            /// </summary>
            public const String C_SHINBUN = "新聞";
            /// <summary>
            /// その他 
            /// </summary>
            public const String C_SONOTA = "その他";
            /// <summary>
            /// 制作 
            /// </summary>
            public const String C_SEISAKU = "制作";
        }

        /// <summary>
        /// 登録.
        /// </summary>
        public struct TorokuKbn
        {
            /// <summary>
            /// 済 
            /// </summary>
            public const String REGISTERED = "済";

            /// <summary>
            /// 未 
            /// </summary>
            public const String YET = "";
        }

        /// <summary>
        /// 統合.
        /// </summary>
        public struct TogoKbn
        {
            /// <summary>
            /// 統合済 
            /// </summary>
            public const String INTEGRATE = "統";

            /// <summary>
            /// 未統合 
            /// </summary>
            public const String YET = "";
        }
        #endregion

        #region 定数

        /// <summary>
        /// アラート基準：アラート表示用金額(円)  
        /// </summary>
        public const int ALERTAMOUNT = 6;

        #endregion 定数
    }
}
