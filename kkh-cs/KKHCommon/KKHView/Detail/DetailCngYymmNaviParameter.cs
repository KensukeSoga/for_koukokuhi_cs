using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHView.Common;

namespace Isid.KKH.Common.KKHView.Detail
{
    class DetailCngYymmNaviParameter : KKHNaviParameter
    {
        int _mode;

        public int Mode
        {
            set { _mode = value; }

            get { return _mode; }
        }
    }
}
