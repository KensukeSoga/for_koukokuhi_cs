using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Main.Utility
{
    class KkhConstMain
    {
        #region 定数

        /// <summary>
        /// 開放確認用種別
        /// </summary>
        public const string RELEASE_SYBT = "999";

        /// <summary>
        /// 開放確認用FIELD1
        /// </summary>
        public const string TF_FLD1 = "001";

        #endregion 定数

        #region 構造体

        /// <summary>
        /// 得意先選択スプレッドの列
        /// </summary>
        public struct CustomerSelectCol
        {
            /// <summary>
            /// 得意先企業コード
            /// </summary>
            public const int TKSKGYCD = 0;
            /// <summary>
            /// 得意先部門SEQNO
            /// </summary>
            public const int TKSBMNSEQNO = 1;
            /// <summary>
            /// 得意先担当SEQNO
            /// </summary>
            public const int TKSTNTSEQNO = 2;
            /// <summary>
            /// 得意先コード
            /// </summary>
            public const int TKSCD = 3;
            /// <summary>
            /// 得意先名
            /// </summary>
            public const int TKSNAME = 4;
            /// <summary>
            /// 担当組織名
            /// </summary>
            public const int TNTSIKNAME = 5;
        }

        /// <summary>
        /// フラグ
        /// </summary>
        public struct Flag
        {
            /// <summary>
            /// OFF
            /// </summary>
            public const string OFF = "0";
            /// <summary>
            /// ON
            /// </summary>
            public const string ON = "1";
        }

        #endregion
    }
}
