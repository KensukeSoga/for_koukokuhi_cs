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

    /** �V���O���g���C���X�^���X */
    private static DocumentTransmissionManager _manager = new DocumentTransmissionManager();

    /***
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private DocumentTransmissionManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static DocumentTransmissionManager getInstance() {
        return _manager;
    }

    /**
     * ��ʕ\���f�[�^���擾����
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    public FindDocumentTransmissionResult findDocumentTransmission(FindDocumentTransmissionCondition cond) throws HAMException {

        FindDocumentTransmissionResult result = new FindDocumentTransmissionResult();

        // ���e�\�̉�ʕ\���f�[�^���擾
        FindDocumentTransmissionDAO fdtDao = FindDocumentTransmissionDAOFactory.createFindDocumentTransmissionDAO();
        result.setFindDocumentTransmission(fdtDao.selectVO(cond));

        // ��ʍ��ڕ\���񐧌�}�X�^�擾
        Mbj37DisplayControlDAO dcdao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        Mbj37DisplayControlCondition dccond = new Mbj37DisplayControlCondition();
        dccond.setFormid(cond.getFormId());
        result.setDisplayControl(dcdao.selectVO(dccond));

        // �@�\����Info�̎擾
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
     * ���[�o�̓f�[�^���擾����
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    public FindDocTransReportResult findDocTransReport(FindDocTransReportCondition cond) throws HAMException {

        FindDocTransReportResult result = new FindDocTransReportResult();

        // ���[�o�͏��擾
        FindDocTransReportDAO fdtrDao = FindDocTransReportDAOFactory.createFindDocTransReportDAO();
        List<FindDocTransReportVO> reportVoList = new ArrayList<FindDocTransReportVO>();
        for (int counter = 0; counter < cond.getDcarcd().size(); counter++) {
            reportVoList.addAll(fdtrDao.selectVO(cond, counter));
        }
        result.setReport(reportVoList);

        // �����}�X�^(���e�\)�擾
        Mbj32DepartmentDAO depDao = Mbj32DepartmentDAOFactory.createMbj32DepartmentDAO();
        Mbj32DepartmentCondition depCond = new Mbj32DepartmentCondition();
        depCond.setDatatype(cond.getKeyCodeDt());
        depCond.setOutputflg("1");
        result.setDep(depDao.selectVO(depCond));

        // �V���}�X�^�擾
        Mbj47NewspaperDAO npDao = Mbj47NewspaperDAOFactory.createMbj47NewspaperDAO();
        result.setNp(npDao.selectVO(new Mbj47NewspaperCondition()));

        return result;
    }
}
