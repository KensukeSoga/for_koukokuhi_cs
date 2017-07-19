package jp.co.isid.ham.billing.model;

import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj12CodeDAO;
import jp.co.isid.ham.common.model.Mbj12CodeDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * JASRAC�������׏�(���W�I�^�C��)����Manager
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/11/19 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindJasracRadioTimeBillManager {

    /** �V���O���g���C���X�^���X */
    private static FindJasracRadioTimeBillManager _manager = new FindJasracRadioTimeBillManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private FindJasracRadioTimeBillManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static FindJasracRadioTimeBillManager getInstance() {
        return _manager;
    }

    /**
     * JASRAC�������׏�(���W�I�^�C��)�o�͏�����������
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    public FindJasracRadioTimeBillResult findJasracRadioTimeBillInfo(FindJasracRadioTimeCondition cond) throws HAMException {

        //��������
        FindJasracRadioTimeBillResult result = new FindJasracRadioTimeBillResult();

        //�R�[�h�}�X�^
        StringBuilder codeType = new StringBuilder();
        for (int i = 0; i < cond.getCodeList().size(); i++) {
            codeType.append("'" + cond.getCodeList().get(i) + "',");
        }

        Mbj12CodeDAO mbj12Dao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition mbj12Cond = new Mbj12CodeCondition();
        mbj12Cond.setCodetype(codeType.toString().substring(0, codeType.toString().length() - 1));
        result.setCode(mbj12Dao.FindManyCd(mbj12Cond));

        //JASRAC�\����(���W�I�^�C��)�o�͏��
        FindJasracRadioTimeDAO dao = FindJasracRadioTimeDAOFactory.createFindJasracRadioTimeDao();
        result.setJasracInfo(dao.selectVO(cond));

        return result;
    }

}
