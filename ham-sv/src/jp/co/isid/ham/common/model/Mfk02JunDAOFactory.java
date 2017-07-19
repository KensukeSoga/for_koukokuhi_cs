package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * ���j�b�gNo.�}�X�^DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Mfk02JunDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private Mfk02JunDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static Mfk02JunDAO createMfk02JunDAO() {
        return (Mfk02JunDAO) DaoFactory.createDao(Mfk02JunDAO.class);
    }

}
