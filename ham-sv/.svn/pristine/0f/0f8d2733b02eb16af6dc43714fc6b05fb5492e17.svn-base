package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.media.model.FindAccountBookOutPutDataCondition;
import jp.co.isid.ham.media.model.FindAccountBookOutPutDataResult;
import jp.co.isid.ham.media.model.FindAccountBookOutputManager;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 営業作業台帳帳票出力データ検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/3/26 HLC M.Tsuchiya)<BR>
 * </P>
 * @author HLC M.Tsuchiya
 */
public class FindAccountBookOutPutDataCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

   /** 検索結果キー */
   private static final String RESULT_KEY = "RESULT_KEY";

   /** 検索条件 */
   private FindAccountBookOutPutDataCondition _condition;


   /**
    * 検索条件を使用し、 営業作業台帳帳票出力データ検索処理を実行します
    * @throws HAMException
    *             検索に失敗した場合
    */
   @Override
    public void execute() throws UserException {
       FindAccountBookOutputManager manager = FindAccountBookOutputManager.getInstance();
        FindAccountBookOutPutDataResult result = manager.findAuthorityAccountBookReport(_condition);
        getResult().set(RESULT_KEY, result);
    }

   /**
    * 検索条件を設定します
    * @param condition 検索条件
    */
   public void setAccountBookOutPutDataCondition(FindAccountBookOutPutDataCondition condition) {
       _condition = condition;
   }

   /**
    * 検索結果を返します
    * @return FindAuthorityAccountBookResult 条件検索結果
    */
   public FindAccountBookOutPutDataResult getFindAccountBookOutPutDataResult() {
       return (FindAccountBookOutPutDataResult) super.getResult().get(RESULT_KEY);
   }
}
