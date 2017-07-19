package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * �I�������Ǘ�
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/13 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class ShutDownManager {

    /** �V���O���g���C���X�^���X */
    private static ShutDownManager _manager = new ShutDownManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private ShutDownManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     * @return �C���X�^���X
     */
    public static ShutDownManager getInstance() {
        return _manager;
    }

    /**
     * �I������
     * @param tbj29vo
     * @return
     * @throws HAMException
     */
    public ShutDownResult shutDown(Tbj29LoginUserVO tbj29vo) throws HAMException {

        ShutDownResult result = new ShutDownResult();

        // ���O�C�����[�U�[�폜
        Tbj29LoginUserDAO dao = Tbj29LoginUserDAOFactory.createTbj29LoginUserDAO();
        Tbj29LoginUserCondition tbj29cond = new Tbj29LoginUserCondition();
        tbj29cond.setHamid(tbj29vo.getHAMID());
        List<Tbj29LoginUserVO> tbl29list = dao.selectVO(tbj29cond);
        if (tbl29list.size() > 0) {
            dao.deleteVO(tbj29vo);
        }

        return result;
    }

}
