using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHView.Detail;

namespace Isid.KKH.Epson.View.Detail
{
    /// <summary>
    /// 明細入力（編集？）画面遷移時ナビパラメータ
    /// </summary>
    class DetailInputEpsonNaviParameter : DetailFormNaviParameter
    {
        #region メンバ変数

        /// <summary>
        /// 明細種別
        /// </summary>
        String kbn;

        #endregion メンバ変数

        #region プロパティ

        /// <summary>
        /// 明細種別
        /// </summary>
        public String Kbn
        {
            set { kbn = value; }
            get { return kbn; }
        }

        #endregion プロパティ
    }
}
