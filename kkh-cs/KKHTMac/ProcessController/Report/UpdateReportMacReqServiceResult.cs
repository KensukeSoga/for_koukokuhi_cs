using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Mac.Schema;

namespace Isid.KKH.Mac.ProcessController.Report
{
    public class UpdateReportMacReqServiceResult : KKHServiceResult
    {
        #region プロパティ 

        /// <summary>
        /// 汎用データセットです。


        /// </summary>
        private RepDsMac _dsMaster;

        /// <summary>
        /// 汎用データセットを取得または設定します。


        /// </summary>
        public RepDsMac MasterDataSet
        {
            get { return _dsMaster; }
            set { _dsMaster = value; }
        }

        #endregion プロパティ
    }
}
