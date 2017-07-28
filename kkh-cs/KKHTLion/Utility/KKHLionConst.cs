using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Lion.Utility
{
    /// <summary>
    /// 得意先ライオン定数域.
    /// </summary>
    public struct KKHLionConst
    {

        #region 構造体.

        /// <summary>
        /// 媒体区分コード.
        /// </summary>
        public struct BaitaiCd
        {
            /// <summary>
            /// テレビタイム.
            /// </summary>
            public const String TV_TIME = "100";
            /// <summary>
            /// テレビスポット.
            /// </summary>
            public const String TV_SPOT = "110";
            /// <summary>
            /// ラジオタイム.
            /// </summary>
            public const String RADIO_TIME = "120";
            /// <summary>
            /// ラジオスポット.
            /// </summary>
            public const String RADIO_SPOT = "125";
            /// <summary>
            /// 新聞.
            /// </summary>
            public const String SHINBUN = "130";
            /// <summary>
            /// 雑誌.
            /// </summary>
            public const String ZASHI = "140";
            /// <summary>
            /// 交通.
            /// </summary>
            public const String KOUTSU = "150";
            /// <summary>
            /// その他.
            /// </summary>
            public const String SONOTA = "190";
            /// <summary>
            /// インターネット.
            /// </summary>
            public const String INTERNET = "116";
            /// <summary>
            /// 事業費.
            /// </summary>
            public const String JIGYOUHI = "250";
            /// <summary>
            /// モバイル.
            /// </summary>
            public const String MOBILE = "260";
            /// <summary>
            /// チラシ.
            /// </summary>
            public const String TIRASHI = "280";
            /// <summary>
            /// サンプリング.
            /// </summary>
            public const String SAMPLING = "290";
            /// <summary>
            /// BSCS.
            /// </summary>
            public const String BSCS = "300";
        }

        /// <summary>
        /// 媒体区分名.
        /// </summary>
        public struct BaitaiName
        {
            /// <summary>
            /// テレビタイム.
            /// </summary>
            public const String TV_TIME = "テレビタイム";
            /// <summary>
            /// テレビスポット.
            /// </summary>
            public const String TV_SPOT = "テレビスポット";
            /// <summary>
            /// ラジオタイム.
            /// </summary>
            public const String RADIO_TIME = "ラジオタイム";
            /// <summary>
            /// ラジオスポット.
            /// </summary>
            public const String RADIO_SPOT = "ラジオスポット";
            /// <summary>
            /// 新聞.
            /// </summary>
            public const String SHINBUN = "新聞";
            /// <summary>
            /// 雑誌.
            /// </summary>
            public const String ZASHI = "雑誌";
            /// <summary>
            /// 交通.
            /// </summary>
            public const String KOUTSU = "交通";
            /// <summary>
            /// その他.
            /// </summary>
            public const String SONOTA = "その他";
            /// <summary>
            /// インターネット.
            /// </summary>
            public const String INTERNET = "インターネット";
            /// <summary>
            /// 事業費.
            /// </summary>
            public const String JIGYOUHI = "事業費";
            /// <summary>
            /// モバイル.
            /// </summary>
            public const String MOBILE = "モバイル";
            /// <summary>
            /// チラシ.
            /// </summary>
            public const String TIRASHI = "チラシ";
            /// <summary>
            /// サンプリング.
            /// </summary>
            public const String SAMPLING = "サンプリング";
            /// <summary>
            /// BSCS.
            /// </summary>
            public const String BSCS = "BSCS";
        }

        #endregion 構造体.

        #region マスタメンテナンス.

        #region 定数.

        #region 汎用マスタ.

        // マスタ（コード） 
        //public const string C_MAST__CD = "0001"; //テレビ番組マスター.
        //public const string C_MAST__CD = "0002"; //ラジオ番組マスター.
        //public const string C_MAST__CD = "0003"; //テレビ局マスター.
        //public const string C_MAST__CD = "0004"; //ラジオ局マスター.
        /// <summary>
        /// ADブランドマスタ.
        /// </summary>
        public const string C_MAST_BRAND_CD = "0005";
        /// <summary>
        /// 消費税変更マスタ.
        /// </summary>
        public const string C_MAST_TAX_CD = "0006";
        //public const string C_MAST__CD = "0007"; //系列マスター.
        /// <summary>
        /// 県マスタ.
        /// </summary>
        public const string C_MAST_KEN_CD = "0008";
        //public const string C_MAST__CD = "0009"; //商品ジャンルマスター.
        /// <summary>
        /// 媒体区分マスタ.
        /// </summary>
        public const string C_MAST_BAITAI_CD = "0010";
        /// <summary>
        /// 新聞マスタ.
        /// </summary>
        public const string C_MAST_SHINBUN_CD = "0011";
        /// <summary>
        /// 雑誌マスタ.
        /// </summary>
        public const string C_MAST_ZASSI_CD = "0012";
        //public const string C_MAST__CD = "0013"; //雑誌スペースマスター.
        /// <summary>
        /// インターネットマスタ.
        /// </summary>
        public const string C_MAST_INTERNET_CD = "0014";
        /// <summary>
        /// モバイルマスタ.
        /// </summary>
        public const string C_MAST_MOBILE_CD = "0015";
        /// <summary>
        /// 新聞コード変換マスタ.
        /// </summary>
        public const string C_MAST_SHINBUN_HEN_CD = "0016";
        /// <summary>
        /// 雑誌コード変換マスタ.
        /// </summary>
        public const string C_MAST_ZASHI_HEN_CD = "0017";
        /// <summary>
        /// テレビ局コード変換マスタ.
        /// </summary>
        public const string C_MAST_TV_HEN_CD = "0018";
        /// <summary>
        /// ラジオ局コード変換マスタ.
        /// </summary>
        public const string C_MAST_RADIO_HEN_CD = "0019";
        //public const string C_MAST__CD = "0020"; //交通広告変換マスター.
        /// <summary>
        /// その他媒体コード変換マスタ.
        /// </summary>
        public const string C_MAST_SONOTA_HEN_CD = "0021";
        //public const string C_MAST__CD = "0022"; //料金マスタ.
        /// <summary>
        /// 地区マスタ.
        /// </summary>
        public const string C_MAST_SEITIKU_CD = "0024";
        /// <summary>
        /// 事業部マスタ.
        /// </summary>
        public const string C_MAST_DIV_CD = "0031";
        /// <summary>
        /// 担当者マスタ.
        /// </summary>
        public const string C_MAST_TANTO_CD = "0090";

        #endregion 汎用マスタ.

        #region DB項目.

        /// <summary>
        /// 登録タイムスタンプ.
        /// </summary>       
        public const string C_TRKTIMSTMP = "trkTimStmp";
        /// <summary>
        /// 登録プログラム.
        /// </summary>
        public const string C_TRKPL = "trkPl";
        /// <summary>
        /// 登録担当者.
        /// </summary>
        public const string C_TRKTNT = "trkTnt";
        /// <summary>
        /// 更新タイムスタンプ.
        /// </summary>
        public const string C_UPDTIMSTMP = "updTimStmp";
        /// <summary>
        /// 更新プログラム.
        /// </summary>
        public const string C_UPDAPL = "updApl";
        /// <summary>
        /// 更新担当者.
        /// </summary>
        public const string C_UPDTNT = "updTnt";
        /// <summary>
        /// 営業所コード.
        /// </summary>
        public const string C_EGCD = "egCd";
        /// <summary>
        /// 得意先企業コード.
        /// </summary>
        public const string C_TKSKGYCD = "tksKgyCd";
        /// <summary>
        /// 得意先部門SEQNO.
        /// </summary>
        public const string C_TKSBMNSEQNO = "tksBmnSeqNo";
        /// <summary>
        /// 得意先担当SEQNO.
        /// </summary>
        public const string C_TKSTNTSEQNO = "tksTntSeqNo";
        /// <summary>
        /// 種別.
        /// </summary>
        public const string C_SYBT = "sybt";

        #endregion DB項目.

        #region マスタファイル名.

        /// <summary>
        /// テレビ番組マスタ.
        /// </summary>
        public const string C_WRFL_TVBMST = "TVBMST";
        /// <summary>
        /// ラジオ番組マスタ.
        /// </summary>
        public const string C_WRFL_RDBMST = "RDBMST";
        /// <summary>
        /// テレビ局マスタ.
        /// </summary>
        public const string C_WRFL_TVKMST = "TVKMST";
        /// <summary>
        /// ラジオ局マスタ.
        /// </summary>
        public const string C_WRFL_RDKMST = "RDKMST";
        /// <summary>
        /// テレビ料金マスタ.
        /// </summary>
        public const string C_WRFL_TVRMST = "TVRMST";
        /// <summary>
        /// ラジオ料金マスタ.
        /// </summary>
        public const string C_WRFL_RDRMST = "RDRMST";
        /// <summary>
        /// テレビCM秒数マスタ.
        /// </summary>
        public const string C_WRFL_TVCMST = "TVCMST";
        /// <summary>
        /// ラジオ秒数マスタ.
        /// </summary>
        public const string C_WRFL_RDCMST = "RDCMST";

        #endregion マスタファイル名.

        #region マスタファイル内項目(テレビCM秒数マスタ).
        /// <summary>
        /// カード区分.
        /// </summary>       
        public const string C_TVCM_CARDKBN = "CardKbn";
        /// <summary>
        /// 年月.
        /// </summary>
        public const string C_TVCM_YEARMONTH = "YearMonth";
        /// <summary>
        /// 代理店.
        /// </summary>
        public const string C_TVCM_DAIRITENCD = "DairitenCd";
        /// <summary>
        /// 媒体区分.
        /// </summary>
        public const string C_TVCM_BAITAIKBN = "baitaiKbn";
        /// <summary>
        /// 番組コード.
        /// </summary>
        public const string C_TVCM_BANGUMICD = "BangumiCd";
        /// <summary>
        /// ブランドコード.
        /// </summary>
        public const string C_TVCM_BRANDCD = "BrandCd";
        /// <summary>
        /// ブランド名称.
        /// </summary>
        public const string C_TVCM_BRANNAME = "BrandName";
        /// <summary>
        /// 局誌コード.
        /// </summary>
        public const string C_TVCM_KYOKUSICD = "KyokusiCd";
        /// <summary>
        /// 局誌名称.
        /// </summary>
        public const string C_TVCM_KYOKUSINAME = "KyokusiName";
        /// <summary>
        /// ネットローカル区分.
        /// </summary>
        public const string C_TVCM_NETFC = "NetFc";
        /// <summary>
        /// 府県コード.
        /// </summary>
        public const string C_TVCM_FUKENCD = "FukenCd";
        /// <summary>
        /// Val1.
        /// </summary>
        public const string C_TVCM_VAL1 = "Val1";
        /// <summary>
        /// Val2.
        /// </summary>
        public const string C_TVCM_VAL2 = "Val2";
        /// <summary>
        /// Val3.
        /// </summary>
        public const string C_TVCM_VAL3 = "Val3";
        /// <summary>
        /// Val4.
        /// </summary>
        public const string C_TVCM_VAL4 = "Val4";
        /// <summary>
        /// 合計.
        /// </summary>
        public const string C_TVCM_GOKEI = "Gokei";
        /// <summary>
        /// 総秒数.
        /// </summary>
        public const string C_TVCM_SOBYOSU = "Sobyosu";
        /// <summary>
        /// 秒数.
        /// </summary>
        public const string C_TVCM_BYOSU = "Byosu";
        /// <summary>
        /// Val5.
        /// </summary>
        public const string C_TVCM_VAL5 = "Val5";
        /// <summary>
        /// Val6.
        /// </summary>
        public const string C_TVCM_VAL6 = "Val6";
        /// <summary>
        /// 放送回数.
        /// </summary>
        public const string C_TVCM_ONAIRKAISU = "OnAirKaisu";
        /// <summary>
        /// データ処理コード.
        /// </summary>
        public const string C_TVCM_DATASYORICD = "DataSyoriCd";

        #endregion マスタファイル内項目(テレビCM秒数マスタ).

        #region マスタファイル内項目(ラジオCM秒数マスタ).

        /// <summary>
        /// カード区分.
        /// </summary>       
        public const string C_RDCM_CARDKBN = "CardKbn";
        /// <summary>
        /// 年月.
        /// </summary>
        public const string C_RDCM_YEARMONTH = "YearMonth";
        /// <summary>
        /// 代理店コード.
        /// </summary>
        public const string C_RDCM_DAIRITENCD = "DairitenCd";
        /// <summary>
        /// 媒体区分.
        /// </summary>
        public const string C_RDCM_BAITAIKBN = "baitaiKbn";
        /// <summary>
        /// 番組コード.
        /// </summary>
        public const string C_RDCM_BANGUMICD = "BangumiCd";
        /// <summary>
        /// ブランドコード.
        /// </summary>
        public const string C_RDCM_BRANDCD = "BrandCd";
        /// <summary>
        /// ブランド名称.
        /// </summary>
        public const string C_RDCM_BRANNAME = "BrandName";
        /// <summary>
        /// 局誌コード.
        /// </summary>
        public const string C_RDCM_KYOKUSICD = "KyokusiCd";
        /// <summary>
        /// 局誌名称.
        /// </summary>
        public const string C_RDCM_KYOKUSINAME = "KyokusiName";
        /// <summary>
        /// ネットローカル区分.
        /// </summary>
        public const string C_RDCM_NETFC = "NetFc";
        /// <summary>
        /// 府県コード.
        /// </summary>
        public const string C_RDCM_FUKENCD = "FukenCd";
        /// <summary>
        /// Val1.
        /// </summary>
        public const string C_RDCM_VAL1 = "Val1";
        /// <summary>
        /// Val2.
        /// </summary>
        public const string C_RDCM_VAL2 = "Val2";
        /// <summary>
        /// Val3.
        /// </summary>
        public const string C_RDCM_VAL3 = "Val3";
        /// <summary>
        /// Val4.
        /// </summary>
        public const string C_RDCM_VAL4 = "Val4";
        /// <summary>
        /// 合計.
        /// </summary>
        public const string C_RDCM_GOKEI = "Gokei";
        /// <summary>
        /// 総秒数.
        /// </summary>
        public const string C_RDCM_SOBYOSU = "Sobyosu";
        /// <summary>
        /// 秒数.
        /// </summary>
        public const string C_RDCM_BYOSU = "Byosu";
        /// <summary>
        /// Val5.
        /// </summary>
        public const string C_RDCM_VAL5 = "Val5";
        /// <summary>
        /// Val6.
        /// </summary>
        public const string C_RDCM_VAL6 = "Val6";
        /// <summary>
        /// 放送回数.
        /// </summary>
        public const string C_RDCM_ONAIRKAISU = "OnAirKaisu";
        /// <summary>
        /// データ処理コード.
        /// </summary>
        public const string C_RDCM_DATASYORICD = "DataSyoriCd";

        #endregion マスタファイル内項目(ラジオCM秒数マスタ).

        #region マスタファイル内項目(テレビ系列局金額設定マスタ).

        /// <summary>
        /// 番組コード.
        /// </summary>       
        public const string C_TVRY_BANCD = "BanCd";
        /// <summary>
        /// 放送局コード.
        /// </summary>
        public const string C_TVRY_KYOKUCD = "KyokuCd";
        /// <summary>
        /// 系列区分.
        /// </summary>
        public const string C_TVRY_KEIRETUCD = "KeiretuCD";
        /// <summary>
        /// 電波料金.
        /// </summary>
        public const string C_TVRY_DENPARYO = "DenpaRyo";
        /// <summary>
        /// ネット料金.
        /// </summary>
        public const string C_TVRY_NETRYO = "NetRyo";

        #endregion マスタファイル内項目(テレビ系列局金額設定マスタ).

        #region マスタファイル内項目(ラジオ系列局金額設定マスタ).

        /// <summary>
        /// 番組コード.
        /// </summary>       
        public const string C_RDRY_BANCD = "BanCd";
        /// <summary>
        /// 放送局コード.
        /// </summary>
        public const string C_RDRY_KYOKUCD = "KyokuCd";
        /// <summary>
        /// 系列区分.
        /// </summary>
        public const string C_RDRY_KEIRETUCD = "KeiretuCD";
        /// <summary>
        /// 電波料金.
        /// </summary>
        public const string C_RDRY_DENPARYO = "DenpaRyo";
        /// <summary>
        /// ネット料金.
        /// </summary>
        public const string C_RDRY_NETRYO = "NetRyo";

        #endregion マスタファイル内項目(ラジオ系列局金額設定マスタ).

        #region マスタファイル内項目(テレビ番組マスタ).

        /// <summary>
        /// 登録タイムスタンプ.
        /// </summary>       
        public const string C_TVBN_TRKTIMSTMP = "trkTimStmp";
        /// <summary>
        /// 登録プログラム.
        /// </summary>
        public const string C_TVBN_TRKPL = "trkPl";
        /// <summary>
        /// 登録担当者.
        /// </summary>
        public const string C_TVBN_TRKTNT = "trkTnt";
        /// <summary>
        /// 更新タイムスタンプ.
        /// </summary>
        public const string C_TVBN_UPDTIMSTMP = "updTimStmp";
        /// <summary>
        /// 更新プログラム.
        /// </summary>
        public const string C_TVBN_UPDAPL = "updApl";
        /// <summary>
        /// 更新担当者.
        /// </summary>
        public const string C_TVBN_UPDTNT = "updTnt";
        /// <summary>
        /// 営業所コード.
        /// </summary>
        public const string C_TVBN_EGCD = "egCd"; 
        /// <summary>
        /// 得意先企業コード.
        /// </summary>
        public const string C_TVBN_TKSKGYCD = "tksKgyCd";
        /// <summary>
        /// 得意先部門SEQNO.
        /// </summary>
        public const string C_TVBN_TKSBMNSEQNO = "tksBmnSeqNo";
        /// <summary>
        /// 得意先担当SEQNO.
        /// </summary>
        public const string C_TVBN_TKSTNTSEQNO = "tksTntSeqNo";
        /// <summary>
        /// 番組コード.
        /// </summary>
        public const string C_TVBN_BANCD = "BANCD";
        /// <summary>
        /// 番組名.
        /// </summary>
        public const string C_TVBN_BANNAME = "BANNAME";
        /// <summary>
        /// 放送局コード.
        /// </summary>
        public const string C_TVBN_HKYOKUCD = "HKYOKUCD";
        /// <summary>
        /// 製作費.
        /// </summary>
        public const string C_TVBN_SEISAKUHI = "SEISAKUHI";
        /// <summary>
        /// 表示順.
        /// </summary>
        public const string C_TVBN_HYOJIJYUN = "HYOJIJYUN";
        /// <summary>
        /// 単価.
        /// </summary>
        public const string C_TVBN_TANKA = "TANKA";
        /// <summary>
        /// タイプ2.
        /// </summary>
        public const string C_TVBN_TYPE2 = "TYPE2";

        #endregion マスタファイル内項目(テレビ番組マスタ).

        #region マスタファイル内項目(ラジオ番組マスタ).

        /// <summary>
        /// 登録タイムスタンプ.
        /// </summary>       
        public const string C_RDBN_TRKTIMSTMP = "trkTimStmp";
        /// <summary>
        /// 登録プログラム.
        /// </summary>
        public const string C_RDBN_TRKPL = "trkPl";
        /// <summary>
        /// 登録担当者.
        /// </summary>
        public const string C_RDBN_TRKTNT = "trkTnt";
        /// <summary>
        /// 更新タイムスタンプ.
        /// </summary>
        public const string C_RDBN_UPDTIMSTMP = "updTimStmp";
        /// <summary>
        /// 更新プログラム.
        /// </summary>
        public const string C_RDBN_UPDAPL = "updApl";
        /// <summary>
        /// 更新担当者.
        /// </summary>
        public const string C_RDBN_UPDTNT = "updTnt";
        /// <summary>
        /// 営業所コード.
        /// </summary>
        public const string C_RDBN_EGCD = "egCd";
        /// <summary>
        /// 得意先企業コード.
        /// </summary>
        public const string C_RDBN_TKSKGYCD = "tksKgyCd";
        /// <summary>
        /// 得意先部門SEQNO.
        /// </summary>
        public const string C_RDBN_TKSBMNSEQNO = "tksBmnSeqNo";
        /// <summary>
        /// 得意先担当SEQNO.
        /// </summary>
        public const string C_RDBN_TKSTNTSEQNO = "tksTntSeqNo";
        /// <summary>
        /// 番組コード.
        /// </summary>
        public const string C_RDBN_BANCD = "BANCD";
        /// <summary>
        /// 番組名.
        /// </summary>
        public const string C_RDBN_BANNAME = "BANNAME";
        /// <summary>
        /// 放送局コード.
        /// </summary>
        public const string C_RDBN_HKYOKUCD = "HKYOKUCD";
        /// <summary>
        /// 製作費.
        /// </summary>
        public const string C_RDBN_SEISAKUHI = "SEISAKUHI";
        /// <summary>
        /// 表示順.
        /// </summary>
        public const string C_RDBN_HYOJIJYUN = "HYOJIJYUN";
        /// <summary>
        /// 単価.
        /// </summary>
        public const string C_RDBN_TANKA = "TANKA";
        /// <summary>
        /// タイプ2.
        /// </summary>
        public const string C_RDBN_TYPE2 = "TYPE2";

        #endregion マスタファイル内項目(ラジオ番組マスタ).

        #region マスタファイル内項目(テレビ局マスタ).

        /// <summary>
        /// 登録タイムスタンプ.
        /// </summary>       
        public const string C_TVK_TRKTIMSTMP = "trkTimStmp";
        /// <summary>
        /// 登録プログラム.
        /// </summary>
        public const string C_TVK_TRKPL = "trkPl";
        /// <summary>
        /// 登録担当者.
        /// </summary>
        public const string C_TVK_TRKTNT = "trkTnt";
        /// <summary>
        /// 更新タイムスタンプ.
        /// </summary>
        public const string C_TVK_UPDTIMSTMP = "updTimStmp";
        /// <summary>
        /// 更新プログラム.
        /// </summary>
        public const string C_TVK_UPDAPL = "updApl";
        /// <summary>
        /// 更新担当者.
        /// </summary>
        public const string C_TVK_UPDTNT = "updTnt";
        /// <summary>
        /// 営業所コード.
        /// </summary>
        public const string C_TVK_EGCD = "egCd";
        /// <summary>
        /// 得意先企業コード.
        /// </summary>
        public const string C_TVK_TKSKGYCD = "tksKgyCd";
        /// <summary>
        /// 得意先部門SEQNO.
        /// </summary>
        public const string C_TVK_TKSBMNSEQNO = "tksBmnSeqNo";
        /// <summary>
        /// 得意先担当SEQNO.
        /// </summary>
        public const string C_TVK_TKSTNTSEQNO = "tksTntSeqNo";
        /// <summary>
        /// 放送局コード.
        /// </summary>
        public const string C_TVK_KYOKUCD = "KYOKUCD";
        /// <summary>
        /// 放送局名.
        /// </summary>
        public const string C_TVK_KYOKUNAME = "KYOKUNAME";
        /// <summary>
        /// 記号.
        /// </summary>
        public const string C_TVK_KIGOU = "KIGOU";
        /// <summary>
        /// 系列.
        /// </summary>
        public const string C_TVK_KEIRETSU = "KEIRETSU";
        /// <summary>
        /// 地区.
        /// </summary>
        public const string C_TVK_TIKU = "TIKU";
        /// <summary>
        /// 地区表示順.
        /// </summary>
        public const string C_TVK_THYOJIJYUN = "THYOJIJYUN";
        /// <summary>
        /// 表示順.
        /// </summary>
        public const string C_TVK_HYOJIJYUN = "HYOJIJYUN";

        #endregion マスタファイル内項目(テレビ局マスタ).

        #region マスタファイル内項目(ラジオ局マスタ).

        /// <summary>
        /// 登録タイムスタンプ.
        /// </summary>       
        public const string C_RDK_TRKTIMSTMP = "trkTimStmp";
        /// <summary>
        /// 登録プログラム.
        /// </summary>
        public const string C_RDK_TRKPL = "trkPl";
        /// <summary>
        /// 登録担当者.
        /// </summary>
        public const string C_RDK_TRKTNT = "trkTnt";
        /// <summary>
        /// 更新タイムスタンプ.
        /// </summary>
        public const string C_RDK_UPDTIMSTMP = "updTimStmp";
        /// <summary>
        /// 更新プログラム.
        /// </summary>
        public const string C_RDK_UPDAPL = "updApl";
        /// <summary>
        /// 更新担当者.
        /// </summary>
        public const string C_RDK_UPDTNT = "updTnt";
        /// <summary>
        /// 営業所コード.
        /// </summary>
        public const string C_RDK_EGCD = "egCd";
        /// <summary>
        /// 得意先企業コード.
        /// </summary>
        public const string C_RDK_TKSKGYCD = "tksKgyCd";
        /// <summary>
        /// 得意先部門SEQNO.
        /// </summary>
        public const string C_RDK_TKSBMNSEQNO = "tksBmnSeqNo";
        /// <summary>
        /// 得意先担当SEQNO.
        /// </summary>
        public const string C_RDK_TKSTNTSEQNO = "tksTntSeqNo";
        /// <summary>
        /// 放送局コード.
        /// </summary>
        public const string C_RDK_KYOKUCD = "KYOKUCD";
        /// <summary>
        /// 放送局名.
        /// </summary>
        public const string C_RDK_KYOKUNAME = "KYOKUNAME";
        /// <summary>
        /// 記号.
        /// </summary>
        public const string C_RDK_KIGOU = "KIGOU";
        /// <summary>
        /// 系列.
        /// </summary>
        public const string C_RDK_KEIRETSU = "KEIRETSU";
        /// <summary>
        /// 表示順.
        /// </summary>
        public const string C_RDK_HYOJIJYUN = "HYOJIJYUN";

        #endregion マスタファイル内項目(ラジオ局マスタ).

        #region システムマスタ用定数.

        /// <summary>
        /// 種別(システムマスタ画面系)
        /// </summary>       
        public const string C_WRFL_SYBT = "003";
        /// <summary>
        /// 種別(ライオン用ワークテーブル)
        /// </summary>
        public const string C_WRKT_SYBT = "007";
        /// <summary>
        /// アドレス用.
        /// </summary>
        public const string C_SMASTA_FLD1 = "002";
        //public const string C_SMASTF_FLD1 = "002"; // ファイル用.
        /// <summary>
        /// 読込CSVファイル名.
        /// </summary>
        public const string C_WRKTF_FLD1 = "001";
        /// <summary>
        /// 読込CSVファイルタイムスタンプ.
        /// </summary>
        public const string C_WRKTT_FLD1 = "002";

        #endregion システムマスタ用定数.

        #region 費目コード.

        /// <summary>
        /// 費目コード(電波).
        /// </summary>
        public const string C_HIMOKUCD_DENPA = "002";
        /// <summary>
        /// 費目コード(局製作費).
        /// </summary>
        public const string C_HIMOKUCD_KYOKU_SEISAKU = "006";

        #endregion 費目コード.

        #region 請求区分.

        /// <summary>
        /// 新聞.
        /// </summary>
        public const string gcstrSeikbn_Np = "11";
        /// <summary>
        /// 雑誌.
        /// </summary>
        public const string gcstrSeikbn_Mz = "21";
        /// <summary>
        /// タイム.
        /// </summary>
        public const string gcstrSeikbn_Tm = "41";
        /// <summary>
        /// スポット.
        /// </summary>
        public const string gcstrSeikbn_Sp = "42";

        #endregion 請求区分.

        #region 明細項目INDEX値.

        /// <summary>
        /// カラム数.
        /// </summary>
        public const int COLIDX_MLIST_COUNT = 38;
        /// <summary>
        /// カードNo.
        /// </summary>
        public const int COLIDX_MLIST_CARDNO = 0;
        /// <summary>
        /// 請求書番号.
        /// </summary>
        public const int COLIDX_MLIST_SEIKYUNO = 1;
        /// <summary>
        /// 年月.
        /// </summary>
        public const int COLIDX_MLIST_YYMM = 2;
        /// <summary>
        /// 代理店コード.
        /// </summary>
        public const int COLIDX_MLIST_DAIRITEN = 3;
        /// <summary>
        /// 媒体区分.
        /// </summary>
        public const int COLIDX_MLIST_BAITAI = 4;
        /// <summary>
        /// 番組コード.
        /// </summary>
        public const int COLIDX_MLIST_BANGCD = 5;
        /// <summary>
        /// 費目コード.
        /// </summary>
        public const int COLIDX_MLIST_HIMKCD = 6;
        /// <summary>
        /// ブランドコード.
        /// </summary>
        public const int COLIDX_MLIST_BRANDCD = 7;
        /// <summary>
        /// 府県コード.
        /// </summary>
        public const int COLIDX_MLIST_FUKENCD = 8;
        /// <summary>
        /// 局誌コード.
        /// </summary>
        public const int COLIDX_MLIST_KYOKUSICD = 9;
        /// <summary>
        /// 局誌名称.
        /// </summary>
        public const int COLIDX_MLIST_STR1 = 10;
        /// <summary>
        /// ネットFC.
        /// </summary>
        public const int COLIDX_MLIST_NETFC = 11;
        /// <summary>
        /// スペース.
        /// </summary>
        public const int COLIDX_MLIST_SPACE = 12;
        /// <summary>
        /// 宣伝費.
        /// </summary>
        public const int COLIDX_MLIST_INT1 = 13;
        /// <summary>
        /// 実施電波料.
        /// </summary>
        public const int COLIDX_MLIST_JISIDENPA = 14;
        /// <summary>
        /// 値引率.
        /// </summary>
        public const int COLIDX_MLIST_NBKRITU = 15;
        /// <summary>
        /// 値引電波料.
        /// </summary>
        public const int COLIDX_MLIST_NBKDENPARYO = 16;
        /// <summary>
        /// ネット料.
        /// </summary>
        public const int COLIDX_MLIST_NETRYO = 17;
        /// <summary>
        /// タイアップ製作費.
        /// </summary>
        public const int COLIDX_MLIST_INT2 = 18;
        /// <summary>
        /// 値引後金額.
        /// </summary>
        public const int COLIDX_MLIST_NBKGOKNGK = 19;
        /// <summary>
        /// 消費税率.
        /// </summary>
        public const int COLIDX_MLIST_TAXRITU = 20;
        /// <summary>
        /// 消費税額.
        /// </summary>
        public const int COLIDX_MLIST_TAX = 21;
        /// <summary>
        /// 本数.
        /// </summary>
        public const int COLIDX_MLIST_HONSU = 22;
        /// <summary>
        /// 秒数.
        /// </summary>
        public const int COLIDX_MLIST_BYOSU = 23;
        /// <summary>
        /// 総秒数.
        /// </summary>
        public const int COLIDX_MLIST_SOBYOSU = 24;
        /// <summary>
        /// 放送回数.
        /// </summary>
        public const int COLIDX_MLIST_HOSOSU = 25;
        /// <summary>
        /// 休止回数.
        /// </summary>
        public const int COLIDX_MLIST_KYUSISU = 26;
        /// <summary>
        /// 放送回数.
        /// </summary>
        public const int COLIDX_MLIST_ONAIRSU = 27;
        /// <summary>
        /// 件名.
        /// </summary>
        public const int COLIDX_MLIST_KENMEI = 28;
        /// <summary>
        /// 掲載日・号・等.
        /// </summary>
        public const int COLIDX_MLIST_KEISAI = 29;
        /// <summary>
        /// 路線名.
        /// </summary>
        public const int COLIDX_MLIST_ROSEN = 30;
        /// <summary>
        /// 期間.
        /// </summary>
        public const int COLIDX_MLIST_KIKAN = 31;
        /// <summary>
        /// 備考.
        /// </summary>
        public const int COLIDX_MLIST_BIKO = 32;
        /// <summary>
        /// 売上明細No.
        /// </summary>
        public const int COLIDX_MLIST_URIMEI = 33;
        /// <summary>
        /// 表示順序.
        /// </summary>
        public const int COLIDX_MLIST_HYOJIJYN = 34;
        /// <summary>
        /// 地区合計.
        /// </summary>
        public const int COLIDX_MLIST_TIKUGO = 35;
        /// <summary>
        /// 地区コード.
        /// </summary>
        public const int COLIDX_MLIST_TIKUCD = 36;
        /// <summary>
        /// 件名変更.
        /// </summary>
        public const int COLIDX_MLIST_KENCHANGE = 37;

        #endregion 明細項目INDEX値.

        #region 明細項目名.

        /// <summary>
        /// カードNo.
        /// </summary>
        public const string COLSTR_MLIST_CARDNO = "カードNO";
        /// <summary>
        /// 請求書番号.
        /// </summary>
        public const string COLSTR_MLIST_SEIKYUNO = "請求書番号";
        /// <summary>
        /// 年月.
        /// </summary>
        public const string COLSTR_MLIST_YYMM = "年月";
        /// <summary>
        /// 代理店コード.
        /// </summary>
        public const string COLSTR_MLIST_DAIRITEN = "代理店CD";
        /// <summary>
        /// 媒体区分.
        /// </summary>
        public const string COLSTR_MLIST_BAITAI = "媒体区分";
        /// <summary>
        /// 番組コード.
        /// </summary>
        public const string COLSTR_MLIST_BANGCD = "番組CD";
        /// <summary>
        /// 費目コード.
        /// </summary>
        public const string COLSTR_MLIST_HIMKCD = "費目CD";
        /// <summary>
        /// ブランドコード.
        /// </summary>
        public const string COLSTR_MLIST_BRANDCD = "ブランド名";
        /// <summary>
        /// 府県コード.
        /// </summary>
        public const string COLSTR_MLIST_FUKENCD = "府県CD";
        /// <summary>
        /// 局誌コード.
        /// </summary>
        public const string COLSTR_MLIST_KYOKUSICD = "局誌CD";
        /// <summary>
        /// 局誌名称.
        /// </summary>
        public const string COLSTR_MLIST_STR1_KYOKU = "局誌名称";
        /// <summary>
        /// 県名称.
        /// </summary>
        public const string COLSTR_MLIST_STR1_KEN = "県名称";
        /// <summary>
        /// 媒体名称.
        /// </summary>
        public const string COLSTR_MLIST_STR1_BAITAI = "媒体名称";
        /// <summary>
        /// ネットFC.
        /// </summary>
        public const string COLSTR_MLIST_NETFC = "ネットFC";
        /// <summary>
        /// スペース.
        /// </summary>
        public const string COLSTR_MLIST_SPACE = "スペース";
        /// <summary>
        /// 実施料.
        /// </summary>
        public const string COLSTR_MLIST_INT1_JISI = "実施料";
        /// <summary>
        /// 宣伝費.
        /// </summary>
        public const string COLSTR_MLIST_INT1_SENDEN = "宣伝費";
        /// <summary>
        /// 実施電波料.
        /// </summary>
        public const string COLSTR_MLIST_JISIDENPA = "実施電波料";
        /// <summary>
        /// 値引率.
        /// </summary>
        public const string COLSTR_MLIST_NBKRITU = "値引率";
        /// <summary>
        /// 値引電波料.
        /// </summary>
        public const string COLSTR_MLIST_NBKDENPARYO = "値引き電波料";
        /// <summary>
        /// ネット料.
        /// </summary>
        public const string COLSTR_MLIST_NETRYO = "ネット料	";
        /// <summary>
        /// 製作費.
        /// </summary>
        public const string COLSTR_MLIST_INT2_SEISAKU = "制作費";
        /// <summary>
        /// タイアップ製作費.
        /// </summary>
        public const string COLSTR_MLIST_INT2_TAIUP = "タイアップ制作費";
        /// <summary>
        /// 値引後金額.
        /// </summary>
        public const string COLSTR_MLIST_NBKGOKNGK = "値引後金額";
        /// <summary>
        /// 消費税率.
        /// </summary>
        public const string COLSTR_MLIST_TAXRITU = "消費税率";
        /// <summary>
        /// 消費税額.
        /// </summary>
        public const string COLSTR_MLIST_TAX = "消費税";
        /// <summary>
        /// 本数.
        /// </summary>
        public const string COLSTR_MLIST_HONSU = "本数";
        /// <summary>
        /// 秒数.
        /// </summary>
        public const string COLSTR_MLIST_BYOSU = "秒数";
        /// <summary>
        /// 総秒数.
        /// </summary>
        public const string COLSTR_MLIST_SOBYOSU = "総秒数";
        /// <summary>
        /// 放送回数.
        /// </summary>
        public const string COLSTR_MLIST_HOSOSU = "放送回数";
        /// <summary>
        /// 休止回数.
        /// </summary>
        public const string COLSTR_MLIST_KYUSISU = "休止回数";
        /// <summary>
        /// 放送回数.
        /// </summary>
        public const string COLSTR_MLIST_ONAIRSU = "オンエア回数";
        /// <summary>
        /// 件名.
        /// </summary>
        public const string COLSTR_MLIST_KENMEI = "件名";
        /// <summary>
        /// 掲載日・号・等.
        /// </summary>
        public const string COLSTR_MLIST_KEISAI = "掲載日・号・等";
        /// <summary>
        /// 路線名.
        /// </summary>
        public const string COLSTR_MLIST_ROSEN = "路線名";
        /// <summary>
        /// 期間.
        /// </summary>
        public const string COLSTR_MLIST_KIKAN = "期間";
        /// <summary>
        /// 備考.
        /// </summary>
        public const string COLSTR_MLIST_BIKO = "備考";
        /// <summary>
        /// 売上明細No.
        /// </summary>
        public const string COLSTR_MLIST_URIMEI = "売上明細Ｎｏ";
        /// <summary>
        /// 表示順序.
        /// </summary>
        public const string COLSTR_MLIST_HYOJIJYN = "表示順序";
        /// <summary>
        /// 地区合計.
        /// </summary>
        public const string COLSTR_MLIST_TIKUGO = "地区合計";
        /// <summary>
        /// 地区コード.
        /// </summary>
        public const string COLSTR_MLIST_TIKUCD = "地区ＣＤ";
        /// <summary>
        /// 件名変更.
        /// </summary>
        public const string COLSTR_MLIST_KENCHANGE = "件名変更";

        #endregion 明細項目名.

        #region 明細項目TYPE用

        // 明細登録、入力用　明細項目INDEX値 
        /// <summary>
        /// 
        /// </summary>
        public const string COLSTR_KMKTYPE_1 = "1";
        /// <summary>
        /// 
        /// </summary>
        public const string COLSTR_KMKTYPE_2 = "2";
        /// <summary>
        /// 
        /// </summary>
        public const string COLSTR_KMKTYPE_3 = "3";
        /// <summary>
        /// 
        /// </summary>
        public const string COLSTR_KMKTYPE_4 = "4";
        /// <summary>
        /// 
        /// </summary>
        public const string COLSTR_KMKTYPE_5 = "5";
        /// <summary>
        /// 
        /// </summary>
        public const string COLSTR_KMKTYPE_6 = "6";
        /// <summary>
        /// 
        /// </summary>
        public const string COLSTR_KMKTYPE_7 = "7";
        /// <summary>
        /// 
        /// </summary>
        public const string COLSTR_KMKTYPE_8 = "8";
        /// <summary>
        /// 
        /// </summary>
        public const string COLSTR_KMKTYPE_9 = "9";
        /// <summary>
        /// 
        /// </summary>
        public const string COLSTR_KMKTYPE_10 = "10";
        /// <summary>
        /// 
        /// </summary>
        public const string COLSTR_KMKTYPE_11 = "11";

        #endregion 明細項目TYPE用.

        #region 媒体orカードNO.

        /// <summary>
        /// 業務.
        /// </summary>
        public const string COLSTR_BTPATARN = "1";
        /// <summary>
        /// カードNO.
        /// </summary>
        public const string COLSTR_CDPATARN = "2";

        #endregion 媒体orカードNO.

        #region カードNO.

        /// <summary>
        /// テレビネット.
        /// </summary>
        public const string COLSTR_CARDNO_TVNET = "001";
        /// <summary>
        /// テレビローカル.
        /// </summary>
        public const string COLSTR_CARDNO_TVLCL = "002";
        /// <summary>
        /// ラジオネット.
        /// </summary>
        public const string COLSTR_CARDNO_RDNET = "003";
        /// <summary>
        /// ラジオローカル.
        /// </summary>
        public const string COLSTR_CARDNO_RDLCL = "004";
        /// <summary>
        /// スポット.
        /// </summary>
        public const string COLSTR_CARDNO_SPOT = "005";
        /// <summary>
        /// CM秒数.
        /// </summary>
        public const string COLSTR_CARDNO_CMTIME = "006";
        /// <summary>
        /// 新聞.
        /// </summary>
        public const string COLSTR_CARDNO_SINBN = "007";
        /// <summary>
        /// 雑誌.
        /// </summary>
        public const string COLSTR_CARDNO_ZASSI = "008";
        /// <summary>
        /// 交通.
        /// </summary>
        public const string COLSTR_CARDNO_KOTU = "009";
        /// <summary>
        /// その他.
        /// </summary>
        public const string COLSTR_CARDNO_SONOTA = "010";
        /// <summary>
        /// 制作.
        /// </summary>
        public const string COLSTR_CARDNO_SEISAKU = "012";
        /// <summary>
        /// チラシ.
        /// </summary>
        public const string COLSTR_CARDNO_CHIRASI = "014";
        /// <summary>
        /// サンプリング.
        /// </summary>
        public const string COLSTR_CARDNO_SAMPLING = "015";
        /// <summary>
        /// BS/CS
        /// </summary>
        public const string COLSTR_CARDNO_BSCS = "016";
        /// <summary>
        /// インターネット.
        /// </summary>
        public const string COLSTR_CARDNO_INTERNET = "017";
        /// <summary>
        /// モバイル.
        /// </summary>
        public const string COLSTR_CARDNO_MOBIL = "018";
        /// <summary>
        /// 事業費.
        /// </summary>
        public const string COLSTR_CARDNO_JIGYOHI = "019";

        #endregion カードNO.

        #region 業務区分.

        /// <summary>
        /// テレビ.
        /// </summary>
        public const string COLSTR_GYOM_TV = "11040";
        /// <summary>
        /// ラジオ.
        /// </summary>
        public const string COLSTR_GYOM_RD = "11030";
        /// <summary>
        /// BS/CS.
        /// </summary>
        public const string COLSTR_GYOM_BSCS = "11050";
        /// <summary>
        /// インタラクティブ.
        /// </summary>
        public const string COLSTR_GYOM_INTARACTIVE = "11060";
        /// <summary>
        /// スポット.
        /// </summary>
        public const string COLSTR_GYOM_SPOT = "11045";
        /// <summary>
        /// 新聞.
        /// </summary>
        public const string COLSTR_GYOM_SINBN = "11010";
        /// <summary>
        /// 雑誌.
        /// </summary>
        public const string COLSTR_GYOM_ZASSI = "11020";
        /// <summary>
        /// 交通.
        /// </summary>
        public const string COLSTR_GYOM_KOTU = "11070";
        /// <summary>
        /// 制作.
        /// </summary>
        public const string COLSTR_GYOM_SEISAKU = "12010";
        /// <summary>
        /// その他1.
        /// </summary>
        public const string COLSTR_GYOM_SONOTA1 = "11080";
        /// <summary>
        /// その他2.
        /// </summary>
        public const string COLSTR_GYOM_SONOTA2 = "11090";
        /// <summary>
        /// その他3.
        /// </summary>
        public const string COLSTR_GYOM_SONOTA3 = "13010";
        /// <summary>
        /// その他4.
        /// </summary>
        public const string COLSTR_GYOM_SONOTA4 = "14010";
        /// <summary>
        /// その他5.
        /// </summary>
        public const string COLSTR_GYOM_SONOTA5 = "14020";
        /// <summary>
        /// その他6.
        /// </summary>
        public const string COLSTR_GYOM_SONOTA6 = "14030";

        #endregion 業務区分.

        #region 媒体区分

        // 媒体区分 
        /// <summary>
        /// テレビタイム.
        /// </summary>
        public const string BAITAIKBN_TV = "01";
        /// <summary>
        /// テレビスポット.
        /// </summary>
        public const string BAITAIKBN_TV_SPOT = "02";
        /// <summary>
        /// ラジオタイム.
        /// </summary>
        public const string BAITAIKBN_RD = "04";
        /// <summary>
        /// ラジオスポット.
        /// </summary>
        public const string BAITAIKBN_RD_SPOT = "05";
        /// <summary>
        /// 新聞.
        /// </summary>
        public const string BAITAIKBN_NP = "07";
        /// <summary>
        /// 雑誌.
        /// </summary>
        public const string BAITAIKBN_MZ = "09";
        /// <summary>
        /// 交通広告.
        /// </summary>
        public const string BAITAIKBN_OOH = "11";
        /// <summary>
        /// その他(間接広告費).
        /// </summary>
        public const string BAITAIKBN_OTHER = "13";
        /// <summary>
        /// チラシ.
        /// </summary>
        public const string BAITAIKBN_CHIRASHI = "14";
        /// <summary>
        /// サンプリング.
        /// </summary>
        public const string BAITAIKBN_SAMPLE = "15";
        /// <summary>
        /// BS/CS
        /// </summary>
        public const string BAITAIKBN_BSCS = "16";
        /// <summary>
        /// インターネット.
        /// </summary>
        public const string BAITAIKBN_INT = "17";
        /// <summary>
        /// モバイル.
        /// </summary>
        public const string BAITAIKBN_MOB = "18";
        /// <summary>
        /// 事業費.
        /// </summary>
        public const string BAITAIKBN_JIGYO = "19";
        /// <summary>
        /// TVCM制作.
        /// </summary>
        public const string BAITAIKBN_TVCF = "20";
        /// <summary>
        /// TVCFプリント費.
        /// </summary>
        public const string BAITAIKBN_SEISAK_TVCFPRINT = "21";
        /// <summary>
        /// 生CM.
        /// </summary>
        public const string BAITAIKBN_SEISAK_CM = "23";
        /// <summary>
        /// 調査費.
        /// </summary>
        public const string BAITAIKBN_SEISAK_CHOSA = "24";
        /// <summary>
        /// 制作ラジオ.
        /// </summary>
        public const string BAITAIKBN_SEISAK_RD = "25";
        /// <summary>
        /// 制作新聞.
        /// </summary>
        public const string BAITAIKBN_SEISAK_NP = "27";
        /// <summary>
        /// 制作雑誌.
        /// </summary>
        public const string BAITAIKBN_SEISAK_MZ = "29";
        /// <summary>
        /// タレント.
        /// </summary>
        public const string BAITAIKBN_SEISAK_TALENT = "31";
        /// <summary>
        /// WEB.
        /// </summary>
        public const string BAITAIKBN_SEISAK_WEB = "33";
        /// <summary>
        /// 雑広告.
        /// </summary>
        public const string BAITAIKBN_SEISAK_KOKOKU = "35";
        /// <summary>
        /// 制作交通.
        /// </summary>
        public const string BAITAIKBN_SEISAK_OOH = "36";
        /// <summary>
        /// 間接費.
        /// </summary>
        public const string BAITAIKBN_SEISAK_KANSETSU = "37";
        /// <summary>
        /// 開発費.
        /// </summary>
        public const string BAITAIKBN_SEISAK_KAIHATSU = "38";
        /// <summary>
        /// パッケージ制作.
        /// </summary>
        public const string BAITAIKBN_SEISAK_PACKAGE = "39";
        /// <summary>
        /// 制作消費税1.
        /// </summary>
        public const string BAITAIKBN_SEISAK_TAX1 = "40";
        /// <summary>
        /// 制作消費税2.
        /// </summary>
        public const string BAITAIKBN_SEISAK_TAX2 = "41";
        /// <summary>
        /// 媒体消費税1.
        /// </summary>
        public const string BAITAIKBN_BAITAI_TAX1 = "50";

        #endregion 媒体区分.

        #region 費目コード.

        /// <summary>
        /// 費目コード:電波.
        /// </summary>
        public const string gcstrHimoku_Denpa = "002";
        /// <summary>
        /// 費目コード:局製作費.
        /// </summary>
        public const string gcstrHimoku_Seisaku = "006";
        /// <summary>
        /// 費目コード:回線料.
        /// </summary>
        public const string gcstrHimoku_Kaisen = "007";

        #endregion 費目コード.

        #endregion

        #endregion

    }
}
