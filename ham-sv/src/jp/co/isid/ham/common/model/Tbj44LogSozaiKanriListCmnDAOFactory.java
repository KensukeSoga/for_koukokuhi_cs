package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �f�ވꗗ�i���L�j���ODAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/10/31 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj44LogSozaiKanriListCmnDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private Tbj44LogSozaiKanriListCmnDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static Tbj44LogSozaiKanriListCmnDAO createTbj44LogSozaiKanriListCmnDAO() {
        return (Tbj44LogSozaiKanriListCmnDAO) DaoFactory.createDao(Tbj44LogSozaiKanriListCmnDAO.class);
    }

}
