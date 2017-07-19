package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.model.base.HAMException;


public class FindProductionChangeCheckManager {


    /** �V���O���g���C���X�^���X */
    private static FindProductionChangeCheckManager _manager = new FindProductionChangeCheckManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private FindProductionChangeCheckManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static FindProductionChangeCheckManager getInstance() {
        return _manager;
    }


    /**
     * ���쌴���ύX�����������܂�
     *
     * @return FindProductionChangeCheckResult ���쌴���ύX���
     * @throws HAMException
     *             �������ɃG���[�����������ꍇ
     */
    public FindProductionChangeCheckResult findProductionChangeCheck(FindProductionChangeCheckCondition cond)
            throws HAMException {

        StringBuffer estDetailSeqno = new StringBuffer();

        //��������
        FindProductionChangeCheckResult result = new FindProductionChangeCheckResult();

        // ******************************************************
        // �쐬���̏��擾
        // ******************************************************
        FindBeforeProductionDAO beforeDao = FindProductionChangeCheckDAOFactory.createFindBeforeProductionDao();
        List<FindBeforeProductionVO> beforelist = beforeDao.selectVO(cond);
        result.setBeforeProduction(beforelist);

        int index = 0;
        for (FindBeforeProductionVO vo: beforelist) {
            if (index != 0) {
                estDetailSeqno.append(",");
            }
            estDetailSeqno.append("'");
            estDetailSeqno.append(vo.getSEQUENCENO().toString());
            estDetailSeqno.append("'");
            index++;
        }

       // ******************************************************
        // ���݂̏��擾
        // ******************************************************
        if (estDetailSeqno.length() > 0) {
            FindNowProductionDAO nowDao = FindProductionChangeCheckDAOFactory.createFindNowProductionDao();
            List<FindNowProductionVO> nowlist = nowDao.selectVO(cond, estDetailSeqno.toString());
            result.setNowProduction(nowlist);
        }

        // ******************************************************
        // ��ʍ��ڕ\���񐧌�}�X�^�擾
        // ******************************************************
        Mbj37DisplayControlDAO dcdao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        Mbj37DisplayControlCondition dccond = new Mbj37DisplayControlCondition();
        dccond.setFormid(cond.getFormID());
        result.setDisplayControl(dcdao.selectVO(dccond));

        return result;
    }
}
