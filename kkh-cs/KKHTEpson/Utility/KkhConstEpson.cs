using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Epson.Utility
{
    /// <summary>
    /// エプソン定数郡.
    /// </summary>
    public class KkhConstEpson
    {
        #region 構造体.
        /// <summary>
        /// マスター取得キー.
        /// </summary>
        public struct MasterKey
        {
            /// <summary>
            /// 取引識別情報マスタ取得キー.
            /// </summary>
            public const string TRISIKI = "0001";
            /// <summary>
            /// 取引担当者マスタ取得キー.
            /// </summary>
            public const string TRITNT = "0002";
            /// <summary>
            /// 仕入先情報マスタ取得キー.
            /// </summary>
            public const string SIIRESAKI = "0003";
            /* 2017/04/14　エプソン仕入先変更対応 ITCOM A.Nakamura ADD Start */
            /// <summary>
            /// 起票部門CDマスタ取得キー：0004.
            /// </summary>
            public const string MST_KIHYOUBMNCD = "0004";
            /// <summary>
            /// 原価センタマスタ取得キー：0005 .
            /// </summary>
            public const string MST_GENKACENTER = "0005";
            /* 2017/04/14 エプソン仕入先変更対応 ITCOM A.Nakamura ADD End */
        }
        #endregion 構造体.
    }
}
