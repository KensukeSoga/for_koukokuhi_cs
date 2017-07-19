package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * HC���i�}�X�^DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Mbj08HcProductDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private Mbj08HcProductDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static Mbj08HcProductDAO createMbj08HcProductDAO() {
        return (Mbj08HcProductDAO) DaoFactory.createDao(Mbj08HcProductDAO.class);
    }

}
