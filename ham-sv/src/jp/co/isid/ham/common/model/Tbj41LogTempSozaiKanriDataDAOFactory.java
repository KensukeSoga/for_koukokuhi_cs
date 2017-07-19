package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * ���f�ޓo�^�ύX���ODAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/10/31 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj41LogTempSozaiKanriDataDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private Tbj41LogTempSozaiKanriDataDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static Tbj41LogTempSozaiKanriDataDAO createTbj41LogTempSozaiKanriDataDAO() {
        return (Tbj41LogTempSozaiKanriDataDAO) DaoFactory.createDao(Tbj41LogTempSozaiKanriDataDAO.class);
    }

}
