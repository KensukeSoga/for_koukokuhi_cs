package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.media.model.*;

/**
 * <P>
 * 媒体状況管理データ検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/01/18 HLC M.Tsuchiya)<BR>
 * </P>
 * @author HLC M.Tsuchiya
 */

public class FindMediaPlanCmd extends Command {

    /**
    *
    */
   private static final long serialVersionUID = 1L;

   /** 検索結果キー */
   private static final String RESULT_KEY = "RESULT_KEY";

   /** 検索条件 */
   private FindMediaPlanCondition _condition;

   /**
    * 検索条件を使用し、 媒体状況管理データ検索処理を実行します
    *
    * @throws HAMException
    *             検索に失敗した場合
    */
   public void execute() throws HAMException {
       FindMediaPlanManager manager = FindMediaPlanManager.getInstance();
       FindMediaPlanResult result = manager.findMediaPlan(_condition);
       getResult().set(RESULT_KEY, result);
   }

   /**
    * 検索条件を設定します
    *
    * @param condition
    *            AccountBook 検索条件
    */
   public void setFindMediaPlanCondition(FindMediaPlanCondition condition) {
       _condition = condition;
   }

   /**
    * 媒体状況管理検索結果を返します
    *
    * @return FindMediaPlanResult 条件検索結果
    */
   public FindMediaPlanResult getMediaPlanResult() {
       return (FindMediaPlanResult) super.getResult().get(RESULT_KEY);
   }

}
