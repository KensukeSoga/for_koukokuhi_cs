package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * ���f�ޓo�^DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/10/31 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj36TempSozaiKanriDataDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private Tbj36TempSozaiKanriDataDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static Tbj36TempSozaiKanriDataDAO createTbj36TempSozaiKanriDataDAO() {
        return (Tbj36TempSozaiKanriDataDAO) DaoFactory.createDao(Tbj36TempSozaiKanriDataDAO.class);
    }

}
