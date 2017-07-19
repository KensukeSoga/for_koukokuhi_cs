package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �n��}�X�^DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Mbj04KeiretsuDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private Mbj04KeiretsuDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static Mbj04KeiretsuDAO createMbj04KeiretsuDAO() {
        return (Mbj04KeiretsuDAO) DaoFactory.createDao(Mbj04KeiretsuDAO.class);
    }

}
