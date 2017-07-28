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
    class FindLionCardNoItrNaviParameter : DetailFormNaviParameter
    {
        private string _cdNoItrCd;

        public string CdNoItrCd
        {
            set { _cdNoItrCd = value; }
            get { return _cdNoItrCd; }
        }

    }
}
