package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �c�ƍ�Ƒ䒠�X�VDAO�̃t�@�N�g���N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/02/28 HLC H.Watabe)<BR>
 * </P>
 *
 * @author HLC H.Watabe
 */
public class UpdABOrderOutRegisterDAOFactory extends DaoFactory {
    /**
     * �C���X�^���X�����֎~���܂�
     */
    private UpdABOrderOutRegisterDAOFactory() {
    }

    /**
     * �c�ƍ�Ƒ䒠�X�VDAO�C���X�^���X�𐶐����܂�
     *
     * @return DAO�C���X�^���X
     */
    public static UpdABOrderOutRegisterDAO createUpdABOrderOutRegisterDAO() {
        return (UpdABOrderOutRegisterDAO) DaoFactory.createDao(UpdABOrderOutRegisterDAO.class);
    }
}
