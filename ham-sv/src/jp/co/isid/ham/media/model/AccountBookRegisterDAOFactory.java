package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �c�ƍ�Ƒ䒠�X�VDAO�̃t�@�N�g���N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/14 HLC H.Watabe)<BR>
 * </P>
 *
 * @author HLC H.Watabe
 */
final class AccountBookRegisterDAOFactory extends DaoFactory{
    /**
     * �C���X�^���X�����֎~���܂�
     */
    private AccountBookRegisterDAOFactory() {
    }

    /**
     * �c�ƍ�Ƒ䒠�X�VDAO�C���X�^���X�𐶐����܂�
     *
     * @return DAO�C���X�^���X
     */
    public static AccountBookRegisterDAO createAccountBookRegisterDAO() {
        return (AccountBookRegisterDAO) DaoFactory.createDao(AccountBookRegisterDAO.class);
    }


    public static AccountBookLogRegisterDAO createAccountBookLogRegisterDAO() {
        return (AccountBookLogRegisterDAO) DaoFactory.createDao(AccountBookLogRegisterDAO.class);
    }

    /**
     * �\�[�g���擾DAO�C���X�^���X�𐶐����܂�
     *
     * @return DAO�C���X�^���X
     */
    public static FindAccountBookSortNoDAO createFindAccountBookSortNoDAO() {
        return (FindAccountBookSortNoDAO) DaoFactory.createDao(FindAccountBookSortNoDAO.class);
    }

}
