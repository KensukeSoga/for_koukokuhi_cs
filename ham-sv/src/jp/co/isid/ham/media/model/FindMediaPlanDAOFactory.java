package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �}�̏󋵊Ǘ�DAO�̃t�@�N�g���N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/01/18 HLC M.Tsuchiya)<BR>
 * </P>
 *
 * @author HLC M.Tsuchiya
 */

final class FindMediaPlanDAOFactory extends DaoFactory{

    /**
     * �C���X�^���X�����֎~���܂�
     */
    private FindMediaPlanDAOFactory() {
    }

    /**
     * �}�̏󋵊Ǘ�DAO�C���X�^���X�𐶐�
     *
     * @return DAO�C���X�^���X
     */
    public static FindMediaPlanDAO createFindMediaPlanDAO() {
        return (FindMediaPlanDAO) DaoFactory.createDao(FindMediaPlanDAO.class);
    }

//    /**
//     * �}�̎�ʎ擾DAO�C���X�^���X���쐬
//     *
//     * @return DAO�C���X�^���X
//     */
//    public static FindMediaCategoryDAO createFindMediaCategoryDAO() {
//        return (FindMediaCategoryDAO)DaoFactory.createDao(FindMediaCategoryDAO.class);
//    }


    /**
     * �}�̏󋵊Ǘ��̃L�����y�[���擾DAO�C���X�^���X���쐬
     *
     * @return DAO�C���X�^���X
     */
    public static FindMediaPlanCampaignDAO createFindMediaPlanCampaignDAO() {
        return (FindMediaPlanCampaignDAO)DaoFactory.createDao(FindMediaPlanCampaignDAO.class);
    }
}
