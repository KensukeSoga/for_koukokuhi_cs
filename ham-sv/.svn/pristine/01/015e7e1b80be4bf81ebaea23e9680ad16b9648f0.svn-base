package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMbj27MediaProductVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj05CarVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj03MediaVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj06HcBumonVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj08HcProductVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceMediaProductDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceMediaProductDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 媒体・商品紐付表示情報取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
public class FindMasterMaintenanceMediaProductCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindMasterMaintenanceMediaProductDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceMediaProductDispResult result = new FindMasterMaintenanceMediaProductDispResult();

        FindMbj27MediaProductVO mediaProductVO = manager.getMasterMaintenanceMediaProduct(_condition.getConditionMediaProduct());

        FindMbj05CarVO carVO = manager.getMasterMaintenanceCar(_condition.getConditionCar());

        FindMbj03MediaVO mediaVO = manager.getMasterMaintenanceMedia(_condition.getConditionMedia());

        FindMbj06HcBumonVO hCSectionVO = manager.getMasterMaintenanceHCSection(_condition.getConditionHCSection());

        FindMbj08HcProductVO hCProductVO = manager.getMasterMaintenanceHCProduct(_condition.getConditionHCProduct());

        result.setMediaProductVO(mediaProductVO);

        result.setCarVO(carVO);

        result.setMediaVO(mediaVO);

        result.setHCSectionVO(hCSectionVO);

        result.setHCProductVO(hCProductVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setFindCondition(FindMasterMaintenanceMediaProductDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return 結果
     */
    public FindMasterMaintenanceMediaProductDispResult getFindResult()
    {
        return (FindMasterMaintenanceMediaProductDispResult) super.getResult().get(RESULT_KEY);
    }

}
