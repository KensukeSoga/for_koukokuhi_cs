package jp.co.isid.ham.mastermaintenance.controller;

import java.util.ArrayList;
import java.util.List;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.common.model.*;
import jp.co.isid.ham.mastermaintenance.model.FindMbj41AlertDispControlVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj05CarVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj02UserVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj12CodeVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceAlertDispControlDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceAlertDispControlDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * アラート表示制御表示情報取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/07/05 森)<BR>
 * </P>
 * @author 森
 */
public class FindMasterMaintenanceAlertDispControlCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindMasterMaintenanceAlertDispControlDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceAlertDispControlDispResult result = new FindMasterMaintenanceAlertDispControlDispResult();

        FindMbj05CarVO carVO = manager.getMasterMaintenanceCar(_condition.getConditionCar());

        FindMbj02UserVO userVO = manager.getMasterMaintenanceUser(_condition.getConditionUser());

        FindMbj41AlertDispControlVO alartDispControlVO = manager.getMasterMaintenanceAlertDispControl(_condition.getConditionAlertDispControl());

        FindMbj12CodeVO codeVO = new FindMbj12CodeVO();
        List<Mbj12CodeVO> workList = new ArrayList<Mbj12CodeVO>();
        for (int i = 0 ; (_condition.getConditionListCode() != null) && (i < _condition.getConditionListCode().size()) ; i++)
        {
            FindMbj12CodeVO workCodeVO = manager.getMasterMaintenanceCode(_condition.getConditionListCode().get(i));

            workList.addAll(workCodeVO.getFindList());
        }
        codeVO.setFindList(workList);

        result.setAlertDispControlVO(alartDispControlVO);

        result.setCarVO(carVO);

        result.setUserVO(userVO);

        result.setCodeVO(codeVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setFindCondition(FindMasterMaintenanceAlertDispControlDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return 結果
     */
    public FindMasterMaintenanceAlertDispControlDispResult getFindResult()
    {
        return (FindMasterMaintenanceAlertDispControlDispResult) super.getResult().get(RESULT_KEY);
    }

}
