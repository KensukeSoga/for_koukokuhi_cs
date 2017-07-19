package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �V�G�}�̃}�X�^DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class RepaVbjaMeu20MsMzBtDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private RepaVbjaMeu20MsMzBtDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static RepaVbjaMeu20MsMzBtDAO createRepaVbjaMeu20MsMzBtDAO() {
        return (RepaVbjaMeu20MsMzBtDAO) DaoFactory.createDao(RepaVbjaMeu20MsMzBtDAO.class);
    }

}
