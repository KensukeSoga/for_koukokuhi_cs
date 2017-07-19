package jp.co.isid.ham.billing.model;

import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj12CodeDAO;
import jp.co.isid.ham.common.model.Mbj12CodeDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * JASRAC請求明細書(ラジオタイム)検索Manager
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/11/19 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindJasracRadioTimeBillManager {

    /** シングルトンインスタンス */
    private static FindJasracRadioTimeBillManager _manager = new FindJasracRadioTimeBillManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindJasracRadioTimeBillManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindJasracRadioTimeBillManager getInstance() {
        return _manager;
    }

    /**
     * JASRAC請求明細書(ラジオタイム)出力情報を検索する
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    public FindJasracRadioTimeBillResult findJasracRadioTimeBillInfo(FindJasracRadioTimeCondition cond) throws HAMException {

        //検索結果
        FindJasracRadioTimeBillResult result = new FindJasracRadioTimeBillResult();

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
        FindJasracRadioTimeDAO dao = FindJasracRadioTimeDAOFactory.createFindJasracRadioTimeDao();
        result.setJasracInfo(dao.selectVO(cond));

        return result;
    }

}
