using System;
using System.Windows.Forms;

using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;

namespace Isid.KKH.Acom.View.Claim
{
    /// <summary>
    /// 請求データ帳票出力 
    /// </summary>
    public partial class ClaimRepForm : KKHDialogBase
    {
        #region 定数 

        #endregion 定数 

        #region 構造体 

        #endregion 構造体 

        #region メンバ変数 

        /// <summary>
        /// Rgナビパラメータ 
        /// </summary>
        private KKHNaviParameter _naviParameter = new KKHNaviParameter();

        #endregion メンバ変数

        #region コンストラクタ 

        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public ClaimRepForm()
        {
            InitializeComponent();
        }

        #endregion コンストラクタ 

        #region イベント 

        /// <summary>
        /// 画面遷移するたびに発生します。 
        /// </summary>
        /// <param name="sender">遷移元フォーム</param>
        /// <param name="arg">イベントデータ</param>
        private void HikForm_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParameter = (KKHNaviParameter)arg.NaviParameter;
            }
        }

        /// <summary>
        /// フォームLoadイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HikForm_Load(object sender, EventArgs e)
        {
            this.InitializeControl();
        }

        #endregion イベント 

        #region メソッド 

        /// <summary>
        /// 各コントロールの初期設定 
        /// </summary>
        private void InitializeControl()
        {
            string yyyymm = _naviParameter.strDate.Replace("/", string.Empty);

        }
       
        #endregion メソッド 
    }
}

