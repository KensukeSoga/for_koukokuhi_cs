package jp.co.isid.ham.login.controller;

import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.login.model.MprKengenCheckCondition;
import jp.co.isid.ham.login.model.MprKengenCheckManager;
import jp.co.isid.ham.login.model.MprKengenCheckResult;
import jp.co.isid.ham.util.StringUtil;
import jp.co.isid.nj.controller.command.Command;

/**
 * <P>
 * 業務会計セキュリティロール取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/05/17 JSE K.Tamura)<BR>
 * </P>
 *
 * @author JSE K.Tamura
 */
public class MprKengenCheckCmd extends Command {

    private static final long serialVersionUID = -8766965615145025400L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private MprKengenCheckCondition _condition;

    /**
     * 検索条件を使用し、検索処理を実行します
     *
     * @throws HAMException 検索に失敗した場合
     */
    public void execute() throws HAMException {

        // 入力チェック
        checkInput();

        // 業務会計セキュリティロール（相対権限）取得
        MprKengenCheckManager manager = MprKengenCheckManager.getInstance();
        //String relativeAuthority = manager.getMprKengenCheck(_condition);
        MprKengenCheckResult result = manager.execute(_condition);

        // 返却値設定
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setMprKengenCheckCondition(MprKengenCheckCondition condition) {
        _condition = condition;
    }

    /**
     * 検索結果を返します
     *
     * @return 検索結果
     */
    public MprKengenCheckResult getMprKengenCheckResult() {
        return (MprKengenCheckResult) super.getResult().get(RESULT_KEY);
    }

    /**
     * パラメータ入力チェック
     *
     * @throws HAMException パラメータ指定エラーの場合
     */
    private void checkInput() throws HAMException {

        if (StringUtil.isBlank(_condition.getAplId())) {
            throw new HAMException("パラメータ指定エラー", "BJ-E0002");
        }
        if (StringUtil.isBlank(_condition.getEsqId())) {
            throw new HAMException("パラメータ指定エラー", "BJ-E0002");
        }
        if (StringUtil.isBlank(_condition.getPassword())) {
            throw new HAMException("パラメータ指定エラー", "BJ-E0002");
        }
        if (_condition.getSecurityInfo() == null) {
            throw new HAMException("パラメータ指定エラー", "BJ-E0002");
        }
    }

}
