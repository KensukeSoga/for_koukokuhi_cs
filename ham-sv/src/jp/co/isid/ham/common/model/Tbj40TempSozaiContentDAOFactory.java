package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �_�񉼑f�ޕR�t��DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/10/31 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj40TempSozaiContentDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private Tbj40TempSozaiContentDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static Tbj40TempSozaiContentDAO createTbj40TempSozaiContentDAO() {
        return (Tbj40TempSozaiContentDAO) DaoFactory.createDao(Tbj40TempSozaiContentDAO.class);
    }

}
