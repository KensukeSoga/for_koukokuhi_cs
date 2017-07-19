package jp.co.isid.ham.login.controller;

import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.login.model.AccountSecurityRoleCondition;
import jp.co.isid.ham.login.model.MprKengenCheckManager;
import jp.co.isid.ham.login.model.AccountSecurityRoleResult;
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
public class AccountSecurityRoleGetCmd extends Command {

    private static final long serialVersionUID = -8766965615145025400L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private AccountSecurityRoleCondition _condition;

    /**
     * 検索条件を使用し、検索処理を実行します
     *
     * @throws HAMException 検索に失敗した場合
     */
    public void execute() throws HAMException {

        // 入力チェック
        checkInput();

//        // 管理者ユーザー情報権限のチェック
//        Mhf31TntVO kanriUserInfo = getKanriUserInfo();
//
//        if (kanriUserInfo != null) {
//            getResult().set(RESULT_KEY, setResult(null, true, kanriUserInfo));
//            return;
//        }

        // 業務会計セキュリティロール（相対権限）取得
        MprKengenCheckManager manager = MprKengenCheckManager.getInstance();
        //String relativeAuthority = manager.getAccountSecurityRole(_condition);
        String relativeAuthority = manager.getAccountSecurityRole(_condition);

//      // データがない場合
//      if (StringUtil.trim(relativeAuthority).isEmpty()) {
//		throw new HAMException("業務会計セキュリティロール取得エラー", "HB-W0107");//TODO エラーコード
//		}

        // 返却値設定
        //getResult().set(RESULT_KEY, setResult(relativeAuthority, false, kanriUserInfo));
        getResult().set(RESULT_KEY, setResult(relativeAuthority, false));
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setAccountSecurityRoleCondition(AccountSecurityRoleCondition condition) {
        _condition = condition;
    }

    /**
     * 検索結果を返します
     *
     * @return 検索結果
     */
    public AccountSecurityRoleResult getAccountSecurityRoleResult() {
        return (AccountSecurityRoleResult) super.getResult().get(RESULT_KEY);
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

//    /**
//     * 管理者ユーザー情報の取得
//     *
//     * @return 管理者ユーザー情報
//     * @throws HAMException 処理中にエラーが発生した場合
//     */
//    private Mhf31TntVO getKanriUserInfo() throws HAMException {
//        // ESQIDの設定
//        _condition.setEsqId(_condition.getEsqId());
//
//        AccountSecurityRoleManager manager = AccountSecurityRoleManager.getInstance();
//        Mhf31TntVO kanriUserInfo = manager.findKanriUserInfo(_condition);
//        return kanriUserInfo;
//    }

//    /**
//     * 返却値設定
//     *
//     * @param relativeAuthority 相対権限
//     * @param notSecurityRoleFlag セキュリティロール取得対象外フラグ
//     * @param kanriUserKengen 管理者ユーザー情報権限
//     * @return 業務会計セキュリティロール取得結果
//     */
//    private AccountSecurityRoleResult setResult(String relativeAuthority, boolean notSecurityRoleFlag, Mhf31TntVO kanriUserInfo) {
//
//        AccountSecurityRoleResult result = new AccountSecurityRoleResult();
//        result.setRelativeAuthority(relativeAuthority);
//        result.setNotSecurityRoleFlag(notSecurityRoleFlag);
//        result.setKanriUserInfo(kanriUserInfo);
//        return result;
//    }
    /**
     * 返却値設定
     *
     * @param relativeAuthority 相対権限
     * @param notSecurityRoleFlag セキュリティロール取得対象外フラグ
     * @return 業務会計セキュリティロール取得結果
     */
    private AccountSecurityRoleResult setResult(String relativeAuthority, boolean notSecurityRoleFlag) {

        AccountSecurityRoleResult result = new AccountSecurityRoleResult();
        result.setRelativeAuthority(relativeAuthority);
        result.setNotSecurityRoleFlag(notSecurityRoleFlag);
        return result;
    }

}
