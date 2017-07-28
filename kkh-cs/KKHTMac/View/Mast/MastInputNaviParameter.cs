using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHView.Common;

namespace Isid.KKH.Mac.View.Mast
{
    public class MastInputNaviParameter : KKHNaviParameter
    {

        /// <summary>
        /// 店舗取込情報マージデータセット
        /// </summary>
        private Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable _dsMerge;

        /// <summary>
        /// 店舗取込情報マージデータセットを取得または設定します。
        /// </summary>
        public Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable dsMerge
        {
            get { return _dsMerge; }
            set { _dsMerge = value; }
        }


        /// <summary>
        /// 店舗取込情報マージデータセット（色）
        /// </summary>
        private Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable _dsMergeColor;

        /// <summary>
        /// 店舗取込情報マージデータセット（色）を取得または設定します。

        /// </summary>
        public Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable dsMergeColor
        {
            get { return _dsMergeColor; }
            set { _dsMergeColor = value; }
        }
    }
}
