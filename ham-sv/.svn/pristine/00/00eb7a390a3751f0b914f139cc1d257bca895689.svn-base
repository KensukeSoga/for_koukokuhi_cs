package jp.co.isid.ham.media.model;

import java.util.ArrayList;
import java.util.List;

import jp.co.isid.ham.common.model.FunctionControlInfoCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoManager;
import jp.co.isid.ham.common.model.Mbj32DepartmentCondition;
import jp.co.isid.ham.common.model.Mbj32DepartmentDAO;
import jp.co.isid.ham.common.model.Mbj32DepartmentDAOFactory;
import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.common.model.Mbj47NewspaperCondition;
import jp.co.isid.ham.common.model.Mbj47NewspaperDAO;
import jp.co.isid.ham.common.model.Mbj47NewspaperDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

public class DocumentTransmissionManager {

    /** シングルトンインスタンス */
    private static DocumentTransmissionManager _manager = new DocumentTransmissionManager();

    /***
     * シングルトンの為、インスタンス化を禁止します
     */
    private DocumentTransmissionManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static DocumentTransmissionManager getInstance() {
        return _manager;
    }

    /**
     * 画面表示データを取得する
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    public FindDocumentTransmissionResult findDocumentTransmission(FindDocumentTransmissionCondition cond) throws HAMException {

        FindDocumentTransmissionResult result = new FindDocumentTransmissionResult();

        // 送稿表の画面表示データを取得
        FindDocumentTransmissionDAO fdtDao = FindDocumentTransmissionDAOFactory.createFindDocumentTransmissionDAO();
        result.setFindDocumentTransmission(fdtDao.selectVO(cond));

        // 画面項目表示列制御マスタ取得
        Mbj37DisplayControlDAO dcdao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        Mbj37DisplayControlCondition dccond = new Mbj37DisplayControlCondition();
        dccond.setFormid(cond.getFormId());
        result.setDisplayControl(dcdao.selectVO(dccond));

        // 機能制御Infoの取得
        FunctionControlInfoManager funcmanager = FunctionControlInfoManager.getInstance();
        FunctionControlInfoCondition funccond = new FunctionControlInfoCondition();
        funccond.setFormid(cond.getFormId());
        funccond.setFunctype(cond.getFuncType());
        funccond.setHamid(cond.getHamId());
        funccond.setUsertype(cond.getUserType());
        funccond.setKksikognzuntcd(cond.getKksikognzuntcd());
        result.setFunctionControlInfoVoList(funcmanager.getFunctionControlInfo(funccond).getFunctionControlInfo());

        return result;
    }


    /**
     * 帳票出力データを取得する
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    public FindDocTransReportResult findDocTransReport(FindDocTransReportCondition cond) throws HAMException {

        FindDocTransReportResult result = new FindDocTransReportResult();

        // 帳票出力情報取得
        FindDocTransReportDAO fdtrDao = FindDocTransReportDAOFactory.createFindDocTransReportDAO();
        List<FindDocTransReportVO> reportVoList = new ArrayList<FindDocTransReportVO>();
        for (int counter = 0; counter < cond.getDcarcd().size(); counter++) {
            reportVoList.addAll(fdtrDao.selectVO(cond, counter));
        }
        result.setReport(reportVoList);

        // 部署マスタ(送稿表)取得
        Mbj32DepartmentDAO depDao = Mbj32DepartmentDAOFactory.createMbj32DepartmentDAO();
        Mbj32DepartmentCondition depCond = new Mbj32DepartmentCondition();
        depCond.setDatatype(cond.getKeyCodeDt());
        depCond.setOutputflg("1");
        result.setDep(depDao.selectVO(depCond));

        // 新聞マスタ取得
        Mbj47NewspaperDAO npDao = Mbj47NewspaperDAOFactory.createMbj47NewspaperDAO();
        result.setNp(npDao.selectVO(new Mbj47NewspaperCondition()));

        return result;
    }
}
