package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �ŏI�X�V�ҏ��̃t�@�N�g���N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/03 HLC H.Watabe)<BR>
 * </P>
 *
 * @author HLC H.Watabe
 */
public class FindLastUpdAccountBookDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~���܂�
     */
    private FindLastUpdAccountBookDAOFactory() {
    }

    /**
     * �ŏI�X�V�ҏ��DAO�C���X�^���X�𐶐�
     *
     * @return DAO�C���X�^���X
     */
    public static FindLastUpdAccountBookDAO createFindLastUpdAccountBookDAO() {
        return (FindLastUpdAccountBookDAO) DaoFactory.createDao(FindLastUpdAccountBookDAO.class);
    }

}
