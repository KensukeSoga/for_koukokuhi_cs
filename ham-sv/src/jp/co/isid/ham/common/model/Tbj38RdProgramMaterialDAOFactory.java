package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * ���W�I�ԑg�f��DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/10/31 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj38RdProgramMaterialDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private Tbj38RdProgramMaterialDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static Tbj38RdProgramMaterialDAO createTbj38RdProgramMaterialDAO() {
        return (Tbj38RdProgramMaterialDAO) DaoFactory.createDao(Tbj38RdProgramMaterialDAO.class);
    }

}
