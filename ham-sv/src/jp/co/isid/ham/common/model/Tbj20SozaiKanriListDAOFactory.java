package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �f�ވꗗDAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj20SozaiKanriListDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private Tbj20SozaiKanriListDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static Tbj20SozaiKanriListDAO createTbj20SozaiKanriListDAO() {
        return (Tbj20SozaiKanriListDAO) DaoFactory.createDao(Tbj20SozaiKanriListDAO.class);
    }

}
