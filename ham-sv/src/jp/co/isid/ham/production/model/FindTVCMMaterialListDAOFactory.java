package jp.co.isid.ham.production.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * TVCM�f�ވꗗ��񌟍�DAO�t�@�N�g���N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2016/03/10 HLC K.Oki)<BR>
 * </P>
 *
 * @author K.Oki
 */
public class FindTVCMMaterialListDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~���܂�
     */
    private FindTVCMMaterialListDAOFactory() {
    }

    /**
     * TVCM�f�ވꗗ��񌟍�DAO�C���X�^���X�𐶐����܂�
     * @return TVCM�f�ވꗗ��񌟍�DAO�C���X�^���X
     */
    public static FindTVCMMaterialListDAO createFindTVCMMaterialListDAOFactory() {
        return (FindTVCMMaterialListDAO) DaoFactory.createDao(FindTVCMMaterialListDAO.class);
    }

}
