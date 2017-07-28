using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHUtility.Constants;

namespace Isid.KKH.Kmn.Utility
{
    /// <summary>
    /// 公文 明細入力、一括登録ダイアログ用共通クラス 
    /// </summary>
    class KKHKmnDetailDisp
    {
        # region 業務区分 
        /// <summary>
        /// 新聞 
        /// </summary>
        public const string C_GYOM_SHINBUN = KKHSystemConst.GyomKbn.Shinbun;
        /// <summary>
        /// 雑誌 
        /// </summary>
        public const string C_GYOM_ZASHI = KKHSystemConst.GyomKbn.Zashi;
        /// <summary>
        /// ラジオ 
        /// </summary>
        public const string C_GYOM_RADIO = KKHSystemConst.GyomKbn.Radio;
        /// <summary>
        /// テレビタイム 
        /// </summary>
        public const string C_GYOM_TVT = KKHSystemConst.GyomKbn.TVTime;
        /// <summary>
        /// テレビスポット 
        /// </summary>
        public const string C_GYOM_TVS = KKHSystemConst.GyomKbn.TVSpot;
        /// <summary>
        /// 衛星メディア 
        /// </summary>
        public const string C_GYOM_EISEIM = KKHSystemConst.GyomKbn.EiseiM;
        /// <summary>
        /// OOHメディア 
        /// </summary>
        public const string C_GYOM_OOHM = KKHSystemConst.GyomKbn.OohM;
        /// <summary>
        /// インタラクティブメディア 
        /// </summary>
        public const string C_GYOM_INTEM = KKHSystemConst.GyomKbn.InteractiveM;
        /// <summary>
        /// その他メディア 
        /// </summary>
        public const string C_GYOM_SONOM = KKHSystemConst.GyomKbn.SonotaM;
        /// <summary>
        /// メディアプランニング 
        /// </summary>
        public const string C_GYOM_MPLAN = KKHSystemConst.GyomKbn.MPlan;
        /// <summary>
        /// クリエーティブ 
        /// </summary>
        public const string C_GYOM_CREAT = KKHSystemConst.GyomKbn.Creative;
        /// <summary>
        /// マーケティング/プロモーション 
        /// </summary>
        public const string C_GYOM_MARPRO = KKHSystemConst.GyomKbn.MarkePromo;
        /// <summary>
        /// スポーツ 
        /// </summary>
        public const string C_GYOM_SPO = KKHSystemConst.GyomKbn.Sports;
        /// <summary>
        /// エンタテイメント 
        /// </summary>
        public const string C_GYOM_ENTE = KKHSystemConst.GyomKbn.Entertainment;
        /// <summary>
        /// その他コンテンツ 
        /// </summary>
        public const string C_GYOM_SONOC = KKHSystemConst.GyomKbn.SonotaC;
        # endregion 業務区分 

        /// <summary>
        /// 業務区分ごとに品目に設定する受注の値を取得する 
        /// </summary>
        /// <param name="GyomKbn"></param>
        /// <param name="jyuData"></param>
        public string[] SetJuchuValue_himoku(string GyomKbn, Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[] jyuData, Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow)
        {
            // 戻す配列初期化 
            string[] resultArray = new string[3];

            //種別ごとの処理 
            switch (GyomKbn)
            {
                # region 新聞 

                // 新聞 
                case C_GYOM_SHINBUN:

                    // 統合データの場合 
                    if (dataRow.hb1TouFlg == "1")
                    {
                        // 品目１ [件名] 
                        resultArray[0] = dataRow.hb1KKNameKJ;

                        if (jyuData.Length > 0)
                        {
                            // 品目２ [受注データの件数] 
                            resultArray[1] = "中央紙・地方紙 全" + jyuData.Length + "紙";
                        }


                        // 品目３ [掲載期間] 
                        // 請求区分ごとに期間をセット 
                        // 2013/04/23 期間のFromToをMin値～Max値に変更対応 JSE M.Naito start 
                        //_seiKbn = _dataRow.hb1SeiKbn.ToString().Trim(); 

                        //string hmk3 = _dataRow.hb1Field12.ToString().Trim(); 
                        //if (hmk3.Length == 16) 
                        //{ 
                        //    string strFrom = hmk3.Substring(0, 4) + "/" + hmk3.Substring(4, 2) + "/" + hmk3.Substring(6, 2); 
                        //    string strTo = hmk3.Substring(8, 4) + "/" + hmk3.Substring(12, 2) + "/" + hmk3.Substring(14, 2); 

                        //    resultArray[2] = strFrom + "～" + strTo; 
                        //} 
                        //String kikan = SetKikanValue(_seiKbn, _dataRow); 
                        //if (kikan != "") 
                        //{ 
                        //    if (kikan.Length == 16) 
                        //    { 
                        // 2013/04/23 期間のFromToをMin値～Max値に変更対応 JSE M.Naito start 
                        //string strFrom = kikan.Substring(0, 4) + "/" + kikan.Substring(4, 2) + "/" + kikan.Substring(6, 2); 
                        //string strTo = kikan.Substring(8, 4) + "/" + kikan.Substring(12, 2) + "/" + kikan.Substring(14, 2); 

                        //// 品目３ [放送期間] 
                        //resultArray[2] = strFrom + "～" + strTo; 

                        // 品目３ [放送期間] 
                        resultArray[2] = GetKikanFromTo(jyuData);
                        // 2013/04/23 期間のFromToをMin値～Max値に変更対応 JSE M.Naito start 
                        //    } 
                        //} 
                        // 2013/04/23 期間のFromToをMin値～Max値に変更対応 JSE M.Naito end 
                    }
                    // 統合データ以外の場合 

                    else
                    {
                        // 品目１ [件名] 
                        resultArray[0] = dataRow.hb1KKNameKJ;

                        // 朝夕取得 
                        string asayuNm = string.Empty;
                        if (dataRow.hb1Field4 == "1")
                        {
                            asayuNm = KkhConstKmn.TyouSekiNm.MORNING + "刊";
                        }
                        else if (dataRow.hb1Field4 == "2")
                        {
                            asayuNm = KkhConstKmn.TyouSekiNm.EVENING + "刊";
                        }
                        // 品目２ [媒体名　朝夕] 
                        resultArray[1] = dataRow.hb1Field2 + " " + asayuNm;

                        // 品目３ [掲載版 記雑区分 掲載面 スペース] 
                        resultArray[2] = dataRow.hb1Field6 + " " + dataRow.hb1Field8 + " " + dataRow.hb1Field10 + " " + dataRow.hb1Field11;
                    }
                    break;
                #endregion 新聞 


                # region TVタイム 
                // TVタイム 
                case C_GYOM_TVT:

                    // 統合データの場合 
                    if (dataRow.hb1TouFlg == "1")
                    {
                        // 品目１ [件名] 
                        resultArray[0] = dataRow.hb1KKNameKJ;

                        // 秒数項目が入っている場合 

                        if (dataRow.hb1Field5.Trim().Length > 0)
                        {
                            // 品目２ [キー局 秒数] 
                            resultArray[1] = dataRow.hb1Field1 + " " + dataRow.hb1Field5.TrimStart('0') + "秒";
                        }
                        // 秒数項目が入っていない場合 

                        else
                        {
                            // 品目２ [キー局] 
                            resultArray[1] = dataRow.hb1Field1;
                        }

                        // 請求区分ごとに期間をセット 
                        // 2013/04/23 期間のFromToをMin値～Max値に変更対応 JSE M.Naito start 
                        //_seiKbn = _dataRow.hb1SeiKbn.ToString().Trim(); 
                        // 2013/04/23 期間のFromToをMin値～Max値に変更対応 JSE M.Naito end 
                        //String kikan = SetKikanValue(_seiKbn,_dataRow); 
                        //if (kikan != "") 
                        //{ 
                        //    if (kikan.Length == 16) 
                        //    { 
                        // 2013/04/23 期間のFromToをMin値～Max値に変更対応 JSE M.Naito start 
                        //string strFrom = kikan.Substring(0, 4) + "/" + kikan.Substring(4, 2) + "/" + kikan.Substring(6, 2); 
                        //string strTo = kikan.Substring(8, 4) + "/" + kikan.Substring(12, 2) + "/" + kikan.Substring(14, 2); 

                        //// 品目３ [放送期間] 
                        //resultArray[2] = strFrom + "～" + strTo; 

                        // 品目３ [放送期間] 
                        resultArray[2] = GetKikanFromTo(jyuData);
                        // 2013/04/23 期間のFromToをMin値～Max値に変更対応 JSE M.Naito start 
                        //    } 
                        //} 
                    }
                    // 統合データ以外の場合 

                    else
                    {
                        // 品目１ [件名] 
                        resultArray[0] = dataRow.hb1KKNameKJ;

                        // 曜日の取得 

                        string weekStr = WeekDayGet(dataRow.hb1Field8, dataRow.hb1Field7);

                        // 曜日が取得できている場合 

                        if (weekStr.Trim().Length > 0)
                        {
                            // 回数項目が入っている場合 

                            if (dataRow.hb1Field6.Trim().Length > 0)
                            {
                                // 品目２ [キー局 曜日 回数] 
                                resultArray[1] = dataRow.hb1Field1 + " " + WeekDayGet(dataRow.hb1Field8, dataRow.hb1Field7) + "毎週 " + dataRow.hb1Field6.TrimStart('0') + "回";
                            }
                            // 回数項目が入っていない場合 

                            else
                            {
                                // 品目２ [キー局 曜日] 
                                resultArray[1] = dataRow.hb1Field1 + " " + WeekDayGet(dataRow.hb1Field8, dataRow.hb1Field7) + "毎週";
                            }
                        }
                        // 曜日が取得できていない場合 

                        else
                        {
                            // 回数項目が入っている場合 

                            if (dataRow.hb1Field6.Trim().Length > 0)
                            {
                                // 品目２ [キー局 回数] 
                                resultArray[1] = dataRow.hb1Field1 + " " + dataRow.hb1Field6.TrimStart('0') + "回";
                            }
                            // 回数項目が入っていない場合 

                            else
                            {
                                // 品目２ [キー局] 
                                resultArray[1] = dataRow.hb1Field1;
                            }
                        }

                        // 秒数が取得できている場合 

                        if (dataRow.hb1Field5.Trim().Length > 0)
                        {
                            // 品目３ [放送時間 秒数] 
                            resultArray[2] = dataRow.hb1Field4 + " " + dataRow.hb1Field5.TrimStart('0') + "秒";
                        }
                        // 秒数が取得できていない場合 

                        else
                        {
                            // 品目３ [放送時間 秒数] 
                            resultArray[2] = dataRow.hb1Field4;
                        }
                    }

                    break;
                #endregion TVタイム 

                # region TVスポット 

                // TVスポット 

                case C_GYOM_TVS:

                    // 統合データの場合 

                    if (dataRow.hb1TouFlg == "1")
                    {
                        // 品目１ [件名] 
                        resultArray[0] = dataRow.hb1KKNameKJ;

                        if (jyuData.Length > 0)
                        {
                            // 秒数が取得できている場合 

                            if (dataRow.hb1Field5.Trim().Length > 0)
                            {
                                // 品目２ [放送局数 秒数] 
                                resultArray[1] = "全" + jyuData.Length + "局" + dataRow.hb1Field5.TrimStart('0') + "秒";
                            }
                            else
                            {
                                // 品目２ [放送局数] 
                                resultArray[1] = "全" + jyuData.Length + "局";
                            }
                        }
                        else
                        {
                            // 秒数が取得できている場合 

                            if (dataRow.hb1Field5.Trim().Length > 0)
                            {
                                // 品目２ [秒数] 
                                resultArray[1] = dataRow.hb1Field5.TrimStart('0') + "秒";
                            }
                            else
                            {
                                // 品目２ [] 
                                resultArray[1] = "";
                            }
                        }

                        // 請求区分ごとに期間をセット 
                        // 2013/04/23 期間のFromToをMin値～Max値に変更対応 JSE M.Naito start 
                        //_seiKbn = _dataRow.hb1SeiKbn.ToString().Trim(); 
                        //String kikan = SetKikanValue(_seiKbn, _dataRow); 
                        //if (kikan != "") 
                        //{ 
                        //    if (kikan.Length == 16) 
                        //    { 
                        //string strFrom = kikan.Substring(0, 4) + "/" + kikan.Substring(4, 2) + "/" + kikan.Substring(6, 2); 
                        //string strTo = kikan.Substring(8, 4) + "/" + kikan.Substring(12, 2) + "/" + kikan.Substring(14, 2); 

                        //// 品目３ [放送期間] 
                        //resultArray[2] = strFrom + "～" + strTo; 

                        // 品目３ [放送期間] 
                        resultArray[2] = GetKikanFromTo(jyuData);
                        // 2013/04/23 期間のFromToをMin値～Max値に変更対応 JSE M.Naito end 
                        //    } 
                        //} 
                    }
                    // 統合データ以外の場合 

                    else
                    {
                        // 品目１ [件名] 
                        resultArray[0] = dataRow.hb1KKNameKJ;

                        // 局ネット数が取得できている場合 

                        if (dataRow.hb1Field3.Trim().Length > 0)
                        {
                            // 品目２ [代表局 放送局数] 
                            resultArray[1] = dataRow.hb1Field1 + " " + dataRow.hb1Field3 + "局ﾈｯﾄ";
                        }
                        else
                        {
                            // 品目２ [代表局] 
                            resultArray[1] = dataRow.hb1Field1;
                        }

                        // 秒数が取得できている場合 

                        if (dataRow.hb1Field5.Trim().Length > 0)
                        {
                            // 品目３ [秒数] 
                            resultArray[2] = dataRow.hb1Field5.TrimStart('0') + "秒";
                        }
                        else
                        {
                            // 品目３ [秒数] 
                            resultArray[2] = "";
                        }
                    }
                    break;
                #endregion TVスポット 


                # region 雑誌 

                // 雑誌 

                case C_GYOM_ZASHI:

                    // 統合データの場合 

                    if (dataRow.hb1TouFlg == "1")
                    {
                        // 品目１ [件名] 
                        resultArray[0] = dataRow.hb1KKNameKJ;

                        // 媒体名が取得できている場合 

                        if (dataRow.hb1Field2.Trim().Length > 0)
                        {
                            // 品目２ [媒体名] 
                            resultArray[1] = dataRow.hb1Field2 + "他 計" + jyuData.Length + "誌";
                        }
                        // 媒体名が取得できていない場合 

                        else
                        {
                            // 品目２ [] 
                            resultArray[1] = "計" + jyuData.Length + "誌";
                        }

                        // 請求区分ごとに期間をセット 
                        // 2013/04/23 期間のFromToをMin値～Max値に変更対応 JSE M.Naito start 
                        //_seiKbn = _dataRow.hb1SeiKbn.ToString().Trim(); 
                        //String kikan = SetKikanValue(_seiKbn, _dataRow); 
                        //if (kikan != "") 
                        //{ 
                        //    if (kikan.Length == 16) 
                        //    { 
                        //string strFrom = kikan.Substring(0, 4) + "/" + kikan.Substring(4, 2) + "/" + kikan.Substring(6, 2); 
                        //string strTo = kikan.Substring(8, 4) + "/" + kikan.Substring(12, 2) + "/" + kikan.Substring(14, 2); 

                        //// 品目３ [放送期間] 
                        //resultArray[2] = strFrom + "～" + strTo; 

                        // 品目３ [放送期間] 
                        resultArray[2] = GetKikanFromTo(jyuData);
                        // 2013/04/23 期間のFromToをMin値～Max値に変更対応 JSE M.Naito end 
                        //    } 
                        //} 
                    }
                    // 統合データ以外の場合 

                    else
                    {
                        // 品目１ [件名] 
                        resultArray[0] = dataRow.hb1KKNameKJ;

                        // 品目２ [媒体名 掲載号] 
                        resultArray[1] = dataRow.hb1Field2 + dataRow.hb1Field4;

                        // 品目３ [掲載種別 掲載条件 スペース] 
                        resultArray[2] = dataRow.hb1Field6 + " " + dataRow.hb1Field8 + " " + dataRow.hb1Field9;
                    }
                    break;
                #endregion 雑誌 


                # region インタラクティブメディア 
                // インタラクティブメディア 
                case C_GYOM_INTEM:

                    // 統合データの場合 

                    if (dataRow.hb1TouFlg == "1")
                    {
                        // 品目１ [件名] 
                        resultArray[0] = dataRow.hb1KKNameKJ;

                        // 補足内容(正味)が取得できている場合 

                        if (dataRow.hb1Field4.Trim().Length > 0)
                        {
                            // 品目２ [補足内容(正味)] 
                            resultArray[1] = dataRow.hb1Field4 + "他";
                        }
                        // 補足内容(正味)が取得できていない場合 

                        else
                        {
                            // 品目２ [] 
                            resultArray[1] = "";
                        }

                        // 請求区分ごとに期間をセット 
                        // 2013/04/23 期間のFromToをMin値～Max値に変更対応 JSE M.Naito start 
                        //_seiKbn = _dataRow.hb1SeiKbn.ToString().Trim(); 
                        //String kikan = SetKikanValue(_seiKbn, _dataRow); 
                        //if (kikan != "") 
                        //{ 
                        //    if (kikan.Length == 16) 
                        //    { 
                        //string strFrom = kikan.Substring(0, 4) + "/" + kikan.Substring(4, 2) + "/" + kikan.Substring(6, 2); 
                        //string strTo = kikan.Substring(8, 4) + "/" + kikan.Substring(12, 2) + "/" + kikan.Substring(14, 2); 

                        //// 品目３ [放送期間] 
                        //resultArray[2] = strFrom + "～" + strTo; 

                        resultArray[2] = GetKikanFromTo(jyuData);
                        // 2013/04/23 期間のFromToをMin値～Max値に変更対応 JSE M.Naito end 
                        //    } 
                        //} 
                    }
                    // 統合データ以外の場合 

                    else
                    {
                        // 品目１ [件名] 
                        resultArray[0] = dataRow.hb1KKNameKJ;

                        // 品目２ [補足内容(正味)] 
                        resultArray[1] = dataRow.hb1Field4;

                        // 品目３ [媒体名] 
                        resultArray[2] = dataRow.hb1Field2;
                    }

                    break;
                #endregion インタラクティブメディア

                default:
                    // 品目１ [件名] 
                    resultArray[0] = dataRow.hb1KKNameKJ;

                    // 品目２ [] 
                    resultArray[1] = string.Empty;

                    // 品目３ [] 
                    resultArray[2] = string.Empty;
                    break;
            }

            return resultArray;
        }

        /// <summary>
        /// 業務区分ごとに内容に設定する受注の値を取得する.
        /// </summary>
        /// <param name="GyomKbn"></param>
        /// <param name="jyuRow"></param>
        public string SetJuchuValue_naiyo(string GyomKbn, Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow jyuRow)
        {
            KKHKmnDetailDisp detailDisp = new KKHKmnDetailDisp();

            // 配列初期化

            string[] resultArray_tmp = new string[3];
            // 戻す変数初期化

            string resultStr = string.Empty;

            //種別ごとの処理 
            switch (GyomKbn)
            {
                # region 新聞

                // 新聞

                case C_GYOM_SHINBUN:

                    // [件名]
                    resultArray_tmp[0] = jyuRow.hb1KKNameKJ;

                    // 朝夕取得
                    string asayuNm = string.Empty;
                    if (jyuRow.hb1Field4 == "1")
                    {
                        asayuNm = KkhConstKmn.TyouSekiNm.MORNING + "刊";
                    }
                    else if (jyuRow.hb1Field4 == "2")
                    {
                        asayuNm = KkhConstKmn.TyouSekiNm.EVENING + "刊";
                    }
                    // [媒体名　朝夕]
                    resultArray_tmp[1] = jyuRow.hb1Field2 + " " + asayuNm;

                    // [掲載版 記雑区分 掲載面 スペース]
                    resultArray_tmp[2] = jyuRow.hb1Field6 + " " + jyuRow.hb1Field8 + " " + jyuRow.hb1Field10 + " " + jyuRow.hb1Field11;

                    break;
                #endregion 新聞


                # region TVタイム
                // TVタイム
                case C_GYOM_TVT:

                    // [件名]
                    resultArray_tmp[0] = jyuRow.hb1KKNameKJ;


                    // 曜日の取得

                    string weekStr = detailDisp.WeekDayGet(jyuRow.hb1Field8, jyuRow.hb1Field7);

                    // 曜日が取得できている場合

                    if (weekStr.Trim().Length > 0)
                    {
                        // 回数項目が入っている場合

                        if (jyuRow.hb1Field6.Trim().Length > 0)
                        {
                            // 品目２ [キー局 曜日 回数]
                            resultArray_tmp[1] = jyuRow.hb1Field1 + " " + detailDisp.WeekDayGet(jyuRow.hb1Field8, jyuRow.hb1Field7) + "毎週 " + jyuRow.hb1Field6.TrimStart('0') + "回";
                        }
                        // 回数項目が入っていない場合

                        else
                        {
                            // 品目２ [キー局 曜日]
                            resultArray_tmp[1] = jyuRow.hb1Field1 + " " + detailDisp.WeekDayGet(jyuRow.hb1Field8, jyuRow.hb1Field7) + "毎週";
                        }
                    }
                    // 曜日が取得できていない場合

                    else
                    {
                        // 回数項目が入っている場合

                        if (jyuRow.hb1Field6.Trim().Length > 0)
                        {
                            // 品目２ [キー局 回数]
                            resultArray_tmp[1] = jyuRow.hb1Field1 + " " + jyuRow.hb1Field6.TrimStart('0') + "回";
                        }
                        // 回数項目が入っていない場合

                        else
                        {
                            // 品目２ [キー局]
                            resultArray_tmp[1] = jyuRow.hb1Field1;
                        }
                    }

                    // 秒数が取得できている場合

                    if (jyuRow.hb1Field5.Trim().Length > 0)
                    {
                        // 品目３ [放送時間 秒数]
                        resultArray_tmp[2] = jyuRow.hb1Field4 + " " + jyuRow.hb1Field5.TrimStart('0') + "秒";
                    }
                    // 秒数が取得できていない場合

                    else
                    {
                        // 品目３ [放送時間 秒数]
                        resultArray_tmp[2] = jyuRow.hb1Field4;
                    }

                    break;
                #endregion TVタイム

                # region TVスポット
                // TVスポット

                case C_GYOM_TVS:

                    // 品目１ [件名]
                    resultArray_tmp[0] = jyuRow.hb1KKNameKJ;

                    // 局ネット数が取得できている場合

                    if (jyuRow.hb1Field3.Trim().Length > 0)
                    {
                        // 品目２ [代表局 放送局数]
                        resultArray_tmp[1] = jyuRow.hb1Field1 + " " + jyuRow.hb1Field3 + "局ﾈｯﾄ";
                    }
                    else
                    {
                        // 品目２ [代表局]
                        resultArray_tmp[1] = jyuRow.hb1Field1;
                    }

                    // 秒数が取得できている場合

                    if (jyuRow.hb1Field5.Trim().Length > 0)
                    {
                        // 品目３ [秒数]
                        resultArray_tmp[2] = jyuRow.hb1Field5.TrimStart('0') + "秒";
                    }
                    else
                    {
                        // 品目３ [秒数]
                        resultArray_tmp[2] = "";
                    }

                    break;
                #endregion TVスポット


                # region 雑誌

                // 雑誌

                case C_GYOM_ZASHI:

                    // [件名]
                    resultArray_tmp[0] = jyuRow.hb1KKNameKJ;

                    // [媒体名 掲載号]
                    resultArray_tmp[1] = jyuRow.hb1Field2 + jyuRow.hb1Field4;

                    // [掲載種別 掲載条件 スペース]
                    resultArray_tmp[2] = jyuRow.hb1Field6 + " " + jyuRow.hb1Field8 + " " + jyuRow.hb1Field9;

                    break;
                #endregion 雑誌


                # region インタラクティブメディア
                // インタラクティブメディア
                case C_GYOM_INTEM:

                    // [件名]
                    resultArray_tmp[0] = jyuRow.hb1KKNameKJ;

                    // [補足内容(正味)]
                    resultArray_tmp[1] = jyuRow.hb1Field4;

                    // [媒体名]
                    resultArray_tmp[2] = jyuRow.hb1Field2;

                    break;
                #endregion インタラクティブメディア

                default:
                    // [件名]
                    resultArray_tmp[0] = jyuRow.hb1KKNameKJ;

                    // []
                    resultArray_tmp[1] = string.Empty;

                    // []
                    resultArray_tmp[2] = string.Empty;
                    break;
            }

            // 配列に格納した文字列をスペースで連結

            if (resultArray_tmp[0].Trim() != "")
            {
                resultStr = resultArray_tmp[0].Trim();
            }
            if (resultArray_tmp[1].Trim() != "")
            {
                if (resultStr.Trim() != "")
                {
                    resultStr = resultStr + " " + resultArray_tmp[1].Trim();
                }
                else
                {
                    resultStr = resultArray_tmp[1].Trim();
                }
            }
            if (resultArray_tmp[2].Trim() != "")
            {
                if (resultStr.Trim() != "")
                {
                    resultStr = resultStr + " " + resultArray_tmp[2].Trim();
                }
                else
                {
                    resultStr = resultArray_tmp[2].Trim();
                }
            }

            return resultStr;
        }

        // 2013/04/23 期間のFromToをMin値～Max値に変更対応 JSE M.Naito  
        /// <summary>
        /// 期間From～Toの取得 
        /// </summary>
        /// <param name="dataRows"></param>
        /// <returns></returns>
        public string GetKikanFromTo(Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[] dataRows)
        {
            // 返却用変数 
            string result = string.Empty;

            // 変数初期化 

            string minFrom = string.Empty;
            string maxTo = string.Empty;
            string strFromTo = string.Empty;
            string seiKbn = string.Empty;

            // 受注データの件数分回してmin日付とmax日付を取得 

            foreach (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow row in dataRows)
            {

                seiKbn = row.hb1SeiKbn.ToString().Trim();
                String kikan = SetKikanValue(seiKbn, row);

                if (kikan != "")
                {
                    if (kikan.Length == 16)
                    {
                        // Fromの中から暫定Min値を取得 

                        int minFrom_tmp = int.Parse(kikan.Substring(0, 8));
                        // Toの中から暫定Max値を取得 

                        int maxTo_tmp = int.Parse(kikan.Substring(8, 8));

                        // min値取得 

                        if (minFrom.Equals(""))
                        {
                            minFrom = minFrom_tmp.ToString();
                        }
                        else
                        {
                            // Min値判定　暫定Min値の方が小さい場合 

                            if (int.Parse(minFrom) > minFrom_tmp)
                            {
                                // Min値交代 
                                minFrom = minFrom_tmp.ToString();
                            }
                        }

                        // max値取得 

                        if (maxTo.Equals(""))
                        {
                            maxTo = maxTo_tmp.ToString();
                        }
                        else
                        {
                            // Max値判定　暫定Max値の方が大きい場合 

                            if (int.Parse(maxTo) < maxTo_tmp)
                            {
                                // Max値交代 
                                maxTo = maxTo_tmp.ToString();
                            }
                        }
                    }

                    // 期間の値が取得できている場合 

                    if (!minFrom.Equals("") && !maxTo.Equals(""))
                    {
                        // 形式変更 
                        string strFrom = minFrom.Substring(0, 4) + "/" + minFrom.Substring(4, 2) + "/" + minFrom.Substring(6, 2);
                        string strTo = maxTo.Substring(0, 4) + "/" + maxTo.Substring(4, 2) + "/" + maxTo.Substring(6, 2);

                        // 期間をセット 
                        result = strFrom + "-" + strTo;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 請求区分ごとに期間の値を返す  
        /// </summary>
        /// <param name="seiKbn"></param>
        /// <param name="row"></param>
        public String SetKikanValue(string seiKbn, Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow row)
        {
            String kikan = "";
            switch (seiKbn)
            {
                case KKHSystemConst.SeiKbn.NewsPaper:   // 新聞 
                    kikan = row.hb1Field12.ToString().Trim();
                    break;

                case KKHSystemConst.SeiKbn.Magazine:    // 雑誌 
                    kikan = row.hb1Field10.ToString().Trim();
                    break;

                case KKHSystemConst.SeiKbn.Time:        // タイム 
                    kikan = row.hb1Field8.ToString().Trim();
                    break;

                case KKHSystemConst.SeiKbn.Spot:        // スポット 
                    kikan = row.hb1Field4.ToString().Trim();
                    break;

                case KKHSystemConst.SeiKbn.IC:          // IC 
                    kikan = row.hb1Field5.ToString().Trim();
                    break;

                case KKHSystemConst.SeiKbn.Ooh:         // 交通広告 
                    kikan = row.hb1Field5.ToString().Trim();
                    break;

                case KKHSystemConst.SeiKbn.Works:       // 諸作業 
                    kikan = row.hb1Field5.ToString().Trim();
                    break;

                case KKHSystemConst.SeiKbn.KMas:        // 国際マス 
                    kikan = row.hb1Field3.ToString().Trim();
                    break;

                case KKHSystemConst.SeiKbn.KWorks:      // 国際(諸作業） 

                    kikan = row.hb1Field4.ToString().Trim();
                    break;
            }
            return kikan;
        }

        /// <summary>
        /// 放送曜日の取得 
        /// </summary>
        /// <param name="Yymm"></param>
        /// <param name="week"></param>
        /// <returns></returns>
        public string WeekDayGet(string Yymm, string week)
        {
            //長さが16以外は処理しない 

            if (Yymm.Length != 16)
            {
                return string.Empty;
            }
            if (string.IsNullOrEmpty(week))
            {
                return string.Empty;
            }
            //曜日セット 
            string Youbi = string.Empty;
            //日付取得 

            int day = 0;
            //日付(string) 
            string strDay = string.Empty;
            //年月の取得 

            string newYymm = Yymm.Substring(0, 4) + "/" + Yymm.Substring(4, 2);
            //曜日重複チェック 
            string tfFlag = string.Empty;
            //曜日取得分繰り返す 
            for (int i = 0; i < week.Replace("0", string.Empty).Length; i++)
            {
                day = week.IndexOf("1", day) + 1;
                if (day.ToString().Length == 1)
                {
                    strDay = "0" + day.ToString();
                }
                else
                {
                    strDay = day.ToString();
                }
                DateTime dt = DateTime.Parse(newYymm + "/" + strDay);

                //曜日のセット 
                switch (dt.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        if (tfFlag.Contains("1")) { break; }
                        Youbi = Youbi + "月";
                        tfFlag = tfFlag + "1";
                        break;
                    case DayOfWeek.Tuesday:
                        if (tfFlag.Contains("2")) { break; }
                        Youbi = Youbi + "火";
                        tfFlag = tfFlag + "2";
                        break;
                    case DayOfWeek.Wednesday:
                        if (tfFlag.Contains("3")) { break; }
                        Youbi = Youbi + "水";
                        tfFlag = tfFlag + "3";
                        break;
                    case DayOfWeek.Thursday:
                        if (tfFlag.Contains("4")) { break; }
                        Youbi = Youbi + "木";
                        tfFlag = tfFlag + "4";
                        break;
                    case DayOfWeek.Friday:
                        if (tfFlag.Contains("5")) { break; }
                        Youbi = Youbi + "金";
                        tfFlag = tfFlag + "5";
                        break;
                    case DayOfWeek.Saturday:
                        if (tfFlag.Contains("6")) { break; }
                        Youbi = Youbi + "土";
                        tfFlag = tfFlag + "6";
                        break;
                    case DayOfWeek.Sunday:
                        if (tfFlag.Contains("7")) { break; }
                        Youbi = Youbi + "日";
                        tfFlag = tfFlag + "7";
                        break;
                }
            }
            return Youbi;
        }
    }
}
