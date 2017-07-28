using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;

namespace Isid.KKH.Mac.ProcessController.MasterMaintenance.Parser
{
    /// <summary>
    /// 検索サービス結果 
    /// </summary>
    /// <remarks>
    ///   修正管理 
    ///   <list type="table">
    ///     <listheader>
    ///       <description>日付</description>
    ///       <description>修正者</description>
    ///       <description>内容</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2012/01/04</description>
    ///       <description>JSE K.Fukuda</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class FindMasterTenpoRirekiByCondServiceResult : KKHServiceResult
    {
        #region プロパティ

        private String _tenpoCd;
        private String _updRrkTimstmp;
        private String _torikomiFlg;
        private String _rrkSybt;
        private Isid.KKH.Mac.Schema.MastDSMac _dsMaster;

        /// <summary>
        /// 店舗コード
        /// </summary>
        public String TenpoCd
        {
            get { return _tenpoCd; }
            set { _tenpoCd = value; }
        }

        /// <summary>
        /// 更新実施キー
        /// </summary>
        public String UpdRrkTimstmp
        {
            get { return _updRrkTimstmp; }
            set { _updRrkTimstmp = value; }
        }

        /// <summary>
        /// 取り込み更新フラグ
        /// </summary>
        public String TorikomiFlg
        {
            get { return _torikomiFlg; }
            set { _torikomiFlg = value; }
        }


        /// <summary>
        /// 履歴種別
        /// </summary>
        public String RrkSybt
        {
            get { return _rrkSybt; }
            set { _rrkSybt = value; }
        }


        /// <summary>
        /// 店舗マスター履歴データセット
        /// </summary>
        public Isid.KKH.Mac.Schema.MastDSMac TenpoRrkMasterDataSet
        {
            get { return _dsMaster; }
            set { _dsMaster = value; }
        }


        #endregion プロパティ
    }
}
