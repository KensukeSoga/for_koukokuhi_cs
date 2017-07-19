package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �l������DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class RepaVbjaMeu19NbJkDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private RepaVbjaMeu19NbJkDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static RepaVbjaMeu19NbJkDAO createRepaVbjaMeu19NbJkDAO() {
        return (RepaVbjaMeu19NbJkDAO) DaoFactory.createDao(RepaVbjaMeu19NbJkDAO.class);
    }

}
