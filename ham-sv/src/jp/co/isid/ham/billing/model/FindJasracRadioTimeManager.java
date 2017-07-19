package jp.co.isid.ham.billing.model;

import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj12CodeDAO;
import jp.co.isid.ham.common.model.Mbj12CodeDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * JASRAC�\����(���W�I�^�C��)����Manager
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/11/17 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindJasracRadioTimeManager {

    /** �V���O���g���C���X�^���X */
    private static FindJasracRadioTimeManager _manager = new FindJasracRadioTimeManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private FindJasracRadioTimeManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static FindJasracRadioTimeManager getInstance() {
        return _manager;
    }

    /**
     * JASRAC�\����(���W�I�^�C��)�o�͏�����������
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    public FindJasracRadioTimeResult findJasracRadioTimeOutputInfo(FindJasracRadioTimeCondition cond) throws HAMException {

        //��������
        FindJasracRadioTimeResult result = new FindJasracRadioTimeResult();

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
        FindJasracRadioTimeDAO jasracRTdao = FindJasracRadioTimeDAOFactory.createFindJasracRadioTimeDao();
        result.setJasracInfo(jasracRTdao.selectVO(cond));

        return result;
    }

}
