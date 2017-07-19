package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

final class FindMediaByCommonMasterDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~���܂�
     */
    private FindMediaByCommonMasterDAOFactory() {
    }

    /**
     * �}�̌����C���X�^���X�𐶐�
     *
     * @return DAO�C���X�^���X
     */
    public static FindMediaByCommonMasterDAO createFindAuthorityAccountBookDAO() {
        return (FindMediaByCommonMasterDAO) DaoFactory.createDao(FindMediaByCommonMasterDAO.class);
    }
}
