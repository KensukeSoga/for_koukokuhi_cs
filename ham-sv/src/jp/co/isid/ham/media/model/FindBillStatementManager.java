package jp.co.isid.ham.media.model;

import java.util.List;

import jp.co.isid.ham.common.model.CarListCondition;
import jp.co.isid.ham.common.model.CarListDAO;
import jp.co.isid.ham.common.model.CarListDAOFactory;
import jp.co.isid.ham.common.model.FunctionControlInfoCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoManager;
import jp.co.isid.ham.model.base.HAMException;

public class FindBillStatementManager {

    /** �V���O���g���C���X�^���X */
    private static FindBillStatementManager _manager = new FindBillStatementManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private FindBillStatementManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static FindBillStatementManager getInstance() {
        return _manager;
    }

    /**
     * �������׏��\�������������܂�
     *
     * @return FindCampaignListResult �c�ƍ�Ƒ䒠���
     * @throws HAMException
     *             �������ɃG���[�����������ꍇ
     */
    public FindBillStatementResult findBillStatement(FindBillStatementCondition cond)
            throws HAMException {


        //��������
        FindBillStatementResult result = new FindBillStatementResult();

        // ******************************************************
        // �c�ƍ�Ƒ䒠���̎擾
        // ******************************************************
        FindLastUpdAccountBookDAO abdao = FindLastUpdAccountBookDAOFactory.createFindLastUpdAccountBookDAO();
        result.setTbj02EigyoDaicho(abdao.findLastUpdAccountBook(cond));

        // �Ԏ�ꗗ��@�\����́A����N�����̂ݎ擾
        if (cond.getLoadFlg()) {

            // ******************************************************
            // �Ԏ�ꗗ�擾
            // ******************************************************
            CarListDAO cldao =CarListDAOFactory.createCarListDAO();
            CarListCondition clcond = new CarListCondition();
            clcond.setHamid(cond.getHamid());
            clcond.setSecType("0");
            result.setCarList(cldao.findCarList(clcond));

            // ******************************************************
            // �@�\����Info�̎擾
            // ******************************************************
            FunctionControlInfoManager funcmanager = FunctionControlInfoManager.getInstance();
            FunctionControlInfoCondition funccond = new FunctionControlInfoCondition();
            funccond.setFormid(cond.getFormID());
            funccond.setFunctype(cond.getFuncType());
            funccond.setHamid(cond.getHamid());
            funccond.setUsertype(cond.getUsertype());
            funccond.setKksikognzuntcd(cond.getKksikognzuntcd());
            result.setFunctionControlInfoVoList(funcmanager.getFunctionControlInfo(funccond).getFunctionControlInfo());
        }

        return result;
    }

    /**
     * �������׏��ɏo�͂�������擾
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    public FindBillStatementDataResult findBillStatementOutData(FindBillStatementDataCondition cond)
            throws HAMException {

        //��������
        FindBillStatementDataResult result = new FindBillStatementDataResult();

        // ******************************************************
        // �������׏��o�͏��̎擾
        // ******************************************************
        FindBillStatementDataDAO billdao = FindBillStatementDataDAOFactory.createFindBillStatementDataDAO();
        List<FindBillStatementDataVO> billlist =billdao.findBillOutputData(cond);
        result.setTbj02EigyoDaicho(billlist);

        return result;
    }
}
