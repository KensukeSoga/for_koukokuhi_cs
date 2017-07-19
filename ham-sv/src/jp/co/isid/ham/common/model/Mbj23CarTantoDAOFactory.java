package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �Ԏ�S���҃}�X�^DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Mbj23CarTantoDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private Mbj23CarTantoDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static Mbj23CarTantoDAO createMbj23CarTantoDAO() {
        return (Mbj23CarTantoDAO) DaoFactory.createDao(Mbj23CarTantoDAO.class);
    }

}
