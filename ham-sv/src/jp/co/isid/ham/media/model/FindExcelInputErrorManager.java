package jp.co.isid.ham.media.model;

import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

public class FindExcelInputErrorManager {

    /** �V���O���g���C���X�^���X */
    private static FindExcelInputErrorManager _manager = new FindExcelInputErrorManager();

    /***
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    public FindExcelInputErrorManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static FindExcelInputErrorManager getInstance() {
        return _manager;
    }

    /**
     * �c�ƍ�Ƒ䒠�����������܂�
     *
     * @return FindCampaignListResult �c�ƍ�Ƒ䒠���
     * @throws HAMException
     *             �������ɃG���[�����������ꍇ
     */
    public FindExcelInputErrorResult findExcelInputError(FindExcelInputErrorCondition cond)
            throws HAMException {


        //��������
        FindExcelInputErrorResult result = new FindExcelInputErrorResult();

        // ******************************************************
        // ��ʍ��ڕ\���񐧌�}�X�^�擾
        // ******************************************************
        Mbj37DisplayControlDAO dcdao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        Mbj37DisplayControlCondition dccond = new Mbj37DisplayControlCondition();
        dccond.setFormid(cond.getFormID());
        result.setMbj37DisplayControl(dcdao.selectVO(dccond));

        return result;
    }
}
