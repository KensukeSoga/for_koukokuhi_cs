package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �VHAM����VIEW(�E�ʓ����O���[�v�����o�[���)DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Vbj03TitleClassMemberDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private Vbj03TitleClassMemberDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static Vbj03TitleClassMemberDAO createVbj03TitleClassMemberDAO() {
        return (Vbj03TitleClassMemberDAO) DaoFactory.createDao(Vbj03TitleClassMemberDAO.class);
    }

}
