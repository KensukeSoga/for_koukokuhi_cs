package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.RegistMbj30InputTntVO;
import jp.co.isid.ham.mastermaintenance.model.CheckRegistMasterMaintenanceResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 入力担当チェックコマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
public class CheckRegistMasterMaintenanceInputUserCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** チェックデータ */
    private RegistMbj30InputTntVO _vo;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();
        CheckRegistMasterMaintenanceResult result = new CheckRegistMasterMaintenanceResult();
        manager.checkRegistMasterMaintenanceInputUser(_vo);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * チェックデータを設定します
     *
     * @param vo チェックデータ
     */
    public void setCheckRegistVO(RegistMbj30InputTntVO vo) {
        _vo = vo;
    }

    /**
     * 結果を返します
     *
     * @return 結果
     */
    public CheckRegistMasterMaintenanceResult getCheckRegistResult() {
        return (CheckRegistMasterMaintenanceResult) super.getResult().get(RESULT_KEY);
    }

}
