package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �����S���i���jDAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class RepaVbjaMeu15ThsTntHrDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private RepaVbjaMeu15ThsTntHrDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static RepaVbjaMeu15ThsTntHrDAO createRepaVbjaMeu15ThsTntHrDAO() {
        return (RepaVbjaMeu15ThsTntHrDAO) DaoFactory.createDao(RepaVbjaMeu15ThsTntHrDAO.class);
    }

}
