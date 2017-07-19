package jp.co.isid.ham.media.model;

import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * �}�̏󋵊Ǘ��f�[�^�I�����Manager
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/01/28 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindMediaPlanSelectManager {

    /** �V���O���g���C���X�^���X */
    private static FindMediaPlanSelectManager _manager = new FindMediaPlanSelectManager();

    /***
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    public FindMediaPlanSelectManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static FindMediaPlanSelectManager getInstance() {
        return _manager;
    }

    /**
     * �}�̏󋵊Ǘ��f�[�^�I����ʏ����������܂�
     *
     * @return FindMediaPlanSelectResult �}�̏󋵊Ǘ��f�[�^�I����ʏ��
     * @throws HAMException �������ɃG���[�����������ꍇ
     */
    public FindMediaPlanSelectResult findMediaPlanSelect(FindMediaPlanSelectCondition cond) throws HAMException {

        //��������
        FindMediaPlanSelectResult result = new FindMediaPlanSelectResult();

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
