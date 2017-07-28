using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;

namespace Isid.KKH.Lion.ProcessController.MastGet
{
    /// <summary>
    /// 
    /// </summary>
   public class RegisterMasterServiceResult : KKHServiceResult
    {
        #region プロパティ 

        /// <summary>
        /// 汎用データセットです。 
        /// </summary>
       private Isid.KKH.Lion.Schema.RepDsLion _dsMaster;

        /// <summary>
        /// 汎用データセットを取得または設定します。 
        /// </summary>
       public Isid.KKH.Lion.Schema.RepDsLion MasterDataSet
        {
            get { return _dsMaster; }
            set { _dsMaster = value; }
        }

        #endregion プロパティ
    }
}
