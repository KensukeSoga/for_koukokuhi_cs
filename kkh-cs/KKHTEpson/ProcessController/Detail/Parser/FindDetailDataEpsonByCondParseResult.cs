using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Epson.ProcessController.Detail.Parser
{
    class FindDetailDataEpsonByCondParseResult
    {
        #region プロパティ

        /// <summary>
        /// 広告費明細入力データセットです。 
        /// </summary>
        private Isid.KKH.Epson.Schema.DetailDSEpson _dsDetailEpson;

        /// <summary>
        /// 広告費明細入力データセットを取得または設定します。 
        /// </summary>
        public Isid.KKH.Epson.Schema.DetailDSEpson DetailEpsonDataSet
        {
            get { return _dsDetailEpson; }
            set { _dsDetailEpson = value; }
        }

        #endregion プロパティ
    }
}
