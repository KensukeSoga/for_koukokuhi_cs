package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMbj32DepartmentVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj12CodeVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceDepartmentDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceDepartmentDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 部署表示情報取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/04 森)<BR>
 * </P>
 * @author 森
 */
public class FindMasterMaintenanceDepartmentCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindMasterMaintenanceDepartmentDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceDepartmentDispResult result = new FindMasterMaintenanceDepartmentDispResult();

        FindMbj32DepartmentVO departmentVO = manager.getMasterMaintenanceDepartment(_condition.getConditionDepartment());

        FindMbj12CodeVO codeVO = manager.getMasterMaintenanceCode(_condition.getConditionCode());

        result.setDepartmentVO(departmentVO);

        result.setCodeVO(codeVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setFindCondition(FindMasterMaintenanceDepartmentDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return 結果
     */
    public FindMasterMaintenanceDepartmentDispResult getFindResult()
    {
        return (FindMasterMaintenanceDepartmentDispResult) super.getResult().get(RESULT_KEY);
    }

}
