package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.media.model.FindBillStatementCondition;
import jp.co.isid.ham.media.model.FindBillStatementManager;
import jp.co.isid.ham.media.model.FindBillStatementResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
/**
 * <P>
 * 請求明細書画面表示データ検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/03 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindBillStatementCmd extends Command{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

   /** 検索結果キー */
   private static final String RESULT_KEY = "RESULT_KEY";

   /** 検索条件 */
   private FindBillStatementCondition _condition;

   /**
    * 検索条件を使用し、 営業作業台帳データ検索処理を実行します
    *
    * @throws HAMException
    *             検索に失敗した場合
    */
   @Override
   public void execute() throws HAMException {
       FindBillStatementManager manager = FindBillStatementManager.getInstance();
       FindBillStatementResult result = manager.findBillStatement(_condition);
       getResult().set(RESULT_KEY, result);
   }

   /**
    * 検索条件を設定します
    *
    * @param condition
    *            AccountBook 検索条件
    */
   public void setBillStatementCondition(FindBillStatementCondition condition) {
       _condition = condition;
   }

   /**
    * 営業作業台帳検索結果を返します
    *
    * @return FindAuthorityAccountBookResult 条件検索結果
    */
   public FindBillStatementResult getBillStatementResult() {
       return (FindBillStatementResult) super.getResult().get(RESULT_KEY);
   }
}
