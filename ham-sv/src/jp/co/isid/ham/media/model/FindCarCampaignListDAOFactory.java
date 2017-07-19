package jp.co.isid.ham.media.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * �L�����y�[���ꗗ���DAO�̃t�@�N�g���N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/30 FM H.Izawa)<BR>
 * </P>
 *
 * @author FM H.Izawa
 */
final class FindCarCampaignListDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~���܂�
     */
    private FindCarCampaignListDAOFactory() {
    }

    /**
     * �L�����y�[���f�[�^�擾DAO�C���X�^���X�𐶐����܂�
     *
     * @return DAO�C���X�^���X
     */
    public static FindCampaignListDAO createFindCampaignListDAO() {
        return (FindCampaignListDAO) DaoFactory.createDao(FindCampaignListDAO.class);
    }

    public static FindCarListDAO createFindCarListDAO() {
        return (FindCarListDAO)DaoFactory.createDao(FindCarListDAO.class);
    }
}
