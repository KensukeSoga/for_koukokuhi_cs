package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �}�̃}�X�^(����)DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Mbj49MediaProductionDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private Mbj49MediaProductionDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static Mbj49MediaProductionDAO createMbj49MediaProductionDAO() {
        return (Mbj49MediaProductionDAO) DaoFactory.createDao(Mbj49MediaProductionDAO.class);
    }

}