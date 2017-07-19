package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �g�D�}�X�^DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class RepaVbjaMeu00SikDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private RepaVbjaMeu00SikDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static RepaVbjaMeu00SikDAO createRepaVbjaMeu00SikDAO() {
        return (RepaVbjaMeu00SikDAO) DaoFactory.createDao(RepaVbjaMeu00SikDAO.class);
    }

}
