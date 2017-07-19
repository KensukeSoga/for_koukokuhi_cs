package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * ���W�I�ԑgDAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/10/31 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj37RdProgramDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private Tbj37RdProgramDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static Tbj37RdProgramDAO createTbj37RdProgramDAO() {
        return (Tbj37RdProgramDAO) DaoFactory.createDao(Tbj37RdProgramDAO.class);
    }

}
