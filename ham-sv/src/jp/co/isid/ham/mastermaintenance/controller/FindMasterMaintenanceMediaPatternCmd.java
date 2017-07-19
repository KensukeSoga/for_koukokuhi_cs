package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMbj35MediaPatternVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj36MediaPatternItemVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceMEU20MSMZBTVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceMediaPatternDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceMediaPatternDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 媒体パターン表示情報取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
public class FindMasterMaintenanceMediaPatternCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindMasterMaintenanceMediaPatternDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceMediaPatternDispResult result = new FindMasterMaintenanceMediaPatternDispResult();

        FindMbj35MediaPatternVO mediaPatternVO = manager.getMasterMaintenanceMediaPattern(_condition.getConditionMediaPattern());

        FindMbj36MediaPatternItemVO mediaPatternItemVO = manager.getMasterMaintenanceMediaPatternItem(_condition.getConditionMediaPatternItem());

        FindMasterMaintenanceMEU20MSMZBTVO mEU20MSMZBTVO = manager.getMEU20MSMZBT(_condition.getConditionMEU20MSMZBT());

        result.setMediaPatternVO(mediaPatternVO);

        result.setMediaPatternItemVO(mediaPatternItemVO);

        result.setMEU20MSMZBTVO(mEU20MSMZBTVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setFindCondition(FindMasterMaintenanceMediaPatternDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return 結果
     */
    public FindMasterMaintenanceMediaPatternDispResult getFindResult()
    {
        return (FindMasterMaintenanceMediaPatternDispResult) super.getResult().get(RESULT_KEY);
    }

}
