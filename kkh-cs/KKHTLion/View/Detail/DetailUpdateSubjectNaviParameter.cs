using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHView.Detail;


namespace Isid.KKH.Lion.View.Detail
{
    class DetailUpdateSubjectNaviParameter : DetailFormNaviParameter
    {
        Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[] dataRow;

        public Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[] DataRow
        {
            set { dataRow = value; }
            get { return dataRow; }
        }

    }
}
