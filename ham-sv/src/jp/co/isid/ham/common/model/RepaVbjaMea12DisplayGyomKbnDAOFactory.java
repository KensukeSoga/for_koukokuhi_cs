package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * ��ʁ|�Ɩ��敪DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class RepaVbjaMea12DisplayGyomKbnDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private RepaVbjaMea12DisplayGyomKbnDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static RepaVbjaMea12DisplayGyomKbnDAO createRepaVbjaMea12DisplayGyomKbnDAO() {
        return (RepaVbjaMea12DisplayGyomKbnDAO) DaoFactory.createDao(RepaVbjaMea12DisplayGyomKbnDAO.class);
    }

}