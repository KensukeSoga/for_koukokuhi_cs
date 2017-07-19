package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

final class FindCooperationDataDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~���܂�
     */
    private FindCooperationDataDAOFactory() {
    }

    /**
     * �l�����敪DAO�C���X�^���X�𐶐�
     *
     * @return DAO�C���X�^���X
     */
    public static FindDiscountFlgDAO createFindDiscountFlgDAO() {
        return (FindDiscountFlgDAO) DaoFactory.createDao(FindDiscountFlgDAO.class);
    }

    /**
     * ���DAO�C���X�^���X�𐶐�
     * @return DAO�C���X�^���X
     */
    public static FindItemDAO createFindItemDAO() {
        return (FindItemDAO) DaoFactory.createDao(FindItemDAO.class);
    }

    /**
     * �g�DDAO�C���X�^���X�𐶐�
     * @return DAO�C���X�^���X
     */
    public static FindSocietyDataDAO createFindSocietyDataDAO() {
        return(FindSocietyDataDAO) DaoFactory.createDao(FindSocietyDataDAO.class);
    }
}
