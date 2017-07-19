package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMbj47NewspaperVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceMEU20MSMZBTVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceFindContactRequestVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceNewspaperDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceNewspaperDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 新聞マスタ表示情報取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/09/17 森)<BR>
 * </P>
 * @author 森
 */
public class FindMasterMaintenanceNewspaperCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindMasterMaintenanceNewspaperDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceNewspaperDispResult result = new FindMasterMaintenanceNewspaperDispResult();

        FindMbj47NewspaperVO newspaperVO = manager.getMasterMaintenanceNewspaper(_condition.getConditionNewspaper());

        FindMasterMaintenanceMEU20MSMZBTVO mEU20MSMZBTVO = manager.getMEU20MSMZBT(_condition.getConditionMEU20MSMZBT());

        FindMasterMaintenanceFindContactRequestVO findContactRequestVO = manager.getMasterMaintenanceFindContactRequest(_condition.getConditionFindContactRequest());

        result.setNewspaperVO(newspaperVO);

        result.setMEU20MSMZBTVO(mEU20MSMZBTVO);

        result.setFindContactRequestVO(findContactRequestVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setFindCondition(FindMasterMaintenanceNewspaperDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return 結果
     */
    public FindMasterMaintenanceNewspaperDispResult getFindResult()
    {
        return (FindMasterMaintenanceNewspaperDispResult) super.getResult().get(RESULT_KEY);
    }

}
