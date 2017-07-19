package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �}�̃p�^�[�����e�}�X�^DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Mbj36MediaPatternItemDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private Mbj36MediaPatternItemDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static Mbj36MediaPatternItemDAO createMbj36MediaPatternItemDAO() {
        return (Mbj36MediaPatternItemDAO) DaoFactory.createDao(Mbj36MediaPatternItemDAO.class);
    }

}
