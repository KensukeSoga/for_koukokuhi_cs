package jp.co.isid.ham.billing.model;

import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj12CodeDAO;
import jp.co.isid.ham.common.model.Mbj12CodeDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * JASRAC申請書(ラジオタイム)検索Manager
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/11/17 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindJasracRadioTimeManager {

    /** シングルトンインスタンス */
    private static FindJasracRadioTimeManager _manager = new FindJasracRadioTimeManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindJasracRadioTimeManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindJasracRadioTimeManager getInstance() {
        return _manager;
    }

    /**
     * JASRAC申請書(ラジオタイム)出力情報を検索する
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    public FindJasracRadioTimeResult findJasracRadioTimeOutputInfo(FindJasracRadioTimeCondition cond) throws HAMException {

        //検索結果
        FindJasracRadioTimeResult result = new FindJasracRadioTimeResult();

        //コードマスタ
        StringBuilder codeType = new StringBuilder();
        for (int i = 0; i < cond.getCodeList().size(); i++) {
            codeType.append("'" + cond.getCodeList().get(i) + "',");
        }

        Mbj12CodeDAO mbj12Dao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition mbj12Cond = new Mbj12CodeCondition();
        mbj12Cond.setCodetype(codeType.toString().substring(0, codeType.toString().length() - 1));
        result.setCode(mbj12Dao.FindManyCd(mbj12Cond));

        //JASRAC申請書(ラジオタイム)出力情報
        FindJasracRadioTimeDAO jasracRTdao = FindJasracRadioTimeDAOFactory.createFindJasracRadioTimeDao();
        result.setJasracInfo(jasracRTdao.selectVO(cond));

        return result;
    }

}
