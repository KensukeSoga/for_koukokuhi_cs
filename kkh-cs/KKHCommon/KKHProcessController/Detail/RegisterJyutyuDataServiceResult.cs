using System;
using System.Collections.Generic;
using System.Text;

using Isid.KKH.Common.KKHProcessController.Common;

namespace Isid.KKH.Common.KKHProcessController.Detail
{
    /// <summary>
    /// 
    /// </summary>
    public class RegisterJyutyuDataServiceResult : KKHServiceResult
    {
        private Isid.KKH.Common.KKHSchema.Detail _dsDetail;

        #region プロパティ
        /// <summary>
        /// 登録結果データ 
        /// </summary>
        public Isid.KKH.Common.KKHSchema.Detail DsDetail
        {
            get { return _dsDetail; }
            set { _dsDetail = value; }
        }

        #endregion プロパティ
    }
}
