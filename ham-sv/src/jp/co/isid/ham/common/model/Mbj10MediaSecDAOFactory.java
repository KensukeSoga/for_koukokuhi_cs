package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �}�̌����}�X�^DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Mbj10MediaSecDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private Mbj10MediaSecDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static Mbj10MediaSecDAO createMbj10MediaSecDAO() {
        return (Mbj10MediaSecDAO) DaoFactory.createDao(Mbj10MediaSecDAO.class);
    }

}
