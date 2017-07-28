using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHView.Common;

namespace Isid.KKH.Mac.View.Mast
{
    public class MastNarrowDownNaviParameter : KKHNaviParameter
    {
        #region "プロパティ"
        /// <summary>
        /// 店舗コード
        /// </summary>
        private string _tenCd;
        /// <summary>
        /// 店舗コード
        /// </summary>
        public string tenCd
        {
            get { return _tenCd; }
            set { _tenCd = value; }
        }

        /// <summary>
        /// 店舗コード2
        /// </summary>
        private string _tenCd2;
        /// <summary>
        /// 店舗コード2
        /// </summary>
        public string tenCd2
        {
            get { return _tenCd2; }
            set { _tenCd2 = value; }
        }

        /// <summary>
        /// 店舗コードコンボボックス
        /// </summary>
        private int  _tenCdCmb;
        /// <summary>
        /// 店舗コードコンボボックス
        /// </summary>
        public int tenCdCmb
        {
            get { return _tenCdCmb; }
            set { _tenCdCmb = value; }
        }

        /// <summary>
        /// 店舗名
        /// </summary>
        private string _tenName;
        /// <summary>
        /// 店舗名
        /// </summary>
        public string tenName
        {
            get { return _tenName; }
            set { _tenName = value; }
        }

        /// <summary>
        /// テリトリー関東
        /// </summary>
        private bool _terKanto;
        /// <summary>
        /// テリトリー関東
        /// </summary>
        public bool terKanto
        {
            get { return _terKanto; }
            set { _terKanto = value; }
        }

        /// <summary>
        /// テリトリー関西
        /// </summary>
        private bool _terKansai;
        /// <summary>
        /// テリトリー関西
        /// </summary>
        public bool terKansai
        {
            get { return _terKansai; }
            set { _terKansai = value; }
        }

        /// <summary>
        /// テリトリー中央
        /// </summary>
        private bool _terTyuou;
        /// <summary>
        /// テリトリー中央
        /// </summary>
        public bool terTyuou
        {
            get { return _terTyuou; }
            set { _terTyuou = value; }
        }

        /// <summary>
        /// テリトリーその他
        /// </summary>
        private bool _terSonota;
        /// <summary>
        /// テリトリーその他
        /// </summary>
        public bool terSonota
        {
            get { return _terSonota; }
            set { _terSonota = value; }
        }

        /// <summary>
        /// 店舗区分地区本部
        /// </summary>
        private bool _kbnTikuhonbu;
        /// <summary>
        /// 店舗区分地区本部
        /// </summary>
        public bool kbnTikuhonbu
        {
            get { return _kbnTikuhonbu; }
            set { _kbnTikuhonbu = value; }
        }

        /// <summary>
        /// 店舗区分MC直営店
        /// </summary>
        private bool _kbnMc;
        /// <summary>
        /// 店舗区分MC直営店
        /// </summary>
        public bool kbnMc
        {
            get { return _kbnMc; }
            set { _kbnMc = value; }
        }

        /// <summary>
        /// 店舗区分ライセンシー
        /// </summary>
        private bool _kbnLicensee;
        /// <summary>
        /// 店舗区分ライセンシー
        /// </summary>
        public bool kbnLicensee
        {
            get { return _kbnLicensee; }
            set { _kbnLicensee = value; }
        }

        /// <summary>
        /// 店舗区分その他
        /// </summary>
        private bool _kbnSonota;
        /// <summary>
        /// 店舗区分その他
        /// </summary>
        public bool kbnSonota
        {
            get { return _kbnSonota; }
            set { _kbnSonota = value; }
        }

        #endregion "プロパティ"

    }
}