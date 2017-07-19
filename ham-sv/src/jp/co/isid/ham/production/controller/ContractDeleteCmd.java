package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.production.model.ContractDeleteCondition;
import jp.co.isid.ham.production.model.ContractDeleteResult;
import jp.co.isid.ham.production.model.ContractRegisterManager;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 契約情報登録画面起動時データ取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/14 JSE A.Naito)<BR>
 * </P>
 * @author
 */
public class ContractDeleteCmd extends Command {

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private ContractDeleteCondition _condition;

    /**
    *
    */
   private static final long serialVersionUID = 1L;

   /**
    * 検索条件を使用し、検索処理を実行します
    * @throws HAMException 検索に失敗した場合
    */
   public void execute() throws UserException {
       ContractDeleteResult result = new ContractDeleteResult();
       ContractRegisterManager manager = ContractRegisterManager.getInstance();
       result = manager.countByCondition(_condition);
       getResult().set(RESULT_KEY, result);
   }

   /**
    * 検索条件を設定します
    *
    * @param condition CommonCodeMasterSearchCondition 検索条件
    */
   public void setContractDeleteCondition(ContractDeleteCondition condition) {
       _condition = condition;
   }

   /**
    * 条件検索結果を返します
    *
    * @return ContractRegisterResult 条件検索結果
    */
   public ContractDeleteResult getContractDeleteResult() {
       return (ContractDeleteResult) super.getResult().get(RESULT_KEY);
   }
}
