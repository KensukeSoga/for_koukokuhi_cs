using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHUtility;

namespace Isid.KKH.Lion.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public class KKHLogUtilityLion : KKHLogUtility
    {
        #region 定数,

        #region 機能ID.

        /// <summary>
        /// 機能ID (オペレーションログ－プルーフリスト)
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_Proof = "001";
        /// <summary>
        /// 機能ID (オペレーションログ－見積書)
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_NewReport = "002";
        /// <summary>
        /// 機能ID (オペレーションログ－請求データ出力)
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_FD = "003";
        /// <summary>
        /// 機能ID (オペレーションログ－CM秒数テレビ)
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_CMTV = "004";
        /// <summary>
        /// 機能ID (オペレーションログ－CM秒数ラジオ)
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_CMRD = "005";
        /// <summary>
        /// 機能ID (オペレーションログ－受注チェック)
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_UPDCHECK = "006";
        /// <summary>
        /// 機能ID (オペレーションログ－件名変更)
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_UPDSUBJECT = "007";
        /// <summary>
        /// 機能ID (オペレーションログ－TVスポット検索)
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_FINDTVSPOT = "008";
        /// <summary>
        /// 機能ID (オペレーションログ－ワークテーブル更新_テレビ番組)
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_WKTVB = "009";
        /// <summary>
        /// 機能ID (オペレーションログ－ワークテーブル更新_テレビ局)
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_WKTVK = "010";
        /// <summary>
        /// 機能ID (オペレーションログ－ワークテーブル更新_ラジオ番組)
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_WKRDB = "011";
        /// <summary>
        /// 機能ID (オペレーションログ－ワークテーブル更新_ラジオ局)
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_WKRDK = "012";
        /// <summary>
        /// 機能ID (オペレーションログ－明細一覧帳票)
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_DETAILLIST = "013";
        /// <summary>
        /// 機能ID (オペレーションログ－制作室リスト)
        /// </summary>
        public const String KIND_ID_OPERATION_LOG_SEISAKULIST = "014";
        /// <summary>
        /// 機能ID (オペレーションログ－追加変更リスト)
        /// </summary>
        public const String KIND_ID_OPERATION_LOG_ADDCHANGELIST = "015";
        /// <summary>
        /// 機能ID (オペレーションログ－受注比較一覧帳票)
        /// </summary>
        public const String KIND_ID_OPERATION_LOG_ORDERDIFFLIST = "016";

        #endregion 機能ID.

        #region 内容.

        /// <summary>
        /// 内容 (オペレーションログ－プルーフリスト)
        /// </summary>
        public const String DESC_OPERATION_LOG_PROOF = "プルーフリスト";
        /// <summary>
        /// 内容 (オペレーションログ－見積書)
        /// </summary>
        public const String DESC_OPERATION_LOG_NEWREPORT = "見積書";
        /// <summary>
        /// 内容 (オペレーションログ－請求データ出力)
        /// </summary>
        public const String DESC_OPERATION_LOG_FD = "請求データ出力";
        /// <summary>
        /// 内容 (オペレーションログ－受注チェック)
        /// </summary>
        public const String DESC_OPERATION_LOG_UPDCHECK = "受注チェック";
        /// <summary>
        /// 内容 (オペレーションログ－件名変更)
        /// </summary>
        public const String DESC_OPERATION_LOG_UPDSUBJECT = "件名変更";
        /// <summary>
        /// 内容 (オペレーションログ－TVスポット検索)
        /// </summary>
        public const String DESC_OPERATION_LOG_FINDTVSPOT = "TVｽﾎﾟｯﾄ検索";
        /// <summary>
        /// 内容 (オペレーションログ－CM秒数テレビ)
        /// </summary>
        public const String DESC_OPERATION_LOG_CMTV = "CM秒数テレビ";
        /// <summary>
        /// 内容 (オペレーションログ－CM秒数ラジオ)
        /// </summary>
        public const String DESC_OPERATION_LOG_CMRD = "CM秒数ラジオ";
        /// <summary>
        /// 内容 (オペレーションログ－ワークテーブル更新_テレビ番組)
        /// </summary>
        public const String DESC_OPERATION_LOG_WKTVB = "ワークテーブル更新_テレビ番組";
        /// <summary>
        /// 内容 (オペレーションログ－ワークテーブル更新_テレビ局)
        /// </summary>
        public const String DESC_OPERATION_LOG_WKTVK = "ワークテーブル更新_テレビ局";
        /// <summary>
        /// 内容 (オペレーションログ－ワークテーブル更新_ラジオ番組)
        /// </summary>
        public const String DESC_OPERATION_LOG_WKRDB = "ワークテーブル更新_ラジオ番組";
        /// <summary>
        /// 内容 (オペレーションログ－ワークテーブル更新_ラジオ局)
        /// </summary>
        public const String DESC_OPERATION_LOG_WKRDK = "ワークテーブル更新_ラジオ局";
        /// <summary>
        /// 内容 (オペレーションログ－明細一覧帳票)
        /// </summary>
        public const String DESC_OPERATION_LOG_DETAILLIST = "明細一覧帳票";
        /// <summary>
        /// 内容 (オペレーションログ－制作室リスト)
        /// </summary>
        public const String DESC_OPERATION_LOG_SEISAKULIST = "制作室リスト";
        /// <summary>
        /// 内容 (オペレーションログ－追加変更リスト)
        /// </summary>
        public const String DESC_OPERATION_LOG_ADDCHANGELIST = "追加変更リスト";

        public const String DESC_OPERATION_LOG_ORDERDIFFLIST = "受注比較一覧帳票";

        #endregion 内容.

        #endregion 定数.
    }
}
