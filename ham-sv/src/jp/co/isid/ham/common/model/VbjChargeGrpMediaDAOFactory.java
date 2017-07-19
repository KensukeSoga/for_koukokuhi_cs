package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * mass�V�X�e�� �r���[DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class VbjChargeGrpMediaDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private VbjChargeGrpMediaDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static VbjChargeGrpMediaDAO createVbjChargeGrpMediaDAO() {
        return (VbjChargeGrpMediaDAO) DaoFactory.createDao(VbjChargeGrpMediaDAO.class);
    }

}
