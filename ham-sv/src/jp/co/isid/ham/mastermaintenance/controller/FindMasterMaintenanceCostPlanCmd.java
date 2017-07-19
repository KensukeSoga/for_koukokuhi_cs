package jp.co.isid.ham.mastermaintenance.controller;

import java.util.ArrayList;
import java.util.List;

import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceCostPlanDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceCostPlanDispResult;
import jp.co.isid.ham.mastermaintenance.model.FindMbj12CodeVO;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 費用企画No表示情報取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * ・請求業務変更対応(2015/08/31 HLC S,Fujimoto)<BR>
 * </P>
 * @author 森
 */
public class FindMasterMaintenanceCostPlanCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindMasterMaintenanceCostPlanDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();
        FindMasterMaintenanceCostPlanDispResult result = new FindMasterMaintenanceCostPlanDispResult();

        //費用企画Noマスタ
        result.setCostPlanVO(manager.getMasterMaintenanceCostPlan(_condition.getConditionCostPlan()));
        //車種マスタ
        result.setCarVO(manager.getMasterMaintenanceCar(_condition.getConditionCar()));
        //媒体マスタ
        result.setMediaVO(manager.getMasterMaintenanceMedia(_condition.getConditionMedia()));

        /* 2015/08/31 請求業務変更対応 HLC S.Fujimoto ADD Start */
        //媒体マスタ(制作)
        result.setMediaProduction(manager.getMasterMaintenanceMediaProduction(_condition.getConditionMediaProduction()));
        //HM担当者マスタ
        result.setHmUserVO(manager.getMasterMaintenanceHMUser(_condition.getConditionHmUser()));
        /* 2015/08/31 請求業務変更対応 HLC S.Fujimoto ADD End */

        //コードマスタ
        FindMbj12CodeVO codeVo = new FindMbj12CodeVO();
        List<Mbj12CodeVO> workList = new ArrayList<Mbj12CodeVO>();
        for (int i = 0 ; (_condition.getConditionListCode() != null) && (i < _condition.getConditionListCode().size()) ; i++)
        {
            FindMbj12CodeVO workCodeVO = manager.getMasterMaintenanceCode(_condition.getConditionListCode().get(i));

            workList.addAll(workCodeVO.getFindList());
        }
        codeVo.setFindList(workList);
        result.setCodeVO(codeVo);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setFindCondition(FindMasterMaintenanceCostPlanDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return 結果
     */
    public FindMasterMaintenanceCostPlanDispResult getFindResult()
    {
        return (FindMasterMaintenanceCostPlanDispResult) super.getResult().get(RESULT_KEY);
    }
}
