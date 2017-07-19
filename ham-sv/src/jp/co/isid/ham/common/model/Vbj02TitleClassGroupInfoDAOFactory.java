package jp.co.isid.ham.common.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �VHAM����VIEW(�E�ʓ����O���[�v���)DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Vbj02TitleClassGroupInfoDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private Vbj02TitleClassGroupInfoDAOFactory() {
    }

    /**
     * DAO�C���X�^���X�𐶐�����
     *
     * @return DAO�C���X�^���X
     */
    public static Vbj02TitleClassGroupInfoDAO createVbj02TitleClassGroupInfoDAO() {
        return (Vbj02TitleClassGroupInfoDAO) DaoFactory.createDao(Vbj02TitleClassGroupInfoDAO.class);
    }

}
