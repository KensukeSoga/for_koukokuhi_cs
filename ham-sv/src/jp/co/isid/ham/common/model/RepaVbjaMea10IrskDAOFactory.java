package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * ������}�X�^DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class RepaVbjaMea10IrskDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private RepaVbjaMea10IrskDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static RepaVbjaMea10IrskDAO createRepaVbjaMea10IrskDAO() {
        return (RepaVbjaMea10IrskDAO) DaoFactory.createDao(RepaVbjaMea10IrskDAO.class);
    }

}
