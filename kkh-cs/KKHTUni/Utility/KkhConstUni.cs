using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Uni.Utility
{
    class KkhConstUni
    {
        #region 定数

        /// <summary>
        /// アラート基準：アラート表示用金額(円)  
        /// </summary>
        public const int ALERTAMOUNT = 6;

        #endregion 定数

        #region 構造体


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
    }
}
