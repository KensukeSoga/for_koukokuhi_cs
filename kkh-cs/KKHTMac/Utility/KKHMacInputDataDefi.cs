using System;
using System.Collections.Generic;
using System.Text;
using Isid.NJ.Config;

namespace Isid.KKH.Mac.KKHUtility
{
    class KKHMacInputDataDefi : Parameter
    {
        /// <summary>
        /// アプリID
        /// </summary>
        public static readonly string APP_ID = "InputDataDefi";

        /// <summary>
        /// インスタンス
        /// </summary>
        private static KKHMacInputDataDefi instance = (KKHMacInputDataDefi)ParameterFactory.GetParameter(APP_ID);

        /// <summary>
        /// デフォルトコンストラクタ。 
        /// </summary>
        public KKHMacInputDataDefi()
        {
        }

        /// <summary>
        /// インスタンスを返します。 
        /// </summary>
        /// <returns>インスタンス</returns>
        public static KKHMacInputDataDefi GetInstance()
        {
            if (instance == null)
            {
                instance = (KKHMacInputDataDefi)ParameterFactory.GetParameter(APP_ID);
            }
            return instance;
        }

        /// <summary>
        /// 取込ファイルのWorkフォルダ
        /// </summary>
        public string InputDataWorkFolderPath
        {
            get
            {
                return (string)instance.GetValue("InputDataWorkFolderPath");
            }
        }

        /// <summary>
        /// Excel起動のリトライ回数
        /// </summary>
        public int ExcelStartRetryCount
        {
            get
            {
                return int.Parse(instance.GetValue("ExcelStartRetryCount").ToString());
            }
        }


        #region "取込項目"
        /// <summary>
        /// 店舗コード 
        /// </summary>
        public string strTenpoCd
        {
            get
            {
                return (string)instance.GetValue("TenpoCd");
            }
        }

        /// <summary>
        /// 店舗名称
        /// </summary>
        public string strTenpoNm
        {
            get
            {
                return (string)instance.GetValue("TenpoNm");
            }
        }
        /// <summary>
        /// 勘定科目
        /// </summary>
        public string strKamokuCd
        {
            get
            {
                return (string)instance.GetValue("KamokuCd");
            }
        }
        /// <summary>
        /// 郵便番号
        /// </summary>
        public string strYubinNo
        {
            get
            {
                return (string)instance.GetValue("YubinNo");
            }
        }
        /// <summary>
        /// 住所１ 
        /// </summary>
        public string strAddress1
        {
            get
            {
                return (string)instance.GetValue("Address1");
            }
        }        

        /// <summary>
        /// 住所２ 
        /// </summary>
        public string strAddress2
        {
            get
            {
                return (string)instance.GetValue("Address2");
            }
        }
        /// <summary>
        /// 電話番号
        /// </summary>
        public string strTelNo
        {
            get
            {
                return (string)instance.GetValue("TelNo");
            }
        }
        /// <summary>
        /// テリトリー
        /// </summary>
        public string strTerritory
        {
            get
            {
                return (string)instance.GetValue("Territory");
            }
        }
        /// <summary>
        /// 店舗区分 
        /// </summary>
        public string strTenpoKbn
        {
            get
            {
                return (string)instance.GetValue("TenpoKbn");
            }
        }
        /// <summary>
        /// ライセンシー社名 
        /// </summary>
        public string strCompanyNm
        {
            get
            {
                return (string)instance.GetValue("CompanyNm");
            }
        }
        /// <summary>
        /// 代表者名
        /// </summary>
        public string strName
        {
            get
            {
                return (string)instance.GetValue("Name");
            }
        }
        /// <summary>
        /// 取引先コード 
        /// </summary>
        public string strTorihikisakiCd
        {
            get
            {
                return (string)instance.GetValue("TorihikisakiCd");
            }
        }
        /// <summary>
        /// 明細行フラグ
        /// </summary>
        public string strSplitFlg
        {
            get
            {
                return (string)instance.GetValue("SplitFlg");
            }
        }

        /// <summary>
        /// 有効開始日
        /// </summary>
        public string strOpenDate
        {
            get
            {
                return (string)instance.GetValue("OpenDate");
            }
        }

        /// <summary>
        /// 有効終了日
        /// </summary>
        public string strCloseDate
        {
            get
            {
                return (string)instance.GetValue("CloseDate");
            }
        }
        /// <summary>
        /// 初期G.OPEN年月日 
        /// </summary>
        public string shokiGOpenNgp
        {
            get
            {
                return (string)instance.GetValue("ShokiGOpenNgp");
            }
        }
        /// <summary>
        /// G.OPEN年月日 
        /// </summary>
        public string gOpenNgp
        {
            get
            {
                return (string)instance.GetValue("GOpenNgp");
            }
        }
        /// <summary>
        /// G.CLOSE年月日  
        /// </summary>
        public string gCloseNgp
        {
            get
            {
                return (string)instance.GetValue("GCloseNgp");
            }
        }

        /// <summary>
        /// 都道府県名(漢字) 
        /// </summary>
        public string strTodofukenNm
        {
            get
            {
                return (string)instance.GetValue("TodofukenNm");
            }
        }
        #endregion
    }
}
