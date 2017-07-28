namespace Isid.KKH.Epson.Schema {


    partial class SeikyuDsEpson
    {
        partial class SeikyuListDataTable
        {
        }
    
        partial class THB14SKDOWNDataTable
        {
        }

        /// <summary>
        /// THB14SKDOWNに保持しているデータからSeikyuListを更新します 
        /// </summary>
        public void UpdateSpdDataBySeikyuData()
        {
            this.SeikyuList.Clear();
            //this.JyutyuDetail.Clear();

            int rowNo = 1;
            foreach (THB14SKDOWNRow row in THB14SKDOWN.Rows)
            {
                //***************************************
                //SeikyuListの編集 
                //***************************************
                SeikyuListRow addRow = SeikyuList.NewSeikyuListRow();
                
                ////行番号(連番) 
                //addRow.rowNo = row.rowNum;

                //反映
                if (row.hb14KKHMeiTimStmp != "")
                {
                    addRow.hannei = "済";
                }
                else
                {
                    addRow.hannei = "";
                }

                //請求書番号
                if (row.hb14SeiNo.Length == 12)
                {
                    addRow.seikyuNo = row.hb14SeiNo.Substring(0, 8) + "-" + row.hb14SeiNo.Substring(8, 4);
                }
                else
                {
                    addRow.seikyuNo = row.hb14SeiNo;
                }

                //請求書明細番号
                addRow.seikyuMeiNo = row.hb14SeiMeiNo;

                //売上明細No
                addRow.uriMeiNo = row.hb14JyutNo + "-" + row.hb14JyMeiNo + "-" + row.hb14UrMeiNo;
                
                //件名
                addRow.kenmei = row.hb14KouNameUp + row.hb14KouNameDown;

                //金額合計（税込み）
                addRow.seiKingakuGk = row.hb14SeigakGk;

                //税額合計
                addRow.zeiGakuGk = row.hb14SzeigakGk;

                //税抜き金額合計
                addRow.zeiNKingakuGk = row.hb14TorigakGk - row.hb14NebigakGk;

                //金額（税込み）
                addRow.seiKingaku = row.hb14TorigakEn - row.hb14NebigakEn + row.hb14SzeiGakEn;

                //税額
                addRow.zeiGaku = row.hb14SzeiGakEn;

                //税抜き金額
                addRow.zeiNKingaku = row.hb14TorigakEn - row.hb14NebigakEn;

                //計上日
                if (row.hb14SeiHakDate.Length == 8)
                {
                    addRow.keiYymm = row.hb14SeiHakDate.Substring(0, 4) + "/" + row.hb14SeiHakDate.Substring(4, 2) + "/" + row.hb14SeiHakDate.Substring(6, 2);
                }
                else
                {
                    addRow.keiYymm = row.hb14SeiHakDate;
                }

                //請求ステータス
                addRow.seiStatus = row.hb14SeiStatus;

                SeikyuList.AddSeikyuListRow(addRow);

                rowNo = rowNo + 1;
            }
        }
    }
}
            