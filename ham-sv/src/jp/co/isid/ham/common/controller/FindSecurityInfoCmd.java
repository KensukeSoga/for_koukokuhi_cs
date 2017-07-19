package jp.co.isid.ham.common.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.common.model.SecurityInfoCondition;
import jp.co.isid.ham.common.model.SecurityInfoResult;
import jp.co.isid.ham.common.model.SecurityInfoManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * セキュリティ情報取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/06/11 森)<BR>
 * </P>
 * @author 森
 */
public class FindSecurityInfoCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private SecurityInfoCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        SecurityInfoManager manager = SecurityInfoManager.getInstance();

        SecurityInfoResult result = manager.getSecurityInfo(_condition);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setFindCondition(SecurityInfoCondition condition)
    {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return 結果
     */
    public SecurityInfoResult getFindResult()
    {
        return (SecurityInfoResult) super.getResult().get(RESULT_KEY);
    }

}
