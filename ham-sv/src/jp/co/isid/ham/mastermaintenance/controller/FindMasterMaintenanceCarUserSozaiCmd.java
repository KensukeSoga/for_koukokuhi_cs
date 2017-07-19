package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceCarUserSozaiDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceCarUserSozaiDispResult;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceCarUserSozaiSpreadVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceHCHMSecGrpUserSpreadVO;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 車種担当(素材)表示情報取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/02/17 HLC K.Oki)<BR>
 * </P>
 * @author K.Oki
 */
public class FindMasterMaintenanceCarUserSozaiCmd extends Command{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindMasterMaintenanceCarUserSozaiDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();
        FindMasterMaintenanceCarUserSozaiDispResult result = new FindMasterMaintenanceCarUserSozaiDispResult();

        //車種担当(素材)マスタ
        FindMasterMaintenanceCarUserSozaiSpreadVO carUserSozaiSpreadVO = manager.getCarUserSozaiSpread(_condition.getConditionCarUserSozaiSpread());
        result.setCarUserSozaiSpreadVO(carUserSozaiSpreadVO);

       //車種マスタ
        result.setCarVO(manager.getMasterMaintenanceCar(_condition.getConditionCar()));

        //セキュリティグループユーザー(HC/HM)
        FindMasterMaintenanceHCHMSecGrpUserSpreadVO HCHMSecGrpUserSpreadVO = manager.getHCHMSecGrpUserSpread(_condition.getConditionHCHMSecGrpUserSpread());
        result.setHCHMSecGrpUserSpreadVO(HCHMSecGrpUserSpreadVO);

        getResult().set(RESULT_KEY, result);
    }


    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setFindCondition(FindMasterMaintenanceCarUserSozaiDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return 結果
     */
    public FindMasterMaintenanceCarUserSozaiDispResult getFindResult()
    {
        return (FindMasterMaintenanceCarUserSozaiDispResult) super.getResult().get(RESULT_KEY);
    }

}
