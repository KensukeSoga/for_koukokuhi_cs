package jp.co.isid.ham.production.model;

import java.util.List;

import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * タレント・ナレーター・楽曲契約表検索(帳票用)検索Manager
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/03/26 T.Hadate)<BR>
 * </P>
 *
 * @author Takahiro Hadate
 */
public class Contract4ReportManager {

    /** シングルトンインスタンス */
    private static Contract4ReportManager _manager = new Contract4ReportManager();

    /**
     * コンストラクタ
     */
    private Contract4ReportManager() {
        //何もしない
    }

    /**
     * インスタンスを取得する.
     *
     * @return インスタンス
     */
    public static Contract4ReportManager getInstance() {
        return _manager;
    }

    /**
     * 帳票出力するデータを検索する.
     *
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    public Contract4ReportResult findReport(Contract4ReportCondition cond) throws HAMException {
        //検索結果
        Contract4ReportResult result = new Contract4ReportResult();

        Contract4ReportDao dao = Contract4ReportDaoFactory.createContract4ReportDao();
        List<Contract4ReportVO> list = dao.findReport(cond);
        result.setContract4ReportVOList(list);

        return result;
    }
}
