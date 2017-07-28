using System;
using System.Data;

using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;

namespace Isid.KKH.Common.KKHSchema
{
    
    
    public partial class Detail {
        partial class JyutyuListDataTable
        {
        }
    
        partial class THB8DOWNRDataTable
        {
        }
    
        partial class THB5HIKDataTable
        {
        }
    
        partial class THB2KMEIDataTable
        {
        }
    
        partial class JyutyuDataDataTable
        {
            /// <summary>
            /// THB1DOWNの行データを基に該当するレコードを更新します。 
            /// </summary>
            /// <param name="updRow"></param>
            public void UpdateRowDataByTGADOWNRow(THB1DOWNRow updRow){
                string filterEx = this.hb1EgCdColumn.ColumnName + "='" + updRow.hb1EgCd + "'";
                filterEx = filterEx + " AND " + this.hb1TksKgyCdColumn.ColumnName + "='" + updRow.hb1TksKgyCd + "'";
                filterEx = filterEx + " AND " + this.hb1TksBmnSeqNoColumn.ColumnName + "='" + updRow.hb1TksBmnSeqNo + "'";
                filterEx = filterEx + " AND " + this.hb1TksTntSeqNoColumn.ColumnName + "='" + updRow.hb1TksTntSeqNo + "'";
                filterEx = filterEx + " AND " + this.hb1JyutNoColumn.ColumnName + "='" + updRow.hb1JyutNo + "'";
                filterEx = filterEx + " AND " + this.hb1JyMeiNoColumn.ColumnName + "='" + updRow.hb1JyMeiNo + "'";
                filterEx = filterEx + " AND " + this.hb1UrMeiNoColumn.ColumnName + "='" + updRow.hb1UrMeiNo + "'";
                filterEx = filterEx + " AND " + this.hb1TouFlgColumn.ColumnName + "='" + updRow.hb1TouFlg + "'";
                filterEx = filterEx + " AND " + this.hb1YymmColumn.ColumnName + "='" + updRow.hb1Yymm + "'";

                DataRow[] oldRows = Select(filterEx);
                THB1DOWNDataTable dtDataTable = new THB1DOWNDataTable();
                foreach (JyutyuDataRow oldRow in oldRows)
                {
                    foreach (DataColumn column in this.Columns)
                    {
                        if (dtDataTable.Columns.Contains(column.ColumnName))
                        {
                            oldRow[column.ColumnName] = updRow[column.ColumnName];
                        }
                    }
                }
                this.AcceptChanges();
            }
        }
    
        partial class THB1DOWNDataTable
        {
            /// <summary>
            /// THB1DOWNRowを初期値を設定して取得します。 
            /// </summary>
            /// <param name="initFlag"></param>
            /// <returns></returns>
            public THB1DOWNRow NewTHB1DOWNRow(bool initFlag)
            {
                THB1DOWNRow row = this.NewTHB1DOWNRow();
                if (initFlag == true)
                {
                    foreach (DataColumn col in this.Columns)
                    {
                        if (col.DataType.FullName == "System.String")
                        {
                            row[col.ColumnName] = "";
                        }
                        else if (col.DataType.FullName == "System.Decimal")
                        {
                            row[col.ColumnName] = 0.0M;
                        }
                        else
                        {
                        }
                    }
                }

                return row;
            }

            /// <summary>
            /// 主キーの値が同値のレコードを上書きします。 
            /// </summary>
            /// <param name="updRow"></param>
            public void UpdateRowData(THB1DOWNRow updRow)
            {
                THB1DOWNRow oldRow = FindByhb1EgCdhb1TksKgyCdhb1TksBmnSeqNohb1TksTntSeqNohb1JyutNohb1JyMeiNohb1UrMeiNohb1TouFlghb1Yymm(
                                        updRow.hb1EgCd
                                        , updRow.hb1TksKgyCd
                                        , updRow.hb1TksBmnSeqNo
                                        , updRow.hb1TksTntSeqNo
                                        , updRow.hb1JyutNo
                                        , updRow.hb1JyMeiNo
                                        , updRow.hb1UrMeiNo
                                        , updRow.hb1TouFlg
                                        , updRow.hb1Yymm
                                    );

                if (oldRow == null)
                {
                    return;
                }
                foreach (DataColumn column in this.Columns)
                {
                    oldRow[column.ColumnName] = updRow[column.ColumnName];
                }
                oldRow.AcceptChanges();
            }
        }

        /// <summary>
        /// JyutyuDataに保持しているデータからJyutyuListを更新します 
        /// </summary>
        public void UpdateSpdDataByJyutyuData(){
            this.JyutyuList.Clear();
            this.JyutyuDetail.Clear();

            int rowNo = 1;
            foreach (JyutyuDataRow row in JyutyuData.Rows)
            {
                if (row.hb1TJyutNo.Trim().Length == 0)
                {
                    //***************************************
                    //JyutyuListの編集 
                    //***************************************
                    JyutyuListRow addRow = JyutyuList.NewJyutyuListRow();
                    //行番号(連番) 
                    addRow.rowNo = row.rowNum;

                    if (row.hb1TouFlg == "1")
                    {
                        //string filterEx = JyutyuData.hb1EgCdColumn.ColumnName + "='" + row.hb1EgCd + "'";
                        //filterEx = filterEx + " AND " + JyutyuData.hb1TksKgyCdColumn.ColumnName + "='" + row.hb1TksKgyCd + "'";
                        //filterEx = filterEx + " AND " + JyutyuData.hb1TksBmnSeqNoColumn.ColumnName + "='" + row.hb1TksBmnSeqNo + "'";
                        //filterEx = filterEx + " AND " + JyutyuData.hb1TksTntSeqNoColumn.ColumnName + "='" + row.hb1TksTntSeqNo + "'";
                        //filterEx = filterEx + " AND " + JyutyuData.hb1TouFlgColumn.ColumnName + "=''";
                        //filterEx = filterEx + " AND " + JyutyuData.hb1YymmColumn.ColumnName + "='" + row.hb1Yymm + "'";
                        //filterEx = filterEx + " AND " + JyutyuData.hb1TJyutNoColumn.ColumnName + "='" + row.hb1JyutNo + "'";
                        //filterEx = filterEx + " AND " + JyutyuData.hb1TJyMeiNoColumn.ColumnName + "='" + row.hb1JyMeiNo + "'";
                        //filterEx = filterEx + " AND " + JyutyuData.hb1TUrMeiNoColumn.ColumnName + "='" + row.hb1UrMeiNo + "'";
                        //JyutyuDataRow[] childDataRows = (JyutyuDataRow[])JyutyuData.Select(filterEx);
                        //foreach (JyutyuDataRow childDataRow in childDataRows)
                        //{
                        //    if (childDataRow.jyutDelFlg == "1" || childDataRow.stpKbn == "1")
                        //    {
                        //        addRow.jyuHen = "消";
                        //    }
                        //    else if (childDataRow.seikJtai == "0" && childDataRow.seiSagSts == "0" &&
                        //             childDataRow.stpKbn == "0")
                        //    {
                        //        addRow.jyuHen = "仮";
                        //    }
                        //    else if (childDataRow.rMeiTimStmp != "")
                        //    {
                        //        addRow.jyuHen = "変";
                        //    }
                        //    else
                        //    {
                        //        addRow.jyuHen = "";
                        //    }
                        //}

                        // 統合した場合親には何も表示しない
                        addRow.jyuHen = "";
                    }
                    else
                    {
                        if (row.jyutDelFlg == "1" || row.stpKbn == "1")
                        {
                            String str = row.hb1JyutNo.Substring(5, 2);
                            bool flag = true;
                            foreach (char c in str)
                            {
                                //数字以外の文字が含まれているか調べる・
                                if (c < '0' || '9' < c)
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            //ユニチャームの場合、かつ営業画面タイプがnullの場合
                            if (row.hb1TksKgyCd.ToString() == "031054" && row.hb1EgGamenType.Trim().ToString() == "")
                            {                                
                                flag = false;
                            }
                            if (flag)
                            {
                                addRow.jyuHen = "消";
                            }

                            //addRow.jyuHen = "消";
                        }
                        else if (row.seikJtai == "0" && row.seiSagSts == "0" &&
                                 row.stpKbn == "0")
                        {
                            addRow.jyuHen = "仮";
                        }
                        else if (row.rMeiTimStmp != "")
                        {
                            addRow.jyuHen = "変";
                        }
                        else
                        {
                            addRow.jyuHen = "";
                        }
                    }

                    //登録 
                    if (row.hb2JyutNo != "")
                    {
                        addRow.toroku = "済";
                    }
                    else
                    {
                        addRow.toroku = "";
                    }

                    //統合 
                    if (row.hb1TouFlg == "1")
                    {
                        addRow.togo = "統";
                    }
                    else
                    {
                        addRow.togo = "";
                    }

                    //代受 
                    if (row.hb1EgCd != row.hb1AtuEgCd)
                    {
                        addRow.daiuke = "代";
                    }
                    else
                    {
                        addRow.daiuke = "";
                    }

                    //2013/03/06 jse okazaki 公文対応　Start
                    //請求 
                    if (row.seikyu != "")
                    {
                        addRow.seikyu = "済";
                    }
                    else
                    {
                        addRow.seikyu = "";
                    }
                    //2013/03/06 jse okazaki 公文対応　End

                    //売上明細No 
                    addRow.uriMeiNo = row.hb1JyutNo + "-" + row.hb1JyMeiNo + "-" + row.hb1UrMeiNo;

                    //請求原票No 
                    addRow.gpyNo = row.hb1GpyNo;

                    //請求年月 
                    addRow.seiYymm = row.hb1Yymm;

                    //業務区分 
                    addRow.gyomKbn = row.hb1GyomKbn;

                    //件名 
                    addRow.kenmei = row.hb1KKNameKJ;

                    if (row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.NewsPaper
                        || row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.Magazine
                        || row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.KMas
                        )
                    {
                        //媒体名 
                        addRow.baitaiNm = row.hb1Field2;

                        //期間 
                        addRow.kikan = FormatPeriodForMMDD(row.hb1Field3);
                    }
                    else if (row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.Time)
                    {
                        //媒体名 
                        addRow.baitaiNm = row.hb1Field2;

                        //期間 
                        addRow.kikan = FormatPeriodForMMDD(row.hb1Field8);
                    }
                    else if (row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.Spot)
                    {
                        //媒体名 
                        addRow.baitaiNm = row.hb1Field2;

                        //期間 
                        addRow.kikan = FormatPeriodForMMDD(row.hb1Field4);
                    }
                    else if (row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.Ooh
                       || row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.IC
                       || row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.Works
                   )
                    {
                        //媒体名 
                        addRow.baitaiNm = row.hb1Field2;

                        //期間 
                        addRow.kikan = FormatPeriodForMMDD(row.hb1Field5);
                    }
                    else if (row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.KWorks)
                    {
                        //媒体名 
                        addRow.baitaiNm = row.hb1Field3;

                        //期間 
                        addRow.kikan = FormatPeriodForMMDD(row.hb1Field4);
                    }

                    //費目名 
                    addRow.himokuNm = row.hb1HimkNmKJ;

                    //局誌CD 
                    addRow.kyokushiCd = row.hb1Field1;

                    //請求金額 
                    addRow.seiKingaku = row.hb1SeiGak;

                    //段単価 
                    addRow.danTanka = row.hb1SeiTnka;

                    //段数 
                    addRow.danSu = row.hb1Field11;

                    //取料金 
                    addRow.toriRyokin = row.hb1ToriGak;

                    //値引率 
                    addRow.nebikiRitsu = row.hb1NeviRitu;

                    //値引額 
                    addRow.nebikiGaku = row.hb1NeviGak;

                    //消費税率 
                    addRow.zeiritsu = row.hb1SzeiRitu;

                    //消費税額 
                    addRow.zeiGaku = row.hb1SzeiGak;

                    //受注請求金額 
                    addRow.goukeiKingaku = row.hb1SeiGak + row.hb1SzeiGak;

                    //変更前請求年月 
                    addRow.oldSeiYymm = row.hb1YymmOld;

                    //if (row.hb2JyutNo != "")
                    //{
                    //    //登録者 
                    //    addRow.trkTnt = row.hb1TrkTnt;
                    //    //更新者
                    //    addRow.updTnt = row.hb1UpdTnt;
                    //}
                    //else
                    //{
                    //    //登録者 
                    //    addRow.trkTnt = "";
                    //    //更新者
                    //    addRow.updTnt = "";
                    //}

                    //登録者名
                    if (!string.IsNullOrEmpty(row.hb1TrkTntNm.Trim()))
                    {
                        addRow.trkTnt = row.hb1TrkTntNm.Trim();
                    }
                    else
                    {
                        addRow.trkTnt = string.Empty;
                    }

                    //更新者名
                    if (!string.IsNullOrEmpty(row.hb1KsnTntNm.Trim()))
                    {
                        addRow.updTnt = row.hb1KsnTntNm.Trim();
                    }
                    else
                    {
                        addRow.updTnt = string.Empty;
                    }


                    //統合受注NO(親子紐づけ用項目) 
                    addRow.jyutyuNo = row.hb1JyutNo;

                    //統合受注明細NO(親子紐づけ用項目) 
                    addRow.jyMeiNo = row.hb1JyMeiNo;

                    //統合売上明細NO(親子紐づけ用項目) 
                    addRow.urMeiNo = row.hb1UrMeiNo;

                    JyutyuList.AddJyutyuListRow(addRow);
                }
                else
                {
                    //***************************************
                    //JyutyuListの編集 
                    //***************************************
                    JyutyuListChildRow addRow = JyutyuListChild.NewJyutyuListChildRow();
                    //行番号(連番) 
                    addRow.rowNo = row.rowNum;

                    if (row.jyutDelFlg == "1" || row.stpKbn == "1")
                    {
                        String str = row.hb1JyutNo.Substring(5, 2);
                        bool flag = true;
                        foreach (char c in str)
                        {
                            //数字以外の文字が含まれているか調べる・
                            if (c < '0' || '9' < c)
                            {
                                flag = false;
                                break;
                            }
                        }
                        //ユニチャームの場合、かつ営業画面タイプがnullの場合
                        if (row.hb1TksKgyCd.ToString() == "031054" && row.hb1EgGamenType.Trim().ToString() == "")
                        {
                            flag = false;
                        }
                        if (flag)
                        {
                            addRow.jyuHen = "消";
                        }
                        //addRow.jyuHen = "消";
                    }
                    else if (row.seikJtai == "0" && row.seiSagSts == "0" &&
                             row.stpKbn == "0")
                    {
                        addRow.jyuHen = "仮";
                    }
                    else if (row.rMeiTimStmp != "")
                    {
                        addRow.jyuHen = "変";
                    }
                    else
                    {
                        addRow.jyuHen = "";
                    }

                    // 暫定対応として子ビュー側は非表示とする
                    //
                    ////登録 
                    //if (row.hb2JyutNo != "")
                    //{
                    //    addRow.toroku = "済";
                    //}
                    //else
                    //{
                    //    addRow.toroku = "";
                    //}
                    ////統合 
                    //if (row.hb1TouFlg == "1")
                    //{
                    //    addRow.togo = "統";
                    //}
                    //else
                    //{
                    //    addRow.togo = "";
                    //}

                    //代受 
                    if (row.hb1EgCd != row.hb1AtuEgCd)
                    {
                        addRow.daiuke = "代";
                    }
                    else
                    {
                        addRow.daiuke = "";
                    }

                    //2013/03/06 jse okazaki 公文対応　Start
                    //請求 
                    if (row.seikyu != "")
                    {
                        addRow.seikyu = "済";
                    }
                    else
                    {
                        addRow.seikyu = "";
                    }
                    //2013/03/06 jse okazaki 公文対応　End

                    //売上明細No 
                    addRow.uriMeiNo = row.hb1JyutNo + "-" + row.hb1JyMeiNo + "-" + row.hb1UrMeiNo;

                    //請求原票No 
                    addRow.gpyNo = row.hb1GpyNo;

                    //請求年月 
                    addRow.seiYymm = row.hb1Yymm;

                    //業務区分 
                    addRow.gyomKbn = row.hb1GyomKbn;

                    //件名 
                    addRow.kenmei = row.hb1KKNameKJ;
                    if (row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.NewsPaper
                        || row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.Magazine
                        || row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.KMas
                        )
                    {
                        //媒体名 
                        addRow.baitaiNm = row.hb1Field2;

                        //期間 
                        addRow.kikan = FormatPeriodForMMDD(row.hb1Field3);
                    }
                    else if (row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.Time)
                    {
                        //媒体名 
                        addRow.baitaiNm = row.hb1Field2;

                        //期間 
                        addRow.kikan = FormatPeriodForMMDD(row.hb1Field8);
                    }
                    else if (row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.Spot)
                    {
                        //媒体名 
                        addRow.baitaiNm = row.hb1Field2;

                        //期間 
                        addRow.kikan = FormatPeriodForMMDD(row.hb1Field4);
                    }
                    else if (row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.Ooh
                       || row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.IC
                       || row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.Works
                   )
                    {
                        //媒体名 
                        addRow.baitaiNm = row.hb1Field2;

                        //期間 
                        addRow.kikan = FormatPeriodForMMDD(row.hb1Field5);
                    }
                    else if (row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.KWorks)
                    {
                        //媒体名 
                        addRow.baitaiNm = row.hb1Field3;

                        //期間 
                        addRow.kikan = FormatPeriodForMMDD(row.hb1Field4);
                    }

                    //費目名 
                    addRow.himokuNm = row.hb1HimkNmKJ;

                    //局誌CD 
                    addRow.kyokushiCd = row.hb1Field1;

                    //請求金額 
                    addRow.seiKingaku = row.hb1SeiGak;

                    //段単価 
                    addRow.danTanka = row.hb1SeiTnka;

                    //段数 
                    addRow.danSu = row.hb1Field11;

                    //取料金 
                    addRow.toriRyokin = row.hb1ToriGak;

                    //値引率 
                    addRow.nebikiRitsu = row.hb1NeviRitu;

                    //値引額 
                    addRow.nebikiGaku = row.hb1NeviGak;

                    //消費税率 
                    addRow.zeiritsu = row.hb1SzeiRitu;

                    //消費税額 
                    addRow.zeiGaku = row.hb1SzeiGak;

                    //受注請求金額 
                    addRow.goukeiKingaku = row.hb1SeiGak + row.hb1SzeiGak;

                    //変更前請求年月 
                    addRow.oldSeiYymm = row.hb1YymmOld;

                    ////登録者名
                    //if (!string.IsNullOrEmpty(row.hb1TrkTntNm.Trim()))
                    //{
                    //    addRow.trkTnt = row.hb1TrkTntNm.Trim();
                    //}
                    //else
                    //{
                    //    addRow.trkTnt = string.Empty;
                    //}

                    ////更新者名
                    //if (!string.IsNullOrEmpty(row.hb1KsnTntNm.Trim()))
                    //{
                    //    addRow.updTnt = row.hb1KsnTntNm.Trim();
                    //}
                    //else
                    //{
                    //    addRow.updTnt = string.Empty;
                    //}

                    //統合受注NO(親子紐づけ用項目) 
                    addRow.tJyutyuNo = row.hb1TJyutNo;

                    //統合受注明細NO(親子紐づけ用項目) 
                    addRow.tJyMeiNo = row.hb1TJyMeiNo;

                    //統合売上明細NO(親子紐づけ用項目) 
                    addRow.tUrMeiNo = row.hb1TUrMeiNo;

                    // 暫定対応として子ビュー側は非表示とする
                    //
                    //if (row.hb2JyutNo != "")
                    //{
                    //    //登録者 
                    //    addRow.trkTnt = row.hb1TrkTnt;
                    //
                    //    //更新者
                    //    addRow.updTnt = row.hb1UpdTnt;
                    //}
                    //else
                    //{
                    //    //登録者 
                    //    addRow.trkTnt = "";
                    //
                    //    //更新者
                    //    addRow.updTnt = "";
                    //}






                    JyutyuListChild.AddJyutyuListChildRow(addRow);
                }


                //***************************************
                //JyutyuDetailの編集 
                //***************************************
                JyutyuDetailRow addDetailRow = JyutyuDetail.NewJyutyuDetailRow();
                //行番号(連番) 
                addDetailRow.rowNo = row.rowNum;
                if (row.hb1SeiKbn == KKHSystemConst.SeiKbn.NewsPaper)
                {
                    //新聞データ 
                    addDetailRow.Field1 = row.hb1Field1.Trim();
                    addDetailRow.Field2 = row.hb1Field2.Trim();
                    addDetailRow.Field3 = row.hb1Field3.Trim();
                    addDetailRow.Field4 = row.hb1Field4.Trim();
                    addDetailRow.Field5 = row.hb1Field6.Trim();
                    addDetailRow.Field6 = row.hb1Field8.Trim();
                    addDetailRow.Field7 = row.hb1Field10.Trim();
                    addDetailRow.Field8 = row.hb1Field11.Trim();
                    addDetailRow.Field9 = FormatPeriod(row.hb1Field12).Trim();

                    
                }
                else if (row.hb1SeiKbn == KKHSystemConst.SeiKbn.Magazine)
                {
                    //雑誌データ 
                    addDetailRow.Field1 = row.hb1Field1.Trim();
                    addDetailRow.Field2 = row.hb1Field2.Trim();
                    addDetailRow.Field3 = row.hb1Field3.Trim();
                    addDetailRow.Field4 = row.hb1Field4.Trim();
                    addDetailRow.Field5 = row.hb1Field6.Trim();
                    addDetailRow.Field6 = row.hb1Field8.Trim();
                    addDetailRow.Field7 = row.hb1Field9.Trim();
                    addDetailRow.Field8 = FormatPeriod(row.hb1Field10).Trim();
                }
                else if (row.hb1SeiKbn == KKHSystemConst.SeiKbn.Time)
                {
                    //タイムデータ 
                    addDetailRow.Field1 = row.hb1Field1.Trim();
                    addDetailRow.Field2 = row.hb1Field2.Trim();
                    addDetailRow.Field3 = row.hb1Field3.Trim();
                    addDetailRow.Field4 = row.hb1Field4.Trim();
                    addDetailRow.Field5 = row.hb1Field5.Trim();
                    addDetailRow.Field6 = row.hb1Field6.Trim();
                    addDetailRow.Field7 = row.hb1Field7.Trim();
                    addDetailRow.Field8 = FormatPeriod(row.hb1Field8).Trim();
                }
                else if (row.hb1SeiKbn == KKHSystemConst.SeiKbn.Spot)
                {
                    //スポットデータ 
                    addDetailRow.Field1 = row.hb1Field1.Trim();
                    addDetailRow.Field2 = row.hb1Field2.Trim();
                    addDetailRow.Field3 = row.hb1Field3.Trim();
                    addDetailRow.Field4 = FormatPeriod(row.hb1Field4).Trim();
                    addDetailRow.Field5 = row.hb1Field5.Trim();
                    addDetailRow.Field6 = row.hb1Field6.Trim();
                }
                else if (row.hb1SeiKbn == KKHSystemConst.SeiKbn.Works)
                {
                    //諸作業データ 
                    addDetailRow.Field1 = row.hb1Field3.Trim();
                    addDetailRow.Field2 = row.hb1Field4.Trim();
                    addDetailRow.Field3 = FormatPeriod(row.hb1Field5).Trim();
                    addDetailRow.Field4 = row.hb1Field6.Trim();
                }
                else if (row.hb1SeiKbn == KKHSystemConst.SeiKbn.Ooh)
                {
                    //交通広告データ 
                    addDetailRow.Field1 = row.hb1Field7.Trim();
                    addDetailRow.Field2 = row.hb1Field8.Trim();
                    addDetailRow.Field3 = row.hb1Field1.Trim();
                    addDetailRow.Field4 = row.hb1Field2.Trim();
                    addDetailRow.Field5 = row.hb1Field3.Trim();
                    addDetailRow.Field6 = row.hb1Field4.Trim();
                    addDetailRow.Field7 = FormatPeriod(row.hb1Field5).Trim();
                    addDetailRow.Field8 = row.hb1Field6.Trim();
                }
                else if (row.hb1SeiKbn == KKHSystemConst.SeiKbn.KMas)
                {
                    //国際/マスデータ 
                    addDetailRow.Field1 = row.hb1Field1.Trim();
                    addDetailRow.Field2 = row.hb1Field2.Trim();
                    addDetailRow.Field3 = FormatPeriod(row.hb1Field3).Trim();
                    addDetailRow.Field4 = row.hb1Field4.Trim();
                    addDetailRow.Field5 = row.hb1Field5.Trim();
                    addDetailRow.Field6 = row.hb1Field6.Trim();
                    addDetailRow.Field7 = row.hb1Field7.Trim();
                    addDetailRow.Field8 = row.hb1Field8.Trim();
                    addDetailRow.Field9 = row.hb1Field9.Trim();
                    addDetailRow.Field10 = row.hb1Field10.Trim();
                    addDetailRow.Field11 = row.hb1Field11.Trim();
                }
                else if (row.hb1SeiKbn == KKHSystemConst.SeiKbn.KWorks)
                {
                    //国際/諸作業データ 
                    addDetailRow.Field1 = row.hb1Field1.Trim();
                    addDetailRow.Field2 = row.hb1Field2.Trim();
                    addDetailRow.Field3 = row.hb1Field3.Trim();
                    addDetailRow.Field4 = FormatPeriod(row.hb1Field4).Trim();
                    addDetailRow.Field5 = row.hb1Field5.Trim();
                    addDetailRow.Field6 = row.hb1Field6.Trim();
                    addDetailRow.Field7 = row.hb1Field7.Trim();
                    addDetailRow.Field8 = row.hb1Field8.Trim();
                    addDetailRow.Field9 = row.hb1Field9.Trim();
                    addDetailRow.Field10 = row.hb1Field10.Trim();
                    addDetailRow.Field11 = row.hb1Field11.Trim();
                    addDetailRow.Field12 = row.hb1Field12.Trim();
                }
                else if (row.hb1SeiKbn == KKHSystemConst.SeiKbn.IC)
                {
                    //IC(インタラクティブメディア) 
                    addDetailRow.Field1 = row.hb1Field1.Trim();
                    addDetailRow.Field2 = row.hb1Field2.Trim();
                    addDetailRow.Field3 = row.hb1Field3.Trim();
                    addDetailRow.Field4 = row.hb1Field4.Trim();
                    addDetailRow.Field5 = FormatPeriod(row.hb1Field5).Trim();
                    addDetailRow.Field6 = row.hb1Field6.Trim();
                }

                JyutyuDetail.AddJyutyuDetailRow(addDetailRow);


                rowNo = rowNo + 1;
            }
        }

        public void MacUpdateSpdDataByJyutyuData()
        {
            this.JyutyuList.Clear();
            this.JyutyuDetail.Clear();

            int rowNo = 1;
            foreach (JyutyuDataRow row in JyutyuData.Rows)
            {
                if (row.hb1TJyutNo.Trim().Length == 0)
                {
                    //***************************************
                    //JyutyuListの編集 
                    //***************************************
                    JyutyuListRow addRow = JyutyuList.NewJyutyuListRow();
                    //行番号(連番) 
                    addRow.rowNo = row.rowNum;

                    if (row.hb1TouFlg == "1")
                    {
                        //string filterEx = JyutyuData.hb1EgCdColumn.ColumnName + "='" + row.hb1EgCd + "'";
                        //filterEx = filterEx + " AND " + JyutyuData.hb1TksKgyCdColumn.ColumnName + "='" + row.hb1TksKgyCd + "'";
                        //filterEx = filterEx + " AND " + JyutyuData.hb1TksBmnSeqNoColumn.ColumnName + "='" + row.hb1TksBmnSeqNo + "'";
                        //filterEx = filterEx + " AND " + JyutyuData.hb1TksTntSeqNoColumn.ColumnName + "='" + row.hb1TksTntSeqNo + "'";
                        //filterEx = filterEx + " AND " + JyutyuData.hb1TouFlgColumn.ColumnName + "=''";
                        //filterEx = filterEx + " AND " + JyutyuData.hb1YymmColumn.ColumnName + "='" + row.hb1Yymm + "'";
                        //filterEx = filterEx + " AND " + JyutyuData.hb1TJyutNoColumn.ColumnName + "='" + row.hb1JyutNo + "'";
                        //filterEx = filterEx + " AND " + JyutyuData.hb1TJyMeiNoColumn.ColumnName + "='" + row.hb1JyMeiNo + "'";
                        //filterEx = filterEx + " AND " + JyutyuData.hb1TUrMeiNoColumn.ColumnName + "='" + row.hb1UrMeiNo + "'";
                        //JyutyuDataRow[] childDataRows = (JyutyuDataRow[])JyutyuData.Select(filterEx);
                        //foreach (JyutyuDataRow childDataRow in childDataRows)
                        //{
                        //    if (childDataRow.jyutDelFlg == "1" || childDataRow.stpKbn == "1")
                        //    {
                        //        addRow.jyuHen = "消";
                        //    }
                        //    else if (childDataRow.seikJtai == "0" && childDataRow.seiSagSts == "0" &&
                        //             childDataRow.stpKbn == "0")
                        //    {
                        //        addRow.jyuHen = "仮";
                        //    }
                        //    else if (childDataRow.rMeiTimStmp != "")
                        //    {
                        //        addRow.jyuHen = "変";
                        //    }
                        //    else
                        //    {
                        //        addRow.jyuHen = "";
                        //    }
                        //}

                        // 統合した場合親には何も表示しない

                        addRow.jyuHen = "";
                    }
                    else
                    {
                        if (row.jyutDelFlg == "1" || row.stpKbn == "1")
                        {
                            String str = row.hb1JyutNo.Substring(5, 2);
                            bool flag = true;
                            foreach (char c in str)
                            {
                                //数字以外の文字が含まれているか調べる・
                                if (c < '0' || '9' < c)
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            //ユニチャームの場合、かつ営業画面タイプがnullの場合
                            if (row.hb1TksKgyCd.ToString() == "031054" && row.hb1EgGamenType.Trim().ToString() == "")
                            {
                                flag = false;
                            }
                            if (flag)
                            {
                                addRow.jyuHen = "消";
                            }

                            //addRow.jyuHen = "消";
                        }
                        else if (row.seikJtai == "0" && row.seiSagSts == "0" &&
                                 row.stpKbn == "0")
                        {
                            addRow.jyuHen = "仮";
                        }
                        else if (row.rMeiTimStmp != "")
                        {
                            addRow.jyuHen = "変";
                        }
                        else
                        {
                            addRow.jyuHen = "";
                        }
                    }

                    //登録 
                    addRow.toroku = "";
                    

                    //代受 
                    if (row.hb1EgCd != row.hb1AtuEgCd)
                    {
                        addRow.daiuke = "代";
                    }
                    else
                    {
                        addRow.daiuke = "";
                    }

                    //2013/03/06 jse okazaki 公文対応　Start
                    //請求 
                    if (row.seikyu != "")
                    {
                        addRow.seikyu = "済";
                    }
                    else
                    {
                        addRow.seikyu = "";
                    }
                    //2013/03/06 jse okazaki 公文対応　End

                    //売上明細No 
                    addRow.uriMeiNo = row.hb1JyutNo + "-" + row.hb1JyMeiNo + "-" + row.hb1UrMeiNo;

                    //請求年月 
                    addRow.seiYymm = row.hb1Yymm;

                    //業務区分 
                    addRow.gyomKbn = row.hb1GyomKbn;

                    //件名 
                    addRow.kenmei = row.hb1KKNameKJ;

                    if (row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.NewsPaper
                        || row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.Magazine
                        || row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.KMas
                        )
                    {
                        //媒体名 
                        addRow.baitaiNm = row.hb1Field2;

                        //期間 
                        addRow.kikan = FormatPeriodForMMDD(row.hb1Field3);
                    }
                    else if (row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.Time)
                    {
                        //媒体名 
                        addRow.baitaiNm = row.hb1Field2;

                        //期間 
                        addRow.kikan = FormatPeriodForMMDD(row.hb1Field8);
                    }
                    else if (row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.Spot)
                    {
                        //媒体名 
                        addRow.baitaiNm = row.hb1Field2;

                        //期間 
                        addRow.kikan = FormatPeriodForMMDD(row.hb1Field4);
                    }
                    else if (row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.Ooh
                       || row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.IC
                       || row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.Works
                   )
                    {
                        //媒体名 
                        addRow.baitaiNm = row.hb1Field2;

                        //期間 
                        addRow.kikan = FormatPeriodForMMDD(row.hb1Field5);
                    }
                    else if (row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.KWorks)
                    {
                        //媒体名 
                        addRow.baitaiNm = row.hb1Field3;

                        //期間 
                        addRow.kikan = FormatPeriodForMMDD(row.hb1Field4);
                    }

                    //費目名 
                    addRow.himokuNm = row.hb1HimkNmKJ;

                    //局誌CD 
                    addRow.kyokushiCd = row.hb1Field1;

                    //請求金額 
                    addRow.seiKingaku = row.hb1SeiGak;

                    //段単価 
                    addRow.danTanka = row.hb1SeiTnka;

                    //段数 
                    addRow.danSu = row.hb1Field11;

                    //取料金 
                    addRow.toriRyokin = row.hb1ToriGak;

                    //値引率 
                    addRow.nebikiRitsu = row.hb1NeviRitu;

                    //値引額 
                    addRow.nebikiGaku = row.hb1NeviGak;

                    //消費税率 
                    addRow.zeiritsu = row.hb1SzeiRitu;

                    //消費税額 
                    addRow.zeiGaku = row.hb1SzeiGak;

                    //受注請求金額 
                    addRow.goukeiKingaku = row.hb1SeiGak + row.hb1SzeiGak;

                    //変更前請求年月 
                    addRow.oldSeiYymm = row.hb1YymmOld;

                    //if (row.hb2JyutNo != "")
                    //{
                    //    //登録者 
                    //    addRow.trkTnt = row.hb1TrkTnt;
                    //    //更新者

                    //    addRow.updTnt = row.hb1UpdTnt;
                    //}
                    //else
                    //{
                    //    //登録者 
                    //    addRow.trkTnt = "";
                    //    //更新者

                    //    addRow.updTnt = "";
                    //}


                    //登録者名
                    if (!string.IsNullOrEmpty(row.hb1TrkTntNm.Trim()))
                    {
                        addRow.trkTnt = row.hb1TrkTntNm.Trim();
                    }
                    else
                    {
                        addRow.trkTnt = string.Empty;
                    }

                    //更新者名
                    if (!string.IsNullOrEmpty(row.hb1KsnTntNm.Trim()))
                    {
                        addRow.updTnt = row.hb1KsnTntNm.Trim();
                    }
                    else
                    {
                        addRow.updTnt = string.Empty;
                    }

                    //統合受注NO(親子紐づけ用項目) 
                    addRow.jyutyuNo = row.hb1JyutNo;

                    //統合受注明細NO(親子紐づけ用項目) 
                    addRow.jyMeiNo = row.hb1JyMeiNo;

                    //統合売上明細NO(親子紐づけ用項目) 
                    addRow.urMeiNo = row.hb1UrMeiNo;

                    JyutyuList.AddJyutyuListRow(addRow);
                }
                else
                {
                    //***************************************
                    //JyutyuListの編集 
                    //***************************************
                    JyutyuListChildRow addRow = JyutyuListChild.NewJyutyuListChildRow();
                    //行番号(連番) 
                    addRow.rowNo = row.rowNum;

                    if (row.jyutDelFlg == "1" || row.stpKbn == "1")
                    {
                        String str = row.hb1JyutNo.Substring(5, 2);
                        bool flag = true;
                        foreach (char c in str)
                        {
                            //数字以外の文字が含まれているか調べる・
                            if (c < '0' || '9' < c)
                            {
                                flag = false;
                                break;
                            }
                        }
                        //ユニチャームの場合、かつ営業画面タイプがnullの場合
                        if (row.hb1TksKgyCd.ToString() == "031054" && row.hb1EgGamenType.Trim().ToString() == "")
                        {
                            flag = false;
                        }
                        if (flag)
                        {
                            addRow.jyuHen = "消";
                        }
                        //addRow.jyuHen = "消";
                    }
                    else if (row.seikJtai == "0" && row.seiSagSts == "0" &&
                             row.stpKbn == "0")
                    {
                        addRow.jyuHen = "仮";
                    }
                    else if (row.rMeiTimStmp != "")
                    {
                        addRow.jyuHen = "変";
                    }
                    else
                    {
                        addRow.jyuHen = "";
                    }

                    // 暫定対応として子ビュー側は非表示とする
                    //
                    ////登録 
                    //if (row.hb2JyutNo != "")
                    //{
                    //    addRow.toroku = "済";
                    //}
                    //else
                    //{
                    //    addRow.toroku = "";
                    //}

                    //代受 
                    if (row.hb1EgCd != row.hb1AtuEgCd)
                    {
                        addRow.daiuke = "代";
                    }
                    else
                    {
                        addRow.daiuke = "";
                    }

                    //2013/03/06 jse okazaki 公文対応　Start
                    //請求 
                    if (row.seikyu != "")
                    {
                        addRow.seikyu = "済";
                    }
                    else
                    {
                        addRow.seikyu = "";
                    }
                    //2013/03/06 jse okazaki 公文対応　End

                    //売上明細No 
                    addRow.uriMeiNo = row.hb1JyutNo + "-" + row.hb1JyMeiNo + "-" + row.hb1UrMeiNo;

                    //請求年月 
                    addRow.seiYymm = row.hb1Yymm;

                    //業務区分 
                    addRow.gyomKbn = row.hb1GyomKbn;

                    //件名 
                    addRow.kenmei = row.hb1KKNameKJ;
                    if (row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.NewsPaper
                        || row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.Magazine
                        || row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.KMas
                        )
                    {
                        //媒体名 
                        addRow.baitaiNm = row.hb1Field2;

                        //期間 
                        addRow.kikan = FormatPeriodForMMDD(row.hb1Field3);
                    }
                    else if (row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.Time)
                    {
                        //媒体名 
                        addRow.baitaiNm = row.hb1Field2;

                        //期間 
                        addRow.kikan = FormatPeriodForMMDD(row.hb1Field8);
                    }
                    else if (row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.Spot)
                    {
                        //媒体名 
                        addRow.baitaiNm = row.hb1Field2;

                        //期間 
                        addRow.kikan = FormatPeriodForMMDD(row.hb1Field4);
                    }
                    else if (row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.Ooh
                       || row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.IC
                       || row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.Works
                   )
                    {
                        //媒体名 
                        addRow.baitaiNm = row.hb1Field2;

                        //期間 
                        addRow.kikan = FormatPeriodForMMDD(row.hb1Field5);
                    }
                    else if (row.hb1SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.KWorks)
                    {
                        //媒体名 
                        addRow.baitaiNm = row.hb1Field3;

                        //期間 
                        addRow.kikan = FormatPeriodForMMDD(row.hb1Field4);
                    }

                    //費目名 
                    addRow.himokuNm = row.hb1HimkNmKJ;

                    //局誌CD 
                    addRow.kyokushiCd = row.hb1Field1;

                    //請求金額 
                    addRow.seiKingaku = row.hb1SeiGak;

                    //段単価 
                    addRow.danTanka = row.hb1SeiTnka;

                    //段数 
                    addRow.danSu = row.hb1Field11;

                    //取料金 
                    addRow.toriRyokin = row.hb1ToriGak;

                    //値引率 
                    addRow.nebikiRitsu = row.hb1NeviRitu;

                    //値引額 
                    addRow.nebikiGaku = row.hb1NeviGak;

                    //消費税率 
                    addRow.zeiritsu = row.hb1SzeiRitu;

                    //消費税額 
                    addRow.zeiGaku = row.hb1SzeiGak;

                    //受注請求金額 
                    addRow.goukeiKingaku = row.hb1SeiGak + row.hb1SzeiGak;

                    //変更前請求年月 
                    addRow.oldSeiYymm = row.hb1YymmOld;


                    //統合受注NO(親子紐づけ用項目) 
                    addRow.tJyutyuNo = row.hb1TJyutNo;

                    //統合受注明細NO(親子紐づけ用項目) 
                    addRow.tJyMeiNo = row.hb1TJyMeiNo;

                    //統合売上明細NO(親子紐づけ用項目) 
                    addRow.tUrMeiNo = row.hb1TUrMeiNo;

                    // 暫定対応として子ビュー側は非表示とする
                    //
                    //if (row.hb2JyutNo != "")
                    //{
                    //    //登録者 
                    //    addRow.trkTnt = row.hb1TrkTnt;
                    //
                    //    //更新者

                    //    addRow.updTnt = row.hb1UpdTnt;
                    //}
                    //else
                    //{
                    //    //登録者 
                    //    addRow.trkTnt = "";
                    //
                    //    //更新者

                    //    addRow.updTnt = "";
                    //}

                    JyutyuListChild.AddJyutyuListChildRow(addRow);
                }


                //***************************************
                //JyutyuDetailの編集 
                //***************************************
                JyutyuDetailRow addDetailRow = JyutyuDetail.NewJyutyuDetailRow();
                //行番号(連番) 
                addDetailRow.rowNo = row.rowNum;
                if (row.hb1SeiKbn == KKHSystemConst.SeiKbn.NewsPaper)
                {
                    //新聞データ 
                    addDetailRow.Field1 = row.hb1Field1.Trim();
                    addDetailRow.Field2 = row.hb1Field2.Trim();
                    addDetailRow.Field3 = row.hb1Field3.Trim();
                    addDetailRow.Field4 = row.hb1Field4.Trim();
                    addDetailRow.Field5 = row.hb1Field6.Trim();
                    addDetailRow.Field6 = row.hb1Field8.Trim();
                    addDetailRow.Field7 = row.hb1Field10.Trim();
                    addDetailRow.Field8 = row.hb1Field11.Trim();
                    addDetailRow.Field9 = FormatPeriod(row.hb1Field12).Trim();


                }
                else if (row.hb1SeiKbn == KKHSystemConst.SeiKbn.Magazine)
                {
                    //雑誌データ 
                    addDetailRow.Field1 = row.hb1Field1.Trim();
                    addDetailRow.Field2 = row.hb1Field2.Trim();
                    addDetailRow.Field3 = row.hb1Field3.Trim();
                    addDetailRow.Field4 = row.hb1Field4.Trim();
                    addDetailRow.Field5 = row.hb1Field6.Trim();
                    addDetailRow.Field6 = row.hb1Field8.Trim();
                    addDetailRow.Field7 = row.hb1Field9.Trim();
                    addDetailRow.Field8 = FormatPeriod(row.hb1Field10).Trim();
                }
                else if (row.hb1SeiKbn == KKHSystemConst.SeiKbn.Time)
                {
                    //タイムデータ 
                    addDetailRow.Field1 = row.hb1Field1.Trim();
                    addDetailRow.Field2 = row.hb1Field2.Trim();
                    addDetailRow.Field3 = row.hb1Field3.Trim();
                    addDetailRow.Field4 = row.hb1Field4.Trim();
                    addDetailRow.Field5 = row.hb1Field5.Trim();
                    addDetailRow.Field6 = row.hb1Field6.Trim();
                    addDetailRow.Field7 = row.hb1Field7.Trim();
                    addDetailRow.Field8 = FormatPeriod(row.hb1Field8).Trim();
                }
                else if (row.hb1SeiKbn == KKHSystemConst.SeiKbn.Spot)
                {
                    //スポットデータ 
                    addDetailRow.Field1 = row.hb1Field1.Trim();
                    addDetailRow.Field2 = row.hb1Field2.Trim();
                    addDetailRow.Field3 = row.hb1Field3.Trim();
                    addDetailRow.Field4 = FormatPeriod(row.hb1Field4).Trim();
                    addDetailRow.Field5 = row.hb1Field5.Trim();
                    addDetailRow.Field6 = row.hb1Field6.Trim();
                }
                else if (row.hb1SeiKbn == KKHSystemConst.SeiKbn.Works)
                {
                    //諸作業データ 
                    addDetailRow.Field1 = row.hb1Field3.Trim();
                    addDetailRow.Field2 = row.hb1Field4.Trim();
                    addDetailRow.Field3 = FormatPeriod(row.hb1Field5).Trim();
                    addDetailRow.Field4 = row.hb1Field6.Trim();
                }
                else if (row.hb1SeiKbn == KKHSystemConst.SeiKbn.Ooh)
                {
                    //交通広告データ 
                    addDetailRow.Field1 = row.hb1Field7.Trim();
                    addDetailRow.Field2 = row.hb1Field8.Trim();
                    addDetailRow.Field3 = row.hb1Field1.Trim();
                    addDetailRow.Field4 = row.hb1Field2.Trim();
                    addDetailRow.Field5 = row.hb1Field3.Trim();
                    addDetailRow.Field6 = row.hb1Field4.Trim();
                    addDetailRow.Field7 = FormatPeriod(row.hb1Field5).Trim();
                    addDetailRow.Field8 = row.hb1Field6.Trim();
                }
                else if (row.hb1SeiKbn == KKHSystemConst.SeiKbn.KMas)
                {
                    //国際/マスデータ 
                    addDetailRow.Field1 = row.hb1Field1.Trim();
                    addDetailRow.Field2 = row.hb1Field2.Trim();
                    addDetailRow.Field3 = FormatPeriod(row.hb1Field3).Trim();
                    addDetailRow.Field4 = row.hb1Field4.Trim();
                    addDetailRow.Field5 = row.hb1Field5.Trim();
                    addDetailRow.Field6 = row.hb1Field6.Trim();
                    addDetailRow.Field7 = row.hb1Field7.Trim();
                    addDetailRow.Field8 = row.hb1Field8.Trim();
                    addDetailRow.Field9 = row.hb1Field9.Trim();
                    addDetailRow.Field10 = row.hb1Field10.Trim();
                    addDetailRow.Field11 = row.hb1Field11.Trim();
                }
                else if (row.hb1SeiKbn == KKHSystemConst.SeiKbn.KWorks)
                {
                    //国際/諸作業データ 
                    addDetailRow.Field1 = row.hb1Field1.Trim();
                    addDetailRow.Field2 = row.hb1Field2.Trim();
                    addDetailRow.Field3 = row.hb1Field3.Trim();
                    addDetailRow.Field4 = FormatPeriod(row.hb1Field4).Trim();
                    addDetailRow.Field5 = row.hb1Field5.Trim();
                    addDetailRow.Field6 = row.hb1Field6.Trim();
                    addDetailRow.Field7 = row.hb1Field7.Trim();
                    addDetailRow.Field8 = row.hb1Field8.Trim();
                    addDetailRow.Field9 = row.hb1Field9.Trim();
                    addDetailRow.Field10 = row.hb1Field10.Trim();
                    addDetailRow.Field11 = row.hb1Field11.Trim();
                    addDetailRow.Field12 = row.hb1Field12.Trim();
                }
                else if (row.hb1SeiKbn == KKHSystemConst.SeiKbn.IC)
                {
                    //IC(インタラクティブメディア) 
                    addDetailRow.Field1 = row.hb1Field1.Trim();
                    addDetailRow.Field2 = row.hb1Field2.Trim();
                    addDetailRow.Field3 = row.hb1Field3.Trim();
                    addDetailRow.Field4 = row.hb1Field4.Trim();
                    addDetailRow.Field5 = FormatPeriod(row.hb1Field5).Trim();
                    addDetailRow.Field6 = row.hb1Field6.Trim();
                }

                JyutyuDetail.AddJyutyuDetailRow(addDetailRow);


                rowNo = rowNo + 1;
            }
        }
        /// <summary>
        ///  
        /// </summary>
        /// <param name="jyutyuDataRow"></param>
        /// <param name="thb1DownRow"></param>
        public void UpdateJyutyuDataRowByTHB1DOWNRow(JyutyuDataRow jyutyuDataRow, THB1DOWNRow thb1DownRow)
        {
            jyutyuDataRow.hb1TimStmp = thb1DownRow.hb1TimStmp;
            jyutyuDataRow.hb1UpdApl = thb1DownRow.hb1UpdApl;
            jyutyuDataRow.hb1UpdTnt = thb1DownRow.hb1UpdTnt;
            jyutyuDataRow.hb1AtuEgCd = thb1DownRow.hb1AtuEgCd;
            jyutyuDataRow.hb1EgCd = thb1DownRow.hb1EgCd;
            jyutyuDataRow.hb1TksKgyCd = thb1DownRow.hb1TksKgyCd;
            jyutyuDataRow.hb1TksBmnSeqNo = thb1DownRow.hb1TksBmnSeqNo;
            jyutyuDataRow.hb1TksTntSeqNo = thb1DownRow.hb1TksTntSeqNo;
            jyutyuDataRow.hb1JyutNo = thb1DownRow.hb1JyutNo;
            jyutyuDataRow.hb1JyMeiNo = thb1DownRow.hb1JyMeiNo;
            jyutyuDataRow.hb1UrMeiNo = thb1DownRow.hb1UrMeiNo;
            jyutyuDataRow.hb1GpyNo = thb1DownRow.hb1GpyNo;
            jyutyuDataRow.hb1GpyoPag = thb1DownRow.hb1GpyoPag;
            jyutyuDataRow.hb1SeiNo = thb1DownRow.hb1SeiNo;
            jyutyuDataRow.hb1HimkCd = thb1DownRow.hb1HimkCd;
            jyutyuDataRow.hb1TouFlg = thb1DownRow.hb1TouFlg;
            jyutyuDataRow.hb1Yymm = thb1DownRow.hb1Yymm;
            jyutyuDataRow.hb1GyomKbn = thb1DownRow.hb1GyomKbn;
            jyutyuDataRow.hb1MsKbn = thb1DownRow.hb1MsKbn;
            jyutyuDataRow.hb1TmspKbn = thb1DownRow.hb1TmspKbn;
            jyutyuDataRow.hb1KokKbn = thb1DownRow.hb1KokKbn;
            jyutyuDataRow.hb1SeiKbn = thb1DownRow.hb1SeiKbn;
            jyutyuDataRow.hb1SyoNo = thb1DownRow.hb1SyoNo;
            jyutyuDataRow.hb1KKNameKJ = thb1DownRow.hb1KKNameKJ;
            jyutyuDataRow.hb1EgGamenType = thb1DownRow.hb1EgGamenType;
            jyutyuDataRow.hb1KkakShanKbn = thb1DownRow.hb1KkakShanKbn;
            jyutyuDataRow.hb1ToriGak = thb1DownRow.hb1ToriGak;
            jyutyuDataRow.hb1SeiTnka = thb1DownRow.hb1SeiTnka;
            jyutyuDataRow.hb1SeiGak = thb1DownRow.hb1SeiGak;
            jyutyuDataRow.hb1NeviRitu = thb1DownRow.hb1NeviRitu;
            jyutyuDataRow.hb1NeviGak = thb1DownRow.hb1NeviGak;
            jyutyuDataRow.hb1SzeiKbn = thb1DownRow.hb1SzeiKbn;
            jyutyuDataRow.hb1SzeiRitu = thb1DownRow.hb1SzeiRitu;
            jyutyuDataRow.hb1SzeiGak = thb1DownRow.hb1SzeiGak;
            jyutyuDataRow.hb1HimkNmKJ = thb1DownRow.hb1HimkNmKJ;
            jyutyuDataRow.hb1HimkNmKN = thb1DownRow.hb1HimkNmKN;
            jyutyuDataRow.hb1TJyutNo = thb1DownRow.hb1TJyutNo;
            jyutyuDataRow.hb1TJyMeiNo = thb1DownRow.hb1TJyMeiNo;
            jyutyuDataRow.hb1TUrMeiNo = thb1DownRow.hb1TUrMeiNo;
            jyutyuDataRow.hb1MSeiFlg = thb1DownRow.hb1MSeiFlg;
            jyutyuDataRow.hb1YymmOld = thb1DownRow.hb1YymmOld;
            jyutyuDataRow.hb1Field1 = thb1DownRow.hb1Field1;
            jyutyuDataRow.hb1Field2 = thb1DownRow.hb1Field2;
            jyutyuDataRow.hb1Field3 = thb1DownRow.hb1Field3;
            jyutyuDataRow.hb1Field4 = thb1DownRow.hb1Field4;
            jyutyuDataRow.hb1Field5 = thb1DownRow.hb1Field5;
            jyutyuDataRow.hb1Field6 = thb1DownRow.hb1Field6;
            jyutyuDataRow.hb1Field7 = thb1DownRow.hb1Field7;
            jyutyuDataRow.hb1Field8 = thb1DownRow.hb1Field8;
            jyutyuDataRow.hb1Field9 = thb1DownRow.hb1Field9;
            jyutyuDataRow.hb1Field10 = thb1DownRow.hb1Field10;
            jyutyuDataRow.hb1Field11 = thb1DownRow.hb1Field11;
            jyutyuDataRow.hb1Field12 = thb1DownRow.hb1Field12;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="jyutyuDataRow"></param>
        /// <param name="thb2KmeiRowList"></param>
        public void UpdateJyutyuDataRowByTHB2KMEIRows(JyutyuDataRow jyutyuDataRow, THB2KMEIRow[] thb2KmeiRowList)
        {
            jyutyuDataRow.hb2JyutNo = "";
            jyutyuDataRow.hb2SeiGak = 0.0M;
            jyutyuDataRow.detailCnt = 0.0M;
            foreach (THB2KMEIRow row in thb2KmeiRowList)
            {
                jyutyuDataRow.hb2JyutNo = row.hb2JyutNo;
                jyutyuDataRow.hb2SeiGak = jyutyuDataRow.hb2SeiGak + row.hb2SeiGak;
                jyutyuDataRow.detailCnt = jyutyuDataRow.detailCnt + 1;
            }
        }

        /// <summary>
        /// 「期間」を表示用のフォーマットに変換します 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string FormatPeriod(string str)
        {
            string ret = "";
            if (str.Length >= 16)
            {
                ret = str.Substring(0, 4) + "/" + str.Substring(4, 2) + "/" + str.Substring(6, 2) + " - " + str.Substring(8, 4) + "/" + str.Substring(12, 2) + "/" + str.Substring(14, 2);
            }
            else if (str.Length == 8)
            {
                ret = str.Substring(0, 4) + "/" + str.Substring(4, 2) + "/" + str.Substring(6, 2);
            }
            else
            {
                return str;
            }

            return ret;
        }

        /// <summary>
        /// 「期間」を表示用のフォーマットに変換します(年月形式) 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string FormatPeriodForMMDD(string str)
        {
            string ret = "";
            if (str.Length >= 16)
            {
                ret = str.Substring(4, 2) + "/" + str.Substring(6, 2) + " - " + str.Substring(12, 2) + "/" + str.Substring(14, 2);
            }
            else if (str.Length == 8)
            {
                ret = str.Substring(4, 2) + "/" + str.Substring(6, 2);
            }
            else
            {
                return str;
            }

            return ret;
        }

        /// <summary>
        /// THB8DOWNRに保持しているデータからJyutyuRirekiを更新します 
        /// </summary>
        public void UpdateJyutyuRirekiByDOWNR()
        {
            this.JyutyuRireki.Clear();

            foreach (THB8DOWNRRow row in this.THB8DOWNR.Rows)
            {
                JyutyuRirekiRow addRow = JyutyuRireki.NewJyutyuRirekiRow();

                //明作 
                if (row.hb8MeiTimStmp.Trim() != "")
                {
                    addRow.dtlToroku = "○";
                }
                else
                {
                    addRow.dtlToroku = "";
                }

                //ダウンロードタイミング 
                //addRow.downTiming = row.hb8FileTimStmp;
                if (row.hb8FileTimStmp.Length >= 14)
                {
                    addRow.downTiming = row.hb8FileTimStmp.Substring(0, 4) + "/" +
                    row.hb8FileTimStmp.Substring(4, 2) + "/" +
                    row.hb8FileTimStmp.Substring(6, 2) + " " +
                    row.hb8FileTimStmp.Substring(8, 2) + ":" +
                    row.hb8FileTimStmp.Substring(10, 2) + ":" +
                    row.hb8FileTimStmp.Substring(12, 2);
                }
                    else
                {
                    addRow.downTiming = row.hb8FileTimStmp;
                }
                

                //売上明細No 
                addRow.uriMeiNo = row.hb8JyutNo + "-" + row.hb8JyMeiNo + "-" + row.hb8UrMeiNo;

                //請求年月 
                addRow.seiYymm = row.hb8Yymm;

                //業務区分 
                addRow.gyomKbn = row.hb8GyomKbn;

                //件名 
                addRow.kenmei = row.hb8KKNameKJ;

                if (row.hb8SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.NewsPaper
                    || row.hb8SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.Magazine
                    || row.hb8SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.KMas
                    )
                {
                    //媒体名 
                    addRow.baitaiNm = row.hb8Field2;

                    //期間 
                    addRow.kikan = FormatPeriodForMMDD(row.hb8Field3);
                }
                else if (row.hb8SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.Time)
                {
                    //媒体名 
                    addRow.baitaiNm = row.hb8Field2;

                    //期間 
                    addRow.kikan = FormatPeriodForMMDD(row.hb8Field8);
                }
                else if (row.hb8SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.Spot)
                {
                    //媒体名 
                    addRow.baitaiNm = row.hb8Field2;

                    //期間 
                    addRow.kikan = FormatPeriodForMMDD(row.hb8Field4);
                }
                else if (row.hb8SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.Ooh
                   || row.hb8SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.IC
                   || row.hb8SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.Works
               )
                {
                    //媒体名 
                    addRow.baitaiNm = row.hb8Field2;

                    //期間 
                    addRow.kikan = FormatPeriodForMMDD(row.hb8Field5);
                }
                else if (row.hb8SeiKbn == KKHUtility.Constants.KKHSystemConst.SeiKbn.KWorks)
                {
                    //媒体名 
                    addRow.baitaiNm = row.hb8Field3;

                    //期間 
                    addRow.kikan = FormatPeriodForMMDD(row.hb8Field4);
                }

                //費目名 
                addRow.himokuNm = row.hb8HimkNmKJ;

                //局誌CD 
                addRow.kyokushiCd = row.hb8Field1;

                //請求金額 
                addRow.seiKingaku = row.hb8SeiGak;

                //段単価 
                addRow.danTanka = row.hb8SeiTnka;

                //段数 
                addRow.danSu = row.hb8Field11;

                //取料金 
                addRow.toriRyokin = row.hb8ToriGak;

                //値引率 
                addRow.nebikiRitsu = row.hb8NeviRitu;

                //値引額 
                addRow.nebikiGaku = row.hb8NeviGak;

                //消費税率 
                addRow.zeiritsu = row.hb8SzeiRitu;

                //消費税額 
                addRow.zeiGaku = row.hb8SzeiGak;

                //受注請求金額 
                addRow.goukeiKingaku = row.hb8SeiGak + row.hb8SzeiGak;

                //変更前請求年月 
                addRow.oldSeiYymm = row.hb8YymmOld;

                JyutyuRireki.AddJyutyuRirekiRow(addRow);
            }

        }

    }
}
