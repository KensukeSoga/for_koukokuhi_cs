using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHUtility.Constants;

namespace Isid.KKH.Ash.View.Detail
{
    public partial class JyutyuRegisterAsh : Isid.KKH.Common.KKHView.Detail.JyutyuRegister
    {
       
        /// <summary>
        /// 
        /// </summary>
        public JyutyuRegisterAsh()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 新規登録前のチェック処理 
        /// </summary>
        /// <returns>チェック結果(True：OK、False：NG)</returns>
        protected override bool CheckBeforeRegisterJyutyu()
        {
            // 共通チェック 
            if (!base.CheckBeforeRegisterJyutyu())
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// 新規登録APIの実行パラメータの編集を行う 
        /// </summary>
        /// <returns></returns>
        protected override DetailProcessController.RegisterJyutyuDataParam EditRegisterJyutyuDataParam()
        {
            //共通機能で登録データの初期設定を行う 
            DetailProcessController.RegisterJyutyuDataParam param = base.EditRegisterJyutyuDataParam();

            //****************************************
            //得意先別の設定項目を編集 
            //****************************************
            foreach (Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow row in param.dsDetail.THB1DOWN.Rows)
            {
                //更新プログラム 
                row.hb1UpdApl = "DtlAsh";
            }
            param.dsDetail.THB1DOWN.AcceptChanges();

            return param;
        }
    }
}

