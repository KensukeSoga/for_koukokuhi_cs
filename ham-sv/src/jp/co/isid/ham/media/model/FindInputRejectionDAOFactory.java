package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * ���͋��ۃf�[�^�X�VDAO�̃t�@�N�g���N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/17 FM H.Izawa)<BR>
 * </P>
 *
 * @author FM H.Izawa
 */
final class FindInputRejectionDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~���܂�
     */
    private FindInputRejectionDAOFactory() {
    }

    /**
     * ���͋��ۃf�[�^����DAO�C���X�^���X�𐶐����܂�
     *
     * @return DAO�C���X�^���X
     */
    public static FindInputRejectionDAO createFindInputRejectionDAO() {
        return (FindInputRejectionDAO) DaoFactory.createDao(FindInputRejectionDAO.class);
    }
}
