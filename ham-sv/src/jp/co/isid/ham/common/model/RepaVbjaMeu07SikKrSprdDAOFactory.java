package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �o���g�D�W�J�e�[�u��DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class RepaVbjaMeu07SikKrSprdDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private RepaVbjaMeu07SikKrSprdDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static RepaVbjaMeu07SikKrSprdDAO createRepaVbjaMeu07SikKrSprdDAO() {
        return (RepaVbjaMeu07SikKrSprdDAO) DaoFactory.createDao(RepaVbjaMeu07SikKrSprdDAO.class);
    }

}
