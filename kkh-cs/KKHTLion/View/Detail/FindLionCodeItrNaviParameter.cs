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
    class FindLionCodeItrNaviParameter : DetailFormNaviParameter
    {

        /// <summary>
        /// コードを取得、または設定します.
        /// </summary>
        private string _cd;

        public string Cd
        {
            get { return _cd; }
            set { _cd = value; }
        }

        /// <summary>
        /// 名称を取得、または設定します.
        /// </summary>
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// 系列を取得、または設定します.
        /// </summary>
        private string _krt;

        public string Krt
        {
            get { return _krt; }
            set { _krt = value; }
        }

        /// <summary>
        /// スペースコードを取得、または設定します.
        /// </summary>
        private string _spCd;

        public string SpCd
        {
            get { return _spCd; }
            set { _spCd = value; }
        }

        /// <summary>
        /// スペース名を取得、または設定します.
        /// </summary>
        private string _spName;

        public string SpName
        {
            get { return _spName; }
            set { _spName = value; }
        }

        /// <summary>
        /// 料金を取得、または設定します.
        /// </summary>
        private string _ryokin;

        public string Ryokin
        {
            get { return _ryokin; }
            set { _ryokin = value; }
        }


        /// <summary>
        /// 種別を取得、または設定します.
        /// </summary>
        private string _cdNo;

        public string CdNo
        {
            get { return _cdNo; }
            set { _cdNo = value; }
        }

        /// <summary>
        /// 媒体CDを取得、または設定します.
        /// </summary>
        private string _btCd;

        public string BtCd
        {
            get { return _btCd; }
            set { _btCd = value; }
        }

        /// <summary>
        /// 現在行を取得、または設定します.
        /// </summary>
        private int _currentRow;

        public int CurrentRow
        {
            get { return _currentRow; }
            set { _currentRow = value; }
        }

    }
}

