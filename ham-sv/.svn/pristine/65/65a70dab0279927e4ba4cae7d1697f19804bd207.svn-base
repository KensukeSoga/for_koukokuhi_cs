package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.RegistMbj26BillGroupVO;
import jp.co.isid.ham.mastermaintenance.model.CheckRegistMasterMaintenanceResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 請求先グループチェックコマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * </P>
 * @author 森
 */
public class CheckRegistMasterMaintenanceDemandGroupCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** チェックデータ */
    private RegistMbj26BillGroupVO _vo;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();
        CheckRegistMasterMaintenanceResult result = new CheckRegistMasterMaintenanceResult();
        manager.checkRegistMasterMaintenanceDemandGroup(_vo);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * チェックデータを設定します
     *
     * @param vo チェックデータ
     */
    public void setCheckRegistVO(RegistMbj26BillGroupVO vo) {
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
