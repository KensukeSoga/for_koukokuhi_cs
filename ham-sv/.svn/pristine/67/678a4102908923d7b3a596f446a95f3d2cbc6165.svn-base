package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.media.model.FindBillStatementDataCondition;
import jp.co.isid.ham.media.model.FindBillStatementDataResult;
import jp.co.isid.ham.media.model.FindBillStatementManager;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 請求明細書出力データ検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/3/25 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindBillStatementDataCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

   /** 検索結果キー */
   private static final String RESULT_KEY = "RESULT_KEY";

   /** 検索条件 */
   private FindBillStatementDataCondition _condition;


   /**
    * 検索条件を使用し、 請求名差諸出力データ検索処理を実行します
    * @throws HAMException
    *             検索に失敗した場合
    */
   @Override
    public void execute() throws UserException {
        FindBillStatementManager manager = FindBillStatementManager.getInstance();
        FindBillStatementDataResult result = manager.findBillStatementOutData(_condition);
        getResult().set(RESULT_KEY, result);
    }

   /**
    * 検索条件を設定します
    * @param condition 検索条件
    */
   public void setBillStatementDataCondition(FindBillStatementDataCondition condition) {
       _condition = condition;
   }

   /**
    * 検索結果を返します
    * @return FindAuthorityAccountBookResult 条件検索結果
    */
   public FindBillStatementDataResult getBillStatementDataResult() {
       return (FindBillStatementDataResult) super.getResult().get(RESULT_KEY);
   }
}
