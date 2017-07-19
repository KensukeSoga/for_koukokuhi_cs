package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * ��ʁ|������}�X�^DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class RepaVbjaMea11DisplayIrskDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private RepaVbjaMea11DisplayIrskDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static RepaVbjaMea11DisplayIrskDAO createRepaVbjaMea11DisplayIrskDAO() {
        return (RepaVbjaMea11DisplayIrskDAO) DaoFactory.createDao(RepaVbjaMea11DisplayIrskDAO.class);
    }

}
